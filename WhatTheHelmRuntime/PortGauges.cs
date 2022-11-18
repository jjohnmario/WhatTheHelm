using WhatTheHelmCanLib.Messages;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
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
        private DateTime _pgn0x1F214LastMsg = new DateTime();
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
            Timer networkStatusTimer = new Timer();
            networkStatusTimer.Interval = 100;
            networkStatusTimer.Tick += NetworkStatusTimer_Tick;
            networkStatusTimer.Start();
        }

        private void CanGateway_MessageRecieved(object sender, CanMessageArgs e)
        {
            //Engine Parameters (Rapid)
            if (e.Message.Pgn == 127488)
            {
                _pgn0x1F200LastMsg = DateTime.Now;
                _pgn0x1F200 = (Pgn0x1F200)_pgn0x1F200.DeserializeFields(e.Message.Data).ToImperial();

                //Port Engine
                if (_pgn0x1F200.EngineInstance == 0)
                {
                    if (gaugePortRpm.IsHandleCreated)
                        gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Value = _pgn0x1F200.EngineSpeed / 4));
                }
                
            }

            //Transmission Parameters
            if (e.Message.Pgn == 127493)
            {
                _pgn0x1F205LastMsg = DateTime.Now;
                _pgn0x1F205 = (Pgn0x1F205)_pgn0x1F205.DeserializeFields(e.Message.Data).ToImperial();

                //Port Engine
                if (_pgn0x1F205.EngineInstance == 0)
                {
                    /*
                     *  Alarm inputs
                     */
                    var discreteInputs = new BitArray(new int[] { _pgn0x1F205.DiscreteStatus1 });
                    //Port drive temp high
                    if (lblPortDriveTempHigh.IsHandleCreated)
                        lblPortDriveTempHigh.Invoke(new MethodInvoker(() => { if (discreteInputs[1] == true) lblPortDriveTempHigh.BackColor = Color.Red; else lblPortDriveTempHigh.BackColor = Color.FromArgb(56, 0, 0); }));
                    /*
                     * Gauge inputs
                     */
                    gaugePortDrivePressure.Invoke(new MethodInvoker(() => { gaugePortDrivePressure.Value = Convert.ToDouble((_pgn0x1F205.OilPressure).ToString("0")); }));
                }
            }

            //Engine Parameters (Dynamic)
            if (e.Message.Pgn == 127489)
            {
                _pgn0x1F201LastMsg = DateTime.Now;
                _pgn0x1F201 = (Pgn0x1F201)_pgn0x1F201.DeserializeFields(e.Message.Data).ToImperial();

                //Port Engine
                if (_pgn0x1F201.EngineInstance == 0)
                {
                    /*
                     * Alarm inputs
                     */

                    var discreteInputs = new BitArray(new int[] { _pgn0x1F201.DiscreteStatus1 });

                    //Port water temp high
                    if (lblPortWaterTempHigh.IsHandleCreated)
                        lblPortWaterTempHigh.Invoke(new MethodInvoker(() => {if (discreteInputs[1] == true) lblPortWaterTempHigh.BackColor = Color.Red; else lblPortWaterTempHigh.BackColor = Color.FromArgb(56, 0, 0); }));

                    //Port oil pressure low
                    if (lblPortOilPressLow.IsHandleCreated)
                        lblPortOilPressLow.Invoke(new MethodInvoker(() => { if (discreteInputs[2] == true) lblPortOilPressLow.BackColor = Color.Red; else lblPortOilPressLow.BackColor = Color.FromArgb(56, 0, 0); }));

                    //Port fuel pressure low
                    if (lblPortFuelPressLow.IsHandleCreated)
                        lblPortFuelPressLow.Invoke(new MethodInvoker(() => {if (discreteInputs[4] == true)                               lblPortFuelPressLow.BackColor = Color.Red;else lblPortFuelPressLow.BackColor = Color.FromArgb(56, 0, 0);}));
                    /*
                     * Gauge inputs
                     */

                    //Port Water temp
                    gaugePortWaterTemp.Invoke(new MethodInvoker(() => { gaugePortWaterTemp.Value = Convert.ToDouble(_pgn0x1F201.EngineTemperature.ToString("0")); }));

                    //Port Oil pressure
                    gaugePortOilPressure.Invoke(new MethodInvoker(() => { gaugePortOilPressure.Value = Convert.ToDouble(_pgn0x1F201.OilPressure.ToString("0")); }));

                    //PortEngine hours
                    lblPortHours.Invoke(new MethodInvoker(() => { lblPortHours.Text = _pgn0x1F201.EngineHours.ToString("0.0") + " HRS"; }));
                }
            }

            //Battery Status
            if (e.Message.Pgn == 127508)
            {
                _pgn0x1F214LastMsg = DateTime.Now;
                _pgn0x1F214 = (Pgn0x1F214)_pgn0x1F214.DeserializeFields(e.Message.Data).ToImperial();

                //Port battery
                if(_pgn0x1F214.BatteryInstance == 200)
                {
                    //Port battery volts
                    gaugePortVolts.Invoke(new MethodInvoker(() => { gaugePortVolts.Value = _pgn0x1F214.Voltage; }));
                    //Port alternator output voltage low
                    if (lblPortVoltageLow.IsHandleCreated)
                        lblPortVoltageLow.Invoke(new MethodInvoker(() => { if (gaugePortVolts.Value <= gaugePortVolts.ErrorLimit) lblPortVoltageLow.BackColor = Color.Red; else lblPortVoltageLow.BackColor = Color.FromArgb(56, 0, 0); }));
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

            //Battery status
            var pgn0x1F214LastMsgEt = dtNow - _pgn0x1F214LastMsg;
            if(pgn0x1F214LastMsgEt.TotalSeconds > 5)
            {
                gaugePortVolts.Invoke(new MethodInvoker(() => { gaugePortVolts.Hide(); }));
                lblPortVoltageLow.Invoke(new MethodInvoker(() => { lblPortVoltageLow.Hide(); }));
            }
            else
            {
                gaugePortVolts.Invoke(new MethodInvoker(() => { gaugePortVolts.Show(); }));
                lblPortVoltageLow.Invoke(new MethodInvoker(() => { lblPortVoltageLow.Show(); }));
            }
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
            //ConfigurationMenu configMenu = new ConfigurationMenu(Program.Configuration);
            //var results = configMenu.ShowDialog();
            //if (results != DialogResult.Cancel)
            //{
            //    Program.Configuration = configMenu.Configuration;
            //    Program.Configuration.Save();
            //}
            //configMenu.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nmea2000Config config = new Nmea2000Config();
            config.ShowDialog();
        }
    }
}
