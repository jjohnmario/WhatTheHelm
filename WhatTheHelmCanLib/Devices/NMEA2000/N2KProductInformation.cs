using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.Devices.Nmea2000
{
    /// <summary>
    /// Represents product information for a NMEA2000 device.
    /// </summary>
    public class N2KProductInformation
    {
        /// <summary>
        /// Represents the NMEA 2000 version to which the device is designed.
        /// </summary>
        public ushort Nmea2000Version { get; set; }
        /// <summary>
        /// Represents the product code of the device.
        /// </summary>
        public ushort ProductCode { get; set; }
        /// <summary>
        /// Represents the model ID of the device.
        /// </summary>
        public string ModelId { get; set; }
        /// <summary>
        /// Represents the software version of the device.
        /// </summary>
        public string SoftwareVersionCode { get; set; }
        /// <summary>
        /// Represents the model version of the device.
        /// </summary>
        public string ModelVersion { get; set; }
        /// <summary>
        /// Represents the serial number of the device.
        /// </summary>
        public string ModelSerialCode { get; set; }
        /// <summary>
        /// Unknown
        /// </summary>
        public byte CertificationLevel { get; set; }
        /// <summary>
        /// Represents the current (x*50 milliamps) drawn from the CAN bus by the device.
        /// </summary>
        public byte LoadEquivalancy { get; set; }

        /// <summary>
        /// Creates a product information instance for a NMEA2000 device.
        /// </summary>
        public N2KProductInformation()
        {

        }

        /// <summary>
        /// Creates a product information instance for a NMEA2000 device using the defined PGN fields.
        /// </summary>
        /// <param name="nmea2000Version">Represents the NMEA 2000 version to which the device is designed.</param>
        /// <param name="productCode">Represents the product code of the device.</param>
        /// <param name="modelId">Represents the model ID of the device.</param>
        /// <param name="softwareVersionCode">Represents the software version of the device.</param>
        /// <param name="modelVersion">Represents the model version of the device.</param>
        /// <param name="modelSerialCode">Represents the serial number of the device.</param>
        /// <param name="certificationLevel">Unknown</param>
        /// <param name="loadEquivalancy">Represents the current (x*50 milliamps) drawn from the CAN bus by the device.</param>
        public N2KProductInformation(ushort nmea2000Version, ushort productCode, string modelId, string softwareVersionCode, string modelVersion, string modelSerialCode, byte certificationLevel, byte loadEquivalancy)
        {
            Nmea2000Version = nmea2000Version;
            ProductCode = productCode;
            ModelId = modelId;
            SoftwareVersionCode = softwareVersionCode;
            ModelVersion = modelVersion;
            ModelSerialCode = modelSerialCode;
            CertificationLevel = certificationLevel;
            LoadEquivalancy = loadEquivalancy;

        }
    }
}
