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
        private Configuration _existingConfig = new Configuration();
        public Nmea2000Config()
        {
            this.HandleCreated += Nmea2000Config_HandleCreated;
            InitializeComponent();

        }

        private void Nmea2000Config_HandleCreated(object sender, EventArgs e)
        {
            Program.CanGateway.MessageRecieved += CanGateway_MessageRecieved;
            for (int i = 0; i < 1000; i++)
            {
                _instanceList.Add(i);
            }
            _existingConfig = Program.Configuration;
            refreshList();
            initializeComboBoxes();

        }

        private void loadExistingConfig()
        {
            if(_existingConfig.PortRpm.ProductInformation != null)
            {
                cbRpmSource.SelectedItem = _existingConfig.PortRpm.ProductInformation.ModelId;
            }    

        }

        private void CanGateway_MessageRecieved(object sender, WhatTheHelmCanLib.Messages.CanMessageArgs e)
        {
            if(this.IsHandleCreated)
            {
                //Product information
                if(e.Message.Pgn == 126996)
                {
                    var prodInfo = new Pgn0x1F014();
                    prodInfo = (Pgn0x1F014)prodInfo.DeserializeFields(e.Message.Data);
                    Nmea2000Object obj = new Nmea2000Object();
                    obj.ProductInformation = prodInfo.ProductInformation;
                    obj.Source = e.Message.SourceAddress;
                    _nmea2000Objects.Add(obj);
                    listBox1.Invoke( new MethodInvoker(()=>listBox1.Items.Add(obj.ToString())));             
                }
                //Pgn List
                if(e.Message.Pgn == 126464)
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

        }

        private void refreshList()
        {
            Timer t = new Timer();
            t.Interval = 500;
            t.Tick += T_Tick;
            t.Start();
            var gw = (Ngt1)Program.CanGateway;
            gw.IsoRequest(126996);
            gw.IsoRequest(126464);
            listBox1.Items.Clear();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            var timer = (Timer)sender;
            timer.Stop();
            timer.Tick -= T_Tick;
            timer.Dispose();
            initializeComboBoxes();
            setComboBoxSelectedItems(); 
        }

        private void initializeComboBoxes()
        {
            object[] instance = _instanceList.ToArray();
            //RPM
            _nmea2000Objects.Where(obj => obj.TxPgns!=null && obj.TxPgns.Contains(127488)).ToList().ForEach(obj => 
            {
                fillComboBox(cbRpmSource, new object[] { obj.ProductInformation.ModelId }, true);
                fillComboBox(cbRpmSourceSerial, new object[] {obj.ProductInformation.ModelSerialCode},true);
                fillComboBox(cbRpmPgn, new object[] { 127488 }, false);
                fillComboBox(cbRpmInstance, instance, true);
            });

            //Engine oil pressure, water temperature, alarms
            _nmea2000Objects.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127489)).ToList().ForEach(obj =>
            {
                fillComboBox(cbWaterTempSource, new object[] { obj.ProductInformation.ModelId }, true);
                fillComboBox(cbWaterTempSerial, new object[] { obj.ProductInformation.ModelSerialCode }, true);
                fillComboBox(cbWaterTempPgn, new object[] { 127489 }, false);
                fillComboBox(cbWaterTempInstance, instance, true);
                fillComboBox(cbOilPressSource, new object[] { obj.ProductInformation.ModelId }, true);
                fillComboBox(cbOilPressSerial, new object[] { obj.ProductInformation.ModelSerialCode }, true);
                fillComboBox(cbOilPressPgn, new object[] { 127489 }, false);
                fillComboBox(cbOilPressInstance, instance, true);
                fillComboBox(cbEngineAlarmsSource, new object[] { obj.ProductInformation.ModelId }, true);
                fillComboBox(cbEngineAlarmsSerial, new object[] { obj.ProductInformation.ModelSerialCode }, true);
                fillComboBox(cbEngineAlarmsPgn, new object[] { 127489 }, false);
                fillComboBox(cbEngineAlarmsInstance, instance, true);
                fillComboBox(cbHourMeterSource, new object[] { obj.ProductInformation.ModelId }, true);
                fillComboBox(cbHourMeterSerial, new object[] { obj.ProductInformation.ModelSerialCode }, true);
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
            //Set constant PGNs
            if (cbRpmPgn.Items.Count > 0)
                cbRpmPgn.Invoke(new MethodInvoker(() => { cbRpmPgn.SelectedIndex = 0; }));
            if (cbWaterTempPgn.Items.Count > 0)
                cbWaterTempPgn.Invoke(new MethodInvoker(() => { cbWaterTempPgn.SelectedIndex = 0; }));
            if (cbOilPressPgn.Items.Count > 0)
                cbOilPressPgn.Invoke(new MethodInvoker(() => { cbOilPressPgn.SelectedIndex = 0; }));
            if (cbEngineAlarmsPgn.Items.Count > 0)
                cbEngineAlarmsPgn.Invoke(new MethodInvoker(() => { cbEngineAlarmsPgn.SelectedIndex = 0; }));
            if (cbHourMeterPgn.Items.Count > 0)
                cbHourMeterPgn.Invoke(new MethodInvoker(() => { cbHourMeterPgn.SelectedIndex = 0; }));
            _existingConfig.PortVoltage.PGN = 555;
            //Set variable PGNs
            if (!cbBatteryVoltageSource.Items.Contains(_existingConfig.PortVoltage.PGN))
            {

                if (_existingConfig.PortVoltage.PGN > 0)
                {
                    cbBatteryVoltageSource.Items.Add(_existingConfig.PortVoltage.PGN);
                    cbBatteryVoltageSource.Invoke(new MethodInvoker(() => { cbBatteryVoltageSource.SelectedIndex = cbBatteryVoltageSource.Items.IndexOf(_existingConfig.PortVoltage.PGN); }));
                }
            }


        }

        private void btnRefreshDeviceList_Click(object sender, EventArgs e)
        {
            refreshList();
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
