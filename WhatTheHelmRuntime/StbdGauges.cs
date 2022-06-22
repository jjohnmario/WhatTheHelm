using CanLib.Messages;
using CanLib.ParameterGroups;
using CanLib.ParameterGroups.J1939;
using CanLib.ParameterGroups.NMEA2000;
using WhatTheHelmRuntime;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WhatTheHelmRuntime
{
    public partial class StbdGauges : Form
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
        DateTime pgn0x1FD06LastMsg = new DateTime();
        DateTime pgn0x1F50BLastMsg = new DateTime();
        DateTime pgn0x1F503LastMsg = new DateTime();
        DateTime pgn0x1F805LastMsg = new DateTime();
        DateTime pgn0x1F10DLastMsg = new DateTime();
        DateTime pgn0x1F20DLastMsg = new DateTime();
        DateTime yoctopucePwmRxLastMsg = new DateTime();
        IndicatorBankStatus[] SeaGaugeIndicatorStatus;
        Color gaugePortRpmBorderLast;
        Color gaugeStbdRpmBorderLast;

        public StbdGauges()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeComponent();
            this.MinimumSize = new Size() { Height = 800, Width = 1280 };
            this.MaximumSize = new Size() { Height = 800, Width = 1280 };
            Program.CanGateWayListener.NewMessage += CanGateWayListener_NewMessage;
            Program.YoctoPwmRx.NewData += YoctoPwmRx_NewData;
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
                //if (gaugePortRpm.IsHandleCreated)
                //    gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Value = Convert.ToDouble((e.Input1Hz * 60 / 4).ToString("0"))));
                if (gaugeStbdRpm.IsHandleCreated)
                    gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Value = Convert.ToDouble((e.Input2Hz * 60 / 4).ToString("0"))));
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
                lblCanMsgQueue.Invoke(new MethodInvoker(() => lblCanMsgQueue.Text = Program.CanGateWayListener.MainMessageQueue.Count.ToString()));
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
                Pgn0x1F20D pgn = (Pgn0x1F20D)ParameterGroup.GetPgnType(127501).DeserializeFields(e.Data).ToImperial();
                SeaGaugeIndicatorStatus = pgn.IndicatorBankStatus;
            }

            //Engine Parameters (Rapid)
            if (e.ParameterGroupNumber == 127488)
            {
                pgn0x1F200LastMsg = DateTime.Now;
                Pgn0x1F200 pgn = (Pgn0x1F200)ParameterGroup.GetPgnType(127488).DeserializeFields(e.Data).ToImperial();

                //Port Engine
                if (pgn.EngineInstance == 0)
                {
                    //if (Program.Configuration.RpmSource == RpmSource.NMEA2000)
                    //{
                    //    if (gaugePortRpm.IsHandleCreated)
                    //        gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Value = pgn.EngineSpeed / 4));
                    //}
                }
                //Stbd Engine
                else if (pgn.EngineInstance == 1)
                {
                    if (Program.Configuration.RpmSource == RpmSource.NMEA2000)
                    {
                        if (gaugeStbdRpm.IsHandleCreated)
                            gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Value = pgn.EngineSpeed / 4));
                    }
                }
                ////Generator
                //else if (pgn.EngineInstance == 2)
                //{
                //    var genRpm = pgn.EngineSpeed;
                //    if (lblGeneratorStatus.IsHandleCreated)
                //        lblGeneratorStatus.Invoke(new MethodInvoker(() =>
                //        {
                //            if (genRpm > 250)
                //            {
                //                lblGeneratorStatus.Text = "RUNNING";
                //                lblGeneratorStatus.ForeColor = Color.White;
                //                lblGeneratorStatus.BackColor = Color.Green;
                //            }
                //            else
                //            {
                //                lblGeneratorStatus.Text = "STOPPED";
                //                lblGeneratorStatus.ForeColor = Color.White;
                //                lblGeneratorStatus.BackColor = Color.Transparent;
                //            }
                //        }));
                //}
            }

            //Transmission Parameters
            if (e.ParameterGroupNumber == 127493)
            {
                pgn0x1F205LastMsg = DateTime.Now;
                Pgn0x1F205 pgn = (Pgn0x1F205)ParameterGroup.GetPgnType(127493).DeserializeFields(e.Data).ToImperial();

                //Port Engine
                if (pgn.EngineInstance == 0)
                {
                    //gaugePortDrivePressure.Invoke(new MethodInvoker(() => { gaugePortDrivePressure.Value = Convert.ToDouble((pgn.OilPressure).ToString("0")); }));
                }

                //Stbd Engine
                if (pgn.EngineInstance == 1)
                {
                    gaugeStbdDrivePressure.Invoke(new MethodInvoker(() => { gaugeStbdDrivePressure.Value = Convert.ToDouble((pgn.OilPressure).ToString("0")); }));
                }
            }

            //Engine Parameters (Dynamic)
            if (e.ParameterGroupNumber == 127489)
            {
                pgn0x1F201LastMsg = DateTime.Now;
                Pgn0x1F201 pgn = (Pgn0x1F201)ParameterGroup.GetPgnType(127489).DeserializeFields(e.Data).ToImperial();

                //Port Engine
                if (pgn.EngineInstance == 0)
                {
                    //gaugePortWaterTemp.Invoke(new MethodInvoker(() => { gaugePortWaterTemp.Value = Convert.ToDouble(pgn.EngineTemperature.ToString("0")); }));
                    //gaugePortOilPressure.Invoke(new MethodInvoker(() => { gaugePortOilPressure.Value = Convert.ToDouble(pgn.OilPressure.ToString("0")); }));
                    //gaugePortVolts.Invoke(new MethodInvoker(() => { gaugePortVolts.Value = Convert.ToDouble(pgn.AlternatorPotential.ToString("0.0")); }));
                    //lblPortHours.Invoke(new MethodInvoker(() => { lblPortHours.Text = pgn.EngineHours.ToString("0.0") + " HRS"; }));
                }
                //Stbd Engine
                else if (pgn.EngineInstance == 1)
                {
                    gaugeStbdWaterTemp.Invoke(new MethodInvoker(() => { gaugeStbdWaterTemp.Value = Convert.ToDouble(pgn.EngineTemperature.ToString("0")); }));
                    gaugeStbdOilPressure.Invoke(new MethodInvoker(() => { gaugeStbdOilPressure.Value = Convert.ToDouble(pgn.OilPressure.ToString("0")); }));
                    gaugeStbdVolts.Invoke(new MethodInvoker(() => { gaugeStbdVolts.Value = Convert.ToDouble(pgn.AlternatorPotential.ToString("0.0")); }));
                    lblStbdHours.Invoke(new MethodInvoker(() => { lblStbdHours.Text = pgn.EngineHours.ToString("0.0") + " HRS"; }));
                }
            }

            ////Water Temperature (F)
            //else if (e.ParameterGroupNumber == 130310)
            //{
            //    pgn0x1FD06LastMsg = DateTime.Now;
            //    Pgn0x1FD06 pgn = (Pgn0x1FD06)ParameterGroup.GetPgnType(130310).DeserializeFields(e.Data).ToImperial();
            //    if (lblSeaWaterTemp.IsHandleCreated)
            //        lblSeaWaterTemp.Invoke(new MethodInvoker(() => lblSeaWaterTemp.Text = (pgn.Temperature + Program.Configuration.WaterTempOffset).ToString("0.0")));
            //}

            ////Water Depth (FT)
            //else if (e.ParameterGroupNumber == 128267)
            //{
            //    pgn0x1F50BLastMsg = DateTime.Now;
            //    Pgn0x1F50B pgn = (Pgn0x1F50B)ParameterGroup.GetPgnType(128267).DeserializeFields(e.Data).ToImperial();
            //    if (lblSeaWaterDepth.IsHandleCreated)
            //        lblSeaWaterDepth.Invoke(new MethodInvoker(() => { lblSeaWaterDepth.Text = (pgn.Depth + Program.Configuration.WaterDepthOffset).ToString("0.0"); }));
            //}

            ////Speed (MPH)
            //else if (e.ParameterGroupNumber == 128259)
            //{
            //    pgn0x1F503LastMsg = DateTime.Now;
            //    Pgn0x1F503 pgn = (Pgn0x1F503)ParameterGroup.GetPgnType(128259).DeserializeFields(e.Data).ToImperial();
            //    if (gaugeSog.IsHandleCreated)
            //    {
            //        gaugeSog.Invoke(new MethodInvoker(() => gaugeSog.Value = pgn.Speed));
            //    }
            //}

            //GPS Coordinates
            //else if (e.ParameterGroupNumber == 129029)
            //{
            //    pgn0x1F805LastMsg = DateTime.Now;
            //    Pgn0x1F805 pgn = (Pgn0x1F805)ParameterGroup.GetPgnType(129029).DeserializeFields(e.Data);
            //    if (lblGpsCoordinates.IsHandleCreated)
            //    {
            //        lblGpsCoordinates.Invoke(new MethodInvoker(() =>
            //        {
            //            var array = pgn.ToString().Split(',');
            //            string text = "LATITUDE: " + array[0] + Environment.NewLine + "LONGITUDE: " + array[1] + Environment.NewLine + "ALTITUDE: " + array[2];
            //            lblGpsCoordinates.Text = text;
            //        }));
            //    }
            //}

            //Poll for GPS Coordinates on next scan.
            Pgn0x1F805 gnssData = new Pgn0x1F805();
            Pgn0x0EA00 isoRequest = new Pgn0x0EA00(gnssData, 3);
            CanMessage message = new CanMessage(isoRequest.MessagePgn, Format.EXTENDED, 3, Program.CanGateway.Address, BitConverter.GetBytes(gnssData.Pgn), false);
            Program.CanGateway.Write(message);
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
                    lblJ1939BustStatus.Text = "CAN BUS FAULTED";
                }
                else
                {
                    lblJ1939BustStatus.BackColor = Color.Green;
                    lblJ1939BustStatus.Text = "CAN BUS OK";
                }
            }));

            ////Rudder position
            //var pgn0x1F10DLastMsgEt = dtNow - pgn0x1F10DLastMsg;
            //if (pgn0x1F10DLastMsgEt.TotalSeconds > 5)
            //    gaugeRudderAngle.Invoke(new MethodInvoker(() => gaugeRudderAngle.Hide()));
            //else
            //    gaugeRudderAngle.Invoke(new MethodInvoker(() => gaugeRudderAngle.Show()));

            //Switch status
            var pgn0x1F20DLastMsgEt = dtNow - pgn0x1F20DLastMsg;
            if (pgn0x1F20DLastMsgEt.TotalSeconds > 5)
            {
                //lblPortWaterTempHigh.Invoke(new MethodInvoker(() => lblPortWaterTempHigh.Hide()));
                lblStbdWaterTempHigh.Invoke(new MethodInvoker(() => lblStbdWaterTempHigh.Hide()));
                //lblPortOilPressLow.Invoke(new MethodInvoker(() => lblPortOilPressLow.Hide()));
                lblStbdOilPressLow.Invoke(new MethodInvoker(() => lblStbdOilPressLow.Hide()));
                //lblPortDriveTempHigh.Invoke(new MethodInvoker(() => lblPortDriveTempHigh.Hide()));
                lblStbdDriveTempHigh.Invoke(new MethodInvoker(() => lblStbdDriveTempHigh.Hide()));
                //lblPortFuelPressLow.Invoke(new MethodInvoker(() => lblPortFuelPressLow.Hide()));
                lblStbdFuelPressLow.Invoke(new MethodInvoker(() => lblStbdFuelPressLow.Hide()));
            }
            else
            {
                //lblPortWaterTempHigh.Invoke(new MethodInvoker(() => lblPortWaterTempHigh.Show()));
                lblStbdWaterTempHigh.Invoke(new MethodInvoker(() => lblStbdWaterTempHigh.Show()));
                //lblPortOilPressLow.Invoke(new MethodInvoker(() => lblPortOilPressLow.Show()));
                lblStbdOilPressLow.Invoke(new MethodInvoker(() => lblStbdOilPressLow.Show()));
                //lblPortDriveTempHigh.Invoke(new MethodInvoker(() => lblPortDriveTempHigh.Show()));
                lblStbdDriveTempHigh.Invoke(new MethodInvoker(() => lblStbdDriveTempHigh.Show()));
                //lblPortFuelPressLow.Invoke(new MethodInvoker(() => lblPortFuelPressLow.Show()));
                lblStbdFuelPressLow.Invoke(new MethodInvoker(() => lblStbdFuelPressLow.Show()));
            }

            //GPS Coordinates
            //var pgn0x1F805LastMsgEt = dtNow - pgn0x1F805LastMsg;
            //if (pgn0x1F805LastMsgEt.TotalSeconds > 5)
            //    lblGpsCoordinates.Invoke(new MethodInvoker(() =>
            //    {
            //        lblGpsCoordinates.Text = "LATITUDE: --" + Environment.NewLine + "LONGITUDE: --" + Environment.NewLine + "ALTITUDE: --";
            //    }));

            //Engine parameters rapid
            var pgn0x1F200LastMsgEt = dtNow - pgn0x1F200LastMsg;
            var yoctopucePwmRxLastMsgEt = dtNow - yoctopucePwmRxLastMsg;
            if (Program.Configuration.RpmSource == RpmSource.NMEA2000)
            {
                if (pgn0x1F200LastMsgEt.TotalSeconds > 5)
                {
                    //gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Hide()));
                    gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Hide()));
                }
                else
                {
                    //gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Show()));
                    gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Show()));
                }
            }
            else if (Program.Configuration.RpmSource == RpmSource.YoctopuceUsb)
            {
                if (yoctopucePwmRxLastMsgEt.TotalSeconds > 5)
                {
                    //gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Hide()));
                    gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Hide()));

                }
                else
                {
                    //gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Show()));
                    gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Show()));
                }
            }

            //Engine parameters dynamic
            var pgn0x1F201LastMsgEt = dtNow - pgn0x1F201LastMsg;
            if (pgn0x1F201LastMsgEt.TotalSeconds > 5)
            {
                //gaugePortWaterTemp.Invoke(new MethodInvoker(() => { gaugePortWaterTemp.Hide(); }));
                //gaugePortOilPressure.Invoke(new MethodInvoker(() => { gaugePortOilPressure.Hide(); }));
                //gaugePortVolts.Invoke(new MethodInvoker(() => { gaugePortVolts.Hide(); }));
                //lblPortVoltageLow.Invoke(new MethodInvoker(() => { lblPortVoltageLow.Hide(); }));
                //lblPortHours.Invoke(new MethodInvoker(() => { lblPortHours.Text = "--"; }));
                gaugeStbdWaterTemp.Invoke(new MethodInvoker(() => { gaugeStbdWaterTemp.Hide(); }));
                gaugeStbdOilPressure.Invoke(new MethodInvoker(() => { gaugeStbdOilPressure.Hide(); }));
                gaugeStbdVolts.Invoke(new MethodInvoker(() => { gaugeStbdVolts.Hide(); }));
                lblStbdVoltageLow.Invoke(new MethodInvoker(() => { lblStbdVoltageLow.Hide(); }));
                lblStbdHours.Invoke(new MethodInvoker(() => { lblStbdHours.Text = "--"; }));
            }
            else
            {
                //gaugePortWaterTemp.Invoke(new MethodInvoker(() => { gaugePortWaterTemp.Show(); }));
                //gaugePortOilPressure.Invoke(new MethodInvoker(() => { gaugePortOilPressure.Show(); }));
                //gaugePortVolts.Invoke(new MethodInvoker(() => { gaugePortVolts.Show(); }));
                //lblPortVoltageLow.Invoke(new MethodInvoker(() => { lblPortVoltageLow.Show(); }));
                gaugeStbdWaterTemp.Invoke(new MethodInvoker(() => { gaugeStbdWaterTemp.Show(); }));
                gaugeStbdOilPressure.Invoke(new MethodInvoker(() => { gaugeStbdOilPressure.Show(); }));
                gaugeStbdVolts.Invoke(new MethodInvoker(() => { gaugeStbdVolts.Show(); }));
                lblStbdVoltageLow.Invoke(new MethodInvoker(() => { lblStbdVoltageLow.Show(); }));
            }

            //Transmission parameters
            var pgn0x1F205LastMsgEt = dtNow - pgn0x1F205LastMsg;
            if (pgn0x1F205LastMsgEt.TotalSeconds > 5)
            {
                //gaugePortDrivePressure.Invoke(new MethodInvoker(() => { gaugePortDrivePressure.Hide(); }));
                gaugeStbdDrivePressure.Invoke(new MethodInvoker(() => { gaugeStbdDrivePressure.Hide(); }));
            }
            else
            {
                //gaugePortDrivePressure.Invoke(new MethodInvoker(() => { gaugePortDrivePressure.Show(); }));
                gaugeStbdDrivePressure.Invoke(new MethodInvoker(() => { gaugeStbdDrivePressure.Show(); }));
            }
        }

        private void AlarmTimer_Tick(object sender, EventArgs e)
        {
            //Port alternator output voltage low
            //lblPortVoltageLow.Invoke(new MethodInvoker(() =>
            //{
            //    try
            //    {
            //        if (gaugePortVolts.Value < 12.6)
            //            lblPortVoltageLow.BackColor = Color.Red;
            //        else
            //            lblPortVoltageLow.BackColor = Color.FromArgb(56, 0, 0);
            //    }
            //    catch
            //    {
            //        lblPortVoltageLow.BackColor = Color.Red;
            //    }
            //}));

            //Stbd alternator output voltage low
            lblStbdVoltageLow.Invoke(new MethodInvoker(() =>
            {
                try
                {
                    if (gaugeStbdVolts.Value < 12.6)
                        lblStbdVoltageLow.BackColor = Color.Red;
                    else
                        lblStbdVoltageLow.BackColor = Color.FromArgb(56, 0, 0);
                }
                catch
                {
                    lblStbdVoltageLow.BackColor = Color.Maroon;
                }
            }));

            //Port water temp high
            if (lblStbdWaterTempHigh.IsHandleCreated)
                lblStbdWaterTempHigh.Invoke(new MethodInvoker(() =>
                {
                    if (SeaGaugeIndicatorStatus != null)
                    {
                        if (SeaGaugeIndicatorStatus[5] == IndicatorBankStatus.Off)
                            lblStbdWaterTempHigh.BackColor = Color.Red;
                        else
                            lblStbdWaterTempHigh.BackColor = Color.FromArgb(56, 0, 0);
                    }
                }));

            //Stbd water temp high
            if (lblStbdWaterTempHigh.IsHandleCreated)
                lblStbdWaterTempHigh.Invoke(new MethodInvoker(() =>
                {
                    if (SeaGaugeIndicatorStatus != null)
                    {
                        if (SeaGaugeIndicatorStatus[7] == IndicatorBankStatus.Off)
                            lblStbdWaterTempHigh.BackColor = Color.Red;
                        else
                            lblStbdWaterTempHigh.BackColor = Color.FromArgb(56, 0, 0);
                    }
                }));

            //Port oil pressure low
            //if (lblPortOilPressLow.IsHandleCreated)
            //    lblPortOilPressLow.Invoke(new MethodInvoker(() =>
            //    {
            //        if (SeaGaugeIndicatorStatus != null)
            //        {
            //            if (SeaGaugeIndicatorStatus[4] == IndicatorBankStatus.Off)
            //                lblPortOilPressLow.BackColor = Color.Red;
            //            else
            //                lblPortOilPressLow.BackColor = Color.FromArgb(56, 0, 0);
            //        }
            //    }));

            //Stbd oil pressure low
            if (lblStbdOilPressLow.IsHandleCreated)
                lblStbdOilPressLow.Invoke(new MethodInvoker(() =>
                {
                    if (SeaGaugeIndicatorStatus != null)
                    {
                        if (SeaGaugeIndicatorStatus[8] == IndicatorBankStatus.Off)
                            lblStbdOilPressLow.BackColor = Color.Red;
                        else
                            lblStbdOilPressLow.BackColor = Color.FromArgb(56, 0, 0);
                    }
                }));

            //Port drive temp high
            //if (lblPortDriveTempHigh.IsHandleCreated)
            //    lblPortDriveTempHigh.Invoke(new MethodInvoker(() =>
            //    {
            //        if (SeaGaugeIndicatorStatus != null)
            //        {
            //            if (SeaGaugeIndicatorStatus[6] == IndicatorBankStatus.Off)
            //                lblPortDriveTempHigh.BackColor = Color.Red;
            //            else
            //                lblPortDriveTempHigh.BackColor = Color.FromArgb(56, 0, 0);
            //        }
            //    }));

            //Stbd drive temp high
            if (lblStbdDriveTempHigh.IsHandleCreated)
                lblStbdDriveTempHigh.Invoke(new MethodInvoker(() =>
                {
                    if (SeaGaugeIndicatorStatus != null)
                    {
                        if (SeaGaugeIndicatorStatus[9] == IndicatorBankStatus.Off)
                            lblStbdDriveTempHigh.BackColor = Color.Red;
                        else
                            lblStbdDriveTempHigh.BackColor = Color.FromArgb(56, 0, 0);
                    }
                }));

            //Port fuel pressure low
            //if (lblPortFuelPressLow.IsHandleCreated)
            //    lblPortFuelPressLow.Invoke(new MethodInvoker(() =>
            //    {
            //        if (SeaGaugeIndicatorStatus != null)
            //        {
            //            if (SeaGaugeIndicatorStatus[10] == IndicatorBankStatus.Off)
            //                lblPortFuelPressLow.BackColor = Color.Red;
            //            else
            //                lblPortFuelPressLow.BackColor = Color.FromArgb(56, 0, 0);
            //        }
            //    }));

            //Stbd fuel pressure low
            if (lblStbdFuelPressLow.IsHandleCreated)
                lblStbdFuelPressLow.Invoke(new MethodInvoker(() =>
                {
                    if (SeaGaugeIndicatorStatus != null)
                    {
                        if (SeaGaugeIndicatorStatus[11] == IndicatorBankStatus.Off)
                            lblStbdFuelPressLow.BackColor = Color.Red;
                        else
                            lblStbdFuelPressLow.BackColor = Color.FromArgb(56, 0, 0);
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
