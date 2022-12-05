using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private List<N2KDevice> _n2kDevices = new List<N2KDevice>();
        private PropulsionNmea2000Configuration _existingPropulsionConfig;
        public PropulsionNmea2000Configuration NewPropulsionConfig { get; private set; }
        public PropulsionNmea2000Config(PropulsionNmea2000Configuration propulsionConfig, string friendlyName)
        {
            //Copy existing configuration or create new config
            if(propulsionConfig == null)
                _existingPropulsionConfig = new PropulsionNmea2000Configuration();
            
            else
                _existingPropulsionConfig = propulsionConfig;
            this.HandleCreated += Nmea2000Config_HandleCreated;
            InitializeComponent();

            //Set banner text
            lblWindowBanner.Text = String.Format("NMEA2000 Configuration - {0}", friendlyName);
        }
        private void Nmea2000Config_HandleCreated(object sender, EventArgs e)
        {
            //Create instance list
            for (int i = 0; i < 1000; i++)
            {
                _instanceList.Add(i.ToString());
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

            //Scan for connected NMEA 2000 devices
            refreshConnectedDeviceList();
        }
        private void CanGateway_MessageRecieved(object sender, WhatTheHelmCanLib.Messages.CanMessageArgs e)
        {
            if (this.IsHandleCreated)
            {
                //Product information PGN 126996
                if (e.Message.Pgn == 126996)
                {
                    var prodInfo = new Pgn0x1F014();
                    prodInfo = (Pgn0x1F014)prodInfo.DeserializeFields(e.Message.Data);
                    if(prodInfo != null)
                    {
                        N2KDevice n2kDevice = new N2KDevice(e.Message.SourceAddress);
                        n2kDevice.ProductInformation = prodInfo.ProductInformation;
                        _n2kDevices.Add(n2kDevice);
                        listBox1.Invoke(new MethodInvoker(() => listBox1.Items.Add(n2kDevice.ToString())));
                    }
                }
                //Pgn List PGN 126464
                if (e.Message.Pgn == 126464)
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
                    else if (pgnList.PgnListType == PgnListType.Receive)
                        updatedObj.RxPgns = pgnList.PgnReceiveList;
                    //Add N2K object to device list
                    _n2kDevices.Add(updatedObj);
                }
            }
        }

        #region User Interaction
        private void CbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var callingCombobox = (ComboBox)sender;
            switch(callingCombobox.Name)
            {
                case ("cbRpmSource"):
                    cbRpmSerial.Enabled = true;
                    cbRpmInstance.Enabled = true;
                    updateSerialComboboxItems(callingCombobox, cbRpmSerial);
                    updateInstanceComboboxItems(cbRpmInstance);
                    break;
                case ("cbEngineTempSource"):
                    cbEngineTempSerial.Enabled = true;
                    cbEngineTempInstance.Enabled = true;
                    updateSerialComboboxItems(callingCombobox, cbEngineTempSerial);
                    updateInstanceComboboxItems(cbEngineTempInstance);
                    break;
                case ("cbOilPressSource"):
                    cbOilPressSerial.Enabled = true;
                    cbOilPressInstance.Enabled = true;
                    updateSerialComboboxItems(callingCombobox, cbOilPressSerial);
                    updateInstanceComboboxItems(cbOilPressInstance);
                    break;
                case ("cbEngineAlarmsSource"):
                    cbEngineAlarmsSerial.Enabled = true;
                    cbEngineAlarmsInstance.Enabled = true;
                    updateSerialComboboxItems(callingCombobox, cbEngineAlarmsSerial);
                    updateInstanceComboboxItems(cbEngineAlarmsInstance);
                    break;
                case ("cbEngineHoursSource"):
                    cbEngineHoursSerial.Enabled = true;
                    cbEngineHoursInstance.Enabled = true;
                    updateSerialComboboxItems(callingCombobox, cbEngineHoursSerial);
                    updateInstanceComboboxItems(cbEngineHoursInstance);
                    break;
                case ("cbTransPressSource"):
                    cbTransPressSerial.Enabled = true;
                    cbTransPressInstance.Enabled = true;
                    updateSerialComboboxItems(callingCombobox, cbTransPressSerial);
                    updateInstanceComboboxItems(cbTransPressInstance);
                    break;
                case ("cbTransAlarmsSource"):
                    cbTransAlarmsSerial.Enabled = true;
                    cbTransAlarmsInstance.Enabled = true;
                    updateSerialComboboxItems(callingCombobox, cbTransAlarmsSerial);
                    updateInstanceComboboxItems(cbTransAlarmsInstance);
                    break;
                case ("cbAlternatorPotentialSource"):
                    cbAlternatorPotentialSerial.Enabled = true;
                    cbAlternatorPotentialPgn.Enabled = true;
                    cbAlternatorPotentialInstance.Enabled = true;
                    updateSerialComboboxItems(callingCombobox, cbAlternatorPotentialSerial);
                    updatePgnComboboxItems(callingCombobox, cbAlternatorPotentialSerial, cbAlternatorPotentialPgn, new List<uint>() { 127508, 127489 });
                    updateInstanceComboboxItems(cbAlternatorPotentialInstance);
                    break;
            }
        }
        private void updateSerialComboboxItems(ComboBox sourceComboBox, ComboBox serialComboBox)
        {
            //Delete existing items
            serialComboBox.Items.Clear();
            //Find serial number of each type of source model ID - for example if there are two engine gateways, list both serial numbers.
            _n2kDevices.Where(device => device.ProductInformation.ModelId == sourceComboBox.SelectedItem.ToString()).Distinct().ToList().ForEach(dev => { serialComboBox.Items.Add(dev.ProductInformation.ModelSerialCode); });
            //Set the first serial number as selected item as default.
            if(serialComboBox.Items.Count > 0)
                serialComboBox.SelectedIndex = 0;
            //If only one serial number option, disable combo box
            if (serialComboBox.Items.Count == 1)
                serialComboBox.Enabled = false;
        }
        private void updateInstanceComboboxItems(ComboBox instanceComboBox)
        {
            instanceComboBox.Items.Clear();
            instanceComboBox.Items.AddRange(_instanceList.ToArray());
            if(instanceComboBox.Items.Count > 0)
                instanceComboBox.SelectedIndex = 0;
        }
        private void updatePgnComboboxItems(ComboBox sourceComboBox, ComboBox serialComboBox, ComboBox pgnComboBox, List<uint> pgnItems)
        {
            //Delete existing items
            pgnComboBox.Items.Clear();

            //Find the selected source device using a combination of model ID and serial number
            var n2kDevice = _n2kDevices.Where(device => device.ProductInformation.ModelId == sourceComboBox.SelectedItem.ToString() && device.ProductInformation.ModelSerialCode == serialComboBox.SelectedItem.ToString()).First();        
            //Add PGN options.
            foreach(uint pgn in pgnItems)
                if (n2kDevice.TxPgns.Contains(pgn))
                    pgnComboBox.Items.Add(pgn);
            //Set the first pgn as selected item as default.
            if (pgnComboBox.Items.Count > 0)
                pgnComboBox.SelectedIndex = 0;
        }
        #endregion

        #region Existing Configuration
        private void setExistingSourceConfig(ComboBox cb, N2KDataBinding n2KDataBinding)
        {
            if (n2KDataBinding != null)
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
                cb.SelectedIndex = cb.Items.IndexOf(n2KDataBinding.Instance.ToString());
            }
        }
        #endregion

        #region Connected Devices
        private void refreshConnectedDeviceList()
        {
            //Disable button temporarily
            btnRefreshDeviceList.Enabled = false;

            //Subscribe to NMEA 2000 messages
            Program.CanGateway.MessageRecieved += CanGateway_MessageRecieved;

            //Clear networked devices list
            _n2kDevices.Clear();
            listBox1.Items.Clear();

            //Issue request for product information and PGN lists from networked devices
            var gw = (Ngt1)Program.CanGateway;
            gw.IsoRequest(126996);
            gw.IsoRequest(126464);

            //Allow 500ms for NMEA2000 devices to respond to requests for product information and pgn lists
            Timer t = new Timer();
            t.Interval = 500;
            t.Tick += T_Tick;
            t.Start();
        }
        private void T_Tick(object sender, EventArgs e)
        {
            //Unsubscribe to NMEA 2000 messages
            Program.CanGateway.MessageRecieved -= CanGateway_MessageRecieved;

            //Dispose of timer
            var timer = (Timer)sender;
            timer.Stop();
            timer.Tick -= T_Tick;
            timer.Dispose();

            //Update networked devices list
            _n2kDevices = _n2kDevices.Distinct().ToList();
            addConnectedDeviceSources();

            //Enable button
            btnRefreshDeviceList.Enabled = true;
        }
        private void addConnectedDeviceSources()
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
                addItemsToComboBox(cbTransAlarmsSource, new object[] { obj.ProductInformation.ModelId });
            });
            //Battery
            List<object> batteryPgns = new List<object>();
            _n2kDevices.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127508) | obj.TxPgns.Contains(127489)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbAlternatorPotentialSource, new object[] { obj.ProductInformation.ModelId });
            });
        }
        private void btnRefreshDeviceList_Click(object sender, EventArgs e)
        {
            refreshConnectedDeviceList();
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
        #endregion

        #region Save/Cancel
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<Control, Color>> flaggedControls = new List<KeyValuePair<Control, Color>>();
            var valid = flagMissingFields(out flaggedControls);
            if (!valid)
            {
                MessageBox.Show("Configuration is incomplete!\nSource, serial number, PGN and instance must be set for each data point!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                resetMissingFieldFlags(flaggedControls);
            }
            else
            {
                if(saveConfig() == true)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                    MessageBox.Show("Failed to save configuration!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private bool flagMissingFields(out List<KeyValuePair<Control,Color>> flaggedControls)
        {
            bool fieldIsMissing = false;
            flaggedControls = new List<KeyValuePair<Control, Color>>();
            var groupBoxes = this.Controls.OfType<GroupBox>();
            foreach(GroupBox groupBox in groupBoxes)
            {
                var comboBoxes = groupBox.Controls.OfType<ComboBox>();
                foreach (ComboBox comboBox in comboBoxes)
                    if (comboBox.SelectedIndex == -1)
                    {
                        fieldIsMissing = true;
                        var defaultColor = comboBox.BackColor;
                        flaggedControls.Add(new KeyValuePair<Control,Color>(comboBox,defaultColor));
                        comboBox.BackColor = Color.Yellow;
                    }
                var labels = groupBox.Controls.OfType<Label>();
                foreach (Label label in labels)
                    if (String.IsNullOrEmpty(label.Text))
                    {
                        fieldIsMissing = true;
                        var defaultColor = label.BackColor;
                        flaggedControls.Add(new KeyValuePair<Control, Color>(label, defaultColor));
                        label.BackColor = Color.Yellow;
                    }
            }
            if (fieldIsMissing)
                return false;
            return true;
        }

        private void resetMissingFieldFlags(List<KeyValuePair<Control, Color>> flaggedControls)
        {
            foreach (KeyValuePair<Control, Color> control in flaggedControls)
                control.Key.BackColor = control.Value;
        }

        private bool saveConfig()
        {
            //Create new propulsion configuration and save individual configurations.
            PropulsionNmea2000Configuration newPropulsionConfig = new PropulsionNmea2000Configuration();
            //RPM
            var device = _n2kDevices.Where(dev => dev.ProductInformation.ModelId == cbRpmSource.SelectedItem.ToString() && dev.ProductInformation.ModelSerialCode == cbRpmSerial.SelectedItem.ToString()).SingleOrDefault();
            if (device != null)
                newPropulsionConfig.Rpm = new N2KDataBinding(device, Convert.ToUInt32(lblRpmPgn.Text), Convert.ToByte(cbRpmInstance.SelectedItem.ToString()));
            else
                newPropulsionConfig.Rpm = _existingPropulsionConfig.Rpm;

            //Engine temperature
            device = _n2kDevices.Where(dev => dev.ProductInformation.ModelId == cbEngineTempSource.SelectedItem.ToString() && dev.ProductInformation.ModelSerialCode == cbEngineTempSerial.SelectedItem.ToString()).SingleOrDefault();
            if (device != null)
                newPropulsionConfig.EngineTemperature = new N2KDataBinding(device, Convert.ToUInt32(lblEngineTempPgn.Text), Convert.ToByte(cbEngineTempInstance.SelectedItem.ToString()));
            else
                newPropulsionConfig.EngineTemperature = _existingPropulsionConfig.EngineTemperature;

            //Engine oil pressure
            device = _n2kDevices.Where(dev => dev.ProductInformation.ModelId == cbOilPressSource.SelectedItem.ToString() && dev.ProductInformation.ModelSerialCode == cbOilPressSerial.SelectedItem.ToString()).SingleOrDefault();
            if (device != null)
                newPropulsionConfig.OilPressure = new N2KDataBinding(device, Convert.ToUInt32(lblOilPressPgn.Text), Convert.ToByte(cbOilPressInstance.SelectedItem.ToString()));
            else
                newPropulsionConfig.OilPressure = _existingPropulsionConfig.OilPressure;

            //Engine alarms
            device = _n2kDevices.Where(dev => dev.ProductInformation.ModelId == cbEngineAlarmsSource.SelectedItem.ToString() && dev.ProductInformation.ModelSerialCode == cbEngineAlarmsSerial.SelectedItem.ToString()).SingleOrDefault();
            if (device != null)
                newPropulsionConfig.EngineAlarms = new N2KDataBinding(device, Convert.ToUInt32(lblEngineAlarmsPgn.Text), Convert.ToByte(cbEngineAlarmsInstance.SelectedItem.ToString()));
            else
                newPropulsionConfig.EngineAlarms = _existingPropulsionConfig.EngineAlarms;

            //Engine hours
            device = _n2kDevices.Where(dev => dev.ProductInformation.ModelId == cbEngineHoursSource.SelectedItem.ToString() && dev.ProductInformation.ModelSerialCode == cbEngineHoursSerial.SelectedItem.ToString()).SingleOrDefault();
            if (device != null)
                newPropulsionConfig.EngineHours = new N2KDataBinding(device, Convert.ToUInt32(lblEngineHoursPgn.Text), Convert.ToByte(cbEngineHoursInstance.SelectedItem.ToString()));
            else
                newPropulsionConfig.EngineHours = _existingPropulsionConfig.EngineHours;

            //Alternator potential
            device = _n2kDevices.Where(dev => dev.ProductInformation.ModelId == cbAlternatorPotentialSource.SelectedItem.ToString() && dev.ProductInformation.ModelSerialCode == cbAlternatorPotentialSerial.SelectedItem.ToString()).SingleOrDefault();
            if (device != null)
                newPropulsionConfig.AlternatorPotential = new N2KDataBinding(device, Convert.ToUInt32(cbAlternatorPotentialPgn.SelectedItem), Convert.ToByte(cbAlternatorPotentialInstance.SelectedItem.ToString()));
            else
                newPropulsionConfig.AlternatorPotential = _existingPropulsionConfig.AlternatorPotential;

            //Transmission pressure
            device = _n2kDevices.Where(dev => dev.ProductInformation.ModelId == cbTransPressSource.SelectedItem.ToString() && dev.ProductInformation.ModelSerialCode == cbTransPressSerial.SelectedItem.ToString()).SingleOrDefault();
            if (device != null)
                newPropulsionConfig.TransPressure = new N2KDataBinding(device, Convert.ToUInt32(lblTransPressPgn.Text), Convert.ToByte(cbTransPressInstance.SelectedItem.ToString()));
            else
                newPropulsionConfig.TransPressure = _existingPropulsionConfig.TransPressure;

            //Transmission alarms
            device = _n2kDevices.Where(dev => dev.ProductInformation.ModelId == cbTransAlarmsSource.SelectedItem.ToString() && dev.ProductInformation.ModelSerialCode == cbTransAlarmsSerial.SelectedItem.ToString()).SingleOrDefault();
            if (device != null)
                newPropulsionConfig.TransAlarms = new N2KDataBinding(device, Convert.ToUInt32(lblTransAlarmsPgn.Text), Convert.ToByte(cbTransAlarmsInstance.SelectedItem.ToString()));
            else
                newPropulsionConfig.TransAlarms = _existingPropulsionConfig.TransAlarms;
            NewPropulsionConfig = newPropulsionConfig;
            return true;
        }
        #endregion
    }
}
