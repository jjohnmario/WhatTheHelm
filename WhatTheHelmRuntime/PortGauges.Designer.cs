﻿
namespace WhatTheHelmRuntime
{
    partial class PortGauges
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortGauges));
            this.lblDriveTempHigh = new System.Windows.Forms.Label();
            this.lblOilPressLow = new System.Windows.Forms.Label();
            this.lblFuelPressLow = new System.Windows.Forms.Label();
            this.lblWaterTempHigh = new System.Windows.Forms.Label();
            this.lblCanMsgQueue = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblLastBusScan = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblJ1939BustStatus = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConfigNmea2000 = new System.Windows.Forms.Button();
            this.btnCalScreens = new System.Windows.Forms.Button();
            this.elementHostRpm = new System.Windows.Forms.Integration.ElementHost();
            this.gaugeRpm = new WhatTheHelmFormsLib.Tachometer();
            this.elementHostWaterTemp = new System.Windows.Forms.Integration.ElementHost();
            this.gaugeWaterTemp = new WhatTheHelmFormsLib.TempGauge();
            this.elementHostOilPress = new System.Windows.Forms.Integration.ElementHost();
            this.gaugeOilPressure = new WhatTheHelmFormsLib.OilPressGauge();
            this.elementHostTransPress = new System.Windows.Forms.Integration.ElementHost();
            this.gaugeDrivePressure = new WhatTheHelmFormsLib.GearPressGauge();
            this.elementHostVolts = new System.Windows.Forms.Integration.ElementHost();
            this.gaugeVolts = new WhatTheHelmFormsLib.VoltGauge();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDriveTempHigh
            // 
            this.lblDriveTempHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDriveTempHigh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriveTempHigh.ForeColor = System.Drawing.Color.Black;
            this.lblDriveTempHigh.Location = new System.Drawing.Point(152, 459);
            this.lblDriveTempHigh.Name = "lblDriveTempHigh";
            this.lblDriveTempHigh.Size = new System.Drawing.Size(69, 25);
            this.lblDriveTempHigh.TabIndex = 129;
            this.lblDriveTempHigh.Text = "TEMP";
            this.lblDriveTempHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOilPressLow
            // 
            this.lblOilPressLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOilPressLow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOilPressLow.ForeColor = System.Drawing.Color.Black;
            this.lblOilPressLow.Location = new System.Drawing.Point(152, 124);
            this.lblOilPressLow.Name = "lblOilPressLow";
            this.lblOilPressLow.Size = new System.Drawing.Size(69, 25);
            this.lblOilPressLow.TabIndex = 127;
            this.lblOilPressLow.Text = "LOW";
            this.lblOilPressLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFuelPressLow
            // 
            this.lblFuelPressLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFuelPressLow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuelPressLow.ForeColor = System.Drawing.Color.Black;
            this.lblFuelPressLow.Location = new System.Drawing.Point(876, 210);
            this.lblFuelPressLow.Name = "lblFuelPressLow";
            this.lblFuelPressLow.Size = new System.Drawing.Size(173, 25);
            this.lblFuelPressLow.TabIndex = 126;
            this.lblFuelPressLow.Text = "FUEL PRESSURE";
            this.lblFuelPressLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWaterTempHigh
            // 
            this.lblWaterTempHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWaterTempHigh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterTempHigh.ForeColor = System.Drawing.Color.Black;
            this.lblWaterTempHigh.Location = new System.Drawing.Point(498, 124);
            this.lblWaterTempHigh.Name = "lblWaterTempHigh";
            this.lblWaterTempHigh.Size = new System.Drawing.Size(69, 25);
            this.lblWaterTempHigh.TabIndex = 120;
            this.lblWaterTempHigh.Text = "HIGH";
            this.lblWaterTempHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCanMsgQueue
            // 
            this.lblCanMsgQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCanMsgQueue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanMsgQueue.ForeColor = System.Drawing.Color.White;
            this.lblCanMsgQueue.Location = new System.Drawing.Point(1154, 738);
            this.lblCanMsgQueue.Name = "lblCanMsgQueue";
            this.lblCanMsgQueue.Size = new System.Drawing.Size(93, 22);
            this.lblCanMsgQueue.TabIndex = 136;
            this.lblCanMsgQueue.Text = "--";
            this.lblCanMsgQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(996, 738);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(156, 22);
            this.label25.TabIndex = 135;
            this.label25.Text = "CAN MESSAGES IN QUEUE: ";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastBusScan
            // 
            this.lblLastBusScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastBusScan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastBusScan.ForeColor = System.Drawing.Color.White;
            this.lblLastBusScan.Location = new System.Drawing.Point(1154, 709);
            this.lblLastBusScan.Name = "lblLastBusScan";
            this.lblLastBusScan.Size = new System.Drawing.Size(93, 22);
            this.lblLastBusScan.TabIndex = 134;
            this.lblLastBusScan.Text = "--";
            this.lblLastBusScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(1008, 709);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(144, 22);
            this.label32.TabIndex = 133;
            this.label32.Text = "LAST BUS READ: ";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblJ1939BustStatus
            // 
            this.lblJ1939BustStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJ1939BustStatus.BackColor = System.Drawing.Color.Red;
            this.lblJ1939BustStatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJ1939BustStatus.ForeColor = System.Drawing.Color.White;
            this.lblJ1939BustStatus.Location = new System.Drawing.Point(1154, 684);
            this.lblJ1939BustStatus.Name = "lblJ1939BustStatus";
            this.lblJ1939BustStatus.Size = new System.Drawing.Size(114, 22);
            this.lblJ1939BustStatus.TabIndex = 132;
            this.lblJ1939BustStatus.Text = "FAULTED";
            this.lblJ1939BustStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(1005, 684);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(147, 22);
            this.label33.TabIndex = 131;
            this.label33.Text = "BUS STATUS: ";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Fuchsia;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(874, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 37);
            this.label5.TabIndex = 148;
            this.label5.Text = "NO DATA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Fuchsia;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(102, 549);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 37);
            this.label3.TabIndex = 147;
            this.label3.Text = "NO DATA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Fuchsia;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 37);
            this.label4.TabIndex = 146;
            this.label4.Text = "NO DATA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Fuchsia;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(448, 549);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 37);
            this.label2.TabIndex = 145;
            this.label2.Text = "NO DATA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Fuchsia;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(449, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 37);
            this.label1.TabIndex = 144;
            this.label1.Text = "NO DATA";
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
            this.btnExit.Location = new System.Drawing.Point(12, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(69, 52);
            this.btnExit.TabIndex = 149;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnConfigNmea2000
            // 
            this.btnConfigNmea2000.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.BlackButton;
            this.btnConfigNmea2000.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfigNmea2000.FlatAppearance.BorderSize = 0;
            this.btnConfigNmea2000.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigNmea2000.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigNmea2000.ForeColor = System.Drawing.Color.White;
            this.btnConfigNmea2000.Location = new System.Drawing.Point(12, 736);
            this.btnConfigNmea2000.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfigNmea2000.Name = "btnConfigNmea2000";
            this.btnConfigNmea2000.Size = new System.Drawing.Size(157, 61);
            this.btnConfigNmea2000.TabIndex = 151;
            this.btnConfigNmea2000.TabStop = false;
            this.btnConfigNmea2000.Text = "NMEA 2000\r\nCONFIGURATION";
            this.btnConfigNmea2000.UseVisualStyleBackColor = true;
            this.btnConfigNmea2000.Click += new System.EventHandler(this.btnConfigNmea2000_Click);
            // 
            // btnCalScreens
            // 
            this.btnCalScreens.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.BlackButton;
            this.btnCalScreens.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCalScreens.FlatAppearance.BorderSize = 0;
            this.btnCalScreens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalScreens.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalScreens.ForeColor = System.Drawing.Color.White;
            this.btnCalScreens.Location = new System.Drawing.Point(178, 736);
            this.btnCalScreens.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalScreens.Name = "btnCalScreens";
            this.btnCalScreens.Size = new System.Drawing.Size(157, 61);
            this.btnCalScreens.TabIndex = 152;
            this.btnCalScreens.TabStop = false;
            this.btnCalScreens.Text = "CALIBRATE TOUCH SCREENS";
            this.btnCalScreens.UseVisualStyleBackColor = true;
            this.btnCalScreens.Click += new System.EventHandler(this.btnCalScreens_Click);
            // 
            // elementHostRpm
            // 
            this.elementHostRpm.Location = new System.Drawing.Point(690, 133);
            this.elementHostRpm.Name = "elementHostRpm";
            this.elementHostRpm.Size = new System.Drawing.Size(555, 555);
            this.elementHostRpm.TabIndex = 153;
            this.elementHostRpm.Text = "elementHost1";
            this.elementHostRpm.Child = this.gaugeRpm;
            // 
            // elementHostWaterTemp
            // 
            this.elementHostWaterTemp.Location = new System.Drawing.Point(383, 83);
            this.elementHostWaterTemp.Name = "elementHostWaterTemp";
            this.elementHostWaterTemp.Size = new System.Drawing.Size(300, 300);
            this.elementHostWaterTemp.TabIndex = 154;
            this.elementHostWaterTemp.Text = "elementHost2";
            this.elementHostWaterTemp.Child = this.gaugeWaterTemp;
            // 
            // elementHostOilPress
            // 
            this.elementHostOilPress.Location = new System.Drawing.Point(35, 83);
            this.elementHostOilPress.Name = "elementHostOilPress";
            this.elementHostOilPress.Size = new System.Drawing.Size(300, 300);
            this.elementHostOilPress.TabIndex = 155;
            this.elementHostOilPress.Text = "elementHost3";
            this.elementHostOilPress.Child = this.gaugeOilPressure;
            // 
            // elementHostTransPress
            // 
            this.elementHostTransPress.Location = new System.Drawing.Point(35, 417);
            this.elementHostTransPress.Name = "elementHostTransPress";
            this.elementHostTransPress.Size = new System.Drawing.Size(300, 300);
            this.elementHostTransPress.TabIndex = 156;
            this.elementHostTransPress.Text = "elementHost4";
            this.elementHostTransPress.Child = this.gaugeDrivePressure;
            // 
            // elementHostVolts
            // 
            this.elementHostVolts.Location = new System.Drawing.Point(382, 417);
            this.elementHostVolts.Name = "elementHostVolts";
            this.elementHostVolts.Size = new System.Drawing.Size(300, 300);
            this.elementHostVolts.TabIndex = 157;
            this.elementHostVolts.Text = "elementHost5";
            this.elementHostVolts.Child = this.gaugeVolts;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(360, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 158;
            // 
            // PortGauges
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCalScreens);
            this.Controls.Add(this.btnConfigNmea2000);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblCanMsgQueue);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.lblLastBusScan);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.lblJ1939BustStatus);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.lblDriveTempHigh);
            this.Controls.Add(this.lblOilPressLow);
            this.Controls.Add(this.lblFuelPressLow);
            this.Controls.Add(this.lblWaterTempHigh);
            this.Controls.Add(this.elementHostRpm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.elementHostOilPress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.elementHostTransPress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.elementHostVolts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.elementHostWaterTemp);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PortGauges";
            this.Text = "PortGauges";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDriveTempHigh;
        private System.Windows.Forms.Label lblOilPressLow;
        private System.Windows.Forms.Label lblFuelPressLow;
        private System.Windows.Forms.Label lblWaterTempHigh;
        private System.Windows.Forms.Label lblCanMsgQueue;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblLastBusScan;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblJ1939BustStatus;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConfigNmea2000;
        private System.Windows.Forms.Button btnCalScreens;
        private System.Windows.Forms.Integration.ElementHost elementHostRpm;
        private WhatTheHelmFormsLib.Tachometer gaugeRpm;
        private System.Windows.Forms.Integration.ElementHost elementHostWaterTemp;
        private WhatTheHelmFormsLib.TempGauge gaugeWaterTemp;
        private System.Windows.Forms.Integration.ElementHost elementHostOilPress;
        private WhatTheHelmFormsLib.OilPressGauge gaugeOilPressure;
        private System.Windows.Forms.Integration.ElementHost elementHostTransPress;
        private WhatTheHelmFormsLib.GearPressGauge gaugeDrivePressure;
        private System.Windows.Forms.Integration.ElementHost elementHostVolts;
        private WhatTheHelmFormsLib.VoltGauge gaugeVolts;
        private System.Windows.Forms.Label label6;
    }
}