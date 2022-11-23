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
using WhatTheHelmCanLib.Devices.NMEA2000;
using WhatTheHelmCanLib.Devices.NMEA2000.Actisense;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;

namespace WhatTheHelmRuntime
{
    public partial class PropulsionNmea2000Config : Form
    {
        private List<object> _instanceList = new List<object>();
        private List<N2KProductInformation> _productInformation = new List<N2KProductInformation>();
        private List<N2KDevice> _n2kDevices = new List<N2KDevice>();
        private PropulsionNmea2000Configuration _existingPropulsionConfig;
        public PropulsionNmea2000Config(PropulsionNmea2000Configuration propulsionConfig)
        {
            if(propulsionConfig == null)
            {
                _existingPropulsionConfig = new PropulsionNmea2000Configuration();
                //TEST CODE - DELETE
                N2KDevice n2KDevice = new N2KDevice(1);
                n2KDevice.ProductInformation = new N2KProductInformation(0, 0, "Model123", "v111", "v222", "Ser123", 1, 1);
                _existingPropulsionConfig.Rpm = new N2KDataBinding(n2KDevice);
                _existingPropulsionConfig.Rpm.PGN = 11111;
                _existingPropulsionConfig.Rpm.Instance = 0;

            }
            else
                _existingPropulsionConfig = propulsionConfig;
            this.HandleCreated += Nmea2000Config_HandleCreated;
            InitializeComponent();

        }

        private void Nmea2000Config_HandleCreated(object sender, EventArgs e)
        {

            for (int i = 0; i < 1000; i++)
            {
                _instanceList.Add(i);
            }
            //Set comboboxes using existing propulsion configuration

            //Sources config
            setExistingSourceConfig(cbRpmSource, _existingPropulsionConfig.Rpm);
            setExistingSourceConfig(cbEngineTempSource, _existingPropulsionConfig.EngineTemperature);
            setExistingSourceConfig(cbOilPressSource, _existingPropulsionConfig.OilPressure);
            setExistingSourceConfig(cbEngineAlarmsSource, _existingPropulsionConfig.EngineAlarms);
            setExistingSourceConfig(cbEngineHoursSource, _existingPropulsionConfig.EngineHours);
            setExistingSourceConfig(cbTransPressSource, _existingPropulsionConfig.TransPressure);
            setExistingSourceConfig(cbTransAlarmsSource, _existingPropulsionConfig.TransAlarms);
            setExistingSourceConfig(cbAlternatorPotentialSource, _existingPropulsionConfig.AlternatorPotential);

            //Serial config
            setExistingSerialConfig(cbRpmSerial, _existingPropulsionConfig.Rpm);
            setExistingSerialConfig(cbEngineTempSerial, _existingPropulsionConfig.EngineTemperature);
            setExistingSerialConfig(cbOilPressSerial, _existingPropulsionConfig.OilPressure);
            setExistingSerialConfig(cbEngineAlarmsSerial, _existingPropulsionConfig.EngineAlarms);
            setExistingSerialConfig(cbEngineHoursSerial, _existingPropulsionConfig.EngineHours);
            setExistingSerialConfig(cbTransPressSerial, _existingPropulsionConfig.TransPressure);
            setExistingSerialConfig(cbTransAlarmsSerial, _existingPropulsionConfig.TransAlarms);
            setExistingSerialConfig(cbAlternatorPotentialSerial, _existingPropulsionConfig.AlternatorPotential);

            //PGN config
            setExistingPgnConfig(cbAlternatorPotentialPgn, _existingPropulsionConfig.AlternatorPotential);

            //Instance config
            fillInstanceComboboxes();
            setExistingInstanceConfig(cbRpmInstance, _existingPropulsionConfig.Rpm);
            setExistingInstanceConfig(cbEngineTempInstance, _existingPropulsionConfig.EngineTemperature);
            setExistingInstanceConfig(cbOilPressInstance, _existingPropulsionConfig.OilPressure);
            setExistingInstanceConfig(cbEngineAlarmsInstance, _existingPropulsionConfig.EngineAlarms);
            setExistingInstanceConfig(cbEngineHoursInstance, _existingPropulsionConfig.EngineHours);
            setExistingInstanceConfig(cbTransPressInstance, _existingPropulsionConfig.TransPressure);
            setExistingInstanceConfig(cbTransAlarmsInstance, _existingPropulsionConfig.TransAlarms);
            setExistingInstanceConfig(cbAlternatorPotentialInstance, _existingPropulsionConfig.AlternatorPotential);

            //Subscribe to Source combobox selected index changed events
            cbRpmSource.SelectedIndexChanged += CbSource_SelectedIndexChanged;
            cbEngineTempSource.SelectedIndexChanged += CbSource_SelectedIndexChanged;
            cbOilPressSource.SelectedIndexChanged += CbSource_SelectedIndexChanged;
            cbEngineAlarmsSource.SelectedIndexChanged += CbSource_SelectedIndexChanged;
            cbEngineHoursSource.SelectedIndexChanged += CbSource_SelectedIndexChanged;
            cbTransPressSource.SelectedIndexChanged += CbSource_SelectedIndexChanged;
            cbTransAlarmsSource.SelectedIndexChanged += CbSource_SelectedIndexChanged;
            cbAlternatorPotentialSource.SelectedIndexChanged += CbSource_SelectedIndexChanged;

            //Subscribe to NMEA 2000 messages
            Program.CanGateway.MessageRecieved += CanGateway_MessageRecieved;

            //Scan for connected NMEA 2000 devices
            refreshN2KDeviceList();
        }

