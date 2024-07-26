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
    public partial class VoltGauge : UserControl
    {
        public bool LowWarningEnabled { get; set; }
        public bool HighWarningEnabled { get; set; }
        public double LowWarningThreshold { get; set; }
        public double HighWarningThreshold { get; set; }
        private Brush _defaultBezelFill;
        private double _volts;
        

        public VoltGauge()
        {
            InitializeComponent();

                _defaultBezelFill = Bezel.Fill;
                Timer t = new Timer(500);
                t.Elapsed += T_Elapsed;
                t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            if ((HighWarningEnabled & _volts >= HighWarningThreshold) | (LowWarningEnabled & _volts <= LowWarningThreshold))
            {
                this.Dispatcher.Invoke(() => {

                    if (Bezel.Fill == _defaultBezelFill)
                        Bezel.Fill = Brushes.Yellow;
                    else
                        Bezel.Fill = _defaultBezelFill;
                });
            }
            else
                this.Dispatcher.Invoke(() =>
                {
                    Bezel.Fill = _defaultBezelFill;
                });
        }

        public void SetVolts(double volts)
        {
            _volts = volts;
 
            if (volts < 0)
                volts = 0;
            if (volts > 16)
                volts = 16;
            double voltsAboveMin = volts - 8;
            //8V =  -60
            //16V = +60
            //120 total degrees
            //1.5 deg/1 V
            //Angle range -60 to +60
            float needleVal = (float)(-60 + (voltsAboveMin * 15));
            RotateTransform rotate = new RotateTransform(needleVal);
            Needle.RenderTransform = rotate;
            Val.Content = volts.ToString("##.0");
        }
    }
}
