namespace CodeBuilder.WinForm.UI.OptionsPages
{
    partial class TraceOptionsPage
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

        #region Component Designer generated displayName

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the displayName editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.noteTextLbl = new System.Windows.Forms.Label();
            this.noteLbl = new System.Windows.Forms.Label();
            this.logDirectoryLabel = new System.Windows.Forms.Label();
            this.logDirectoryLbl = new System.Windows.Forms.Label();
            this.traceLevelCombox = new System.Windows.Forms.ComboBox();
            this.tracLevelLbl = new System.Windows.Forms.Label();
            this.internalTraceLbl = new System.Windows.Forms.Label();
            this.topGbx = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // noteTextLbl
            // 
            this.noteTextLbl.Location = new System.Drawing.Point(102, 130);
            this.noteTextLbl.Name = "noteTextLbl";
            this.noteTextLbl.Size = new System.Drawing.Size(329, 40);
            this.noteTextLbl.TabIndex = 29;
            this.noteTextLbl.Text = "Changes in the Trace Level will not affect the current session. After changing th" +
    "e level, you should shut down and restart the Gui.";
            // 
            // noteLbl
            // 
            this.noteLbl.AutoSize = true;
            this.noteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(47, 130);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(38, 13);
            this.noteLbl.TabIndex = 28;
            this.noteLbl.Text = "Note:";
            // 
            // logDirectoryLabel
            // 
            this.logDirectoryLabel.Location = new System.Drawing.Point(105, 87);
            this.logDirectoryLabel.Name = "logDirectoryLabel";
            this.logDirectoryLabel.Size = new System.Drawing.Size(300, 13);
            this.logDirectoryLabel.TabIndex = 27;
            // 
            // logDirectoryLbl
            // 
            this.logDirectoryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logDirectoryLbl.Location = new System.Drawing.Point(19, 87);
            this.logDirectoryLbl.Name = "logDirectoryLbl";
            this.logDirectoryLbl.Size = new System.Drawing.Size(75, 13);
            this.logDirectoryLbl.TabIndex = 26;
            this.logDirectoryLbl.Text = "Log Directory:";
            // 
            // traceLevelCombox
            // 
            this.traceLevelCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.traceLevelCombox.FormattingEnabled = true;
            this.traceLevelCombox.Items.AddRange(new object[] {
            "Default",
            "Off",
            "Error",
            "Warning",
            "Info",
            "Verbose"});
            this.traceLevelCombox.Location = new System.Drawing.Point(105, 43);
            this.traceLevelCombox.Name = "traceLevelCombox";
            this.traceLevelCombox.Size = new System.Drawing.Size(62, 21);
            this.traceLevelCombox.TabIndex = 25;
            // 
            // tracLevelLbl
            // 
            this.tracLevelLbl.Location = new System.Drawing.Point(19, 46);
            this.tracLevelLbl.Name = "tracLevelLbl";
            this.tracLevelLbl.Size = new System.Drawing.Size(75, 13);
            this.tracLevelLbl.TabIndex = 24;
            this.tracLevelLbl.Text = "Trace Level:";
            // 
            // internalTraceLbl
            // 
            this.internalTraceLbl.Location = new System.Drawing.Point(9, 5);
            this.internalTraceLbl.Name = "internalTraceLbl";
            this.internalTraceLbl.Size = new System.Drawing.Size(80, 16);
            this.internalTraceLbl.TabIndex = 23;
            this.internalTraceLbl.Text = "Internal Trace";
            // 
            // topGbx
            // 
            this.topGbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topGbx.Location = new System.Drawing.Point(90, 5);
            this.topGbx.Name = "topGbx";
            this.topGbx.Size = new System.Drawing.Size(360, 8);
            this.topGbx.TabIndex = 22;
            this.topGbx.TabStop = false;
            // 
            // TraceOptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.noteTextLbl);
            this.Controls.Add(this.noteLbl);
            this.Controls.Add(this.logDirectoryLabel);
            this.Controls.Add(this.logDirectoryLbl);
            this.Controls.Add(this.traceLevelCombox);
            this.Controls.Add(this.tracLevelLbl);
            this.Controls.Add(this.internalTraceLbl);
            this.Controls.Add(this.topGbx);
            this.Name = "TraceOptionsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label noteTextLbl;
        private System.Windows.Forms.Label noteLbl;
        private System.Windows.Forms.Label logDirectoryLabel;
        private System.Windows.Forms.Label logDirectoryLbl;
        private System.Windows.Forms.ComboBox traceLevelCombox;
        private System.Windows.Forms.Label tracLevelLbl;
        private System.Windows.Forms.Label internalTraceLbl;
        private System.Windows.Forms.GroupBox topGbx;

    }
}