        private void CbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(sender.GetType().Name)
            {
                case ("foo"):
                    break;
            }
            throw new NotImplementedException();
        }

        private void fillInstanceComboboxes()
        {
            object[] instance = _instanceList.ToArray();
            addItemsToComboBox(cbRpmInstance, instance);
            addItemsToComboBox(cbEngineTempInstance, instance);
            addItemsToComboBox(cbOilPressInstance, instance);
            addItemsToComboBox(cbEngineAlarmsInstance, instance);
            addItemsToComboBox(cbEngineHoursInstance, instance);
            addItemsToComboBox(cbTransPressInstance, instance);
            addItemsToComboBox(cbAlternatorPotentialInstance, instance);
            instance = null;
        }

        private void setExistingSourceConfig(ComboBox cb, N2KDataBinding n2KDataBinding)
        {
            if(n2KDataBinding != null)
            {
                addItemsToComboBox(cb, new object[] { n2KDataBinding.Nmea2000Device.ProductInformation.ModelId });
                cb.SelectedItem = n2KDataBinding.Nmea2000Device.ProductInformation.ModelId;
            }    
        }

        private void setExistingSerialConfig(ComboBox cb, N2KDataBinding n2KDataBinding)
        {
            if (n2KDataBinding != null)
            {
                addItemsToComboBox(cb, new object[] { n2KDataBinding.Nmea2000Device.ProductInformation.ModelSerialCode });
                cb.SelectedItem = n2KDataBinding.Nmea2000Device.ProductInformation.ModelSerialCode;
            }
        }

        private void setExistingPgnConfig(ComboBox cb, N2KDataBinding n2KDataBinding)
        {
            if (n2KDataBinding != null)
            {
                addItemsToComboBox(cb, new object[] { n2KDataBinding.PGN });
                cb.SelectedItem = n2KDataBinding.PGN;
            }
        }

