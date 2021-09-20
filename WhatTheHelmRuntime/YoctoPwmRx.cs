using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhatTheHelmRuntime
{
    public class YoctoPwmRxArgs : EventArgs
    {
        /// <summary>
        /// Represents the frequency read in Hz from input 1
        /// </summary>
        public double Input1Hz { get; set; }
        /// <summary>
        /// Represents the frequency read in Hz from input 2
        /// </summary>
        public double Input2Hz { get; set; }
    }
       
    
    /// <summary>
    /// Represents a single instance of the Yocto-puce Yocto-PWM-RX USB PWM sensing module.
    /// </summary>
    public class YoctoPwmRx
    {
        /// <summary>
        /// Raised after a successful scan of the module and its inputs.
        /// </summary>
        public event EventHandler<YoctoPwmRxArgs> NewData;
        /// <summary>
        /// Represents the frequency read in Hz from input 1
        /// </summary>
        public double Input1Hz { get; private set; }
        /// <summary>
        /// Represents the frequency read in Hz from input 2
        /// </summary>
        public double Input2Hz { get; private set; }
        private YModule _Module;
        private YPwmInput _Pwm;
        private YPwmInput _Pwm1;
        private YPwmInput _Pwm2;
        private bool _Scanning;

        public bool Connect(out string message)
        {
            string errmsg = "";

            _Module = null;
            _Pwm = null;
            _Pwm1 = null;
            _Pwm2 = null;

            // Setup the API to use local USB devices
            if (YAPI.RegisterHub("usb", ref errmsg) != YAPI.SUCCESS)
            {
                message = "RegisterHub error: " + errmsg;
                return false;
            }

            // retreive any pwm input available
            _Pwm = YPwmInput.FirstPwmInput();
            if (_Pwm == null)
            {
                message = "No module found";
                return false;
            }
           // we need to retreive both channels from the device.
            if (_Pwm.isOnline())
            {
                _Module = _Pwm.get_module();
                _Pwm1 = YPwmInput.FindPwmInput(_Module.get_serialNumber() + ".pwmInput1");
                _Pwm2 = YPwmInput.FindPwmInput(_Module.get_serialNumber() + ".pwmInput2");
                message = "Success";
                return true;
            }
            else
            {
                message = "Module not online";
                return false;
            }
        }

        /// <summary>
        /// Scans each module input at the defined interval.
        /// </summary>
        /// <param name="interval">The scan interval expressed in milliseconds</param>
        public void StartScan(int interval)
        {
            _Scanning = true;
            while(_Module.isOnline() & _Scanning)
            {
                Input1Hz = _Pwm1.get_frequency();
                Input2Hz = _Pwm2.get_frequency();
                if (NewData != null)
                    NewData.Invoke(this, new YoctoPwmRxArgs() { Input1Hz = this.Input1Hz, Input2Hz = this.Input2Hz });
                Thread.Sleep(interval);
            }
            _Scanning = false;
        }

        /// <summary>
        /// Terminates the scanning of module inputs.
        /// </summary>
        public void StopScan()
        {
            _Scanning = false;
        }
    }
}
