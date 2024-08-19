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
    public partial class RudderPosGauge : UserControl
    {
        private int _position;
        

        public RudderPosGauge()
        {
            InitializeComponent();
        }

        public void SetPosition(int position)
        {
            _position = position;
 
            if (position < -45)
                position = -45;
            if (position > 45)
                position = 45;
            //int positionAboveMin = position - 0;
            //-45 degrees = -60
            //45 degrees = +60
            //120 total degrees
            //1.33333333 deg/1 degree
            //Angle range -60 to +60
            //float needleVal = (float)(-60 + (positionAboveMin * 1.5));
            float needleVal = (float)(position * 1.33333333);

            RotateTransform rotate = new RotateTransform(needleVal);
            Needle.RenderTransform = rotate;
            Val.Content = position;
        }
    }
}
