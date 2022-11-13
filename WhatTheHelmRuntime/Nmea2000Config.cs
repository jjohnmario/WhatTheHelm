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
        private List<object> _instanceList = new List<object>();
        private List<ProductInformation> _productInformation = new List<ProductInformation>();
        private List<Nmea2000Object> _nmea2000Objects = new List<Nmea2000Object>();
        public Nmea2000Config()
        {
            InitializeComponent();
            Program.CanGateway.MessageRecieved += CanGateway_MessageRecieved;
            for (int i = 0; i < 1000; i++)
            {
                _instanceList.Add(i);
            }
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
        }

        private void configureComboBoxes()
        {
            object[] instance = _instanceList.ToArray();
            //RPM
            _nmea2000Objects.Where(obj => obj.TxPgns!=null && obj.TxPgns.Contains(127488)).ToList().ForEach(obj => 
            {
                fillComboBox(cbRpmSource, new object[] { obj.ToString() }, true);
                fillComboBox(cbRpmPgn, new object[] { 127488 }, false);
                fillComboBox(cbRpmInstance, instance, true);
            });

            //Engine oil pressure, water temperature, alarms
            _nmea2000Objects.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127489)).ToList().ForEach(obj =>
            {
                fillComboBox(cbWaterTempSource, new object[] { obj.ToString() }, true);
                fillComboBox(cbWaterTempPgn, new object[] { 127489 }, false);
                fillComboBox(cbWaterTempInstance, instance, true);
                fillComboBox(cbOilPressureSource, new object[] { obj.ToString() }, true);
                fillComboBox(cbOilPressurePgn, new object[] { 127489 }, false);
                fillComboBox(cbOilPressureInstance, instance, true);
                fillComboBox(cbEngineAlarmsSource, new object[] { obj.ToString() }, true);
                fillComboBox(cbEngineAlarmsPgn, new object[] { 127489 }, false);
                fillComboBox(cbEngineAlarmsInstance, instance, true);
                fillComboBox(cbHourMeterSource, new object[] { obj.ToString() }, true);
                fillComboBox(cbHourMeterPgn, new object[] { 127489 }, false);
                fillComboBox(cbHourMeterInstance, instance, true);
            });
            //Trans hydraulic pressure, alarms
            _nmea2000Objects.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127493)).ToList().ForEach(obj =>
            {
                fillComboBox(cbTransPressureSource, new object[] { obj.ToString() }, true);
                fillComboBox(cbTransPressurePgn, new object[] { 127493 }, false);
                fillComboBox(cbTransPressureInstance, instance, true);
            });
            //Battery
            List<object> batteryPgns = new List<object>();
            _nmea2000Objects.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127508) | obj.TxPgns.Contains(127489)).ToList().ForEach(obj =>
            {
                fillComboBox(cbBatteryVoltageSource, new object[] { obj.ToString() }, true);
                if (obj.TxPgns.Contains(127508) & !batteryPgns.Contains(127508))
                    batteryPgns.Add(127508);
                if(obj.TxPgns.Contains(127489) & !batteryPgns.Contains(127489))
                    batteryPgns.Add(127489);

            });
            fillComboBox(cbBatteryVoltagePgn, batteryPgns.ToArray(), true);
            fillComboBox(cbBatteryVoltageInstance, instance, true);
            instance = null;
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
            if (cbRpmPgn.Items.Count > 0)
                cbRpmPgn.Invoke(new MethodInvoker(() => { cbRpmPgn.SelectedIndex = 0; }));
            if (cbWaterTempPgn.Items.Count > 0)
                cbWaterTempPgn.Invoke(new MethodInvoker(() => { cbWaterTempPgn.SelectedIndex = 0; }));
            if (cbOilPressurePgn.Items.Count > 0)
                cbOilPressurePgn.Invoke(new MethodInvoker(() => { cbOilPressurePgn.SelectedIndex = 0; }));
            if (cbEngineAlarmsPgn.Items.Count > 0)
                cbEngineAlarmsPgn.Invoke(new MethodInvoker(() => { cbEngineAlarmsPgn.SelectedIndex = 0; }));
            if (cbHourMeterPgn.Items.Count > 0)
                cbHourMeterPgn.Invoke(new MethodInvoker(() => { cbHourMeterPgn.SelectedIndex = 0; }));
        }

        private void btnRefreshDeviceList_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDeviceListScrollUp_Click(object sender, EventArgs e)
        {
            int visibleItemsInRow = listBox1.ClientSize.Height / listBox1.ItemHeight;
            listBox1.TopIndex = 0;
        }

        private void btnDeviceListScrollDown_Click(object sender, EventArgs e)
        {
            int visibleItemsInRow = listBox1.ClientSize.Height / listBox1.ItemHeight;
            listBox1.TopIndex = listBox1.TopIndex + visibleItemsInRow;
        }
    }
}
