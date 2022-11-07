using WhatTheHelmCanLib.Messages;
using WhatTheHelmCanLib.ParameterGroups;
using WhatTheHelmCanLib.ParameterGroups.J1939;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections;

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
        private DateTime _pgn0x1F201LastMsg = new DateTime();
        private DateTime _pgn0x1F205LastMsg = new DateTime();
        private DateTime _pgn0x1F200LastMsg = new DateTime();
        private DateTime _pgn0x1F20DLastMsg = new DateTime();
        private IndicatorBankStatus[] _discreteStatus1 = new IndicatorBankStatus[16];
        private Pgn0x1F20D _pgn0x1F20D = new Pgn0x1F20D();
        private Pgn0x1F200 _pgn0x1F200 = new Pgn0x1F200();
        private Pgn0x1F205 _pgn0x1F205 = new Pgn0x1F205();
        private Pgn0x1F201 _pgn0x1F201 = new Pgn0x1F201();
        private Pgn0x1F214 _pgn0x1F214 = new Pgn0x1F214();

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
            Program.CanGateway.MessageRecieved += CanGateway_MessageRecieved;
            Timer pgnTimeoutTimer = new Timer();
            pgnTimeoutTimer.Interval = 2000;
            pgnTimeoutTimer.Tick += PgnTimeoutTimer_Tick;
            pgnTimeoutTimer.Start();
            Timer alarmTimer = new Timer();
            alarmTimer.Interval = 100;
            alarmTimer.Tick += AlarmTimer_Tick;
            alarmTimer.Start();
            Timer networkStatusTimer = new Timer();
            networkStatusTimer.Interval = 100;
            networkStatusTimer.Tick += NetworkStatusTimer_Tick;
            networkStatusTimer.Start();
        }

        private void CanGateway_MessageRecieved(object sender, CanMessageArgs e)
        {
            //Binary switch status (from Seagauge)
            if (e.Message.ParameterGroupNumber == 127501)
            {
                _pgn0x1F20DLastMsg = DateTime.Now;
                _pgn0x1F20D = (Pgn0x1F20D)_pgn0x1F20D.DeserializeFields(e.Message.Data).ToImperial();
                _discreteStatus1 = _pgn0x1F20D.IndicatorBankStatus;
            }

            //Engine Parameters (Rapid)
            if (e.Message.ParameterGroupNumber == 127488)
            {
                _pgn0x1F200LastMsg = DateTime.Now;
                if (Program.Configuration.RpmSource == RpmSource.NMEA2000)
                {
                    _pgn0x1F200 = (Pgn0x1F200)_pgn0x1F200.DeserializeFields(e.Message.Data).ToImperial();

                    //Port Engine
                    if (_pgn0x1F200.EngineInstance == 0)
                    {
                        if (gaugePortRpm.IsHandleCreated)
                            gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Value = _pgn0x1F200.EngineSpeed / 4));
                    }
                }
            }

            //Transmission Parameters
            if (e.Message.ParameterGroupNumber == 127493)
            {
                _pgn0x1F205LastMsg = DateTime.Now;
                _pgn0x1F205 = (Pgn0x1F205)_pgn0x1F205.DeserializeFields(e.Message.Data).ToImperial();

                //Port Engine
                if (_pgn0x1F205.EngineInstance == 0)
                {
                    gaugePortDrivePressure.Invoke(new MethodInvoker(() => { gaugePortDrivePressure.Value = Convert.ToDouble((_pgn0x1F205.OilPressure).ToString("0")); }));
                }
            }

            //Engine Parameters (Dynamic)
            if (e.Message.ParameterGroupNumber == 127489)
            {
                _pgn0x1F201LastMsg = DateTime.Now;
                _pgn0x1F201 = (Pgn0x1F201)_pgn0x1F201.DeserializeFields(e.Message.Data).ToImperial();

                //Port Engine
                if (_pgn0x1F201.EngineInstance == 0)
                {
                    //Alarm inputs
                    var discreteInputs = new BitArray(new int[] { _pgn0x1F201.DiscreteStatus1 });
                    _discreteStatus1[0] = (IndicatorBankStatus)Convert.ToUInt16(discreteInputs[0]);
                    _discreteStatus1[1] = (IndicatorBankStatus)Convert.ToUInt16(discreteInputs[1]);
                    _discreteStatus1[2] = (IndicatorBankStatus)Convert.ToUInt16(discreteInputs[2]);
                    _discreteStatus1[3] = (IndicatorBankStatus)Convert.ToUInt16(discreteInputs[3]);
                    //Water temp
                    gaugePortWaterTemp.Invoke(new MethodInvoker(() => { gaugePortWaterTemp.Value = Convert.ToDouble(_pgn0x1F201.EngineTemperature.ToString("0")); }));
                    //Oil pressure
                    gaugePortOilPressure.Invoke(new MethodInvoker(() => { gaugePortOilPressure.Value = Convert.ToDouble(_pgn0x1F201.OilPressure.ToString("0")); }));
                    //Engine hours
                    lblPortHours.Invoke(new MethodInvoker(() => { lblPortHours.Text = _pgn0x1F201.EngineHours.ToString("0.0") + " HRS"; }));
                }
            }

            //Battery Status
            if (e.Message.ParameterGroupNumber == 127508)
            {
                _pgn0x1F214 = (Pgn0x1F214)_pgn0x1F214.DeserializeFields(e.Message.Data).ToImperial();

                if(_pgn0x1F214.BatteryInstance == 200)
                {
                    //Volts
                    gaugePortVolts.Invoke(new MethodInvoker(() => { gaugePortVolts.Value = _pgn0x1F214.Voltage; }));
                }
            }
        }

        private void PgnTimeoutTimer_Tick(object sender, EventArgs e)
        {
            //Get current time
            var dtNow = DateTime.Now;

            //Update Bus Status
            var lastBusMessageEt = dtNow - Program.CanGateway.LastRead;
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

            //Engine parameters rapid
            var pgn0x1F200LastMsgEt = dtNow - _pgn0x1F200LastMsg;
            if (pgn0x1F200LastMsgEt.TotalSeconds > 5)
            {
                gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Hide()));
            }
            else
            {
                gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Show()));
            }
            
            //Engine parameters dynamic
            var pgn0x1F201LastMsgEt = dtNow - _pgn0x1F201LastMsg;
            if (pgn0x1F201LastMsgEt.TotalSeconds > 5)
            {
                gaugePortWaterTemp.Invoke(new MethodInvoker(() => { gaugePortWaterTemp.Hide(); }));
                gaugePortOilPressure.Invoke(new MethodInvoker(() => { gaugePortOilPressure.Hide(); }));
                gaugePortVolts.Invoke(new MethodInvoker(() => { gaugePortVolts.Hide(); }));
                lblPortVoltageLow.Invoke(new MethodInvoker(() => { lblPortVoltageLow.Hide(); }));
                lblPortHours.Invoke(new MethodInvoker(() => { lblPortHours.Text = "--"; }));
                lblPortWaterTempHigh.Invoke(new MethodInvoker(() => lblPortWaterTempHigh.Hide()));
                lblPortOilPressLow.Invoke(new MethodInvoker(() => lblPortOilPressLow.Hide()));
                lblPortDriveTempHigh.Invoke(new MethodInvoker(() => lblPortDriveTempHigh.Hide()));
                lblPortFuelPressLow.Invoke(new MethodInvoker(() => lblPortFuelPressLow.Hide()));
            }
            else
            {
                gaugePortWaterTemp.Invoke(new MethodInvoker(() => { gaugePortWaterTemp.Show(); }));
                gaugePortOilPressure.Invoke(new MethodInvoker(() => { gaugePortOilPressure.Show(); }));
                gaugePortVolts.Invoke(new MethodInvoker(() => { gaugePortVolts.Show(); }));
                lblPortVoltageLow.Invoke(new MethodInvoker(() => { lblPortVoltageLow.Show(); }));
                lblPortWaterTempHigh.Invoke(new MethodInvoker(() => lblPortWaterTempHigh.Show()));
                lblPortOilPressLow.Invoke(new MethodInvoker(() => lblPortOilPressLow.Show()));
                lblPortDriveTempHigh.Invoke(new MethodInvoker(() => lblPortDriveTempHigh.Show()));
                lblPortFuelPressLow.Invoke(new MethodInvoker(() => lblPortFuelPressLow.Show()));
            }

            //Transmission parameters
            var pgn0x1F205LastMsgEt = dtNow - _pgn0x1F205LastMsg;
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
            if (lblPortVoltageLow.IsHandleCreated)
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
                    if (_discreteStatus1 != null)
                    {
                        if (_discreteStatus1[0] == IndicatorBankStatus.Off)
                            lblPortWaterTempHigh.BackColor = Color.Red;
                        else
                            lblPortWaterTempHigh.BackColor = Color.FromArgb(56, 0, 0);
                    }
                }));

            //Port oil pressure low
            if (lblPortOilPressLow.IsHandleCreated)
                lblPortOilPressLow.Invoke(new MethodInvoker(() =>
                {
                    if (_discreteStatus1 != null)
                    {
                        if (_discreteStatus1[1] == IndicatorBankStatus.Off)
                            lblPortOilPressLow.BackColor = Color.Red;
                        else
                            lblPortOilPressLow.BackColor = Color.FromArgb(56, 0, 0);
                    }
                }));

            //Port drive temp high
            if (lblPortDriveTempHigh.IsHandleCreated)
                lblPortDriveTempHigh.Invoke(new MethodInvoker(() =>
                {
                    if (_discreteStatus1 != null)
                    {
                        if (_discreteStatus1[2] == IndicatorBankStatus.Off)
                            lblPortDriveTempHigh.BackColor = Color.Red;
                        else
                            lblPortDriveTempHigh.BackColor = Color.FromArgb(56, 0, 0);
                    }
                }));

            //Port fuel pressure low
            if (lblPortFuelPressLow.IsHandleCreated)
                lblPortFuelPressLow.Invoke(new MethodInvoker(() =>
                {
                    if (_discreteStatus1 != null)
                    {
                        if (_discreteStatus1[3] == IndicatorBankStatus.Off)
                            lblPortFuelPressLow.BackColor = Color.Red;
                        else
                            lblPortFuelPressLow.BackColor = Color.FromArgb(56, 0, 0);
                    }
                }));
        }

        private void NetworkStatusTimer_Tick(object sender, EventArgs e)
        {
            //Update CAN message queue count
            if (lblCanMsgQueue.IsHandleCreated)
            {
                lblCanMsgQueue.Invoke(new MethodInvoker(() => lblCanMsgQueue.Text = Program.CanGateway.MessageQueueCount.ToString()));
            }

            //Update last bus scan
            if (lblLastBusScan.IsHandleCreated)
            {
                lblLastBusScan.Invoke(new MethodInvoker(() => lblLastBusScan.Text = Program.CanGateway.LastRead.ToString("HH:mm:ss:FFF")));
            }
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
