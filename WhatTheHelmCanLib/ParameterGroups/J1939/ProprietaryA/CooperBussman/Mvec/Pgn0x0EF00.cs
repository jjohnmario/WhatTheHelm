using WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.MVec
{
    /// <summary>
    /// PGN: 61184 Cooper-Bussman mVEC Command PGN
    /// </summary>
    public class Pgn0x0EF00 : ParameterGroup
    {
        public override bool MultiFrame
        {
            get
            {
                return false;
            }
        }

        public override Target Target => throw new NotImplementedException();

        public override string Description
        {
            get
            {
                return "PGN: 61184 Cooper-Bussman mVEC Command PGN";
            }
        }

        public override PgnType PgnType
        {
            get
            {
                return PgnType.J3919;
            }
        }

        public override uint Pgn
        {
            get
            {
                return 61184;

            }
        }

        /// <summary>
        /// Represents the command data passed using the command PGN
        /// </summary>
        public MvecCommand Command { get; private set; }

        /// <summary>
        /// Represents the reply data passed from an MVEC module in response the command.
        /// </summary>
        public MvecReply Reply { get; private set; }

        /// <summary>
        /// Represents the address of the MVEC module to which the command PGN is intended.
        /// </summary>
        public byte DestinationAddress { get; private set; }

        public Pgn0x0EF00()
        {

        }

        public Pgn0x0EF00(MvecCommand command, byte destinationAddress)
        {
            Command = command;
            DestinationAddress = destinationAddress;
        }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            ReplyMessage msg = (ReplyMessage)data[0];
            switch (msg)
            {
                //
                case ReplyMessage.hex01:
                    {
                        Reply = new MvecReply0x01().DeserializeFields(data);
                        break;
                    }
                case ReplyMessage.hex13:
                    {
                        Reply = new MvecReply0x13().DeserializeFields(data);
                        break;
                    }
                case ReplyMessage.hex94:
                    {
                        Reply = new MvecReply0x94().DeserializeFields(data);
                        break;
                    }
                case ReplyMessage.hex96:
                    {
                        Reply = new MvecReply0x96().DeserializeFields(data);
                        break;
                    }
                case ReplyMessage.hex97:
                    {
                        Reply = new MvecReply0x97().DeserializeFields(data);
                        break;
                    }
            }
            return this;
        }

        public override byte[] SerializeFields()
        {
            return Command.SerializeFields();
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
