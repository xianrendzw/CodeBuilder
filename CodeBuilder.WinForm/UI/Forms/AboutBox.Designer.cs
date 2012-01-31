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
        /// <param typeName="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated displayName

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the displayName editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
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
            resources.ApplyResources(this.dotNetVersionLabel, "dotNetVersionLabel");
            this.dotNetVersionLabel.Name = "dotNetVersionLabel";
            // 
            // clrTypeLabel
            // 
            resources.ApplyResources(this.clrTypeLabel, "clrTypeLabel");
            this.clrTypeLabel.Name = "clrTypeLabel";
            // 
            // copyright
            // 
            resources.ApplyResources(this.copyright, "copyright");
            this.copyright.Name = "copyright";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // infoLinkLabel
            // 
            resources.ApplyResources(this.infoLinkLabel, "infoLinkLabel");
            this.infoLinkLabel.Name = "infoLinkLabel";
            this.infoLinkLabel.TabStop = true;
            this.infoLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.infoLinkLabel_LinkClicked);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // versionLabel
            // 
            resources.ApplyResources(this.versionLabel, "versionLabel");
            this.versionLabel.Name = "versionLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.OkButton, "OkButton");
            this.OkButton.Name = "OkButton";
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // AboutBox
            // 
            this.AcceptButton = this.OkButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.OkButton;
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