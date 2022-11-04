using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec
{
    /// <summary>
    /// Represents a reply containing board configuration, CAN source address offset, CAN source address base, PGN base value, CAN message count threshold, CAN timeout source address
    /// </summary>
    public class MvecReply0x97 : MvecReply
    {
        public override ReplyMessage Reply
        {
            get
            {
                return ReplyMessage.hex97;
            }
        }

        /// <summary>
        /// Represents the response message ID which returned the field values.
        /// </summary>
        public byte ResponseMessageId { get; private set; }

        /// <summary>
        /// REpresents the detected circuit board configuration (Read from mapping board)
        /// </summary>
        public byte CircuitBoardConfig { get; private set; }

        /// <summary>
        /// Represents the CAN source address offset (cable select)
        /// </summary>
        public byte CanSourceAddrOffset { get; private set; }

        /// <summary>
        /// Represents the CAN source address base
        /// </summary>
        public byte CanSourceBaseAddr { get; private set; }

        /// <summary>
        /// Represents the maximum number of failed messages before faulting.
        /// </summary>
        public ushort CanMessageCountThreshold { get; private set; }

        /// <summary>
        /// Address of the MVEC module that has timed out.
        /// </summary>
        public byte CanTimeOutSourceAddr { get; private set; }

        /// <summary>
        /// Represents the base PGN for use with status messages.  Default is 0xA0.
        /// </summary>
        public byte StatusPgnBase { get; private set; }

        public override MvecReply DeserializeFields(byte[] data)
        {
            //Byte 0
            ResponseMessageId = data[0];
            //Byte 1
            CircuitBoardConfig = data[1];
            //Byte 2
            CanSourceAddrOffset = data[2];
            //Byte 3
            CanSourceBaseAddr = data[3];
            //Bytes 4-5
            CanMessageCountThreshold = BitConverter.ToUInt16(data, 4);
            //Byte 6
            CanTimeOutSourceAddr = data[6];
            //Byte 7
            StatusPgnBase = data[7];
            return this;
        }
    }
}
