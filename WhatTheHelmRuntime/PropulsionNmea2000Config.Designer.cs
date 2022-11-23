namespace WhatTheHelmRuntime
{
    partial class PropulsionNmea2000Config
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
            this.btnRefreshDeviceList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRpmSource = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cbRpmInstance = new System.Windows.Forms.ComboBox();
            this.cbWaterTempInstance = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbWaterTempSource = new System.Windows.Forms.ComboBox();
            this.cbOilPressInstance = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbOilPressSource = new System.Windows.Forms.ComboBox();
            this.cbEngineAlarmsInstance = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbEngineAlarmsSource = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEngineAlarmsPgn = new System.Windows.Forms.Label();
            this.lblEngineHoursPgn = new System.Windows.Forms.Label();
            this.lblOilPressPgn = new System.Windows.Forms.Label();
            this.lblWaterTempPgn = new System.Windows.Forms.Label();
            this.lblRpmPgn = new System.Windows.Forms.Label();
            this.cbHourMeterSerial = new System.Windows.Forms.ComboBox();
            this.cbEngineAlarmsSerial = new System.Windows.Forms.ComboBox();
            this.cbOilPressSerial = new System.Windows.Forms.ComboBox();
            this.cbWaterTempSerial = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbRpmSourceSerial = new System.Windows.Forms.ComboBox();
            this.cbHourMeterInstance = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbHourMeterSource = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTransAlarmsSerial = new System.Windows.Forms.ComboBox();
            this.lblTransAlarmsPgn = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cbTransPressSerial = new System.Windows.Forms.ComboBox();
            this.lblTransPressPgn = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbTransPressSource = new System.Windows.Forms.ComboBox();
            this.cbTransPressInstance = new System.Windows.Forms.ComboBox();
            this.cbTransAlarmsSource = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbTransAlarmsInstance = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cbBatteryVoltageSerial = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbBatteryVoltagePgn = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cbBatteryVoltageSource = new System.Windows.Forms.ComboBox();
            this.cbBatteryVoltageInstance = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnDeviceListScrollUp = new System.Windows.Forms.Button();
            this.btnDeviceListScrollDown = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefreshDeviceList
            // 
            this.btnRefreshDeviceList.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.BlackButton;
            this.btnRefreshDeviceList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshDeviceList.FlatAppearance.BorderSize = 0;
            this.btnRefreshDeviceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshDeviceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshDeviceList.ForeColor = System.Drawing.Color.White;
            this.btnRefreshDeviceList.Location = new System.Drawing.Point(1022, 662);
            this.btnRefreshDeviceList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefreshDeviceList.Name = "btnRefreshDeviceList";
            this.btnRefreshDeviceList.Size = new System.Drawing.Size(222, 126);
            this.btnRefreshDeviceList.TabIndex = 0;
            this.btnRefreshDeviceList.TabStop = false;
            this.btnRefreshDeviceList.Text = "Refresh\r\nDevice List";
            this.btnRefreshDeviceList.UseVisualStyleBackColor = true;
            this.btnRefreshDeviceList.Click += new System.EventHandler(this.btnRefreshDeviceList_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1278, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "NMEA 2000 Configuration";
            // 
            // cbRpmSource
            // 
            this.cbRpmSource.BackColor = System.Drawing.Color.Black;
            this.cbRpmSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRpmSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRpmSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRpmSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbRpmSource.FormattingEnabled = true;
            this.cbRpmSource.Location = new System.Drawing.Point(269, 66);
            this.cbRpmSource.Name = "cbRpmSource";
            this.cbRpmSource.Size = new System.Drawing.Size(409, 33);
            this.cbRpmSource.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "RPM:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Enabled = false;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(33, 688);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(794, 50);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // cbRpmInstance
            // 
            this.cbRpmInstance.BackColor = System.Drawing.Color.Black;
            this.cbRpmInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRpmInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRpmInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRpmInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbRpmInstance.FormattingEnabled = true;
            this.cbRpmInstance.Location = new System.Drawing.Point(1020, 66);
            this.cbRpmInstance.Name = "cbRpmInstance";
            this.cbRpmInstance.Size = new System.Drawing.Size(106, 33);
            this.cbRpmInstance.TabIndex = 7;
            // 
            // cbWaterTempInstance
            // 
            this.cbWaterTempInstance.BackColor = System.Drawing.Color.Black;
            this.cbWaterTempInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWaterTempInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbWaterTempInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWaterTempInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbWaterTempInstance.FormattingEnabled = true;
            this.cbWaterTempInstance.Location = new System.Drawing.Point(1020, 104);
            this.cbWaterTempInstance.Name = "cbWaterTempInstance";
            this.cbWaterTempInstance.Size = new System.Drawing.Size(106, 33);
            this.cbWaterTempInstance.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Water Temperature:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbWaterTempSource
            // 
            this.cbWaterTempSource.BackColor = System.Drawing.Color.Black;
            this.cbWaterTempSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWaterTempSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbWaterTempSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWaterTempSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbWaterTempSource.FormattingEnabled = true;
            this.cbWaterTempSource.Location = new System.Drawing.Point(269, 104);
            this.cbWaterTempSource.Name = "cbWaterTempSource";
            this.cbWaterTempSource.Size = new System.Drawing.Size(409, 33);
            this.cbWaterTempSource.TabIndex = 9;
            // 
            // cbOilPressInstance
            // 
            this.cbOilPressInstance.BackColor = System.Drawing.Color.Black;
            this.cbOilPressInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOilPressInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOilPressInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOilPressInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbOilPressInstance.FormattingEnabled = true;
            this.cbOilPressInstance.Location = new System.Drawing.Point(1020, 142);
            this.cbOilPressInstance.Name = "cbOilPressInstance";
            this.cbOilPressInstance.Size = new System.Drawing.Size(106, 33);
            this.cbOilPressInstance.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(18, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(245, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Oil Pressure:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbOilPressSource
            // 
            this.cbOilPressSource.BackColor = System.Drawing.Color.Black;
            this.cbOilPressSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOilPressSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOilPressSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOilPressSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbOilPressSource.FormattingEnabled = true;
            this.cbOilPressSource.Location = new System.Drawing.Point(269, 142);
            this.cbOilPressSource.Name = "cbOilPressSource";
            this.cbOilPressSource.Size = new System.Drawing.Size(409, 33);
            this.cbOilPressSource.TabIndex = 13;
            // 
            // cbEngineAlarmsInstance
            // 
            this.cbEngineAlarmsInstance.BackColor = System.Drawing.Color.Black;
            this.cbEngineAlarmsInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEngineAlarmsInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEngineAlarmsInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEngineAlarmsInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbEngineAlarmsInstance.FormattingEnabled = true;
            this.cbEngineAlarmsInstance.Location = new System.Drawing.Point(1020, 180);
            this.cbEngineAlarmsInstance.Name = "cbEngineAlarmsInstance";
            this.cbEngineAlarmsInstance.Size = new System.Drawing.Size(106, 33);
            this.cbEngineAlarmsInstance.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(18, 182);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(245, 23);
            this.label11.TabIndex = 22;
            this.label11.Text = "Alarms:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbEngineAlarmsSource
            // 
            this.cbEngineAlarmsSource.BackColor = System.Drawing.Color.Black;
            this.cbEngineAlarmsSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEngineAlarmsSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEngineAlarmsSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEngineAlarmsSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbEngineAlarmsSource.FormattingEnabled = true;
            this.cbEngineAlarmsSource.Location = new System.Drawing.Point(269, 180);
            this.cbEngineAlarmsSource.Name = "cbEngineAlarmsSource";
            this.cbEngineAlarmsSource.Size = new System.Drawing.Size(409, 33);
            this.cbEngineAlarmsSource.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEngineAlarmsPgn);
            this.groupBox1.Controls.Add(this.lblEngineHoursPgn);
            this.groupBox1.Controls.Add(this.lblOilPressPgn);
            this.groupBox1.Controls.Add(this.lblWaterTempPgn);
            this.groupBox1.Controls.Add(this.lblRpmPgn);
            this.groupBox1.Controls.Add(this.cbHourMeterSerial);
            this.groupBox1.Controls.Add(this.cbEngineAlarmsSerial);
            this.groupBox1.Controls.Add(this.cbOilPressSerial);
            this.groupBox1.Controls.Add(this.cbWaterTempSerial);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.cbRpmSourceSerial);
            this.groupBox1.Controls.Add(this.cbHourMeterInstance);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbHourMeterSource);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbRpmSource);
            this.groupBox1.Controls.Add(this.cbRpmInstance);
            this.groupBox1.Controls.Add(this.cbWaterTempSource);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbWaterTempInstance);
            this.groupBox1.Controls.Add(this.cbOilPressSource);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbEngineAlarmsInstance);
            this.groupBox1.Controls.Add(this.cbOilPressInstance);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbEngineAlarmsSource);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(33, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1211, 280);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Engine";
            // 
            // lblEngineAlarmsPgn
            // 
            this.lblEngineAlarmsPgn.BackColor = System.Drawing.Color.Black;
            this.lblEngineAlarmsPgn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEngineAlarmsPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEngineAlarmsPgn.ForeColor = System.Drawing.Color.Gray;
            this.lblEngineAlarmsPgn.Location = new System.Drawing.Point(868, 180);
            this.lblEngineAlarmsPgn.Name = "lblEngineAlarmsPgn";
            this.lblEngineAlarmsPgn.Size = new System.Drawing.Size(132, 33);
            this.lblEngineAlarmsPgn.TabIndex = 46;
            this.lblEngineAlarmsPgn.Text = "127489";
            this.lblEngineAlarmsPgn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEngineHoursPgn
            // 
            this.lblEngineHoursPgn.BackColor = System.Drawing.Color.Black;
            this.lblEngineHoursPgn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEngineHoursPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEngineHoursPgn.ForeColor = System.Drawing.Color.Gray;
            this.lblEngineHoursPgn.Location = new System.Drawing.Point(868, 217);
            this.lblEngineHoursPgn.Name = "lblEngineHoursPgn";
            this.lblEngineHoursPgn.Size = new System.Drawing.Size(132, 33);
            this.lblEngineHoursPgn.TabIndex = 45;
            this.lblEngineHoursPgn.Text = "127489";
            this.lblEngineHoursPgn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOilPressPgn
            // 
            this.lblOilPressPgn.BackColor = System.Drawing.Color.Black;
            this.lblOilPressPgn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOilPressPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOilPressPgn.ForeColor = System.Drawing.Color.Gray;
            this.lblOilPressPgn.Location = new System.Drawing.Point(868, 142);
            this.lblOilPressPgn.Name = "lblOilPressPgn";
            this.lblOilPressPgn.Size = new System.Drawing.Size(132, 33);
            this.lblOilPressPgn.TabIndex = 44;
            this.lblOilPressPgn.Text = "127489";
            this.lblOilPressPgn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWaterTempPgn
            // 
            this.lblWaterTempPgn.BackColor = System.Drawing.Color.Black;
            this.lblWaterTempPgn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWaterTempPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterTempPgn.ForeColor = System.Drawing.Color.Gray;
            this.lblWaterTempPgn.Location = new System.Drawing.Point(868, 104);
            this.lblWaterTempPgn.Name = "lblWaterTempPgn";
            this.lblWaterTempPgn.Size = new System.Drawing.Size(132, 33);
            this.lblWaterTempPgn.TabIndex = 43;
            this.lblWaterTempPgn.Text = "127489";
            this.lblWaterTempPgn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRpmPgn
            // 
            this.lblRpmPgn.BackColor = System.Drawing.Color.Black;
            this.lblRpmPgn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRpmPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRpmPgn.ForeColor = System.Drawing.Color.Gray;
            this.lblRpmPgn.Location = new System.Drawing.Point(868, 65);
            this.lblRpmPgn.Name = "lblRpmPgn";
            this.lblRpmPgn.Size = new System.Drawing.Size(132, 33);
            this.lblRpmPgn.TabIndex = 42;
            this.lblRpmPgn.Text = "127488";
            this.lblRpmPgn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbHourMeterSerial
            // 
            this.cbHourMeterSerial.BackColor = System.Drawing.Color.Black;
            this.cbHourMeterSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHourMeterSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbHourMeterSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHourMeterSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbHourMeterSerial.FormattingEnabled = true;
            this.cbHourMeterSerial.Location = new System.Drawing.Point(683, 217);
            this.cbHourMeterSerial.Name = "cbHourMeterSerial";
            this.cbHourMeterSerial.Size = new System.Drawing.Size(165, 33);
            this.cbHourMeterSerial.TabIndex = 41;
            // 
            // cbEngineAlarmsSerial
            // 
            this.cbEngineAlarmsSerial.BackColor = System.Drawing.Color.Black;
            this.cbEngineAlarmsSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEngineAlarmsSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEngineAlarmsSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEngineAlarmsSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbEngineAlarmsSerial.FormattingEnabled = true;
            this.cbEngineAlarmsSerial.Location = new System.Drawing.Point(683, 180);
            this.cbEngineAlarmsSerial.Name = "cbEngineAlarmsSerial";
            this.cbEngineAlarmsSerial.Size = new System.Drawing.Size(165, 33);
            this.cbEngineAlarmsSerial.TabIndex = 40;
            // 
            // cbOilPressSerial
            // 
            this.cbOilPressSerial.BackColor = System.Drawing.Color.Black;
            this.cbOilPressSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOilPressSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOilPressSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOilPressSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbOilPressSerial.FormattingEnabled = true;
            this.cbOilPressSerial.Location = new System.Drawing.Point(683, 142);
            this.cbOilPressSerial.Name = "cbOilPressSerial";
            this.cbOilPressSerial.Size = new System.Drawing.Size(165, 33);
            this.cbOilPressSerial.TabIndex = 39;
            // 
            // cbWaterTempSerial
            // 
            this.cbWaterTempSerial.BackColor = System.Drawing.Color.Black;
            this.cbWaterTempSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWaterTempSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbWaterTempSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWaterTempSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbWaterTempSerial.FormattingEnabled = true;
            this.cbWaterTempSerial.Location = new System.Drawing.Point(683, 104);
            this.cbWaterTempSerial.Name = "cbWaterTempSerial";
            this.cbWaterTempSerial.Size = new System.Drawing.Size(165, 33);
            this.cbWaterTempSerial.TabIndex = 38;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(683, 31);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(164, 23);
            this.label20.TabIndex = 37;
            this.label20.Text = "Serial Number";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbRpmSourceSerial
            // 
            this.cbRpmSourceSerial.BackColor = System.Drawing.Color.Black;
            this.cbRpmSourceSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRpmSourceSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRpmSourceSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRpmSourceSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbRpmSourceSerial.FormattingEnabled = true;
            this.cbRpmSourceSerial.Location = new System.Drawing.Point(683, 65);
            this.cbRpmSourceSerial.Name = "cbRpmSourceSerial";
            this.cbRpmSourceSerial.Size = new System.Drawing.Size(165, 33);
            this.cbRpmSourceSerial.TabIndex = 36;
            // 
            // cbHourMeterInstance
            // 
            this.cbHourMeterInstance.BackColor = System.Drawing.Color.Black;
            this.cbHourMeterInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHourMeterInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbHourMeterInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHourMeterInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbHourMeterInstance.FormattingEnabled = true;
            this.cbHourMeterInstance.Location = new System.Drawing.Point(1020, 217);
            this.cbHourMeterInstance.Name = "cbHourMeterInstance";
            this.cbHourMeterInstance.Size = new System.Drawing.Size(106, 33);
            this.cbHourMeterInstance.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(18, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 23);
            this.label6.TabIndex = 33;
            this.label6.Text = "Hour Meter:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbHourMeterSource
            // 
            this.cbHourMeterSource.BackColor = System.Drawing.Color.Black;
            this.cbHourMeterSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHourMeterSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbHourMeterSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHourMeterSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbHourMeterSource.FormattingEnabled = true;
            this.cbHourMeterSource.Location = new System.Drawing.Point(269, 217);
            this.cbHourMeterSource.Name = "cbHourMeterSource";
            this.cbHourMeterSource.Size = new System.Drawing.Size(409, 33);
            this.cbHourMeterSource.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(868, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "PGN";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1020, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Instance";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(269, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(408, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "Source";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTransAlarmsSerial);
            this.groupBox2.Controls.Add(this.lblTransAlarmsPgn);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.cbTransPressSerial);
            this.groupBox2.Controls.Add(this.lblTransPressPgn);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cbTransPressSource);
            this.groupBox2.Controls.Add(this.cbTransPressInstance);
            this.groupBox2.Controls.Add(this.cbTransAlarmsSource);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cbTransAlarmsInstance);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(33, 347);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1211, 165);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transmission";
            // 
            // cbTransAlarmsSerial
            // 
            this.cbTransAlarmsSerial.BackColor = System.Drawing.Color.Black;
            this.cbTransAlarmsSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransAlarmsSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTransAlarmsSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransAlarmsSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbTransAlarmsSerial.FormattingEnabled = true;
            this.cbTransAlarmsSerial.Location = new System.Drawing.Point(684, 104);
            this.cbTransAlarmsSerial.Name = "cbTransAlarmsSerial";
            this.cbTransAlarmsSerial.Size = new System.Drawing.Size(165, 33);
            this.cbTransAlarmsSerial.TabIndex = 49;
            // 
            // lblTransAlarmsPgn
            // 
            this.lblTransAlarmsPgn.BackColor = System.Drawing.Color.Black;
            this.lblTransAlarmsPgn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTransAlarmsPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransAlarmsPgn.ForeColor = System.Drawing.Color.Gray;
            this.lblTransAlarmsPgn.Location = new System.Drawing.Point(868, 104);
            this.lblTransAlarmsPgn.Name = "lblTransAlarmsPgn";
            this.lblTransAlarmsPgn.Size = new System.Drawing.Size(132, 33);
            this.lblTransAlarmsPgn.TabIndex = 48;
            this.lblTransAlarmsPgn.Text = "127493";
            this.lblTransAlarmsPgn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(684, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(164, 23);
            this.label21.TabIndex = 48;
            this.label21.Text = "Serial Number";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTransPressSerial
            // 
            this.cbTransPressSerial.BackColor = System.Drawing.Color.Black;
            this.cbTransPressSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransPressSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTransPressSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransPressSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbTransPressSerial.FormattingEnabled = true;
            this.cbTransPressSerial.Location = new System.Drawing.Point(684, 66);
            this.cbTransPressSerial.Name = "cbTransPressSerial";
            this.cbTransPressSerial.Size = new System.Drawing.Size(165, 33);
            this.cbTransPressSerial.TabIndex = 47;
            // 
            // lblTransPressPgn
            // 
            this.lblTransPressPgn.BackColor = System.Drawing.Color.Black;
            this.lblTransPressPgn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTransPressPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransPressPgn.ForeColor = System.Drawing.Color.Gray;
            this.lblTransPressPgn.Location = new System.Drawing.Point(868, 66);
            this.lblTransPressPgn.Name = "lblTransPressPgn";
            this.lblTransPressPgn.Size = new System.Drawing.Size(132, 33);
            this.lblTransPressPgn.TabIndex = 47;
            this.lblTransPressPgn.Text = "127493";
            this.lblTransPressPgn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(868, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 23);
            this.label10.TabIndex = 31;
            this.label10.Text = "PGN";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(1020, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 23);
            this.label12.TabIndex = 26;
            this.label12.Text = "Instance";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(269, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(450, 23);
            this.label13.TabIndex = 25;
            this.label13.Text = "Source";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(18, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(245, 23);
            this.label14.TabIndex = 3;
            this.label14.Text = "Pressure:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTransPressSource
            // 
            this.cbTransPressSource.BackColor = System.Drawing.Color.Black;
            this.cbTransPressSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransPressSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTransPressSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransPressSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbTransPressSource.FormattingEnabled = true;
            this.cbTransPressSource.Location = new System.Drawing.Point(269, 66);
            this.cbTransPressSource.Name = "cbTransPressSource";
            this.cbTransPressSource.Size = new System.Drawing.Size(409, 33);
            this.cbTransPressSource.TabIndex = 2;
            // 
            // cbTransPressInstance
            // 
            this.cbTransPressInstance.BackColor = System.Drawing.Color.Black;
            this.cbTransPressInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransPressInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTransPressInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransPressInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbTransPressInstance.FormattingEnabled = true;
            this.cbTransPressInstance.Location = new System.Drawing.Point(1020, 66);
            this.cbTransPressInstance.Name = "cbTransPressInstance";
            this.cbTransPressInstance.Size = new System.Drawing.Size(106, 33);
            this.cbTransPressInstance.TabIndex = 7;
            // 
            // cbTransAlarmsSource
            // 
            this.cbTransAlarmsSource.BackColor = System.Drawing.Color.Black;
            this.cbTransAlarmsSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransAlarmsSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTransAlarmsSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransAlarmsSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbTransAlarmsSource.FormattingEnabled = true;
            this.cbTransAlarmsSource.Location = new System.Drawing.Point(269, 104);
            this.cbTransAlarmsSource.Name = "cbTransAlarmsSource";
            this.cbTransAlarmsSource.Size = new System.Drawing.Size(409, 33);
            this.cbTransAlarmsSource.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(18, 106);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(245, 23);
            this.label15.TabIndex = 10;
            this.label15.Text = "Alarms:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTransAlarmsInstance
            // 
            this.cbTransAlarmsInstance.BackColor = System.Drawing.Color.Black;
            this.cbTransAlarmsInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransAlarmsInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTransAlarmsInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransAlarmsInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbTransAlarmsInstance.FormattingEnabled = true;
            this.cbTransAlarmsInstance.Location = new System.Drawing.Point(1020, 104);
            this.cbTransAlarmsInstance.Name = "cbTransAlarmsInstance";
            this.cbTransAlarmsInstance.Size = new System.Drawing.Size(106, 33);
            this.cbTransAlarmsInstance.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.cbBatteryVoltageSerial);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cbBatteryVoltagePgn);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.cbBatteryVoltageSource);
            this.groupBox3.Controls.Add(this.cbBatteryVoltageInstance);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(33, 529);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1211, 124);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Battery";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(685, 31);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(164, 23);
            this.label22.TabIndex = 51;
            this.label22.Text = "Serial Number";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbBatteryVoltageSerial
            // 
            this.cbBatteryVoltageSerial.BackColor = System.Drawing.Color.Black;
            this.cbBatteryVoltageSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatteryVoltageSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBatteryVoltageSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBatteryVoltageSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbBatteryVoltageSerial.FormattingEnabled = true;
            this.cbBatteryVoltageSerial.Location = new System.Drawing.Point(685, 66);
            this.cbBatteryVoltageSerial.Name = "cbBatteryVoltageSerial";
            this.cbBatteryVoltageSerial.Size = new System.Drawing.Size(165, 33);
            this.cbBatteryVoltageSerial.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(868, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 23);
            this.label9.TabIndex = 31;
            this.label9.Text = "PGN";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbBatteryVoltagePgn
            // 
            this.cbBatteryVoltagePgn.BackColor = System.Drawing.Color.Black;
            this.cbBatteryVoltagePgn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatteryVoltagePgn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBatteryVoltagePgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBatteryVoltagePgn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbBatteryVoltagePgn.FormattingEnabled = true;
            this.cbBatteryVoltagePgn.Location = new System.Drawing.Point(868, 66);
            this.cbBatteryVoltagePgn.Name = "cbBatteryVoltagePgn";
            this.cbBatteryVoltagePgn.Size = new System.Drawing.Size(132, 33);
            this.cbBatteryVoltagePgn.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(1020, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 23);
            this.label16.TabIndex = 26;
            this.label16.Text = "Instance";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(269, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(450, 23);
            this.label17.TabIndex = 25;
            this.label17.Text = "Source";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(18, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(245, 31);
            this.label18.TabIndex = 3;
            this.label18.Text = "Voltage:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbBatteryVoltageSource
            // 
            this.cbBatteryVoltageSource.BackColor = System.Drawing.Color.Black;
            this.cbBatteryVoltageSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatteryVoltageSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBatteryVoltageSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBatteryVoltageSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbBatteryVoltageSource.FormattingEnabled = true;
            this.cbBatteryVoltageSource.Location = new System.Drawing.Point(269, 66);
            this.cbBatteryVoltageSource.Name = "cbBatteryVoltageSource";
            this.cbBatteryVoltageSource.Size = new System.Drawing.Size(409, 33);
            this.cbBatteryVoltageSource.TabIndex = 2;
            // 
            // cbBatteryVoltageInstance
            // 
            this.cbBatteryVoltageInstance.BackColor = System.Drawing.Color.Black;
            this.cbBatteryVoltageInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatteryVoltageInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBatteryVoltageInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBatteryVoltageInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbBatteryVoltageInstance.FormattingEnabled = true;
            this.cbBatteryVoltageInstance.Location = new System.Drawing.Point(1020, 66);
            this.cbBatteryVoltageInstance.Name = "cbBatteryVoltageInstance";
            this.cbBatteryVoltageInstance.Size = new System.Drawing.Size(106, 33);
            this.cbBatteryVoltageInstance.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(33, 662);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(794, 23);
            this.label19.TabIndex = 38;
            this.label19.Text = "Connected Devices:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDeviceListScrollUp
            // 
            this.btnDeviceListScrollUp.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.BlackButton;
            this.btnDeviceListScrollUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeviceListScrollUp.FlatAppearance.BorderSize = 0;
            this.btnDeviceListScrollUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeviceListScrollUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeviceListScrollUp.ForeColor = System.Drawing.Color.White;
            this.btnDeviceListScrollUp.Location = new System.Drawing.Point(832, 662);
            this.btnDeviceListScrollUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeviceListScrollUp.Name = "btnDeviceListScrollUp";
            this.btnDeviceListScrollUp.Size = new System.Drawing.Size(186, 58);
            this.btnDeviceListScrollUp.TabIndex = 39;
            this.btnDeviceListScrollUp.TabStop = false;
            this.btnDeviceListScrollUp.Text = "Previous Page";
            this.btnDeviceListScrollUp.UseVisualStyleBackColor = true;
            this.btnDeviceListScrollUp.Click += new System.EventHandler(this.btnDeviceListScrollUp_Click);
            // 
            // btnDeviceListScrollDown
            // 
            this.btnDeviceListScrollDown.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.BlackButton;
            this.btnDeviceListScrollDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeviceListScrollDown.FlatAppearance.BorderSize = 0;
            this.btnDeviceListScrollDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeviceListScrollDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeviceListScrollDown.ForeColor = System.Drawing.Color.White;
            this.btnDeviceListScrollDown.Location = new System.Drawing.Point(832, 730);
            this.btnDeviceListScrollDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeviceListScrollDown.Name = "btnDeviceListScrollDown";
            this.btnDeviceListScrollDown.Size = new System.Drawing.Size(186, 58);
            this.btnDeviceListScrollDown.TabIndex = 40;
            this.btnDeviceListScrollDown.TabStop = false;
            this.btnDeviceListScrollDown.Text = "Next Page";
            this.btnDeviceListScrollDown.UseVisualStyleBackColor = true;
            this.btnDeviceListScrollDown.Click += new System.EventHandler(this.btnDeviceListScrollDown_Click);
            // 
            // PropulsionNmea2000Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1278, 718);
            this.Controls.Add(this.btnDeviceListScrollDown);
            this.Controls.Add(this.btnDeviceListScrollUp);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefreshDeviceList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PropulsionNmea2000Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NMEA 2000 Configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshDeviceList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRpmSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cbRpmInstance;
        private System.Windows.Forms.ComboBox cbWaterTempInstance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbWaterTempSource;
        private System.Windows.Forms.ComboBox cbOilPressInstance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbOilPressSource;
        private System.Windows.Forms.ComboBox cbEngineAlarmsInstance;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbEngineAlarmsSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbHourMeterInstance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbHourMeterSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbTransPressSource;
        private System.Windows.Forms.ComboBox cbTransPressInstance;
        private System.Windows.Forms.ComboBox cbTransAlarmsSource;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbTransAlarmsInstance;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbBatteryVoltagePgn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbBatteryVoltageSource;
        private System.Windows.Forms.ComboBox cbBatteryVoltageInstance;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnDeviceListScrollUp;
        private System.Windows.Forms.Button btnDeviceListScrollDown;
        private System.Windows.Forms.ComboBox cbHourMeterSerial;
        private System.Windows.Forms.ComboBox cbEngineAlarmsSerial;
        private System.Windows.Forms.ComboBox cbOilPressSerial;
        private System.Windows.Forms.ComboBox cbWaterTempSerial;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblRpmPgn;
        private System.Windows.Forms.ComboBox cbRpmSourceSerial;
        private System.Windows.Forms.Label lblOilPressPgn;
        private System.Windows.Forms.Label lblWaterTempPgn;
        private System.Windows.Forms.Label lblEngineHoursPgn;
        private System.Windows.Forms.Label lblEngineAlarmsPgn;
        private System.Windows.Forms.Label lblTransPressPgn;
        private System.Windows.Forms.Label lblTransAlarmsPgn;
        private System.Windows.Forms.ComboBox cbTransAlarmsSerial;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbTransPressSerial;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cbBatteryVoltageSerial;
    }
}