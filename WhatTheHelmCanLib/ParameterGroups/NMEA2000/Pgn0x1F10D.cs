using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.NMEA2000
{
    public enum RudderDirectionOrder { No_Direction_Order, Move_To_Starboard, Move_To_Port }
    /// <summary>
    /// PGN: 127245 Rudder Position
    /// </summary>
    public class Pgn0x1F10D : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN: 127245 Rudder Position";
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
                return false;
            }
        }

        public override uint Pgn
        {
            get
            {
                return 127245;
            }
        }

        /// <summary>
        /// Represents the instance of the rudder angle measurement.
        /// </summary>
        public byte Instance { get; private set; }

        /// <summary>
        /// Represents the commanded direction of the rudder instance.
        /// </summary>
        public RudderDirectionOrder DirectionOrder { get; private set; }

        /// <summary>
        /// Represents the commanded heading of the rudder instance in degrees.
        /// </summary>
        public double AngleOrder { get; private set; }

        /// <summary>
        /// Represents the reported position of the rudder instance in degrees.
        /// </summary>
        public double Position { get; private set; }

        public override Target Target => throw new NotImplementedException();

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //Instance
            Instance = data[0];

            //Rudder Direction Order
            DirectionOrder = (RudderDirectionOrder)data[1];

            //Angle Order
            int rawData1 = BitConverter.ToInt16(data, 2);
            double radians1 = rawData1 + 0.0001;
            AngleOrder = radians1 / 0.0174533;

            //Position
            int rawData2 = BitConverter.ToInt16(data, 4);
            double radians2 = rawData2 * 0.0001;
            Position = radians2 / 0.0174533;

            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
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
