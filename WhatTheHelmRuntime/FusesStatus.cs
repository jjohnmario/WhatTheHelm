using BoatFormsLib;
using WhatTheHelmCanLib.Messages;
using WhatTheHelmCanLib.ParameterGroups;
using WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec;
using WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.MVec;
using WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryB.CooperBussman.Mvec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatTheHelmRuntime
{
    public partial class FusesStatus : Form
    {
        /// <summary>
        /// One or more fuses have reported a fault.
        /// </summary>
        public event EventHandler FuseFaulted;
        /// <summary>
        /// All fuses are clear of faults.
        /// </summary>
        public event EventHandler FuseFaultCleared;
        public FusesStatus()
        {
            InitializeComponent();
            this.MinimumSize = new Size() { Height = 480, Width = 800 };
            this.MaximumSize = new Size() { Height = 480, Width = 800 };

            //Subscribe to CAN messages
            Program.CanGateway.MessageRecieved += CanGateWay_MessageRecieved;
        }

        private void CanGateWay_MessageRecieved(object sender, CanMessageArgs e)
        {
            //Set DashboardButton fuse status
            if (e.Message.Pgn == 65440)
            {
                Pgn0x0FFA0 pgn = (Pgn0x0FFA0)ParameterGroup.GetPgnType(65440).DeserializeFields(e.Message.Data);
                      
                foreach (Control c in this.Controls)
                {
                    if(c.GetType() == typeof(Panel))
                    {
                        foreach(Control child in c.Controls)
                        {
                            if (child.GetType() == typeof(Fuse) && c.IsHandleCreated)
                            {
                                var control = (Fuse)child;
                                control.UpdateFuseStatus((byte)e.Message.SourceAddress, pgn.GridAddress, pgn.FuseStatus);
                            }                        
                        }                     
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Fuse_Faulted(object sender, EventArgs e)
        {
            if (FuseFaulted != null)
                FuseFaulted.Invoke(sender, e);
        }

        private void Fuse_FaultCleared(object sender, EventArgs e)
        {
            if (FuseFaultCleared != null)
                FuseFaultCleared.Invoke(sender, e);
        }
    }
}
