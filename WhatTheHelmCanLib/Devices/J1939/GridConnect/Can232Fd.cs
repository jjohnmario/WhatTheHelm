﻿using WhatTheHelmCanLib.Messages;
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

namespace WhatTheHelmCanLib.Devices.J1939.GridConnect
{
    /// <summary>
    /// Represents a connected GridConnect CAN232FD gateway.
    /// </summary>
    public class Can232Fd : ICanGateway
    {
        public int MessageQueueCount { get => _mainMessageQueue.Count; }

        public bool IsOpen => throw new NotImplementedException();

        private SerialPort _serialPort;
        private Queue<string> _mainMessageQueue = new Queue<string>();
        private bool _scanMainMessageQueue = false;
        private bool _read = false;

        /// <summary>
        /// Creates an object reference to a GridConnect CAN232FD gateway and binds it to the defined CAN network address and serial port.
        /// </summary>
        /// <param name="serialPort">The host serial port to whih the CAN232FD gateway is connected.</param>
        /// <param name="address">The CAN network address to assign the CAN232FD gateway.</param>
        public Can232Fd (SerialPort serialPort,ushort address)
        {
            _serialPort = serialPort;
            //_SerialPort.DataReceived += SerialPort_DataReceived;
        }

        /// <summary>
        /// Creates an object reference to a GridConnect CAN232FD gateway of a defined name and binds it to the defined CAN network address and serial port.
        /// </summary>
        /// <param name="serialPort">The host serial port to whih the CAN232FD gateway is connected.</param>
        /// <param name="address">The CAN network address to assign the CAN232FD gateway.</param>
        /// <param name="name">The NAME of the CAN232FD gateway</param>
        public Can232Fd (SerialPort serialPort,ushort address, CanName name)
        {
            _serialPort = serialPort;
        }

        /// <summary>
        /// Creates an object reference to a GridConnect CAN232FD gateway of a defined name and product information and binds it to the defined CAN network address and serial port.
        /// </summary>
        /// <param name="serialPort">The host serial port to whih the CAN232FD gateway is connected.</param>
        /// <param name="address">The CAN network address to assign the CAN232FD gateway.</param>
        /// <param name="name">The NAME of the CAN232FD gateway</param>
        /// <param name="productInformation">The product information of the CAN232FD gateway</param>
        public Can232Fd(SerialPort serialPort,ushort address, CanName name, N2KProductInformation productInformation)
        {
            _serialPort = serialPort;
        }

        public event EventHandler<CanMessageArgs> MessageRecieved;

        private void Read()
        {
            while(_read)
            {
                string msg = _serialPort.ReadLine();
                _mainMessageQueue.Enqueue(msg);
            }
        }

        private void ScanMainMessageQueue()
        {
            try
            {
                while (_scanMainMessageQueue)
                {
                    if (_mainMessageQueue.Count > 0)
                    {
                        string message = _mainMessageQueue.Dequeue();
                        if(MessageRecieved!=null)
                        {
                            try
                            {
                                var parsedMessage = Parse(message);
                                MessageRecieved.Invoke(this, new CanMessageArgs() { Message = parsedMessage });
                            }
                            catch
                            {
                               
                            }
                        }
                    }
                    Thread.Sleep(5);
                }
            }
            catch
            {
                _mainMessageQueue.Clear();
                ScanMainMessageQueue();
            }
        }

