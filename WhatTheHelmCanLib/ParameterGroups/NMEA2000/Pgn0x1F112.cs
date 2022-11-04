using WhatTheHelmCanLib.ParameterGroups;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN: 127250 Vessel Heading
    /// </summary>
    public class Pgn0x1F112 : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN: 127250 Vessel Heading";
            }
        }

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

        public override uint Pgn
        {
            get
            {
                return 127250;
            }
        }

        public override Target Target => throw new NotImplementedException();

        public int Sid { get; private set; }
        public double Heading { get; private set; }
        public double Deviation { get; private set; }
        public double Variation { get; private set; }


        public override ParameterGroup DeserializeFields(byte[] data)
        {
            if (data.Length != 8)
                throw new FormatException("Data frame must be exactly 8 bytes.");
            else
            {
                //SID
                Sid = data[0];

                //Heading
                byte[] headingByteArray = new byte[2];
                Array.Copy(data, 1, headingByteArray, 0, 2);
                Heading = BitConverter.ToInt16(headingByteArray, 0) * 0.0001;

                //Deviation
                byte[] deviationByteArray = new byte[2];
                Array.Copy(data, 3, deviationByteArray, 0, 2);
                Deviation = BitConverter.ToInt16(deviationByteArray, 0) * 0.0001;

                //Variation
                byte[] variationByteArray = new byte[2];
                Array.Copy(data, 5, variationByteArray, 0, 2);
                Variation = BitConverter.ToInt16(variationByteArray, 0) * 0.0001;

                //Cleanup byte array(s)
                headingByteArray = null;
                deviationByteArray = null;
                variationByteArray = null;
            }
            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }

        public override ParameterGroup ToImperial()
        {
            throw new NotImplementedException();
        }

        public override ParameterGroup ToMetric()
        {
            throw new NotImplementedException();
        }
    }
}
