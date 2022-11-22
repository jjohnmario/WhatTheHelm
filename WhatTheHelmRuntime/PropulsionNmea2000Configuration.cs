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
        public Nmea2000DataBinding Rpm { get; set; }
        public Nmea2000DataBinding EngineTemperature { get; set; }
        public Nmea2000DataBinding OilPressure { get; set; }
        public Nmea2000DataBinding OilTemperature { get; set; }
        public Nmea2000DataBinding AlternatorPotential { get; set; }
        public Nmea2000DataBinding CoolantPressure { get; set; } 
        public Nmea2000DataBinding FuelPressure { get; set; } 
        public Nmea2000DataBinding FuelRate { get; set; }
        public Nmea2000DataBinding PercentEngineLoad { get; set; }
        public Nmea2000DataBinding PercentEngineTorque { get; set; }
        public Nmea2000DataBinding EngineAlarms { get; set; }
        public Nmea2000DataBinding EngineHours { get; set; }
        public Nmea2000DataBinding PortTransPressure { get; set; }
        public Nmea2000DataBinding PortTransAlarms { get; set; }
        public Nmea2000DataBinding PortVoltage { get; set; }
    }
}
