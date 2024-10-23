
namespace WhatTheHelmRuntime
{
    partial class StbdGauges
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StbdGauges));
            this.lblDriveTempHigh = new System.Windows.Forms.Label();
            this.lblOilPressLow = new System.Windows.Forms.Label();
            this.lblFuelPressLow = new System.Windows.Forms.Label();
            this.lblWaterTempHigh = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConfigNmea2000 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.elementHostRpm = new System.Windows.Forms.Integration.ElementHost();
            this.gaugeRpm = new WhatTheHelmFormsLib.Tachometer();
            this.elementHostWaterTemp = new System.Windows.Forms.Integration.ElementHost();
            this.gaugeWaterTemp = new WhatTheHelmFormsLib.TempGauge();
            this.elementHostVolts = new System.Windows.Forms.Integration.ElementHost();
            this.gaugeVolts = new WhatTheHelmFormsLib.VoltGauge();
            this.elementHostOilPress = new System.Windows.Forms.Integration.ElementHost();
            this.gaugeOilPressure = new WhatTheHelmFormsLib.OilPressGauge();
            this.elementHostTransPress = new System.Windows.Forms.Integration.ElementHost();
            this.gaugeDrivePressure = new WhatTheHelmFormsLib.GearPressGauge();
            this.SuspendLayout();
            // 
            // lblDriveTempHigh
            // 
            this.lblDriveTempHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDriveTempHigh.Font = new System.Drawing.Font("Arial", 12F);
            this.lblDriveTempHigh.ForeColor = System.Drawing.Color.Black;
            this.lblDriveTempHigh.Location = new System.Drawing.Point(1060, 459);
            this.lblDriveTempHigh.Name = "lblDriveTempHigh";
            this.lblDriveTempHigh.Size = new System.Drawing.Size(69, 25);
            this.lblDriveTempHigh.TabIndex = 129;
            this.lblDriveTempHigh.Text = "TEMP";
            this.lblDriveTempHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOilPressLow
            // 
            this.lblOilPressLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOilPressLow.Font = new System.Drawing.Font("Arial", 12F);
            this.lblOilPressLow.ForeColor = System.Drawing.Color.Black;
            this.lblOilPressLow.Location = new System.Drawing.Point(1060, 124);
            this.lblOilPressLow.Name = "lblOilPressLow";
            this.lblOilPressLow.Size = new System.Drawing.Size(69, 25);
            this.lblOilPressLow.TabIndex = 127;
            this.lblOilPressLow.Text = "LOW";
            this.lblOilPressLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFuelPressLow
            // 
            this.lblFuelPressLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFuelPressLow.Font = new System.Drawing.Font("Arial", 12F);
            this.lblFuelPressLow.ForeColor = System.Drawing.Color.Black;
            this.lblFuelPressLow.Location = new System.Drawing.Point(224, 209);
            this.lblFuelPressLow.Name = "lblFuelPressLow";
            this.lblFuelPressLow.Size = new System.Drawing.Size(173, 25);
            this.lblFuelPressLow.TabIndex = 126;
            this.lblFuelPressLow.Text = "FUEL PRESSURE";
            this.lblFuelPressLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWaterTempHigh
            // 
            this.lblWaterTempHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWaterTempHigh.Font = new System.Drawing.Font("Arial", 12F);
            this.lblWaterTempHigh.ForeColor = System.Drawing.Color.Black;
            this.lblWaterTempHigh.Location = new System.Drawing.Point(713, 124);
            this.lblWaterTempHigh.Name = "lblWaterTempHigh";
            this.lblWaterTempHigh.Size = new System.Drawing.Size(69, 25);
            this.lblWaterTempHigh.TabIndex = 120;
            this.lblWaterTempHigh.Text = "HIGH";
            this.lblWaterTempHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Fuchsia;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(663, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 37);
            this.label1.TabIndex = 139;
            this.label1.Text = "NO DATA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Fuchsia;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(663, 547);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 37);
            this.label2.TabIndex = 140;
            this.label2.Text = "NO DATA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Fuchsia;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1008, 547);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 37);
            this.label3.TabIndex = 142;
            this.label3.Text = "NO DATA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Fuchsia;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1008, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 37);
            this.label4.TabIndex = 141;
            this.label4.Text = "NO DATA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Fuchsia;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(223, 386);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 37);
            this.label5.TabIndex = 143;
            this.label5.Text = "NO DATA";
            // 
            // btnConfigNmea2000
            // 
            this.btnConfigNmea2000.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.BlackButton;
            this.btnConfigNmea2000.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfigNmea2000.FlatAppearance.BorderSize = 0;
            this.btnConfigNmea2000.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigNmea2000.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigNmea2000.ForeColor = System.Drawing.Color.White;
            this.btnConfigNmea2000.Location = new System.Drawing.Point(1110, 736);
            this.btnConfigNmea2000.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfigNmea2000.Name = "btnConfigNmea2000";
            this.btnConfigNmea2000.Size = new System.Drawing.Size(157, 53);
            this.btnConfigNmea2000.TabIndex = 153;
            this.btnConfigNmea2000.TabStop = false;
            this.btnConfigNmea2000.Text = "NMEA 2000\r\nCONFIGURATION";
            this.btnConfigNmea2000.UseVisualStyleBackColor = true;
            this.btnConfigNmea2000.Click += new System.EventHandler(this.btnConfigNmea2000_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.BlackButton;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1200, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(69, 52);
            this.btnExit.TabIndex = 152;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // elementHostRpm
            // 
            this.elementHostRpm.Location = new System.Drawing.Point(38, 133);
            this.elementHostRpm.Name = "elementHostRpm";
            this.elementHostRpm.Size = new System.Drawing.Size(555, 555);
            this.elementHostRpm.TabIndex = 154;
            this.elementHostRpm.Child = this.gaugeRpm;
            // 
            // elementHostWaterTemp
            // 
            this.elementHostWaterTemp.Location = new System.Drawing.Point(599, 83);
            this.elementHostWaterTemp.Name = "elementHostWaterTemp";
            this.elementHostWaterTemp.Size = new System.Drawing.Size(300, 300);
            this.elementHostWaterTemp.TabIndex = 155;
            this.elementHostWaterTemp.Text = "elementHost1";
            this.elementHostWaterTemp.Child = this.gaugeWaterTemp;
            // 
            // elementHostVolts
            // 
            this.elementHostVolts.Location = new System.Drawing.Point(599, 417);
            this.elementHostVolts.Name = "elementHostVolts";
            this.elementHostVolts.Size = new System.Drawing.Size(300, 300);
            this.elementHostVolts.TabIndex = 156;
            this.elementHostVolts.Text = "elementHost1";
            this.elementHostVolts.Child = this.gaugeVolts;
            // 
            // elementHostOilPress
            // 
            this.elementHostOilPress.Location = new System.Drawing.Point(943, 83);
            this.elementHostOilPress.Name = "elementHostOilPress";
            this.elementHostOilPress.Size = new System.Drawing.Size(300, 300);
            this.elementHostOilPress.TabIndex = 157;
            this.elementHostOilPress.Text = "gaugeOilPressure";
            this.elementHostOilPress.Child = this.gaugeOilPressure;
            // 
            // elementHostTransPress
            // 
            this.elementHostTransPress.Location = new System.Drawing.Point(943, 417);
            this.elementHostTransPress.Name = "elementHostTransPress";
            this.elementHostTransPress.Size = new System.Drawing.Size(300, 300);
            this.elementHostTransPress.TabIndex = 158;
            this.elementHostTransPress.Text = "gaugeDrivePressure";
            this.elementHostTransPress.Child = this.gaugeDrivePressure;
            // 
            // StbdGauges
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.btnConfigNmea2000);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblDriveTempHigh);
            this.Controls.Add(this.lblOilPressLow);
            this.Controls.Add(this.lblFuelPressLow);
            this.Controls.Add(this.lblWaterTempHigh);
            this.Controls.Add(this.elementHostRpm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.elementHostWaterTemp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elementHostVolts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.elementHostOilPress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.elementHostTransPress);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StbdGauges";
            this.Text = "StbdGauges";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDriveTempHigh;
        private System.Windows.Forms.Label lblOilPressLow;
        private System.Windows.Forms.Label lblFuelPressLow;
        private System.Windows.Forms.Label lblWaterTempHigh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConfigNmea2000;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Integration.ElementHost elementHostRpm;
        private WhatTheHelmFormsLib.Tachometer gaugeRpm;
        private System.Windows.Forms.Integration.ElementHost elementHostWaterTemp;
        private System.Windows.Forms.Integration.ElementHost elementHostVolts;
        private System.Windows.Forms.Integration.ElementHost elementHostOilPress;
        private WhatTheHelmFormsLib.OilPressGauge gaugeOilPressure;
        private System.Windows.Forms.Integration.ElementHost elementHostTransPress;
        private WhatTheHelmFormsLib.GearPressGauge gaugeDrivePressure;
        private WhatTheHelmFormsLib.TempGauge gaugeWaterTemp;
        private WhatTheHelmFormsLib.VoltGauge gaugeVolts;
    }
}