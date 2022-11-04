using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec
{
    /// <summary>
    /// Represents a reply containing the relay states of the MVEC module.
    /// </summary>
    public class MvecReply0x96 : MvecReply
    {
        public override ReplyMessage Reply
        {
            get
            {
                return ReplyMessage.hex96;
            }
        }

        /// <summary>
        /// Represents the response message ID which returned the field values.
        /// </summary>
        public byte ResponseMessageId { get; private set; }

        /// <summary>
        /// Represents the grid address for the requested relay states.
        /// </summary>
        public byte GridAddress { get; private set; }

        /// <summary>
        /// Represents the relay states of a grid within the MVEC module.
        /// </summary>
        public BitArray RelayState { get; private set; }

        /// <summary>
        /// Represents the default relay states of a grid within the MVEC module
        /// </summary>
        public BitArray RelayDefaultState { get; private set; }

        /// <summary>
        /// Represents the delay in ms after power is applied to the grid before relays are set to thier default states.
        /// </summary>
        public ushort StartupDelay { get; private set; }

        public override MvecReply DeserializeFields(byte[] data)
        {
            //Byte 0
            ResponseMessageId = data[0];
            //Byte 1
            GridAddress = data[1];
            //Byte 2 -3 
            RelayState = new BitArray(new byte[2] { data[2], data[3] });
            //Byte 4-5
            RelayDefaultState = new BitArray(new byte[2] { data[4], data[5] });
            //Byte 6-7
            StartupDelay = BitConverter.ToUInt16(data, 6);
            return this;
        }
    }
}
