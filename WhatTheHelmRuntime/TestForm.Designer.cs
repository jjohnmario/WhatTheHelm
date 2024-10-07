namespace WhatTheHelmRuntime
{
    partial class TestForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.dashboardButton4 = new BoatFormsLib.CustomUserControls.DashboardButton();
            this.dashboardButton3 = new BoatFormsLib.CustomUserControls.DashboardButton();
            this.btnBothBowUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.BlackButtonGear1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.button1.Location = new System.Drawing.Point(636, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 76);
            this.button1.TabIndex = 116;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dashboardButton4
            // 
            this.dashboardButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.dashboardButton4.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.Picture2;
            this.dashboardButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardButton4.ButtonBehavior = BoatFormsLib.CustomUserControls.ButtonBehavior.Momentary;
            this.dashboardButton4.FlatAppearance.BorderSize = 0;
            this.dashboardButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton4.Function = null;
            this.dashboardButton4.Location = new System.Drawing.Point(468, 65);
            this.dashboardButton4.MvecAddress = ((byte)(0));
            this.dashboardButton4.MvecFuseNumber = ((byte)(0));
            this.dashboardButton4.MvecGrid = ((byte)(0));
            this.dashboardButton4.MvecRelayNumber = ((byte)(0));
            this.dashboardButton4.Name = "dashboardButton4";
            this.dashboardButton4.OffStateBackImage = global::WhatTheHelmRuntime.Properties.Resources.Picture2;
            this.dashboardButton4.OffStateForeColor = System.Drawing.Color.Empty;
            this.dashboardButton4.OffStateText = null;
            this.dashboardButton4.OnStateBackImage = global::WhatTheHelmRuntime.Properties.Resources.Windlass_In_On;
            this.dashboardButton4.OnStateForeColor = System.Drawing.Color.Empty;
            this.dashboardButton4.OnStateText = null;
            this.dashboardButton4.Size = new System.Drawing.Size(150, 150);
            this.dashboardButton4.State = false;
            this.dashboardButton4.TabIndex = 4;
            this.dashboardButton4.UseVisualStyleBackColor = false;
            // 
            // dashboardButton3
            // 
            this.dashboardButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.dashboardButton3.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.Picture2;
            this.dashboardButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardButton3.ButtonBehavior = BoatFormsLib.CustomUserControls.ButtonBehavior.Momentary;
            this.dashboardButton3.FlatAppearance.BorderSize = 0;
            this.dashboardButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.dashboardButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton3.Function = null;
            this.dashboardButton3.Location = new System.Drawing.Point(316, 65);
            this.dashboardButton3.MvecAddress = ((byte)(0));
            this.dashboardButton3.MvecFuseNumber = ((byte)(0));
            this.dashboardButton3.MvecGrid = ((byte)(0));
            this.dashboardButton3.MvecRelayNumber = ((byte)(0));
            this.dashboardButton3.Name = "dashboardButton3";
            this.dashboardButton3.OffStateBackImage = global::WhatTheHelmRuntime.Properties.Resources.Picture2;
            this.dashboardButton3.OffStateForeColor = System.Drawing.Color.Empty;
            this.dashboardButton3.OffStateText = null;
            this.dashboardButton3.OnStateBackImage = global::WhatTheHelmRuntime.Properties.Resources.Windlass_In_On;
            this.dashboardButton3.OnStateForeColor = System.Drawing.Color.Empty;
            this.dashboardButton3.OnStateText = null;
            this.dashboardButton3.Size = new System.Drawing.Size(150, 150);
            this.dashboardButton3.State = false;
            this.dashboardButton3.TabIndex = 3;
            this.dashboardButton3.UseVisualStyleBackColor = false;
            this.dashboardButton3.NewCommand += new System.EventHandler<BoatFormsLib.DashboardButtonArgs>(this.dashboardButton3_NewCommand);
            // 
            // btnBothBowUp
            // 
            this.btnBothBowUp.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.Bow_Up_Off;
            this.btnBothBowUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBothBowUp.FlatAppearance.BorderSize = 0;
            this.btnBothBowUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBothBowUp.Location = new System.Drawing.Point(128, 186);
            this.btnBothBowUp.Name = "btnBothBowUp";
            this.btnBothBowUp.Size = new System.Drawing.Size(150, 150);
            this.btnBothBowUp.TabIndex = 159;
            this.btnBothBowUp.UseVisualStyleBackColor = true;
            this.btnBothBowUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBothBowUp_MouseDown);
            this.btnBothBowUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBothBowUp_MouseUp);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.ControlBox = false;
            this.Controls.Add(this.btnBothBowUp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dashboardButton4);
            this.Controls.Add(this.dashboardButton3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion
        private BoatFormsLib.CustomUserControls.DashboardButton dashboardButton3;
        private BoatFormsLib.CustomUserControls.DashboardButton dashboardButton4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBothBowUp;
    }
}