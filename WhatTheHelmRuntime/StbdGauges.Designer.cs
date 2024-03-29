﻿
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
            CodeArtEng.Gauge.Themes.ThemeColors themeColors1 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors2 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors3 = new CodeArtEng.Gauge.Themes.ThemeColors();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblDriveTempHigh = new System.Windows.Forms.Label();
            this.lblVoltageLow = new System.Windows.Forms.Label();
            this.lblOilPressLow = new System.Windows.Forms.Label();
            this.lblFuelPressLow = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWaterTempHigh = new System.Windows.Forms.Label();
            this.gaugeRpm = new CodeArtEng.Gauge.CircularGauge();
            this.gaugeOilPressure = new CodeArtEng.Gauge.CircularGauge();
            this.gaugeVolts = new CodeArtEng.Gauge.CircularGauge();
            this.gaugeDrivePressure = new CodeArtEng.Gauge.CircularGauge();
            this.gaugeWaterTemp = new CodeArtEng.Gauge.CircularGauge();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConfigNmea2000 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHours
            // 
            this.lblHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lblHours.Font = new System.Drawing.Font("Arial", 14F);
            this.lblHours.ForeColor = System.Drawing.Color.White;
            this.lblHours.Location = new System.Drawing.Point(241, 533);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(151, 22);
            this.lblHours.TabIndex = 130;
            this.lblHours.Text = "--";
            this.lblHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDriveTempHigh
            // 
            this.lblDriveTempHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDriveTempHigh.Font = new System.Drawing.Font("Arial", 14F);
            this.lblDriveTempHigh.ForeColor = System.Drawing.Color.Black;
            this.lblDriveTempHigh.Location = new System.Drawing.Point(1060, 630);
            this.lblDriveTempHigh.Name = "lblDriveTempHigh";
            this.lblDriveTempHigh.Size = new System.Drawing.Size(69, 25);
            this.lblDriveTempHigh.TabIndex = 129;
            this.lblDriveTempHigh.Text = "TEMP";
            this.lblDriveTempHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVoltageLow
            // 
            this.lblVoltageLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVoltageLow.Font = new System.Drawing.Font("Arial", 14F);
            this.lblVoltageLow.ForeColor = System.Drawing.Color.Black;
            this.lblVoltageLow.Location = new System.Drawing.Point(713, 630);
            this.lblVoltageLow.Name = "lblVoltageLow";
            this.lblVoltageLow.Size = new System.Drawing.Size(69, 25);
            this.lblVoltageLow.TabIndex = 128;
            this.lblVoltageLow.Text = "LOW";
            this.lblVoltageLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOilPressLow
            // 
            this.lblOilPressLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOilPressLow.Font = new System.Drawing.Font("Arial", 14F);
            this.lblOilPressLow.ForeColor = System.Drawing.Color.Black;
            this.lblOilPressLow.Location = new System.Drawing.Point(1060, 295);
            this.lblOilPressLow.Name = "lblOilPressLow";
            this.lblOilPressLow.Size = new System.Drawing.Size(69, 25);
            this.lblOilPressLow.TabIndex = 127;
            this.lblOilPressLow.Text = "LOW";
            this.lblOilPressLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFuelPressLow
            // 
            this.lblFuelPressLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFuelPressLow.Font = new System.Drawing.Font("Arial", 14F);
            this.lblFuelPressLow.ForeColor = System.Drawing.Color.Black;
            this.lblFuelPressLow.Location = new System.Drawing.Point(229, 498);
            this.lblFuelPressLow.Name = "lblFuelPressLow";
            this.lblFuelPressLow.Size = new System.Drawing.Size(173, 25);
            this.lblFuelPressLow.TabIndex = 126;
            this.lblFuelPressLow.Text = "FUEL PRESSURE";
            this.lblFuelPressLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(1031, 497);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(120, 20);
            this.panel5.TabIndex = 125;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(690, 497);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 20);
            this.panel4.TabIndex = 123;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(1031, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 20);
            this.panel1.TabIndex = 124;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(690, 165);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(120, 20);
            this.panel3.TabIndex = 122;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(192, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 39);
            this.panel2.TabIndex = 121;
            // 
            // lblWaterTempHigh
            // 
            this.lblWaterTempHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWaterTempHigh.Font = new System.Drawing.Font("Arial", 14F);
            this.lblWaterTempHigh.ForeColor = System.Drawing.Color.Black;
            this.lblWaterTempHigh.Location = new System.Drawing.Point(713, 295);
            this.lblWaterTempHigh.Name = "lblWaterTempHigh";
            this.lblWaterTempHigh.Size = new System.Drawing.Size(69, 25);
            this.lblWaterTempHigh.TabIndex = 120;
            this.lblWaterTempHigh.Text = "HIGH";
            this.lblWaterTempHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gaugeRpm
            // 
            this.gaugeRpm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugeRpm.ErrorLimit = 4000D;
            this.gaugeRpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeRpm.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.gaugeRpm.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugeRpm.Location = new System.Drawing.Point(38, 133);
            this.gaugeRpm.Maximum = 4000D;
            this.gaugeRpm.Name = "gaugeRpm";
            this.gaugeRpm.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugeRpm.PointerWidth = 80;
            this.gaugeRpm.ScaleFactor = 1D;
            this.gaugeRpm.SegmentGap = 10;
            this.gaugeRpm.Size = new System.Drawing.Size(555, 551);
            this.gaugeRpm.TabIndex = 119;
            this.gaugeRpm.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugeRpm.Title = "";
            this.gaugeRpm.Unit = "RPM";
            this.gaugeRpm.UserDefinedColors.Base = themeColors1;
            themeColors2.PointerColor = System.Drawing.Color.Red;
            this.gaugeRpm.UserDefinedColors.Error = themeColors2;
            themeColors3.PointerColor = System.Drawing.Color.Orange;
            this.gaugeRpm.UserDefinedColors.Warning = themeColors3;
            this.gaugeRpm.Value = 0D;
            this.gaugeRpm.WarningLimit = 3800D;
            // 
            // gaugeOilPressure
            // 
            this.gaugeOilPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugeOilPressure.ErrorLimit = 8D;
            this.gaugeOilPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeOilPressure.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeOilPressure.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugeOilPressure.InvertLimit = true;
            this.gaugeOilPressure.Location = new System.Drawing.Point(943, 83);
            this.gaugeOilPressure.Maximum = 120D;
            this.gaugeOilPressure.Name = "gaugeOilPressure";
            this.gaugeOilPressure.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugeOilPressure.PointerWidth = 40;
            this.gaugeOilPressure.ScaleFactor = 1D;
            this.gaugeOilPressure.SegmentGap = 10;
            this.gaugeOilPressure.Size = new System.Drawing.Size(300, 300);
            this.gaugeOilPressure.TabIndex = 118;
            this.gaugeOilPressure.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugeOilPressure.Title = "";
            this.gaugeOilPressure.Unit = "OIL PSI";
            this.gaugeOilPressure.Value = 0D;
            this.gaugeOilPressure.WarningLimit = 15D;
            // 
            // gaugeVolts
            // 
            this.gaugeVolts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugeVolts.ErrorLimit = 11.5D;
            this.gaugeVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeVolts.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeVolts.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugeVolts.InvertLimit = true;
            this.gaugeVolts.Location = new System.Drawing.Point(599, 417);
            this.gaugeVolts.Maximum = 15D;
            this.gaugeVolts.Name = "gaugeVolts";
            this.gaugeVolts.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugeVolts.PointerWidth = 40;
            this.gaugeVolts.ScaleFactor = 1D;
            this.gaugeVolts.SegmentGap = 10;
            this.gaugeVolts.Size = new System.Drawing.Size(300, 300);
            this.gaugeVolts.TabIndex = 117;
            this.gaugeVolts.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugeVolts.Title = "";
            this.gaugeVolts.Unit = "DC VOLTS";
            this.gaugeVolts.Value = 0D;
            this.gaugeVolts.WarningLimit = 12.2D;
            // 
            // gaugeDrivePressure
            // 
            this.gaugeDrivePressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugeDrivePressure.ErrorLimit = 30D;
            this.gaugeDrivePressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeDrivePressure.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeDrivePressure.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugeDrivePressure.InvertLimit = true;
            this.gaugeDrivePressure.Location = new System.Drawing.Point(943, 417);
            this.gaugeDrivePressure.Name = "gaugeDrivePressure";
            this.gaugeDrivePressure.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugeDrivePressure.PointerWidth = 40;
            this.gaugeDrivePressure.ScaleFactor = 1D;
            this.gaugeDrivePressure.SegmentGap = 10;
            this.gaugeDrivePressure.Size = new System.Drawing.Size(300, 300);
            this.gaugeDrivePressure.TabIndex = 116;
            this.gaugeDrivePressure.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugeDrivePressure.Title = "";
            this.gaugeDrivePressure.Unit = "GEAR PSI";
            this.gaugeDrivePressure.Value = 0D;
            this.gaugeDrivePressure.WarningLimit = 50D;
            // 
            // gaugeWaterTemp
            // 
            this.gaugeWaterTemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugeWaterTemp.ErrorLimit = 190D;
            this.gaugeWaterTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeWaterTemp.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeWaterTemp.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugeWaterTemp.Location = new System.Drawing.Point(599, 83);
            this.gaugeWaterTemp.Maximum = 220D;
            this.gaugeWaterTemp.Name = "gaugeWaterTemp";
            this.gaugeWaterTemp.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugeWaterTemp.PointerWidth = 40;
            this.gaugeWaterTemp.ScaleFactor = 1D;
            this.gaugeWaterTemp.SegmentGap = 10;
            this.gaugeWaterTemp.Size = new System.Drawing.Size(300, 300);
            this.gaugeWaterTemp.TabIndex = 115;
            this.gaugeWaterTemp.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugeWaterTemp.Title = "";
            this.gaugeWaterTemp.Unit = "WATER °F";
            this.gaugeWaterTemp.Value = 0D;
            this.gaugeWaterTemp.WarningLimit = 185D;
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
            this.btnConfigNmea2000.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // StbdGauges
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.btnConfigNmea2000);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.lblDriveTempHigh);
            this.Controls.Add(this.lblVoltageLow);
            this.Controls.Add(this.lblOilPressLow);
            this.Controls.Add(this.lblFuelPressLow);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblWaterTempHigh);
            this.Controls.Add(this.gaugeRpm);
            this.Controls.Add(this.gaugeOilPressure);
            this.Controls.Add(this.gaugeVolts);
            this.Controls.Add(this.gaugeDrivePressure);
            this.Controls.Add(this.gaugeWaterTemp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StbdGauges";
            this.Text = "StbdGauges";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblDriveTempHigh;
        private System.Windows.Forms.Label lblVoltageLow;
        private System.Windows.Forms.Label lblOilPressLow;
        private System.Windows.Forms.Label lblFuelPressLow;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWaterTempHigh;
        private CodeArtEng.Gauge.CircularGauge gaugeRpm;
        private CodeArtEng.Gauge.CircularGauge gaugeOilPressure;
        private CodeArtEng.Gauge.CircularGauge gaugeVolts;
        private CodeArtEng.Gauge.CircularGauge gaugeDrivePressure;
        private CodeArtEng.Gauge.CircularGauge gaugeWaterTemp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConfigNmea2000;
        private System.Windows.Forms.Button btnExit;
    }
}