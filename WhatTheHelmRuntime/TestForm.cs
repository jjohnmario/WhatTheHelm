using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatTheHelmRuntime.Properties;

namespace WhatTheHelmRuntime
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            //engineSyncGauge1.SetRpmDelta(3100, 3000 );
            //rudderPosGauge1.SetPosition(-5);
        }

        private void btnBothBowUp_MouseDown(object sender, MouseEventArgs e)
        {
            btnBothBowUp.BackgroundImage = Resources.Bow_Down_On;
            dashboardButton3.ForceMouseDownEvent();
            dashboardButton4.ForceMouseDownEvent();
        }

        private void btnBothBowUp_MouseUp(object sender, MouseEventArgs e)
        {
            btnBothBowUp.BackgroundImage = Resources.Bow_Down_Off;
            dashboardButton3.ForceMouseUpEvent();
            dashboardButton4.ForceMouseUpEvent();
        }

        private void dashboardButton3_NewCommand(object sender, BoatFormsLib.DashboardButtonArgs e)
        {

        }
    }
}
