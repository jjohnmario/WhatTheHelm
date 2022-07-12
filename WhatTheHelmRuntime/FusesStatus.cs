using BoatFormsLib;
using CanLib.Messages;
using CanLib.ParameterGroups;
using CanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec;
using CanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.MVec;
using CanLib.ParameterGroups.J1939.ProprietaryB.CooperBussman.Mvec;
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
            Program.CanGateWayListener.NewMessage += CanGateWayListener_NewMessage;

            //Perform intial scan of relay states of MVEC-1
            MvecCommand0x96 cmd1 = new MvecCommand0x96(0);
            Pgn0x0EF00 pgn1 = new Pgn0x0EF00(cmd1, 176);
            CanMessage msg1 = new CanMessage(pgn1.Pgn, Format.EXTENDED, 6, Program.CanRequestHandler.CanGateway.Address, pgn1.SerializeFields());
            Program.CanRequestHandler.QueueOutgoingMessage(msg1);
            //Perform intial scan of relay states of MVEC-2
            MvecCommand0x96 cmd2 = new MvecCommand0x96(0);
            Pgn0x0EF00 pgn2 = new Pgn0x0EF00(cmd2, 177);
            CanMessage msg2 = new CanMessage(pgn1.Pgn, Format.EXTENDED, 6, Program.CanRequestHandler.CanGateway.Address, pgn1.SerializeFields());
            Program.CanRequestHandler.QueueOutgoingMessage(msg2);
        }

        private void CanGateWayListener_NewMessage(object sender, CanMessage e)
        {
            //Set DashboardButton fuse status
            if (e.ParameterGroupNumber == 65440)
            {
                Pgn0x0FFA0 pgn = (Pgn0x0FFA0)ParameterGroup.GetPgnType(65440).DeserializeFields(e.Data);
                      
                foreach (Control c in this.Controls)
                {
                    if(c.GetType() == typeof(Panel))
                    {
                        foreach(Control child in c.Controls)
                        {
                            if (child.GetType() == typeof(Fuse) && c.IsHandleCreated)
                            {
                                var control = (Fuse)child;
                                control.UpdateFuseStatus((byte)e.SourceAddress, pgn.GridAddress, pgn.FuseStatus);
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
