using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.ParameterGroups.J1939
{
    /// <summary>
    /// Represents a J1939 parameter group.
    /// </summary>
    public abstract class J1939ParameterGroup : ParameterGroup
    {
        /// <summary>
        /// Represents the CAN address of the intended target node.  In many J1939 PGNs, this occupies the LSB of the PGN.
        /// </summary>
        public virtual byte DestinationAddress { get; set; }
    }
}
