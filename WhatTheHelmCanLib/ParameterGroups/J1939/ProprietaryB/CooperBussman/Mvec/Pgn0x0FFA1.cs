using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.J1939.ProprietaryB.CooperBussman.Mvec
{
    /// <summary>
    /// Relay status of a single relay in an MVEC module grid.
    /// </summary>
    public enum RelayStatus
    {
        /// <summary>
        /// Okay
        /// </summary>
        Okay = 0x00,
        /// <summary>
        /// Relay coil open or relay not present
        /// </summary>
        CoilOpenOrNotPresent = 0x01,
        /// <summary>
        /// Coil shorted or failed relay driver
        /// </summary>
        CoilShorted = 0x02,
        /// <summary>
        /// Normally Open (N.O) contact is open (when a N.O contact is not connected to the Common (C) terminal, but should be).
        /// </summary>
        NOContactOpen = 0x03,
        /// <summary>
        /// Normally Closed (N.C) contact is open (when a N.C contact is not connected to the Common (C) terminal, but should be).
        /// </summary>
        NCContactOpen = 0x04,
        /// <summary>
        /// he coil is not receiving power
        /// </summary>
        CoilNoPower = 0x05,
        /// <summary>
        /// Normally Open (N.O) contact is shorted (when a N.O contact is connected to the Common (C) terminal, but should not be).
        /// </summary>
        NOContactShorted = 0x06,
        /// <summary>
        /// Normally Closed (N.C) contact is shorted (when a N.C contact is connected to the Common (C) terminal, but should not be)
        /// </summary>
        NCContactShorted = 0x07,
        /// <summary>
        /// High-side driver is reporting a fault condition.
        /// </summary>
        HighSideDriverFault = 0x0B,
        /// <summary>
        /// High-side driver has an open-load
        /// </summary>
        HighSideDriverOpenLoad = 0xC,
        /// <summary>
        /// High-side driver is over voltage
        /// </summary>
        HighSideDriverOverVoltage = 0xD,
        /// <summary>
        /// Relay location not used
        /// </summary>
        RelayLocationNotUsed = 0x0F
    }
    /// <summary>
    /// PGN: 65441 J1939 Proprietary B PGN - Relay Status
    /// </summary>
    public class Pgn0x0FFA1 : J1939ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN: 65441 J1939 Proprietary B PGN - Relay Status";
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

        public override int Pgn
        {
            get
            {
                return 0x0FFA1;
            }
        }

        public override Target Target => throw new NotImplementedException();

        /// <summary>
        /// Represents the address of the MVEC module grid.
        /// </summary>
        public byte GridAddress { get; private set; }

        /// <summary>
        /// Represents the status of each individual relay in the MVEC module grid.
        /// </summary>
        public RelayStatus[] RelayStatus { get; private set; }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //Grid Address
            GridAddress = data[0];

            //Fuse Status
            RelayStatus = new RelayStatus[13];

            //Byte 1
            string byte1Bin = Convert.ToString(data[1], 2).PadLeft(8, '0');
            RelayStatus[1] = (RelayStatus)Convert.ToByte(byte1Bin.Substring(0, 4), 2);
            RelayStatus[0] = (RelayStatus)Convert.ToByte(byte1Bin.Substring(4, 4), 2);

            //Byte 2
            string byte2Bin = Convert.ToString(data[2], 2).PadLeft(8, '0');
            RelayStatus[3] = (RelayStatus)Convert.ToByte(byte2Bin.Substring(0, 4), 2);
            RelayStatus[2] = (RelayStatus)Convert.ToByte(byte2Bin.Substring(4, 4), 2);

            //Byte 3
            string byte3Bin = Convert.ToString(data[3], 2).PadLeft(8, '0');
            RelayStatus[5] = (RelayStatus)Convert.ToByte(byte3Bin.Substring(0, 4), 2);
            RelayStatus[4] = (RelayStatus)Convert.ToByte(byte3Bin.Substring(4, 4), 2);

            //Byte 4
            string byte4Bin = Convert.ToString(data[4], 2).PadLeft(8, '0');
            RelayStatus[7] = (RelayStatus)Convert.ToByte(byte4Bin.Substring(0, 4), 2);
            RelayStatus[6] = (RelayStatus)Convert.ToByte(byte4Bin.Substring(4, 4), 2);

            //Byte 5
            string byte5Bin = Convert.ToString(data[5], 2).PadLeft(8, '0');
            RelayStatus[9] = (RelayStatus)Convert.ToByte(byte5Bin.Substring(0, 4), 2);
            RelayStatus[8] = (RelayStatus)Convert.ToByte(byte5Bin.Substring(4, 4), 2);

            //Byte 6
            string byte6Bin = Convert.ToString(data[6], 2).PadLeft(8, '0');
            RelayStatus[11] = (RelayStatus)Convert.ToByte(byte6Bin.Substring(0, 4), 2);
            RelayStatus[10] = (RelayStatus)Convert.ToByte(byte6Bin.Substring(4, 4), 2);

            //Byte 7
            string byte7Bin = Convert.ToString(data[7], 2).PadLeft(8, '0');
            RelayStatus[12] = (RelayStatus)Convert.ToByte(byte7Bin.Substring(0, 4), 2);

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
