using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryB.CooperBussman.Mvec
{
    /// <summary>
    /// Fuse status of a single fuse in an MVEC module grid.
    /// </summary>
    public enum FuseStatus { NoFault, Blown, NotPowered, NotUsed}

    /// <summary>
    /// PGN: 65440 J1939 Proprietary B PGN - Fuse Status
    /// </summary>
    public class Pgn0x0FFA0 : J1939ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN: 65440 J1939 Proprietary B PGN - Fuse Status";
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
                return 0x0FFA0;
            }
        }

        public override Target Target => throw new NotImplementedException();

        /// <summary>
        /// Represents the address of the MVEC module grid.
        /// </summary>
        public byte GridAddress { get; private set; }

        /// <summary>
        /// Represents the status of each individual fuse in the MVEC module grid.
        /// </summary>
        public FuseStatus[] FuseStatus { get; private set; }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //Grid Address
            GridAddress = data[0];

            //Fuse Status
            FuseStatus = new FuseStatus[16];

            //Byte 1
            string byte1Bin = Convert.ToString(data[1], 2).PadLeft(8, '0');
            FuseStatus[3] = (FuseStatus)Convert.ToByte(byte1Bin.Substring(0, 2),2);
            FuseStatus[2] = (FuseStatus)Convert.ToByte(byte1Bin.Substring(2, 2),2);
            FuseStatus[1] = (FuseStatus)Convert.ToByte(byte1Bin.Substring(4, 2),2);
            FuseStatus[0] = (FuseStatus)Convert.ToByte(byte1Bin.Substring(6, 2),2);

            //Byte 2
            string byte2Bin = Convert.ToString(data[2], 2).PadLeft(8, '0');
            FuseStatus[7] = (FuseStatus)Convert.ToByte(byte2Bin.Substring(0, 2),2);
            FuseStatus[6] = (FuseStatus)Convert.ToByte(byte2Bin.Substring(2, 2),2);
            FuseStatus[5] = (FuseStatus)Convert.ToByte(byte2Bin.Substring(4, 2),2);
            FuseStatus[4] = (FuseStatus)Convert.ToByte(byte2Bin.Substring(6, 2),2);

            //Byte 3
            string byte3Bin = Convert.ToString(data[3], 2).PadLeft(8, '0');
            FuseStatus[11] = (FuseStatus)Convert.ToByte(byte3Bin.Substring(0, 2),2);
            FuseStatus[10] = (FuseStatus)Convert.ToByte(byte3Bin.Substring(2, 2),2);
            FuseStatus[9] = (FuseStatus)Convert.ToByte(byte3Bin.Substring(4, 2),2);
            FuseStatus[8] = (FuseStatus)Convert.ToByte(byte3Bin.Substring(6, 2),2);

            //Byte 4
            string byte4Bin = Convert.ToString(data[4], 2).PadLeft(8, '0');
            FuseStatus[15] = (FuseStatus)Convert.ToByte(byte4Bin.Substring(0, 2),2);
            FuseStatus[14] = (FuseStatus)Convert.ToByte(byte4Bin.Substring(2, 2),2);
            FuseStatus[13] = (FuseStatus)Convert.ToByte(byte4Bin.Substring(4, 2),2);
            FuseStatus[12] = (FuseStatus)Convert.ToByte(byte4Bin.Substring(6, 2),2);

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
