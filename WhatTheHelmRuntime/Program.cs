using CanLib.Devices;
using CanLib.Devices.Nmea2000;
using CanLib.Devices.Nmea2000.GridConnect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatTheHelmRuntime;

namespace Dashboard
{
    static class Program
    {
        public static Can232Fd CanGateway { get; set; }
        public static CanGateWayListener CanGateWayListener { get; set; }
        public static CanRequestHandler CanRequestHandler { get; set; }
        public static YoctoPwmRx YoctoPwmRx { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                //Initialize CAN adapter
                //CanName name = new CanName(false, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
                //ProductInformation productInformation = new ProductInformation(22, 33, "MarioWare Display", "v1.0.0", "1.0.0", "01229330JJF", 1, 2);
                //SerialPort serialPort = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.One) { NewLine = ";" };
                //CanGateway = new Can232Fd(serialPort, 0, name, productInformation);
                //CanGateWayListener = new CanGateWayListener(CanGateway);
                //CanGateWayListener.Start();
                //CanRequestHandler = new CanRequestHandler(CanGateway);
                //CanRequestHandler.Start();

                //Initialize USB tachometer adapter (if not using NMEA tachometer inputs)
                YoctoPwmRx = new YoctoPwmRx();
                string msg;
                if (YoctoPwmRx.Connect(out msg))
                    Task.Run(() => YoctoPwmRx.StartScan(250));
                

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //Try to run the application across four screens.  Else run off one screen.
                try
                {
                    //Get list of all screens.
                    Screen[] screens = Screen.AllScreens;

                    //Get list of 1280x800 screens.
                    var screens1280x800 = Screen.AllScreens.Where(size => size.Bounds.Height == 800 & size.Bounds.Width == 1280).ToList();
                    //Get list of 800x480 screens.
                    var screens800x480 = Screen.AllScreens.Where(size => size.Bounds.Height == 480 & size.Bounds.Width == 800).ToList();

                    //Get the primary 1280x800 screen and assign it as a "Gauges" screen.
                    Screen gaugesScreen = screens1280x800.Where(y => y.Primary).OrderBy(x => x.DeviceName).First();
                    screens1280x800.Remove(gaugesScreen);
                    //Get next number 1280x800 screen and assign it as an OpenCpn screen.
                    Screen openCpnScreen = screens1280x800.OrderBy(x => x.DeviceName).First();

                    //Get lowest number 640x480 screen and assign it as a "TrimControl" screen.
                    Screen trimControlScreen = screens800x480.OrderBy(x => x.DeviceName).First();
                    screens800x480.Remove(trimControlScreen);
                    //Get next number 640x480 screen and assign it as a "SwitchPanel" screen.
                    Screen switchPanelScreen = screens800x480.OrderBy(x => x.DeviceName).First();

                    //Bind all but Gauges types to physical screens
                    List<KeyValuePair<Screen, Type>> screenAssignmentList = new List<KeyValuePair<Screen, Type>>();
                    screenAssignmentList.Add(new KeyValuePair<Screen, Type>(openCpnScreen, typeof(Process)));
                    screenAssignmentList.Add(new KeyValuePair<Screen, Type>(switchPanelScreen, typeof(SwitchPanel)));
                    screenAssignmentList.Add(new KeyValuePair<Screen, Type>(trimControlScreen, typeof(TrimControl)));

                    //Bind Gauges form to physical screen
                    //Pass screen/type list as constructor for guages screen.  This allows other screens to be spawned from the Gauges screen and on the UI thread.
                    Gauges gauges = new Gauges(screenAssignmentList);
                    gauges.Bounds = gaugesScreen.Bounds;
                    gauges.StartPosition = FormStartPosition.Manual;
                    Application.Run(gauges);
                }
                catch
                {
                    Gauges gauges = new Gauges();
                    Application.Run(gauges);
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
