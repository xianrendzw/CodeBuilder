namespace CodeBuilder.WinForm.UI
{
    partial class AboutBox
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
            this.dotNetVersionLabel = new System.Windows.Forms.Label();
            this.clrTypeLabel = new System.Windows.Forms.Label();
            this.copyright = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.infoLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dotNetVersionLabel
            // 
            this.dotNetVersionLabel.Location = new System.Drawing.Point(157, 264);
            this.dotNetVersionLabel.Name = "dotNetVersionLabel";
            this.dotNetVersionLabel.Size = new System.Drawing.Size(284, 23);
            this.dotNetVersionLabel.TabIndex = 25;
            // 
            // clrTypeLabel
            // 
            this.clrTypeLabel.Location = new System.Drawing.Point(24, 264);
            this.clrTypeLabel.Name = "clrTypeLabel";
            this.clrTypeLabel.Size = new System.Drawing.Size(102, 15);
            this.clrTypeLabel.TabIndex = 24;
            this.clrTypeLabel.Text = "CLR Version:";
            // 
            // copyright
            // 
            this.copyright.Location = new System.Drawing.Point(157, 12);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(297, 84);
            this.copyright.TabIndex = 23;
            this.copyright.Text = "Copyright (C) 2011-2012 Tom Deng\r\nAll Rights Reserved.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(24, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 28);
            this.label7.TabIndex = 22;
            this.label7.Text = "Copyright:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(157, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 29);
            this.label6.TabIndex = 21;
            this.label6.Text = "Emil Song";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 29);
            this.label5.TabIndex = 20;
            this.label5.Text = "Thanks to:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Information:";
            // 
            // infoLinkLabel
            // 
            this.infoLinkLabel.LinkArea = new System.Windows.Forms.LinkArea(0, 48);
            this.infoLinkLabel.Location = new System.Drawing.Point(157, 104);
            this.infoLinkLabel.Name = "infoLinkLabel";
            this.infoLinkLabel.Size = new System.Drawing.Size(266, 16);
            this.infoLinkLabel.TabIndex = 18;
            this.infoLinkLabel.TabStop = true;
            this.infoLinkLabel.Text = "http://www.dengzhiwei.com/category/codebuilder\r\n";
            this.infoLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.infoLinkLabel_LinkClicked);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(157, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 48);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tom Deng,Peter Chen,Gallop Chen";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 29);
            this.label2.TabIndex = 16;
            this.label2.Text = "Developers:";
            // 
            // versionLabel
            // 
            this.versionLabel.Location = new System.Drawing.Point(157, 232);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(156, 23);
            this.versionLabel.TabIndex = 15;
            this.versionLabel.Text = "1.0.11.1210";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Version:";
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkButton.Location = new System.Drawing.Point(361, 296);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(96, 29);
            this.OkButton.TabIndex = 13;
            this.OkButton.Text = "OK";
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // AboutBox
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.OkButton;
            this.ClientSize = new System.Drawing.Size(480, 336);
            this.Controls.Add(this.dotNetVersionLabel);
            this.Controls.Add(this.clrTypeLabel);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.infoLinkLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About CodeBuilder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label dotNetVersionLabel;
        private System.Windows.Forms.Label clrTypeLabel;
        private System.Windows.Forms.Label copyright;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel infoLinkLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OkButton;
    }
}