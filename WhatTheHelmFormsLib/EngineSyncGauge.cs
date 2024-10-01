using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WhatTheHelmFormsLib
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class EngineSyncGauge : UserControl
    {
        private int _position;
        

        public EngineSyncGauge()
        {
            InitializeComponent();
        }

        public void SetRpmDelta(int portRpm, int stbdRpm)
        {
            //Engine speed synchronization
            var rpmDelta = portRpm - stbdRpm;
            _position = portRpm;
            //+ delta = stbd slow, - delta = port slow
            if (rpmDelta < -1000)
                rpmDelta = -1000;
            if (rpmDelta > 1000)
                rpmDelta = 1000;
            //int positionAboveMin = position - 0;
            //-1000 RPM = -60
            //1000 = +60
            //120 total degrees
            //0.06 deg/1 RPM
            float needleVal = (float)(rpmDelta * 0.06);
            RotateTransform rotate = new RotateTransform(needleVal);
            Needle.RenderTransform = rotate;
        }
    }
}
