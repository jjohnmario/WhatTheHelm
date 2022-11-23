using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatTheHelmCanLib.Devices.NMEA2000;

namespace WhatTheHelmRuntime
{
    /// <summary>
    /// Defines the NMEA2000 devices responsible for producing or consuming propulsion data.
    /// </summary>
    public class PropulsionNmea2000Configuration
    {
        public N2KDataBinding Rpm { get; set; }
        public N2KDataBinding EngineTemperature { get; set; }
        public N2KDataBinding OilPressure { get; set; }
        public N2KDataBinding OilTemperature { get; set; }
        public N2KDataBinding AlternatorPotential { get; set; }
        public N2KDataBinding CoolantPressure { get; set; } 
        public N2KDataBinding FuelPressure { get; set; } 
        public N2KDataBinding FuelRate { get; set; }
        public N2KDataBinding PercentEngineLoad { get; set; }
        public N2KDataBinding PercentEngineTorque { get; set; }
        public N2KDataBinding EngineAlarms { get; set; }
        public N2KDataBinding EngineHours { get; set; }
        public N2KDataBinding TransPressure { get; set; }
        public N2KDataBinding TransAlarms { get; set; }
        public N2KDataBinding Voltage { get; set; }
    }
}
