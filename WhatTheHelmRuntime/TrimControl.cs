using BoatFormsLib;
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
        DateTime _pgn0x1FE10LastMsg = new DateTime();
        Pgn0x1FE10 _pgn0x1FE10 = new Pgn0x1FE10();
        Pgn0x1F10D _pgn0x1F10D = new Pgn0x1F10D();
        Pgn0x0EF00 _pgn0x0EF00 = new Pgn0x0EF00();
        Pgn0x0FFA0 _pgn0x0FFA0 = new Pgn0x0FFA0();
        Pgn0x0FFA1 _pgn0x0FFA1 = new Pgn0x0FFA1();

        public TrimControl()
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

            Timer t = new Timer();
            t.Interval = 5000;
            t.Tick += T_Tick;
            t.Start();
        }

        private void CanGateWay_MessageRecieved(object sender, CanMessageArgs e)
        {
            //Set Trim tab status
            if (Program.RunningConfiguration != null)
            {
                //Trim tab - Port
                if (Program.RunningConfiguration.RudderTrimN2KConfig.PortTrim != null)
                {
                    if (e.Message.SourceAddress == Program.RunningConfiguration.RudderTrimN2KConfig.PortTrim.Nmea2000Device.Address)
                    {
                        //PGN check
                        if (e.Message.Pgn == Program.RunningConfiguration.RudderTrimN2KConfig.PortTrim.PGN)
                        {
                            _pgn0x1FE10 = (Pgn0x1FE10)_pgn0x1FE10.DeserializeFields(e.Message.Data).ToImperial();
                            if (gaugePortTrim.IsHandleCreated)
                                gaugePortTrim.Invoke(new MethodInvoker(() => gaugePortTrim.Value = _pgn0x1FE10.PortPosition));
                        }
                    }
                }
                //Trim tab - Stbd
                if (Program.RunningConfiguration.RudderTrimN2KConfig.StbdTrim != null)
                {
                    if (e.Message.SourceAddress == Program.RunningConfiguration.RudderTrimN2KConfig.StbdTrim.Nmea2000Device.Address)
                    {
                        //PGN check
                        if (e.Message.Pgn == Program.RunningConfiguration.RudderTrimN2KConfig.StbdTrim.PGN)
                        {
                            _pgn0x1FE10 = (Pgn0x1FE10)_pgn0x1FE10.DeserializeFields(e.Message.Data).ToImperial();
                            if (gaugeStbdTrim.IsHandleCreated)
                                gaugeStbdTrim.Invoke(new MethodInvoker(() => gaugeStbdTrim.Value = _pgn0x1FE10.StbdPosition));
                        }
                    }
                }
            }

            //Set DashboardButton states
            if (e.Message.Pgn == 61184)
            {
                _pgn0x0EF00 = (Pgn0x0EF00)_pgn0x0EF00.DeserializeFields(e.Message.Data);
                if (_pgn0x0EF00.Reply.Reply == ReplyMessage.hex96)
                {

                    MvecReply0x96 reply = (MvecReply0x96)_pgn0x0EF00.Reply;
                    foreach (Control c in this.Controls)
                    {
                        if (c.GetType() == typeof(DashboardButton))
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
                _pgn0x0FFA0 = (Pgn0x0FFA0)_pgn0x0FFA0.DeserializeFields(e.Message.Data);
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(DashboardButton))
                    {
                        var control = (DashboardButton)c;
                        control.UpdateFuseStatus((byte)e.Message.SourceAddress, _pgn0x0FFA0.GridAddress, _pgn0x0FFA0.FuseStatus);
                    }
                }
            }

            //Set DashboardButton relay status
            else if (e.Message.Pgn == 65441)
            {
                _pgn0x0FFA1 = (Pgn0x0FFA1)_pgn0x0FFA1.DeserializeFields(e.Message.Data);
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(DashboardButton))
                    {
                        var control = (DashboardButton)c;
                        control.UpdateRelayStatus((byte)e.Message.SourceAddress, _pgn0x0FFA1.GridAddress, _pgn0x0FFA1.RelayStatus);
                    }
                }
            }
        }

        private void NewCommand(DashboardButtonArgs e)
        {
            MvecCommand0x80 cmd = new MvecCommand0x80(0, e.MvecRelayNumber, e.RelayCommandState);
            Pgn0x0EF00 pgn = new Pgn0x0EF00(cmd, e.MvecAddress);
            CanMessage msg = new CanMessage(pgn.Pgn, Format.EXTENDED, 6, Program.CanGateway.Address, pgn.DestinationAddress, pgn.SerializeFields());
            Program.CanGateway.Write(msg);
        }

        private void T_Tick(object sender, EventArgs e)
        {
            //Get current time
            var dtNow = DateTime.Now;

            //Trim tab status
            var pgn0x1FE10LastMsgEt = dtNow - _pgn0x1FE10LastMsg;
            if (pgn0x1FE10LastMsgEt.TotalSeconds > 5)
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

        private void btnConfigNmea2000_Click(object sender, EventArgs e)
        {
            RudderTrimNmea2000Config config = new RudderTrimNmea2000Config(Program.Configuration.RudderTrimN2KConfig, "Rudder & Trim");
            var result = config.ShowDialog();
            if (result == DialogResult.OK)
            {
                Program.Configuration.RudderTrimN2KConfig = config.NewRudderTrimConfig;
                Program.Configuration.Save(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\WhatTheHelm", "config.json", Program.Configuration);
                Program.InitializeConfiguration();
            }
        }
    }
}
