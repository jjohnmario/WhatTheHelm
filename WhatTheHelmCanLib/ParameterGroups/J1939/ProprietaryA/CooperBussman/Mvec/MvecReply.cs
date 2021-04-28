using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec
{
    /// <summary>
    /// Represents an enumeration of replies capablie of being produces by MVEC modules.
    /// </summary>
    public enum ReplyMessage
    {
        /// <summary>
        /// Diagnostic message that indicates success or failure
        /// </summary>
        hex01 = 0x01,
        /// <summary>
        /// Response to 0x12 command
        /// </summary>
        hex13 = 0x13,
        /// <summary>
        /// Response to 0x92 command
        /// </summary>
        hex94 = 0x94,
        /// <summary>
        /// Response to 0x96 command
        /// </summary>
        hex96 = 0x96,
        /// <summary>
        /// Response to 0x97 command
        /// </summary>
        hex97 = 0x97,
    }

    /// <summary>
    /// Represents a response from an MVEC module to a PGN 0x0EF00 command.
    /// </summary>
    public abstract class MvecReply
    {
        /// <summary>
        /// Represents the type of reply.
        /// </summary>
        public abstract ReplyMessage Reply { get; }

        /// <summary>
        /// Deserializes a byte array into an object of type: MvecCommand
        /// </summary>
        /// <param name="data">Byte array comtaining fields to deserialize.</param>
        /// <returns></returns>
        public abstract MvecReply DeserializeFields(byte[] data);
    }
}
