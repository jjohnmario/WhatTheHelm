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
            //Read NMEA2000 config


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
            //Engine RPM
            if(Program.Configuration.PortPropulsionN2KConfig.Rpm!=null)
                if(e.Message.SourceAddress == Program.Configuration.PortPropulsionN2KConfig.Rpm.Nmea2000Device.Address)
            {
                //PGN check
                if (e.Message.Pgn == Program.Configuration.PortPropulsionN2KConfig.Rpm.PGN)
                {
                    _pgn0x1F200 = (Pgn0x1F200)_pgn0x1F200.DeserializeFields(e.Message.Data).ToImperial();

                    //Instance check
                    if (_pgn0x1F200.EngineInstance == Program.Configuration.PortPropulsionN2KConfig.Rpm.Instance)
                    {
                        _pgn0x1F200LastMsg = DateTime.Now;
                        if (gaugeRpm.IsHandleCreated)
                            gaugeRpm.Invoke(new MethodInvoker(() => gaugeRpm.Value = _pgn0x1F200.EngineSpeed / 4));
                    }
                }
            }

            //Engine temperature
            if(Program.Configuration.PortPropulsionN2KConfig.EngineTemperature!=null)
                if(e.Message.SourceAddress == Program.Configuration.PortPropulsionN2KConfig.EngineTemperature.Nmea2000Device.Address)
            {
                //PGN check
                if(e.Message.Pgn == Program.Configuration.PortPropulsionN2KConfig.EngineTemperature.PGN)
                {
                    _pgn0x1F201 = (Pgn0x1F201)_pgn0x1F201.DeserializeFields(e.Message.Data).ToImperial();

                    //Instance check
                    if(_pgn0x1F201.EngineInstance == Program.Configuration.PortPropulsionN2KConfig.EngineTemperature.Instance)
                    {
                        _pgn0x1F201LastMsg = DateTime.Now;
                        gaugeWaterTemp.Invoke(new MethodInvoker(() => { gaugeWaterTemp.Value = Convert.ToDouble(_pgn0x1F201.EngineTemperature.ToString("0")); }));
                    }

                }
            }

            //Engine oil pressure
            if(Program.Configuration.PortPropulsionN2KConfig.OilPressure!=null)
                if(e.Message.SourceAddress == Program.Configuration.PortPropulsionN2KConfig.OilPressure.Nmea2000Device.Address)
            {
                //PGN check
                if (e.Message.Pgn == Program.Configuration.PortPropulsionN2KConfig.OilPressure.PGN)
                {
                    _pgn0x1F201 = (Pgn0x1F201)_pgn0x1F201.DeserializeFields(e.Message.Data).ToImperial();

                    //Instance check
                    if (_pgn0x1F201.EngineInstance == Program.Configuration.PortPropulsionN2KConfig.OilPressure.Instance)
                    {
                        _pgn0x1F201LastMsg = DateTime.Now;
                        gaugeOilPressure.Invoke(new MethodInvoker(() => { gaugeOilPressure.Value = Convert.ToDouble(_pgn0x1F201.OilPressure.ToString("0")); }));
                    }
                }
            }

            //Engine alarms
            if(Program.Configuration.PortPropulsionN2KConfig.EngineAlarms!=null)
                if(e.Message.SourceAddress == Program.Configuration.PortPropulsionN2KConfig.EngineAlarms.Nmea2000Device.Address)
            {
                //PGN check
                if(e.Message.Pgn == Program.Configuration.PortPropulsionN2KConfig.EngineAlarms.PGN)
                {
                    _pgn0x1F201 = (Pgn0x1F201)_pgn0x1F201.DeserializeFields(e.Message.Data).ToImperial();

                    //Instance check
                    if(_pgn0x1F201.EngineInstance == Program.Configuration.PortPropulsionN2KConfig.EngineAlarms.Instance)
                    {
                        _pgn0x1F201LastMsg = DateTime.Now;

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
            if(Program.Configuration.PortPropulsionN2KConfig.EngineHours != null)
                if (e.Message.SourceAddress == Program.Configuration.PortPropulsionN2KConfig.EngineHours.Nmea2000Device.Address)
            {
                //PGN check
                if(e.Message.Pgn == Program.Configuration.PortPropulsionN2KConfig.EngineHours.PGN)
                {
                    _pgn0x1F201 = (Pgn0x1F201)_pgn0x1F201.DeserializeFields(e.Message.Data).ToImperial();
                    
                    //Instance check
                    if(_pgn0x1F201.EngineInstance == Program.Configuration.PortPropulsionN2KConfig.EngineHours.Instance)
                    {
                        _pgn0x1F201LastMsg = DateTime.Now;
                        lblHours.Invoke(new MethodInvoker(() => { lblHours.Text = _pgn0x1F201.EngineHours.ToString("0.0") + " HRS"; }));
                    }
                }
            }

            //Transmission pressure
            if(Program.Configuration.PortPropulsionN2KConfig.TransPressure != null)
                if(e.Message.SourceAddress == Program.Configuration.PortPropulsionN2KConfig.TransPressure.Nmea2000Device.Address)
            {
                //PGN check
                if(e.Message.Pgn == Program.Configuration.PortPropulsionN2KConfig.TransPressure.PGN)
                {
                    _pgn0x1F205 = (Pgn0x1F205)_pgn0x1F205.DeserializeFields(e.Message.Data).ToImperial();

                    //Instance check
                    if(_pgn0x1F205.EngineInstance == Program.Configuration.PortPropulsionN2KConfig.TransPressure.Instance)
                    {
                        _pgn0x1F205LastMsg = DateTime.Now;
                        gaugeDrivePressure.Invoke(new MethodInvoker(() => { gaugeDrivePressure.Value = Convert.ToDouble((_pgn0x1F205.OilPressure).ToString("0")); }));
                    }
                }
            }

            //Transmission alarms
            if(Program.Configuration.PortPropulsionN2KConfig.TransAlarms != null)
                if(e.Message.SourceAddress == Program.Configuration.PortPropulsionN2KConfig.TransAlarms.Nmea2000Device.Address)
            {
                //PGN check
                if(e.Message.Pgn == Program.Configuration.PortPropulsionN2KConfig.TransAlarms.PGN)
                {
                    _pgn0x1F205 = (Pgn0x1F205)_pgn0x1F205.DeserializeFields(e.Message.Data).ToImperial();
                    //Instance check
                    if(_pgn0x1F205.EngineInstance == Program.Configuration.PortPropulsionN2KConfig.TransAlarms.Instance)
                    {
                        _pgn0x1F205LastMsg = DateTime.Now;
                        var discreteInputs = new BitArray(new int[] { _pgn0x1F205.DiscreteStatus1 });
                        //Trans temp high
                        if (lblDriveTempHigh.IsHandleCreated)
                            lblDriveTempHigh.Invoke(new MethodInvoker(() => { if (discreteInputs[1] == true) lblDriveTempHigh.BackColor = Color.Red; else lblDriveTempHigh.BackColor = Color.FromArgb(56, 0, 0); }));
                    }
                }
            }

            //Alternator potential
            if(Program.Configuration.PortPropulsionN2KConfig.AlternatorPotential != null)
                if (e.Message.SourceAddress == Program.Configuration.PortPropulsionN2KConfig.AlternatorPotential.Nmea2000Device.Address)
            {
                //PGN check
                if(e.Message.Pgn == Program.Configuration.PortPropulsionN2KConfig.AlternatorPotential.PGN)
                {//Battery instance 200
                    //Battery status
                    if(e.Message.Pgn == 127508)
                    {
                        _pgn0x1F214 = (Pgn0x1F214)_pgn0x1F214.DeserializeFields(e.Message.Data).ToImperial();

                        //Instance check
                        if(_pgn0x1F214.BatteryInstance == Program.Configuration.PortPropulsionN2KConfig.AlternatorPotential.Instance)
                        {
                            _pgn0x1F214LastMsg = DateTime.Now;
                            gaugeVolts.Invoke(new MethodInvoker(() => { gaugeVolts.Value = _pgn0x1F214.Voltage; }));
                        }

                    }
                    else if(e.Message.Pgn == 00000)
                    {

                    }
                    //Low battery alarm
                    if (lblVoltageLow.IsHandleCreated)
                        lblVoltageLow.Invoke(new MethodInvoker(() => { if (gaugeVolts.Value <= gaugeVolts.ErrorLimit) lblVoltageLow.BackColor = Color.Red; else lblVoltageLow.BackColor = Color.FromArgb(56, 0, 0); }));

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
                gaugeRpm.Invoke(new MethodInvoker(() => gaugeRpm.Hide()));
            }
            else
            {
                gaugeRpm.Invoke(new MethodInvoker(() => gaugeRpm.Show()));
            }
            
            //Engine parameters dynamic
            var pgn0x1F201LastMsgEt = dtNow - _pgn0x1F201LastMsg;
            if (pgn0x1F201LastMsgEt.TotalSeconds > 5)
            {
                gaugeWaterTemp.Invoke(new MethodInvoker(() => { gaugeWaterTemp.Hide(); }));
                gaugeOilPressure.Invoke(new MethodInvoker(() => { gaugeOilPressure.Hide(); }));
                lblHours.Invoke(new MethodInvoker(() => { lblHours.Text = "--"; }));
                lblWaterTempHigh.Invoke(new MethodInvoker(() => lblWaterTempHigh.Hide()));
                lblOilPressLow.Invoke(new MethodInvoker(() => lblOilPressLow.Hide()));
                lblDriveTempHigh.Invoke(new MethodInvoker(() => lblDriveTempHigh.Hide()));
                lblFuelPressLow.Invoke(new MethodInvoker(() => lblFuelPressLow.Hide()));
            }
            else
            {
                gaugeWaterTemp.Invoke(new MethodInvoker(() => { gaugeWaterTemp.Show(); }));
                gaugeOilPressure.Invoke(new MethodInvoker(() => { gaugeOilPressure.Show(); }));
                lblWaterTempHigh.Invoke(new MethodInvoker(() => lblWaterTempHigh.Show()));
                lblOilPressLow.Invoke(new MethodInvoker(() => lblOilPressLow.Show()));
                lblDriveTempHigh.Invoke(new MethodInvoker(() => lblDriveTempHigh.Show()));
                lblFuelPressLow.Invoke(new MethodInvoker(() => lblFuelPressLow.Show()));
            }

            //Transmission parameters
            var pgn0x1F205LastMsgEt = dtNow - _pgn0x1F205LastMsg;
            if (pgn0x1F205LastMsgEt.TotalSeconds > 5)
            {
                gaugeDrivePressure.Invoke(new MethodInvoker(() => { gaugeDrivePressure.Hide(); }));
            }
            else
            {
                gaugeDrivePressure.Invoke(new MethodInvoker(() => { gaugeDrivePressure.Show(); }));
            }

            //Battery status
            var pgn0x1F214LastMsgEt = dtNow - _pgn0x1F214LastMsg;
            if(pgn0x1F214LastMsgEt.TotalSeconds > 5)
            {
                gaugeVolts.Invoke(new MethodInvoker(() => { gaugeVolts.Hide(); }));
                lblVoltageLow.Invoke(new MethodInvoker(() => { lblVoltageLow.Hide(); }));
            }
            else
            {
                gaugeVolts.Invoke(new MethodInvoker(() => { gaugeVolts.Show(); }));
                lblVoltageLow.Invoke(new MethodInvoker(() => { lblVoltageLow.Show(); }));
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

        private void btnConfigNmea2000_Click(object sender, EventArgs e)
        {
            PropulsionNmea2000Config config = new PropulsionNmea2000Config(Program.Configuration.PortPropulsionN2KConfig, "Port Propulsion");
            var result = config.ShowDialog();
            if (result == DialogResult.OK)
            {
                Program.Configuration.PortPropulsionN2KConfig = config.NewPropulsionConfig;
                Program.Configuration.Save(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\WhatTheHelm", "config.json",Program.Configuration);
            }

        }
    }
}
