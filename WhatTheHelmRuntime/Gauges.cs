using CanLib.Messages;
using CanLib.ParameterGroups;
using CanLib.ParameterGroups.J1939;
using CanLib.ParameterGroups.NMEA2000;
using WhatTheHelmRuntime.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WhatTheHelmRuntime;

namespace Dashboard
{
    public partial class Gauges : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

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
        IndicatorBankStatus[] SeaGaugeIndicatorStatus;
        Color gaugePortRpmBorderLast;
        Color gaugeStbdRpmBorderLast;


        public Gauges(List<KeyValuePair<Screen,Type>> screenMap)
        {
           foreach(KeyValuePair<Screen,Type> kvp in screenMap)
            {
                if (kvp.Value == typeof(Process))
                {
                    //Find OpenCpn executable
                    string[] paths = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "opencpn.exe", SearchOption.AllDirectories);

                    //If OpenCpn is found, see if an instance process is running.  If not, create a process.
                    if (paths.Count() > 0)
                    {
                        var processes = Process.GetProcessesByName("opencpn.exe");
                        if (processes.Count() > 0)
                        {
                            foreach (Process p in processes)
                            {
                                SetWindowPos(p.MainWindowHandle, IntPtr.Zero, kvp.Key.WorkingArea.Left, kvp.Key.WorkingArea.Top, kvp.Key.WorkingArea.Width, kvp.Key.WorkingArea.Height, 0xC);
                            }
                        }
                        else
                        {
                            Process p = Process.Start(paths[0]);
                            p.WaitForInputIdle();
                            SetWindowPos(p.MainWindowHandle, IntPtr.Zero, kvp.Key.WorkingArea.Left, kvp.Key.WorkingArea.Top, kvp.Key.WorkingArea.Width, kvp.Key.WorkingArea.Height, 0xC);
                        }
                    }
                }
                else
                {
                    if(kvp.Value == typeof(TrimControl))
                    {
                        TrimControl tc = new TrimControl();
                        tc.Bounds = kvp.Key.Bounds;
                        tc.StartPosition = FormStartPosition.Manual;
                        tc.Show();
                    }
                    else if(kvp.Value == typeof(SwitchPanel))
                    {
                        SwitchPanel sp = new SwitchPanel();
                        sp.Bounds = kvp.Key.Bounds;
                        sp.StartPosition = FormStartPosition.Manual;
                        sp.Show();
                    }
                }
            }

