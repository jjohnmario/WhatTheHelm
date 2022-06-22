namespace WhatTheHelmRuntime
{
    partial class SwitchPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwitchPanel));
            this.button1 = new System.Windows.Forms.Button();
            this.dashboardButton5 = new BoatFormsLib.CustomUserControls.DashboardButton();
            this.dashboardButton8 = new BoatFormsLib.CustomUserControls.DashboardButton();
            this.dashboardButton11 = new BoatFormsLib.CustomUserControls.DashboardButton();
            this.dashboardButton12 = new BoatFormsLib.CustomUserControls.DashboardButton();
            this.dashboardButton9 = new BoatFormsLib.CustomUserControls.DashboardButton();
            this.dashboardButton6 = new BoatFormsLib.CustomUserControls.DashboardButton();
            this.dashboardButton7 = new BoatFormsLib.CustomUserControls.DashboardButton();
            this.dashboardButton3 = new BoatFormsLib.CustomUserControls.DashboardButton();
            this.dashboardButton2 = new BoatFormsLib.CustomUserControls.DashboardButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.BlackButtonGear1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.button1.Location = new System.Drawing.Point(647, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 76);
            this.button1.TabIndex = 115;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dashboardButton5
            // 
            this.dashboardButton5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton5.BackgroundImage")));
            this.dashboardButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardButton5.ButtonBehavior = BoatFormsLib.CustomUserControls.ButtonBehavior.Toggle;
            this.dashboardButton5.FlatAppearance.BorderSize = 0;
            this.dashboardButton5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton5.ForeColor = System.Drawing.Color.White;
            this.dashboardButton5.Function = "SEARCH LIGHT";
            this.dashboardButton5.Location = new System.Drawing.Point(12, 357);
            this.dashboardButton5.MvecAddress = ((byte)(176));
            this.dashboardButton5.MvecFuseNumber = ((byte)(3));
            this.dashboardButton5.MvecGrid = ((byte)(0));
            this.dashboardButton5.MvecRelayNumber = ((byte)(7));
            this.dashboardButton5.Name = "dashboardButton5";
            this.dashboardButton5.OffStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton5.OffStateBackImage")));
            this.dashboardButton5.OffStateForeColor = System.Drawing.Color.White;
            this.dashboardButton5.OffStateText = "SEARCH\r\nLIGHT\r\nOFF";
            this.dashboardButton5.OnStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton5.OnStateBackImage")));
            this.dashboardButton5.OnStateForeColor = System.Drawing.Color.White;
            this.dashboardButton5.OnStateText = "SEARCH\r\nLIGHT\r\nON\r\n";
            this.dashboardButton5.Size = new System.Drawing.Size(250, 105);
            this.dashboardButton5.State = false;
            this.dashboardButton5.TabIndex = 114;
            this.dashboardButton5.Text = "SEARCH\r\nLIGHT\r\nOFF";
            this.dashboardButton5.UseVisualStyleBackColor = true;
            this.dashboardButton5.NewCommand += new System.EventHandler<BoatFormsLib.DashboardButtonArgs>(this.NewCommand);
            // 
            // dashboardButton8
            // 
            this.dashboardButton8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton8.BackgroundImage")));
            this.dashboardButton8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardButton8.ButtonBehavior = BoatFormsLib.CustomUserControls.ButtonBehavior.Toggle;
            this.dashboardButton8.FlatAppearance.BorderSize = 0;
            this.dashboardButton8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton8.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton8.ForeColor = System.Drawing.Color.White;
            this.dashboardButton8.Function = "PORT WIPER";
            this.dashboardButton8.Location = new System.Drawing.Point(275, 129);
            this.dashboardButton8.MvecAddress = ((byte)(176));
            this.dashboardButton8.MvecFuseNumber = ((byte)(1));
            this.dashboardButton8.MvecGrid = ((byte)(0));
            this.dashboardButton8.MvecRelayNumber = ((byte)(1));
            this.dashboardButton8.Name = "dashboardButton8";
            this.dashboardButton8.OffStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton8.OffStateBackImage")));
            this.dashboardButton8.OffStateForeColor = System.Drawing.Color.White;
            this.dashboardButton8.OffStateText = "STBD\r\nWIPER\r\nOFF";
            this.dashboardButton8.OnStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton8.OnStateBackImage")));
            this.dashboardButton8.OnStateForeColor = System.Drawing.Color.White;
            this.dashboardButton8.OnStateText = "STBD\r\nWIPER\r\nON\r\n";
            this.dashboardButton8.Size = new System.Drawing.Size(250, 105);
            this.dashboardButton8.State = false;
            this.dashboardButton8.TabIndex = 113;
            this.dashboardButton8.Text = "STBD\r\nWIPER\r\nOFF";
            this.dashboardButton8.UseVisualStyleBackColor = true;
            this.dashboardButton8.NewCommand += new System.EventHandler<BoatFormsLib.DashboardButtonArgs>(this.NewCommand);
            // 
            // dashboardButton11
            // 
            this.dashboardButton11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton11.BackgroundImage")));
            this.dashboardButton11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardButton11.ButtonBehavior = BoatFormsLib.CustomUserControls.ButtonBehavior.Toggle;
            this.dashboardButton11.FlatAppearance.BorderSize = 0;
            this.dashboardButton11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton11.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton11.ForeColor = System.Drawing.Color.White;
            this.dashboardButton11.Function = "NAVIGATION LIGHTS";
            this.dashboardButton11.Location = new System.Drawing.Point(12, 246);
            this.dashboardButton11.MvecAddress = ((byte)(177));
            this.dashboardButton11.MvecFuseNumber = ((byte)(7));
            this.dashboardButton11.MvecGrid = ((byte)(0));
            this.dashboardButton11.MvecRelayNumber = ((byte)(3));
            this.dashboardButton11.Name = "dashboardButton11";
            this.dashboardButton11.OffStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton11.OffStateBackImage")));
            this.dashboardButton11.OffStateForeColor = System.Drawing.Color.White;
            this.dashboardButton11.OffStateText = "NAVIGATION\r\nLIGHTS\r\nOFF";
            this.dashboardButton11.OnStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton11.OnStateBackImage")));
            this.dashboardButton11.OnStateForeColor = System.Drawing.Color.White;
            this.dashboardButton11.OnStateText = "NAVIGATION\r\nLIGHTS\r\nON\r\n";
            this.dashboardButton11.Size = new System.Drawing.Size(250, 105);
            this.dashboardButton11.State = false;
            this.dashboardButton11.TabIndex = 109;
            this.dashboardButton11.Text = "NAVIGATION\r\nLIGHTS\r\nOFF";
            this.dashboardButton11.UseVisualStyleBackColor = true;
            this.dashboardButton11.NewCommand += new System.EventHandler<BoatFormsLib.DashboardButtonArgs>(this.NewCommand);
            // 
            // dashboardButton12
            // 
            this.dashboardButton12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton12.BackgroundImage")));
            this.dashboardButton12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardButton12.ButtonBehavior = BoatFormsLib.CustomUserControls.ButtonBehavior.Toggle;
            this.dashboardButton12.FlatAppearance.BorderSize = 0;
            this.dashboardButton12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton12.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton12.ForeColor = System.Drawing.Color.White;
            this.dashboardButton12.Function = "PORT WIPER";
            this.dashboardButton12.Location = new System.Drawing.Point(275, 12);
            this.dashboardButton12.MvecAddress = ((byte)(176));
            this.dashboardButton12.MvecFuseNumber = ((byte)(2));
            this.dashboardButton12.MvecGrid = ((byte)(0));
            this.dashboardButton12.MvecRelayNumber = ((byte)(4));
            this.dashboardButton12.Name = "dashboardButton12";
            this.dashboardButton12.OffStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton12.OffStateBackImage")));
            this.dashboardButton12.OffStateForeColor = System.Drawing.Color.White;
            this.dashboardButton12.OffStateText = "PORT\r\nWIPER\r\nOFF";
            this.dashboardButton12.OnStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton12.OnStateBackImage")));
            this.dashboardButton12.OnStateForeColor = System.Drawing.Color.White;
            this.dashboardButton12.OnStateText = "PORT\r\nWIPER\r\nON\r\n";
            this.dashboardButton12.Size = new System.Drawing.Size(250, 105);
            this.dashboardButton12.State = false;
            this.dashboardButton12.TabIndex = 108;
            this.dashboardButton12.Text = "PORT\r\nWIPER\r\nOFF";
            this.dashboardButton12.UseVisualStyleBackColor = true;
            this.dashboardButton12.NewCommand += new System.EventHandler<BoatFormsLib.DashboardButtonArgs>(this.NewCommand);
            // 
            // dashboardButton9
            // 
            this.dashboardButton9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton9.BackgroundImage")));
            this.dashboardButton9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardButton9.ButtonBehavior = BoatFormsLib.CustomUserControls.ButtonBehavior.Momentary;
            this.dashboardButton9.FlatAppearance.BorderSize = 0;
            this.dashboardButton9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton9.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton9.ForeColor = System.Drawing.Color.White;
            this.dashboardButton9.Function = "WINDSHIELD WASHERS";
            this.dashboardButton9.Location = new System.Drawing.Point(275, 246);
            this.dashboardButton9.MvecAddress = ((byte)(176));
            this.dashboardButton9.MvecFuseNumber = ((byte)(7));
            this.dashboardButton9.MvecGrid = ((byte)(0));
            this.dashboardButton9.MvecRelayNumber = ((byte)(3));
            this.dashboardButton9.Name = "dashboardButton9";
            this.dashboardButton9.OffStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton9.OffStateBackImage")));
            this.dashboardButton9.OffStateForeColor = System.Drawing.Color.White;
            this.dashboardButton9.OffStateText = "WINDSHIELD\r\nWASHERS";
            this.dashboardButton9.OnStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton9.OnStateBackImage")));
            this.dashboardButton9.OnStateForeColor = System.Drawing.Color.White;
            this.dashboardButton9.OnStateText = "WINDSHIELD\r\nWASHERS\r\n";
            this.dashboardButton9.Size = new System.Drawing.Size(250, 105);
            this.dashboardButton9.State = false;
            this.dashboardButton9.TabIndex = 105;
            this.dashboardButton9.Text = "WINDSHIELD\r\nWASHERS";
            this.dashboardButton9.UseVisualStyleBackColor = true;
            this.dashboardButton9.NewCommand += new System.EventHandler<BoatFormsLib.DashboardButtonArgs>(this.NewCommand);
            // 
            // dashboardButton6
            // 
            this.dashboardButton6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton6.BackgroundImage")));
            this.dashboardButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardButton6.ButtonBehavior = BoatFormsLib.CustomUserControls.ButtonBehavior.Momentary;
            this.dashboardButton6.FlatAppearance.BorderSize = 0;
            this.dashboardButton6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton6.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton6.ForeColor = System.Drawing.Color.White;
            this.dashboardButton6.Function = "WINDLASS OUT";
            this.dashboardButton6.Location = new System.Drawing.Point(538, 129);
            this.dashboardButton6.MvecAddress = ((byte)(176));
            this.dashboardButton6.MvecFuseNumber = ((byte)(6));
            this.dashboardButton6.MvecGrid = ((byte)(0));
            this.dashboardButton6.MvecRelayNumber = ((byte)(6));
            this.dashboardButton6.Name = "dashboardButton6";
            this.dashboardButton6.OffStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton6.OffStateBackImage")));
            this.dashboardButton6.OffStateForeColor = System.Drawing.Color.White;
            this.dashboardButton6.OffStateText = "WINDLASS\r\nOUT";
            this.dashboardButton6.OnStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton6.OnStateBackImage")));
            this.dashboardButton6.OnStateForeColor = System.Drawing.Color.White;
            this.dashboardButton6.OnStateText = "WINDLASS\r\nOUT";
            this.dashboardButton6.Size = new System.Drawing.Size(250, 105);
            this.dashboardButton6.State = false;
            this.dashboardButton6.TabIndex = 104;
            this.dashboardButton6.Text = "WINDLASS\r\nOUT";
            this.dashboardButton6.UseVisualStyleBackColor = true;
            this.dashboardButton6.NewCommand += new System.EventHandler<BoatFormsLib.DashboardButtonArgs>(this.NewCommand);
            // 
            // dashboardButton7
            // 
            this.dashboardButton7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton7.BackgroundImage")));
            this.dashboardButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardButton7.ButtonBehavior = BoatFormsLib.CustomUserControls.ButtonBehavior.Momentary;
            this.dashboardButton7.FlatAppearance.BorderSize = 0;
            this.dashboardButton7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton7.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton7.ForeColor = System.Drawing.Color.White;
            this.dashboardButton7.Function = "WINDLASS IN";
            this.dashboardButton7.Location = new System.Drawing.Point(538, 12);
            this.dashboardButton7.MvecAddress = ((byte)(176));
            this.dashboardButton7.MvecFuseNumber = ((byte)(5));
            this.dashboardButton7.MvecGrid = ((byte)(0));
            this.dashboardButton7.MvecRelayNumber = ((byte)(8));
            this.dashboardButton7.Name = "dashboardButton7";
            this.dashboardButton7.OffStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton7.OffStateBackImage")));
            this.dashboardButton7.OffStateForeColor = System.Drawing.Color.White;
            this.dashboardButton7.OffStateText = "WINDLASS\r\nIN";
            this.dashboardButton7.OnStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton7.OnStateBackImage")));
            this.dashboardButton7.OnStateForeColor = System.Drawing.Color.White;
            this.dashboardButton7.OnStateText = "WINDLASS\r\nIN";
            this.dashboardButton7.Size = new System.Drawing.Size(250, 105);
            this.dashboardButton7.State = false;
            this.dashboardButton7.TabIndex = 103;
            this.dashboardButton7.Text = "WINDLASS\r\nIN";
            this.dashboardButton7.UseVisualStyleBackColor = true;
            this.dashboardButton7.NewCommand += new System.EventHandler<BoatFormsLib.DashboardButtonArgs>(this.NewCommand);
            // 
            // dashboardButton3
            // 
            this.dashboardButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton3.BackgroundImage")));
            this.dashboardButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardButton3.ButtonBehavior = BoatFormsLib.CustomUserControls.ButtonBehavior.Toggle;
            this.dashboardButton3.FlatAppearance.BorderSize = 0;
            this.dashboardButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton3.ForeColor = System.Drawing.Color.White;
            this.dashboardButton3.Function = "BILGE PUMP MANUAL";
            this.dashboardButton3.Location = new System.Drawing.Point(12, 129);
            this.dashboardButton3.MvecAddress = ((byte)(177));
            this.dashboardButton3.MvecFuseNumber = ((byte)(3));
            this.dashboardButton3.MvecGrid = ((byte)(0));
            this.dashboardButton3.MvecRelayNumber = ((byte)(7));
            this.dashboardButton3.Name = "dashboardButton3";
            this.dashboardButton3.OffStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton3.OffStateBackImage")));
            this.dashboardButton3.OffStateForeColor = System.Drawing.Color.White;
            this.dashboardButton3.OffStateText = "BILGE PUMP\r\nIN AUTO";
            this.dashboardButton3.OnStateBackImage = global::WhatTheHelmRuntime.Properties.Resources.YellowButton;
            this.dashboardButton3.OnStateForeColor = System.Drawing.Color.Black;
            this.dashboardButton3.OnStateText = "BILGE PUMP\r\nIN MANUAL";
            this.dashboardButton3.Size = new System.Drawing.Size(250, 105);
            this.dashboardButton3.State = false;
            this.dashboardButton3.TabIndex = 100;
            this.dashboardButton3.Text = "BILGE PUMP\r\nIN AUTO";
            this.dashboardButton3.UseVisualStyleBackColor = true;
            this.dashboardButton3.NewCommand += new System.EventHandler<BoatFormsLib.DashboardButtonArgs>(this.NewCommand);
            // 
            // dashboardButton2
            // 
            this.dashboardButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton2.BackgroundImage")));
            this.dashboardButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardButton2.ButtonBehavior = BoatFormsLib.CustomUserControls.ButtonBehavior.Toggle;
            this.dashboardButton2.FlatAppearance.BorderSize = 0;
            this.dashboardButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton2.ForeColor = System.Drawing.Color.White;
            this.dashboardButton2.Function = "BILGE BLOWER";
            this.dashboardButton2.Location = new System.Drawing.Point(12, 12);
            this.dashboardButton2.MvecAddress = ((byte)(176));
            this.dashboardButton2.MvecFuseNumber = ((byte)(4));
            this.dashboardButton2.MvecGrid = ((byte)(0));
            this.dashboardButton2.MvecRelayNumber = ((byte)(2));
            this.dashboardButton2.Name = "dashboardButton2";
            this.dashboardButton2.OffStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton2.OffStateBackImage")));
            this.dashboardButton2.OffStateForeColor = System.Drawing.Color.White;
            this.dashboardButton2.OffStateText = "BILGE BLOWER\r\nOFF";
            this.dashboardButton2.OnStateBackImage = ((System.Drawing.Image)(resources.GetObject("dashboardButton2.OnStateBackImage")));
            this.dashboardButton2.OnStateForeColor = System.Drawing.Color.White;
            this.dashboardButton2.OnStateText = "BILGE BLOWER\r\nON";
            this.dashboardButton2.Size = new System.Drawing.Size(250, 105);
            this.dashboardButton2.State = false;
            this.dashboardButton2.TabIndex = 99;
            this.dashboardButton2.Text = "BILGE BLOWER\r\nOFF";
            this.dashboardButton2.UseVisualStyleBackColor = true;
            this.dashboardButton2.NewCommand += new System.EventHandler<BoatFormsLib.DashboardButtonArgs>(this.NewCommand);
            // 
            // SwitchPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dashboardButton5);
            this.Controls.Add(this.dashboardButton8);
            this.Controls.Add(this.dashboardButton11);
            this.Controls.Add(this.dashboardButton12);
            this.Controls.Add(this.dashboardButton9);
            this.Controls.Add(this.dashboardButton6);
            this.Controls.Add(this.dashboardButton7);
            this.Controls.Add(this.dashboardButton3);
            this.Controls.Add(this.dashboardButton2);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SwitchPanel";
            this.Text = "SwitchPanel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion
        private BoatFormsLib.CustomUserControls.DashboardButton dashboardButton2;
        private BoatFormsLib.CustomUserControls.DashboardButton dashboardButton3;
        private BoatFormsLib.CustomUserControls.DashboardButton dashboardButton6;
        private BoatFormsLib.CustomUserControls.DashboardButton dashboardButton7;
        private BoatFormsLib.CustomUserControls.DashboardButton dashboardButton9;
        private BoatFormsLib.CustomUserControls.DashboardButton dashboardButton11;
        private BoatFormsLib.CustomUserControls.DashboardButton dashboardButton12;
        private BoatFormsLib.CustomUserControls.DashboardButton dashboardButton8;
        private BoatFormsLib.CustomUserControls.DashboardButton dashboardButton5;
        private System.Windows.Forms.Button button1;
    }
}