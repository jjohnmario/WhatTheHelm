using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WhatTheHelmFormsLib
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Tachometer : UserControl
    {
        public Tachometer()
        {
            InitializeComponent();
        }
        public void SetRpm(int rpm)
        {
            //0 RPM =  -145
            //5000 RPM = 145
            //290 total degrees
            //0.058 deg/1 RPM
            //Less than 2500 deduct 50 rpm (-2.9 degrees)
            //Greater than 2500 add 50 rpm (+2.9 degrees)
            float needleVal = (float)(-145 + (rpm * 0.058));
            if (needleVal < 0)
                needleVal = (float)(needleVal - 2.9);
            if (needleVal > 0)
                needleVal = (float)(needleVal + 2.9);
            RotateTransform rotate = new RotateTransform(needleVal);
            Needle.RenderTransform = rotate;
            Val.Content = rpm;
        }
        public void SetEngineHours(int thousands, int hundreds, int tens, int ones, int tenths)
        {
            EngHoursThousands.Content = thousands;
            EngHoursHundreds.Content = hundreds;
            EngHoursTens.Content = tens;
            EngHoursOnes.Content = ones;
            EngHoursTenths.Content = tenths;
        }
    }
}
