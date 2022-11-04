using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec
{
    /// <summary>
    /// Creates an object reference to a command to return the MVEC software version number.
    /// </summary>
    public class MvecCommand0x12 : MvecCommand
    {
        public override CommandMessage Command
        {
            get
            {
                return CommandMessage.hex12;
            }
        }

        public override byte[] SerializeFields()
        {
            return new byte[] { 0x12 };
        }
    }
}
