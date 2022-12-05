using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN: 130576 Rudder Status
    /// </summary>
    public class Pgn0x1FE10 : Nmea2000ParameterGroup
    {
        public override string Description => "PGN: 130576 Rudder Status";

        public override bool MultiFrame => false;

        public override uint Pgn => 130576;

        public override Target Target => throw new NotImplementedException();

        /// <summary>
        /// Port trim tab position in percent
        /// </summary>
        public ushort PortPosition;

        /// <summary>
        /// Stbd trim tab position in percent
        /// </summary>
        public ushort StbdPosition;

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            PortPosition = data[0];
            StbdPosition = data[1];
            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }

        public override ParameterGroup ToImperial()
        {
            return this;
        }

        public override ParameterGroup ToMetric()
        {
            throw new NotImplementedException();
        }
    }
}
