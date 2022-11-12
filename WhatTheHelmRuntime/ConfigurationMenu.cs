using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatTheHelmCanLib.Messages;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;

namespace WhatTheHelmRuntime
{
    public partial class ConfigurationMenu : Form
    {

        public Configuration Configuration { get; set; }
        private const int CAN_ADDCLAIM_PGN = 60928;
        private const int CAN_ISOREQ_PGN = 59904;
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
            Program.CanGateway.MessageRecieved += CanGateway_MessageRecieved;


        }

        private void CanGateway_MessageRecieved(object sender, CanMessageArgs e)
        {
            if(e.Message.ParameterGroupNumber < 100000)
                Console.WriteLine(e.Message.ParameterGroupNumber);
            if (e.Message.ParameterGroupNumber == 59904)
            {
                Console.WriteLine(e.Message.ParameterGroupNumber);
            }
            if (e.Message.ParameterGroupNumber == 59392)
            {
                Console.WriteLine(e.Message.ParameterGroupNumber);
            }
            if (e.Message.ParameterGroupNumber == 126208)
            {
                Console.WriteLine(e.Message.ParameterGroupNumber);
            }
            if (e.Message.ParameterGroupNumber == 60928)
            {
                Console.WriteLine(e.Message.ParameterGroupNumber);
            }
            if (e.Message.ParameterGroupNumber == 126996)
            {
                Pgn0x1F014 pgn0X1F014 = new Pgn0x1F014();
                pgn0X1F014.DeserializeFields(e.Message.Data);
                Console.WriteLine(e.Message.ParameterGroupNumber);
            }
            if (e.Message.ParameterGroupNumber == 126720)
            {
               // Console.WriteLine(e.Message.ParameterGroupNumber);
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            //var boo = Program.CanGateway.AskN2KDevicesForCANName();
            //var boo = Program.CanGateway.AddressClaim();
            Program.CanGateway.IsoRequest(126996);
            //Program.CanGateway.IsoRequest(60928);
        }
    }
}