        private void setExistingInstanceConfig(ComboBox cb, N2KDataBinding n2KDataBinding)
        {
            if (n2KDataBinding != null)
            {
                addItemsToComboBox(cb, _instanceList.ToArray());
                cbRpmInstance.SelectedItem = n2KDataBinding.Instance;
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
                    N2KDevice n2kDevice = new N2KDevice(e.Message.SourceAddress);
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
                        updatedObj.TxPgns = pgnList.PgnTransmitList;  
                    //Returned list is Rx
                    else if(pgnList.PgnListType == PgnListType.Receive)
                        updatedObj.RxPgns = pgnList.PgnReceiveList;
                    //Replace old N2K object with new
                    //_n2kDevices.Remove(foundObj);
                    _n2kDevices.Add(updatedObj);
                }
            }
        }

        private void refreshN2KDeviceList()
        {
            //Allow 500ms for NMEA2000 devices to respond to requests for product information and pgn lists
            var gw = (Ngt1)Program.CanGateway;
            gw.IsoRequest(126996);
            gw.IsoRequest(126464);
            _n2kDevices.Clear();
            listBox1.Items.Clear();
            Timer t = new Timer();
            t.Interval = 500;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            var timer = (Timer)sender;
            timer.Stop();
            timer.Tick -= T_Tick;
            timer.Dispose();
            addNetworkDeviceSources();
            addNetworkDeviceSerials();
            //setComboBoxSelectedItems(); 
            //resetComboBoxSelections();
        }


        private void addNetworkDeviceSources()
        {
            //RPM
            _n2kDevices.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127488)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbRpmSource, new object[] { obj.ProductInformation.ModelId });
            });

            //Engine oil pressure, water temperature, alarms
            _n2kDevices.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127489)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbEngineTempSource, new object[] { obj.ProductInformation.ModelId });
                addItemsToComboBox(cbOilPressSource, new object[] { obj.ProductInformation.ModelId });
                addItemsToComboBox(cbEngineAlarmsSource, new object[] { obj.ProductInformation.ModelId });
                addItemsToComboBox(cbEngineHoursSource, new object[] { obj.ProductInformation.ModelId });
            });
            //Trans hydraulic pressure, alarms
            _n2kDevices.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127493)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbTransPressSource, new object[] { obj.ProductInformation.ModelId });
            });
            //Battery
            List<object> batteryPgns = new List<object>();
            _n2kDevices.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127508) | obj.TxPgns.Contains(127489)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbAlternatorPotentialSource, new object[] { obj.ProductInformation.ModelId });
            });
        }

        private void addNetworkDeviceSerials()
        {
            //RPM
            _n2kDevices.Where(obj => obj.TxPgns!=null && obj.TxPgns.Contains(127488)).ToList().ForEach(obj => 
            {
                addItemsToComboBox(cbRpmSerial, new object[] {obj.ProductInformation.ModelSerialCode});
            });

            //Engine oil pressure, water temperature, alarms
            _n2kDevices.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127489)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbEngineTempSerial, new object[] { obj.ProductInformation.ModelSerialCode });
                addItemsToComboBox(cbOilPressSerial, new object[] { obj.ProductInformation.ModelSerialCode });
                addItemsToComboBox(cbEngineAlarmsSerial, new object[] { obj.ProductInformation.ModelSerialCode });
                addItemsToComboBox(cbEngineHoursSerial, new object[] { obj.ProductInformation.ModelSerialCode });
            });
            //Trans pressure, alarms
            _n2kDevices.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127493)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbTransPressSerial, new object[] { obj.ProductInformation.ModelSerialCode });
            });
            //Battery
            _n2kDevices.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127508) | obj.TxPgns.Contains(127489)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbAlternatorPotentialSerial, new object[] { obj.ProductInformation.ModelSerialCode });
            });
        }

        private void addNetworkDevicePgns()
        {
            ////Battery
            //_n2kDevices.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127508) | obj.TxPgns.Contains(127489)).ToList().ForEach(obj =>
            //{
            //    addItemsToComboBox(cbBatteryVoltageSerial, new object[] { obj.ProductInformation.ModelSerialCode });
            //});
        }



        private void resetComboBoxSelections()
        {
            cbRpmSource.SelectedIndex = -1;
            cbRpmSerial.SelectedIndex = -1;
            cbRpmInstance.SelectedIndex = -1;
        }

        private void setComboBoxSelectedItems()
        {
            //Set variable PGNs
            _existingPropulsionConfig.Voltage = new WhatTheHelmCanLib.Devices.NMEA2000.N2KDataBinding(new N2KDevice(1));
            _existingPropulsionConfig.Voltage.PGN = 126234;
            if(_existingPropulsionConfig.Voltage!=null)
            {
                if (!cbAlternatorPotentialPgn.Items.Contains(_existingPropulsionConfig.Voltage.PGN))
                {

                    if (_existingPropulsionConfig.Voltage.PGN > 0)
                    {
                        cbAlternatorPotentialPgn.Items.Add(_existingPropulsionConfig.Voltage.PGN);
                        cbAlternatorPotentialPgn.Invoke(new MethodInvoker(() => { cbAlternatorPotentialPgn.SelectedIndex = cbAlternatorPotentialPgn.Items.IndexOf(_existingPropulsionConfig.Voltage.PGN); }));
                    }
                }
            }



        }

        #region Connected Devices

        private void btnRefreshDeviceList_Click(object sender, EventArgs e)
        {
            refreshN2KDeviceList();
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

        #endregion

        #region Helpers
        private void addItemsToComboBox(ComboBox cb, object[] items)
        {
            cb.Invoke(new MethodInvoker(() =>
            {
                foreach (object item in items)
                {
                    if (!cb.Items.Contains(item))
                        cb.Items.Add(item);
                }
            }));
        }

        #endregion
    }
}
