namespace WhatTheHelmRuntime
{
    partial class Nmea2000Config
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
            this.cbOilPressureInstance = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbOilPressureSource = new System.Windows.Forms.ComboBox();
            this.cbEngineAlarmsInstance = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbEngineAlarmsSource = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRpmPgn = new System.Windows.Forms.ComboBox();
            this.cbWaterTempPgn = new System.Windows.Forms.ComboBox();
            this.cbEngineAlarmsPgn = new System.Windows.Forms.ComboBox();
            this.cbOilPressurePgn = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbHourMeterPgn = new System.Windows.Forms.ComboBox();
            this.cbHourMeterInstance = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbHourMeterSource = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbTransPressurePgn = new System.Windows.Forms.ComboBox();
            this.cbTransAlarmsPgn = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbTransPressureSource = new System.Windows.Forms.ComboBox();
            this.cbTransPressureInstance = new System.Windows.Forms.ComboBox();
            this.cbTransAlarmsSource = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbTransAlarmsInstance = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.btnRefreshDeviceList.Margin = new System.Windows.Forms.Padding(2);
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
            this.label1.Size = new System.Drawing.Size(1280, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "NMEA 2000 Configuration";
            // 
            // cbPortRpmSource
            // 
            this.cbRpmSource.BackColor = System.Drawing.Color.Black;
            this.cbRpmSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRpmSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRpmSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRpmSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbRpmSource.FormattingEnabled = true;
            this.cbRpmSource.Location = new System.Drawing.Point(269, 66);
            this.cbRpmSource.Name = "cbPortRpmSource";
            this.cbRpmSource.Size = new System.Drawing.Size(579, 33);
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
            this.listBox1.Size = new System.Drawing.Size(794, 100);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // cbPortRpmInstance
            // 
            this.cbRpmInstance.BackColor = System.Drawing.Color.Black;
            this.cbRpmInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRpmInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRpmInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRpmInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbRpmInstance.FormattingEnabled = true;
            this.cbRpmInstance.Location = new System.Drawing.Point(1020, 66);
            this.cbRpmInstance.Name = "cbPortRpmInstance";
            this.cbRpmInstance.Size = new System.Drawing.Size(106, 33);
            this.cbRpmInstance.TabIndex = 7;
            // 
            // cbPortWaterTempInstance
            // 
            this.cbWaterTempInstance.BackColor = System.Drawing.Color.Black;
            this.cbWaterTempInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWaterTempInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbWaterTempInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWaterTempInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbWaterTempInstance.FormattingEnabled = true;
            this.cbWaterTempInstance.Location = new System.Drawing.Point(1020, 104);
            this.cbWaterTempInstance.Name = "cbPortWaterTempInstance";
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
            // cbPortWaterTempSource
            // 
            this.cbWaterTempSource.BackColor = System.Drawing.Color.Black;
            this.cbWaterTempSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWaterTempSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbWaterTempSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWaterTempSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbWaterTempSource.FormattingEnabled = true;
            this.cbWaterTempSource.Location = new System.Drawing.Point(269, 104);
            this.cbWaterTempSource.Name = "cbPortWaterTempSource";
            this.cbWaterTempSource.Size = new System.Drawing.Size(579, 33);
            this.cbWaterTempSource.TabIndex = 9;
            // 
            // cbPortOilPressureInstance
            // 
            this.cbOilPressureInstance.BackColor = System.Drawing.Color.Black;
            this.cbOilPressureInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOilPressureInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOilPressureInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOilPressureInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbOilPressureInstance.FormattingEnabled = true;
            this.cbOilPressureInstance.Location = new System.Drawing.Point(1020, 142);
            this.cbOilPressureInstance.Name = "cbPortOilPressureInstance";
            this.cbOilPressureInstance.Size = new System.Drawing.Size(106, 33);
            this.cbOilPressureInstance.TabIndex = 15;
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
            // cbPortOilPressureSource
            // 
            this.cbOilPressureSource.BackColor = System.Drawing.Color.Black;
            this.cbOilPressureSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOilPressureSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOilPressureSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOilPressureSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbOilPressureSource.FormattingEnabled = true;
            this.cbOilPressureSource.Location = new System.Drawing.Point(269, 142);
            this.cbOilPressureSource.Name = "cbPortOilPressureSource";
            this.cbOilPressureSource.Size = new System.Drawing.Size(579, 33);
            this.cbOilPressureSource.TabIndex = 13;
            // 
            // cbPortEngineAlarmsInstance
            // 
            this.cbEngineAlarmsInstance.BackColor = System.Drawing.Color.Black;
            this.cbEngineAlarmsInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEngineAlarmsInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEngineAlarmsInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEngineAlarmsInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbEngineAlarmsInstance.FormattingEnabled = true;
            this.cbEngineAlarmsInstance.Location = new System.Drawing.Point(1020, 180);
            this.cbEngineAlarmsInstance.Name = "cbPortEngineAlarmsInstance";
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
            // cbPortEngineAlarmsSource
            // 
            this.cbEngineAlarmsSource.BackColor = System.Drawing.Color.Black;
            this.cbEngineAlarmsSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEngineAlarmsSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEngineAlarmsSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEngineAlarmsSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbEngineAlarmsSource.FormattingEnabled = true;
            this.cbEngineAlarmsSource.Location = new System.Drawing.Point(269, 180);
            this.cbEngineAlarmsSource.Name = "cbPortEngineAlarmsSource";
            this.cbEngineAlarmsSource.Size = new System.Drawing.Size(579, 33);
            this.cbEngineAlarmsSource.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbHourMeterPgn);
            this.groupBox1.Controls.Add(this.cbHourMeterInstance);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbHourMeterSource);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbRpmPgn);
            this.groupBox1.Controls.Add(this.cbWaterTempPgn);
            this.groupBox1.Controls.Add(this.cbEngineAlarmsPgn);
            this.groupBox1.Controls.Add(this.cbOilPressurePgn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbRpmSource);
            this.groupBox1.Controls.Add(this.cbRpmInstance);
            this.groupBox1.Controls.Add(this.cbWaterTempSource);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbWaterTempInstance);
            this.groupBox1.Controls.Add(this.cbOilPressureSource);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbEngineAlarmsInstance);
            this.groupBox1.Controls.Add(this.cbOilPressureInstance);
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
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(269, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(450, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "Source";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // cbPortRpmPgn
            // 
            this.cbRpmPgn.BackColor = System.Drawing.Color.Black;
            this.cbRpmPgn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRpmPgn.Enabled = false;
            this.cbRpmPgn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRpmPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRpmPgn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbRpmPgn.FormattingEnabled = true;
            this.cbRpmPgn.Location = new System.Drawing.Point(868, 66);
            this.cbRpmPgn.Name = "cbPortRpmPgn";
            this.cbRpmPgn.Size = new System.Drawing.Size(132, 33);
            this.cbRpmPgn.TabIndex = 27;
            // 
            // cbPortWaterTempPgn
            // 
            this.cbWaterTempPgn.BackColor = System.Drawing.Color.Black;
            this.cbWaterTempPgn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWaterTempPgn.Enabled = false;
            this.cbWaterTempPgn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbWaterTempPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWaterTempPgn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbWaterTempPgn.FormattingEnabled = true;
            this.cbWaterTempPgn.Location = new System.Drawing.Point(868, 104);
            this.cbWaterTempPgn.Name = "cbPortWaterTempPgn";
            this.cbWaterTempPgn.Size = new System.Drawing.Size(132, 33);
            this.cbWaterTempPgn.TabIndex = 28;
            // 
            // cbPortEngineAlarmsPgn
            // 
            this.cbEngineAlarmsPgn.BackColor = System.Drawing.Color.Black;
            this.cbEngineAlarmsPgn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEngineAlarmsPgn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEngineAlarmsPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEngineAlarmsPgn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbEngineAlarmsPgn.FormattingEnabled = true;
            this.cbEngineAlarmsPgn.Location = new System.Drawing.Point(868, 180);
            this.cbEngineAlarmsPgn.Name = "cbPortEngineAlarmsPgn";
            this.cbEngineAlarmsPgn.Size = new System.Drawing.Size(132, 33);
            this.cbEngineAlarmsPgn.TabIndex = 30;
            // 
            // cbPortOilPressurePgn
            // 
            this.cbOilPressurePgn.BackColor = System.Drawing.Color.Black;
            this.cbOilPressurePgn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOilPressurePgn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOilPressurePgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOilPressurePgn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbOilPressurePgn.FormattingEnabled = true;
            this.cbOilPressurePgn.Location = new System.Drawing.Point(868, 142);
            this.cbOilPressurePgn.Name = "cbPortOilPressurePgn";
            this.cbOilPressurePgn.Size = new System.Drawing.Size(132, 33);
            this.cbOilPressurePgn.TabIndex = 29;
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
            // cbPortHourMeterPgn
            // 
            this.cbHourMeterPgn.BackColor = System.Drawing.Color.Black;
            this.cbHourMeterPgn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHourMeterPgn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbHourMeterPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHourMeterPgn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbHourMeterPgn.FormattingEnabled = true;
            this.cbHourMeterPgn.Location = new System.Drawing.Point(868, 217);
            this.cbHourMeterPgn.Name = "cbPortHourMeterPgn";
            this.cbHourMeterPgn.Size = new System.Drawing.Size(132, 33);
            this.cbHourMeterPgn.TabIndex = 35;
            // 
            // cbPortHourMeterInstance
            // 
            this.cbHourMeterInstance.BackColor = System.Drawing.Color.Black;
            this.cbHourMeterInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHourMeterInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbHourMeterInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHourMeterInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbHourMeterInstance.FormattingEnabled = true;
            this.cbHourMeterInstance.Location = new System.Drawing.Point(1020, 217);
            this.cbHourMeterInstance.Name = "cbPortHourMeterInstance";
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
            // cbPortHourMeterSource
            // 
            this.cbHourMeterSource.BackColor = System.Drawing.Color.Black;
            this.cbHourMeterSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHourMeterSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbHourMeterSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHourMeterSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbHourMeterSource.FormattingEnabled = true;
            this.cbHourMeterSource.Location = new System.Drawing.Point(269, 217);
            this.cbHourMeterSource.Name = "cbPortHourMeterSource";
            this.cbHourMeterSource.Size = new System.Drawing.Size(579, 33);
            this.cbHourMeterSource.TabIndex = 32;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbTransPressurePgn);
            this.groupBox2.Controls.Add(this.cbTransAlarmsPgn);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cbTransPressureSource);
            this.groupBox2.Controls.Add(this.cbTransPressureInstance);
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
            // cbTransPressurePgn
            // 
            this.cbTransPressurePgn.BackColor = System.Drawing.Color.Black;
            this.cbTransPressurePgn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransPressurePgn.Enabled = false;
            this.cbTransPressurePgn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTransPressurePgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransPressurePgn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbTransPressurePgn.FormattingEnabled = true;
            this.cbTransPressurePgn.Location = new System.Drawing.Point(868, 66);
            this.cbTransPressurePgn.Name = "cbTransPressurePgn";
            this.cbTransPressurePgn.Size = new System.Drawing.Size(132, 33);
            this.cbTransPressurePgn.TabIndex = 27;
            // 
            // cbTransAlarmsPgn
            // 
            this.cbTransAlarmsPgn.BackColor = System.Drawing.Color.Black;
            this.cbTransAlarmsPgn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransAlarmsPgn.Enabled = false;
            this.cbTransAlarmsPgn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTransAlarmsPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransAlarmsPgn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbTransAlarmsPgn.FormattingEnabled = true;
            this.cbTransAlarmsPgn.Location = new System.Drawing.Point(868, 104);
            this.cbTransAlarmsPgn.Name = "cbTransAlarmsPgn";
            this.cbTransAlarmsPgn.Size = new System.Drawing.Size(132, 33);
            this.cbTransAlarmsPgn.TabIndex = 28;
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
            // cbTransPressureSource
            // 
            this.cbTransPressureSource.BackColor = System.Drawing.Color.Black;
            this.cbTransPressureSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransPressureSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTransPressureSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransPressureSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbTransPressureSource.FormattingEnabled = true;
            this.cbTransPressureSource.Location = new System.Drawing.Point(269, 66);
            this.cbTransPressureSource.Name = "cbTransPressureSource";
            this.cbTransPressureSource.Size = new System.Drawing.Size(579, 33);
            this.cbTransPressureSource.TabIndex = 2;
            // 
            // cbTransPressureInstance
            // 
            this.cbTransPressureInstance.BackColor = System.Drawing.Color.Black;
            this.cbTransPressureInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransPressureInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTransPressureInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransPressureInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbTransPressureInstance.FormattingEnabled = true;
            this.cbTransPressureInstance.Location = new System.Drawing.Point(1020, 66);
            this.cbTransPressureInstance.Name = "cbTransPressureInstance";
            this.cbTransPressureInstance.Size = new System.Drawing.Size(106, 33);
            this.cbTransPressureInstance.TabIndex = 7;
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
            this.cbTransAlarmsSource.Size = new System.Drawing.Size(579, 33);
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
            this.cbBatteryVoltagePgn.Enabled = false;
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
            this.cbBatteryVoltageSource.Size = new System.Drawing.Size(579, 33);
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
            this.btnDeviceListScrollUp.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnDeviceListScrollDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeviceListScrollDown.Name = "btnDeviceListScrollDown";
            this.btnDeviceListScrollDown.Size = new System.Drawing.Size(186, 58);
            this.btnDeviceListScrollDown.TabIndex = 40;
            this.btnDeviceListScrollDown.TabStop = false;
            this.btnDeviceListScrollDown.Text = "Next Page";
            this.btnDeviceListScrollDown.UseVisualStyleBackColor = true;
            this.btnDeviceListScrollDown.Click += new System.EventHandler(this.btnDeviceListScrollDown_Click);
            // 
            // Nmea2000Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Nmea2000Config";
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
        private System.Windows.Forms.ComboBox cbOilPressureInstance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbOilPressureSource;
        private System.Windows.Forms.ComboBox cbEngineAlarmsInstance;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbEngineAlarmsSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRpmPgn;
        private System.Windows.Forms.ComboBox cbWaterTempPgn;
        private System.Windows.Forms.ComboBox cbEngineAlarmsPgn;
        private System.Windows.Forms.ComboBox cbOilPressurePgn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbHourMeterPgn;
        private System.Windows.Forms.ComboBox cbHourMeterInstance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbHourMeterSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbTransPressurePgn;
        private System.Windows.Forms.ComboBox cbTransAlarmsPgn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbTransPressureSource;
        private System.Windows.Forms.ComboBox cbTransPressureInstance;
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
    }
}