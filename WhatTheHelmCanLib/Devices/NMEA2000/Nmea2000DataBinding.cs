using System;
using System.Collections.Generic;
using System.Text;
using WhatTheHelmCanLib.Devices.Nmea2000;

namespace WhatTheHelmCanLib.Devices.NMEA2000
{
    /// <summary>
    /// Defines the relationship between a NMEA2000 device and a NMEA2000 PGN.
    /// </summary>
    public class Nmea2000DataBinding
    {
        /// <summary>
        /// The NMEA2000 device containing the data source
        /// </summary>
        public Nmea2000Device Nmea2000Device { get; set; }
        /// <summary>
        /// The PGN of the produced or consumed data point.
        /// </summary>
        public uint PGN { get; set; }
        /// <summary>
        /// The instance of the produced or consumed PGN.
        /// </summary>
        public byte Instance { get; set; }

        public Nmea2000DataBinding(Nmea2000Device n2KDevice)
        {
            if(n2KDevice == null)
                throw new ArgumentNullException(nameof(n2KDevice));
            else
                Nmea2000Device = n2KDevice;
        }

    }
}
