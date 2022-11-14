using WhatTheHelmCanLib.ParameterGroups;
using WhatTheHelmCanLib.ParameterGroups.J1939;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.Messages
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
        /// Represents the MSB of the PGN
        /// </summary>
        public const byte PGN_RESERVED_BIT = 0;

        /// <summary>
        /// If true, message shall be addressed to a single node.  Else, the message is broadcasted to all nodes (destination = 255)
        /// </summary>
        public bool IsAddressible { get; private set; }
        /// <summary>
        /// Standard or extended format message identifer.
        /// </summary>
        public Format Format { get; private set; }

        /// <summary>
        /// The Data Page Selector (PS, 0=J1939,1=NMEA2000), which is the MSB of the PGN
        /// </summary>
        public PgnType PgnType { get; private set; }
        /// <summary>
        /// The PDU Format (PF) field, which is the middle byte of the PGN
        /// </summary>
        public byte PF { get; private set; }
        /// <summary>
        /// The PDU Specific (PS) field, which is the LSB of the PGN. If the PF is between 0 and 239, the message is addressable (PDU1) and the PS field contains the destination address.
        /// </summary>
        public byte PS { get; private set; }
        /// <summary>
        /// Message priority (1-7)
        /// </summary>
        public int Priority { get; private set; }
        /// <summary>
        /// The network address of the message producer.
        /// </summary>
        public ushort SourceAddress { get; private set; }
        /// <summary>
        /// The network address of the message consumer.
        /// </summary>
        public ushort DestinationAddress { get; private set; }
        /// <summary>
        /// The PGN scope of the message.
        /// </summary>
        public uint Pgn { get; private set; }
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
        /// <param name="destinationAddress">The CAN network address of the message consumer.</param>
        /// <param name="data">The data frame of the CAN message</param>
        public CanMessage(uint parameterGroupNumber, Format format,int priority, ushort sourceAddress, ushort destinationAddress, byte[] data)
        {
            Format = format;
            Priority = priority;
            Pgn = parameterGroupNumber;
            byte[] pgn = BitConverter.GetBytes(parameterGroupNumber);
            if (pgn.Length > 0)
                PgnType = (PgnType)pgn[0];
            if (pgn.Length > 1)
                PF = pgn[1];
            if (pgn.Length > 2)
            {
                if (PF <= 239)
                {
                    PS = (byte)destinationAddress;
                    IsAddressible = true;
                }
                else
                {
                    PS = pgn[2];
                    IsAddressible = false;
                }
            }    
            SourceAddress = sourceAddress;
            DestinationAddress = destinationAddress;
            Data = data;
        }
    }
}
