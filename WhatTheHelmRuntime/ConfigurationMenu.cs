using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatTheHelmRuntime
{
    public partial class ConfigurationMenu : Form
    {
        public Configuration Configuration { get; set; }
        public ConfigurationMenu(Configuration config)
        {
            InitializeComponent();
            Configuration = config;
            if (Configuration.RpmSource == RpmSource.NMEA2000)
                cbRpmSource.Checked = true;
            else
                cbRpmSource.Checked = false;
            nudWaterDepthOffset.Value = Convert.ToDecimal(Configuration.WaterDepthOffset);
            nudWaterTempOffset.Value = Convert.ToDecimal(Configuration.WaterTempOffset);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbRpmSource.Checked)
                Configuration.RpmSource = RpmSource.NMEA2000;
            else
                Configuration.RpmSource = RpmSource.YoctopuceUsb;
            Configuration.WaterDepthOffset = Convert.ToDouble(nudWaterDepthOffset.Value);
            Configuration.WaterTempOffset = Convert.ToDouble(nudWaterTempOffset.Value);
            this.DialogResult = DialogResult.OK;
        }
    }
}
