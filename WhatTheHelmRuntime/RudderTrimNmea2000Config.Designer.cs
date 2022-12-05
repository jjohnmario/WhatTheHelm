namespace WhatTheHelmRuntime
{
    partial class RudderTrimNmea2000Config
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
            this.lblWindowBanner = new System.Windows.Forms.Label();
            this.cbPortTrimSource = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbStbdTrimSource = new System.Windows.Forms.ComboBox();
            this.cbRudderInstance = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbRudderSource = new System.Windows.Forms.ComboBox();
            this.lblRudderPgn = new System.Windows.Forms.Label();
            this.lblStbdTrimPgn = new System.Windows.Forms.Label();
            this.lblPortTrimPgn = new System.Windows.Forms.Label();
            this.cbRudderSerial = new System.Windows.Forms.ComboBox();
            this.cbStbdTrimSerial = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbPortTrimSerial = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnDeviceListScrollUp = new System.Windows.Forms.Button();
            this.btnDeviceListScrollDown = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRefreshDeviceList
            // 
            this.btnRefreshDeviceList.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.BlackButton;
            this.btnRefreshDeviceList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshDeviceList.FlatAppearance.BorderSize = 0;
            this.btnRefreshDeviceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshDeviceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshDeviceList.ForeColor = System.Drawing.Color.White;
            this.btnRefreshDeviceList.Location = new System.Drawing.Point(484, 255);
            this.btnRefreshDeviceList.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshDeviceList.Name = "btnRefreshDeviceList";
            this.btnRefreshDeviceList.Size = new System.Drawing.Size(135, 78);
            this.btnRefreshDeviceList.TabIndex = 0;
            this.btnRefreshDeviceList.TabStop = false;
            this.btnRefreshDeviceList.Text = "Refresh\r\nDevice List";
            this.btnRefreshDeviceList.UseVisualStyleBackColor = true;
            this.btnRefreshDeviceList.Click += new System.EventHandler(this.btnRefreshDeviceList_Click);
            // 
            // lblWindowBanner
            // 
            this.lblWindowBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblWindowBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWindowBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowBanner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWindowBanner.Location = new System.Drawing.Point(0, 0);
            this.lblWindowBanner.Name = "lblWindowBanner";
            this.lblWindowBanner.Size = new System.Drawing.Size(800, 29);
            this.lblWindowBanner.TabIndex = 1;
            // 
            // cbPortTrimSource
            // 
            this.cbPortTrimSource.BackColor = System.Drawing.Color.Black;
            this.cbPortTrimSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPortTrimSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPortTrimSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPortTrimSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbPortTrimSource.FormattingEnabled = true;
            this.cbPortTrimSource.Location = new System.Drawing.Point(191, 90);
            this.cbPortTrimSource.Name = "cbPortTrimSource";
            this.cbPortTrimSource.Size = new System.Drawing.Size(265, 28);
            this.cbPortTrimSource.TabIndex = 2;
            this.cbPortTrimSource.SelectedIndexChanged += new System.EventHandler(this.cbRpmSource_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port Trim Tab Position:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Enabled = false;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(19, 280);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(453, 180);
            this.listBox1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Stbd Trim Tab Position:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbStbdTrimSource
            // 
            this.cbStbdTrimSource.BackColor = System.Drawing.Color.Black;
            this.cbStbdTrimSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStbdTrimSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbStbdTrimSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStbdTrimSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbStbdTrimSource.FormattingEnabled = true;
            this.cbStbdTrimSource.Location = new System.Drawing.Point(191, 128);
            this.cbStbdTrimSource.Name = "cbStbdTrimSource";
            this.cbStbdTrimSource.Size = new System.Drawing.Size(265, 28);
            this.cbStbdTrimSource.TabIndex = 9;
            this.cbStbdTrimSource.SelectedIndexChanged += new System.EventHandler(this.cbEngineTempSource_SelectedIndexChanged);
            // 
            // cbRudderInstance
            // 
            this.cbRudderInstance.BackColor = System.Drawing.Color.Black;
            this.cbRudderInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRudderInstance.Enabled = false;
            this.cbRudderInstance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRudderInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRudderInstance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbRudderInstance.FormattingEnabled = true;
            this.cbRudderInstance.Location = new System.Drawing.Point(706, 166);
            this.cbRudderInstance.Name = "cbRudderInstance";
            this.cbRudderInstance.Size = new System.Drawing.Size(76, 28);
            this.cbRudderInstance.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(11, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Rudder Position:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbRudderSource
            // 
            this.cbRudderSource.BackColor = System.Drawing.Color.Black;
            this.cbRudderSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRudderSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRudderSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRudderSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbRudderSource.FormattingEnabled = true;
            this.cbRudderSource.Location = new System.Drawing.Point(191, 166);
            this.cbRudderSource.Name = "cbRudderSource";
            this.cbRudderSource.Size = new System.Drawing.Size(265, 28);
            this.cbRudderSource.TabIndex = 13;
            this.cbRudderSource.SelectedIndexChanged += new System.EventHandler(this.cbOilPressSource_SelectedIndexChanged);
            // 
            // lblRudderPgn
            // 
            this.lblRudderPgn.BackColor = System.Drawing.Color.Black;
            this.lblRudderPgn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRudderPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRudderPgn.ForeColor = System.Drawing.Color.Gray;
            this.lblRudderPgn.Location = new System.Drawing.Point(620, 166);
            this.lblRudderPgn.Name = "lblRudderPgn";
            this.lblRudderPgn.Size = new System.Drawing.Size(74, 33);
            this.lblRudderPgn.TabIndex = 44;
            this.lblRudderPgn.Text = "127245";
            this.lblRudderPgn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStbdTrimPgn
            // 
            this.lblStbdTrimPgn.BackColor = System.Drawing.Color.Black;
            this.lblStbdTrimPgn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStbdTrimPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStbdTrimPgn.ForeColor = System.Drawing.Color.Gray;
            this.lblStbdTrimPgn.Location = new System.Drawing.Point(620, 128);
            this.lblStbdTrimPgn.Name = "lblStbdTrimPgn";
            this.lblStbdTrimPgn.Size = new System.Drawing.Size(74, 33);
            this.lblStbdTrimPgn.TabIndex = 43;
            this.lblStbdTrimPgn.Text = "130576";
            this.lblStbdTrimPgn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPortTrimPgn
            // 
            this.lblPortTrimPgn.BackColor = System.Drawing.Color.Black;
            this.lblPortTrimPgn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPortTrimPgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortTrimPgn.ForeColor = System.Drawing.Color.Gray;
            this.lblPortTrimPgn.Location = new System.Drawing.Point(620, 89);
            this.lblPortTrimPgn.Name = "lblPortTrimPgn";
            this.lblPortTrimPgn.Size = new System.Drawing.Size(74, 33);
            this.lblPortTrimPgn.TabIndex = 42;
            this.lblPortTrimPgn.Text = "130576";
            this.lblPortTrimPgn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbRudderSerial
            // 
            this.cbRudderSerial.BackColor = System.Drawing.Color.Black;
            this.cbRudderSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRudderSerial.Enabled = false;
            this.cbRudderSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRudderSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRudderSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbRudderSerial.FormattingEnabled = true;
            this.cbRudderSerial.Location = new System.Drawing.Point(468, 166);
            this.cbRudderSerial.Name = "cbRudderSerial";
            this.cbRudderSerial.Size = new System.Drawing.Size(140, 28);
            this.cbRudderSerial.TabIndex = 39;
            // 
            // cbStbdTrimSerial
            // 
            this.cbStbdTrimSerial.BackColor = System.Drawing.Color.Black;
            this.cbStbdTrimSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStbdTrimSerial.Enabled = false;
            this.cbStbdTrimSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbStbdTrimSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStbdTrimSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbStbdTrimSerial.FormattingEnabled = true;
            this.cbStbdTrimSerial.Location = new System.Drawing.Point(468, 128);
            this.cbStbdTrimSerial.Name = "cbStbdTrimSerial";
            this.cbStbdTrimSerial.Size = new System.Drawing.Size(140, 28);
            this.cbStbdTrimSerial.TabIndex = 38;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(468, 55);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(139, 23);
            this.label20.TabIndex = 37;
            this.label20.Text = "Serial Number";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPortTrimSerial
            // 
            this.cbPortTrimSerial.BackColor = System.Drawing.Color.Black;
            this.cbPortTrimSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPortTrimSerial.Enabled = false;
            this.cbPortTrimSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPortTrimSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPortTrimSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbPortTrimSerial.FormattingEnabled = true;
            this.cbPortTrimSerial.Location = new System.Drawing.Point(468, 89);
            this.cbPortTrimSerial.Name = "cbPortTrimSerial";
            this.cbPortTrimSerial.Size = new System.Drawing.Size(140, 28);
            this.cbPortTrimSerial.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(620, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "PGN";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(706, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Instance";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(191, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(295, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "Source Device";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(20, 255);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(452, 23);
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
            this.btnDeviceListScrollUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeviceListScrollUp.ForeColor = System.Drawing.Color.White;
            this.btnDeviceListScrollUp.Location = new System.Drawing.Point(484, 337);
            this.btnDeviceListScrollUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeviceListScrollUp.Name = "btnDeviceListScrollUp";
            this.btnDeviceListScrollUp.Size = new System.Drawing.Size(135, 58);
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
            this.btnDeviceListScrollDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeviceListScrollDown.ForeColor = System.Drawing.Color.White;
            this.btnDeviceListScrollDown.Location = new System.Drawing.Point(484, 399);
            this.btnDeviceListScrollDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeviceListScrollDown.Name = "btnDeviceListScrollDown";
            this.btnDeviceListScrollDown.Size = new System.Drawing.Size(135, 58);
            this.btnDeviceListScrollDown.TabIndex = 40;
            this.btnDeviceListScrollDown.TabStop = false;
            this.btnDeviceListScrollDown.Text = "Next Page";
            this.btnDeviceListScrollDown.UseVisualStyleBackColor = true;
            this.btnDeviceListScrollDown.Click += new System.EventHandler(this.btnDeviceListScrollDown_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.BlackButton;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(630, 357);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 98);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::WhatTheHelmRuntime.Properties.Resources.BlackButton;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(630, 255);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 98);
            this.btnSave.TabIndex = 43;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TrimRudderNmea2000Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.lblRudderPgn);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblStbdTrimPgn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPortTrimPgn);
            this.Controls.Add(this.btnDeviceListScrollDown);
            this.Controls.Add(this.cbRudderSerial);
            this.Controls.Add(this.btnDeviceListScrollUp);
            this.Controls.Add(this.cbStbdTrimSerial);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cbPortTrimSerial);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWindowBanner);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRefreshDeviceList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbRudderInstance);
            this.Controls.Add(this.cbPortTrimSource);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbRudderSource);
            this.Controls.Add(this.cbStbdTrimSource);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TrimRudderNmea2000Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NMEA 2000 Configuration";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshDeviceList;
        private System.Windows.Forms.Label lblWindowBanner;
        private System.Windows.Forms.ComboBox cbPortTrimSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbStbdTrimSource;
        private System.Windows.Forms.ComboBox cbRudderInstance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbRudderSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnDeviceListScrollUp;
        private System.Windows.Forms.Button btnDeviceListScrollDown;
        private System.Windows.Forms.ComboBox cbRudderSerial;
        private System.Windows.Forms.ComboBox cbStbdTrimSerial;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblPortTrimPgn;
        private System.Windows.Forms.ComboBox cbPortTrimSerial;
        private System.Windows.Forms.Label lblRudderPgn;
        private System.Windows.Forms.Label lblStbdTrimPgn;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}