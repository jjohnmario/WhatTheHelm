using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN:127489 Engine Parameters Dynamic
    /// </summary>
    public class Pgn0x1F201 : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN: 127489 Engine Parameters Dynamic";
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
                return 127489;
            }
        }

        public override Target Target => throw new NotImplementedException();

        /// <summary>
        /// Defines the engine that is producing the PGN data.  It is common that 0=Port engine, and 1=Stbd engine.
        /// </summary>
        public byte EngineInstance { get; private set; }

        /// <summary>
        /// Represents the engine oil pressure expressed in Pascals.
        /// </summary>
        public double OilPressure { get; private set; }

        /// <summary>
        /// Represents engine oil temperature expressed in Kelvin.
        /// </summary>
        public double OilTemperature { get; private set; }

        /// <summary>
        /// Represents engine temperature expressed in Kelvin.
        /// </summary>
        public double EngineTemperature { get; private set; }

        /// <summary>
        /// Represents engine alternator voltage expressed in volts.
        /// </summary>
        public double AlternatorPotential { get; private set; }

        /// <summary>
        /// Represents engine fuel flow rate expressed in cubic meters per hour.
        /// </summary>
        public double FuelRate { get; private set; }

        /// <summary>
        /// Represents engine runtime expressed in hours.
        /// </summary>
        public double EngineHours { get; private set; }

        /// <summary>
        /// Represents the engine coolant pressure expressed in Pascals * 100.
        /// </summary>
        public double CoolantPressure { get; private set; }

        /// <summary>
        /// Represents the engine coolant pressure expressed in Pascals * 1000.
        /// </summary>
        public double FuelPressure { get; private set; }

        /// <summary>
        /// Represent a set of binary engine signals such as high temperature sensor output.
        /// </summary>
        public ushort DiscreteStatus1 { get; private set; }

        /// <summary>
        /// Represent a set of binary engine signals such as high temperature sensor output.
        /// </summary>
        public ushort DiscreteStatus2 { get; private set; }
        
        /// <summary>
        /// Represents engine load expressed in percent.
        /// </summary>
        public short PercentEngineLoad { get; private set; }

        /// <summary>
        /// Represents engine tourque expressed in percent.
        /// </summary>
        public short PercentEngineTourque { get; private set; }


        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //Engine instance
            EngineInstance = data[0];

            //Oil Pressure
            OilPressure = BitConverter.ToUInt16(data, 1) * 100;

            //Oil Temperature
            OilTemperature = BitConverter.ToUInt16(data, 3) * 0.1;

            //Engine Temperature
            EngineTemperature = BitConverter.ToUInt16(data, 5) * 0.01;

            //Alternator Potential
            AlternatorPotential = BitConverter.ToInt16(data, 7) * 0.01;

            //Fuel rate
            FuelRate = BitConverter.ToInt16(data, 9) * 0.0001;

            //Engine Hours
            EngineHours = BitConverter.ToUInt32(data, 11) / 3600.0;

            //Coolant Pressure
            CoolantPressure = BitConverter.ToUInt16(data, 15) * 100;

            //Fuel Pressure
            FuelPressure = BitConverter.ToUInt16(data, 17) * 1000;

            //*Reserved Byte*

            //Discrete Status 1
            DiscreteStatus1 = BitConverter.ToUInt16(data, 20);

            //Discrete Status 2
            DiscreteStatus2 = BitConverter.ToUInt16(data, 22);

            //Percent Engine Load
            PercentEngineLoad = data[24];

            //Percent Engine Tourque
            PercentEngineTourque = data[25];

            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns Kelvin expressed in degrees Fahrenheit, Pascals in PSI, and flow in gallons/sec.
        /// </summary>
        /// <returns></returns>
        public override ParameterGroup ToImperial()
        {
            Pgn0x1F201 result = new Pgn0x1F201();
            result.EngineInstance = EngineInstance;
            result.OilPressure = OilPressure * 0.0001450377;
            result.OilTemperature = (OilTemperature - 273.15) * 1.8 + 32;
            result.EngineTemperature = (EngineTemperature - 273.15) * 1.8 + 32;
            result.AlternatorPotential = AlternatorPotential;
            result.FuelRate = FuelRate * 264.172;
            result.EngineHours = EngineHours;
            result.FuelPressure = FuelPressure * 0.0001450377;
            result.CoolantPressure = CoolantPressure * 0.0001450377;
            result.DiscreteStatus1 = DiscreteStatus1;
            result.DiscreteStatus2 = DiscreteStatus2;
            result.PercentEngineLoad = PercentEngineLoad;
            result.PercentEngineTourque = PercentEngineTourque;
            return result;
        }

        public override ParameterGroup ToMetric()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns string representations of scaled fields in comma-separated format.
        /// </summary>
        /// <returns>EngineInstance,OilPressure,OilTemperature,EngineTemperature,AlternatorPotential,FuelRate,EngineHours,FuelPressure,CoolantPressure,DiscreteStatus1,DiscreteStatus2,PercentEngineLoad,PercentEngineTorque</returns>
        public override string ToString()
        {
            
            return base.ToString();
        }
    }
}
