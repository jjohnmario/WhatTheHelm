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
        private DateTime _engineTempLastMsg = new DateTime();
        private DateTime _oilPressLastMsg = new DateTime();
        private DateTime _engineAlarmsLastMsg = new DateTime();
        private DateTime _transPressLastMsg = new DateTime();
        private DateTime _transAlarmsLastMsg = new DateTime();
        private DateTime _alternatorPotentialLastMsg = new DateTime();
        private DateTime _rpmLastMsg = new DateTime();
        private Pgn0x1F200 _pgn0x1F200 = new Pgn0x1F200();
        private Pgn0x1F205 _pgn0x1F205 = new Pgn0x1F205();
        private Pgn0x1F201 _pgn0x1F201 = new Pgn0x1F201();
        private Pgn0x1F214 _pgn0x1F214 = new Pgn0x1F214();

        public StbdGauges(List<KeyValuePair<Screen, Type>> screenMap)
        {
            foreach (KeyValuePair<Screen, Type> kvp in screenMap)
            {
                if (kvp.Value == typeof(StbdGauges))
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

        public StbdGauges()
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
            pgnTimeoutTimer.Interval = 10000;
            pgnTimeoutTimer.Tick += PgnTimeoutTimer_Tick;
            pgnTimeoutTimer.Start();
        }

        private void CanGateway_MessageRecieved(object sender, CanMessageArgs e)
        {
            if (Program.RunningConfiguration != null)
            {
                //Engine RPM
                if (Program.RunningConfiguration.StbdPropulsionN2KConfig.Rpm != null)
                    if (e.Message.SourceAddress == Program.RunningConfiguration.StbdPropulsionN2KConfig.Rpm.Nmea2000Device.Address)
                    {
                        //PGN check
                        if (e.Message.Pgn == Program.RunningConfiguration.StbdPropulsionN2KConfig.Rpm.PGN)
                        {
                            _pgn0x1F200 = (Pgn0x1F200)_pgn0x1F200.DeserializeFields(e.Message.Data).ToImperial();

                            //Instance check
                            if (_pgn0x1F200.EngineInstance == Program.RunningConfiguration.StbdPropulsionN2KConfig.Rpm.Instance)
                            {
                                _rpmLastMsg = DateTime.Now;
                                gaugeRpm.SetRpm(_pgn0x1F200.EngineSpeed / 4);
                            }
                        }
                    }

                //Engine temperature
                if (Program.RunningConfiguration.StbdPropulsionN2KConfig.EngineTemperature != null)
                    if (e.Message.SourceAddress == Program.RunningConfiguration.StbdPropulsionN2KConfig.EngineTemperature.Nmea2000Device.Address)
                    {
                        //PGN check
                        if (e.Message.Pgn == Program.RunningConfiguration.StbdPropulsionN2KConfig.EngineTemperature.PGN)
                        {
                            _pgn0x1F201 = (Pgn0x1F201)_pgn0x1F201.DeserializeFields(e.Message.Data).ToImperial();

                            //Instance check
                            if (_pgn0x1F201.EngineInstance == Program.RunningConfiguration.StbdPropulsionN2KConfig.EngineTemperature.Instance)
                            {
                                _engineTempLastMsg = DateTime.Now;
                                gaugeWaterTemp.SetTemp(Convert.ToInt32(_pgn0x1F201.EngineTemperature));
                            }
                        }
                    }

                //Engine oil pressure
                if (Program.RunningConfiguration.StbdPropulsionN2KConfig.OilPressure != null)
                    if (e.Message.SourceAddress == Program.RunningConfiguration.StbdPropulsionN2KConfig.OilPressure.Nmea2000Device.Address)
                    {
                        //PGN check
                        if (e.Message.Pgn == Program.RunningConfiguration.StbdPropulsionN2KConfig.OilPressure.PGN)
                        {
                            _pgn0x1F201 = (Pgn0x1F201)_pgn0x1F201.DeserializeFields(e.Message.Data).ToImperial();

                            //Instance check
                            if (_pgn0x1F201.EngineInstance == Program.RunningConfiguration.StbdPropulsionN2KConfig.OilPressure.Instance)
                            {
                                _oilPressLastMsg = DateTime.Now;
                                gaugeOilPressure.SetPressure(Convert.ToInt32(_pgn0x1F201.OilPressure)); 
                            }
                        }
                    }

                //Engine alarms
                if (Program.RunningConfiguration.StbdPropulsionN2KConfig.EngineAlarms != null)
                    if (e.Message.SourceAddress == Program.RunningConfiguration.StbdPropulsionN2KConfig.EngineAlarms.Nmea2000Device.Address)
                    {
                        //PGN check
                        if (e.Message.Pgn == Program.RunningConfiguration.StbdPropulsionN2KConfig.EngineAlarms.PGN)
                        {
                            _pgn0x1F201 = (Pgn0x1F201)_pgn0x1F201.DeserializeFields(e.Message.Data).ToImperial();

                            //Instance check
                            if (_pgn0x1F201.EngineInstance == Program.RunningConfiguration.StbdPropulsionN2KConfig.EngineAlarms.Instance)
                            {
                                _engineAlarmsLastMsg = DateTime.Now;

                                var discreteInputs = new BitArray(new int[] { _pgn0x1F201.DiscreteStatus1 });

                                //Engine temp high
                                if (lblWaterTempHigh.IsHandleCreated)
                                    lblWaterTempHigh.Invoke(new MethodInvoker(() => { if (discreteInputs[1] == true) lblWaterTempHigh.BackColor = Color.Red; else lblWaterTempHigh.BackColor = Color.FromArgb(56, 0, 0); }));

                                //Oil pressure low
                                if (lblOilPressLow.IsHandleCreated)
                                    lblOilPressLow.Invoke(new MethodInvoker(() => { if (discreteInputs[2] == true) lblOilPressLow.BackColor = Color.Red; else lblOilPressLow.BackColor = Color.FromArgb(56, 0, 0); }));

                                //Fuel pressure low
                                if (lblFuelPressLow.IsHandleCreated)
                                    lblFuelPressLow.Invoke(new MethodInvoker(() => { if (discreteInputs[4] == true) lblFuelPressLow.BackColor = Color.Red; else lblFuelPressLow.BackColor = Color.FromArgb(56, 0, 0); }));
                            }
                        }
                    }

                //Engine hours
                if (Program.RunningConfiguration.StbdPropulsionN2KConfig.EngineHours != null)
                    if (e.Message.SourceAddress == Program.RunningConfiguration.StbdPropulsionN2KConfig.EngineHours.Nmea2000Device.Address)
                    {
                        //PGN check
                        if (e.Message.Pgn == Program.RunningConfiguration.StbdPropulsionN2KConfig.EngineHours.PGN)
                        {
                            _pgn0x1F201 = (Pgn0x1F201)_pgn0x1F201.DeserializeFields(e.Message.Data).ToImperial();

                            //Instance check
                            if (_pgn0x1F201.EngineInstance == Program.RunningConfiguration.StbdPropulsionN2KConfig.EngineHours.Instance)
                            {
                                var arr = string.Format("{0:0000.0}", Math.Truncate(_pgn0x1F201.EngineHours * 10) / 10).ToCharArray();
                                int thousands = Convert.ToInt32(arr[arr.Length - 6].ToString());
                                int hundreds = Convert.ToInt32(arr[arr.Length - 5].ToString());
                                int tens = Convert.ToInt32(arr[arr.Length - 4].ToString());
                                int ones = Convert.ToInt32(arr[arr.Length - 3].ToString());
                                int tenths = Convert.ToInt32(arr[arr.Length - 1].ToString());
                                gaugeRpm.SetEngineHours(thousands, hundreds, tens, ones, tenths);
                            }
                        }
                    }

                //Transmission pressure
                if (Program.RunningConfiguration.StbdPropulsionN2KConfig.TransPressure != null)
                    if (e.Message.SourceAddress == Program.RunningConfiguration.StbdPropulsionN2KConfig.TransPressure.Nmea2000Device.Address)
                    {
                        //PGN check
                        if (e.Message.Pgn == Program.RunningConfiguration.StbdPropulsionN2KConfig.TransPressure.PGN)
                        {
                            _pgn0x1F205 = (Pgn0x1F205)_pgn0x1F205.DeserializeFields(e.Message.Data).ToImperial();

                            //Instance check
                            if (_pgn0x1F205.EngineInstance == Program.RunningConfiguration.StbdPropulsionN2KConfig.TransPressure.Instance)
                            {
                                _transPressLastMsg = DateTime.Now;
                                gaugeDrivePressure.SetPressure(Convert.ToInt32(_pgn0x1F205.OilPressure));
                            }
                        }
                    }

                //Transmission alarms
                if (Program.RunningConfiguration.StbdPropulsionN2KConfig.TransAlarms != null)
                    if (e.Message.SourceAddress == Program.RunningConfiguration.StbdPropulsionN2KConfig.TransAlarms.Nmea2000Device.Address)
                    {
                        //PGN check
                        if (e.Message.Pgn == Program.RunningConfiguration.StbdPropulsionN2KConfig.TransAlarms.PGN)
                        {
                            _pgn0x1F205 = (Pgn0x1F205)_pgn0x1F205.DeserializeFields(e.Message.Data).ToImperial();
                            //Instance check
                            if (_pgn0x1F205.EngineInstance == Program.RunningConfiguration.StbdPropulsionN2KConfig.TransAlarms.Instance)
                            {
                                _transAlarmsLastMsg = DateTime.Now;
                                var discreteInputs = new BitArray(new int[] { _pgn0x1F205.DiscreteStatus1 });
                                //Trans temp high
                                if (lblDriveTempHigh.IsHandleCreated)
                                    lblDriveTempHigh.Invoke(new MethodInvoker(() => { if (discreteInputs[1] == true) lblDriveTempHigh.BackColor = Color.Red; else lblDriveTempHigh.BackColor = Color.FromArgb(56, 0, 0); }));
                            }
                        }
                    }

                //Alternator potential
                if (Program.RunningConfiguration.StbdPropulsionN2KConfig.AlternatorPotential != null)
                    if (e.Message.SourceAddress == Program.RunningConfiguration.StbdPropulsionN2KConfig.AlternatorPotential.Nmea2000Device.Address)
                    {
                        //PGN check
                        if (e.Message.Pgn == Program.RunningConfiguration.StbdPropulsionN2KConfig.AlternatorPotential.PGN)
                        {
                            //Battery status
                            if (e.Message.Pgn == 127508)
                            {
                                _pgn0x1F214 = (Pgn0x1F214)_pgn0x1F214.DeserializeFields(e.Message.Data).ToImperial();

                                //Instance check
                                if (_pgn0x1F214.BatteryInstance == Program.RunningConfiguration.StbdPropulsionN2KConfig.AlternatorPotential.Instance)
                                {
                                    _alternatorPotentialLastMsg = DateTime.Now;
                                    gaugeVolts.SetVolts(_pgn0x1F214.Voltage);
                                }

                            }
                        }
                    }
            }
        }

        private void PgnTimeoutTimer_Tick(object sender, EventArgs e)
        {
            //Get current time
            var dtNow = DateTime.Now;

            //Engine RPM
            var rpmLastMsgEt = dtNow - _rpmLastMsg;
            if (rpmLastMsgEt.TotalSeconds > 5)
                gaugeRpm.Visibility = System.Windows.Visibility.Hidden;
            else
                gaugeRpm.Visibility = System.Windows.Visibility.Visible;

            //Engine temperature
            var engineTempLastMsgEt = dtNow - _engineTempLastMsg;
            if (engineTempLastMsgEt.TotalSeconds > 5)
                gaugeWaterTemp.Visibility = System.Windows.Visibility.Hidden;
            else
                gaugeWaterTemp.Visibility = System.Windows.Visibility.Visible;

            //Oil pressure
            var oilPressLastMsgEt = dtNow - _oilPressLastMsg;
            if (oilPressLastMsgEt.TotalSeconds > 5)
                gaugeOilPressure.Visibility = System.Windows.Visibility.Hidden;
            else
                gaugeOilPressure.Visibility = System.Windows.Visibility.Visible;

            //Engine alarms
            var engineAlarmsLastMsgEt = dtNow - _engineAlarmsLastMsg;
            if (engineAlarmsLastMsgEt.TotalSeconds > 5)
            {
                lblWaterTempHigh.Invoke(new MethodInvoker(() => lblWaterTempHigh.Hide()));
                lblOilPressLow.Invoke(new MethodInvoker(() => lblOilPressLow.Hide()));
                lblFuelPressLow.Invoke(new MethodInvoker(() => lblFuelPressLow.Hide()));
            }
            else
            {
                lblWaterTempHigh.Invoke(new MethodInvoker(() => lblWaterTempHigh.Show()));
                lblOilPressLow.Invoke(new MethodInvoker(() => lblOilPressLow.Show()));
                lblFuelPressLow.Invoke(new MethodInvoker(() => lblFuelPressLow.Show()));
            }

            //Transmission pressure
            var transPressLastMsgEt = dtNow - _transPressLastMsg;
            if (transPressLastMsgEt.TotalSeconds > 5)
                gaugeDrivePressure.Visibility = System.Windows.Visibility.Hidden;
            else
                gaugeDrivePressure.Visibility = System.Windows.Visibility.Visible;

            //Transmission alarms
            var transAlarmsLastMsgEt = dtNow - _transAlarmsLastMsg;
            if (transAlarmsLastMsgEt.TotalSeconds > 5)
                lblDriveTempHigh.Invoke(new MethodInvoker(() => lblDriveTempHigh.Hide()));
            else
                lblDriveTempHigh.Invoke(new MethodInvoker(() => lblDriveTempHigh.Show()));

            //Alternator potential
            var alternatorPotentialLastMsgEt = dtNow - _alternatorPotentialLastMsg;
            if (alternatorPotentialLastMsgEt.TotalSeconds > 5)
                gaugeVolts.Visibility = System.Windows.Visibility.Hidden;
            else
                gaugeVolts.Visibility = System.Windows.Visibility.Visible;
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

        private void btnConfigNmea2000_Click(object sender, EventArgs e)
        {
            PropulsionNmea2000Config config = new PropulsionNmea2000Config(Program.Configuration.StbdPropulsionN2KConfig, "Starboard Propulsion");
            var result = config.ShowDialog();
            if (result == DialogResult.OK)
            {
                Program.Configuration.StbdPropulsionN2KConfig = config.NewPropulsionConfig;
                Program.Configuration.Save(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\WhatTheHelm", "config.json", Program.Configuration);
                Program.InitializeConfiguration();
            }
        }
    }
}
