using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN:130310 Environmental Parameters (Water Temperature)
    /// </summary>
    public class Pgn0x1FD06 : Nmea2000ParameterGroup
    {
        public override int Pgn
        {
            get
            {
                return 130310;
            }
        }
        public override string Description
        {
            get
            {
                if (UomSystem == UomSystem.Metric)
                    return "Environmental Parameters (Water Temperature) in Degrees Kelvin";
                else
                    return "Environmental Parameters (Water Temperature) in Degrees Fahrenheit";
            }
        }
        public int Sid { get; private set; }
        public double Temperature { get; private set; }
        public UomSystem UomSystem { get; private set; }

        public override PgnType PgnType
        {
            get
            {
                return PgnType.NMEA2000;
            }
        }


        public override bool MultiFrame
        {
            get
            {
                return false;
            }
        }

        public override Target Target
        {
            get
            {
                return Target.Broadcast;
            }
        }

        /// <summary>
        /// Creates an object reference to PGN:130310 Environmental Parameters (Water Temperature)
        /// </summary>
        public Pgn0x1FD06()
        {

        }

        /// <summary>
        /// Creates an object reference to PGN:130310 Environmental Parameters (Water Temperature) with the defined SID and temperature values.
        /// </summary>
        /// <param name="sid">SID value</param>
        /// <param name="temperature">Temperature value</param>
        public Pgn0x1FD06(int sid, double temperature)
        {
            Sid = sid;
            Temperature = temperature;
        }

        /// <summary>
        /// Creates an object reference to PGN:130310 Environmental Parameters (Water Temperature) with the defined SID and temperature values and sets measurement system for the PGN.
        /// </summary>
        /// <param name="sid">SID value</param>
        /// <param name="temperature">Temperature value</param>
        /// <param name="uomSystem">Measurement system used to present PGN values</param>
        public Pgn0x1FD06(int sid, double temperature, UomSystem uomSystem)
        {
            Sid = sid;
            Temperature = temperature;
            UomSystem = uomSystem;
        }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            if (data.Length != 8)
                throw new FormatException("Data frame must be exactly 8 bytes.");
            else
            {
                //SID
                Sid = data[0];

                //Temperature
                byte[] tempByteArray = new byte[2];
                Array.Copy(data, 1, tempByteArray, 0, 2);
                Temperature = BitConverter.ToInt16(tempByteArray, 0) * 0.01;

                //Cleanup byte array(s)
                tempByteArray = null;
            }
            return this;
        }

        public override ParameterGroup ToImperial()
        {
            return new Pgn0x1FD06(Sid, ((Temperature - 273.15) * (1.8) + 32), UomSystem.Imperial);
        }

        public override ParameterGroup ToMetric()
        {
            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }
    }
}
