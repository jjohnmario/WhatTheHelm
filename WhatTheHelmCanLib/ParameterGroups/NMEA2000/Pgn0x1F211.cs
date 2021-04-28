using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.NMEA2000
{ 
    public enum FluidLevelType { Fuel, Water, Gray_Water, Live_Well, Oil, Black_Water }
    /// <summary>
     /// PGN:127505 Fluid Level
     /// </summary>
    public class Pgn0x1F211 : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN:127505 Fluid Level";
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
                return 127505;
            }
        }

        public override Target Target => throw new NotImplementedException();

        /// <summary>
        /// Represents the fluid level instance.
        /// </summary>
        public byte Instance { get; private set; }

        /// <summary>
        /// Represents the fluid type of the fluid level instance.
        /// </summary>
        public FluidLevelType FluidLevelType { get; private set; }

        /// <summary>
        /// Represents the level of the fluid level instance expressed in percent x 0.004
        /// </summary>
        public ushort FluidLevel { get; private set; }

        /// <summary>
        /// Represents the capacity of the fluid level instance expressed in Liters * 0.1
        /// </summary>
        public ushort FluidCapacity { get; private set; }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //Instance
            Instance = data[0];

            //Fluid Level Type
            FluidLevelType = (FluidLevelType)data[1];

            //Fluid Level
            FluidLevel = BitConverter.ToUInt16(data, 2);

            //Fluid Capacity
            FluidCapacity = BitConverter.ToUInt16(data, 4);

            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns Liters expressed in gallons.
        /// </summary>
        /// <returns></returns>
        public override ParameterGroup ToImperial()
        {
            Pgn0x1F211 result = new Pgn0x1F211();
            result.Instance = Instance;
            result.FluidLevelType = FluidLevelType;
            result.FluidLevel = FluidLevel;
            result.FluidCapacity = (ushort)(FluidCapacity * 0.264172);
            return result;
        }

        public override ParameterGroup ToMetric()
        {
            throw new NotImplementedException();
        }
    }
}
