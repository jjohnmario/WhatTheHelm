
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
            this.lblStbdHours = new System.Windows.Forms.Label();
            this.lblStbdDriveTempHigh = new System.Windows.Forms.Label();
            this.lblStbdVoltageLow = new System.Windows.Forms.Label();
            this.lblStbdOilPressLow = new System.Windows.Forms.Label();
            this.lblStbdFuelPressLow = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStbdWaterTempHigh = new System.Windows.Forms.Label();
            this.gaugeStbdRpm = new CodeArtEng.Gauge.CircularGauge();
            this.gaugeStbdOilPressure = new CodeArtEng.Gauge.CircularGauge();
            this.gaugeStbdVolts = new CodeArtEng.Gauge.CircularGauge();
            this.gaugeStbdDrivePressure = new CodeArtEng.Gauge.CircularGauge();
            this.gaugeStbdWaterTemp = new CodeArtEng.Gauge.CircularGauge();
            this.lblFastPacketQueue = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lblCanMsgQueue = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblLastBusScan = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblJ1939BustStatus = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStbdHours
            // 
            this.lblStbdHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStbdHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lblStbdHours.Font = new System.Drawing.Font("Arial", 14F);
            this.lblStbdHours.ForeColor = System.Drawing.Color.White;
            this.lblStbdHours.Location = new System.Drawing.Point(241, 533);
            this.lblStbdHours.Name = "lblStbdHours";
            this.lblStbdHours.Size = new System.Drawing.Size(151, 22);
            this.lblStbdHours.TabIndex = 130;
            this.lblStbdHours.Text = "--";
            this.lblStbdHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStbdDriveTempHigh
            // 
            this.lblStbdDriveTempHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStbdDriveTempHigh.Font = new System.Drawing.Font("Arial", 14F);
            this.lblStbdDriveTempHigh.ForeColor = System.Drawing.Color.Black;
            this.lblStbdDriveTempHigh.Location = new System.Drawing.Point(1060, 630);
            this.lblStbdDriveTempHigh.Name = "lblStbdDriveTempHigh";
            this.lblStbdDriveTempHigh.Size = new System.Drawing.Size(69, 25);
            this.lblStbdDriveTempHigh.TabIndex = 129;
            this.lblStbdDriveTempHigh.Text = "TEMP";
            this.lblStbdDriveTempHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStbdVoltageLow
            // 
            this.lblStbdVoltageLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStbdVoltageLow.Font = new System.Drawing.Font("Arial", 14F);
            this.lblStbdVoltageLow.ForeColor = System.Drawing.Color.Black;
            this.lblStbdVoltageLow.Location = new System.Drawing.Point(713, 630);
            this.lblStbdVoltageLow.Name = "lblStbdVoltageLow";
            this.lblStbdVoltageLow.Size = new System.Drawing.Size(69, 25);
            this.lblStbdVoltageLow.TabIndex = 128;
            this.lblStbdVoltageLow.Text = "LOW";
            this.lblStbdVoltageLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStbdOilPressLow
            // 
            this.lblStbdOilPressLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStbdOilPressLow.Font = new System.Drawing.Font("Arial", 14F);
            this.lblStbdOilPressLow.ForeColor = System.Drawing.Color.Black;
            this.lblStbdOilPressLow.Location = new System.Drawing.Point(1060, 295);
            this.lblStbdOilPressLow.Name = "lblStbdOilPressLow";
            this.lblStbdOilPressLow.Size = new System.Drawing.Size(69, 25);
            this.lblStbdOilPressLow.TabIndex = 127;
            this.lblStbdOilPressLow.Text = "LOW";
            this.lblStbdOilPressLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStbdFuelPressLow
            // 
            this.lblStbdFuelPressLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStbdFuelPressLow.Font = new System.Drawing.Font("Arial", 14F);
            this.lblStbdFuelPressLow.ForeColor = System.Drawing.Color.Black;
            this.lblStbdFuelPressLow.Location = new System.Drawing.Point(229, 498);
            this.lblStbdFuelPressLow.Name = "lblStbdFuelPressLow";
            this.lblStbdFuelPressLow.Size = new System.Drawing.Size(173, 25);
            this.lblStbdFuelPressLow.TabIndex = 126;
            this.lblStbdFuelPressLow.Text = "FUEL PRESSURE";
            this.lblStbdFuelPressLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // lblStbdWaterTempHigh
            // 
            this.lblStbdWaterTempHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStbdWaterTempHigh.Font = new System.Drawing.Font("Arial", 14F);
            this.lblStbdWaterTempHigh.ForeColor = System.Drawing.Color.Black;
            this.lblStbdWaterTempHigh.Location = new System.Drawing.Point(713, 295);
            this.lblStbdWaterTempHigh.Name = "lblStbdWaterTempHigh";
            this.lblStbdWaterTempHigh.Size = new System.Drawing.Size(69, 25);
            this.lblStbdWaterTempHigh.TabIndex = 120;
            this.lblStbdWaterTempHigh.Text = "HIGH";
            this.lblStbdWaterTempHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gaugeStbdRpm
            // 
            this.gaugeStbdRpm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugeStbdRpm.ErrorLimit = 4000D;
            this.gaugeStbdRpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeStbdRpm.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.gaugeStbdRpm.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugeStbdRpm.Location = new System.Drawing.Point(38, 133);
            this.gaugeStbdRpm.Maximum = 4000D;
            this.gaugeStbdRpm.Name = "gaugeStbdRpm";
            this.gaugeStbdRpm.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugeStbdRpm.PointerWidth = 80;
            this.gaugeStbdRpm.ScaleFactor = 1D;
            this.gaugeStbdRpm.SegmentGap = 10;
            this.gaugeStbdRpm.Size = new System.Drawing.Size(555, 551);
            this.gaugeStbdRpm.TabIndex = 119;
            this.gaugeStbdRpm.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugeStbdRpm.Title = "";
            this.gaugeStbdRpm.Unit = "RPM";
            this.gaugeStbdRpm.UserDefinedColors.Base = themeColors1;
            themeColors2.PointerColor = System.Drawing.Color.Red;
            this.gaugeStbdRpm.UserDefinedColors.Error = themeColors2;
            themeColors3.PointerColor = System.Drawing.Color.Orange;
            this.gaugeStbdRpm.UserDefinedColors.Warning = themeColors3;
            this.gaugeStbdRpm.Value = 0D;
            this.gaugeStbdRpm.WarningLimit = 3800D;
            // 
            // gaugeStbdOilPressure
            // 
            this.gaugeStbdOilPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugeStbdOilPressure.ErrorLimit = 8D;
            this.gaugeStbdOilPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeStbdOilPressure.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeStbdOilPressure.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugeStbdOilPressure.InvertLimit = true;
            this.gaugeStbdOilPressure.Location = new System.Drawing.Point(943, 83);
            this.gaugeStbdOilPressure.Maximum = 120D;
            this.gaugeStbdOilPressure.Name = "gaugeStbdOilPressure";
            this.gaugeStbdOilPressure.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugeStbdOilPressure.PointerWidth = 40;
            this.gaugeStbdOilPressure.ScaleFactor = 1D;
            this.gaugeStbdOilPressure.SegmentGap = 10;
            this.gaugeStbdOilPressure.Size = new System.Drawing.Size(300, 300);
            this.gaugeStbdOilPressure.TabIndex = 118;
            this.gaugeStbdOilPressure.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugeStbdOilPressure.Title = "";
            this.gaugeStbdOilPressure.Unit = "OIL PSI";
            this.gaugeStbdOilPressure.Value = 0D;
            this.gaugeStbdOilPressure.WarningLimit = 15D;
            // 
            // gaugeStbdVolts
            // 
            this.gaugeStbdVolts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugeStbdVolts.ErrorLimit = 11.5D;
            this.gaugeStbdVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeStbdVolts.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeStbdVolts.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugeStbdVolts.InvertLimit = true;
            this.gaugeStbdVolts.Location = new System.Drawing.Point(599, 417);
            this.gaugeStbdVolts.Maximum = 15D;
            this.gaugeStbdVolts.Name = "gaugeStbdVolts";
            this.gaugeStbdVolts.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugeStbdVolts.PointerWidth = 40;
            this.gaugeStbdVolts.ScaleFactor = 1D;
            this.gaugeStbdVolts.SegmentGap = 10;
            this.gaugeStbdVolts.Size = new System.Drawing.Size(300, 300);
            this.gaugeStbdVolts.TabIndex = 117;
            this.gaugeStbdVolts.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugeStbdVolts.Title = "";
            this.gaugeStbdVolts.Unit = "DC VOLTS";
            this.gaugeStbdVolts.Value = 0D;
            this.gaugeStbdVolts.WarningLimit = 12.2D;
            // 
            // gaugeStbdDrivePressure
            // 
            this.gaugeStbdDrivePressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugeStbdDrivePressure.ErrorLimit = 30D;
            this.gaugeStbdDrivePressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeStbdDrivePressure.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeStbdDrivePressure.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugeStbdDrivePressure.InvertLimit = true;
            this.gaugeStbdDrivePressure.Location = new System.Drawing.Point(943, 417);
            this.gaugeStbdDrivePressure.Name = "gaugeStbdDrivePressure";
            this.gaugeStbdDrivePressure.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugeStbdDrivePressure.PointerWidth = 40;
            this.gaugeStbdDrivePressure.ScaleFactor = 1D;
            this.gaugeStbdDrivePressure.SegmentGap = 10;
            this.gaugeStbdDrivePressure.Size = new System.Drawing.Size(300, 300);
            this.gaugeStbdDrivePressure.TabIndex = 116;
            this.gaugeStbdDrivePressure.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugeStbdDrivePressure.Title = "";
            this.gaugeStbdDrivePressure.Unit = "GEAR PSI";
            this.gaugeStbdDrivePressure.Value = 0D;
            this.gaugeStbdDrivePressure.WarningLimit = 50D;
            // 
            // gaugeStbdWaterTemp
            // 
            this.gaugeStbdWaterTemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugeStbdWaterTemp.ErrorLimit = 190D;
            this.gaugeStbdWaterTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeStbdWaterTemp.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeStbdWaterTemp.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugeStbdWaterTemp.Location = new System.Drawing.Point(599, 83);
            this.gaugeStbdWaterTemp.Maximum = 220D;
            this.gaugeStbdWaterTemp.Name = "gaugeStbdWaterTemp";
            this.gaugeStbdWaterTemp.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugeStbdWaterTemp.PointerWidth = 40;
            this.gaugeStbdWaterTemp.ScaleFactor = 1D;
            this.gaugeStbdWaterTemp.SegmentGap = 10;
            this.gaugeStbdWaterTemp.Size = new System.Drawing.Size(300, 300);
            this.gaugeStbdWaterTemp.TabIndex = 115;
            this.gaugeStbdWaterTemp.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugeStbdWaterTemp.Title = "";
            this.gaugeStbdWaterTemp.Unit = "WATER °F";
            this.gaugeStbdWaterTemp.Value = 0D;
            this.gaugeStbdWaterTemp.WarningLimit = 185D;
            // 
            // lblFastPacketQueue
            // 
            this.lblFastPacketQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFastPacketQueue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFastPacketQueue.ForeColor = System.Drawing.Color.White;
            this.lblFastPacketQueue.Location = new System.Drawing.Point(164, 765);
            this.lblFastPacketQueue.Name = "lblFastPacketQueue";
            this.lblFastPacketQueue.Size = new System.Drawing.Size(92, 22);
            this.lblFastPacketQueue.TabIndex = 138;
            this.lblFastPacketQueue.Text = "--";
            this.lblFastPacketQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(18, 765);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(143, 22);
            this.label29.TabIndex = 137;
            this.label29.Text = "FAST PACKETS IN QUEUE: ";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCanMsgQueue
            // 
            this.lblCanMsgQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCanMsgQueue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanMsgQueue.ForeColor = System.Drawing.Color.White;
            this.lblCanMsgQueue.Location = new System.Drawing.Point(164, 737);
            this.lblCanMsgQueue.Name = "lblCanMsgQueue";
            this.lblCanMsgQueue.Size = new System.Drawing.Size(92, 22);
            this.lblCanMsgQueue.TabIndex = 136;
            this.lblCanMsgQueue.Text = "--";
            this.lblCanMsgQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(6, 737);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(155, 22);
            this.label25.TabIndex = 135;
            this.label25.Text = "CAN MESSAGES IN QUEUE: ";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastBusScan
            // 
            this.lblLastBusScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastBusScan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastBusScan.ForeColor = System.Drawing.Color.White;
            this.lblLastBusScan.Location = new System.Drawing.Point(164, 708);
            this.lblLastBusScan.Name = "lblLastBusScan";
            this.lblLastBusScan.Size = new System.Drawing.Size(92, 22);
            this.lblLastBusScan.TabIndex = 134;
            this.lblLastBusScan.Text = "--";
            this.lblLastBusScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(18, 708);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(143, 22);
            this.label32.TabIndex = 133;
            this.label32.Text = "LAST SCAN: ";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblJ1939BustStatus
            // 
            this.lblJ1939BustStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJ1939BustStatus.BackColor = System.Drawing.Color.Red;
            this.lblJ1939BustStatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJ1939BustStatus.ForeColor = System.Drawing.Color.White;
            this.lblJ1939BustStatus.Location = new System.Drawing.Point(164, 683);
            this.lblJ1939BustStatus.Name = "lblJ1939BustStatus";
            this.lblJ1939BustStatus.Size = new System.Drawing.Size(96, 22);
            this.lblJ1939BustStatus.TabIndex = 132;
            this.lblJ1939BustStatus.Text = "FAULTED";
            this.lblJ1939BustStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(15, 683);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(146, 22);
            this.label33.TabIndex = 131;
            this.label33.Text = "J1939 BUS STATUS: ";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StbdGauges
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.lblFastPacketQueue);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.lblCanMsgQueue);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.lblLastBusScan);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.lblJ1939BustStatus);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.lblStbdHours);
            this.Controls.Add(this.lblStbdDriveTempHigh);
            this.Controls.Add(this.lblStbdVoltageLow);
            this.Controls.Add(this.lblStbdOilPressLow);
            this.Controls.Add(this.lblStbdFuelPressLow);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblStbdWaterTempHigh);
            this.Controls.Add(this.gaugeStbdRpm);
            this.Controls.Add(this.gaugeStbdOilPressure);
            this.Controls.Add(this.gaugeStbdVolts);
            this.Controls.Add(this.gaugeStbdDrivePressure);
            this.Controls.Add(this.gaugeStbdWaterTemp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StbdGauges";
            this.Text = "StbdGauges";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStbdHours;
        private System.Windows.Forms.Label lblStbdDriveTempHigh;
        private System.Windows.Forms.Label lblStbdVoltageLow;
        private System.Windows.Forms.Label lblStbdOilPressLow;
        private System.Windows.Forms.Label lblStbdFuelPressLow;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStbdWaterTempHigh;
        private CodeArtEng.Gauge.CircularGauge gaugeStbdRpm;
        private CodeArtEng.Gauge.CircularGauge gaugeStbdOilPressure;
        private CodeArtEng.Gauge.CircularGauge gaugeStbdVolts;
        private CodeArtEng.Gauge.CircularGauge gaugeStbdDrivePressure;
        private CodeArtEng.Gauge.CircularGauge gaugeStbdWaterTemp;
        private System.Windows.Forms.Label lblFastPacketQueue;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lblCanMsgQueue;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblLastBusScan;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblJ1939BustStatus;
        private System.Windows.Forms.Label label33;
    }
}