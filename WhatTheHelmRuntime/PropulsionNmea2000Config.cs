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
        public N2KProductInformation ProductInformation;
        public List<uint> RxPgns;
        public List<uint> TxPgns;
        public override string ToString()
        {
            return String.Format("{0}, {1}", ProductInformation.ModelId, ProductInformation.ModelSerialCode);
        }
    }
    public partial class PropulsionNmea2000Config : Form
    {
        private List<object> _instanceList = new List<object>();
        private List<N2KProductInformation> _productInformation = new List<N2KProductInformation>();
        private List<Nmea2000Device> _n2kDevices;
        private PropulsionNmea2000Configuration _existingPropulsionConfig;
        public PropulsionNmea2000Config(PropulsionNmea2000Configuration propulsionConfig)
        {
            if(propulsionConfig == null)
                _existingPropulsionConfig = new PropulsionNmea2000Configuration();
            else
                _existingPropulsionConfig = propulsionConfig;
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
            refreshList();
            initializeComboBoxes();

        }

        private void setExistingConfig()
        {
            if(_existingPropulsionConfig.Rpm.Nmea2000Device.ProductInformation != null)
            {
                addItemsToComboBox(cbRpmSource, new object[] { _existingPropulsionConfig.Rpm.Nmea2000Device.ProductInformation.ModelId });
                cbRpmSource.SelectedItem = _existingPropulsionConfig.Rpm.Nmea2000Device.ProductInformation.ModelId;
                addItemsToComboBox(cbRpmInstance, _instanceList.ToArray());
                cbRpmInstance.SelectedItem = _existingPropulsionConfig.Rpm.Instance;
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
                    Nmea2000Device n2kDevice = new Nmea2000Device(e.Message.SourceAddress);
                    n2kDevice.ProductInformation = prodInfo.ProductInformation;
                    _n2kDevices.Add(n2kDevice);
                    listBox1.Invoke( new MethodInvoker(()=>listBox1.Items.Add(n2kDevice.ToString())));             
                }
                //Pgn List
                if(e.Message.Pgn == 126464)
                {
                    var pgnList = new Pgn0x1EE00();
                    pgnList = (Pgn0x1EE00)pgnList.DeserializeFields(e.Message.Data);
                    //Copy existing N2K object
                    var foundObj = _n2kDevices.Where(obj => obj.Address == e.Message.SourceAddress).First();
                    var updatedObj = foundObj;
                    //Returned list is Tx
                    if (pgnList.PgnListType == PgnListType.Transmit)
                        updatedObj.N2KTxPgns = pgnList.PgnTransmitList;  
                    //Returned list is Rx
                    else if(pgnList.PgnListType == PgnListType.Receive)
                        updatedObj.N2KRxPgns = pgnList.PgnReceiveList;
                    //Replace old N2K object with new
                    _n2kDevices.Remove(foundObj);
                    _n2kDevices.Add(updatedObj);
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
            _n2kDevices.Where(obj => obj.N2KTxPgns!=null && obj.N2KTxPgns.Contains(127488)).ToList().ForEach(obj => 
            {
                addItemsToComboBox(cbRpmSource, new object[] { obj.ProductInformation.ModelId });
                addItemsToComboBox(cbRpmSourceSerial, new object[] {obj.ProductInformation.ModelSerialCode});
                addItemsToComboBox(cbRpmInstance, instance);
            });

            //Engine oil pressure, water temperature, alarms
            _n2kDevices.Where(obj => obj.N2KTxPgns != null && obj.N2KTxPgns.Contains(127489)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbWaterTempSource, new object[] { obj.ProductInformation.ModelId });
                addItemsToComboBox(cbWaterTempSerial, new object[] { obj.ProductInformation.ModelSerialCode });
                addItemsToComboBox(cbWaterTempInstance, instance);
                addItemsToComboBox(cbOilPressSource, new object[] { obj.ProductInformation.ModelId });
                addItemsToComboBox(cbOilPressSerial, new object[] { obj.ProductInformation.ModelSerialCode });
                addItemsToComboBox(cbOilPressInstance, instance);
                addItemsToComboBox(cbEngineAlarmsSource, new object[] { obj.ProductInformation.ModelId });
                addItemsToComboBox(cbEngineAlarmsSerial, new object[] { obj.ProductInformation.ModelSerialCode });
                addItemsToComboBox(cbEngineAlarmsInstance, instance);
                addItemsToComboBox(cbHourMeterSource, new object[] { obj.ProductInformation.ModelId });
                addItemsToComboBox(cbHourMeterSerial, new object[] { obj.ProductInformation.ModelSerialCode });
                addItemsToComboBox(cbHourMeterInstance, instance);
            });
            //Trans hydraulic pressure, alarms
            _n2kDevices.Where(obj => obj.N2KTxPgns != null && obj.N2KTxPgns.Contains(127493)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbTransPressSource, new object[] { obj.ToString() });
                addItemsToComboBox(cbTransPressInstance, instance);
            });
            //Battery
            List<object> batteryPgns = new List<object>();
            _n2kDevices.Where(obj => obj.N2KTxPgns != null && obj.N2KTxPgns.Contains(127508) | obj.N2KTxPgns.Contains(127489)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbBatteryVoltageSource, new object[] { obj.ToString() });
                if (obj.N2KTxPgns.Contains(127508) & !batteryPgns.Contains(127508))
                    batteryPgns.Add(127508);
                if(obj.N2KTxPgns.Contains(127489) & !batteryPgns.Contains(127489))
                    batteryPgns.Add(127489);

            });
            addItemsToComboBox(cbBatteryVoltagePgn, batteryPgns.ToArray());
            addItemsToComboBox(cbBatteryVoltageInstance, instance);
            instance = null;
        }

        private void addItemsToComboBox(ComboBox cb, object[] items)
        {
            cb.Invoke(new MethodInvoker(() =>
            {
                foreach (object item in items)
                {
                    if(!cb.Items.Contains(item))
                        cb.Items.Add(item);
                }
            }));        
        }

        private void setComboBoxSelectedItems()
        {
            //Set variable PGNs
            if (!cbBatteryVoltageSource.Items.Contains(_existingPropulsionConfig.PortVoltage.PGN))
            {

                if (_existingPropulsionConfig.PortVoltage.PGN > 0)
                {
                    cbBatteryVoltageSource.Items.Add(_existingPropulsionConfig.PortVoltage.PGN);
                    cbBatteryVoltageSource.Invoke(new MethodInvoker(() => { cbBatteryVoltageSource.SelectedIndex = cbBatteryVoltageSource.Items.IndexOf(_existingPropulsionConfig.PortVoltage.PGN); }));
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
