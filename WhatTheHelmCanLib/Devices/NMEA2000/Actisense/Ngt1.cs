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
    /// Represents a connected Actisense NGT-1 gateway.
    /// </summary>
    public class Ngt1 : Nmea2000Gateway
    {
        public int MessageQueueCount { get => _mainMessageQueue.Count; }
        public List<uint> RxPgnList { get; }
        public DateTime LastRead { get; private set; }
        public override event EventHandler<CanMessageArgs> MessageRecieved;
        private SerialPort _serialPort;
        private Queue<NMEA2K.N2KMsg_s> _mainMessageQueue = new Queue<NMEA2K.N2KMsg_s>();
        private bool _scanMainMessageQueue = false;
        private int _actiHandle;
        private ARLErrorCodes_t _error;       /* Error value returned by ActisenseComms API function calls */
        private ActisenseComms.API.Callback _n2kRxCallback;
        private object _parseLock = new object();

        /// <summary>
        /// Creates an object reference to an Actisense NGT-1 gateway and binds it to the defined CAN network address and serial port.
        /// </summary>
        /// <param name="serialPort">The host serial port to which the NGT-1 gateway is connected.</param>
        /// <param name="address">The CAN network address to assign the NGT-1 gateway.</param>
        public Ngt1(SerialPort serialPort, ushort address, List<uint> rxPgnList) : base(address)
        {
            _serialPort = serialPort;
            RxPgnList = rxPgnList;
        }

        public override void Dispose()
        {
            AComms.DestroyAll();
        }

        public override bool Open()
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
            //Assign callback method for when a new N2K message is recieved
            _n2kRxCallback = new ActisenseComms.API.Callback(n2kRxCallbackHandler);
            _error = NMEA2K.SetRxCallback(_actiHandle, _n2kRxCallback, new IntPtr(0));
            if (_error != ARLErrorCodes_t.ES_NoError)
                return false;
            IntPtr cPortName = AComms.EnumerateSerialPortsGetName(_portNumber);
            string portName = Marshal.PtrToStringAnsi(cPortName);
            if (portName.Contains("NGT"))
            {
                _error = ACommand.SetStream(_actiHandle, stream_t.CmdStreamBST);
                if (_error != ARLErrorCodes_t.ES_NoError)
                    return false;
            }
            Task.Run(() => scanMainMessageQueue()).ContinueWith((t) => {
                if (t.IsFaulted)
                    Task.Run(() => scanMainMessageQueue());
            });
            return true;
        }

        public override bool Close()
        {
            AComms.Close(_actiHandle);
            _scanMainMessageQueue = false;
            return true;
        }

        private void scanMainMessageQueue()
        {
            while (_scanMainMessageQueue)
            {
                Console.WriteLine(_mainMessageQueue.Count);
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

        public override CanMessage Parse(object message)
        {
            lock(_parseLock)
            {
                var msg = (NMEA2K.N2KMsg_s)message;
                if (msg.Size != 0 && msg.Data != null)
                {
                    byte[] data = new byte[msg.Size];
                    Array.Copy(msg.Data, 4, data, 0, msg.Size);
                    return new CanMessage(msg.PGN, Format.EXTENDED, msg.Priority, msg.Src, data);
                }
                else
                    return null;
            }
        }

        public override void Write(CanMessage message)
        {
            throw new NotImplementedException();
        }

        protected override CanIdDataPair ParseExtended(object message)
        {
            throw new NotImplementedException();
        }

        protected override void WriteMultiPacket(CanMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
