using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.Devices.Nmea2000
{
    public class Nmea2000Device : CanDevice
    {
        /// <summary>
        /// A list of available recieve PGNs
        /// </summary>
        public List<uint> N2KRxPgns { get; set; } = new List<uint>();
        /// <summary>
        /// A list of available transmit PGNs
        /// </summary>
        public List<uint> N2KTxPgns { get; set; } = new List<uint>();
        /// <summary>
        /// Contains the NMEA2000 product information for the device
        /// </summary>
        public N2KProductInformation ProductInformation { get; set; } = new N2KProductInformation();

        public Nmea2000Device(ushort sourceAddress):base(sourceAddress)
        {
        }
        public Nmea2000Device(ushort sourceAddress, CanName name) : base(sourceAddress, name)
        {

        }
    }
}
