using WhatTheHelmCanLib.Messages;
using WhatTheHelmCanLib.ParameterGroups;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.Devices
{
    /// <summary>
    /// Represents a generic CAN gateway.
    /// </summary>
    public abstract class CanGateway : CanDevice ,IDisposable
    {
        public const int CAN_ADDCLAIM_PGN = 60928;
        public const int CAN_ISOREQ_PGN = 59904;
        /// <summary>
        /// Creates a generic CAN gateway with the defined source address.
        /// </summary>
        /// <param name="address">Address to assign to the CAN gateway</param>
        public CanGateway(ushort address) : base(address) { }
        /// <summary>
        /// Creates a generic CAN gateway with the defined source address and NAME.
        /// </summary>
        /// <param name="address">Address to assign to the CAN gateway</param>
        /// <param name="name">NAME to assign the CAN gateway</param>
        public CanGateway(ushort address, CanName name) : base(address, name) { }
        /// <summary>
        /// A CAN message has been recieved by the gateway.
        /// </summary>
        public abstract event EventHandler<CanMessageArgs> MessageRecieved;
        /// <summary>
        /// Parses a CAN message in native gateway format to an object of type: CanMessage.
        /// </summary>
        /// <param name="message">CAN message to parse.</param>
        /// <returns></returns>
        public abstract CanMessage Parse(object message);
        /// <summary>
        /// Opens a connection to the CAN gateway device.
        /// </summary>
        public abstract bool Open();
        /// <summary>
        /// Closes all connections to the CAN gateway device.
        /// </summary>
        public abstract bool Close();
        /// <summary>
        /// Serializes the CAN message and writes the result to the CAN gateway.
        /// </summary>
        /// <param name="message">CAN message to write.</param>
        /// <returns>True if write operation was successful.</returns>
        public abstract bool Write(CanMessage message);
        /// <summary>
        /// Separates the identity and data frame of a single message and parses CAN message properties into key value pairs.
        /// </summary>
        /// <param name="message">CAN message to parse.</param>
        /// <returns></returns>
        protected abstract CanIdDataPair ParseExtended(object message);
        /// <summary>
        /// Serializes the multi-packet CAN message into individual CAN messages and writes each result to the CAN gateway.
        /// </summary>
        /// <param name="message">Multi-packet CAN message to write.</param>
        protected abstract void WriteMultiPacket(CanMessage message);
        public virtual void Dispose() { }
    }
}
