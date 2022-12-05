using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatTheHelmCanLib.Devices.NMEA2000;

namespace WhatTheHelmRuntime
{
    /// <summary>
    /// Defines the NMEA2000 devices responsible for producing or consuming rudder and trim data.
    /// </summary>
    public class RudderTrimNmea2000Configuration
    {
        public N2KDataBinding PortTrim { get; set; }
        public N2KDataBinding StbdTrim { get; set; }
        public N2KDataBinding Rudder { get; set; }
    }
}
