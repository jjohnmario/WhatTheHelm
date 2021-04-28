using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.NMEA2000
{
    public enum TransmissionGear { Forward, Neutral, Reverse, Unknown }
    /// <summary>
    /// PGN:127493 Transmission Parameters
    /// </summary>
    public class Pgn0x1F205 : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN:127493 Transmission Parameters";
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
                return 127493;
            }
        }

        public override Target Target => throw new NotImplementedException();


        /// <summary>
        /// Defines the engine that is producing the PGN data.  It is common that 0=Port engine, and 1=Stbd engine.
        /// </summary>
        public byte EngineInstance { get; private set; }

        /// <summary>
        /// Represents the transmission gear selected.
        /// </summary>
        public TransmissionGear TransmissionGear { get; private set; }

        /// <summary>
        /// Represents the transmission oil pressure expressed in Pascals * 100.
        /// </summary>
        public double OilPressure { get; private set; }

        /// <summary>
        /// Represents transmission oil temperature expressed in Kelvin * 0.1.
        /// </summary>
        public double OilTemperature { get; private set; }

        /// <summary>
        /// Represent a set of binary engine signals such as high temperature sensor output.
        /// </summary>
        public byte DiscreteStatus1 { get; set; }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //Engine instance
            EngineInstance = data[0];

            //Transmission Gear
            TransmissionGear = (TransmissionGear)data[1];

            //Oil Pressure
            OilPressure = BitConverter.ToUInt16(data, 2) * 100;

            //Oil Temperature
            OilTemperature = BitConverter.ToUInt16(data, 3) * 0.01; 

            //Discrete Status 1
            DiscreteStatus1 = data[4];

            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }

        public override ParameterGroup ToImperial()
        {
            Pgn0x1F205 result = new Pgn0x1F205();
            result.EngineInstance = EngineInstance;
            result.TransmissionGear = TransmissionGear;
            result.OilPressure = OilPressure * 0.0001450377;
            result.OilTemperature = (OilTemperature - 273.15) * 1.8 + 32;
            result.DiscreteStatus1 = DiscreteStatus1;
            return result;
        }

        public override ParameterGroup ToMetric()
        {
            throw new NotImplementedException();
        }
    }
}
