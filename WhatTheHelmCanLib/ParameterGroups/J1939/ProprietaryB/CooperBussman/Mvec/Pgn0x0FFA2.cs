using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryB.CooperBussman.Mvec
{
    /// <summary>
    /// PGN: 65442 J1939 Proprietary B PGN - System Error Status
    /// </summary>
    public class Pgn0x0FFA2 : J1939ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN: 65442 J1939 Proprietary B PGN - System Error Status";
            }
        }

        public override PgnType PgnType
        {
            get
            {
                return PgnType.J3919;
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
                return 0x0FFA2;
            }
        }

        public override Target Target => throw new NotImplementedException();

        /// <summary>
        /// Represents the address of the MVEC module grid.
        /// </summary>
        public byte GridAddress { get; private set; }

        /// <summary>
        /// Error byte 0
        /// </summary>
        public byte ErrorByte0 { get; private set; }

        /// <summary>
        /// Error byte 1
        /// </summary>
        public byte ErrorByte1 { get; private set; }



        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //Error byte 0
            ErrorByte1 = data[0];

            //Error byte 1
            ErrorByte0 = data[1];

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
            return this;
        }
    }
}
