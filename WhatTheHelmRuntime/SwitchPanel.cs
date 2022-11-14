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
using WhatTheHelmCanLib.Messages;
using WhatTheHelmCanLib.ParameterGroups;
using WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec;
using WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.MVec;
using WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryB.CooperBussman.Mvec;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;

namespace WhatTheHelmRuntime
{
    public partial class SwitchPanel : Form
    {
        Pgn0x0EF00 pgn0x0EF00 = new Pgn0x0EF00();
        Pgn0x0FFA0 pgn0x0FFA0 = new Pgn0x0FFA0();
        Pgn0x0FFA1 pgn0x0FFA1 = new Pgn0x0FFA1();
        public SwitchPanel()
        {
            InitializeComponent();
            this.MinimumSize = new Size() { Height = 480, Width = 800 };
            this.MaximumSize = new Size() { Height = 480, Width = 800 };

            //Subscribe to CAN messages
            Program.CanGateway.MessageRecieved += CanGateWay_MessageRecieved;

            //Perform intial scan of relay states of MVEC-1
            Pgn0x0EF00 pgn1 = new Pgn0x0EF00(new MvecCommand0x96(0), 176);
            CanMessage msg1 = new CanMessage(pgn1.Pgn, Format.EXTENDED, 6, Program.CanGateway.Address, pgn1.DestinationAddress, pgn1.SerializeFields());
            Program.CanGateway.Write(msg1);

            //Perform intial scan of relay states of MVEC-2
            Pgn0x0EF00 pgn2 = new Pgn0x0EF00(new MvecCommand0x96(0), 177);
            CanMessage msg2 = new CanMessage(pgn2.Pgn, Format.EXTENDED, 6, Program.CanGateway.Address, pgn2.DestinationAddress, pgn2.SerializeFields());
            Program.CanGateway.Write(msg2);

            //Perform intial scan of relay states of MVEC-3
            Pgn0x0EF00 pgn3 = new Pgn0x0EF00(new MvecCommand0x96(0), 178);
            CanMessage msg3 = new CanMessage(pgn3.Pgn, Format.EXTENDED, 6, Program.CanGateway.Address, pgn3.DestinationAddress, pgn3.SerializeFields());
            Program.CanGateway.Write(msg3);
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

        private void CanGateWay_MessageRecieved(object sender, CanMessageArgs e)
        {
            //Set DashboardButton states
            if (e.Message.Pgn == 61184)
            {
                pgn0x0EF00 = (Pgn0x0EF00)pgn0x0EF00.DeserializeFields(e.Message.Data);
                if(pgn0x0EF00.Reply.Reply == ReplyMessage.hex96)
                {
                    MvecReply0x96 reply = (MvecReply0x96)pgn0x0EF00.Reply;
                    foreach (Control c in this.Controls)
                    {
                        if (c.GetType() == typeof(DashboardButton) && c.IsHandleCreated)
                        {
                            var control = (DashboardButton)c;
                            control.UpdateState((byte)e.Message.SourceAddress, reply.GridAddress, reply.RelayState);
                        }
                    }
                }
            }
            //Set DashboardButton fuse status
            else if (e.Message.Pgn == 65440)
            {

                pgn0x0FFA0 = (Pgn0x0FFA0)pgn0x0FFA0.DeserializeFields(e.Message.Data);
                if (pgn0x0FFA0.FuseStatus.Contains(FuseStatus.Blown))
                    FusesStatus_FuseFaulted();
                else
                    FusesStatus_FuseFaultCleared();

                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(DashboardButton) && c.IsHandleCreated)
                    {
                        var control = (DashboardButton)c;
                        control.UpdateFuseStatus((byte)e.Message.SourceAddress, pgn0x0FFA0.GridAddress, pgn0x0FFA0.FuseStatus);
                    }              
                }
            }
            //Set DashboardButton relay status
            else if (e.Message.Pgn == 65441)
            {
                pgn0x0FFA1 = (Pgn0x0FFA1)pgn0x0FFA1.DeserializeFields(e.Message.Data);
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(DashboardButton) && c.IsHandleCreated)
                    {
                        var control = (DashboardButton)c;
                        control.UpdateRelayStatus((byte)e.Message.SourceAddress, pgn0x0FFA1.GridAddress, pgn0x0FFA1.RelayStatus);
                    }
                }
            }
        }

        public void NewCommand(object sender,DashboardButtonArgs e)
        {
            Pgn0x0EF00 pgn = new Pgn0x0EF00(new MvecCommand0x80(0, e.MvecRelayNumber, e.RelayCommandState), e.MvecAddress);
            CanMessage msg = new CanMessage(pgn.Pgn, Format.EXTENDED, 6, Program.CanGateway.Address, pgn.DestinationAddress, pgn.SerializeFields());
            Program.CanGateway.Write(msg);
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
