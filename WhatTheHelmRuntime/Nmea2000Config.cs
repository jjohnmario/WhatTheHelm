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
    struct Nmea2000Object
    {
        public uint Source;
        public ProductInformation ProductInformation;
        public List<uint> RxPgns;
        public List<uint> TxPgns;
        public override string ToString()
        {
            return String.Format("{0}, {1}", ProductInformation.ModelId, ProductInformation.ModelSerialCode);
        }
    }
    public partial class Nmea2000Config : Form
    {
        private List<ProductInformation> _productInformation = new List<ProductInformation>();
        private List<Nmea2000Object> _nmea2000Objects = new List<Nmea2000Object>();
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
                Nmea2000Object nmea2000Object = new Nmea2000Object();
                nmea2000Object.ProductInformation = prodInfo.ProductInformation;
                nmea2000Object.Source = e.Message.SourceAddress;
                _nmea2000Objects.Add(nmea2000Object);
                
               
                string nmea2000ObjectStr = String.Format("{0}, Serial Number: {1}", nmea2000Object.ProductInformation.ModelId, nmea2000Object.ProductInformation.ModelSerialCode);
                listBox1.Invoke( new MethodInvoker(()=>listBox1.Items.Add(nmea2000ObjectStr)));
                
            }
            //Pgn List
            if(e.Message.ParameterGroupNumber == 126464)
            {
                var pgnList = new Pgn0x1EE00();
                pgnList = (Pgn0x1EE00)pgnList.DeserializeFields(e.Message.Data);
                //Copy existing N2K object
                var foundObj = _nmea2000Objects.Where(obj => obj.Source == e.Message.SourceAddress).First();
                var updatedObj = foundObj;
                //Returned list is Tx
                if (pgnList.PgnListType == PgnListType.Transmit)
                    updatedObj.TxPgns = pgnList.PgnTransmitList;  
                //Returned list is Rx
                else if(pgnList.PgnListType == PgnListType.Receive)
                    updatedObj.RxPgns = pgnList.PgnReceiveList;
                //Replace old N2K object with new
                _nmea2000Objects.Remove(foundObj);
                _nmea2000Objects.Add(updatedObj);
            }
        }

        private void RefreshList()
        {
            var gw = (Ngt1)Program.CanGateway;
            gw.IsoRequest(126996);
            gw.IsoRequest(126464);
            listBox1.Items.Clear();
        }

        private void addComboBoxItems()
        {
            _nmea2000Objects.Where(obj => obj.TxPgns.Contains(127488)).ToList().ForEach(obj => {
                cbPortRpmSource.Items.Add(obj.ToString());
                cbPortRpmPgn.Items.Add(127488);
                cbPortRpmPgn.SelectedItem = 127488;
                cbPortRpmInstance.Items.AddRange(new object[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
                cbPortWaterTempSource.Items.Add(obj.ToString());
                cbPortWaterTempPgn.Items.Add(127488);
                cbPortWaterTempPgn.SelectedItem = 127488;
                cbPortWaterTempInstance.Items.AddRange(new object[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addComboBoxItems();
        }
    }
}
