using WhatTheHelmCanLib.Devices;
using WhatTheHelmCanLib.Devices.Nmea2000;
using WhatTheHelmCanLib.Devices.Nmea2000.GridConnect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WhatTheHelmFormsLib;
using WhatTheHelmRuntime;
using WhatTheHelmRuntime.NMEA0183;
using XMLhelper;
using WhatTheHelmCanLib.Devices.NMEA2000.Actisense;
using System.Security.AccessControl;

namespace WhatTheHelmRuntime
{
    static class Program
    {
        //public static Can232Fd CanGateway { get; set; }
        public static Ngt1 CanGateway { get; set; }
        //public static CanGateWayListener CanGateWayListener { get; set; }
        public static CanRequestHandler CanRequestHandler { get; set; }
        public static YoctoPwmRx YoctoPwmRx { get; set; }
        public static Configuration Configuration { get; set; }

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
                //Load configuration file
                var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                Configuration = new Configuration();
                Configuration = Configuration.Read(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\WhatTheHelm", "config.json");
                Configuration.Save(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\WhatTheHelm", "config.json");

                //Open NMEA 2000 gateway. If COM port is busy, wait and retry.
                SerialPort serialPort = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
                do
                {
                    if (CanGateway != null)
                        CanGateway.Dispose();
                    CanGateway = new Ngt1(serialPort, 55, Configuration.TxPgnFilter, Configuration.RxPgnFilter);
                }
                while (!CanGateway.Open());

                //Try to run the application across five screens.  Else run off one screen.
                try
                {
                    //Get list of all screens.
                    Screen[] screens = Screen.AllScreens;
                    var screens1 = screens.OrderBy(x => x.Bounds.X);

                    //Get list of 1280x800 screens.
                    var screens1280x800 = Screen.AllScreens.Where(size => size.Bounds.Height == 800 & size.Bounds.Width == 1280).ToList();

                    //Get the primary 1280x800 screen and assign it as a "PortGauges" screen.
                    Screen portGaugesScreen = screens1280x800.Where(y => y.Primary).OrderBy(x => x.DeviceName).First();
                    screens1280x800.Remove(portGaugesScreen);
                    //Get next number 1280x800 screen and assign it as a "StbdGauges" screen.
                    Screen stbdGaugesScreen = screens1280x800.OrderBy(x => x.DeviceName).First();

                    //Get list of 800x480 screens.
                    var screens800x480 = Screen.AllScreens.Where(size => size.Bounds.Height == 480 & size.Bounds.Width == 800).ToList();

                    //Get next number 640x480 screen and assign it as a "SwitchPanel" screen.
                    Screen switchPanelScreen = screens800x480.OrderBy(x => x.Bounds.X).First();
                    screens800x480.Remove(switchPanelScreen);

                    //Get next number 640x480 screen and assign it as a "GPS" screen.
                    Screen rudderScreen = screens800x480.OrderBy(x => x.Bounds.X).First();
                    screens800x480.Remove(rudderScreen);

                    //Get lowest number 640x480 screen and assign it as a "TrimControl" screen.
                    Screen trimControlScreen = screens800x480.OrderBy(x => x.Bounds.X).First();

                    //Bind all but Gauges types to physical screens
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
                    //PortGauges portGauges = new PortGauges();
                    //Application.Run(portGauges);
                    PropulsionNmea2000Config nmea2000Config = new Nmea2000Config();
                    Application.Run(nmea2000Config);
                    //SwitchPanel switchPanel = new SwitchPanel();
                    //Application.Run(switchPanel);

                    //Rudder rudder = new Rudder();
                    //Application.Run(rudder);

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
    }
}
