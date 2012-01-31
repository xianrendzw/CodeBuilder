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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TraceOptionsPage));
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
            resources.ApplyResources(this.noteTextLbl, "noteTextLbl");
            this.noteTextLbl.Name = "noteTextLbl";
            // 
            // noteLbl
            // 
            resources.ApplyResources(this.noteLbl, "noteLbl");
            this.noteLbl.Name = "noteLbl";
            // 
            // logDirectoryLabel
            // 
            resources.ApplyResources(this.logDirectoryLabel, "logDirectoryLabel");
            this.logDirectoryLabel.Name = "logDirectoryLabel";
            // 
            // logDirectoryLbl
            // 
            resources.ApplyResources(this.logDirectoryLbl, "logDirectoryLbl");
            this.logDirectoryLbl.Name = "logDirectoryLbl";
            // 
            // traceLevelCombox
            // 
            this.traceLevelCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.traceLevelCombox.FormattingEnabled = true;
            this.traceLevelCombox.Items.AddRange(new object[] {
            resources.GetString("traceLevelCombox.Items"),
            resources.GetString("traceLevelCombox.Items1"),
            resources.GetString("traceLevelCombox.Items2"),
            resources.GetString("traceLevelCombox.Items3"),
            resources.GetString("traceLevelCombox.Items4"),
            resources.GetString("traceLevelCombox.Items5")});
            resources.ApplyResources(this.traceLevelCombox, "traceLevelCombox");
            this.traceLevelCombox.Name = "traceLevelCombox";
            // 
            // tracLevelLbl
            // 
            resources.ApplyResources(this.tracLevelLbl, "tracLevelLbl");
            this.tracLevelLbl.Name = "tracLevelLbl";
            // 
            // internalTraceLbl
            // 
            resources.ApplyResources(this.internalTraceLbl, "internalTraceLbl");
            this.internalTraceLbl.Name = "internalTraceLbl";
            // 
            // topGbx
            // 
            resources.ApplyResources(this.topGbx, "topGbx");
            this.topGbx.Name = "topGbx";
            this.topGbx.TabStop = false;
            // 
            // TraceOptionsPage
            // 
            resources.ApplyResources(this, "$this");
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
