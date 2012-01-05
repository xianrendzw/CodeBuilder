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
            this.checkFilesExistCheckBox.AutoSize = true;
            this.checkFilesExistCheckBox.Location = new System.Drawing.Point(27, 72);
            this.checkFilesExistCheckBox.Name = "checkFilesExistCheckBox";
            this.checkFilesExistCheckBox.Size = new System.Drawing.Size(185, 17);
            this.checkFilesExistCheckBox.TabIndex = 4;
            this.checkFilesExistCheckBox.Text = "Check that files exist before listing";
            this.checkFilesExistCheckBox.UseVisualStyleBackColor = true;
            // 
            // filesInMenuLbl
            // 
            this.filesInMenuLbl.Location = new System.Drawing.Point(147, 33);
            this.filesInMenuLbl.Name = "filesInMenuLbl";
            this.filesInMenuLbl.Size = new System.Drawing.Size(96, 24);
            this.filesInMenuLbl.TabIndex = 3;
            this.filesInMenuLbl.Text = "files in menu";
            // 
            // recentFilesCountTextBox
            // 
            this.recentFilesCountTextBox.Location = new System.Drawing.Point(91, 33);
            this.recentFilesCountTextBox.MaxLength = 50;
            this.recentFilesCountTextBox.Name = "recentFilesCountTextBox";
            this.recentFilesCountTextBox.Size = new System.Drawing.Size(40, 20);
            this.recentFilesCountTextBox.TabIndex = 2;
            this.recentFilesCountTextBox.Text = "3";
            // 
            // listLbl
            // 
            this.listLbl.Location = new System.Drawing.Point(27, 33);
            this.listLbl.Name = "listLbl";
            this.listLbl.Size = new System.Drawing.Size(55, 16);
            this.listLbl.TabIndex = 1;
            this.listLbl.Text = "List";
            // 
            // topGbox
            // 
            this.topGbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topGbox.Location = new System.Drawing.Point(80, 5);
            this.topGbox.Name = "topGbox";
            this.topGbox.Size = new System.Drawing.Size(370, 8);
            this.topGbox.TabIndex = 35;
            this.topGbox.TabStop = false;
            // 
            // recentFilesLbl
            // 
            this.recentFilesLbl.Location = new System.Drawing.Point(9, 5);
            this.recentFilesLbl.Name = "recentFilesLbl";
            this.recentFilesLbl.Size = new System.Drawing.Size(70, 16);
            this.recentFilesLbl.TabIndex = 36;
            this.recentFilesLbl.Text = "Recent Files";
            // 
            // RecentFilesOptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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
