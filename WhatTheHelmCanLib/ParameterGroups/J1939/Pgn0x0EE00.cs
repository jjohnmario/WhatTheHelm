using CanLib.Devices;
using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.J1939
{
    /// <summary>
    /// PGN: 060928 (0x0EE00) Address Claimed Message
    /// </summary>
    public class Pgn0x0EE00 : J1939ParameterGroup
    {
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
                if (Target == Target.Broadcast)
                    return 0x0EEFF;
                else
                    return 0x0EE00;
            }
        }
        public override PgnType PgnType
        {
            get
            {
                return PgnType.J3919;
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
        /// The NAME information for the claimer.
        /// </summary>
        public CanName Name { get; set; }

        public override string Description
        {
            get
            {
                return "PGN: 060928(0x00EE00) Address Claimed Message";
            }
        }

        /// <summary>
        /// Creates an object reference to PGN: 060928 (0x00EE00) Address Claimed Message
        /// </summary>
        public Pgn0x0EE00()
        {
            
        }

        /// <summary>
        /// Creates an object reference to PGN: 060928 (0x00EE00) Address Claimed Message and adds NAME information for the claimer.
        /// </summary>
        /// <param name="name">The NAME information for the claimer.</param>
        public Pgn0x0EE00(CanName name)
        {
            Name = name;
        }

        public override byte[] SerializeFields()
        {
            byte[] bytes = new byte[8];
            return bytes;
        }

        public override ParameterGroup DeserializeFields(byte[] data)
        {
            throw new NotImplementedException();
        }

        public override ParameterGroup ToImperial()
        {
            throw new NotImplementedException();
        }

        public override ParameterGroup ToMetric()
        {
            throw new NotImplementedException();
        }


    }
}
