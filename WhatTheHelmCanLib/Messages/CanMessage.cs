using CanLib.ParameterGroups;
using CanLib.ParameterGroups.J1939;
using CanLib.ParameterGroups.NMEA2000;
using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.Messages
{
    /// <summary>
    /// Enumeration of CAN message identifer types.
    /// </summary>
    public enum Format
    { 
        /// <summary>
        /// Represents a Standard 11 bit CAN identifier
        /// </summary>
        STANDARD,
        /// <summary>
        /// Represents an extended 29 bit CAN identifer
        /// </summary>
        EXTENDED 
    }

    /// <summary>
    /// A CAN message presented as a key value pair consisting of an identifier and a data frame.
    /// </summary>
    public struct CanIdDataPair
    {
        public byte[] Id;
        public byte[] Data;
    }


    /// <summary>
    /// Object representation of a generic CAN message.
    /// </summary>
    public class CanMessage
    {
        /// <summary>
        /// Standard or extended format message identifer.
        /// </summary>
        public Format Format { get; private set; }
        /// <summary>
        /// Message priority (1-7)
        /// </summary>
        public int Priority { get; private set; }
        /// <summary>
        /// The address of the message producing network node.
        /// </summary>
        public ushort SourceAddress { get; private set; }
        /////// <summary>
        /////// Defines whether the message is part of a multi-packet message.
        /////// </summary>
        //public bool MultiPacketMessage { get; private set; }
        /// <summary>
        /// The PGN scope of the message.
        /// </summary>
        public int ParameterGroupNumber { get; private set; }
        /// <summary>
        /// The data frame of the message.
        /// </summary>
        public byte[] Data { get; set; }


        /// <summary>
        /// Creates a CAN message with a defined format, priority, parameter group, source address and data frame.
        /// </summary>
        /// <param name="parameterGroupNumber">The PGN scope of the message.</param>
        /// <param name="format">Standard or extended format message identifer.</param>
        /// <param name="priority">Message priority (1-7)</param>
        /// <param name="sourceAddress">The CAN network address of the message producer.</param>
        /// <param name="data">The data frame of the CAN message</param>
        public CanMessage(int parameterGroupNumber, Format format,int priority, ushort sourceAddress, byte[] data)
        {
            Format = format;
            Priority = priority;
            ParameterGroupNumber = parameterGroupNumber;
            SourceAddress = sourceAddress;
            Data = data;
            //MultiPacketMessage = multiPacketMessage;
        }
    }
}
