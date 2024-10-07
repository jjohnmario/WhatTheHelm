using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.ComponentModel.Design;
using System.Drawing.Design;
using WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec;
using WhatTheHelmCanLib.ParameterGroups.J1939.ProprietaryB.CooperBussman.Mvec;
using System.Collections;

namespace BoatFormsLib.CustomUserControls
{
    public enum ButtonBehavior { Toggle, Momentary }

    public partial class DashboardButton : Button
    {
        private Image _OffStateBackImage;
        private string _OffStateText;

        //Prevents the white border from appearing after control loses focus and a control on another screen gains focus.
        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }

        /// <summary>
        /// Mvec address of the relay to which the button is bound.
        /// </summary>
        [Browsable(true)]
        public byte MvecAddress { get; set; }
        /// <summary>
        /// Mvec grid where the relay is located.
        /// </summary>
        [Browsable(true)]
        public byte MvecGrid { get; set; }
        /// <summary>
        /// The relay number.
        /// </summary>
        [Browsable(true)]
        public byte MvecRelayNumber { get; set; }
        /// <summary>
        /// The fuse number associated with the relay number.
        /// </summary>
        [Browsable(true)]
        public byte MvecFuseNumber { get; set; }
        /// <summary>
        /// Description of the button function.
        /// </summary>
        [Browsable(true)]
        public string Function { get; set; }
        /// <summary>
        /// Behavior of the button's action.
        /// </summary>
        [Browsable(true)]
        public ButtonBehavior ButtonBehavior { get; set; }
        /// <summary>
        /// Text color when the relay state = on.
        /// </summary>
        [Browsable(true)]
        public Color OnStateForeColor { get; set; }
        /// <summary>
        /// Text color when the relay state = off.
        /// </summary>
        [Browsable(true)]
        public Color OffStateForeColor { get; set; }
        /// <summary>
        /// Background image displayed when the relay state = on.
        /// </summary>
        [Browsable(true)]
        public Image OnStateBackImage { get; set; }
        /// <summary>
        /// Background image displayed when the relay state = off.
        /// </summary>
        [Browsable(true),Description("Background image displayed when the relay state = off.")]
        public Image OffStateBackImage
        { 
            get
            {
                return _OffStateBackImage;
            }
            set
            {
                _OffStateBackImage = value;
                this.BackgroundImage = _OffStateBackImage;

            }
        }
        /// <summary>
        /// Text displayed when the relay state = on.
        /// </summary>
        [Browsable(true), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string OnStateText { get; set; }
        /// <summary>
        /// Text displayed when the relay state = off.
        /// </summary>
        [Browsable(true), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string OffStateText
        {
            get
            {
                return _OffStateText;
            }
            set
            {
                _OffStateText = value;
                this.Text = _OffStateText;
            }
        }
        /// <summary>
        /// Current state of the relay.
        /// </summary>
        [Browsable(true)]
        public bool State { get; set; }
        protected override bool ShowFocusCues => false;
        private bool FuseFaulted;
        private bool RelayFaulted;
        private Font FirstFont;

        /// <summary>
        /// A new state command has been dispatched from the button.
        /// </summary>
        public event EventHandler<DashboardButtonArgs> NewCommand;

        public DashboardButton()
        {
            this.Paint += DashboardButton_Paint;
            InitializeComponent();
            FirstFont = new Font("Arial", 18);
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.BackgroundImage = OffStateBackImage;
            this.MouseDown += DashboardButton_MouseDown;
            this.MouseUp += DashboardButton_MouseUp;
        }

        private void DashboardButton_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode)
            {
                this.Text = OffStateText;
                this.ForeColor = OffStateForeColor;
                this.BackgroundImage = OffStateBackImage;
            }
        }

