﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.Devices.J1939.CooperBussman
{
    public class MVec : CanDevice
    {
        public MVec(ushort address, CanName name) : base(address,name)
        {

        }
    }
}
