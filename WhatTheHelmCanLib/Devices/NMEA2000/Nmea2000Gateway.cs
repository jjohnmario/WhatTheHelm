using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.Devices.Nmea2000
{
    /// <summary>
    /// Represents a generic NMEA2000 gateway.
    /// </summary>
    public abstract class Nmea2000Gateway : CanGateway
    {
        /// <summary>
        /// Product information per PGN:126996
        /// </summary>
        public ProductInformation ProductInformation { get; set; }
        /// <summary>
        /// Creates a generic NMEA2000 gateway with the defined source address.
        /// </summary>
        /// <param name="sourceAddress">Address to assign to the NMEA gateway</param>
        public Nmea2000Gateway(ushort sourceAddress) : base(sourceAddress) { }
        /// <summary>
        /// Creates a generic NMEA2000 gateway with the defined source address and NAME.
        /// </summary>
        /// <param name="sourceAddress">Address to assign to the NMEA2000 gateway</param>
        /// <param name="name">NAME to assign the NMEA2000 gateway</param>
        public Nmea2000Gateway(ushort sourceAddress, CanName name) : base(sourceAddress, name) { }
        /// <summary>
        /// Creates a generic NMEA2000 gateway with the defined source address, NAME and product information
        /// </summary>
        /// <param name="sourceAddress">Address to assign to the NMEA2000 gateway</param>
        /// <param name="name">NAME to assign the NMEA2000 gateway</param>
        /// <param name="productInformation">Product information for the NMEA2000 gateway</param>
        public Nmea2000Gateway(ushort sourceAddress, CanName name, ProductInformation productInformation):base(sourceAddress,name)
        {
            ProductInformation = productInformation;
        }
    }
}
