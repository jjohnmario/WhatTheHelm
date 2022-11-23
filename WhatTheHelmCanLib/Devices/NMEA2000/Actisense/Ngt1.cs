using WhatTheHelmCanLib.Messages;
using WhatTheHelmCanLib.ParameterGroups;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhatTheHelmCanLib.Devices.Nmea2000;
using ActisenseComms.API;
using static ActisenseComms.API.Decode;
using static ActisenseComms.API.NMEA2K;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WhatTheHelmCanLib.Devices.NMEA2000.Actisense
{
    /// <summary>
    /// Represents an Actisense NGT-1 gateway.
    /// </summary>
    public class Ngt1 : N2KDevice, ICanGateway
    {
        public int MessageQueueCount { get => _mainMessageQueue.Count; }
        public DateTime LastRead { get; private set; }
        public event EventHandler<CanMessageArgs> MessageRecieved;
        private SerialPort _serialPort;
        private Queue<NMEA2K.N2KMsg_s> _mainMessageQueue = new Queue<NMEA2K.N2KMsg_s>();
        private bool _scanMainMessageQueue = false;
        private int _actiHandle;
        private ARLErrorCodes_t _error;       /* Error value returned by ActisenseComms API function calls */
        private ActisenseComms.API.Callback _n2kRxCallback;
        private ActisenseComms.API.Decode.Callback _gatewayConfigCallback;
        private object _parseLock = new object();

        /// <summary>
        /// Creates an object reference to an Actisense NGT-1 gateway and binds it to the defined CAN network address and serial port.
        /// </summary>
        /// <param name="serialPort">The host serial port to which the NGT-1 gateway is connected.</param>
        /// <param name="address">The CAN network address to assign the NGT-1 gateway.</param>
        public Ngt1(SerialPort serialPort, ushort address, List<uint> txPgnList, List<uint> rxPgnList) : base(address)
        {
            _serialPort = serialPort;
            TxPgns = txPgnList;
            RxPgns = rxPgnList;
        }

        public void Dispose()
        {
            AComms.DestroyAll();
        }

        public bool Open()
        {
            _scanMainMessageQueue = true;
            /* API Create call creates a new instance of the ActisenseComms library */
            _error = AComms.Create(out _actiHandle);
            if (_error != ARLErrorCodes_t.ES_NoError)
                return false;
            //API Open opens the requested port at the requested baud rate
            uint _portNumber = Convert.ToUInt16(_serialPort.PortName.TrimStart('C', 'O', 'M'));
            _error = AComms.Open(_actiHandle, Convert.ToInt16(_portNumber), _serialPort.BaudRate);
            if (_error != ARLErrorCodes_t.ES_NoError)
                return false;

            //Assign callback method for modifying the configuration of the gateway.
            _gatewayConfigCallback = new Decode.Callback(this.gatewayConfigurationResponseReceived);
            DecodeData_t[] ResponseList = { DecodeData_t.ddCANConfig, DecodeData_t.ddHardwareInfo, DecodeData_t.ddPortBaudCfg, DecodeData_t.ddPortPCodeCfg, DecodeData_t.ddProductInfoN2K, DecodeData_t.ddRxPGNEnableList, DecodeData_t.ddTxPGNEnableList, DecodeData_t.ddCANInfoField1, DecodeData_t.ddCANInfoField2, DecodeData_t.ddCANInfoField3, DecodeData_t.ddEnableRxPGN, DecodeData_t.ddEnableTxPGN, DecodeData_t.ddHardwareBaud, DecodeData_t.ddOperatingMode, DecodeData_t.ddStartupStatus, DecodeData_t.ddTotalTime, DecodeData_t.ddDeletePGNEnableList };
            _error = Decode.SetCallbackGroup(_actiHandle, ResponseList, ResponseList.Length, _gatewayConfigCallback, new IntPtr(0));
            if (_error != ARLErrorCodes_t.ES_NoError)
            {
                return false;
            }

            //Assign callback method for when a new N2K message is recieved from gateway
            _n2kRxCallback = new ActisenseComms.API.Callback(n2kRxCallbackHandler);
            _error = NMEA2K.SetRxCallback(_actiHandle, _n2kRxCallback, new IntPtr(0));
            if (_error != ARLErrorCodes_t.ES_NoError)
                return false;

            //Open connection to the gateway
            _error = ACommand.SetStream(_actiHandle, stream_t.CmdStreamBST);
            if (_error != ARLErrorCodes_t.ES_NoError)
                return false;
            
            //Configure gateway
            configureGateway(out _error);
            if (_error != ARLErrorCodes_t.ES_NoError)
                return false;

            //Start scanning the message queue
            Task.Run(() => scanMainMessageQueue()).ContinueWith((t) => {
                if (t.IsFaulted)
                    Task.Run(() => scanMainMessageQueue());
            });
            return true;
        }

        private bool configureGateway(out ARLErrorCodes_t error)
        {
            //Clear existing PGN lists
            error = ACommand.ClearPGNList(_actiHandle, PGNEnableList_t.ENABLE_LIST_RX);
            //error = ACommand.SetOperatingMode(_actiHandle, 2);

            //Create new PGN lists
            //Tx
            foreach (uint pgn in TxPgns)
            {
                error = ACommand.SetTxPGN(_actiHandle, pgn, PGNEnable_t.ENABLE_PGN);
                if (error != ARLErrorCodes_t.ES_NoError)
                    return false;

            }
            //Rx
            foreach (uint pgn in RxPgns)
            {
                error = ACommand.SetRxPGN(_actiHandle, pgn, PGNEnable_t.ENABLE_PGN);
                if (error != ARLErrorCodes_t.ES_NoError)
                    return false;
            }
            //Activate new PGN lists
            ACommand.ActivatePGNEnableLists(_actiHandle);
            error = ARLErrorCodes_t.ES_NoError;
            return true;
        }

        public bool Close()
        {
            AComms.Close(_actiHandle);
            _scanMainMessageQueue = false;
            return true;
        }

        public bool IsoRequest(uint requestedPgn)
        {
            NMEA2K.N2KMsg_s N2Kmsg = new NMEA2K.N2KMsg_s();
            N2Kmsg.PGN = 0x0EA00;
            N2Kmsg.Timestamp = 0;
            N2Kmsg.Src = 255;
            N2Kmsg.Dest = 255;
            N2Kmsg.Size = 3;
            byte[] pgn = BitConverter.GetBytes(requestedPgn);
            N2Kmsg.Data = new byte[NMEA2K.N2K_MAXLEN_FP];
            Array.Copy(pgn, 0, N2Kmsg.Data, 4, 3); // Note that the actual data frame starts at index 4, not index 0 for NGT-1
            ARLErrorCodes_t error = NMEA2K.Write(_actiHandle, ref N2Kmsg);
            if (error != ARLErrorCodes_t.ES_NoError)
                return false;
            else
                return true;
        }

        private void scanMainMessageQueue()
        {
            while (_scanMainMessageQueue)
            {
                //Console.WriteLine(_mainMessageQueue.Count);
                if (_mainMessageQueue.Count > 0)
                {
                    var message = _mainMessageQueue.Dequeue();
                    if (MessageRecieved != null)
                    {
                        var parsedMessage = Parse(message);
                        if(parsedMessage != null)
                            MessageRecieved.Invoke(this, new CanMessageArgs() { Message = parsedMessage });
                    }
                }
            }
        }

        private void n2kRxCallbackHandler(IntPtr UserData)
        {
            /* NMEA2K.Read calls the ActisenseComms API to obtain the new N2K
              * message that has just been received */
            LastRead = DateTime.Now;
            NMEA2K.N2KMsg_s msg;
            _error = NMEA2K.Read(_actiHandle, out msg);
            _mainMessageQueue.Enqueue(msg);
        }

        public CanMessage Parse(object message)
        {
            lock(_parseLock)
            {
                var msg = (NMEA2K.N2KMsg_s)message;
                if (msg.Size != 0 && msg.Data != null)
                {
                    byte[] data = new byte[msg.Size];
                    Array.Copy(msg.Data, 4, data, 0, msg.Size);
                    return new CanMessage(msg.PGN, Format.EXTENDED, msg.Priority, msg.Src, msg.Dest, data);
                }
                else
                    return null;
            }
        }

        public bool Write(CanMessage message)
        {
            NMEA2K.N2KMsg_s N2Kmsg = new NMEA2K.N2KMsg_s();
            N2Kmsg.Timestamp = 0;
            N2Kmsg.Src = (byte)message.SourceAddress;
            N2Kmsg.PGN = message.Pgn;
            if (message.IsAddressible)           
                N2Kmsg.Dest = (byte)message.DestinationAddress;
            else            
                N2Kmsg.Dest = 255;
            N2Kmsg.Size = (uint)message.Data.Length;
            N2Kmsg.Data = new byte[NMEA2K.N2K_MAXLEN_FP];
            Array.Copy(message.Data, 0, N2Kmsg.Data, 4, N2Kmsg.Size); // Note that the actual data frame starts at index 4, not index 0 for NGT-1
            ARLErrorCodes_t error = NMEA2K.Write(_actiHandle, ref N2Kmsg);
            if (error != ARLErrorCodes_t.ES_NoError)
                return false;
            else
                return true;
        }

        private void gatewayConfigurationResponseReceived(IntPtr UserData, DecodeData_t DecodedData, DecodeReason_t DecodeReason)
        {
            if (DecodeReason == DecodeReason_t.drDecodeDataArrived)
            {
                switch (DecodedData)
                {
                    case DecodeData_t.ddDeletePGNEnableList:
                        sDecodeTag Tag;
                        ActisenseComms.API.Decode.GetTag(_actiHandle, out Tag, DecodeData_t.ddDeletePGNEnableList);
                        break;
                    case DecodeData_t.ddStartupStatus:
                        sDecodeStartupStatus StartupStatus;
                        ActisenseComms.API.Decode.GetStartupStatus(_actiHandle, out StartupStatus);
                        break;
                    case DecodeData_t.ddTotalTime:
                        sDecodeTotalTime TotalTime;
                        ActisenseComms.API.Decode.GetTotalTime(_actiHandle, out TotalTime);
                        //DumpStructure(TotalTime);
                        break;
                    case DecodeData_t.ddCANConfig:
                        sDecodeCanConfig CanConfig;
                        ActisenseComms.API.Decode.GetCanConfig(_actiHandle, out CanConfig);
                        //DumpStructure(CanConfig);
                        break;
                    case DecodeData_t.ddHardwareInfo:
                        sDecodeHardwareInfo HardwareInfo;
                        ActisenseComms.API.Decode.GetHardwareInfo(_actiHandle, out HardwareInfo);
                        //DumpStructure(HardwareInfo);
                        break;
                    case DecodeData_t.ddPortBaudCfg:
                        sDecodePortBaudCodes PortBaudCfg;
                        ActisenseComms.API.Decode.GetPortBaudCodes(_actiHandle, out PortBaudCfg);
                        //DumpStructure(PortBaudCfg);
                        break;
                    case DecodeData_t.ddPortPCodeCfg:
                        sDecodeArray_u8 PortPCodeCfg;
                        ActisenseComms.API.Decode.GetPortPCodes(_actiHandle, out PortPCodeCfg);
                        //DumpStructure(PortPCodeCfg);
                        break;
                    case DecodeData_t.ddProductInfoN2K:
                        sDecodeProductInfoN2K ProductInfoN2K;
                        ActisenseComms.API.Decode.GetProductInfoN2K(_actiHandle, out ProductInfoN2K);
                        //DumpStructure(ProductInfoN2K);
                        break;
                    case DecodeData_t.ddCANInfoField1:
                        sDecodeCanInfoField CANInfoField1;
                        ActisenseComms.API.Decode.GetCanInfoField1(_actiHandle, out CANInfoField1);
                        //DumpStructure(CANInfoField1);
                        //ThreadSafe_UpdateCommandDialog(DecodedData, null, 0, CANInfoField1.String);
                        break;
                    case DecodeData_t.ddCANInfoField2:
                        sDecodeCanInfoField CANInfoField2;
                        ActisenseComms.API.Decode.GetCanInfoField2(_actiHandle, out CANInfoField2);
                        //DumpStructure(CANInfoField2);
                        //ThreadSafe_UpdateCommandDialog(DecodedData, null, 0, CANInfoField2.String);
                        break;
                    case DecodeData_t.ddCANInfoField3:
                        sDecodeCanInfoField CANInfoField3;
                        ActisenseComms.API.Decode.GetCanInfoField3(_actiHandle, out CANInfoField3);
                        //DumpStructure(CANInfoField3);
                        //ThreadSafe_UpdateCommandDialog(DecodedData, null, 0, CANInfoField3.String);
                        break;
                    case DecodeData_t.ddEnableRxPGN:
                        sDecodeRxPGN RxPGNEnable;
                        ActisenseComms.API.Decode.GetRxPGN(_actiHandle, out RxPGNEnable);
                        //DumpStructure(RxPGNEnable);
                        break;
                    case DecodeData_t.ddEnableTxPGN:
                        sDecodeTxPGN TxPGNEnable;
                        ActisenseComms.API.Decode.GetTxPGN(_actiHandle, out TxPGNEnable);
                        //DumpStructure(TxPGNEnable);
                        break;
                    case DecodeData_t.ddRxPGNEnableList:
                        sDecodeRxPGNList RxPGNList;
                        ActisenseComms.API.Decode.GetRxPGNList(_actiHandle, out RxPGNList);
                        //DumpStructure(RxPGNList);
                        break;
                    case DecodeData_t.ddTxPGNEnableList:
                        sDecodeTxPGNList TxPGNList;
                        ActisenseComms.API.Decode.GetTxPGNList(_actiHandle, out TxPGNList);
                        //DumpStructure(TxPGNList);
                        break;
                    case DecodeData_t.ddHardwareBaud:
                        sDecodePortBaudCodes HardwareBaud;
                        ActisenseComms.API.Decode.GetHardwareBaudCodes(_actiHandle, out HardwareBaud);
                        //DumpStructure(HardwareBaud);
                        break;
                    case DecodeData_t.ddOperatingMode:
                        sDecodeOperatingMode OperatingMode;
                        ActisenseComms.API.Decode.GetOperatingMode(_actiHandle, out OperatingMode);
                        //DumpStructure(OperatingMode);
                        //ThreadSafe_UpdateCommandDialog(DecodedData, Enum.GetNames(typeof(OperatingMode_t)), (int)OperatingMode.ModeID, null);
                        break;
                }
            }
            
                
        }
    }
}
