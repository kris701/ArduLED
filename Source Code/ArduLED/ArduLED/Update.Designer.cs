namespace ArduLEDNameSpace
{
    partial class Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Update));
            this.UpdateTopLabel = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateNowButton = new System.Windows.Forms.Button();
            this.UpdateLaterButton = new System.Windows.Forms.Button();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateTopLabel
            // 
            this.UpdateTopLabel.AutoSize = true;
            this.UpdateTopLabel.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateTopLabel.ForeColor = System.Drawing.Color.White;
            this.UpdateTopLabel.Location = new System.Drawing.Point(19, 57);
            this.UpdateTopLabel.Name = "UpdateTopLabel";
            this.UpdateTopLabel.Size = new System.Drawing.Size(303, 13);
            this.UpdateTopLabel.TabIndex = 0;
            this.UpdateTopLabel.Text = "A new version of ArduLED is available";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel7.Controls.Add(this.label1);
            this.panel7.Location = new System.Drawing.Point(-2, -1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(349, 55);
            this.panel7.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "ArduLED Update";
            // 
            // UpdateNowButton
            // 
            this.UpdateNowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.UpdateNowButton.FlatAppearance.BorderSize = 0;
            this.UpdateNowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateNowButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateNowButton.ForeColor = System.Drawing.Color.White;
            this.UpdateNowButton.Location = new System.Drawing.Point(22, 85);
            this.UpdateNowButton.Name = "UpdateNowButton";
            this.UpdateNowButton.Size = new System.Drawing.Size(147, 22);
            this.UpdateNowButton.TabIndex = 59;
            this.UpdateNowButton.Text = "Update now";
            this.UpdateNowButton.UseVisualStyleBackColor = false;
            this.UpdateNowButton.Click += new System.EventHandler(this.UpdateNowButton_Click);
            // 
            // UpdateLaterButton
            // 
            this.UpdateLaterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(217)))));
            this.UpdateLaterButton.FlatAppearance.BorderSize = 0;
            this.UpdateLaterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateLaterButton.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateLaterButton.ForeColor = System.Drawing.Color.White;
            this.UpdateLaterButton.Location = new System.Drawing.Point(178, 85);
            this.UpdateLaterButton.Name = "UpdateLaterButton";
            this.UpdateLaterButton.Size = new System.Drawing.Size(147, 22);
            this.UpdateLaterButton.TabIndex = 60;
            this.UpdateLaterButton.Text = "Later";
            this.UpdateLaterButton.UseVisualStyleBackColor = false;
            this.UpdateLaterButton.Click += new System.EventHandler(this.UpdateLaterButton_Click);
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(345, 128);
            this.Controls.Add(this.UpdateLaterButton);
            this.Controls.Add(this.UpdateNowButton);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.UpdateTopLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Update";
            this.Text = "Update";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Update_Load);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UpdateTopLabel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UpdateNowButton;
        private System.Windows.Forms.Button UpdateLaterButton;
    }
}