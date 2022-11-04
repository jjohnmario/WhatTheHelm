using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.Devices
{
    /// <summary>
    /// Represents the NAME property, which is used to uniquely identify a single J1939 CAN node on a CAN network
    /// </summary>
    public class CanName
    {
        /// <summary>
        /// If true, the CA is able to assign itself an address.
        /// </summary>
        public bool SelfConfigurable { get; set; }
        /// <summary>
        /// Represents the J1939 Industry Group
        /// </summary>
        public ushort IndustryGroup { get; set; }
        /// <summary>
        /// Represents an instance of a generic system in the vehicle.
        /// </summary>
        public ushort VehicleSystemInstance { get; set; }
        /// <summary>
        /// Represents a generic system within the vehicle according to the J1939 standard.
        /// </summary>
        public ushort VehicleSystem { get; set; }
        /// <summary>
        /// Represents a generic function within the vehicle according to the J1939 standard.
        /// </summary>
        public ushort Function { get; set; }
        /// <summary>
        /// Represents an instance of a generic function within the vehicle accroding to the J1939 standard.
        /// </summary>
        public ushort FunctionInstance { get; set; }
        /// <summary>
        /// Represents an instance of an ECU within the vehicle.
        /// </summary>
        public ushort EcuInstance { get; set; }
        /// <summary>
        /// Represents the manufacturer product code of the ECU.  This is likely to indicate the model number of the ECU.
        /// </summary>
        public Int16 ManufacturerCode { get; set; }
        /// <summary>
        /// Represents the identity number of the ECU associated with the name.  This is likely to indicate the serial number of a device.
        /// </summary>
        public int IdentityNumber { get; set; }

        /// <summary>
        /// Creates a CAN NAME attribute using the standard J1939 NAME data fields.
        /// </summary>
        /// <param name="selfConfigurable">If true, the CA is able to assign itself an address.</param>
        /// <param name="industryGroup">Represents the J1939 Industry Group</param>
        /// <param name="vehicleSystemInstance">Represents an instance of a generic system in the vehicle.</param>
        /// <param name="vehicleSystem">Represents a generic system within the vehicle according to the J1939 standard.</param>
        /// <param name="function">Represents a generic function within the vehicle according to the J1939 standard.</param>
        /// <param name="functionInstance">Represents an instance of a generic function within the vehicle accroding to the J1939 standard.</param>
        /// <param name="ecuInstance">Represents an instance of an ECU within the vehicle.</param>
        /// <param name="manufacturerCode">Represents the manufacturer product code of the ECU.  This is likely to indicate the model number of the ECU.</param>
        /// <param name="identityNumber">Represents the identity number of the ECU associated with the name.  This is likely to indicate the serial number of a device.</param>
        public CanName(bool selfConfigurable, ushort industryGroup, ushort vehicleSystemInstance, ushort vehicleSystem, ushort function, ushort functionInstance, ushort ecuInstance, Int16 manufacturerCode, int identityNumber)
        {
            SelfConfigurable = selfConfigurable;
            IndustryGroup = industryGroup;
            VehicleSystemInstance = vehicleSystemInstance;
            VehicleSystem = vehicleSystem;
            Function = function;
            FunctionInstance = functionInstance;
            EcuInstance = ecuInstance;
            ManufacturerCode = manufacturerCode;
            IdentityNumber = identityNumber;
        }

        /// <summary>
        /// Returns the NAME properties expressed as a byte array.
        /// </summary>
        /// <returns></returns>
        public byte[] DataToArray()
        {
            //Bytes 1-4
            string identityNumberBin = Convert.ToString(IdentityNumber, 2).PadLeft(21, '0');
            string mfgCodeBin = Convert.ToString(ManufacturerCode, 2).PadLeft(11, '0');
            byte[] bytes1 = BitConverter.GetBytes(Convert.ToUInt32(string.Concat(identityNumberBin, mfgCodeBin), 2));
            if (bytes1.Length != 4)
                throw new IndexOutOfRangeException("The aggregate of Identity Number and Manufacturer Code must equal exactly 4 bytes.");
            string hex = Convert.ToInt32(string.Concat(identityNumberBin, mfgCodeBin), 2).ToString("X").PadLeft(8, '0');

            //Byte 5
            string ecuInstanceBin = Convert.ToString(EcuInstance, 2).PadLeft(3, '0');
            string functionInstanceBin = Convert.ToString(FunctionInstance, 2).PadLeft(5, '0');
            byte[] bytes2 = BitConverter.GetBytes(Convert.ToByte(string.Concat(ecuInstanceBin, functionInstanceBin), 2));
            if (bytes2.Length != 2 | bytes2[1] != 0)
                throw new IndexOutOfRangeException("The aggregate of ECU Instance and Function Index must equal exactly 1 byte.");
            hex = string.Concat(hex, Convert.ToByte(string.Concat(ecuInstanceBin, functionInstanceBin), 2).ToString("X").PadLeft(2, '0'));

            //Byte 6
            string functionBin = Convert.ToString(Function, 2).PadLeft(8, '0');
            byte[] bytes3 = BitConverter.GetBytes(Convert.ToByte(functionBin, 2));
            if (bytes3.Length != 2 | bytes3[1] != 0)
                throw new IndexOutOfRangeException("Function must equal exactly 1 byte.");
            hex = string.Concat(hex, Convert.ToByte(functionBin, 2).ToString("X").PadLeft(2, '0'));

            //Byte 7
            string reservedBin = Convert.ToString(0);
            string vehicleSystemBin = Convert.ToString(VehicleSystem, 2).PadLeft(7, '0');
            byte[] bytes4 = BitConverter.GetBytes(Convert.ToByte(string.Concat(reservedBin, vehicleSystemBin), 2));
            if (bytes4.Length != 2 | bytes4[1] != 0)
                throw new IndexOutOfRangeException("The aggregate of Reserved and Vehicle System must equal exactly 1 byte.");
            hex = string.Concat(hex, Convert.ToByte(string.Concat(reservedBin, vehicleSystemBin), 2).ToString("X").PadLeft(2, '0'));

            //Byte 8
            string vehicleSystemInstanceBin = Convert.ToString(VehicleSystemInstance, 2).PadLeft(4, '0');
            string industryGroupBin = Convert.ToString(IndustryGroup, 2).PadLeft(3, '0');
            string selfConfigBin = Convert.ToString(Convert.ToInt32(SelfConfigurable));
            byte[] bytes5 = BitConverter.GetBytes(Convert.ToByte(string.Concat(vehicleSystemInstanceBin, industryGroupBin, selfConfigBin), 2));
            if (bytes5.Length != 2 | bytes5[1] != 0)
                throw new IndexOutOfRangeException("The aggregate of Vehicle System Instance, Industry Group and Self Configurable must equal exactly 1 byte.");
            hex = string.Concat(hex, Convert.ToInt32(string.Concat(vehicleSystemInstanceBin, industryGroupBin, selfConfigBin), 2).ToString("X").PadLeft(2, '0'));

            byte[] results = new byte[8];
            results[0] = bytes1[0];
            results[1] = bytes1[1];
            results[2] = bytes1[2];
            results[3] = bytes1[3];
            results[4] = bytes2[0];
            results[5] = bytes3[0];
            results[6] = bytes4[0];
            results[7] = bytes5[0];

            //Dispose of byte array.
            bytes1 = null;
            bytes2 = null;
            bytes3 = null;
            bytes4 = null;
            bytes5 = null;

            return results;
        }
    }
}