        public bool Open()
        {
            try
            {
                _serialPort.Open();
                _scanMainMessageQueue = true;
                _read = true;
                Task.Run(() => ScanMainMessageQueue()).ContinueWith(t => throw t.Exception,TaskContinuationOptions.OnlyOnFaulted);
                Task.Run(() => Read());
                //task.ContinueWith(t =>
                //{
                //    throw t.Exception;
                //},
                //TaskContinuationOptions.OnlyOnFaulted);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                _serialPort.Close();
                _scanMainMessageQueue = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public CanMessage Parse(object message)
        {
            string msg = (string)message;
            CanIdDataPair canMessage = new CanIdDataPair();
            //Format
            Format format;
            if (msg.StartsWith(":S"))
                format = Format.STANDARD;
            else if (msg.StartsWith(":X"))
            {
                format = Format.EXTENDED;
                try
                {
                    //Parse the extended message int identifier and data frames.
                    canMessage = ParseExtended(msg);
                    //Convert first byte of ID to binary to extract the bits
                    string firstbyteToBin = Convert.ToString(canMessage.Id[0], 2).PadLeft(8, '0');
                    //Priority
                    int priority = Convert.ToInt32(firstbyteToBin.Substring(3, 3), 2);
                    //PGN Type (0=J1939, 1=NMEA2000)
                    PgnType pgnType = (PgnType)Convert.ToInt32(firstbyteToBin.Substring(7, 1));
                    //PGN
                    string pgnByte1Bin = firstbyteToBin.Substring(7, 1).PadLeft(8, '0');
                    string pgnByte2Bin = Convert.ToString(canMessage.Id[1], 2).PadLeft(8, '0');
                    string pgnByte3Bin = Convert.ToString(canMessage.Id[2], 2).PadLeft(8, '0');
                    string pgnAssembledBytesBin = string.Concat(pgnByte1Bin, pgnByte2Bin, pgnByte3Bin);
                    uint pgn = Convert.ToUInt32(pgnAssembledBytesBin, 2);
                    //Source Address
                    ushort sourceAddress = canMessage.Id[3];
                    //Data
                    byte[] data = canMessage.Data;
                    canMessage.Id = null;
                    canMessage.Data = null;
                    return new CanMessage(pgn, format, priority, sourceAddress, 255, data);
                }
                catch
                {
                    throw;
                }
            }
            else
                throw new FormatException("Can32FdMessage must start with 'S' or 'X'.");
            return null;
        }

        protected CanIdDataPair ParseExtended(object message)
        {
            try
            {
                string msg = (string)message;
                //Remove ":X" prefix.
                msg = msg.Remove(0, 2);
                //Remove ";" suffix.
                msg = msg.TrimEnd(';');
                //Extract ID frame (8 bytes)
                byte[] result = System.Text.RegularExpressions.Regex.Replace(msg.Substring(0, 8), ".{2}", "$0 ").TrimEnd().Split(' ').Select(item => Convert.ToByte(item, 16)).ToArray();
                //Extract Data frame (0 - 8 bytes)
                byte[] dataBytes = System.Text.RegularExpressions.Regex.Replace(msg.Substring(9), ".{2}", "$0 ").TrimEnd().Split(' ').Select(item => Convert.ToByte(item, 16)).ToArray();
                CanIdDataPair results = new CanIdDataPair() { Id = result, Data = dataBytes };
                result = null;
                dataBytes = null;
                return results;
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
            //_SerialPort.DataReceived -= SerialPort_DataReceived;
            _serialPort.Dispose();
        }

        public bool Write(CanMessage message)
        {
            if (ParameterGroup.GetPgnType(message.Pgn).MultiFrame == true)
            {
                WriteMultiPacket(message);
                return true;
            }
            else
            {
                try
                {
                    //Always start with ':' (1 byte)
                    string msg = ":";

                    //Concatenate CAN format (1 byte)
                    if (message.Format == Format.STANDARD)
                        msg = string.Concat(msg, "S");
                    else if (message.Format == Format.EXTENDED)
                        msg = string.Concat(msg, "X");

                    //Concatenate last 3 bits of arbitration frame, message priority (3 bits), and PGN type(2 bits,0=J1939,1=NMEA2000) for a total of 8 bits.
                    string arbFrame = "000";
                    string priority = Convert.ToString(message.Priority, 2).PadLeft(3, '0');
                    string pgnBin = Convert.ToString(message.Pgn, 2).PadLeft(18, '0');
                    string msgType = Convert.ToString(pgnBin.Substring(0, 2)).PadLeft(2, '0');
                    msg = string.Concat(msg, Convert.ToInt32(string.Concat(arbFrame, priority, msgType), 2).ToString("X").PadLeft(2, '0'));

                    //Concatenate PGN (2 bytes)
                    string pgnMsb = Convert.ToInt32(pgnBin.Substring(2, 8), 2).ToString("X");
                    string pgnLsb = Convert.ToInt32(pgnBin.Substring(10, 8), 2).ToString("X").PadLeft(2, '0');
                    msg = string.Concat(msg, pgnMsb, pgnLsb);

                    //Concatenate Consuming Node Address (1 byte)
                    msg = string.Concat(msg, message.SourceAddress.ToString("X").PadLeft(2, '0'));

                    //Concatenate 'N' to signal the gateway the start of the data frame. (1 byte)
                    msg = string.Concat(msg, "N");

                    //Concatenate data frame. (8 bytes)
                    string data = BitConverter.ToString(message.Data).Replace("-", string.Empty);
                    msg = string.Concat(msg, data);

                    //Concatenate ';' to signal the gateway the end of the data frame. (1 byte)
                    msg = string.Concat(msg, ";");

                    //Write message to gateway. (16 bytes total)
                    _serialPort.Write(msg);

                    return true;
                }
                catch 
                {
                    return false;
                }
            }
        }

        private void Write(string message)
        {
            //Write message to gateway. (Maximum of 16 bytes total)
            _serialPort.Write(message);
        }

        protected void WriteMultiPacket(CanMessage message)
        {
            //Create message queue.
            Queue<CanMessage> messageQueue = new Queue<CanMessage>();

            //Determine the number of messages required
            //Get data length of FPM.
            byte dataBytesLen = (byte)message.Data.Length;

            //Calculate the number of packets required to meet data byte length (first packet = 6 bytes, remaining = 7 bytes) 
            //First packet contains only 6 bytes of data, because the first byte is the packet identifier and the second is the total number of bytes to transmit.
            //The second and subsequent packets contain only 7 bytes of data, because the first byte is the packet identifier.
            //var raw = (float)(((dataBytesLen - 6.00) / 7.00)+1);
            int messageCountReq = (int)Math.Ceiling((float)(((dataBytesLen - 6.00) / 7.00) + 1));

            //Fill data frame for first message then add to message list.
            byte basePacketId = 0x00;
            byte[] firstPacketData = new byte[8];
            firstPacketData[0] = basePacketId;
            firstPacketData[1] = dataBytesLen;
            firstPacketData[2] = message.Data[0];
            firstPacketData[3] = message.Data[1];
            firstPacketData[4] = message.Data[2];
            firstPacketData[5] = message.Data[3];
            firstPacketData[6] = message.Data[4];
            firstPacketData[7] = message.Data[5];
            messageQueue.Enqueue(new CanMessage(message.Pgn, message.Format, message.Priority, message.SourceAddress, 255,firstPacketData.Reverse().ToArray()));

            //Fill data frame for each remaining message and add to message list.
            for(int i = 1; i< messageCountReq; i++)
            {
                //Middle messages
                if (i < messageCountReq - 1)
                {
                    byte[] packetData = new byte[8];
                    packetData[0] = (byte)(basePacketId + i);
                    packetData[1] = message.Data[(i * 8) - i];
                    packetData[2] = message.Data[((i * 8) - i) + 1];
                    packetData[3] = message.Data[((i * 8) - i) + 2];
                    packetData[4] = message.Data[((i * 8) - i) + 3];
                    packetData[5] = message.Data[((i * 8) - i) + 4];
                    packetData[6] = message.Data[((i * 8) - i) + 5];
                    packetData[7] = message.Data[((i * 8) - i) + 6];
                    messageQueue.Enqueue(new CanMessage(message.Pgn, message.Format, message.Priority, message.SourceAddress, 255, packetData.Reverse().ToArray()));
                }
                //Last message
                else
                {
                    int bytesSoFar = (messageQueue.Count * 7) - 1;
                    int bytesRemaining = message.Data.Length - bytesSoFar;
                    byte[] finalPacketData = new byte[8];
                    finalPacketData[0] = (byte)(basePacketId + i);
                    for (int j = 1; j < bytesRemaining; j++)
                    {
                        finalPacketData[j] = message.Data[(message.Data.Length - bytesRemaining) + j];
                    }
                    //finalPacketData.Reverse();
                    messageQueue.Enqueue(new CanMessage(message.Pgn, message.Format, message.Priority, message.SourceAddress, 255, finalPacketData.Reverse().ToArray()));
                }
            }

            //Write each message individually.
            while(messageQueue.Count !=0)
            {
                this.Write(messageQueue.Dequeue());
            }
        }
    }
}
