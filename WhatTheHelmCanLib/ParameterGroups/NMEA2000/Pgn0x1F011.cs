using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN:126993 Heartbeat
    /// </summary>
    public class Pgn0x1F011 : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN:126993 Heartbeat";
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
                return 126993;
            }
        }
        

        public override Target Target => throw new NotImplementedException();

        /// <summary>
        /// Represents the heartbeat interval in ms.
        /// </summary>
        public UInt16 Interval { get; set; }
        /// <summary>
        /// Not sure what this is?
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// Reserved
        /// </summary>
        public byte Reserved1 { get; set; }
        /// <summary>
        /// Reserved
        /// </summary>
        public UInt32 Reserved2 { get; set; }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            Interval = BitConverter.ToUInt16(data, 0);
            Status = data[2];
            Reserved1 = data[3];
            Reserved2 = BitConverter.ToUInt32(data, 4);
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
