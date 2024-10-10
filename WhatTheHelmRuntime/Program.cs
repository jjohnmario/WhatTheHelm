using WhatTheHelmCanLib.Devices;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using WhatTheHelmCanLib.Devices.NMEA2000.Actisense;
using WhatTheHelmCanLib.Devices.Nmea2000;
using WhatTheHelmCanLib.ParameterGroups.NMEA2000;
using WhatTheHelmCanLib.Devices.NMEA2000;

namespace WhatTheHelmRuntime
{
    static class Program
    {
        public static Ngt1 CanGateway { get; set; }       
        public static Configuration Configuration { get; set; }
        public static Configuration RunningConfiguration { get; set; }
        public static bool ConnectedDeviceScanBusy;
        private static List<N2KDevice> _n2kDevices = new List<N2KDevice>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                //Initialize configuration
                InitializeConfiguration();

                //Periodically check for new devices that joined the CAN bus after the application started.
                Timer checkForNewDevicesTimer = new Timer();
                checkForNewDevicesTimer.Interval = 60000;
                checkForNewDevicesTimer.Tick += CheckForNewDevicesTimer_Tick;
                checkForNewDevicesTimer.Start();

                //Try to run the application across five screens.  Else run off one screen.
                try
                {
                    //Get list of all screens.
                    Screen[] screens = Screen.AllScreens;

                    //Get list of 1280x800 screens.
                    var screens1280x800 = Screen.AllScreens.Where(size => size.Bounds.Height == 800 & size.Bounds.Width == 1280).ToList();

                    //Get the primary 1280x800 screen and assign it as a "PortGauges" screen.
                    Screen portGaugesScreen = screens1280x800.Where(y => y.Primary).OrderBy(x => x.DeviceName).First();
                    screens1280x800.Remove(portGaugesScreen);
                    //Get next number 1280x800 screen and assign it as a "StbdGauges" screen.
                    Screen stbdGaugesScreen = screens1280x800.OrderBy(x => x.DeviceName).First();

                    //Get list of 800x480 screens.
                    var screens800x480 = Screen.AllScreens.Where(size => size.Bounds.Height == 480 & size.Bounds.Width == 800).ToList();

                    //Get the left-most 640x480 screen and assign it as a "SwitchPanel" screen.
                    Screen switchPanelScreen = screens800x480.OrderBy(x => x.Bounds.X).First();
                    screens800x480.Remove(switchPanelScreen);

                    //Get the next left-most 640x480 screen and assign it as a "Rudder" screen.
                    Screen rudderScreen = screens800x480.OrderBy(x => x.Bounds.X).First();
                    screens800x480.Remove(rudderScreen);

                    //Get the least left-most 640x480 screen and assign it as a "TrimControl" screen.
                    Screen trimControlScreen = screens800x480.OrderBy(x => x.Bounds.X).First();

                    //Bind all but PortGauges forms to physical screens
                    List<KeyValuePair<Screen, Type>> screenAssignmentList = new List<KeyValuePair<Screen, Type>>();
                    screenAssignmentList.Add(new KeyValuePair<Screen, Type>(stbdGaugesScreen, typeof(StbdGauges)));
                    screenAssignmentList.Add(new KeyValuePair<Screen, Type>(switchPanelScreen, typeof(SwitchPanel)));
                    screenAssignmentList.Add(new KeyValuePair<Screen, Type>(trimControlScreen, typeof(TrimControl)));
                    screenAssignmentList.Add(new KeyValuePair<Screen, Type>(rudderScreen, typeof(Rudder)));

                    //Bind PortGauges form to physical screen
                    //Pass screen/type list as constructor for guages screen.  This allows other screens to be spawned from the Gauges screen and on the UI thread.
                    PortGauges portGauges = new PortGauges(screenAssignmentList);
                    portGauges.Bounds = portGaugesScreen.Bounds;
                    portGauges.StartPosition = FormStartPosition.Manual;
                    Application.Run(portGauges);
                }
                catch
                {
                    PortGauges portGauges = new PortGauges();
                    Application.Run(portGauges);
                }
            }
            catch(Exception e)
            {
                var result = MessageBox.Show("The following unhandled exception occured: " + e.ToString() + Environment.NewLine + "Press OK to restart the application or Cancel to exit." , "Error", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                    Application.Restart();
                else
                    Application.Exit();
            }
        }

        private static void CheckForNewDevicesTimer_Tick(object sender, EventArgs e)
        {
            InitializeConfiguration();
        }

        public static void InitializeConfiguration()
        {
            //Load existing configuration file or create a new one if one doesn't exist.
            var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            Configuration = new Configuration();
            Configuration = Configuration.Read(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\WhatTheHelm", "config.json");

            //Open NMEA 2000 gateway. If COM port is busy, wait and retry.
            if (CanGateway == null)
            {
                SerialPort serialPort = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.One);
                do
                {
                    if (CanGateway != null)
                        CanGateway.Dispose();
                    CanGateway = new Ngt1(serialPort, 55, Configuration.TxPgnFilter, Configuration.RxPgnFilter);
                }
                while (!CanGateway.Open());
            }

            //Subscribe to NMEA 2000 gateway messages
            CanGateway.MessageRecieved += CanGateway_MessageRecieved;

            //Issue request for product information from connected devices, and start the response timer
            ConnectedDeviceScanBusy = true;
            System.Windows.Forms.Timer productInformationResponseTimer = new System.Windows.Forms.Timer();
            productInformationResponseTimer.Interval = 1500;
            productInformationResponseTimer.Tick += ProductInformationResponseTimer_Tick;
            CanGateway.IsoRequest(126996);
            productInformationResponseTimer.Start();
        }

