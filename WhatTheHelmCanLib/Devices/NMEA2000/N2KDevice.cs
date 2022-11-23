﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.Devices.Nmea2000
{
    /// <summary>
    /// Represents a NMEA2000 device
    /// </summary>
    public class N2KDevice : CanDevice
    {
        /// <summary>
        /// A list of available recieve PGNs
        /// </summary>
        public List<uint> RxPgns { get; set; } = new List<uint>();
        /// <summary>
        /// A list of available transmit PGNs
        /// </summary>
        public List<uint> TxPgns { get; set; } = new List<uint>();
        /// <summary>
        /// Contains the NMEA2000 product information for the device
        /// </summary>
        public N2KProductInformation ProductInformation { get; set; } = new N2KProductInformation();

        public N2KDevice(ushort sourceAddress):base(sourceAddress)
        {
        }
        public N2KDevice(ushort sourceAddress, CanName name) : base(sourceAddress, name)
        {

        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", ProductInformation.ModelId, ProductInformation.ModelSerialCode);
        }
    }
}