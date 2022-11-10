
namespace WhatTheHelmRuntime
{
    partial class ConfigurationMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudWaterDepthOffset = new System.Windows.Forms.NumericUpDown();
            this.nudWaterTempOffset = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRpmSource = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaterDepthOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaterTempOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "Water Depth Offset (Feet):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudWaterDepthOffset
            // 
            this.nudWaterDepthOffset.DecimalPlaces = 1;
            this.nudWaterDepthOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWaterDepthOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudWaterDepthOffset.Location = new System.Drawing.Point(635, 82);
            this.nudWaterDepthOffset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudWaterDepthOffset.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudWaterDepthOffset.Name = "nudWaterDepthOffset";
            this.nudWaterDepthOffset.Size = new System.Drawing.Size(329, 75);
            this.nudWaterDepthOffset.TabIndex = 1;
            // 
            // nudWaterTempOffset
            // 
            this.nudWaterTempOffset.DecimalPlaces = 1;
            this.nudWaterTempOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWaterTempOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudWaterTempOffset.Location = new System.Drawing.Point(635, 174);
            this.nudWaterTempOffset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudWaterTempOffset.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudWaterTempOffset.Name = "nudWaterTempOffset";
            this.nudWaterTempOffset.Size = new System.Drawing.Size(329, 75);
            this.nudWaterTempOffset.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 174);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(584, 76);
            this.label2.TabIndex = 2;
            this.label2.Text = "Water Temp Offset (DegF):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbRpmSource
            // 
            this.cbRpmSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRpmSource.Location = new System.Drawing.Point(92, 276);
            this.cbRpmSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbRpmSource.Name = "cbRpmSource";
            this.cbRpmSource.Size = new System.Drawing.Size(872, 98);
            this.cbRpmSource.TabIndex = 4;
            this.cbRpmSource.Text = "Use NMEA 2000 RPM Source\r\n(Unchecked use USB Tach Adapter)";
            this.cbRpmSource.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(385, 406);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(301, 107);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(840, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 129);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConfigurationMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbRpmSource);
            this.Controls.Add(this.nudWaterTempOffset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudWaterDepthOffset);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConfigurationMenu";
            this.Text = "ConfigurationMenu";
            ((System.ComponentModel.ISupportInitialize)(this.nudWaterDepthOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaterTempOffset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudWaterDepthOffset;
        private System.Windows.Forms.NumericUpDown nudWaterTempOffset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbRpmSource;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
    }
}