            InitializeComponent();
            this.MinimumSize = new Size() { Height = 800, Width = 1280 };
            this.MaximumSize = new Size() { Height = 800, Width = 1280 };
            Program.CanGateWayListener.NewMessage += CanGateWayListener_NewMessage;
            gaugePortRpmBorderLast = gaugePortRpm.Border.Color;
            gaugeStbdRpmBorderLast = gaugeStbdRpm.Border.Color;
            Timer t1 = new Timer();
            t1.Interval = 5000;
            t1.Tick += PgnTimeoutTimer_Tick;
            t1.Start();
            Timer t2 = new Timer();
            t2.Interval = 500;
            t2.Tick += AlarmTimer_Tick;
            t2.Start();
            try
            {
                SoundPlayer depthLowPlayer = new SoundPlayer(Resources.TF014);
                depthLowPlayer.Load();
                SoundPlayer depthLowLowPlayer = new SoundPlayer(Resources.TF023);
                depthLowLowPlayer.Load();
                System.Threading.Tasks.Task.Run(() => DepthAlarmLowLoop(depthLowPlayer));
                System.Threading.Tasks.Task.Run(() => DepthAlarmLowLowLoop(depthLowLowPlayer));
            }
            catch
            {
                return;
            }
        }

        public Gauges()
        {
            InitializeComponent();
            this.MinimumSize = new Size() { Height = 800, Width = 1280 };
            this.MaximumSize = new Size() { Height = 800, Width = 1280 };
            //Program.CanGateWayListener.NewMessage += CanGateWayListener_NewMessage;
            Program.YoctoPwmRx.NewData += YoctoPwmRx_NewData;
            Timer pgnTimeoutTimer = new Timer();
            pgnTimeoutTimer.Interval = 5000;
            pgnTimeoutTimer.Tick += PgnTimeoutTimer_Tick;
            pgnTimeoutTimer.Start();
            Timer alarmTimer = new Timer();
            alarmTimer.Interval = 500;
            alarmTimer.Tick += AlarmTimer_Tick;
            alarmTimer.Start();
            try
            {
                SoundPlayer depthLowPlayer = new SoundPlayer(Resources.TF014);
                depthLowPlayer.Load();
                SoundPlayer depthLowLowPlayer = new SoundPlayer(Resources.TF023);
                depthLowLowPlayer.Load();
                System.Threading.Tasks.Task.Run(() => DepthAlarmLowLoop(depthLowPlayer));
                System.Threading.Tasks.Task.Run(() => DepthAlarmLowLowLoop(depthLowLowPlayer));
            }
            catch
            {
                return;
            }
        }

        private void YoctoPwmRx_NewData(object sender, WhatTheHelmRuntime.YoctoPwmRxArgs e)
        {//REMEMBER TO CHECK FOR AREAS THAT ARE COMMENTED OUT FOR TESTING OF THIS FEATURE!!!
            if (gaugePortRpm.IsHandleCreated)
                gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Value = e.Input1Hz / 400));
            if (lblPortRpm.IsHandleCreated)
                lblPortRpm.Invoke(new MethodInvoker(() => lblPortRpm.Text = (e.Input1Hz / 4).ToString("#")));
            if (gaugeStbdRpm.IsHandleCreated)
                gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Value = e.Input2Hz / 400));
            if(lblStbdRpm.IsHandleCreated)
                lblStbdRpm.Invoke(new MethodInvoker(() => lblStbdRpm.Text = (e.Input2Hz / 4).ToString("#")));
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
            if(lblFastPacketQueue.IsHandleCreated)
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

            //Rudder position
            if (e.ParameterGroupNumber == 127245)
            {
                pgn0x1F10DLastMsg = DateTime.Now;
                Pgn0x1F10D pgn = (Pgn0x1F10D)ParameterGroup.GetPgnType(127245).DeserializeFields(e.Data).ToImperial();
                if(gaugeRudderAngle.IsHandleCreated)
                    gaugeRudderAngle.Invoke(new MethodInvoker(() => gaugeRudderAngle.Value = pgn.Position));
            }

            //Engine Parameters (Rapid)
            if (e.ParameterGroupNumber == 127488)
            {
                pgn0x1F200LastMsg = DateTime.Now;
                Pgn0x1F200 pgn = (Pgn0x1F200)ParameterGroup.GetPgnType(127488).DeserializeFields(e.Data).ToImperial();

                //Port Engine
                if(pgn.EngineInstance == 0)
                {
                    if (gaugePortRpm.IsHandleCreated)
                        gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Value = pgn.EngineSpeed / 400));
                }
                //Stbd Engine
                else if(pgn.EngineInstance == 1)
                {
                    //Note that on my particular Seagauge G2, the stbd pulse input was inaccurate by a factor of value * 2.3, so I do the correction
                    //here.  Note that if the NMEA engine gateway is ever to change, this value must be changed back to the port setting found
                    //on line 184.
                    if(gaugeStbdRpm.IsHandleCreated)
                        gaugeStbdRpm.Invoke(new MethodInvoker(()=> gaugeStbdRpm.Value = (pgn.EngineSpeed / 400)/2.3));
                }
                //Generator
                else if(pgn.EngineInstance == 2)
                {
                    var genRpm = pgn.EngineSpeed;
                    if (lblGeneratorStatus.IsHandleCreated)
                        lblGeneratorStatus.Invoke(new MethodInvoker(() =>
                        {
                            if (genRpm > 250)
                            {
                                lblGeneratorStatus.Text = "RUNNING";
                                lblGeneratorStatus.ForeColor = Color.White;
                                lblGeneratorStatus.BackColor = Color.Green;
                            }
                            else
                            {
                                lblGeneratorStatus.Text = "STOPPED";
                                lblGeneratorStatus.ForeColor = Color.White;
                                lblGeneratorStatus.BackColor = Color.Transparent;
                            }
                        }));
                }
            }

            //Transmission Parameters
            if(e.ParameterGroupNumber == 127493)
            {
                pgn0x1F205LastMsg = DateTime.Now;
                Pgn0x1F205 pgn = (Pgn0x1F205)ParameterGroup.GetPgnType(127493).DeserializeFields(e.Data).ToImperial();

                //Port Engine
                if(pgn.EngineInstance == 0)
                {
                    lblPortDrivePressure.Invoke(new MethodInvoker(() => { lblPortDrivePressure.Text = (pgn.OilPressure).ToString("0"); }));
                }

                //Stbd Engine
                if(pgn.EngineInstance == 1)
                {
                    lblStbdDrivePressure.Invoke(new MethodInvoker(() => { lblStbdDrivePressure.Text = (pgn.OilPressure).ToString("0"); }));
                }
            }

            //Engine Parameters (Dynamic)
            if (e.ParameterGroupNumber == 127489)
            {
                pgn0x1F201LastMsg = DateTime.Now;
                Pgn0x1F201 pgn = (Pgn0x1F201)ParameterGroup.GetPgnType(127489).DeserializeFields(e.Data).ToImperial();

                //Port Engine
                if(pgn.EngineInstance == 0)
                {
                    lblPortWaterTemp.Invoke(new MethodInvoker(() => { lblPortWaterTemp.Text = pgn.EngineTemperature.ToString("0"); }));
                    lblPortOilPressure.Invoke(new MethodInvoker(() => { lblPortOilPressure.Text = pgn.OilPressure.ToString("0"); }));
                    lblPortVolts.Invoke(new MethodInvoker(() => { lblPortVolts.Text = pgn.AlternatorPotential.ToString("0.0");}));
                    lblPortHours.Invoke(new MethodInvoker(() => { lblPortHours.Text = pgn.EngineHours.ToString("0.0") + " HRS"; }));
                }
                //Stbd Engine
                else if(pgn.EngineInstance == 1)
                {
                    lblStbdWaterTemp.Invoke(new MethodInvoker(() => { lblStbdWaterTemp.Text = pgn.EngineTemperature.ToString("0"); }));
                    lblStbdOilPressure.Invoke(new MethodInvoker(() => { lblStbdOilPressure.Text = pgn.OilPressure.ToString("0"); }));
                    lblStbdVolts.Invoke(new MethodInvoker(() => { lblStbdVolts.Text = pgn.AlternatorPotential.ToString("0.0"); }));
                    lblStbdHours.Invoke(new MethodInvoker(() => { lblStbdHours.Text = pgn.EngineHours.ToString("0.0") + " HRS"; }));
                }
            }

            //Water Temperature (F)
            else if (e.ParameterGroupNumber == 130310)
            {
                pgn0x1FD06LastMsg = DateTime.Now;
                Pgn0x1FD06 pgn = (Pgn0x1FD06)ParameterGroup.GetPgnType(130310).DeserializeFields(e.Data).ToImperial();
                if (lblSeaWaterTemp.IsHandleCreated)
                    lblSeaWaterTemp.Invoke(new MethodInvoker(() => lblSeaWaterTemp.Text = (pgn.Temperature + Program.Configuration.WaterTempOffset).ToString("0.0")));
            }

            //Water Depth (FT)
            else if (e.ParameterGroupNumber == 128267)
            {
                pgn0x1F50BLastMsg = DateTime.Now;
                Pgn0x1F50B pgn = (Pgn0x1F50B)ParameterGroup.GetPgnType(128267).DeserializeFields(e.Data).ToImperial();
                if (lblSeaWaterDepth.IsHandleCreated)
                    lblSeaWaterDepth.Invoke(new MethodInvoker(() => { lblSeaWaterDepth.Text = (pgn.Depth + Program.Configuration.WaterDepthOffset).ToString("0.0"); }));                
            }

            //Speed (MPH)
            else if (e.ParameterGroupNumber == 128259)
            {
                pgn0x1F503LastMsg = DateTime.Now;
                Pgn0x1F503 pgn = (Pgn0x1F503)ParameterGroup.GetPgnType(128259).DeserializeFields(e.Data).ToImperial();
                if (gaugeSog.IsHandleCreated)
                {
                    gaugeSog.Invoke(new MethodInvoker(() => gaugeSog.Value = pgn.Speed));
                }
            }

            //GPS Coordinates
            else if (e.ParameterGroupNumber == 129029)
            {
                pgn0x1F805LastMsg = DateTime.Now;
                Pgn0x1F805 pgn = (Pgn0x1F805)ParameterGroup.GetPgnType(129029).DeserializeFields(e.Data);
                if (lblGpsCoordinates.IsHandleCreated)
                {
                    lblGpsCoordinates.Invoke(new MethodInvoker(() =>
                    {
                        var array = pgn.ToString().Split(',');
                        string text = "LATITUDE: " + array[0] + Environment.NewLine + "LONGITUDE: " + array[1] + Environment.NewLine + "ALTITUDE: " + array[2];
                        lblGpsCoordinates.Text = text;
                    }));
                }
            }

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
                    lblJ1939BustStatus.Text = "FAULTED";
                }
                else
                {
                    lblJ1939BustStatus.BackColor = Color.Green;
                    lblJ1939BustStatus.Text = "ONLINE";
                }
            }));

            //Rudder position
            var pgn0x1F10DLastMsgEt =  dtNow - pgn0x1F10DLastMsg;
            if (pgn0x1F10DLastMsgEt.TotalSeconds > 5)
                gaugeRudderAngle.Invoke(new MethodInvoker(() => gaugeRudderAngle.Hide()));
            else
                gaugeRudderAngle.Invoke(new MethodInvoker(() => gaugeRudderAngle.Show()));

            //Switch status
            var pgn0x1F20DLastMsgEt =  dtNow - pgn0x1F20DLastMsg;
            if(pgn0x1F20DLastMsgEt.TotalSeconds > 5)
            {
                lblPortWaterTempHigh.Invoke(new MethodInvoker(() => lblPortWaterTempHigh.Hide()));
                lblStbdWaterTempHigh.Invoke(new MethodInvoker(() => lblStbdWaterTempHigh.Hide()));
                lblPortOilPressLow.Invoke(new MethodInvoker(() => lblPortOilPressLow.Hide()));
                lblStbdOilPressLow.Invoke(new MethodInvoker(() => lblStbdOilPressLow.Hide()));
                lblPortDriveTempHigh.Invoke(new MethodInvoker(() => lblPortDriveTempHigh.Hide()));
                lblStbdDriveTempHigh.Invoke(new MethodInvoker(() => lblStbdDriveTempHigh.Hide()));
                lblPortFuelPressLow.Invoke(new MethodInvoker(() => lblPortFuelPressLow.Hide()));
                lblStbdFuelPressLow.Invoke(new MethodInvoker(() => lblStbdFuelPressLow.Hide()));
            }
            else
            {
                lblPortWaterTempHigh.Invoke(new MethodInvoker(() => lblPortWaterTempHigh.Show()));
                lblStbdWaterTempHigh.Invoke(new MethodInvoker(() => lblStbdWaterTempHigh.Show()));
                lblPortOilPressLow.Invoke(new MethodInvoker(() => lblPortOilPressLow.Show()));
                lblStbdOilPressLow.Invoke(new MethodInvoker(() => lblStbdOilPressLow.Show()));
                lblPortDriveTempHigh.Invoke(new MethodInvoker(() => lblPortDriveTempHigh.Show()));
                lblStbdDriveTempHigh.Invoke(new MethodInvoker(() => lblStbdDriveTempHigh.Show()));
                lblPortFuelPressLow.Invoke(new MethodInvoker(() => lblPortFuelPressLow.Show()));
                lblStbdFuelPressLow.Invoke(new MethodInvoker(() => lblStbdFuelPressLow.Show()));
            }

            //Water temperature
            var pgn0x1FD06LastMsgEt = dtNow - pgn0x1FD06LastMsg;
            if(pgn0x1FD06LastMsgEt.TotalSeconds > 5)
                lblSeaWaterTemp.Invoke(new MethodInvoker(() => lblSeaWaterTemp.Text = "--"));

            //Water depth
            var pgn0x1F50BLastMsgEt = dtNow - pgn0x1F50BLastMsg;
            if(pgn0x1F50BLastMsgEt.TotalSeconds > 5)
            {
                lblSeaWaterDepth.Invoke(new MethodInvoker(() =>
                {
                    lblSeaWaterDepth.Text = "--";
                    lblSeaWaterDepth.ForeColor = Color.White;
                    lblSeaWaterDepth.BackColor = Color.Transparent;
                }));
            }

            //Speed
            var pgn0x1F503LastMsgEt = dtNow - pgn0x1F503LastMsg;
            if(pgn0x1F503LastMsgEt.TotalSeconds > 5)
                gaugeSog.Invoke(new MethodInvoker(() => gaugeSog.Hide()));
            else
                gaugeSog.Invoke(new MethodInvoker(() => gaugeSog.Show()));

            //GPS Coordinates
            var pgn0x1F805LastMsgEt = dtNow - pgn0x1F805LastMsg;
            if(pgn0x1F805LastMsgEt.TotalSeconds > 5)
                lblGpsCoordinates.Invoke(new MethodInvoker(() =>
                {
                    lblGpsCoordinates.Text = "LATITUDE: --" + Environment.NewLine + "LONGITUDE: --" + Environment.NewLine + "ALTITUDE: --";
                }));

            //Engine parameters rapid
            var pgn0x1F200LastMsgEt = dtNow - pgn0x1F200LastMsg;
            if(Program.Configuration.RpmSource == RpmSource.NMEA2000)
            {
                if (pgn0x1F200LastMsgEt.TotalSeconds > 5)
                {
                    gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Hide()));
                    gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Hide()));
                    lblGeneratorStatus.Invoke(new MethodInvoker(() =>
                    {
                        lblGeneratorStatus.Text = "--";
                        lblGeneratorStatus.ForeColor = Color.White;
                        lblGeneratorStatus.BackColor = Color.Transparent;
                    }));
                }
                else
                {
                    gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Show()));
                    gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Show()));
                }
            }
            else
            {
                gaugePortRpm.Invoke(new MethodInvoker(() => gaugePortRpm.Show()));
                gaugeStbdRpm.Invoke(new MethodInvoker(() => gaugeStbdRpm.Show()));
            }

            //Engine parameters dynamic
            var pgn0x1F201LastMsgEt = dtNow - pgn0x1F201LastMsg;
            if(pgn0x1F201LastMsgEt.TotalSeconds > 5)
            {
                lblPortWaterTemp.Invoke(new MethodInvoker(() => { lblPortWaterTemp.Text = "--"; }));
                lblPortOilPressure.Invoke(new MethodInvoker(() => { lblPortOilPressure.Text = "--"; }));
                lblPortVolts.Invoke(new MethodInvoker(() => { lblPortVolts.Text = "--"; }));
                lblPortHours.Invoke(new MethodInvoker(() => { lblPortHours.Text = "--"; }));
                lblStbdWaterTemp.Invoke(new MethodInvoker(() => { lblStbdWaterTemp.Text = "--"; }));
                lblStbdOilPressure.Invoke(new MethodInvoker(() => { lblStbdOilPressure.Text = "--"; }));
                lblStbdVolts.Invoke(new MethodInvoker(() => { lblStbdVolts.Text = "--"; }));
                lblStbdHours.Invoke(new MethodInvoker(() => { lblStbdHours.Text = "--"; }));
                lblPortVoltageLow.Invoke(new MethodInvoker(() => { lblPortVoltageLow.Hide(); }));
                lblStbdVoltageLow.Invoke(new MethodInvoker(() => { lblStbdVoltageLow.Hide(); }));
            }
            else
            {
                lblPortVoltageLow.Invoke(new MethodInvoker(() => { lblPortVoltageLow.Show(); }));
                lblStbdVoltageLow.Invoke(new MethodInvoker(() => { lblStbdVoltageLow.Show(); }));
            }

            //Transmission parameters
            var pgn0x1F205LastMsgEt = dtNow - pgn0x1F205LastMsg;
            if(pgn0x1F205LastMsgEt.TotalSeconds > 5)
            {
                lblPortDrivePressure.Invoke(new MethodInvoker(() => { lblPortDrivePressure.Text = "--"; }));
                lblStbdDrivePressure.Invoke(new MethodInvoker(() => { lblStbdDrivePressure.Text = "--"; }));
            }
        }

        private void AlarmTimer_Tick(object sender, EventArgs e)
        {
            //Update local time display
            if (lblLocalTime.IsHandleCreated)
                lblLocalTime.Invoke(new MethodInvoker(() => lblLocalTime.Text = DateTime.Now.ToString("yyyy/MM/dd, HH:mm:ss")));

            //Engine speed synchronization
            var portRpm = gaugePortRpm.Value;
            var stbdRpm = gaugeStbdRpm.Value;
            var rpmDelta = portRpm - stbdRpm;
            
            //Port engine
            if(gaugePortRpm.IsHandleCreated)
            {
                gaugePortRpm.Invoke(new MethodInvoker(() =>
                {
                    //Stalled
                    if (portRpm < 2.5)
                    {
                        if (gaugePortRpmBorderLast != Color.Red)
                        {
                            gaugePortRpm.Border.Color = Color.Red;
                            gaugePortRpmBorderLast = Color.Red;
                        }
                        else if (gaugePortRpmBorderLast == Color.Red)
                        {
                            gaugePortRpm.Border.Color = Color.Black;
                            gaugePortRpmBorderLast = Color.Black;
                        }

                    }
                    //Slow
                    else if ((portRpm < stbdRpm) && (Math.Abs(rpmDelta) > 0.75))
                    {
                        if(gaugePortRpmBorderLast != Color.Yellow)
                        {
                            gaugePortRpm.Border.Color = Color.Yellow;
                            gaugePortRpmBorderLast = Color.Yellow;
                        }
                        else if(gaugePortRpmBorderLast == Color.Yellow)
                        {
                            gaugePortRpm.Border.Color = Color.Black;
                            gaugePortRpmBorderLast = Color.Black;
                        }
                    }
                    //Fast
                    else if ((portRpm > stbdRpm) && (Math.Abs(rpmDelta) > 0.75))
                        gaugePortRpm.Border.Color = Color.Black;
                    //Sync
                    else
                        gaugePortRpm.Border.Color = Color.Lime;
                }));

            }

            //Stbd engine
            if (gaugeStbdRpm.IsHandleCreated)
            {
                gaugeStbdRpm.Invoke(new MethodInvoker(() =>
                {
                    //Stalled
                    if (stbdRpm < 2.5)
                    {
                        if (gaugeStbdRpmBorderLast != Color.Red)
                        {
                            gaugeStbdRpm.Border.Color = Color.Red;
                            gaugeStbdRpmBorderLast = Color.Red;
                        }
                        else
                        {
                            gaugeStbdRpm.Border.Color = Color.Black;
                            gaugeStbdRpmBorderLast = Color.Black;

                        }
                    }
                    //Slow
                    else if ((stbdRpm < portRpm) && (Math.Abs(rpmDelta) > 0.75))
                    {
                        if (gaugeStbdRpmBorderLast != Color.Yellow)
                        {
                            gaugeStbdRpm.Border.Color = Color.Yellow;
                            gaugeStbdRpmBorderLast = Color.Yellow;
                        }
                        else if (gaugeStbdRpmBorderLast == Color.Yellow)
                        {
                            gaugeStbdRpm.Border.Color = Color.Black;
                            gaugeStbdRpmBorderLast = Color.Black;
                        }
                    }
                    //Fast
                    else if ((stbdRpm > portRpm) && (Math.Abs(rpmDelta) > 0.75))
                        gaugeStbdRpm.Border.Color = Color.Black;
                    //Sync
                    else
                        gaugeStbdRpm.Border.Color = Color.Lime;
                }));
            }
            
            //Port alternator output voltage low
            lblPortVoltageLow.Invoke(new MethodInvoker(() =>
            {
                try
                {
                    if (Convert.ToDouble(lblPortVolts.Text) < 12.6)
                        lblPortVoltageLow.BackColor = Color.Red;
                    else
                        lblPortVoltageLow.BackColor = Color.Maroon;
                }
                catch
                {
                    lblPortVoltageLow.BackColor = Color.Red;
                }
            }));

            //Stbd alternator output voltage low
            lblStbdVoltageLow.Invoke(new MethodInvoker(() =>
            {
                try
                {
                    if (Convert.ToDouble(lblStbdVolts.Text) < 12.6)
                        lblStbdVoltageLow.BackColor = Color.Red;
                    else
                        lblStbdVoltageLow.BackColor = Color.Maroon;
                }
                catch
                {
                    lblStbdVoltageLow.BackColor = Color.Maroon;
                }
            }));
           
            //Port water temp high
            if (lblPortWaterTempHigh.IsHandleCreated)
                lblPortWaterTempHigh.Invoke(new MethodInvoker(() =>
                {
                    if(SeaGaugeIndicatorStatus!=null)
                    {
                        if (SeaGaugeIndicatorStatus[5] == IndicatorBankStatus.Off)
                            lblPortWaterTempHigh.BackColor = Color.Red;
                        else
                            lblPortWaterTempHigh.BackColor = Color.Maroon;
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
                            lblStbdWaterTempHigh.BackColor = Color.Maroon;
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
                            lblPortOilPressLow.BackColor = Color.Maroon;
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
                            lblStbdOilPressLow.BackColor = Color.Maroon;
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
                            lblPortDriveTempHigh.BackColor = Color.Maroon;
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
                            lblStbdDriveTempHigh.BackColor = Color.Maroon;
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
                            lblPortFuelPressLow.BackColor = Color.Maroon;
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
                            lblStbdFuelPressLow.BackColor = Color.Maroon;
                    }
                }));

            //Water depth
            lblSeaWaterDepth.Invoke(new MethodInvoker(() =>
            {
                try
                {
                    var depth = Convert.ToDouble(lblSeaWaterDepth.Text);
                    //Water depth low-low flash (less than 4 ft)
                    if (depth <= 4)
                    {
                        if (lblSeaWaterDepth.BackColor == Color.Red && lblSeaWaterDepth.ForeColor == Color.White)
                        {
                            lblSeaWaterDepth.BackColor = Color.Transparent;
                            lblSeaWaterDepth.ForeColor = Color.White;
                        }
                        else
                        {
                            lblSeaWaterDepth.BackColor = Color.Red;
                            lblSeaWaterDepth.ForeColor = Color.White;
                        }
                    }
                    //Water depth low flash (4-6 ft)
                    else if (depth > 4 && depth <= 6)
                    {
                        if (lblSeaWaterDepth.BackColor == Color.Yellow && lblSeaWaterDepth.ForeColor == Color.Black)
                        {
                            lblSeaWaterDepth.BackColor = Color.Transparent;
                            lblSeaWaterDepth.ForeColor = Color.Black;
                        }
                        else
                        {
                            lblSeaWaterDepth.BackColor = Color.Yellow;
                            lblSeaWaterDepth.ForeColor = Color.Black;
                        }
                    }
                    //Water depth OK
                    else
                    {
                        lblSeaWaterDepth.BackColor = Color.Transparent;
                        lblSeaWaterDepth.ForeColor = Color.White;
                    }
                }
                catch
                {
                    if (lblSeaWaterDepth.BackColor == Color.Red && lblSeaWaterDepth.ForeColor == Color.White)
                    {
                        lblSeaWaterDepth.BackColor = Color.Transparent;
                        lblSeaWaterDepth.ForeColor = Color.White;
                    }
                    else
                    {
                        lblSeaWaterDepth.BackColor = Color.Red;
                        lblSeaWaterDepth.ForeColor = Color.White;
                    }
                }
            }));
        }

        private void DepthAlarmLowLoop(SoundPlayer player)
        {
            while(true)
            {
                try
                {
                    var depth = Convert.ToDouble(lblSeaWaterDepth.Text);
                    //low
                    if (depth > 4 && depth <= 6)
                        if(player.IsLoadCompleted)
                            player.PlaySync();
                }
                catch
                {
                    //if (player.IsLoadCompleted)
                    //    player.PlaySync();
                }
                System.Threading.Thread.Sleep(5);
            }
        }

        private void DepthAlarmLowLowLoop(SoundPlayer player)
        {
            while (true)
            {
                try
                {
                    var depth = Convert.ToDouble(lblSeaWaterDepth.Text);
                    //low-low
                    if (depth <= 4)
                        if (player.IsLoadCompleted)
                            player.PlaySync();
                }
                catch
                {
                    //if (player.IsLoadCompleted)
                    //    player.PlaySync();
                }
                System.Threading.Thread.Sleep(5);
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
