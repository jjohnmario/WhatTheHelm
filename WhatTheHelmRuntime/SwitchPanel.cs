using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using BoatFormsLib;
using BoatFormsLib.CustomUserControls;
using CanLib.Messages;
using CanLib.ParameterGroups;
using CanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec;
using CanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.MVec;
using CanLib.ParameterGroups.J1939.ProprietaryB.CooperBussman.Mvec;
using CanLib.ParameterGroups.NMEA2000;

namespace WhatTheHelmRuntime
{
    public partial class SwitchPanel : Form
    {
        public SwitchPanel()
        {
            InitializeComponent();
            this.MinimumSize = new Size() { Height = 480, Width = 800 };
            this.MaximumSize = new Size() { Height = 480, Width = 800 };

            //Subscribe to CAN messages
            Program.CanGateWayListener.NewMessage += CanGateWayListener_NewMessage;

            //Perform intial scan of relay states of MVEC-1
            MvecCommand0x96 cmd1 = new MvecCommand0x96(0);
            Pgn0x0EF00 pgn1 = new Pgn0x0EF00(cmd1, 176);
            CanMessage msg1 = new CanMessage(pgn1.Pgn, Format.EXTENDED, 6, Program.CanRequestHandler.CanGateway.Address, pgn1.SerializeFields(), false);
            Program.CanRequestHandler.QueueOutgoingMessage(msg1);
            //Perform intial scan of relay states of MVEC-2
            MvecCommand0x96 cmd2 = new MvecCommand0x96(0);
            Pgn0x0EF00 pgn2 = new Pgn0x0EF00(cmd2, 177);
            CanMessage msg2 = new CanMessage(pgn1.Pgn, Format.EXTENDED, 6, Program.CanRequestHandler.CanGateway.Address, pgn1.SerializeFields(), false);
            Program.CanRequestHandler.QueueOutgoingMessage(msg2);
        }

        private void FusesStatus_FuseFaultCleared()
        {
            MethodInvoker inv = new MethodInvoker(() =>
            {
                button1.BackgroundImage = WhatTheHelmRuntime.Properties.Resources.BlackButtonGear1;
            });
            if(button1.IsHandleCreated)
                button1.Invoke(inv);
        }
        private void FusesStatus_FuseFaulted()
        {
            MethodInvoker inv = new MethodInvoker(() =>
            {
                button1.BackgroundImage = WhatTheHelmRuntime.Properties.Resources.YellowButtonGear;
            });
            if(button1.IsHandleCreated)
                button1.Invoke(inv);
        }

        private void CanGateWayListener_NewMessage(object sender, CanMessage e)
        {
            //Set DashboardButton states
            if (e.ParameterGroupNumber == 61184)
            {
                Pgn0x0EF00 pgn = (Pgn0x0EF00)ParameterGroup.GetPgnType(61184).DeserializeFields(e.Data);
                if(pgn.Reply.Reply == ReplyMessage.hex96)
                {
                    MvecReply0x96 reply = (MvecReply0x96)pgn.Reply;
                    foreach (Control c in this.Controls)
                    {
                        if (c.GetType() == typeof(DashboardButton) && c.IsHandleCreated)
                        {
                            var control = (DashboardButton)c;
                            control.UpdateState((byte)e.SourceAddress, reply.GridAddress, reply.RelayState);
                        }
                    }
                }
            }
            //Set DashboardButton fuse status
            else if (e.ParameterGroupNumber == 65440)
            {
               
                Pgn0x0FFA0 pgn = (Pgn0x0FFA0)ParameterGroup.GetPgnType(65440).DeserializeFields(e.Data);
                if (pgn.FuseStatus.Contains(FuseStatus.Blown))
                    FusesStatus_FuseFaulted();
                else
                    FusesStatus_FuseFaultCleared();

                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(DashboardButton) && c.IsHandleCreated)
                    {
                        var control = (DashboardButton)c;
                        control.UpdateFuseStatus((byte)e.SourceAddress, pgn.GridAddress, pgn.FuseStatus);
                    }              
                }
            }
            //Set DashboardButton relay status
            else if (e.ParameterGroupNumber == 65441)
            {
                Pgn0x0FFA1 pgn = (Pgn0x0FFA1)ParameterGroup.GetPgnType(65441).DeserializeFields(e.Data);
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(DashboardButton) && c.IsHandleCreated)
                    {
                        var control = (DashboardButton)c;
                        control.UpdateRelayStatus((byte)e.SourceAddress, pgn.GridAddress, pgn.RelayStatus);
                    }
                }
            }
        }

        public void NewCommand(object sender,DashboardButtonArgs e)
        {
            MvecCommand0x80 cmd = new MvecCommand0x80(0, e.MvecRelayNumber, e.RelayCommandState);
            Pgn0x0EF00 pgn = new Pgn0x0EF00(cmd, e.MvecAddress);
            CanMessage msg = new CanMessage(pgn.Pgn, Format.EXTENDED, 6, Program.CanRequestHandler.CanGateway.Address, pgn.SerializeFields(), false);
            Program.CanRequestHandler.QueueOutgoingMessage(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FusesStatus fusesStatus = new FusesStatus();
            fusesStatus.Bounds = this.Bounds;
            fusesStatus.StartPosition = FormStartPosition.CenterParent;
            fusesStatus.ShowDialog();
        }
    }
}
