using CanLib.Messages;
using CanLib.ParameterGroups;
using CanLib.ParameterGroups.J1939;
using CanLib.ParameterGroups.NMEA2000;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WhatTheHelmRuntime
{
    public partial class PortGauges : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        DateTime lastBusMessage = new DateTime();
        DateTime pgn0x1F201LastMsg = new DateTime();
        DateTime pgn0x1F205LastMsg = new DateTime();
        DateTime pgn0x1F200LastMsg = new DateTime();
        DateTime pgn0x1F20DLastMsg = new DateTime();
        DateTime yoctopucePwmRxLastMsg = new DateTime();
        IndicatorBankStatus[] SeaGaugeIndicatorStatus;
        Pgn0x1F20D pgn0x1F20D = new Pgn0x1F20D();
        Pgn0x1F200 pgn0x1F200 = new Pgn0x1F200();
        Pgn0x1F205 pgn0x1F205 = new Pgn0x1F205();
        Pgn0x1F201 pgn0x1F201 = new Pgn0x1F201();

        public PortGauges(List<KeyValuePair<Screen, Type>> screenMap)
        {
            foreach (KeyValuePair<Screen, Type> kvp in screenMap)
            {
                if(kvp.Value == typeof(StbdGauges))
                {
                    StbdGauges sg = new StbdGauges();
                    sg.Bounds = kvp.Key.Bounds;
                    sg.StartPosition = FormStartPosition.Manual;
                    sg.Show();
                }
                if (kvp.Value == typeof(TrimControl))
                {
                    TrimControl tc = new TrimControl();
                    tc.Bounds = kvp.Key.Bounds;
                    tc.StartPosition = FormStartPosition.Manual;
                    tc.Show();
                }
                else if (kvp.Value == typeof(SwitchPanel))
                {
                    SwitchPanel sp = new SwitchPanel();
                    sp.Bounds = kvp.Key.Bounds;
                    sp.StartPosition = FormStartPosition.Manual;
                    sp.Show();
                }
                else if (kvp.Value == typeof(Rudder))
                {
                    Rudder gps = new Rudder();
                    gps.Bounds = kvp.Key.Bounds;
                    gps.StartPosition = FormStartPosition.Manual;
                    gps.Show();
                }           
            }
            Initialize();
        }

        public PortGauges()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeComponent();
            this.MinimumSize = new Size() { Height = 800, Width = 1280 };
            this.MaximumSize = new Size() { Height = 800, Width = 1280 };
            Program.CanGateWayListener.NewMessage += CanGateWayListener_NewMessage;
            Program.YoctoPwmRx.NewInput1Data += YoctoPwmRx_NewData;
            Timer pgnTimeoutTimer = new Timer();
            pgnTimeoutTimer.Interval = 5000;
            pgnTimeoutTimer.Tick += PgnTimeoutTimer_Tick;
            pgnTimeoutTimer.Start();
            Timer alarmTimer = new Timer();
            alarmTimer.Interval = 500;
            alarmTimer.Tick += AlarmTimer_Tick;
            alarmTimer.Start();
        }

        private void YoctoPwmRx_NewData(object sender, YoctoPwmRxArgs e)
        {
            yoctopucePwmRxLastMsg = DateTime.Now;
            if (Program.Configuration.RpmSource == RpmSource.YoctopuceUsb)
            {
                if (gaugePortRpm.IsHandleCreated)
                    gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Value = Convert.ToDouble((e.InputHz * 60 / 4).ToString("0"))));
            }
        }

        private void CanGateWayListener_NewMessage(object sender, CanLib.Messages.CanMessage e)
        {
            //Update last bus read event timestamp
            lastBusMessage = DateTime.Now;

            //Update last bus scan
            if (lblLastBusScan.IsHandleCreated)
            {
                lblLastBusScan.Invoke(new MethodInvoker(() => lblLastBusScan.Text = DateTime.Now.ToString("HH:mm:ss")));
            }

            //Update CAN message queue count
            if (lblCanMsgQueue.IsHandleCreated)
            {
                lblCanMsgQueue.Invoke(new MethodInvoker(() => lblCanMsgQueue.Text = Program.CanGateway.MessageQueueCount.ToString()));
            }

            //Update CAN fast packet queue count
            if (lblFastPacketQueue.IsHandleCreated)
            {
                lblFastPacketQueue.Invoke(new MethodInvoker(() => lblFastPacketQueue.Text = Program.CanGateWayListener.FastPacketMessageQueue.Count.ToString()));
            }

            //Binary switch status (from Seagauge)
            if (e.ParameterGroupNumber == 127501)
            {
                pgn0x1F20DLastMsg = DateTime.Now;
                pgn0x1F20D = (Pgn0x1F20D)pgn0x1F20D.DeserializeFields(e.Data).ToImperial();
                SeaGaugeIndicatorStatus = pgn0x1F20D.IndicatorBankStatus;
            }

            //Engine Parameters (Rapid)
            if (e.ParameterGroupNumber == 127488)
            {
                pgn0x1F200LastMsg = DateTime.Now;
                if (Program.Configuration.RpmSource == RpmSource.NMEA2000)
                {
                    pgn0x1F200 = (Pgn0x1F200)pgn0x1F200.DeserializeFields(e.Data).ToImperial();

                    //Port Engine
                    if (pgn0x1F200.EngineInstance == 0)
                    {
                        if (gaugePortRpm.IsHandleCreated)
                            gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Value = pgn0x1F200.EngineSpeed / 4));
                    }
                }
            }

            //Transmission Parameters
            if (e.ParameterGroupNumber == 127493)
            {
                pgn0x1F205LastMsg = DateTime.Now;
                pgn0x1F205 = (Pgn0x1F205)pgn0x1F205.DeserializeFields(e.Data).ToImperial();
                
                //Port Engine
                if (pgn0x1F205.EngineInstance == 0)
                {
                    gaugePortDrivePressure.Invoke(new MethodInvoker(() => { gaugePortDrivePressure.Value = Convert.ToDouble((pgn0x1F205.OilPressure).ToString("0")); }));
                }
            }

            //Engine Parameters (Dynamic)
            if (e.ParameterGroupNumber == 127489)
            {
                pgn0x1F201LastMsg = DateTime.Now;
                pgn0x1F201 = (Pgn0x1F201)pgn0x1F201.DeserializeFields(e.Data).ToImperial();

                //Port Engine
                if (pgn0x1F201.EngineInstance == 0)
                {
                    gaugePortWaterTemp.Invoke(new MethodInvoker(() => { gaugePortWaterTemp.Value = Convert.ToDouble(pgn0x1F201.EngineTemperature.ToString("0")); }));
                    gaugePortOilPressure.Invoke(new MethodInvoker(() => { gaugePortOilPressure.Value = Convert.ToDouble(pgn0x1F201.OilPressure.ToString("0")); }));
                    gaugePortVolts.Invoke(new MethodInvoker(() => { gaugePortVolts.Value = Convert.ToDouble(pgn0x1F201.AlternatorPotential.ToString("0.0")); }));
                    lblPortHours.Invoke(new MethodInvoker(() => { lblPortHours.Text = pgn0x1F201.EngineHours.ToString("0.0") + " HRS"; }));
                }
            }
        }

        private void PgnTimeoutTimer_Tick(object sender, EventArgs e)
        {
            //Get current time
            var dtNow = DateTime.Now;

            //Update Bus Status
            var lastBusMessageEt = dtNow - lastBusMessage;
            lblJ1939BustStatus.Invoke(new MethodInvoker(() =>
            {
                if (lastBusMessageEt.TotalSeconds > 5)
                {
                    lblJ1939BustStatus.BackColor = Color.Red;
                    lblJ1939BustStatus.Text = "FAULTED";
                }
                else
                {
                    lblJ1939BustStatus.BackColor = Color.Green;
                    lblJ1939BustStatus.Text = "OK";
                }
            }));

            //Alarm statuses
            var pgn0x1F20DLastMsgEt = dtNow - pgn0x1F20DLastMsg;
            if (pgn0x1F20DLastMsgEt.TotalSeconds > 5)
            {
                lblPortWaterTempHigh.Invoke(new MethodInvoker(() => lblPortWaterTempHigh.Hide()));
                lblPortOilPressLow.Invoke(new MethodInvoker(() => lblPortOilPressLow.Hide()));
                lblPortDriveTempHigh.Invoke(new MethodInvoker(() => lblPortDriveTempHigh.Hide()));
                lblPortFuelPressLow.Invoke(new MethodInvoker(() => lblPortFuelPressLow.Hide()));
            }
            else
            {
                lblPortWaterTempHigh.Invoke(new MethodInvoker(() => lblPortWaterTempHigh.Show()));
                lblPortOilPressLow.Invoke(new MethodInvoker(() => lblPortOilPressLow.Show()));
                lblPortDriveTempHigh.Invoke(new MethodInvoker(() => lblPortDriveTempHigh.Show()));
                lblPortFuelPressLow.Invoke(new MethodInvoker(() => lblPortFuelPressLow.Show()));
            }

            //Engine parameters rapid
            var pgn0x1F200LastMsgEt = dtNow - pgn0x1F200LastMsg;
            var yoctopucePwmRxLastMsgEt = dtNow - yoctopucePwmRxLastMsg;
            if (Program.Configuration.RpmSource == RpmSource.NMEA2000)
            {
                if (pgn0x1F200LastMsgEt.TotalSeconds > 5)
                {
                    gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Hide()));
                }
                else
                {
                    gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Show()));
                }
            }
            else if (Program.Configuration.RpmSource == RpmSource.YoctopuceUsb)
            {
                if (yoctopucePwmRxLastMsgEt.TotalSeconds > 5)
                {
                    gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Hide()));

                }
                else
                {
                    gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Show()));
                }
            }

            //Engine parameters dynamic
            var pgn0x1F201LastMsgEt = dtNow - pgn0x1F201LastMsg;
            if (pgn0x1F201LastMsgEt.TotalSeconds > 5)
            {
                gaugePortWaterTemp.Invoke(new MethodInvoker(() => { gaugePortWaterTemp.Hide(); }));
                gaugePortOilPressure.Invoke(new MethodInvoker(() => { gaugePortOilPressure.Hide(); }));
                gaugePortVolts.Invoke(new MethodInvoker(() => { gaugePortVolts.Hide(); }));
                lblPortVoltageLow.Invoke(new MethodInvoker(() => { lblPortVoltageLow.Hide(); }));
                lblPortHours.Invoke(new MethodInvoker(() => { lblPortHours.Text = "--"; }));
            }
            else
            {
                gaugePortWaterTemp.Invoke(new MethodInvoker(() => { gaugePortWaterTemp.Show(); }));
                gaugePortOilPressure.Invoke(new MethodInvoker(() => { gaugePortOilPressure.Show(); }));
                gaugePortVolts.Invoke(new MethodInvoker(() => { gaugePortVolts.Show(); }));
                lblPortVoltageLow.Invoke(new MethodInvoker(() => { lblPortVoltageLow.Show(); }));
            }

            //Transmission parameters
            var pgn0x1F205LastMsgEt = dtNow - pgn0x1F205LastMsg;
            if (pgn0x1F205LastMsgEt.TotalSeconds > 5)
            {
                gaugePortDrivePressure.Invoke(new MethodInvoker(() => { gaugePortDrivePressure.Hide(); }));
            }
            else
            {
                gaugePortDrivePressure.Invoke(new MethodInvoker(() => { gaugePortDrivePressure.Show(); }));
            }
        }

        private void AlarmTimer_Tick(object sender, EventArgs e)
        {
            //Port alternator output voltage low
            if(lblPortVoltageLow.IsHandleCreated)
                lblPortVoltageLow.Invoke(new MethodInvoker(() =>
                {
                    if (gaugePortVolts.Value < 12.6)
                        lblPortVoltageLow.BackColor = Color.Red;
                    else
                        lblPortVoltageLow.BackColor = Color.FromArgb(56, 0, 0);
                }));

            //Port water temp high
            if (lblPortWaterTempHigh.IsHandleCreated)
                lblPortWaterTempHigh.Invoke(new MethodInvoker(() =>
                {
                    if (SeaGaugeIndicatorStatus != null)
                    {
                        if (SeaGaugeIndicatorStatus[5] == IndicatorBankStatus.Off)
                            lblPortWaterTempHigh.BackColor = Color.Red;
                        else
                            lblPortWaterTempHigh.BackColor = Color.FromArgb(56, 0, 0);
                    }
                }));

            //Port oil pressure low
            if (lblPortOilPressLow.IsHandleCreated)
                lblPortOilPressLow.Invoke(new MethodInvoker(() =>
                {
                    if (SeaGaugeIndicatorStatus != null)
                    {
                        if (SeaGaugeIndicatorStatus[4] == IndicatorBankStatus.Off)
                            lblPortOilPressLow.BackColor = Color.Red;
                        else
                            lblPortOilPressLow.BackColor = Color.FromArgb(56, 0, 0);
                    }
                }));

            //Port drive temp high
            if (lblPortDriveTempHigh.IsHandleCreated)
                lblPortDriveTempHigh.Invoke(new MethodInvoker(() =>
                {
                    if (SeaGaugeIndicatorStatus != null)
                    {
                        if (SeaGaugeIndicatorStatus[6] == IndicatorBankStatus.Off)
                            lblPortDriveTempHigh.BackColor = Color.Red;
                        else
                            lblPortDriveTempHigh.BackColor = Color.FromArgb(56, 0, 0);
                    }
                }));

            //Port fuel pressure low
            if (lblPortFuelPressLow.IsHandleCreated)
                lblPortFuelPressLow.Invoke(new MethodInvoker(() =>
                {
                    if (SeaGaugeIndicatorStatus != null)
                    {
                        if (SeaGaugeIndicatorStatus[10] == IndicatorBankStatus.Off)
                            lblPortFuelPressLow.BackColor = Color.Red;
                        else
                            lblPortFuelPressLow.BackColor = Color.FromArgb(56, 0, 0);
                    }
                }));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Restart application?", "Exit", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
                Application.Restart();
            else if (result == DialogResult.No)
                Application.Exit();
            else if (result == DialogResult.Cancel)
                return;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ConfigurationMenu configMenu = new ConfigurationMenu(Program.Configuration);
            var results = configMenu.ShowDialog();
            if (results != DialogResult.Cancel)
            {
                Program.Configuration = configMenu.Configuration;
                Program.Configuration.Save();
            }
            configMenu.Dispose();
        }
    }
}
