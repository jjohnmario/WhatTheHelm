using System;
using System.Collections.Generic;
using System.Text;
using WhatTheHelmCanLib.Messages;

namespace WhatTheHelmCanLib.Devices
{
    /// <summary>
    /// Defines the properties and methods for a device to function as a CAN gateway.
    /// </summary>
    public interface ICanGateway : IDisposable
    {
        /// <summary>
        /// Raised when a message is recieved from the CAN bus network.
        /// </summary>
        event EventHandler<CanMessageArgs> MessageRecieved;
        /// <summary>
        /// Parses a CAN message in native gateway format to an object of type: CanMessage.
        /// </summary>
        /// <param name="message">CAN message to parse.</param>
        /// <returns></returns>
        CanMessage Parse(object message);
        /// <summary>
        /// Opens a connection to the CAN gateway device.
        /// </summary>
        bool Open();
        /// <summary>
        /// Closes all connections to the CAN gateway device.
        /// </summary>
        bool Close();
        /// <summary>
        /// Serializes the CAN message and writes the result to the CAN gateway.
        /// </summary>
        /// <param name="message">CAN message to write.</param>
        /// <returns>True if write operation was successful.</returns>
        bool Write(CanMessage message);
    }
}
