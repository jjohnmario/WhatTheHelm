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
        /// Represents the frequency read in Hz from an input.
        /// </summary>
        public double InputHz { get; set; }
    }
       
    
    /// <summary>
    /// Represents a single instance of the Yocto-puce Yocto-PWM-RX USB PWM sensing module.
    /// </summary>
    public class YoctoPwmRx
    {
        /// <summary>
        /// Raised after a successful scan of input 1 of the module.
        /// </summary>
        public event EventHandler<YoctoPwmRxArgs> NewInput1Data;
        /// <summary>
        /// Raised after a successful scan of input 2 of the module.
        /// </summary>
        public event EventHandler<YoctoPwmRxArgs> NewInput2Data;
        private YModule _ConnectedPwmInputModule;
        private YPwmInput _FirstPwmInputFound;
        private YPwmInput _PwmInputModule_Input1;
        private YPwmInput _PwmInputModule_Input2;
        private bool _Scanning;
        private string _ErrMsg;

        public bool Connect(out string message)
        {
            _ConnectedPwmInputModule = null;
            _FirstPwmInputFound = null;
            _PwmInputModule_Input1 = null;
            _PwmInputModule_Input2 = null;

            // Setup the API to use local USB devices
            if (YAPI.RegisterHub("usb", ref _ErrMsg) != YAPI.SUCCESS)
            {
                message = "RegisterHub error: " + _ErrMsg;
                return false;
            }

            // Find any PWM input, which indicates a USB PWM device is connected.
            _FirstPwmInputFound = YPwmInput.FirstPwmInput();
            if (_FirstPwmInputFound == null)
            {
                message = "No USB tachometer input devices found.";
                return false;
            }
            // we need to retreive both channels from the device.
            else
            {
                _ConnectedPwmInputModule = _FirstPwmInputFound.get_module();
                while(!_ConnectedPwmInputModule.isOnline())
                    YAPI.Sleep(50, ref _ErrMsg);
                _PwmInputModule_Input1 = YPwmInput.FindPwmInput(_ConnectedPwmInputModule.get_serialNumber() + ".pwmInput1");
                _PwmInputModule_Input2 = YPwmInput.FindPwmInput(_ConnectedPwmInputModule.get_serialNumber() + ".pwmInput2");
                while (!_PwmInputModule_Input1.isOnline())
                    YAPI.Sleep(50, ref _ErrMsg);
                while (!_PwmInputModule_Input2.isOnline())
                    YAPI.Sleep(50, ref _ErrMsg);
                message = "USB tachometer input device ready.";
                return true;
            }
        }
        /// <summary>
        /// Scans each module input at the defined interval.
        /// </summary>
        /// <param name="interval">The scan interval expressed in milliseconds</param>
        public void StartScan(int interval)
        {
            _Scanning = true;
            Task.Run(() =>
            {
                while (_Scanning)
                {
                    if (_ConnectedPwmInputModule.isOnline())
                    {
                        //Input 1
                        if(_PwmInputModule_Input1.isOnline())                            
                            if(NewInput1Data != null)
                                NewInput1Data.Invoke(this, new YoctoPwmRxArgs() { InputHz = _PwmInputModule_Input1.get_frequency()});
                        //Input 2
                        if (_PwmInputModule_Input2.isOnline())
                            if (NewInput2Data != null)
                                NewInput2Data.Invoke(this, new YoctoPwmRxArgs() { InputHz = _PwmInputModule_Input2.get_frequency()});
                    }
                    YAPI.Sleep(interval, ref _ErrMsg);
                }
            });
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