        /// <summary>
        /// Updates the state associated with the relay that button controls.
        /// </summary>
        /// <param name="mvecAddress">Mvec address of the relay to which the button is bound.</param>
        /// <param name="mvecGrid">Mvec grid where the relay is located.</param>
        /// <param name="relayState">An array of all relay states within the defined grid and address.</param>
        public void UpdateState(byte mvecAddress, byte mvecGrid, BitArray relayState)
        {
            if (MvecAddress == mvecAddress)
                if (MvecGrid == mvecGrid)
                {
                    if (relayState[MvecRelayNumber - 1] == false)
                    {
                        MethodInvoker inv = new MethodInvoker(() =>
                        {
                            this.BackgroundImage = OffStateBackImage;
                            this.ForeColor = OffStateForeColor;
                            this.Text = OffStateText;
                            State = false;
                        });
                        if(IsHandleCreated)
                            Invoke(inv);
                    }
                    else if (relayState[MvecRelayNumber - 1] == true)
                    {
                        MethodInvoker inv = new MethodInvoker(() =>
                        {
                            this.BackgroundImage = OnStateBackImage;
                            this.ForeColor = OnStateForeColor;
                            this.Text = OnStateText;
                            State = true;
                        });
                        if(IsHandleCreated)
                            Invoke(inv);
                    }
                }
        }

        /// <summary>
        /// Updates the fuse fault status associated with the relay that button controls.
        /// </summary>
        /// <param name="mvecAddress">Mvec address of the fuse of the associated relay to which the button is bound.</param>
        /// <param name="mvecGrid">Mvec grid where the fuse is located.</param>
        /// <param name="fuseStatus">An array of all fuse fault statuses within the defined grid and address.</param>
        public void UpdateFuseStatus(byte mvecAddress, byte mvecGrid, FuseStatus[] fuseStatus)
        {
            if (MvecAddress == mvecAddress)
                if (MvecGrid == mvecGrid)
                {
                    if(MvecFuseNumber > 0)
                    {
                        //Fuse Fault
                        if (fuseStatus[MvecFuseNumber - 1] != FuseStatus.NoFault)
                        {
                            FuseFaulted = true;
                            MethodInvoker inv = new MethodInvoker(() =>
                            {
                                this.BackgroundImage = null;
                                this.ForeColor = Color.Yellow;
                                this.Font = new Font("Arial", 12);
                                this.Text = Function + " (FUSE:" + MvecFuseNumber + ", MVEC-"+(MvecAddress-175)+") FAULT: " + fuseStatus[MvecFuseNumber - 1].ToString();
                                if (this.Visible)
                                    this.Hide();
                                else
                                    this.Show();
                            });
                            if(IsHandleCreated)
                                this.Invoke(inv);                           
                        }

                        //Fault Cleared
                        else if (fuseStatus[MvecFuseNumber - 1] == FuseStatus.NoFault)
                        {
                            FuseFaulted = false;
                            if(!RelayFaulted)
                            {
                                if (State == true)
                                {
                                    MethodInvoker inv = new MethodInvoker(() =>
                                    {
                                        this.BackgroundImage = OnStateBackImage;
                                        this.ForeColor = OnStateForeColor;
                                        this.Text = OnStateText;
                                        this.Font = FirstFont;
                                        this.Show();
                                    });
                                    if(IsHandleCreated)
                                        this.Invoke(inv);

                                }
                                else if (State == false)
                                {
                                    MethodInvoker inv = new MethodInvoker(() =>
                                    {
                                        this.BackgroundImage = OffStateBackImage;
                                        this.ForeColor = OffStateForeColor;
                                        this.Text = OffStateText;
                                        this.Font = FirstFont;
                                        this.Show();
                                    });
                                    if(IsHandleCreated)
                                        this.Invoke(inv);
                                }
                            }
                        }
                    }
                }
        }

