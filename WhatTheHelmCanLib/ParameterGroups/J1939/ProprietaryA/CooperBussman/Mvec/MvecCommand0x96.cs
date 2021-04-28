using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec
{
    /// <summary>
    /// Creates an object reference to a command view the startup delay time, default and current state of the relays within a grid of an MVEC module.
    /// </summary>
    public class MvecCommand0x96 : MvecCommand
    {
        public override CommandMessage Command
        {
            get
            {
                return CommandMessage.hex96;
            }
        }

        /// <summary>
        /// Represents the address of the grid to examine.
        /// </summary>
        public byte GridAddress { get; private set; }

        /// <summary>
        /// Creates an object reference to a command view the startup delay time, default and current state of the relays within a grid of an MVEC module using a defined grid address.
        /// </summary>
        /// <param name="gridAddress"></param>
        public MvecCommand0x96(byte gridAddress)
        {
            GridAddress = gridAddress;
        }
        
        public override byte[] SerializeFields()
        {
            return new byte[] { 0x96, GridAddress };
        }
    }
}
