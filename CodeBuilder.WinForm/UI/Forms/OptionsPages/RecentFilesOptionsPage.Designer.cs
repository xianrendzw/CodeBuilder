namespace CodeBuilder.WinForm.UI.OptionsPages
{
    partial class RecentFilesOptionsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecentFilesOptionsPage));
            this.checkFilesExistCheckBox = new System.Windows.Forms.CheckBox();
            this.filesInMenuLbl = new System.Windows.Forms.Label();
            this.recentFilesCountTextBox = new System.Windows.Forms.TextBox();
            this.listLbl = new System.Windows.Forms.Label();
            this.topGbox = new System.Windows.Forms.GroupBox();
            this.recentFilesLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkFilesExistCheckBox
            // 
            resources.ApplyResources(this.checkFilesExistCheckBox, "checkFilesExistCheckBox");
            this.checkFilesExistCheckBox.Name = "checkFilesExistCheckBox";
            this.checkFilesExistCheckBox.UseVisualStyleBackColor = true;
            // 
            // filesInMenuLbl
            // 
            resources.ApplyResources(this.filesInMenuLbl, "filesInMenuLbl");
            this.filesInMenuLbl.Name = "filesInMenuLbl";
            // 
            // recentFilesCountTextBox
            // 
            resources.ApplyResources(this.recentFilesCountTextBox, "recentFilesCountTextBox");
            this.recentFilesCountTextBox.Name = "recentFilesCountTextBox";
            // 
            // listLbl
            // 
            resources.ApplyResources(this.listLbl, "listLbl");
            this.listLbl.Name = "listLbl";
            // 
            // topGbox
            // 
            resources.ApplyResources(this.topGbox, "topGbox");
            this.topGbox.Name = "topGbox";
            this.topGbox.TabStop = false;
            // 
            // recentFilesLbl
            // 
            resources.ApplyResources(this.recentFilesLbl, "recentFilesLbl");
            this.recentFilesLbl.Name = "recentFilesLbl";
            // 
            // RecentFilesOptionsPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkFilesExistCheckBox);
            this.Controls.Add(this.filesInMenuLbl);
            this.Controls.Add(this.recentFilesCountTextBox);
            this.Controls.Add(this.listLbl);
            this.Controls.Add(this.topGbox);
            this.Controls.Add(this.recentFilesLbl);
            this.Name = "RecentFilesOptionsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkFilesExistCheckBox;
        private System.Windows.Forms.Label filesInMenuLbl;
        private System.Windows.Forms.TextBox recentFilesCountTextBox;
        private System.Windows.Forms.Label listLbl;
        private System.Windows.Forms.GroupBox topGbox;
        private System.Windows.Forms.Label recentFilesLbl;
    }
}
