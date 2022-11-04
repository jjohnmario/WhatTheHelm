using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN:128259 Speed (Speed Water Reference)
    /// </summary>
    public class Pgn0x1F503 : Nmea2000ParameterGroup
    {
        public override uint Pgn
        {
            get
            {
                return 128259;
            }
        }
        public override string Description
        {
            get
            {
                if (UomSystem == UomSystem.Metric)
                    return "Speed (Speed Water Reference) in M/s";
                else
                    return "Speed (Speed Water Reference) in MPH";
            }
        }
        public int Sid { get; private set; }
        public double Speed { get; private set; }
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
        /// Creates an object reference to PGN:128259 Speed (Speed Water Reference)
        /// </summary>
        public Pgn0x1F503()
        {

        }
        /// <summary>
        /// Creates an object reference to PGN:128259 Speed (Speed Water Reference) with the defined SID and speed values.
        /// </summary>
        /// <param name="sid">SID value</param>
        /// <param name="speed">Speed value</param>
        public Pgn0x1F503(int sid, double speed)
        {
            Sid = sid;
            Speed = speed;
        }
        /// <summary>
        /// Creates an object reference to PGN:128259 Speed (Speed Water Reference) with the defined SID and speed values and sets measurement system for the PGN.
        /// </summary>
        /// <param name="sid">SID value</param>
        /// <param name="speed">Speed value</param>
        /// <param name="uomSystem">Measurement system used to present PGN values</param>
        public Pgn0x1F503(int sid, double speed, UomSystem uomSystem)
        {
            Sid = sid;
            Speed = speed;
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

                //Speed
                byte[] speedByteArray = new byte[2];
                Array.Copy(data, 1, speedByteArray, 0, 2);
                Speed = BitConverter.ToInt16(speedByteArray, 0) * 0.01;

                //Cleanup byte array(s)
                speedByteArray = null;
            }
            return this;
        }

        public override ParameterGroup ToImperial()
        {
            return new Pgn0x1F503(Sid, (Speed * 2.237), UomSystem.Imperial);
        }

        public override ParameterGroup ToMetric()
        {
            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
