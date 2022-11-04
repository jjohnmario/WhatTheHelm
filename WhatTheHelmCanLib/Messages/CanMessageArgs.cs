using System;
using System.Collections.Generic;
using System.Text;

namespace WhatTheHelmCanLib.Messages
{
    public class CanMessageArgs : EventArgs
    {
        public CanMessage Message { get; set; }
    }
}
