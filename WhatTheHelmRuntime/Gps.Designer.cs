
namespace WhatTheHelmRuntime
{
    partial class Gps
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
            this.pbCompass = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompass)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCompass
            // 
            this.pbCompass.BackColor = System.Drawing.Color.Black;
            this.pbCompass.Location = new System.Drawing.Point(172, 15);
            this.pbCompass.Name = "pbCompass";
            this.pbCompass.Size = new System.Drawing.Size(450, 450);
            this.pbCompass.TabIndex = 76;
            this.pbCompass.TabStop = false;
            // 
            // Gps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.pbCompass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Gps";
            this.Text = "Gps";
            ((System.ComponentModel.ISupportInitialize)(this.pbCompass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbCompass;
    }
}