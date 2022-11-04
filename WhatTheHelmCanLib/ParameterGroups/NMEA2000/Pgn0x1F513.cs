using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN:128275 Distance Log
    /// </summary>
    public class Pgn0x1F513 : Nmea2000ParameterGroup
    {
        public override uint Pgn
        {
            get
            {
                return 128275;
            }
        }
        public override string Description
        {
            get
            {
                if (UomSystem == UomSystem.Metric)
                    return "Distance traveled in Meters";
                else
                    return "Distance traveled in Feet";
            }
        }
        /// <summary>
        /// First packet identifier
        /// </summary>
        public int Pid { get; private set; }
        /// <summary>
        /// Total cumulative distance
        /// </summary>
        public int Log { get; private set; }
        /// <summary>
        /// Total distance since last reset
        /// </summary>
        public int TripLog { get; private set; }
        /// <summary>
        /// Days since January 1, 1970
        /// </summary>
        public Int16 Date { get; private set; }
        /// <summary>
        /// Seconds since midnight
        /// </summary>
        public Double Time { get; private set; }
        public UomSystem UomSystem { get; private set; }

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

        public override Target Target
        {
            get
            {
                return Target.Broadcast;
            }
        }

        public Pgn0x1F513()
        {

        }

        public Pgn0x1F513(int pid, int log, int tripLog, Int16 date, double time)
        {
            Pid = pid;
            Log = log;
            TripLog = tripLog;
            Date = date;
            Time = time;
        }

        public Pgn0x1F513(int pid, int log, int tripLog, Int16 date, double time, UomSystem uomSystem)
        {
            Pid = pid;
            Log = log;
            TripLog = tripLog;
            Date = date;
            Time = time;
            UomSystem = uomSystem;
        }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            if (data.Length != 14)
                throw new FormatException("Data frame must be exactly 14 bytes.");
            else
            {
                //PID
                Pid = -1;

                //Date
                byte[] dateByteArray = new byte[2];
                Array.Copy(data, 0, dateByteArray, 0, 2);
                Date = BitConverter.ToInt16(dateByteArray, 0);
                dateByteArray = null;

                //Time
                byte[] timeByteArray = new byte[4];
                Array.Copy(data, 2, timeByteArray, 0, 4);
                Time = BitConverter.ToSingle(timeByteArray, 0) * 0.0001;
                timeByteArray = null;

                //Log
                byte[] logByteArray = new byte[4];
                Array.Copy(data, 6, logByteArray, 0, 4);
                Log = BitConverter.ToInt32(logByteArray, 0);
                logByteArray = null;

                //Trip Log
                byte[] tripLogByteArray = new byte[4];
                Array.Copy(data, 10, tripLogByteArray, 0, 3);
                Array.Copy(data, 13, tripLogByteArray, 3, 1);
                TripLog = BitConverter.ToInt32(tripLogByteArray, 0);
                tripLogByteArray = null;
            }
            return this;
        }

        public override ParameterGroup ToImperial()
        {
            return new Pgn0x1F513(Pid, (Log * 3), (TripLog * 3), Date, Time, UomSystem.Imperial);
        }

        public override ParameterGroup ToMetric()
        {
            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }
    }
}
