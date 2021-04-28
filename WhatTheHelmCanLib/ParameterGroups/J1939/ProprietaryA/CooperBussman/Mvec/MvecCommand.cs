using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec
{
    /// <summary>
    /// Represents an enumeration of commands compatible with MVEC modules.
    /// </summary>
    public enum CommandMessage
    {
        /// <summary>
        /// View software version number
        /// </summary>
        hex12 = 0x12, 
        /// <summary>
        /// Change state of relays or high-side drive (if installed) - no reply from MVEC
        /// </summary>
        hex80 = 0x80,
        /// <summary>
        /// Change state of relays or high-side drive (if installed) - 0x01 reply from MVEC
        /// </summary>
        hex88 = 0x88, 
        /// <summary>
        /// Set CAN source address base value and PGN base value
        /// </summary>
        hex90 = 0x90, 
        /// <summary>
        /// View population table
        /// </summary>
        hex92 = 0x92, 
        /// <summary>
        /// Change population table settings
        /// </summary>
        hex94 = 0x94, 
        /// <summary>
        /// Change default relay states
        /// </summary>
        hex95 = 0x95, 
        /// <summary>
        /// View start-up delay time, default relay states and current relay states
        /// </summary>
        hex96 = 0x96, 
        /// <summary>
        /// View mapping board configuration, CAN source address offset, CAN source address base, PGN base value, CAN message count threshold, CAN timeout source address
        /// </summary>
        hex97 = 0x97, 
        /// <summary>
        /// Change CAN message count threshold
        /// </summary>
        hex98 = 0x98, 
        /// <summary>
        /// Set startup delay time
        /// </summary>
        hex99 = 0x99
    }



    /// <summary>
    /// Represents a command sent to an MVEC module using PGN 0x0EF00.
    /// </summary>
    public abstract class MvecCommand
    {
        /// <summary>
        /// Represents the type of command.
        /// </summary>
        public abstract CommandMessage Command { get; }

        /// <summary>
        /// Serializes MVEC command fields into a byte array.
        /// </summary>
        /// <returns></returns>
        public abstract byte[] SerializeFields();
    }
}
