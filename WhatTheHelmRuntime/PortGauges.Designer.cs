namespace Dashboard
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
            CodeArtEng.Gauge.Themes.ThemeColors themeColors1 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors2 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors3 = new CodeArtEng.Gauge.Themes.ThemeColors();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSeaWaterDepth = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblSeaWaterTemp = new System.Windows.Forms.Label();
            this.pnlPower = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.lblPortRpm = new System.Windows.Forms.Label();
            this.lblPortHours = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblLocalTime = new System.Windows.Forms.Label();
            this.lblGpsCoordinates = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPortFuelPressLow = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPortDriveTempHigh = new System.Windows.Forms.Label();
            this.lblPortVoltageLow = new System.Windows.Forms.Label();
            this.lblPortDrivePressure = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblPortVolts = new System.Windows.Forms.Label();
            this.lblPortOilPressLow = new System.Windows.Forms.Label();
            this.lblPortOilPressure = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblPortWaterTempHigh = new System.Windows.Forms.Label();
            this.lblPortWaterTemp = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gaugePortRpm = new CodeArtEng.Gauge.CircularGauge();
            this.circularGauge1 = new CodeArtEng.Gauge.CircularGauge();
            this.pnlPower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Arial", 14F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(232, 260);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 52);
            this.label12.TabIndex = 65;
            this.label12.Text = "DEPTH IN FEET";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSeaWaterDepth
            // 
            this.lblSeaWaterDepth.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeaWaterDepth.ForeColor = System.Drawing.Color.White;
            this.lblSeaWaterDepth.Location = new System.Drawing.Point(232, 199);
            this.lblSeaWaterDepth.Name = "lblSeaWaterDepth";
            this.lblSeaWaterDepth.Size = new System.Drawing.Size(150, 57);
            this.lblSeaWaterDepth.TabIndex = 66;
            this.lblSeaWaterDepth.Text = "--";
            this.lblSeaWaterDepth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Arial", 14F);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(249, 370);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(118, 52);
            this.label18.TabIndex = 70;
            this.label18.Text = "WATER\r\n°F";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSeaWaterTemp
            // 
            this.lblSeaWaterTemp.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeaWaterTemp.ForeColor = System.Drawing.Color.White;
            this.lblSeaWaterTemp.Location = new System.Drawing.Point(249, 309);
            this.lblSeaWaterTemp.Name = "lblSeaWaterTemp";
            this.lblSeaWaterTemp.Size = new System.Drawing.Size(118, 57);
            this.lblSeaWaterTemp.TabIndex = 71;
            this.lblSeaWaterTemp.Text = "--";
            this.lblSeaWaterTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPower
            // 
            this.pnlPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.pnlPower.Controls.Add(this.circularGauge1);
            this.pnlPower.Controls.Add(this.gaugePortRpm);
            this.pnlPower.Controls.Add(this.btnConfig);
            this.pnlPower.Controls.Add(this.lblPortRpm);
            this.pnlPower.Controls.Add(this.lblPortHours);
            this.pnlPower.Controls.Add(this.btnExit);
            this.pnlPower.Controls.Add(this.lblLocalTime);
            this.pnlPower.Controls.Add(this.lblGpsCoordinates);
            this.pnlPower.Controls.Add(this.lblSeaWaterTemp);
            this.pnlPower.Controls.Add(this.label18);
            this.pnlPower.Controls.Add(this.lblSeaWaterDepth);
            this.pnlPower.Controls.Add(this.label12);
            this.pnlPower.Controls.Add(this.pictureBox1);
            this.pnlPower.Controls.Add(this.label13);
            this.pnlPower.Controls.Add(this.label5);
            this.pnlPower.Controls.Add(this.label23);
            this.pnlPower.Location = new System.Drawing.Point(157, 13);
            this.pnlPower.Name = "pnlPower";
            this.pnlPower.Size = new System.Drawing.Size(964, 775);
            this.pnlPower.TabIndex = 2;
            // 
            // btnConfig
            // 
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.ForeColor = System.Drawing.Color.White;
            this.btnConfig.Location = new System.Drawing.Point(11, 530);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 36);
            this.btnConfig.TabIndex = 117;
            this.btnConfig.Text = "CONFIG";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // lblPortRpm
            // 
            this.lblPortRpm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPortRpm.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortRpm.ForeColor = System.Drawing.Color.White;
            this.lblPortRpm.Location = new System.Drawing.Point(67, 403);
            this.lblPortRpm.Name = "lblPortRpm";
            this.lblPortRpm.Size = new System.Drawing.Size(112, 34);
            this.lblPortRpm.TabIndex = 115;
            this.lblPortRpm.Text = "--";
            this.lblPortRpm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortHours
            // 
            this.lblPortHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPortHours.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortHours.ForeColor = System.Drawing.Color.White;
            this.lblPortHours.Location = new System.Drawing.Point(67, 449);
            this.lblPortHours.Name = "lblPortHours";
            this.lblPortHours.Size = new System.Drawing.Size(151, 22);
            this.lblPortHours.TabIndex = 113;
            this.lblPortHours.Text = "--";
            this.lblPortHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(875, 724);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 36);
            this.btnExit.TabIndex = 112;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblLocalTime
            // 
            this.lblLocalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocalTime.Font = new System.Drawing.Font("Arial", 14F);
            this.lblLocalTime.ForeColor = System.Drawing.Color.White;
            this.lblLocalTime.Location = new System.Drawing.Point(15, 26);
            this.lblLocalTime.Name = "lblLocalTime";
            this.lblLocalTime.Size = new System.Drawing.Size(304, 27);
            this.lblLocalTime.TabIndex = 108;
            this.lblLocalTime.Text = "LOCAL TIME";
            this.lblLocalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGpsCoordinates
            // 
            this.lblGpsCoordinates.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGpsCoordinates.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGpsCoordinates.Location = new System.Drawing.Point(-21, 53);
            this.lblGpsCoordinates.Name = "lblGpsCoordinates";
            this.lblGpsCoordinates.Size = new System.Drawing.Size(340, 89);
            this.lblGpsCoordinates.TabIndex = 81;
            this.lblGpsCoordinates.Text = "LATITUDE: --\r\nLONGITUDE: --\r\nALTITUDE: --";
            this.lblGpsCoordinates.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(258, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 83);
            this.pictureBox1.TabIndex = 69;
            this.pictureBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(241, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 57);
            this.label13.TabIndex = 110;
            this.label13.Text = "--";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(700, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 57);
            this.label5.TabIndex = 98;
            this.label5.Text = "--";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(241, 436);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(136, 57);
            this.label23.TabIndex = 111;
            this.label23.Text = "--";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblPortFuelPressLow);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.lblPortDriveTempHigh);
            this.panel3.Controls.Add(this.lblPortVoltageLow);
            this.panel3.Controls.Add(this.lblPortDrivePressure);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.lblPortVolts);
            this.panel3.Controls.Add(this.lblPortOilPressLow);
            this.panel3.Controls.Add(this.lblPortOilPressure);
            this.panel3.Controls.Add(this.label28);
            this.panel3.Controls.Add(this.lblPortWaterTempHigh);
            this.panel3.Controls.Add(this.lblPortWaterTemp);
            this.panel3.Controls.Add(this.label31);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(7, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(144, 776);
            this.panel3.TabIndex = 99;
            // 
            // lblPortFuelPressLow
            // 
            this.lblPortFuelPressLow.BackColor = System.Drawing.Color.Maroon;
            this.lblPortFuelPressLow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPortFuelPressLow.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortFuelPressLow.ForeColor = System.Drawing.Color.Black;
            this.lblPortFuelPressLow.Location = new System.Drawing.Point(12, 674);
            this.lblPortFuelPressLow.Name = "lblPortFuelPressLow";
            this.lblPortFuelPressLow.Size = new System.Drawing.Size(116, 75);
            this.lblPortFuelPressLow.TabIndex = 97;
            this.lblPortFuelPressLow.Text = "FUEL\r\nPSI\r\nLOW";
            this.lblPortFuelPressLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 14F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 56);
            this.label10.TabIndex = 96;
            this.label10.Text = "PORT\r\nENGINE";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortDriveTempHigh
            // 
            this.lblPortDriveTempHigh.BackColor = System.Drawing.Color.Maroon;
            this.lblPortDriveTempHigh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPortDriveTempHigh.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortDriveTempHigh.ForeColor = System.Drawing.Color.Black;
            this.lblPortDriveTempHigh.Location = new System.Drawing.Point(36, 610);
            this.lblPortDriveTempHigh.Name = "lblPortDriveTempHigh";
            this.lblPortDriveTempHigh.Size = new System.Drawing.Size(69, 25);
            this.lblPortDriveTempHigh.TabIndex = 95;
            this.lblPortDriveTempHigh.Text = "TEMP";
            this.lblPortDriveTempHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortVoltageLow
            // 
            this.lblPortVoltageLow.BackColor = System.Drawing.Color.Maroon;
            this.lblPortVoltageLow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPortVoltageLow.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortVoltageLow.ForeColor = System.Drawing.Color.Black;
            this.lblPortVoltageLow.Location = new System.Drawing.Point(36, 470);
            this.lblPortVoltageLow.Name = "lblPortVoltageLow";
            this.lblPortVoltageLow.Size = new System.Drawing.Size(69, 25);
            this.lblPortVoltageLow.TabIndex = 82;
            this.lblPortVoltageLow.Text = "LOW";
            this.lblPortVoltageLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortDrivePressure
            // 
            this.lblPortDrivePressure.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortDrivePressure.ForeColor = System.Drawing.Color.White;
            this.lblPortDrivePressure.Location = new System.Drawing.Point(3, 507);
            this.lblPortDrivePressure.Name = "lblPortDrivePressure";
            this.lblPortDrivePressure.Size = new System.Drawing.Size(136, 57);
            this.lblPortDrivePressure.TabIndex = 94;
            this.lblPortDrivePressure.Text = "--";
            this.lblPortDrivePressure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Arial", 14F);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(12, 568);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 32);
            this.label19.TabIndex = 93;
            this.label19.Text = "DRIVE PSI";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Arial", 14F);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(15, 428);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(110, 32);
            this.label21.TabIndex = 80;
            this.label21.Text = "VOLTS";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortVolts
            // 
            this.lblPortVolts.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortVolts.ForeColor = System.Drawing.Color.White;
            this.lblPortVolts.Location = new System.Drawing.Point(3, 367);
            this.lblPortVolts.Name = "lblPortVolts";
            this.lblPortVolts.Size = new System.Drawing.Size(136, 57);
            this.lblPortVolts.TabIndex = 81;
            this.lblPortVolts.Text = "--";
            this.lblPortVolts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortOilPressLow
            // 
            this.lblPortOilPressLow.BackColor = System.Drawing.Color.Maroon;
            this.lblPortOilPressLow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPortOilPressLow.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortOilPressLow.ForeColor = System.Drawing.Color.Black;
            this.lblPortOilPressLow.Location = new System.Drawing.Point(36, 322);
            this.lblPortOilPressLow.Name = "lblPortOilPressLow";
            this.lblPortOilPressLow.Size = new System.Drawing.Size(69, 25);
            this.lblPortOilPressLow.TabIndex = 79;
            this.lblPortOilPressLow.Text = "LOW";
            this.lblPortOilPressLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortOilPressure
            // 
            this.lblPortOilPressure.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortOilPressure.ForeColor = System.Drawing.Color.White;
            this.lblPortOilPressure.Location = new System.Drawing.Point(3, 219);
            this.lblPortOilPressure.Name = "lblPortOilPressure";
            this.lblPortOilPressure.Size = new System.Drawing.Size(136, 57);
            this.lblPortOilPressure.TabIndex = 78;
            this.lblPortOilPressure.Text = "--";
            this.lblPortOilPressure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Arial", 14F);
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(20, 280);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(101, 32);
            this.label28.TabIndex = 77;
            this.label28.Text = "OIL PSI";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortWaterTempHigh
            // 
            this.lblPortWaterTempHigh.BackColor = System.Drawing.Color.Maroon;
            this.lblPortWaterTempHigh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPortWaterTempHigh.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPortWaterTempHigh.ForeColor = System.Drawing.Color.Black;
            this.lblPortWaterTempHigh.Location = new System.Drawing.Point(36, 174);
            this.lblPortWaterTempHigh.Name = "lblPortWaterTempHigh";
            this.lblPortWaterTempHigh.Size = new System.Drawing.Size(69, 25);
            this.lblPortWaterTempHigh.TabIndex = 76;
            this.lblPortWaterTempHigh.Text = "HIGH";
            this.lblPortWaterTempHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPortWaterTemp
            // 
            this.lblPortWaterTemp.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortWaterTemp.ForeColor = System.Drawing.Color.White;
            this.lblPortWaterTemp.Location = new System.Drawing.Point(3, 71);
            this.lblPortWaterTemp.Name = "lblPortWaterTemp";
            this.lblPortWaterTemp.Size = new System.Drawing.Size(136, 57);
            this.lblPortWaterTemp.TabIndex = 75;
            this.lblPortWaterTemp.Text = "--";
            this.lblPortWaterTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Arial", 14F);
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(14, 132);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(112, 32);
            this.label31.TabIndex = 74;
            this.label31.Text = "WATER °F";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 57);
            this.label1.TabIndex = 98;
            this.label1.Text = "--";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 57);
            this.label3.TabIndex = 99;
            this.label3.Text = "--";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 57);
            this.label4.TabIndex = 100;
            this.label4.Text = "--";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(2, 594);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 57);
            this.label11.TabIndex = 102;
            this.label11.Text = "--";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 684);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 57);
            this.label9.TabIndex = 103;
            this.label9.Text = "--";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gaugePortRpm
            // 
            this.gaugePortRpm.ErrorLimit = 3800D;
            this.gaugePortRpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugePortRpm.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugePortRpm.Location = new System.Drawing.Point(310, 43);
            this.gaugePortRpm.Maximum = 4000D;
            this.gaugePortRpm.Name = "gaugePortRpm";
            this.gaugePortRpm.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.gaugePortRpm.PointerWidth = 80;
            this.gaugePortRpm.ScaleFactor = 1D;
            this.gaugePortRpm.Size = new System.Drawing.Size(634, 639);
            this.gaugePortRpm.TabIndex = 118;
            this.gaugePortRpm.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.gaugePortRpm.Title = "";
            this.gaugePortRpm.Unit = "RPM";
            this.gaugePortRpm.Value = 3650D;
            this.gaugePortRpm.WarningLimit = 3600D;
            // 
            // circularGauge1
            // 
            this.circularGauge1.ErrorLimit = 5D;
            this.circularGauge1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularGauge1.FontTitle = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularGauge1.FontUnitLabel = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularGauge1.InvertLimit = true;
            this.circularGauge1.Location = new System.Drawing.Point(-5, 26);
            this.circularGauge1.Maximum = 100D;
            this.circularGauge1.Name = "circularGauge1";
            this.circularGauge1.PointerPaintMode = CodeArtEng.Gauge.PointerPaintMode.SimpleGradient;
            this.circularGauge1.PointerWidth = 40;
            this.circularGauge1.ScaleFactor = 1D;
            this.circularGauge1.Size = new System.Drawing.Size(257, 250);
            this.circularGauge1.TabIndex = 119;
            this.circularGauge1.Theme = CodeArtEng.Gauge.GaugeTheme.DarkGrey;
            this.circularGauge1.Title = "OIL";
            this.circularGauge1.Unit = "PSI";
            this.circularGauge1.UserDefinedColors.Base = themeColors1;
            themeColors2.PointerColor = System.Drawing.Color.Red;
            this.circularGauge1.UserDefinedColors.Error = themeColors2;
            themeColors3.PointerColor = System.Drawing.Color.Orange;
            this.circularGauge1.UserDefinedColors.Warning = themeColors3;
            this.circularGauge1.Value = 30D;
            this.circularGauge1.WarningLimit = 10D;
            // 
            // PortGauges
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlPower);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PortGauges";
            this.Text = "Gauges";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlPower.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblSeaWaterDepth;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblSeaWaterTemp;
        private System.Windows.Forms.Panel pnlPower;
        private System.Windows.Forms.Label lblGpsCoordinates;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPortFuelPressLow;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPortDriveTempHigh;
        private System.Windows.Forms.Label lblPortVoltageLow;
        private System.Windows.Forms.Label lblPortDrivePressure;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblPortVolts;
        private System.Windows.Forms.Label lblPortOilPressLow;
        private System.Windows.Forms.Label lblPortOilPressure;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblPortWaterTempHigh;
        private System.Windows.Forms.Label lblPortWaterTemp;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lblLocalTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblPortHours;
        private System.Windows.Forms.Label lblPortRpm;
        private System.Windows.Forms.Button btnConfig;
        private CodeArtEng.Gauge.CircularGauge gaugePortRpm;
        private CodeArtEng.Gauge.CircularGauge circularGauge1;
    }
}