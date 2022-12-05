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
    public partial class RudderTrimNmea2000Config : Form
    {
        private List<object> _instanceList = new List<object>();
        private List<N2KDevice> _n2kDevices = new List<N2KDevice>();
        private RudderTrimNmea2000Configuration _existingRudderTrimConfig;
        public RudderTrimNmea2000Configuration NewRudderTrimConfig { get; private set; }
        public RudderTrimNmea2000Config(RudderTrimNmea2000Configuration rudderTrimConfig, string friendlyName)
        {
            //Copy existing configuration or create new config
            if(rudderTrimConfig == null)
                _existingRudderTrimConfig = new RudderTrimNmea2000Configuration();
            
            else
                _existingRudderTrimConfig = rudderTrimConfig;
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
            setExistingSourceConfig(cbPortTrimSource, _existingRudderTrimConfig.PortTrim);
            setExistingSourceConfig(cbStbdTrimSource, _existingRudderTrimConfig.StbdTrim);
            setExistingSourceConfig(cbRudderSource, _existingRudderTrimConfig.Rudder);

            //Serial config
            setExistingSerialConfig(cbPortTrimSerial, _existingRudderTrimConfig.PortTrim);
            setExistingSerialConfig(cbStbdTrimSerial, _existingRudderTrimConfig.StbdTrim);
            setExistingSerialConfig(cbRudderSerial, _existingRudderTrimConfig.Rudder);

            //Instance config
            fillInstanceComboboxes();
            setExistingInstanceConfig(cbRudderInstance, _existingRudderTrimConfig.Rudder);

            //Subscribe to Source combobox selected index changed events
            cbPortTrimSource.SelectedIndexChanged += CbSource_SelectedIndexChanged;
            cbStbdTrimSource.SelectedIndexChanged += CbSource_SelectedIndexChanged;
            cbRudderSource.SelectedIndexChanged += CbSource_SelectedIndexChanged;

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
                case ("cbPortTrimSource"):
                    cbPortTrimSerial.Enabled = true;
                    updateSerialComboboxItems(callingCombobox, cbPortTrimSerial);
                    break;
                case ("cbStbdTrimSource"):
                    cbStbdTrimSerial.Enabled = true;
                    updateSerialComboboxItems(callingCombobox, cbStbdTrimSerial);
                    break;
                case ("cbRudderSource"):
                    cbRudderSerial.Enabled = true;
                    cbRudderInstance.Enabled = true;
                    updateSerialComboboxItems(callingCombobox, cbRudderSerial);
                    updateInstanceComboboxItems(cbRudderInstance);
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
            //Port/Stbd trim
            _n2kDevices.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(130576)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbPortTrimSource, new object[] { obj.ProductInformation.ModelId });
                addItemsToComboBox(cbStbdTrimSource, new object[] { obj.ProductInformation.ModelId });
            });

            //Rudder
            _n2kDevices.Where(obj => obj.TxPgns != null && obj.TxPgns.Contains(127245)).ToList().ForEach(obj =>
            {
                addItemsToComboBox(cbRudderSource, new object[] { obj.ProductInformation.ModelId });
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
            addItemsToComboBox(cbRudderInstance, instance);
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
            //Create new rudder/trim configuration and save individual configurations.
            RudderTrimNmea2000Configuration newRudderTrimConfig = new RudderTrimNmea2000Configuration();
            //Port trim
            var device = _n2kDevices.Where(dev => dev.ProductInformation.ModelId == cbPortTrimSource.SelectedItem.ToString() && dev.ProductInformation.ModelSerialCode == cbPortTrimSerial.SelectedItem.ToString()).SingleOrDefault();
            if (device != null)
                newRudderTrimConfig.PortTrim = new N2KDataBinding(device, Convert.ToUInt32(lblPortTrimPgn.Text), Convert.ToByte(0));
            else
                newRudderTrimConfig.PortTrim = _existingRudderTrimConfig.PortTrim;

            //Stbd trim
            device = _n2kDevices.Where(dev => dev.ProductInformation.ModelId == cbStbdTrimSource.SelectedItem.ToString() && dev.ProductInformation.ModelSerialCode == cbStbdTrimSerial.SelectedItem.ToString()).SingleOrDefault();
            if (device != null)
                newRudderTrimConfig.StbdTrim = new N2KDataBinding(device, Convert.ToUInt32(lblStbdTrimPgn.Text), Convert.ToByte(0));
            else
                newRudderTrimConfig.StbdTrim = _existingRudderTrimConfig.StbdTrim;

            //Rudder
            device = _n2kDevices.Where(dev => dev.ProductInformation.ModelId == cbRudderSource.SelectedItem.ToString() && dev.ProductInformation.ModelSerialCode == cbRudderSerial.SelectedItem.ToString()).SingleOrDefault();
            if (device != null)
                newRudderTrimConfig.Rudder = new N2KDataBinding(device, Convert.ToUInt32(lblRudderPgn.Text), Convert.ToByte(cbRudderInstance.SelectedItem.ToString()));
            else
                newRudderTrimConfig.Rudder = _existingRudderTrimConfig.Rudder;

            NewRudderTrimConfig = newRudderTrimConfig;
            return true;
        }
        #endregion

        private void cbRpmSource_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbEngineTempSource_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbOilPressSource_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
