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

namespace WhatTheHelmCanLib.Devices.NMEA2000.Actisense
{

    /// <summary>
    /// Represents a connected Actisense NGT-1 gateway.
    /// </summary>
    public class Ngt1 : Nmea2000Gateway
    {
        public int MessageQueueCount { get => _mainMessageQueue.Count; }
        private SerialPort _serialPort;
        private Queue<NMEA2K.N2KMsg_s> _mainMessageQueue = new Queue<NMEA2K.N2KMsg_s>();
        private bool _scanMainMessageQueue = false;
        private bool _read = false;
        private int _actiHandle;
        private ARLErrorCodes_t _error;       /* Error value returned by ActisenseComms API function calls */
        private NMEA2K.N2KMsg_s _n2KMsg; /* Single N2K message buffer */

        /// <summary>
        /// Creates an object reference to an Actisense NGT-1 gateway and binds it to the defined CAN network address and serial port.
        /// </summary>
        /// <param name="serialPort">The host serial port to which the NGT-1 gateway is connected.</param>
        /// <param name="address">The CAN network address to assign the NGT-1 gateway.</param>
        public Ngt1(SerialPort serialPort, ushort address) : base(address)
        {
            _serialPort = serialPort;
            //_SerialPort.DataReceived += SerialPort_DataReceived;
        }

        public override event EventHandler<CanMessageArgs> MessageRecieved;

        public override bool Close()
        {
            AComms.Close(_actiHandle);
            _scanMainMessageQueue = false;
            return true;
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
            _error = NMEA2K.SetRxCallback(_actiHandle, new ActisenseComms.API.Callback(N2kRxCallbackHandler), new IntPtr(0));
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
            return true;
        }

        private void N2kRxCallbackHandler(IntPtr UserData)
        {
            /* NMEA2K.Read calls the ActisenseComms API to obtain the new N2K
              * message that has just been received */
            NMEA2K.N2KMsg_s msg;
            _error = NMEA2K.Read(_actiHandle, out msg);
            if (MessageRecieved != null)
            {
                var parsedMessage = Parse(msg);
                MessageRecieved.Invoke(this, new CanMessageArgs() { Message = parsedMessage });
            }

        }

        public override CanMessage Parse(object message)
        {
            var msg = (NMEA2K.N2KMsg_s)message;
            byte[] data = new byte[msg.Size];
            Array.Copy(msg.Data, data, msg.Size);
            return new CanMessage(msg.PGN,Format.EXTENDED,msg.Priority,msg.Src,data);
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
