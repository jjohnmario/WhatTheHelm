using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec
{
    /// <summary>
    /// Represents the status of the command as reported by the reply message.
    /// </summary>
    public enum CommandStatus
    {
        Failure = 0,
        Success = 1
    }
    /// <summary>
    /// An object reference to a diagnostic message that indicates sucess or failure.
    /// </summary>
    internal class MvecReply0x01 : MvecReply
    {
        public override ReplyMessage Reply
        {
            get
            {
                return ReplyMessage.hex01;
            }
        }

        /// <summary>
        /// Represents the command message being responded to.
        /// </summary>
        public CommandMessage Command { get; private set; }

        /// <summary>
        /// Represents the status of the command message being responded to.
        /// </summary>
        public CommandStatus CommandStatus { get; private set; }

        public override MvecReply DeserializeFields(byte[] data)
        {
            //Byte 1
            Command = (CommandMessage)data[1];

            //Byte 2
            CommandStatus = (CommandStatus)data[2];
            return this;
        }
    }
}
