using WhatTheHelmCanLib.Devices.Nmea2000;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN:126996 Product Information
    /// </summary>
    public class Pgn0x1F014 : Nmea2000ParameterGroup
    {
        public override uint Pgn
        {
            get
            {
                return 126996;
            }
        }

        public override bool MultiFrame
        {
            get
            {
                return true;
            }
        }
        public override PgnType PgnType
        {
            get
            {
                return PgnType.NMEA2000;
            }
        }

        public override Target Target
        {
            get
            {
                return Target.Defined;
            }
        }

        public override string Description
        {
            get
            {
                return "PGN:126996 Product Information";
            }
        }

        /// <summary>
        /// The project information payload associated with the PGN instance.
        /// </summary>
        public N2KProductInformation ProductInformation { get; private set; }

        /// <summary>
        /// Creates an object reference to PGN:126996 Product Information
        /// </summary>
        public Pgn0x1F014()
        {
            ProductInformation = new N2KProductInformation();
        }

        /// <summary>
        /// Craetes an object reference to PGN:126996 Product Information with the defined product information.
        /// </summary>
        /// <param name="productInformation"></param>
        public Pgn0x1F014(N2KProductInformation productInformation)
        {
            ProductInformation = productInformation;
        }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            if (data.Length != 134)
                return null;
            else
            {
                //NMEA 2000 Version
                ProductInformation.Nmea2000Version = BitConverter.ToUInt16(data, 0);

                //Product Code
                ProductInformation.ProductCode = BitConverter.ToUInt16(data, 2);

                //Model ID
                var foo = Encoding.ASCII.GetChars(data);
                ProductInformation.ModelId = Encoding.ASCII.GetString(data, 4, 32).TrimEnd('?').TrimEnd('\0');

                //Software Version Code
                ProductInformation.SoftwareVersionCode = Encoding.ASCII.GetString(data, 36, 32).TrimEnd('?').TrimEnd('\0');

                //Model Version
                ProductInformation.ModelVersion = Encoding.ASCII.GetString(data, 68, 32).TrimEnd('?').TrimEnd('\0');

                //Model Serial Code
                ProductInformation.ModelSerialCode = Encoding.ASCII.GetString(data, 100, 32).TrimEnd('?').TrimEnd('\0');

                //Bus Load Equivalency
                ProductInformation.LoadEquivalancy = data[133];

                return this;
            }
        }

        public override byte[] SerializeFields()
        {
            byte[] bytes = new byte[134];

            //NMEA2000 Version
            byte[] nmea2000Version = BitConverter.GetBytes(ProductInformation.Nmea2000Version);
            if (nmea2000Version.Length <= 2)
                nmea2000Version.CopyTo(bytes, 0);

            //Product Code
            byte[] productCode = BitConverter.GetBytes(ProductInformation.ProductCode);
            if (productCode.Length <= 2)
                productCode.CopyTo(bytes, 2);

            //Model ID
            byte[] modelId = Encoding.ASCII.GetBytes(ProductInformation.ModelId);
            if (modelId.Length <= 32)
                modelId.CopyTo(bytes, 4);

            //Software Version Code
            byte[] softwareVersion = Encoding.ASCII.GetBytes(ProductInformation.SoftwareVersionCode);
            if (softwareVersion.Length <= 32)
                softwareVersion.CopyTo(bytes, 36);

            //Model Version
            byte[] modelVersion = Encoding.ASCII.GetBytes(ProductInformation.ModelVersion);
            if (modelVersion.Length <= 32)
                modelVersion.CopyTo(bytes, 68);

            //Model Serial Code
            byte[] serialCode = Encoding.ASCII.GetBytes(ProductInformation.ModelSerialCode);
            if (serialCode.Length <= 32)
                serialCode.CopyTo(bytes, 100);

            //Certification Level
            bytes[132] = ProductInformation.CertificationLevel;

            //Bus Load Equivalency
            bytes[133] = ProductInformation.LoadEquivalancy;

            return bytes;
        }

        public override ParameterGroup ToImperial()
        {
            return this;
        }

        public override ParameterGroup ToMetric()
        {
            return this;
        }


    }
}
