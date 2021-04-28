using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// Represents a NMEA 2000 parameter group.
    /// </summary>
    public abstract class Nmea2000ParameterGroup : ParameterGroup
    {
        public override PgnType PgnType
        {
            get
            {
                return PgnType.NMEA2000;
            }
        }
    }
}
