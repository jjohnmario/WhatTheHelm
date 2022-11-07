using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN:127508 Battery Status
    /// </summary>
    public class Pgn0x1F214 : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN:127508 Battery Status";

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
                return 127508;
            }
        }

        public override Target Target => throw new NotImplementedException();

        /// <summary>
        /// Represents the battery instance.  Typically 0 = port, 1 = stbd.
        /// </summary>
        public byte BatteryInstance { get; private set; }

        /// <summary>
        /// Represents the voltage measurement of the battery instance in volts * 0.01.
        /// </summary>
        public double Voltage { get; private set; }

        /// <summary>
        /// Represents the current measurement of the battery instance in amperes * 0.01.
        /// </summary>
        public double Current { get; private set; }

        /// <summary>
        /// Represents the temperature of the battery instance in Kelvin * 0.01
        /// </summary>
        public double Temperature { get; private set; }

        /// <summary>
        /// Sequence Identifier (optional)
        /// </summary>
        public byte Sid { get; private set; }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //Battery Instance
            BatteryInstance = data[0];

            //Voltage
            Voltage = BitConverter.ToUInt16(data, 1) * 0.01;

            //Current
            Current = BitConverter.ToUInt16(data, 3) * 0.01;

            //Temperature
            Temperature = BitConverter.ToUInt16(data, 5) * 0.01;

            //SID (Optional)
            if (data.Length > 7)
                Sid = data[7];

            return this;

        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns Kelvin expressed in degrees Fahrenheit.
        /// </summary>
        /// <returns></returns>
        public override ParameterGroup ToImperial()
        {
            Pgn0x1F214 result = new Pgn0x1F214();
            result.BatteryInstance = BatteryInstance;
            result.Voltage = Voltage;
            result.Current = Current;
            result.Temperature = (ushort)((Temperature - 273.15) * ((9 / 5) + 32));
            result.Sid = Sid;
            return result;
        }

        public override ParameterGroup ToMetric()
        {
            return this;
        }
    }
}
