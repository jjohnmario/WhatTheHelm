using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMSAcceleratorLib.HardwareInterfaces.Serial;
using WMSAcceleratorLib.Interfaces.HardwareInterfaces.Serial;

namespace WMSAcceleratorLib.HardwareInterfaces.Serial
{

    /// <summary>
    /// Serial Port class that examines each byte in the buffer up to a defined terminating character when new data is detected.
    /// </summary>
    public class AcceleratorSerialPort : SerialPort
    {

        #region Public Properties

        /// <summary>
        /// Event handler for new data received at serial port.
        /// </summary>
        public event EventHandler<COMPortNewDataArgs> NewData;

        /// <summary>
        /// Event handler for when the buffer becomes larger than the defined max input buffer length.
        /// </summary>
        public event EventHandler<COMPortInputBufferFull> BufferFull;

        /// <summary>
        /// Max number of bytes to be read from a buffer before the terminating character.
        /// </summary>
        public int MaxInputBufferLength { get; set; } = 40;

        /// <summary>
        /// The time out in milliseconds for reading the buffer.
        /// </summary>
        public int InputReadTimeout { get; set; } = 20000;

        /// <summary>
        /// Bool that indicates of the input buffer listener is listening.
        /// </summary>
        public bool IsListening { get; private set; } = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for the AcceleratorSerialPort Class
        /// </summary>
        /// <param name="config">Configuration of the serial port class.</param>
        public AcceleratorSerialPort(ISerialDeviceConfiguration config)
        {
            //define the port settings
            PortName = "COM" + config.COMPortNumber;
            BaudRate = 115200;
            DataBits = Convert.ToInt16(config.DataBits);
            ReadTimeout = config.TimeOut;
            NewLine = config.TermChar.ToString();
            InputReadTimeout = config.TimeOut;
            ReadBufferSize = config.ReadBufferSize;

            //set the parity of the COM port
            switch (config.Parity)
            {
                case "Odd":
                    Parity = Parity.Odd;
                    break;
                case "Even":
                    Parity = Parity.Even;
                    break;
                case "Mark":
                    Parity = Parity.Mark;
                    break;
                case "Space":
                    Parity = Parity.Space;
                    break;
            }

            //set the stop bits of the COM port.
            switch (config.StopBits)
            {
                case "1":
                    StopBits = StopBits.One;
                    break;
                case "1.5":
                    StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    StopBits = StopBits.Two;
                    break;
                case "None":
                    StopBits = StopBits.None;
                    break;
            }

            //open the port
            OpenPort();

            //set the read timeout to infinite.
            //ReadTimeout = InfiniteTimeout;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Opens the serial port connection if not already open.
        /// </summary>
        /// <returns>Success of the method. True = Open</returns>
        public bool OpenPort()
        {
            //if it's not open
            if (!IsOpen)
            {
                try
                {
                    //open the port
                    Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            //return true if open
            return IsOpen;
        }

        /// <summary>
        /// Closes the serial port connection if it is open.
        /// </summary>
        /// <returns>Success of the method. True = closed</returns>
        public bool ClosePort()
        {
            //if the port is open
            if (IsOpen)
            {
                try
                {
                    //close the port
                    Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            //returns true if closed
            return !IsOpen;
        }

        /// <summary>
        /// Methods start the input buffer listener.
        /// </summary>
        /// <returns>Returns the state of the input buffer listener. True = Listening</returns>
        public bool StartInputBufferListener()
        {
            OpenPort();
            IsListening = true;
            Task.Run(()=>ListenToBuffer());
            return IsListening;
        }

        /// <summary>
        /// Method ends the input buffer listener. 
        /// </summary>
        /// <returns>Returns the state of the listener. False = Not Listening</returns>
        public bool EndInputBufferListener()
        {
            IsListening = false;
            return IsListening;
        }

        /// <summary>
        /// Starts the input buffer listener on another thread.
        /// </summary>
        /// <returns></returns>        
        private void ListenToBuffer()
        {
            try
            {
                //fields for the method
                string input;
                string trimString;
                byte lastByteRead = new byte();
                List<byte> byteList = new List<byte>();
                byte termByte = Encoding.UTF8.GetBytes(NewLine.ToCharArray())[0];

                while (IsListening)
                {
                    //null fields used to read the buffer
                    input = String.Empty;
                    trimString = String.Empty;
                    byteList.Clear();

                    //while the last byte read is > 0
                    while ((lastByteRead = (byte)ReadByte()) >= 0)
                    {                        //if the last byte read is the terminating character
                        if (lastByteRead == termByte)
                        {
                            //break from the loop
                            break;
                        }

                        //add the last byte read to the list of bytes
                        byteList.Add(lastByteRead);

                        //if the byte count is longer than the max allowable buffer length
                        if (byteList.Count > MaxInputBufferLength)
                        {
                            //if the buffer full event is not null
                            if (BufferFull != null)
                            {
                                //invoke a new buffer full event
                                BufferFull.Invoke(this, new COMPortInputBufferFull()
                                {
                                    BufferContent = Encoding.UTF8.GetString(byteList.ToArray()),
                                    BytesRead = byteList.Count
                                });

                                //discard the buffer
                                DiscardInBuffer();

                                //break from the read loop
                                break;
                            }

                            //else throw out the buffer and throw exception
                            else
                            {
                                DiscardInBuffer();
                                throw new SerialInputBufferFullException("The input buffer for " + PortName.ToString() + " has exceeded the allowable limit.\nThe input buffer has been cleared");
                            }
                        }

                        //sleep for 10ms before reading the next byte.
                        Thread.Sleep(10);
                    }

                    //if the status listening status property is false then break out of the listening loop.
                    if (!IsListening)
                    {
                        break;
                    }

                    //convert the collection of bytes to a string
                    input = Encoding.UTF8.GetString(byteList.ToArray());

                    //trim the terminating character from the string
                    trimString = input.TrimEnd(NewLine.ToCharArray());

                    //if the NewData event handler is not null
                    if (NewData != null)
                    {
                        //invoke a new event
                        NewData.Invoke(this, new COMPortNewDataArgs()
                        {
                            ReadLine = trimString,
                            BytesRead = byteList.Count,
                            Event = COMPortNewDataArgs.EventType.PortRead,
                        });
                    }
                }
            }
            //list of catches that can be used for exception handling
            catch (SerialInputBufferFullException ex)
            {
                throw new Exception(ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.ToString());
            }
            catch (System.IO.IOException ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// Write a string to the serial port.
        /// </summary>
        /// <param name="message"></param>
        public void WriteOutputBuffer(string message)
        {
            try
            {
                //Make sure the port is open
                OpenPort();

                //encode the string into bytes
                byte[] encodedString = Encoding.GetBytes(message + NewLine);

                //write the bytes to the output buffer
                BaseStream.Write(encodedString, 0, encodedString.Length);

                //flush the buffer
                BaseStream.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// Write a line to a serial port async.
        /// </summary>
        /// <param name="port">The serial port the string is to be written to.</param>
        /// <param name="message">The string to be written to the serial port.</param>
        /// <returns></returns>
        public async Task WriteOutputBufferAsync(string message)
        {
            try
            {
                //Make sure the port is open
                OpenPort();

                //encode the string into bytes
                byte[] encodedString = Encoding.GetBytes(message + NewLine);

                //write the bytes to the output buffer
                await BaseStream.WriteAsync(encodedString, 0, encodedString.Length);

                //flush the buffer
                await BaseStream.FlushAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        #endregion
    }

    /// <summary>
    /// Event arguments for when the COM Port input buffer becomes larger than the defined max input buffer length
    /// </summary>
    public class COMPortInputBufferFull : EventArgs
    {
        /// <summary>
        /// The contents of the input buffer.
        /// </summary>
        public string BufferContent { get; set; }

        /// <summary>
        /// The number of bytes read.
        /// </summary>
        public int BytesRead { get; set; }
    }

    /// <summary>
    /// Exception that can be used for when the input buffer exceeds a desired count.
    /// </summary>
    public class SerialInputBufferFullException : Exception
    {
        public SerialInputBufferFullException(string message) : base(message)
        {

        }
    }
}
