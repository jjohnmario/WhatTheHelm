using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.NMEA2000
{
    public enum GnssType { GPS,GLONASS,GPS_AND_GLONASS,GPS_AND_SBAS_OR_WASS, GPS_AND_SBAS_OR_WASS_AND_GLONASS,CHAYKA,INTEGRATED,SURVEYED,GALILEO }
    public enum GnssMethod { NO_GNSS,GNSS_FIX,DGNSS_FIX,PRECISE_GNSS,RTK_FIXED_INTEGER,RTK_FLOAT,ESTIMATED_DR_MODE,MANUAL_INPUT,SIMULATE_MODE }
    public enum GnssIntegrity { NO_INTEGRITY_CHECKING,SAFE,CAUTION }
    /// <summary>
    /// PGN:129029 GNSS Position Data
    /// </summary>
    public class Pgn0x1F805 : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN:129029 GNSS Position Data";
            }
        }

        public override PgnType PgnType
        {
            get
            {
                return PgnType.NMEA2000;
            }
        }

        public override bool MultiFrame
        {
            get
            {
                return true;
            }
        }


        public override uint Pgn
        {
            get
            {
                return 129029;
            }
        }

        public override Target Target => throw new NotImplementedException();

        /// <summary>
        /// Sequence Indentifier
        /// </summary>
        public byte Sid { get; set; }
        /// <summary>
        /// Days since January 1, 1970
        /// </summary>
        public ushort Date { get; set; }
        /// <summary>
        /// Seconds since midnight as 1 x E-4
        /// </summary>
        public uint Time { get; set; }
        /// <summary>
        /// Latitude expressed as 1 x E-16
        /// </summary>
        public long Latitude { get; set; }
        /// <summary>
        /// Longitude expressed as 1 x E-16
        /// </summary>
        public long Longitude { get; set; }
        /// <summary>
        /// Altitude expressed as 1 x E-16
        /// </summary>
        public long Altitude { get; set; }
        /// <summary>
        /// GNSS Type
        /// </summary>
        public GnssType GnssType { get; set; }
        /// <summary>
        /// GNSS Method
        /// </summary>
        public GnssMethod GnssMethod { get; set; }
        /// <summary>
        /// Integrity
        /// </summary>
        public GnssIntegrity GnssIntegrity { get; set; }
        /// <summary>
        /// Number of satellites used in solution
        /// </summary>
        public byte NumberofSvs { get; set; }
        /// <summary>
        /// Horizontal dilution of precision
        /// </summary>
        public ushort Hdop { get; set; }
        /// <summary>
        /// Probable dilution of precision
        /// </summary>
        public ushort Pdop { get; set; }
        /// <summary>
        /// Geoidal Separation
        /// </summary>
        public ushort GeoidalSeparation { get; set; }
        /// <summary>
        /// Number of reference stations
        /// </summary>
        public byte ReferenceStations { get; set; }
        /// <summary>
        /// Reference Station Type
        /// </summary>
        public GnssType ReferenceStationType { get; set; }
        /// <summary>
        /// Reference Station ID
        /// </summary>
        public ushort ReferenceStationId { get; set; }
        /// <summary>
        /// Age of DGNSS Corrections
        /// </summary>
        public ushort AgeOfDgnssCorrections { get; set; }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            if (data.Length == 0)
                throw new FormatException("Data frame must be at least 1 byte.");

            //Seems some mfrs do not send the full 45 bytes of data, so using the bytes remaining computation, fill in the fields that are available.
            int bytesRemaining = data.Length;
            if(bytesRemaining >=1)
            {
                //SID  (1 byte)
                Sid = data[0];
            }
            bytesRemaining = bytesRemaining - 1;

            if(bytesRemaining >= 2)
            {
                //Date (2 bytes)
                Date = BitConverter.ToUInt16(data, 1);
            }
            bytesRemaining = bytesRemaining - 2;

            if(bytesRemaining >= 4)
            {
                //Time (4 bytes)
                Time = BitConverter.ToUInt32(data, 3);
            }
            bytesRemaining = bytesRemaining - 4;
            
            if (bytesRemaining >= 8)
            {
                //Latitude (8 bytes)
                Latitude = BitConverter.ToInt64(data, 7);
            }
            bytesRemaining = bytesRemaining - 8;

            if(bytesRemaining >=8)
            {
                //Longitude (8 bytes)
                Longitude = BitConverter.ToInt64(data, 15);
            }
            bytesRemaining = bytesRemaining - 8;

            if(bytesRemaining >= 8)
            {
                //Altitude (8 bytes)
                Altitude = BitConverter.ToInt64(data, 23);
            }
            bytesRemaining = bytesRemaining - 8;

            if(bytesRemaining >= 1)
            {
                //GNSS Type (4 bits)
                string byteToBin = Convert.ToString(data[31], 2).PadLeft(8, '0');
                GnssType = (GnssType)Convert.ToByte(byteToBin.Substring(0, 4), 2);

                //GNSS Method (4 bits)
                GnssMethod = (GnssMethod)Convert.ToByte(byteToBin.Substring(4, 4), 2);
            }
            bytesRemaining = bytesRemaining - 1;

            if(bytesRemaining >= 1)
            {
                //Integrity (2 bits)
                string byteToBin = Convert.ToString(data[32], 2).PadLeft(8, '0');
                GnssIntegrity = (GnssIntegrity)Convert.ToByte(byteToBin.Substring(6, 2), 2);

                //Reserved (6 bits)
            }
            bytesRemaining = bytesRemaining - 1;

            if(bytesRemaining >= 1)
            {
                //Number of SVs (1 byte)
                NumberofSvs = data[33];
            }
            bytesRemaining = bytesRemaining - 1;

            if(bytesRemaining >= 2)
            {
                //HDOP (2 bytes)
                Hdop = BitConverter.ToUInt16(data, 34);
            }
            bytesRemaining = bytesRemaining - 2;

            if(bytesRemaining >= 2)
            {
                //HDOP (2 bytes)
                Hdop = BitConverter.ToUInt16(data, 34);
            }
            bytesRemaining = bytesRemaining - 2;

            if (bytesRemaining >= 2)
            {
                //PDOP (2 bytes)
                Pdop = BitConverter.ToUInt16(data, 36);
            }
            bytesRemaining = bytesRemaining - 2;

            if (bytesRemaining >= 2)
            {
                //Geoidal Separation (2 bytes)
                GeoidalSeparation = BitConverter.ToUInt16(data, 38);
            }
            bytesRemaining = bytesRemaining - 2;

            if(bytesRemaining >=1)
            {
                //Reference Stations (1 byte)
                ReferenceStations = data[40];
            }
            bytesRemaining = bytesRemaining - 1;

            if(bytesRemaining >=1)
            {
                //Reference Station Type (4 bits)
                string byteToBin = Convert.ToString(data[41], 2).PadLeft(8, '0');
                ReferenceStationId = Convert.ToByte(byteToBin.Substring(0, 4), 2);

                //Reference Station ID (12 bits)
                string byteToBin2 = Convert.ToString(data[42], 2).PadLeft(8, '0');
                string concat = string.Concat(byteToBin.Substring(4, 4), byteToBin2);
                ReferenceStationId = Convert.ToUInt16(concat);
            }
            bytesRemaining = bytesRemaining - 1;

            if(bytesRemaining >=2)
            {
                //Age of DGNSS Corrections (2 bytes)
                AgeOfDgnssCorrections = BitConverter.ToUInt16(data, 43);
            }
            return this;
        }

        public override byte[] SerializeFields()
        {
            return null;
        }

        public override ParameterGroup ToImperial()
        {
            return this;
        }

        public override ParameterGroup ToMetric()
        {
            return this;
        }

        /// <summary>
        /// Returns an comma-separated string with latitude at position 0, longitude at position 1 and altitude at position 2.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Concat(Convert.ToDouble(Latitude / 10000000000000000.0).ToString("##.####"), ",", Convert.ToDouble(Longitude / 10000000000000000.0).ToString("##.####"), ",", Convert.ToDouble(Altitude / 1000000.0).ToString("##.####"));
        }
    }
}
