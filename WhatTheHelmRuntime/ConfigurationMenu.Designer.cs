
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
            ((System.ComponentModel.ISupportInitialize)(this.nudWaterDepthOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaterTempOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 62);
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
            this.nudWaterDepthOffset.Location = new System.Drawing.Point(476, 67);
            this.nudWaterDepthOffset.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudWaterDepthOffset.Name = "nudWaterDepthOffset";
            this.nudWaterDepthOffset.Size = new System.Drawing.Size(247, 62);
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
            this.nudWaterTempOffset.Location = new System.Drawing.Point(476, 141);
            this.nudWaterTempOffset.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudWaterTempOffset.Name = "nudWaterTempOffset";
            this.nudWaterTempOffset.Size = new System.Drawing.Size(247, 62);
            this.nudWaterTempOffset.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(438, 62);
            this.label2.TabIndex = 2;
            this.label2.Text = "Water Temp Offset (DegF):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbRpmSource
            // 
            this.cbRpmSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRpmSource.Location = new System.Drawing.Point(69, 224);
            this.cbRpmSource.Name = "cbRpmSource";
            this.cbRpmSource.Size = new System.Drawing.Size(654, 80);
            this.cbRpmSource.TabIndex = 4;
            this.cbRpmSource.Text = "Use NMEA 2000 RPM Source\r\n(Unchecked use USB Tach Adapter)";
            this.cbRpmSource.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(289, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(226, 87);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ConfigurationMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbRpmSource);
            this.Controls.Add(this.nudWaterTempOffset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudWaterDepthOffset);
            this.Controls.Add(this.label1);
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
    }
}