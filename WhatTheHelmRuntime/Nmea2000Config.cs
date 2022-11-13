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

                
                configureComboBoxes();
                setComboBoxSelectedItems();
            }
        }

        private void RefreshList()
        {
            var gw = (Ngt1)Program.CanGateway;
            gw.IsoRequest(126996);
            gw.IsoRequest(126464);
            listBox1.Items.Clear();
            listBox1.Items.Add("FOO");
            listBox1.Items.Add("FOO");
            listBox1.Items.Add("FOO");


        }

        private void configureComboBoxes()
        {
            _nmea2000Objects.Where(obj => obj.TxPgns!=null && obj.TxPgns.Contains(127488)).ToList().ForEach(obj => 
            {
                object[] instance = new object[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                //Port RPM
                fillComboBox(cbPortRpmSource, new object[] { obj.ToString() }, true);
                fillComboBox(cbPortRpmPgn, new object[] { 127488 }, false);
                fillComboBox(cbPortRpmInstance, instance, true);

                //Port oil, water, alarms
                fillComboBox(cbPortWaterTempSource, new object[] { obj.ToString() }, true);
                fillComboBox(cbPortWaterTempPgn, new object[] { 127493 }, false);
                fillComboBox(cbPortWaterTempInstance, instance, true);
                fillComboBox(cbPortOilPressureSource, new object[] { obj.ToString() }, true);
                fillComboBox(cbPortOilPressurePgn, new object[] { 127493 }, false);
                fillComboBox(cbPortOilPressureInstance, instance, true);
                fillComboBox(cbPortEngineAlarmsSource, new object[] { obj.ToString() }, true);
                fillComboBox(cbPortEngineAlarmsPgn, new object[] { 127493 }, false);
                fillComboBox(cbPortEngineAlarmsInstance, instance, true);
                fillComboBox(cbPortHourMeterSource, new object[] { obj.ToString() }, true);
                fillComboBox(cbPortHourMeterPgn, new object[] { 127493 }, false);
                fillComboBox(cbPortHourMeterInstance, instance, true);

                instance = null;
            });

        }

        private void fillComboBox(ComboBox cb, object[] items, bool enabled)
        {
            cb.Invoke(new MethodInvoker(() =>
            {
                cb.Items.Clear();
                cb.Items.AddRange(items);
                cb.Enabled = enabled;
            }));

           
        }

        private void setComboBoxSelectedItems()
        {
            if (cbPortRpmPgn.Items.Count > 0)
                cbPortRpmPgn.Invoke(new MethodInvoker(() => { cbPortRpmPgn.SelectedIndex = 0; }));
            if (cbPortWaterTempPgn.Items.Count > 0)
                cbPortWaterTempPgn.Invoke(new MethodInvoker(() => { cbPortWaterTempPgn.SelectedIndex = 0; }));
            if (cbPortOilPressurePgn.Items.Count > 0)
                cbPortOilPressurePgn.Invoke(new MethodInvoker(() => { cbPortOilPressurePgn.SelectedIndex = 0; }));
            if (cbPortEngineAlarmsPgn.Items.Count > 0)
                cbPortEngineAlarmsPgn.Invoke(new MethodInvoker(() => { cbPortEngineAlarmsPgn.SelectedIndex = 0; }));
            if (cbPortHourMeterPgn.Items.Count > 0)
                cbPortHourMeterPgn.Invoke(new MethodInvoker(() => { cbPortHourMeterPgn.SelectedIndex = 0; }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDeviceListScrollUp_Click(object sender, EventArgs e)
        {
            int visibleItemsInRow = listBox1.ClientSize.Height / listBox1.ItemHeight;
            listBox1.TopIndex = 0; //listBox1.TopIndex - visibleItemsInRow;
        }

        private void btnDeviceListScrollDown_Click(object sender, EventArgs e)
        {
            int visibleItemsInRow = listBox1.ClientSize.Height / listBox1.ItemHeight;
            listBox1.TopIndex = listBox1.TopIndex + visibleItemsInRow;
        }
    }
}
