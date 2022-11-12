using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatTheHelmCanLib.Devices.Nmea2000;
using WhatTheHelmCanLib.Devices.NMEA2000.Actisense;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;

namespace WhatTheHelmRuntime
{
    public partial class Nmea2000Config : Form
    {
        private List<ProductInformation> _productInformation = new List<ProductInformation>();
        public Nmea2000Config()
        {
            InitializeComponent();
            Program.CanGateway.MessageRecieved += CanGateway_MessageRecieved;
            RefreshList();
        }

        private void CanGateway_MessageRecieved(object sender, WhatTheHelmCanLib.Messages.CanMessageArgs e)
        {
            //Product information
            if(e.Message.ParameterGroupNumber == 126996)
            {
                var prodInfo = new Pgn0x1F014();
                prodInfo = (Pgn0x1F014)prodInfo.DeserializeFields(e.Message.Data);
                _productInformation.Add(prodInfo.ProductInformation);
                string device = String.Format("{0}, Serial Number: {1}", prodInfo.ProductInformation.ModelId, prodInfo.ProductInformation.ModelSerialCode);
                listBox1.Invoke( new MethodInvoker(()=>listBox1.Items.Add(device)));
                
            }
        }

        private void RefreshList()
        {
            var gw = (Ngt1)Program.CanGateway;
            gw.IsoRequest(126996);
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
    }
}
