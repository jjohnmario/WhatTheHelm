using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN:127497 Trip Parameters, Engine
    /// </summary>
    public class Pgn0x1F209 : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN:127497 Trip Parameters, Engine";
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
                return 127497;
            }
        }
        /// <summary>
        /// Defines the engine that is producing the PGN data.  It is common that 0=Port engine, and 1=Stbd engine.
        /// </summary>
        public byte EngineInstance { get; private set; }

        /// <summary>
        /// Represents the trip fuel totalizer expressed in liters.
        /// </summary>
        public ushort TripFuelUsed { get; private set; }

        /// <summary>
        /// Represents the fuel used expressed in liters per hour * 0.1.
        /// </summary>
        public ushort FuelUsedAvg { get; private set; }

        /// <summary>
        /// Represents the average fuel economy expressed in liters per kilometer * 0.1.
        /// </summary>
        public ushort FuelRateEconomy { get; private set; }

        /// <summary>
        /// Represents the instant fuel economy expressed in liters per kilometer * 0.1.
        /// </summary>
        public ushort FuelRateEconomyInstant { get; private set; }

        public override Target Target => throw new NotImplementedException();

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //Engine Instance
            EngineInstance = data[0];

            //Trip Fuel Used
            TripFuelUsed = BitConverter.ToUInt16(data, 1);

            //Fuel Used Average
            FuelUsedAvg = BitConverter.ToUInt16(data, 3);

            //Fuel Rate Economy        
            FuelRateEconomy = BitConverter.ToUInt16(data, 5);

            //Fuel Rate Economy Instant
            FuelRateEconomyInstant = BitConverter.ToUInt16(data, 7);

            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }

        public override ParameterGroup ToImperial()
        {
            Pgn0x1F209 result = new Pgn0x1F209();
            result.EngineInstance = EngineInstance;
            result.TripFuelUsed = (ushort)(TripFuelUsed * 3.785411784);
            result.FuelUsedAvg = (ushort)(FuelUsedAvg * 3.785411784);
            result.FuelRateEconomy = (ushort)(FuelRateEconomy* 3.785411784); ;
            result.FuelRateEconomyInstant = (ushort)(FuelRateEconomyInstant * 3.785411784); ;
            return result;
        }

        public override ParameterGroup ToMetric()
        {
            return this;
        }
    }
}
