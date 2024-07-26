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
    public partial class GearPressGauge : UserControl
    {
        public bool LowWarningEnabled { get; set; }
        public bool HighWarningEnabled { get; set; }
        public int LowWarningThreshold { get; set; }
        public int HighWarningThreshold { get; set; }
        private Brush _defaultBezelFill;
        private int _pressure;
        

        public GearPressGauge()
        {
            InitializeComponent();

                _defaultBezelFill = Bezel.Fill;
                Timer t = new Timer(500);
                t.Elapsed += T_Elapsed;
                t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            if ((HighWarningEnabled & _pressure >= HighWarningThreshold) | (LowWarningEnabled & _pressure <= LowWarningThreshold))
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

        public void SetPressure(int pressure)
        {
            _pressure = pressure;
 
            if (pressure < 0)
                pressure = 0;
            if (pressure > 400)
                pressure = 400;
            int pressAboveMin = pressure - 0;
            //0 PSI =  -60
            //400 PSI = +60
            //120 total degrees
            //1.5 deg/1 PSI
            //Angle range -60 to +60
            float needleVal = (float)(-60 + (pressAboveMin * 0.3));
            RotateTransform rotate = new RotateTransform(needleVal);
            Needle.RenderTransform = rotate;
            Val.Content = pressure;
        }
    }
}
