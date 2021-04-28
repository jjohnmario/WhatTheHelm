using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.NMEA2000
{
    public enum TemperatureSourceExtended { Sea_Temperature , Outside_Temperature ,Inside_Temperature, Engine_Room_Temperature, Main_Cabin_Temperature, Live_Well_Temperature, Bait_Well_Temperature , Refridgeration_Temperature , Heating_System_Temperature , Dew_Point_Temperature , Wind_Chill_Temperature_Apparent, Wind_Chill_Temperature_Theoretical, Heat_Index_Temperature, Freezer_Temperature, Exhaust_Gas_Temperature }
    /// <summary>
    /// PGN:130316 Temperature Extended Range
    /// </summary>
    public class Pgn0x1FD0C : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN:130316 Temperature Extended Range";
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
                return 130316;
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
        /// Represents the actual temperature of the instance expressed in Kelvin * 0.001.
        /// </summary>
        public uint ActualTemperature { get; private set; }

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
            byte[] temp = new byte[] { 0, data[3], data[4], data[5] };           
            ActualTemperature = BitConverter.ToUInt32(temp, 0);

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
            Pgn0x1FD0C result = new Pgn0x1FD0C();
            result.Sid = Sid;
            result.TemperatureInstance = TemperatureInstance;
            result.TemperatureSource = TemperatureSource;
            result.SetTemperature = (ushort)((SetTemperature - 273.15) * ((9 / 5) + 32));
            result.ActualTemperature = (uint)((ActualTemperature - 273.15) * ((9 / 5) + 32));
            return result;
        }

        public override ParameterGroup ToMetric()
        {
            return this;
        }
    }
}
