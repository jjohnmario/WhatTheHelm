﻿using BoatFormsLib;
using BoatFormsLib.CustomUserControls;
using WhatTheHelmCanLib.Messages;
using WhatTheHelmCanLib.ParameterGroups;
using WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec;
using WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.MVec;
using WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryB.CooperBussman.Mvec;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatTheHelmRuntime
{
    public partial class TrimControl : Form
    {
        DateTime pgn0x1F200LastMsg = new DateTime();
        Pgn0x1F200 pgn0x1F200 = new Pgn0x1F200();
        Pgn0x0EF00 pgn0x0EF00 = new Pgn0x0EF00();
        Pgn0x0FFA0 pgn0x0FFA0 = new Pgn0x0FFA0();
        Pgn0x0FFA1 pgn0x0FFA1 = new Pgn0x0FFA1();
        public TrimControl()
        {
            InitializeComponent();
            this.MinimumSize = new Size() { Height = 480, Width = 800 };
            this.MaximumSize = new Size() { Height = 480, Width = 800 };
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

            Timer t = new Timer();
            t.Interval = 5000;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            //Get current time
            var dtNow = DateTime.Now;

            //Engine parameters dynamic
            var pgn0x1F200LastMsgEt = dtNow - pgn0x1F200LastMsg;
            if (pgn0x1F200LastMsgEt.TotalSeconds > 5)
            {
                gaugePortTrim.Invoke(new MethodInvoker(() => gaugePortTrim.Hide()));
                gaugeStbdTrim.Invoke(new MethodInvoker(() => gaugeStbdTrim.Hide()));
            }
            else
            {
                gaugePortTrim.Invoke(new MethodInvoker(() => gaugePortTrim.Show()));
                gaugeStbdTrim.Invoke(new MethodInvoker(() => gaugeStbdTrim.Show()));
            }
        }

        private void CanGateWayListener_NewMessage(object sender, CanMessage e)
        {
            //Engine Parameters (Rapid)
            if (e.ParameterGroupNumber == 127488)
            {
                pgn0x1F200LastMsg = DateTime.Now;
                pgn0x1F200 = (Pgn0x1F200)pgn0x1F200.DeserializeFields(e.Data).ToImperial();

                //Port Engine
                if (pgn0x1F200.EngineInstance == 0)
                {
                    if (gaugePortTrim.IsHandleCreated)
                        gaugePortTrim.Invoke(new MethodInvoker(() => gaugePortTrim.Value = pgn0x1F200.EngineTiltTrim));
                }
                //Stbd Engine
                else if (pgn0x1F200.EngineInstance == 1)
                {
                    if (gaugeStbdTrim.IsHandleCreated)
                        gaugeStbdTrim.Invoke(new MethodInvoker(() => gaugeStbdTrim.Value = pgn0x1F200.EngineTiltTrim));
                }
            }
            //Set DashboardButton states
            else if (e.ParameterGroupNumber == 61184)
            {
                pgn0x0EF00 = (Pgn0x0EF00)pgn0x0EF00.DeserializeFields(e.Data);
                if (pgn0x0EF00.Reply.Reply == ReplyMessage.hex96)
                {

                    MvecReply0x96 reply = (MvecReply0x96)pgn0x0EF00.Reply;
                    foreach (Control c in this.Controls)
                    {
                        if (c.GetType() == typeof(DashboardButton))
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
                pgn0x0FFA0 = (Pgn0x0FFA0)pgn0x0FFA0.DeserializeFields(e.Data);
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(DashboardButton))
                    {
                        var control = (DashboardButton)c;
                        control.UpdateFuseStatus((byte)e.SourceAddress, pgn0x0FFA0.GridAddress, pgn0x0FFA0.FuseStatus);
                    }
                }
            }
            //Set DashboardButton relay status
            else if (e.ParameterGroupNumber == 65441)
            {
                pgn0x0FFA1 = (Pgn0x0FFA1)pgn0x0FFA1.DeserializeFields(e.Data);
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(DashboardButton))
                    {
                        var control = (DashboardButton)c;
                        control.UpdateRelayStatus((byte)e.SourceAddress, pgn0x0FFA1.GridAddress, pgn0x0FFA1.RelayStatus);
                    }
                }
            }
        }

        private void NewCommand(DashboardButtonArgs e)
        {
            MvecCommand0x80 cmd = new MvecCommand0x80(0, e.MvecRelayNumber, e.RelayCommandState);
            Pgn0x0EF00 pgn = new Pgn0x0EF00(cmd, e.MvecAddress);
            CanMessage msg = new CanMessage(pgn.Pgn, Format.EXTENDED, 6, Program.CanRequestHandler.CanGateway.Address, pgn.SerializeFields());
            Program.CanRequestHandler.QueueOutgoingMessage(msg);
        }

        private void dashboardButton3_NewCommand(object sender, BoatFormsLib.DashboardButtonArgs e)
        {
            NewCommand(e);
        }

        private void dashboardButton2_NewCommand(object sender, BoatFormsLib.DashboardButtonArgs e)
        {
            NewCommand(e);
        }

        private void dashboardButton7_NewCommand(object sender, BoatFormsLib.DashboardButtonArgs e)
        {
            NewCommand(e);
        }

        private void dashboardButton1_NewCommand(object sender, BoatFormsLib.DashboardButtonArgs e)
        {
            NewCommand(e);
        }

        private void dashboardButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
