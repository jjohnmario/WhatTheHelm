using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMSAcceleratorLib.Interfaces.HardwareInterfaces.Serial;


namespace WMSAcceleratorLib.HardwareInterfaces.Serial
{
    /// <summary>
    /// The basic configuration for a serial device.
    /// </summary>
    public class SerialDeviceConfiguration : ISerialDeviceConfiguration
    {
        /// <summary>
        /// Baud rate.
        /// </summary>
        public string BaudRate { get; set; }
        /// <summary>
        /// Communication interval (ms).
        /// </summary>
        public int CommInterval { get; set; }
        /// <summary>
        /// COM port number.
        /// </summary>
        public string COMPortNumber { get; set; }
        /// <summary>
        /// Data bits.
        /// </summary>
        public string DataBits { get; set; }
        /// <summary>
        /// Data Terminal Ready enable.
        /// </summary>
        public bool DTREnable { get; set; }
        /// <summary>
        /// Hardware flow control.
        /// </summary>
        public string FlowControl { get; set; }
        /// <summary>
        /// Hardware handshaking.
        /// </summary>
        public string Handshaking { get; set; }
        /// <summary>
        /// Parity
        /// </summary>
        public string Parity { get; set; }
        /// <summary>
        /// Read buffer size in bytes.
        /// </summary>
        public int ReadBufferSize { get; set; }
        /// <summary>
        /// Stop bits.
        /// </summary>
        public string StopBits { get; set; }
        /// <summary>
        /// String length of data within read/write buffer.
        /// </summary>
        public string StringLength { get; set; }
        /// <summary>
        /// Terminating character.
        /// </summary>
        public char TermChar { get; set; }
        /// <summary>
        /// Communication timeout (ms).
        /// </summary>
        public int TimeOut { get; set; }
        /// <summary>
        /// Write buffer size.
        /// </summary>
        public int WriteBufferSize { get; set; }
    }
}
