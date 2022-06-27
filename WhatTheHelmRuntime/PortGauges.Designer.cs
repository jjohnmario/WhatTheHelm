
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
            CodeArtEng.Gauge.Themes.ThemeColors themeColors4 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors5 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors6 = new CodeArtEng.Gauge.Themes.ThemeColors();
            this.lblPortHours = new System.Windows.Forms.Label();
            this.lblPortDriveTempHigh = new System.Windows.Forms.Label();
            this.lblPortVoltageLow = new System.Windows.Forms.Label();
            this.lblPortOilPressLow = new System.Windows.Forms.Label();
            this.lblPortFuelPressLow = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPortWaterTempHigh = new System.Windows.Forms.Label();
            this.gaugePortRpm = new CodeArtEng.Gauge.CircularGauge();
            this.gaugePortOilPressure = new CodeArtEng.Gauge.CircularGauge();
            this.gaugePortVolts = new CodeArtEng.Gauge.CircularGauge();
            this.gaugePortDrivePressure = new CodeArtEng.Gauge.CircularGauge();
            this.gaugePortWaterTemp = new CodeArtEng.Gauge.CircularGauge();
            this.lblFastPacketQueue = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
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
            this.btnConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPortHours
            // 
            this.lblPortHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPortHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lblPortHours.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortHours.ForeColor = System.Drawing.Color.White;
            this.lblPortHours.Location = new System.Drawing.Point(890, 533);
            this.lblPortHours.Name = "lblPortHours";
            this.lblPortHours.Size = new System.Drawing.Size(151, 22);
            this.lblPortHours.TabIndex = 130;
            this.lblPortHours.Text = "--";
            this.lblPortHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortDriveTempHigh
            // 
            this.lblPortDriveTempHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPortDriveTempHigh.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortDriveTempHigh.ForeColor = System.Drawing.Color.Black;
            this.lblPortDriveTempHigh.Location = new System.Drawing.Point(152, 630);
            this.lblPortDriveTempHigh.Name = "lblPortDriveTempHigh";
            this.lblPortDriveTempHigh.Size = new System.Drawing.Size(69, 25);
            this.lblPortDriveTempHigh.TabIndex = 129;
            this.lblPortDriveTempHigh.Text = "TEMP";
            this.lblPortDriveTempHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortVoltageLow
            // 
            this.lblPortVoltageLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPortVoltageLow.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortVoltageLow.ForeColor = System.Drawing.Color.Black;
            this.lblPortVoltageLow.Location = new System.Drawing.Point(496, 630);
            this.lblPortVoltageLow.Name = "lblPortVoltageLow";
            this.lblPortVoltageLow.Size = new System.Drawing.Size(69, 25);
            this.lblPortVoltageLow.TabIndex = 128;
            this.lblPortVoltageLow.Text = "LOW";
            this.lblPortVoltageLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortOilPressLow
            // 
            this.lblPortOilPressLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPortOilPressLow.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortOilPressLow.ForeColor = System.Drawing.Color.Black;
            this.lblPortOilPressLow.Location = new System.Drawing.Point(152, 295);
            this.lblPortOilPressLow.Name = "lblPortOilPressLow";
            this.lblPortOilPressLow.Size = new System.Drawing.Size(69, 25);
            this.lblPortOilPressLow.TabIndex = 127;
            this.lblPortOilPressLow.Text = "LOW";
            this.lblPortOilPressLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortFuelPressLow
            // 
            this.lblPortFuelPressLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPortFuelPressLow.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortFuelPressLow.ForeColor = System.Drawing.Color.Black;
            this.lblPortFuelPressLow.Location = new System.Drawing.Point(878, 498);
            this.lblPortFuelPressLow.Name = "lblPortFuelPressLow";
            this.lblPortFuelPressLow.Size = new System.Drawing.Size(173, 25);
            this.lblPortFuelPressLow.TabIndex = 126;
            this.lblPortFuelPressLow.Text = "FUEL PRESSURE";
            this.lblPortFuelPressLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(123, 497);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(120, 20);
            this.panel5.TabIndex = 125;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(473, 497);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 20);
            this.panel4.TabIndex = 123;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(123, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 20);
            this.panel1.TabIndex = 124;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(474, 165);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(120, 20);
            this.panel3.TabIndex = 122;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(841, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 39);
            this.panel2.TabIndex = 121;
            // 
            // lblPortWaterTempHigh
            // 
            this.lblPortWaterTempHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPortWaterTempHigh.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortWaterTempHigh.ForeColor = System.Drawing.Color.Black;
            this.lblPortWaterTempHigh.Location = new System.Drawing.Point(497, 295);
            this.lblPortWaterTempHigh.Name = "lblPortWaterTempHigh";
            this.lblPortWaterTempHigh.Size = new System.Drawing.Size(69, 25);
            this.lblPortWaterTempHigh.TabIndex = 120;
            this.lblPortWaterTempHigh.Text = "HIGH";
            this.lblPortWaterTempHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gaugePortRpm
            // 
            this.gaugePortRpm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugePortRpm.ErrorLimit = 4000D;
            this.gaugePortRpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugePortRpm.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.gaugePortRpm.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugePortRpm.Location = new System.Drawing.Point(690, 133);
            this.gaugePortRpm.Maximum = 4000D;
            this.gaugePortRpm.Name = "gaugePortRpm";
            this.gaugePortRpm.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugePortRpm.PointerWidth = 80;
            this.gaugePortRpm.ScaleFactor = 1D;
            this.gaugePortRpm.SegmentGap = 10;
            this.gaugePortRpm.Size = new System.Drawing.Size(555, 551);
            this.gaugePortRpm.TabIndex = 119;
            this.gaugePortRpm.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugePortRpm.Title = "";
            this.gaugePortRpm.Unit = "RPM";
            this.gaugePortRpm.UserDefinedColors.Base = themeColors4;
            themeColors5.PointerColor = System.Drawing.Color.Red;
            this.gaugePortRpm.UserDefinedColors.Error = themeColors5;
            themeColors6.PointerColor = System.Drawing.Color.Orange;
            this.gaugePortRpm.UserDefinedColors.Warning = themeColors6;
            this.gaugePortRpm.Value = 0D;
            this.gaugePortRpm.WarningLimit = 3800D;
            // 
            // gaugePortOilPressure
            // 
            this.gaugePortOilPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugePortOilPressure.ErrorLimit = 8D;
            this.gaugePortOilPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugePortOilPressure.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugePortOilPressure.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugePortOilPressure.InvertLimit = true;
            this.gaugePortOilPressure.Location = new System.Drawing.Point(35, 83);
            this.gaugePortOilPressure.Maximum = 120D;
            this.gaugePortOilPressure.Name = "gaugePortOilPressure";
            this.gaugePortOilPressure.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugePortOilPressure.PointerWidth = 40;
            this.gaugePortOilPressure.ScaleFactor = 1D;
            this.gaugePortOilPressure.SegmentGap = 10;
            this.gaugePortOilPressure.Size = new System.Drawing.Size(300, 300);
            this.gaugePortOilPressure.TabIndex = 118;
            this.gaugePortOilPressure.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugePortOilPressure.Title = "";
            this.gaugePortOilPressure.Unit = "OIL PSI";
            this.gaugePortOilPressure.Value = 0D;
            this.gaugePortOilPressure.WarningLimit = 15D;
            // 
            // gaugePortVolts
            // 
            this.gaugePortVolts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugePortVolts.ErrorLimit = 11.5D;
            this.gaugePortVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugePortVolts.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugePortVolts.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugePortVolts.InvertLimit = true;
            this.gaugePortVolts.Location = new System.Drawing.Point(382, 417);
            this.gaugePortVolts.Maximum = 15D;
            this.gaugePortVolts.Name = "gaugePortVolts";
            this.gaugePortVolts.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugePortVolts.PointerWidth = 40;
            this.gaugePortVolts.ScaleFactor = 1D;
            this.gaugePortVolts.SegmentGap = 10;
            this.gaugePortVolts.Size = new System.Drawing.Size(300, 300);
            this.gaugePortVolts.TabIndex = 117;
            this.gaugePortVolts.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugePortVolts.Title = "";
            this.gaugePortVolts.Unit = "DC VOLTS";
            this.gaugePortVolts.Value = 0D;
            this.gaugePortVolts.WarningLimit = 12.2D;
            // 
            // gaugePortDrivePressure
            // 
            this.gaugePortDrivePressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugePortDrivePressure.ErrorLimit = 30D;
            this.gaugePortDrivePressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugePortDrivePressure.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugePortDrivePressure.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugePortDrivePressure.InvertLimit = true;
            this.gaugePortDrivePressure.Location = new System.Drawing.Point(35, 417);
            this.gaugePortDrivePressure.Name = "gaugePortDrivePressure";
            this.gaugePortDrivePressure.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugePortDrivePressure.PointerWidth = 40;
            this.gaugePortDrivePressure.ScaleFactor = 1D;
            this.gaugePortDrivePressure.SegmentGap = 10;
            this.gaugePortDrivePressure.Size = new System.Drawing.Size(300, 300);
            this.gaugePortDrivePressure.TabIndex = 116;
            this.gaugePortDrivePressure.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugePortDrivePressure.Title = "";
            this.gaugePortDrivePressure.Unit = "GEAR PSI";
            this.gaugePortDrivePressure.Value = 0D;
            this.gaugePortDrivePressure.WarningLimit = 50D;
            // 
            // gaugePortWaterTemp
            // 
            this.gaugePortWaterTemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.gaugePortWaterTemp.ErrorLimit = 190D;
            this.gaugePortWaterTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugePortWaterTemp.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugePortWaterTemp.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.MouseClick;
            this.gaugePortWaterTemp.Location = new System.Drawing.Point(383, 83);
            this.gaugePortWaterTemp.Maximum = 220D;
            this.gaugePortWaterTemp.Name = "gaugePortWaterTemp";
            this.gaugePortWaterTemp.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugePortWaterTemp.PointerWidth = 40;
            this.gaugePortWaterTemp.ScaleFactor = 1D;
            this.gaugePortWaterTemp.SegmentGap = 10;
            this.gaugePortWaterTemp.Size = new System.Drawing.Size(300, 300);
            this.gaugePortWaterTemp.TabIndex = 115;
            this.gaugePortWaterTemp.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugePortWaterTemp.Title = "";
            this.gaugePortWaterTemp.Unit = "WATER °F";
            this.gaugePortWaterTemp.Value = 0D;
            this.gaugePortWaterTemp.WarningLimit = 185D;
            // 
            // lblFastPacketQueue
            // 
            this.lblFastPacketQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFastPacketQueue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFastPacketQueue.ForeColor = System.Drawing.Color.White;
            this.lblFastPacketQueue.Location = new System.Drawing.Point(1154, 766);
            this.lblFastPacketQueue.Name = "lblFastPacketQueue";
            this.lblFastPacketQueue.Size = new System.Drawing.Size(93, 22);
            this.lblFastPacketQueue.TabIndex = 138;
            this.lblFastPacketQueue.Text = "--";
            this.lblFastPacketQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(1008, 766);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(144, 22);
            this.label29.TabIndex = 137;
            this.label29.Text = "FAST PACKETS IN QUEUE: ";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.label32.Text = "LAST SCAN: ";
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
            this.label33.Text = "J1939 BUS STATUS: ";
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
            this.btnExit.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(12, 736);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(116, 52);
            this.btnExit.TabIndex = 149;
            this.btnExit.Text = "EXIT...";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.ForeColor = System.Drawing.Color.White;
            this.btnConfig.Location = new System.Drawing.Point(134, 736);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(116, 52);
            this.btnConfig.TabIndex = 150;
            this.btnConfig.Text = "CONFIGURE...";
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // PortGauges
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblFastPacketQueue);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.lblCanMsgQueue);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.lblLastBusScan);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.lblJ1939BustStatus);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.lblPortHours);
            this.Controls.Add(this.lblPortDriveTempHigh);
            this.Controls.Add(this.lblPortVoltageLow);
            this.Controls.Add(this.lblPortOilPressLow);
            this.Controls.Add(this.lblPortFuelPressLow);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblPortWaterTempHigh);
            this.Controls.Add(this.gaugePortRpm);
            this.Controls.Add(this.gaugePortOilPressure);
            this.Controls.Add(this.gaugePortVolts);
            this.Controls.Add(this.gaugePortDrivePressure);
            this.Controls.Add(this.gaugePortWaterTemp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PortGauges";
            this.Text = "StbdGauges";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPortHours;
        private System.Windows.Forms.Label lblPortDriveTempHigh;
        private System.Windows.Forms.Label lblPortVoltageLow;
        private System.Windows.Forms.Label lblPortOilPressLow;
        private System.Windows.Forms.Label lblPortFuelPressLow;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPortWaterTempHigh;
        private CodeArtEng.Gauge.CircularGauge gaugePortRpm;
        private CodeArtEng.Gauge.CircularGauge gaugePortOilPressure;
        private CodeArtEng.Gauge.CircularGauge gaugePortVolts;
        private CodeArtEng.Gauge.CircularGauge gaugePortDrivePressure;
        private CodeArtEng.Gauge.CircularGauge gaugePortWaterTemp;
        private System.Windows.Forms.Label lblFastPacketQueue;
        private System.Windows.Forms.Label label29;
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
        private System.Windows.Forms.Button btnConfig;
    }
}