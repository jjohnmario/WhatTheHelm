using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMSAcceleratorLib.HardwareInterfaces.Serial
{
    /// <summary>
    /// Arguments passed when new data is transmitted or recieved by a serial port.
    /// </summary>
    public class COMPortNewDataArgs : EventArgs
    {
        /// <summary>
        /// The string that was written to the serial port's output buffer.
        /// </summary>
        public string WriteLine { get; set; }

        /// <summary>
        /// The string that was read from the serial port's input buffer.
        /// </summary>
        public string ReadLine { get; set; }
        /// <summary>
        /// Read or Write event.
        /// </summary>
        public enum EventType {
            /// <summary>
            /// Port write event.
            /// </summary>
            PortWrite,
            /// <summary>
            /// Port read event.
            /// </summary>
            PortRead }
        /// <summary>
        /// Type of the event.
        /// </summary>
        public EventType Event { get; set; }
        /// <summary>
        /// Bytes read during a read event.
        /// </summary>
        public int BytesRead { get; set; }
        /// <summary>
        /// Bytes written during a write event.
        /// </summary>
        public int BytesWritten { get; set; }
    }
}
