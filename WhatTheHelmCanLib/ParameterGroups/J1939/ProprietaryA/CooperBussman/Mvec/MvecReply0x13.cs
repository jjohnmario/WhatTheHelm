using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec
{
    /// <summary>
    /// Represents the operating mode of the software on an MVEC module.
    /// </summary>
    public enum SoftwareOperatingMode
    {
        Run = 0x00,
        Reserved = 0x01,
        TestMode = 0x02
    }

    /// <summary>
    /// Represents a reply containing the installed bootloader version on the MVEC module.
    /// </summary>
    internal class MvecReply0x13 : MvecReply
    {
        public override ReplyMessage Reply
        {
            get
            {
                return ReplyMessage.hex13;
            }
        }

        /// <summary>
        /// Represents the response message ID which returned the field values.
        /// </summary>
        public byte ResponseMessageId { get; private set; }

        /// <summary>
        /// Represents the operating mode of the software on the MVEC module.
        /// </summary>
        public SoftwareOperatingMode SoftwareOperatingMode { get; private set; }

        /// <summary>
        /// Represents the installed software version on the MVEC module.
        /// </summary>
        public ushort SoftwareVersion { get; private set; }

        /// <summary>
        /// Represents the installed bootloader version on the MVEC module.
        /// </summary>
        public ushort AlternateVersion { get; private set; }

        public override MvecReply DeserializeFields(byte[] data)
        {
            if (data.Length != 8)
                throw new IndexOutOfRangeException("The data frame must be exactly 8 bytes.");
            else
            {
                //Byte 0
                ResponseMessageId = data[0];

                //Byte 1
                SoftwareOperatingMode = (SoftwareOperatingMode)data[1];

                //Bytes 2
                SoftwareVersion = BitConverter.ToUInt16(data, 2);

                //Bytes 3
                AlternateVersion = BitConverter.ToUInt16(data, 4);
            }
            return this;
        }
    }
}
