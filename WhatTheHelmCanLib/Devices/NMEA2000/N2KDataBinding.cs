using System;
using System.Collections.Generic;
using System.Text;
using WhatTheHelmCanLib.Devices.Nmea2000;

namespace WhatTheHelmCanLib.Devices.NMEA2000
{
    /// <summary>
    /// Defines the relationship between a NMEA2000 device and a NMEA2000 PGN.
    /// </summary>
    public class N2KDataBinding
    {
        /// <summary>
        /// The NMEA2000 device containing the data source
        /// </summary>
        public N2KDevice Nmea2000Device { get; set; }
        /// <summary>
        /// The PGN of the produced or consumed data point.
        /// </summary>
        public uint PGN { get; set; }
        /// <summary>
        /// The instance of the produced or consumed PGN.
        /// </summary>
        public byte Instance { get; set; }

        public N2KDataBinding()
        {

        }

        public N2KDataBinding(N2KDevice n2KDevice)
        {
            if(n2KDevice == null)
                throw new ArgumentNullException(nameof(n2KDevice));
            else
                Nmea2000Device = n2KDevice;
        }

        public N2KDataBinding(N2KDevice nmea2000Device, uint pGN, byte instance) : this(nmea2000Device)
        {
            PGN = pGN;
            Instance = instance;
        }
    }
}
