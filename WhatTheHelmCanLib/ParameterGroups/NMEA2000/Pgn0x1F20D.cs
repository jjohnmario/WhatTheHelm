using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.NMEA2000
{
    public enum IndicatorBankStatus { Off=0, On=1, Error=2, Undefined=3 }
    /// <summary>
    /// PGN: 127501 Binary Switch Bank Status
    /// </summary>
    public class Pgn0x1F20D : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN: 127501 Binary Switch Bank Status";
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
                return 127501;
            }
        }

        /// <summary>
        /// Represents an instance of the indicator bank being measured.
        /// </summary>
        public byte IndicatorBankInstance { get; private set; }

        private IndicatorBankStatus[] _IndicatorBankStatus;
        /// <summary>
        /// Represents the state of the instance of the indicator bank being measured.
        /// </summary>
        public IndicatorBankStatus[] IndicatorBankStatus
        { 
            get
            {
                if(_IndicatorBankStatus == null)
                    _IndicatorBankStatus = new IndicatorBankStatus[16];
                return _IndicatorBankStatus;
            }
            set
            {
                _IndicatorBankStatus = value;
            }
        }

        public override Target Target => throw new NotImplementedException();

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //Instance
            IndicatorBankInstance = data[0];

            //Indicator Bank Statuses
            string byte1ToBin = Convert.ToString(data[1], 2).PadLeft(8, '0');
            IndicatorBankStatus[0] = (IndicatorBankStatus)Convert.ToByte(byte1ToBin.Substring(0, 2), 2);
            IndicatorBankStatus[1] = (IndicatorBankStatus)Convert.ToByte(byte1ToBin.Substring(2, 2), 2);
            IndicatorBankStatus[2] = (IndicatorBankStatus)Convert.ToByte(byte1ToBin.Substring(4, 2), 2);
            IndicatorBankStatus[3] = (IndicatorBankStatus)Convert.ToByte(byte1ToBin.Substring(6, 2), 2);

            string byte2ToBin = Convert.ToString(data[2], 2).PadLeft(8, '0');
            IndicatorBankStatus[4] = (IndicatorBankStatus)Convert.ToByte(byte2ToBin.Substring(0, 2), 2);
            IndicatorBankStatus[5] = (IndicatorBankStatus)Convert.ToByte(byte2ToBin.Substring(2, 2), 2);
            IndicatorBankStatus[6] = (IndicatorBankStatus)Convert.ToByte(byte2ToBin.Substring(4, 2), 2);
            IndicatorBankStatus[7] = (IndicatorBankStatus)Convert.ToByte(byte2ToBin.Substring(6, 2), 2);

            string byte3ToBin = Convert.ToString(data[3], 2).PadLeft(8, '0');
            IndicatorBankStatus[8] = (IndicatorBankStatus)Convert.ToByte(byte3ToBin.Substring(0, 2), 2);
            IndicatorBankStatus[9] = (IndicatorBankStatus)Convert.ToByte(byte3ToBin.Substring(2, 2), 2);
            IndicatorBankStatus[10] = (IndicatorBankStatus)Convert.ToByte(byte3ToBin.Substring(4, 2), 2);
            IndicatorBankStatus[11] = (IndicatorBankStatus)Convert.ToByte(byte3ToBin.Substring(6, 2), 2);

            string byte4ToBin = Convert.ToString(data[4], 2).PadLeft(8, '0');
            IndicatorBankStatus[12] = (IndicatorBankStatus)Convert.ToByte(byte4ToBin.Substring(0, 2), 2);
            IndicatorBankStatus[13] = (IndicatorBankStatus)Convert.ToByte(byte4ToBin.Substring(2, 2), 2);
            IndicatorBankStatus[14] = (IndicatorBankStatus)Convert.ToByte(byte4ToBin.Substring(4, 2), 2);
            IndicatorBankStatus[15] = (IndicatorBankStatus)Convert.ToByte(byte4ToBin.Substring(6, 2), 2);

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
