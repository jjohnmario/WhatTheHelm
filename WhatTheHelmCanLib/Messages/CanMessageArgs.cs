using System;
using System.Collections.Generic;
using System.Text;

namespace CanLib.Messages
{
    public class CanMessageArgs : EventArgs
    {
        public CanMessage Message { get; set; }
    }
}
