using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatTheHelmRuntime.NMEA0183.Sentences
{
    public class GPRMC : Nmea0183Sentence
    {
        public override string Description
        {
            get
            {
                return "Position, Velocity and Time";
            }
        }
        public override string SentenceId
        {
            get
            {
                return "GPRMC";
            }
        }
        /// <summary>
        /// UTC of position fix
        /// </summary>
        public decimal UtcPositionFix { get; private set; }

        /// <summary>
        /// Status A=active or V=void
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public string Latitude { get; private set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public string Longitude { get; private set; }

        /// <summary>
        /// Speed over ground in knots
        /// </summary>
        public decimal Sog { get; private set; }

        /// <summary>
        /// Track angle in degrees (True)
        /// </summary>
        public decimal TrackAngle { get; private set; }

        /// <summary>
        /// Date
        /// </summary>
        public long Date { get; private set; }

        /// <summary>
        /// Magnetic variation in degrees
        /// </summary>
        public int MagneticVariation { get; private set; }

        /// <summary>
        /// The checksum data, always begins with *
        /// </summary>
        public string Checksum { get; private set; }

        public override Nmea0183Sentence DeserializeFields(string data)
        {
            string[] fields = data.Split(',');
            if (fields.Length != 13)
                return null;
            if(!String.IsNullOrEmpty(fields[1]))
                UtcPositionFix = Convert.ToDecimal(fields[1]);
            if (!String.IsNullOrEmpty(fields[2]))
                Status = fields[2];
            if (!String.IsNullOrEmpty(fields[3]))
                Latitude = String.Concat(fields[3], fields[4]);
            if (!String.IsNullOrEmpty(fields[5]))
                Longitude = String.Concat(fields[5], fields[6]);
            if (!String.IsNullOrEmpty(fields[7]))
                Sog = Convert.ToDecimal(fields[7]);
            if (!String.IsNullOrEmpty(fields[8]))
                TrackAngle = Convert.ToDecimal(fields[8]);
            if (!String.IsNullOrEmpty(fields[9]))
                Date = Convert.ToInt64(fields[9]);
            if (!String.IsNullOrEmpty(fields[10]))
                MagneticVariation = Convert.ToInt32(fields[10]);
            if (!String.IsNullOrEmpty(fields[11]))
                Checksum = fields[11];
            return this;
        }

        public override string[] SerializeFields()
        {
            throw new NotImplementedException();
        }

        public override Nmea0183Sentence ToImperial()
        {
            return this;
        }

        public override Nmea0183Sentence ToMetric()
        {
            return this;
        }
    }
}
