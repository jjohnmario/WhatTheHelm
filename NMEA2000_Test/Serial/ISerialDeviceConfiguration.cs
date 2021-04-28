using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMSAcceleratorLib.HardwareInterfaces.Serial;

namespace WMSAcceleratorLib.Interfaces.HardwareInterfaces.Serial
{
    /// <summary>
    /// A basic Serial device interface.
    /// </summary>
    public interface ISerialDeviceConfiguration
    {
        /// <summary>
        /// Communication interval (ms).
        /// </summary>
        string COMPortNumber { get; set; }
        /// <summary>
        /// Baud rate.
        /// </summary>
        string BaudRate { get; set; }
        /// <summary>
        /// Data bits.
        /// </summary>
        string DataBits { get; set; }
        /// <summary>
        /// Parity
        /// </summary>
        string Parity { get; set; }
        /// <summary>
        /// Stop bits.
        /// </summary>
        string StopBits { get; set; }
        /// <summary>
        /// Hardware flow control.
        /// </summary>
        string FlowControl { get; set; }
        /// <summary>
        /// String length of data within read/write buffer.
        /// </summary>
        string StringLength { get; set; }
        /// <summary>
        /// Communication interval (ms).
        /// </summary>
        int CommInterval { get; set; }
        /// <summary>
        /// Communication timeout (ms).
        /// </summary>
        int TimeOut { get; set; }
        /// <summary>
        /// Terminating character.
        /// </summary>
        char TermChar { get; set; }
        /// <summary>
        /// Hardware handshaking.
        /// </summary>
        string Handshaking { get; set; }
        /// <summary>
        /// Read buffer size in bytes.
        /// </summary>
        int ReadBufferSize { get; set; }
        /// <summary>
        /// Write buffer size.
        /// </summary>
        int WriteBufferSize { get; set; }
        /// <summary>
        /// Data Terminal Ready enable.
        /// </summary>
        bool DTREnable { get; set; }
    }
}
