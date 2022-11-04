using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.Devices
{
    /// <summary>
    /// Represents a CAN controller application (CA)
    /// </summary>
    public abstract class CanDevice
    {
        public CanName Name { get; set; }
        /// <summary>
        /// Represents the address of the device on the CAN network.
        /// </summary>
        public ushort Address { get; set; }
        /// <summary>
        /// Creates a CAN device with the defined source address.
        /// </summary>
        /// <param name="address">Address to assign to the CAN device</param>
        public CanDevice(ushort address)
        {
            Address = address;
        }
        /// <summary>
        /// Creates a CAN device with the defined source address and NAME.
        /// </summary>
        /// <param name="address">Address to assign to the CAN device</param>
        /// <param name="name">NAME to assign the CAN device</param>
        public CanDevice(ushort address, CanName name)
        {
            Address = address;
            Name = name;
        }

    }
}