        private static void CanGateway_MessageRecieved(object sender, WhatTheHelmCanLib.Messages.CanMessageArgs e)
        {
            //Product information PGN 126996
            if (e.Message.Pgn == 126996)
            {
                var prodInfo = new Pgn0x1F014();
                prodInfo = (Pgn0x1F014)prodInfo.DeserializeFields(e.Message.Data);
                N2KDevice n2kDevice = new N2KDevice(e.Message.SourceAddress);
                n2kDevice.ProductInformation = prodInfo.ProductInformation;
                _n2kDevices.Add(n2kDevice);
            }
        }

        private static void ProductInformationResponseTimer_Tick(object sender, EventArgs e)
        {
            //Unsubscribe from CAN gateway messages
            CanGateway.MessageRecieved -= CanGateway_MessageRecieved;

            //Dispose of timer
            var timer = (System.Windows.Forms.Timer)sender;
            timer.Stop();
            timer.Tick -= ProductInformationResponseTimer_Tick;
            timer.Dispose();

            //Remove duplicate devices
            _n2kDevices = _n2kDevices.Distinct().ToList();

            //Create a running configuration from the stored configuration.  The running configuration includes only NMEA2000 data bindings for which there exists connected NMEA2000 devices.  The running configuration also updates the device addresses within the bindings which may have changed as a result of the CAN bus address claim process.
            RunningConfiguration = new Configuration();

            //Port propulsion running configuration
            RunningConfiguration.PortPropulsionN2KConfig = CreateRuntimePropulsionConfig(Configuration.PortPropulsionN2KConfig, _n2kDevices);
            //Stbd propulsion running configuration
            RunningConfiguration.StbdPropulsionN2KConfig = CreateRuntimePropulsionConfig(Configuration.StbdPropulsionN2KConfig, _n2kDevices);
            //Rudder and trim running configuration
            RunningConfiguration.RudderTrimN2KConfig = CreateRudderTrimConfig(Configuration.RudderTrimN2KConfig, _n2kDevices);
            //Common systems running configuration
            RunningConfiguration.CommonSystemsN2KConfig = CreateRuntimeCommonSystemsConfig(Configuration.CommonSystemsN2KConfig, _n2kDevices);
        }

        private static PropulsionNmea2000Configuration CreateRuntimePropulsionConfig(PropulsionNmea2000Configuration config, List<N2KDevice> n2kDevices)
        {
            PropulsionNmea2000Configuration updatedConfig = new PropulsionNmea2000Configuration();
            config.GetType().GetProperties().Where(prop => prop.PropertyType == typeof(N2KDataBinding)).ToList().ForEach(binding =>
            {
                N2KDataBinding n2kDataBinding = (N2KDataBinding)binding.GetValue(config);

                if (n2kDataBinding != null)
                {
                    foreach (var n2kDevice in n2kDevices)
                    {
                        if (n2kDevice.ProductInformation.Equals(n2kDataBinding.Nmea2000Device.ProductInformation))
                        {
                            n2kDataBinding.Nmea2000Device.Address = n2kDevice.Address;
                            updatedConfig.GetType().GetProperty(binding.Name).SetValue(updatedConfig, n2kDataBinding);
                        }
                    }
                }
            });
            return updatedConfig;
        }

        private static RudderTrimNmea2000Configuration CreateRudderTrimConfig(RudderTrimNmea2000Configuration config, List<N2KDevice> n2kDevices)
        {
            RudderTrimNmea2000Configuration updatedConfig = new RudderTrimNmea2000Configuration();
            config.GetType().GetProperties().Where(prop => prop.PropertyType == typeof(N2KDataBinding)).ToList().ForEach(binding =>
            {
                N2KDataBinding n2kDataBinding = (N2KDataBinding)binding.GetValue(config);

                if (n2kDataBinding != null)
                {
                    foreach (var n2kDevice in n2kDevices)
                    {
                        if (n2kDevice.ProductInformation.Equals(n2kDataBinding.Nmea2000Device.ProductInformation))
                        {
                            n2kDataBinding.Nmea2000Device.Address = n2kDevice.Address;
                            updatedConfig.GetType().GetProperty(binding.Name).SetValue(updatedConfig, n2kDataBinding);
                        }
                    }
                }
            });
            return updatedConfig;
        }

        private static List<N2KDataBinding> CreateRuntimeCommonSystemsConfig(List<N2KDataBinding> config, List<N2KDevice> n2kDevices)
        {
            List<N2KDataBinding> updatedConfig = new List<N2KDataBinding>(config.Count);
            n2kDevices.ForEach(n2kDevice =>
            {
                foreach(var n2kBinding in config)
                {
                    if(n2kDevice.ProductInformation.Equals(n2kBinding.Nmea2000Device.ProductInformation))
                    {
                        var index = config.IndexOf(n2kBinding);
                        n2kBinding.Nmea2000Device.Address = n2kDevice.Address;
                        updatedConfig.Insert(index, n2kBinding);
                    }
                }
            });
            return updatedConfig;
        }
    }
}
