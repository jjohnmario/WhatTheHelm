using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN:130312 Temperature
    /// </summary>
    public class Pgn0x1FD08 : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN:130312 Temperature";
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
                return 130312;
            }
        }
        /// <summary>
        /// Sequence Identifier
        /// </summary>
        public byte Sid { get; private set; }

        /// <summary>
        /// Represents the temperature instance.
        /// </summary>
        public byte TemperatureInstance { get; private set; }

        /// <summary>
        /// Represents the source of the temperature instance.
        /// </summary>
        public TemperatureSourceExtended TemperatureSource { get; private set; }

        /// <summary>
        /// Represents the actual temperature of the instance expressed in Kelvin * 0.1.
        /// </summary>
        public ushort ActualTemperature { get; private set; }

        /// <summary>
        /// Represents the temperatures setpoint of the instance expressed in Kelvin * 0.1.
        /// </summary>
        public ushort SetTemperature { get; private set; }

        public override Target Target => throw new NotImplementedException();

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //SID
            Sid = data[0];

            //Temperature Instance
            TemperatureInstance = data[1];

            //Temperature Source
            TemperatureSource = (TemperatureSourceExtended)data[2];

            //Actual Temperature
            ActualTemperature = BitConverter.ToUInt16(data, 3);

            //Set Temperature 
            SetTemperature = BitConverter.ToUInt16(data, 5);

            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }

        public override ParameterGroup ToImperial()
        {
            Pgn0x1FD08 result = new Pgn0x1FD08();
            result.Sid = Sid;
            result.TemperatureInstance = TemperatureInstance;
            result.TemperatureSource = TemperatureSource;
            result.SetTemperature = (ushort)((SetTemperature - 273.15) * ((9 / 5) + 32));
            result.ActualTemperature = (ushort)((ActualTemperature - 273.15) * ((9 / 5) + 32));
            return result;
        }

        public override ParameterGroup ToMetric()
        {
            return this;
        }
    }
}
