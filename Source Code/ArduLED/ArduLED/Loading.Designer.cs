namespace ArduLEDNameSpace
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LoadingScreenLabel = new System.Windows.Forms.Label();
            this.LoadingScreenLoadingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 65.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 87);
            this.label1.TabIndex = 0;
            this.label1.Text = "ArduLED";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(64, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "A project by Kristian Skov Johansen";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ArduLEDNameSpace.Properties.Resources.SkinnySeveralAsianlion;
            this.pictureBox1.Location = new System.Drawing.Point(450, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 11);
            this.label4.TabIndex = 5;
            this.label4.Text = "2018 - Powered by BASS.NET";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.LoadingScreenLoadingLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 30);
            this.panel1.TabIndex = 6;
            // 
            // LoadingScreenLabel
            // 
            this.LoadingScreenLabel.AutoSize = true;
            this.LoadingScreenLabel.Font = new System.Drawing.Font("Lucida Console", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadingScreenLabel.ForeColor = System.Drawing.Color.White;
            this.LoadingScreenLabel.Location = new System.Drawing.Point(215, 154);
            this.LoadingScreenLabel.Name = "LoadingScreenLabel";
            this.LoadingScreenLabel.Size = new System.Drawing.Size(95, 9);
            this.LoadingScreenLabel.TabIndex = 7;
            this.LoadingScreenLabel.Text = "Loading: Internals";
            // 
            // LoadingScreenLoadingLabel
            // 
            this.LoadingScreenLoadingLabel.AutoSize = true;
            this.LoadingScreenLoadingLabel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadingScreenLoadingLabel.ForeColor = System.Drawing.Color.White;
            this.LoadingScreenLoadingLabel.Location = new System.Drawing.Point(3, 9);
            this.LoadingScreenLoadingLabel.Name = "LoadingScreenLoadingLabel";
            this.LoadingScreenLoadingLabel.Size = new System.Drawing.Size(215, 11);
            this.LoadingScreenLoadingLabel.TabIndex = 6;
            this.LoadingScreenLoadingLabel.Text = "Your Version:  Newest Version:";
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(595, 170);
            this.Controls.Add(this.LoadingScreenLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loading";
            this.Opacity = 0D;
            this.Tag = "0";
            this.Text = "Loading";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Loading_FormClosing);
            this.Load += new System.EventHandler(this.Loading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label LoadingScreenLabel;
        public System.Windows.Forms.Label LoadingScreenLoadingLabel;
    }
}