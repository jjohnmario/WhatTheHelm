using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMSAcceleratorLib.Interfaces.HardwareInterfaces.Serial;

namespace WMSAcceleratorLib.HardwareInterfaces.Serial
{
    /// <summary>
    /// Creates a serial port.
    /// </summary>
    [Obsolete("Superceeded by AcceleratorSerialPort.",false)]
    public class COMPort : SerialPort
    {
        /// <summary>
        /// The string to be written to the serial port's output buffer.
        /// </summary>
        public string WriteString { get; set; }
        /// <summary>
        /// The array of strings read from the serial port's input buffer.
        /// </summary>
        public ArrayList ReadStringArray { get; set; }
        /// <summary>
        /// New data recieved in the serial port's input buffer.
        /// </summary>
        public event EventHandler<COMPortNewDataArgs> NewData;
        private object _Lock;

        /// <summary>
        /// Initializes a serial port using the provided configuration.
        /// </summary>
        /// <param name="configuration"></param>
        public COMPort(ISerialDeviceConfiguration configuration)
        {
            _Lock = new object();
            PortName = "COM" + configuration.COMPortNumber;
            BaudRate = Convert.ToInt16(configuration.BaudRate);
            DataBits = Convert.ToInt16(configuration.DataBits);
            ReadTimeout = configuration.TimeOut;
            NewLine = configuration.TermChar.ToString();

            switch (configuration.Parity)
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

            switch (configuration.StopBits)
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
            DataReceived += COMPort_DataReceived;

        }

        private void COMPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (_Lock)
            {

                SerialPort serialPort = (SerialPort)sender;
                if (serialPort.BytesToRead != 0)
                {
                    //Read data from COM port and trim terminating character.
                    string rawStringTrimmed;
                    char[] termCharArray = NewLine.ToCharArray(1, 1);
                    string termchar = termCharArray[0].ToString();
                    int termint = Convert.ToInt16(termchar);
                    byte[] buffer = new byte[250];
                    Thread.Sleep(100);
                    int bytesToRead = serialPort.BytesToRead;
                    serialPort.Read(buffer, 0, buffer.Length);
                    string rawString = Encoding.UTF8.GetString(buffer, 0, bytesToRead - 1);
                    rawStringTrimmed = rawString.TrimEnd(new char[] { (char)termint });
                    DiscardInBuffer();
                    if (NewData != null)
                        NewData.Invoke(this, new COMPortNewDataArgs() { ReadLine = rawStringTrimmed, Event = COMPortNewDataArgs.EventType.PortRead, BytesRead = bytesToRead });
                }
            }
        }

        /// <summary>
        /// Opens the serial port.
        /// </summary>
        /// <returns></returns>
        public bool OpenPort()
        {
            if (!IsOpen)
                Open();
            return IsOpen;
        }

        /// <summary>
        /// Closes the serial port.
        /// </summary>
        /// <returns></returns>
        public bool ClosePort()
        {
            Close();
            return !IsOpen;
        }

        /// <summary>
        /// Reads data from the COM port's input buffer.
        /// </summary>
        /// <returns></returns>
        private string ReadInputBuffer()
        {
            //Read data from COM port and trim terminating character.

            string rawStringTrimmed;
            char[] termCharArray = NewLine.ToCharArray(1, 1);
            string termchar = termCharArray[0].ToString();
            int termint = Convert.ToInt16(termchar);
            byte[] buffer = new byte[250];
            int bytesToRead = base.BytesToRead;
            base.Read(buffer, 0, buffer.Length);
            Thread.Sleep(200);
            string rawString = Encoding.UTF8.GetString(buffer, 0, bytesToRead - 1);
            rawStringTrimmed = rawString.TrimEnd(new char[] { (char)termint });
            DiscardInBuffer();
            return rawStringTrimmed;
        }

        /// <summary>
        /// Writes data to the COM port's output buffer.
        /// </summary>
        /// <param name="writeData"></param>
        public void WriteOutputBuffer(string writeData)
        {
            try
            {
                if (!IsOpen)
                {
                    Open();
                }
                if (IsOpen)
                {
                    DiscardOutBuffer();
                    char[] termCharArray = NewLine.ToCharArray(1, 1);
                    string termchar = termCharArray[0].ToString();
                    int termint = Convert.ToInt16(termchar);
                    StringBuilder sb = new StringBuilder(writeData);
                    sb.Append(new char[] { (char)termint });
                    WriteLine(WriteString + sb);
                }
            }
            catch
            {
                return;
            }
        }
    }
}
