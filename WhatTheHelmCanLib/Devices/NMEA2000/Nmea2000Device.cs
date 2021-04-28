using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.Devices.Nmea2000
{
    public class Nmea2000Device : CanDevice
    {
        public Nmea2000Device(ushort sourceAddress):base(sourceAddress)
        {
        }
        public Nmea2000Device(ushort sourceAddress, CanName name) : base(sourceAddress, name)
        {

        }

        public ProductInformation ProductInformation { get; set; }
    }
}
