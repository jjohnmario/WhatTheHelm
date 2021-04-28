using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.NMEA2000
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

        public override int Pgn
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
        /// Represents the actual heading of the rudder instance in degrees.
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
            AngleOrder = BitConverter.ToInt16(data, 2) * 0.0057295779513082332;

            //Position
            Position = BitConverter.ToInt16(data, 4) * 0.0057295779513082332;

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
