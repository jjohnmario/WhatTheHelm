using System;
using System.Drawing;
using System.Windows.Forms;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;

namespace WhatTheHelmRuntime
{
    public partial class Rudder : Form
    {
        private Pgn0x1F112 _pgn0X1F112 = new Pgn0x1F112();
        private Pgn0x1F200 _pgn0x1F200 = new Pgn0x1F200();
        private int _portRpm;
        private int _stbdRpm;
        public Rudder()
        {
            InitializeComponent();
            Program.CanGateway.MessageRecieved += CanGateway_MessageRecieved;
        }

        private void CanGateway_MessageRecieved(object sender, WhatTheHelmCanLib.Messages.CanMessageArgs e)
        {
            //Port Engine RPM
            if (Program.Configuration.PortPropulsionN2KConfig.Rpm != null)
                if (e.Message.SourceAddress == Program.Configuration.PortPropulsionN2KConfig.Rpm.Nmea2000Device.Address)
                {
                    //PGN check
                    if (e.Message.Pgn == Program.Configuration.PortPropulsionN2KConfig.Rpm.PGN)
                    {
                        _pgn0x1F200 = (Pgn0x1F200)_pgn0x1F200.DeserializeFields(e.Message.Data).ToImperial();

                        //Instance check
                        if (_pgn0x1F200.EngineInstance == Program.Configuration.PortPropulsionN2KConfig.Rpm.Instance)
                        {
                            _portRpm = _pgn0x1F200.EngineSpeed / 4;
                        }
                    }
                }
            //Stbd Engine RPM
            if (Program.Configuration.StbdPropulsionN2KConfig.Rpm != null)
                if (e.Message.SourceAddress == Program.Configuration.StbdPropulsionN2KConfig.Rpm.Nmea2000Device.Address)
                {
                    //PGN check
                    if (e.Message.Pgn == Program.Configuration.StbdPropulsionN2KConfig.Rpm.PGN)
                    {
                        _pgn0x1F200 = (Pgn0x1F200)_pgn0x1F200.DeserializeFields(e.Message.Data).ToImperial();

                        //Instance check
                        if (_pgn0x1F200.EngineInstance == Program.Configuration.StbdPropulsionN2KConfig.Rpm.Instance)
                        {
                            _stbdRpm = _pgn0x1F200.EngineSpeed / 4;
                        }
                    }
                }
            //Update sync display
            SetSync(_portRpm, _stbdRpm);

            //Rudder position (future)
            //linearGauge1.Value = null;
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
