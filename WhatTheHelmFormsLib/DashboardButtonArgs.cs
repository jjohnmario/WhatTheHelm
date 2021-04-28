using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanLib;
using CanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec;

namespace BoatFormsLib
{
    public class DashboardButtonArgs : EventArgs
    {
        public byte MvecAddress { get; set; }
        public byte MvecGrid { get; set; }
        public byte MvecRelayNumber { get; set; }
        public RelayCommandState RelayCommandState { get; set; }
    }
}
