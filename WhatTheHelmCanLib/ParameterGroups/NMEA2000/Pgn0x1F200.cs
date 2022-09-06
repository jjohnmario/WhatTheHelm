using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.NMEA2000
{
    /// <summary>
    /// PGN:127488 Engine Parameters Rapid Update
    /// </summary>
    public class Pgn0x1F200 : ParameterGroup
    {
        public override string Description
        {
            get
            {
                return "PGN:127488 Engine Parameters Rapid Update";
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
                return 127488;
            }
        }

        public override Target Target
        {
            get
            {
                return Target.Broadcast;
            }
        }

        /// <summary>
        /// Defines the engine that is producing the PGN data.  It is common that 0=Port engine, and 1=Stbd engine.
        /// </summary>
        public byte EngineInstance { get; private set; }

        /// <summary>
        /// Represents engine speed in RPM * 0.25
        /// </summary>
        public ushort EngineSpeed { get; private set; }

        /// <summary>
        /// Represents engine turbo boost in Pascals * 100
        /// </summary>
        public ushort EngineBoostPressure { get; private set; }

        /// <summary>
        /// Engine trim in percent (0-100)
        /// </summary>
        public sbyte EngineTiltTrim { get; private set; }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            //Engine instance
            EngineInstance = data[0];

            //Engine speed
            EngineSpeed = BitConverter.ToUInt16(data, 1);

            //Engine turbo boost pressure
            EngineBoostPressure = BitConverter.ToUInt16(data, 3);

            //Engine trim
            EngineTiltTrim = (sbyte)data[5];

            //Bytes 6-7 reserved.

            return this;
        }

        public override byte[] SerializeFields()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns Pascals expressed in PSI.
        /// </summary>
        /// <returns></returns>
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
