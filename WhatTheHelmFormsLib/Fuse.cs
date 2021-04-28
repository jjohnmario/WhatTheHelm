using CanLib.ParameterGroups.J1939.ProprietaryB.CooperBussman.Mvec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoatFormsLib
{
    public partial class Fuse : UserControl
    {
        [Browsable(true)]
        public byte MvecAddress { get; set; }
        [Browsable(true)]
        public byte MvecGrid { get; set; }
        [Browsable(true)]
        public byte MvecFuseNumber { get; set; }
        [Browsable(true)]
        public string Function { get; set; }
        public event EventHandler<EventArgs> Faulted;
        public event EventHandler<EventArgs> FaultCleared;
        private FuseStatus[] _FuseStatus;

        public Fuse()
        {
            InitializeComponent();
        }

        public void UpdateFuseStatus(byte mvecAddress, byte mvecGrid, FuseStatus[] fuseStatus)
        {

            if (MvecAddress == mvecAddress)
                if (MvecGrid == mvecGrid)
                {
                    _FuseStatus = fuseStatus;
                    if (MvecFuseNumber > 0)
                    {
                        //Fuse Fault
                        if (fuseStatus[MvecFuseNumber - 1] != FuseStatus.NoFault)
                        {
                            MethodInvoker inv = new MethodInvoker(() =>
                            {
                                this.BackColor = Color.Red;
                                this.ForeColor = Color.Yellow;
                                label1.Text = "FUSE "+MvecFuseNumber.ToString() + " FAULT";
                            });
                            this.Invoke(inv);
                            if (Faulted != null)
                                Faulted.Invoke(this, null);
                        }

                        //Fault Cleared
                        else if (fuseStatus[MvecFuseNumber - 1] == FuseStatus.NoFault)
                        {
                            MethodInvoker inv = new MethodInvoker(() =>
                            {
                                this.BackColor = Color.LimeGreen;
                                this.ForeColor = Color.Black;
                                label1.Text = "FUSE " + MvecFuseNumber.ToString() + " OK";
                                this.Show();
                            });
                            this.Invoke(inv);
                            if (FaultCleared != null)
                                FaultCleared.Invoke(this, null);
                        }
                    }
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string msg = @"FUNCTION: "+Function+
                "\r\nMVEC LOCATION: MVEC-" + (MvecAddress - 175) +
                "\r\nGRID NUMBER: " + MvecGrid +
                "\r\nFUSE NUMBER: " + MvecFuseNumber +
                "\r\nSTATUS: " + _FuseStatus[MvecFuseNumber - 1].ToString();
            MessageBox.Show(msg, "MVEC Fuse Status");
        }
    }
}
