using WhatTheHelmCanLib.Messages;
using WhatTheHelmCanLib.ParameterGroups;
using WhatTheHelmCanLib.ParameterGroups.J1939;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;
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
        DateTime pgn0x1F20DLastMsg = new DateTime();
        DateTime yoctopucePwmRxLastMsg = new DateTime();
        IndicatorBankStatus[] SeaGaugeIndicatorStatus;
        Pgn0x1F20D pgn0x1F20D = new Pgn0x1F20D();
        Pgn0x1F200 pgn0x1F200 = new Pgn0x1F200();
        Pgn0x1F205 pgn0x1F205 = new Pgn0x1F205();
        Pgn0x1F201 pgn0x1F201 = new Pgn0x1F201();

        public StbdGauges()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeComponent();
            this.MinimumSize = new Size() { Height = 800, Width = 1280 };
            this.MaximumSize = new Size() { Height = 800, Width = 1280 };
            Timer pgnTimeoutTimer = new Timer();
            pgnTimeoutTimer.Interval = 5000;
            pgnTimeoutTimer.Tick += PgnTimeoutTimer_Tick;
            pgnTimeoutTimer.Start();
            Timer alarmTimer = new Timer();
            alarmTimer.Interval = 500;
            alarmTimer.Tick += AlarmTimer_Tick;
            alarmTimer.Start();
        }

        private void CanGateWayListener_NewMessage(object sender, WhatTheHelmCanLib.Messages.CanMessage e)
        {
            //Update last bus read event timestamp
            lastBusMessage = DateTime.Now;

            //Binary switch status (from Seagauge)
            if (e.Pgn == 127501)
            {
                pgn0x1F20DLastMsg = DateTime.Now;
                pgn0x1F20D = (Pgn0x1F20D)pgn0x1F20D.DeserializeFields(e.Data).ToImperial();
                SeaGaugeIndicatorStatus = pgn0x1F20D.IndicatorBankStatus;
            }

            //Engine Parameters (Rapid)
            if (e.Pgn == 127488)
            {
                pgn0x1F200LastMsg = DateTime.Now;
                pgn0x1F200 = (Pgn0x1F200)pgn0x1F200.DeserializeFields(e.Data).ToImperial();

                //Stbd Engine
                if (pgn0x1F200.EngineInstance == 1)
                {
                    if (gaugeStbdRpm.IsHandleCreated)
                        gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Value = pgn0x1F200.EngineSpeed / 4));
                }
                
            }

            //Transmission Parameters
            if (e.Pgn == 127493)
            {
                pgn0x1F205LastMsg = DateTime.Now;
                pgn0x1F205 = (Pgn0x1F205)pgn0x1F205.DeserializeFields(e.Data).ToImperial();

                //Stbd Engine
                if (pgn0x1F205.EngineInstance == 1)
                {
                    gaugeStbdDrivePressure.Invoke(new MethodInvoker(() => { gaugeStbdDrivePressure.Value = Convert.ToDouble((pgn0x1F205.OilPressure).ToString("0")); }));
                }
            }

            //Engine Parameters (Dynamic)
            if (e.Pgn == 127489)
            {
                pgn0x1F201LastMsg = DateTime.Now;
                pgn0x1F201 = (Pgn0x1F201)pgn0x1F201.DeserializeFields(e.Data).ToImperial();

                //Stbd Engine
                if (pgn0x1F201.EngineInstance == 1)
                {
                    gaugeStbdWaterTemp.Invoke(new MethodInvoker(() => { gaugeStbdWaterTemp.Value = Convert.ToDouble(pgn0x1F201.EngineTemperature.ToString("0")); }));
                    gaugeStbdOilPressure.Invoke(new MethodInvoker(() => { gaugeStbdOilPressure.Value = Convert.ToDouble(pgn0x1F201.OilPressure.ToString("0")); }));
                    gaugeStbdVolts.Invoke(new MethodInvoker(() => { gaugeStbdVolts.Value = Convert.ToDouble(pgn0x1F201.AlternatorPotential.ToString("0.0")); }));
                    lblStbdHours.Invoke(new MethodInvoker(() => { lblStbdHours.Text = pgn0x1F201.EngineHours.ToString("0.0") + " HRS"; }));
                }
            }
        }

        private void PgnTimeoutTimer_Tick(object sender, EventArgs e)
        {
            //Get current time
            var dtNow = DateTime.Now;

            //Update Bus Status
            var lastBusMessageEt = dtNow - lastBusMessage;

            //Alarm Statuses
            var pgn0x1F20DLastMsgEt = dtNow - pgn0x1F20DLastMsg;
            if (pgn0x1F20DLastMsgEt.TotalSeconds > 5)
            {
                lblStbdWaterTempHigh.Invoke(new MethodInvoker(() => lblStbdWaterTempHigh.Hide()));
                lblStbdOilPressLow.Invoke(new MethodInvoker(() => lblStbdOilPressLow.Hide()));
                lblStbdDriveTempHigh.Invoke(new MethodInvoker(() => lblStbdDriveTempHigh.Hide()));
                lblStbdFuelPressLow.Invoke(new MethodInvoker(() => lblStbdFuelPressLow.Hide()));
            }
            else
            {
                lblStbdWaterTempHigh.Invoke(new MethodInvoker(() => lblStbdWaterTempHigh.Show()));
                lblStbdOilPressLow.Invoke(new MethodInvoker(() => lblStbdOilPressLow.Show()));
                lblStbdDriveTempHigh.Invoke(new MethodInvoker(() => lblStbdDriveTempHigh.Show()));
                lblStbdFuelPressLow.Invoke(new MethodInvoker(() => lblStbdFuelPressLow.Show()));
            }

            //Engine parameters rapid
            var pgn0x1F200LastMsgEt = dtNow - pgn0x1F200LastMsg;
            var yoctopucePwmRxLastMsgEt = dtNow - yoctopucePwmRxLastMsg;
            if (pgn0x1F200LastMsgEt.TotalSeconds > 5)
            {
                gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Hide()));
            }
            else
            {
                gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Show()));
            }


            //Engine parameters dynamic
            var pgn0x1F201LastMsgEt = dtNow - pgn0x1F201LastMsg;
            if (pgn0x1F201LastMsgEt.TotalSeconds > 5)
            {
                gaugeStbdWaterTemp.Invoke(new MethodInvoker(() => { gaugeStbdWaterTemp.Hide(); }));
                gaugeStbdOilPressure.Invoke(new MethodInvoker(() => { gaugeStbdOilPressure.Hide(); }));
                gaugeStbdVolts.Invoke(new MethodInvoker(() => { gaugeStbdVolts.Hide(); }));
                lblStbdVoltageLow.Invoke(new MethodInvoker(() => { lblStbdVoltageLow.Hide(); }));
                lblStbdHours.Invoke(new MethodInvoker(() => { lblStbdHours.Text = "--"; }));
            }
            else
            {
                gaugeStbdWaterTemp.Invoke(new MethodInvoker(() => { gaugeStbdWaterTemp.Show(); }));
                gaugeStbdOilPressure.Invoke(new MethodInvoker(() => { gaugeStbdOilPressure.Show(); }));
                gaugeStbdVolts.Invoke(new MethodInvoker(() => { gaugeStbdVolts.Show(); }));
                lblStbdVoltageLow.Invoke(new MethodInvoker(() => { lblStbdVoltageLow.Show(); }));
            }

            //Transmission parameters
            var pgn0x1F205LastMsgEt = dtNow - pgn0x1F205LastMsg;
            if (pgn0x1F205LastMsgEt.TotalSeconds > 5)
            {
                gaugeStbdDrivePressure.Invoke(new MethodInvoker(() => { gaugeStbdDrivePressure.Hide(); }));
            }
            else
            {
                gaugeStbdDrivePressure.Invoke(new MethodInvoker(() => { gaugeStbdDrivePressure.Show(); }));
            }
        }

        private void AlarmTimer_Tick(object sender, EventArgs e)
        {
            //Stbd alternator output voltage low
            if(lblStbdVoltageLow.IsHandleCreated)
                lblStbdVoltageLow.Invoke(new MethodInvoker(() =>
                {
                    if (gaugeStbdVolts.Value < 12.6)
                        lblStbdVoltageLow.BackColor = Color.Red;
                    else
                        lblStbdVoltageLow.BackColor = Color.FromArgb(56, 0, 0);
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
    }
}
