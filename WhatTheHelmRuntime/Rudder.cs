using WhatTheHelmRuntime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatTheHelmRuntime.NMEA0183.Sentences;
using CanLib.ParameterGroups;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;
using CanLib.ParameterGroups.NMEA2000;

namespace WhatTheHelmRuntime
{
    public partial class Rudder : Form
    {
        Random portRpm = new Random(1100);
        Random stbdRpm = new Random(1000);
        Pgn0x1F112 pgn0X1F112 = new Pgn0x1F112();
        Pgn0x1F200 pgn0x1F200 = new Pgn0x1F200();
        int lastNMEA2000PortRpm;
        int lastNMEA2000StbdRpm;
        public Rudder()
        {
            InitializeComponent();
            Program.CanGateWayListener.NewMessage += CanGateWayListener_NewMessage;
            Program.YoctoPwmRx.NewData += YoctoPwmRx_NewData;
            Timer t = new Timer();
            t.Interval = 500;
            t.Tick += T_Tick;
            t.Start();
        }

        private void YoctoPwmRx_NewData(object sender, YoctoPwmRxArgs e)
        {
            if (Program.Configuration.RpmSource == RpmSource.YoctopuceUsb)
            {
                int portRpm = Convert.ToInt32(Convert.ToDouble((e.Input1Hz * 60 / 4)));
                int stbdRpm = Convert.ToInt32(Convert.ToDouble((e.Input2Hz * 60 / 4)));
                //Update sync display
                SetSync(portRpm, stbdRpm);
            }
        }

        private void T_Tick(object sender, EventArgs e)
        {
            SetSync(portRpm.Next(1000, 1200),stbdRpm.Next(1000,1200));
        }

        private void CanGateWayListener_NewMessage(object sender, CanLib.Messages.CanMessage e)
        {
            //Engine Parameters (Rapid)
            if (e.ParameterGroupNumber == 127488)
            {
                pgn0x1F200 = (Pgn0x1F200)pgn0x1F200.DeserializeFields(e.Data).ToImperial();

                //Because of issue with the Seagauge module, I had to measure rudder percent using the last remaining tilt/trim instance which is 
                //engine #3 (instance = 2). Its a total hack move, but I had no choice.
                if(pgn0x1F200.EngineInstance == 2)
                {
                    linearGauge1.Value = pgn0x1F200.EngineTiltTrim;
                }
                else if (Program.Configuration.RpmSource == RpmSource.NMEA2000)
                {
                    //Port Engine
                    if (pgn0x1F200.EngineInstance == 0)
                        lastNMEA2000PortRpm = pgn0x1F200.EngineSpeed / 4;
                    //Stbd Engine
                    else if (pgn0x1F200.EngineInstance == 1)
                        lastNMEA2000StbdRpm = pgn0x1F200.EngineSpeed / 4;
                    //Update sync display
                    SetSync(lastNMEA2000PortRpm, lastNMEA2000StbdRpm);
                }
            }
        }

        private void SetSync(int portRpm, int stbdRpm)
        {
            //Engine speed synchronization
            var rpmDelta = portRpm - stbdRpm;

            //Port engine
            if (lblPortSlow.IsHandleCreated && lblStbdSlow.IsHandleCreated && lblSync.IsHandleCreated)
            {
                lblPortSlow.Invoke(new MethodInvoker(() =>
                {
                    //Slow
                    if ((portRpm < stbdRpm) && (Math.Abs(rpmDelta) > 25))
                    {
                        lblPortSlow.BackColor = Color.Yellow;
                        lblStbdSlow.BackColor = Color.FromArgb(60, 53, 4);
                        lblSync.BackColor = Color.FromArgb(3, 30, 2);
                    }
                    //Fast
                    else if ((portRpm > stbdRpm) && (Math.Abs(rpmDelta) > 20))
                    {
                        lblStbdSlow.BackColor = Color.Yellow;
                        lblPortSlow.BackColor = Color.FromArgb(60, 53, 4);
                        lblSync.BackColor = Color.FromArgb(3, 30, 2);
                    }
                    //Sync
                    else
                    {
                        lblStbdSlow.BackColor = Color.FromArgb(60, 53, 4);
                        lblPortSlow.BackColor = Color.FromArgb(60, 53, 4);
                        lblSync.BackColor = Color.Lime;
                    }
                }));
            }
        }
    }
}
