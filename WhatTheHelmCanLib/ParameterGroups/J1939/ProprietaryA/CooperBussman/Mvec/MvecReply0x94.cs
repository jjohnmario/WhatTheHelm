using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec
{
    /// <summary>
    /// Represents a reply containing the population table settings of the MVEC module.
    /// </summary>
    public class MvecReply0x94 : MvecReply
    {
        public override ReplyMessage Reply
        {
            get
            {
                return ReplyMessage.hex94;
            }
        }

        /// <summary>
        /// Represents the response message ID which returned the field values.
        /// </summary>
        public byte ResponseMessageId { get; private set; }

        /// <summary>
        /// Represents the grid address for the requested population table.
        /// </summary>
        public byte GridAddress { get; private set; }

        /// <summary>
        /// Represents the fuse population by location of a grid within the MVEC module.
        /// </summary>
        public BitArray FusePopulated { get; private set; }

        /// <summary>
        /// Represents the relay population by location of a grid within the MVEC module.
        /// </summary>
        public BitArray RelayPopulated { get; private set; }

        public override MvecReply DeserializeFields(byte[] data)
        {
            //Byte 0
            ResponseMessageId = data[0];
            //Byte 1
            GridAddress = data[1];
            //Byte 2 -3 
            FusePopulated = new BitArray(new byte[3] { data[2], data[3], data[4] });
            //Byte 6
            RelayPopulated = new BitArray(new byte[2] { data[6], data[7] });
            return this;
        }
    }
}
