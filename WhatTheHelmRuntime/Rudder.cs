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
using WhatTheHelmCanLib.ParameterGroups;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;

namespace WhatTheHelmRuntime
{
    public partial class Rudder : Form
    {
        Pgn0x1F112 pgn0X1F112 = new Pgn0x1F112();
        Pgn0x1F200 pgn0x1F200 = new Pgn0x1F200();
        int _PortRpm;
        int _StbdRpm;
        public Rudder()
        {
            InitializeComponent();
        }

        private void CanGateWayListener_NewMessage(object sender, WhatTheHelmCanLib.Messages.CanMessage e)
        {
            //Engine Parameters (Rapid)
            if (e.Pgn == 127488)
            {
                pgn0x1F200 = (Pgn0x1F200)pgn0x1F200.DeserializeFields(e.Data).ToImperial();

                //Because of issue with the Seagauge module, I had to measure rudder percent using the last remaining tilt/trim instance which is 
                //engine #3 (instance = 2). Its a total hack move, but I had no choice.
                if(pgn0x1F200.EngineInstance == 2)
                {
                    linearGauge1.Value = pgn0x1F200.EngineTiltTrim;
                }
                //Port Engine
                if (pgn0x1F200.EngineInstance == 0)
                    _PortRpm = pgn0x1F200.EngineSpeed / 4;
                //Stbd Engine
                else if (pgn0x1F200.EngineInstance == 1)
                    _StbdRpm = pgn0x1F200.EngineSpeed / 4;
                //Update sync display
                SetSync(_PortRpm, _StbdRpm);             
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