        /// <summary>
        /// Updates the relay fault status associated with the relay that button controls.
        /// </summary>
        /// <param name="mvecAddress">Mvec address of the associated relay to which the button is bound.</param>
        /// <param name="mvecGrid">Mvec grid where the relay is located.</param>
        /// <param name="relayStatus">An array of all relay fault statuses within the defined grid and address.</param>
        public void UpdateRelayStatus(byte mvecAddress, byte mvecGrid, RelayStatus[] relayStatus)
        {
            if (MvecAddress == mvecAddress)
                if (MvecGrid == mvecGrid)
                {
                    if(MvecRelayNumber > 0)
                    {
                        //Relay Fault
                        if (relayStatus[MvecRelayNumber - 1] != RelayStatus.Okay && !FuseFaulted)
                        {
                            RelayFaulted = true;
                            MethodInvoker inv = new MethodInvoker(() =>
                            {
                                this.BackgroundImage = null;
                                this.ForeColor = Color.Yellow;
                                this.Font = new Font("Arial", 12);
                                this.Text = Function + " (RELAY: " + MvecRelayNumber + ", MVEC-"+(MvecAddress-175)+") FAULT: " + relayStatus[MvecRelayNumber - 1].ToString();
                                if (this.Visible)
                                    this.Hide();
                                else
                                    this.Show();
                            });
                            if(IsHandleCreated)
                                this.Invoke(inv);  
                        }

                        //Fault Cleared
                        else if (relayStatus[MvecRelayNumber - 1] == RelayStatus.Okay)
                        {
                            RelayFaulted = false;
                            if (!FuseFaulted)
                            {
                                if (State == true)
                                {
                                    MethodInvoker inv = new MethodInvoker(() =>
                                    {
                                        this.BackgroundImage = OnStateBackImage;
                                        this.ForeColor = OnStateForeColor;
                                        this.Text = OnStateText;
                                        this.Font = FirstFont;
                                        this.Show();
                                    });
                                    if(IsHandleCreated)
                                        this.Invoke(inv);

                                }
                                else if (State == false)
                                {
                                    MethodInvoker inv = new MethodInvoker(() =>
                                    {
                                        this.BackgroundImage = OffStateBackImage;
                                        this.ForeColor = OffStateForeColor;
                                        this.Text = OffStateText;
                                        this.Font = FirstFont;
                                        this.Show();
                                    });
                                    if(IsHandleCreated)
                                        this.Invoke(inv);
                                }
                            }
                        }
                    }
                }
        }

        /// <summary>
        /// Forces invocation of the MouseUp event handler
        /// </summary>
        public void ForceMouseUpEvent()
        {
            DashboardButton_MouseUp(null, null);
        }

        /// <summary>
        /// Forces invoction of the MouseDown event handler
        /// </summary>
        public void ForceMouseDownEvent()
        {
            DashboardButton_MouseDown(null, null);
        }

        private void DashboardButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseLeave(new EventArgs());
            if (ButtonBehavior == ButtonBehavior.Momentary)
            {
                //this.BackColor = OffStateBackColor;
                this.BackgroundImage = OffStateBackImage;
                this.ForeColor = OffStateForeColor;
                this.Text = OffStateText;
                State = false;
                if (NewCommand != null)
                    NewCommand.Invoke(this, new DashboardButtonArgs { MvecAddress = MvecAddress, MvecGrid = MvecGrid,MvecRelayNumber = MvecRelayNumber,RelayCommandState = RelayCommandState.TurnRelayOff });
            }
                
            else if (ButtonBehavior == ButtonBehavior.Toggle)
            {
                if(State == false)
                {
                    this.BackgroundImage = OnStateBackImage;
                    this.ForeColor = OnStateForeColor;
                    this.Text = OnStateText;
                    State = true;
                    if (NewCommand != null)
                        NewCommand.Invoke(this, new DashboardButtonArgs { MvecAddress = MvecAddress, MvecGrid = MvecGrid, MvecRelayNumber = MvecRelayNumber, RelayCommandState = RelayCommandState.TurnRelayOn });
                }
                else if (State == true)
                {
                    this.BackgroundImage = OffStateBackImage;
                    this.ForeColor = OffStateForeColor;
                    this.Text = OffStateText;
                    State = false;
                    if (NewCommand != null)
                        NewCommand.Invoke(this, new DashboardButtonArgs { MvecAddress = MvecAddress, MvecGrid = MvecGrid, MvecRelayNumber = MvecRelayNumber, RelayCommandState = RelayCommandState.TurnRelayOff });
                }
            }
        }

        private void DashboardButton_MouseDown(object sender, MouseEventArgs e)
        {
            if(ButtonBehavior == ButtonBehavior.Momentary)
            {
                this.BackgroundImage = OnStateBackImage;
                this.ForeColor = OnStateForeColor;
                this.Text = OnStateText;
                State = true;
                if (NewCommand != null)
                    NewCommand.Invoke(this, new DashboardButtonArgs { MvecAddress = MvecAddress, MvecGrid = MvecGrid, MvecRelayNumber = MvecRelayNumber, RelayCommandState = RelayCommandState.TurnRelayOn });
            }
        }
    }
}
