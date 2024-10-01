using System;
using System.Drawing;
using System.Windows.Forms;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;

namespace WhatTheHelmRuntime
{
    public partial class Rudder : Form
    {
        DateTime _portRpmLastMsg = new DateTime();
        DateTime _stbdRpmLastMsg = new DateTime();
        DateTime _rudderLastMsg = new DateTime();
        private Pgn0x1F10D _pgn0x1F10D = new Pgn0x1F10D();
        private Pgn0x1F200 _pgn0x1F200 = new Pgn0x1F200();
        private int _portRpm;
        private int _stbdRpm;
        public Rudder()
        {
            InitializeComponent();
            Timer t = new Timer();
            t.Interval = 5000;
            t.Tick += T_Tick;
            t.Start();
            Program.CanGateway.MessageRecieved += CanGateway_MessageRecieved;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            //Get current time
            var dtNow = DateTime.Now;

            //Port RPM status
            var portRpmLastMsgEt = dtNow - _portRpmLastMsg;
            if (portRpmLastMsgEt.TotalSeconds > 5)
            {

            }
            else
            {
 
            }
            //Stbd RPM status
            var stbdRpmLastMsgEt = dtNow - _stbdRpmLastMsg;
            if (stbdRpmLastMsgEt.TotalSeconds > 5)
            {

            }
            else
            {

            }
            //Rudder status
            var rudderLastMsgEt = dtNow - _rudderLastMsg;
            if (rudderLastMsgEt.TotalSeconds > 5)
            {
                
            }
            else
            {

            }
        }

        private void CanGateway_MessageRecieved(object sender, WhatTheHelmCanLib.Messages.CanMessageArgs e)
        {
            if(Program.RunningConfiguration!=null)
            {
                //Port Engine RPM
                if (Program.RunningConfiguration.PortPropulsionN2KConfig.Rpm != null)
                    if (e.Message.SourceAddress == Program.RunningConfiguration.PortPropulsionN2KConfig.Rpm.Nmea2000Device.Address)
                    {
                        //PGN check
                        if (e.Message.Pgn == Program.RunningConfiguration.PortPropulsionN2KConfig.Rpm.PGN)
                        {
                            _portRpmLastMsg = DateTime.Now;
                            _pgn0x1F200 = (Pgn0x1F200)_pgn0x1F200.DeserializeFields(e.Message.Data).ToImperial();

                            //Instance check
                            if (_pgn0x1F200.EngineInstance == Program.RunningConfiguration.PortPropulsionN2KConfig.Rpm.Instance)
                            {
                                _portRpm = _pgn0x1F200.EngineSpeed / 4;
                            }
                        }
                    }
                //Stbd Engine RPM
                if (Program.RunningConfiguration.StbdPropulsionN2KConfig.Rpm != null)
                    if (e.Message.SourceAddress == Program.RunningConfiguration.StbdPropulsionN2KConfig.Rpm.Nmea2000Device.Address)
                    {
                        //PGN check
                        if (e.Message.Pgn == Program.RunningConfiguration.StbdPropulsionN2KConfig.Rpm.PGN)
                        {
                            _stbdRpmLastMsg = DateTime.Now;
                            _pgn0x1F200 = (Pgn0x1F200)_pgn0x1F200.DeserializeFields(e.Message.Data).ToImperial();

                            //Instance check
                            if (_pgn0x1F200.EngineInstance == Program.RunningConfiguration.StbdPropulsionN2KConfig.Rpm.Instance)
                            {
                                _stbdRpm = _pgn0x1F200.EngineSpeed / 4;
                            }
                        }
                    }
                //Rudder
                if (Program.RunningConfiguration.RudderTrimN2KConfig.Rudder !=null)
                    if(e.Message.SourceAddress == Program.RunningConfiguration.RudderTrimN2KConfig.Rudder.Nmea2000Device.Address)
                    {
                        //PGN check
                        if(e.Message.Pgn == Program.RunningConfiguration.RudderTrimN2KConfig.Rudder.PGN)
                        {
                            _rudderLastMsg = DateTime.Now;
                            _pgn0x1F10D = (Pgn0x1F10D)_pgn0x1F10D.DeserializeFields(e.Message.Data).ToImperial();

                            //Instance check
                            if(_pgn0x1F10D.Instance == Program.RunningConfiguration.RudderTrimN2KConfig.Rudder.Instance)
                            {
                                rudderPosGauge1.SetPosition(_pgn0x1F10D.Instance);
                            }
                        }
                    }
                //Sync
                engineSyncGauge1.SetRpmDelta(_portRpm, _stbdRpm);
            }
        }
    }
}
