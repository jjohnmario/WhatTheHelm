
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
            this.lblSog = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbCompass = new System.Windows.Forms.PictureBox();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompass)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSog
            // 
            this.lblSog.Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSog.ForeColor = System.Drawing.Color.White;
            this.lblSog.Location = new System.Drawing.Point(488, 117);
            this.lblSog.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSog.Name = "lblSog";
            this.lblSog.Size = new System.Drawing.Size(291, 107);
            this.lblSog.TabIndex = 0;
            this.lblSog.Text = "--";
            this.lblSog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(517, 224);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(233, 32);
            this.label31.TabIndex = 75;
            this.label31.Text = "SOG KTS";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::WhatTheHelmRuntime.Properties.Resources.satellite_48;
            this.pictureBox1.Location = new System.Drawing.Point(610, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 52);
            this.pictureBox1.TabIndex = 77;
            this.pictureBox1.TabStop = false;
            // 
            // pbCompass
            // 
            this.pbCompass.BackColor = System.Drawing.Color.Black;
            this.pbCompass.Location = new System.Drawing.Point(15, 13);
            this.pbCompass.Name = "pbCompass";
            this.pbCompass.Size = new System.Drawing.Size(450, 450);
            this.pbCompass.TabIndex = 76;
            this.pbCompass.TabStop = false;
            // 
            // lblLatitude
            // 
            this.lblLatitude.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.ForeColor = System.Drawing.Color.White;
            this.lblLatitude.Location = new System.Drawing.Point(474, 297);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(317, 32);
            this.lblLatitude.TabIndex = 78;
            this.lblLatitude.Text = "--";
            this.lblLatitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLongitude
            // 
            this.lblLongitude.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.ForeColor = System.Drawing.Color.White;
            this.lblLongitude.Location = new System.Drawing.Point(474, 338);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(317, 32);
            this.lblLongitude.TabIndex = 79;
            this.lblLongitude.Text = "--";
            this.lblLongitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(517, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 35);
            this.label3.TabIndex = 80;
            this.label3.Text = "GPS POSITION";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Gps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbCompass);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.lblSog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Gps";
            this.Text = "Gps";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSog;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.PictureBox pbCompass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label label3;
    }
}