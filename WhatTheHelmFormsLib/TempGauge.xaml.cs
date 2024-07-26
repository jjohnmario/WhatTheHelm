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
    public partial class TempGauge : UserControl
    {
        public bool LowWarningEnabled { get; set; }
        public bool HighWarningEnabled { get; set; }
        public int LowWarningThreshold { get; set; }
        public int HighWarningThreshold { get; set; }
        private Brush _defaultBezelFill;
        private int _temp;
        

        public TempGauge()
        {
            InitializeComponent();

                _defaultBezelFill = Bezel.Fill;
                Timer t = new Timer(500);
                t.Elapsed += T_Elapsed;
                t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (HighWarningEnabled & _temp >= HighWarningThreshold)
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

        public void SetTemp(int temp)
        {
            _temp = temp;
 
            if (temp < 140)
                temp = 140;
            if (temp > 220)
                temp = 220;
            int tempAboveMin = temp - 140;
            //140F =  -60
            //220F = +60
            //120 total degrees
            //1.5 deg/1F
            //Angle range -60 to +60
            float needleVal = (float)(-60 + (tempAboveMin * 1.5));
            RotateTransform rotate = new RotateTransform(needleVal);
            Needle.RenderTransform = rotate;
            Val.Content = temp;
        }
    }
}
