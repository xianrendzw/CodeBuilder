namespace CodeBuilder.WinForm.UI.OptionsPages
{
    partial class CodeGeneralOptionsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeGeneralOptionsPage));
            this.ouputPathTxtbox = new System.Windows.Forms.TextBox();
            this.ouputPathLbl = new System.Windows.Forms.Label();
            this.noteTextLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.generationLbl = new System.Windows.Forms.Label();
            this.topGbx = new System.Windows.Forms.GroupBox();
            this.ouputPathBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.templatePathBtn = new System.Windows.Forms.Button();
            this.templatePathTxtbox = new System.Windows.Forms.TextBox();
            this.templatePathLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ouputPathTxtbox
            // 
            resources.ApplyResources(this.ouputPathTxtbox, "ouputPathTxtbox");
            this.ouputPathTxtbox.Name = "ouputPathTxtbox";
            // 
            // ouputPathLbl
            // 
            resources.ApplyResources(this.ouputPathLbl, "ouputPathLbl");
            this.ouputPathLbl.Name = "ouputPathLbl";
            // 
            // noteTextLabel
            // 
            resources.ApplyResources(this.noteTextLabel, "noteTextLabel");
            this.noteTextLabel.Name = "noteTextLabel";
            // 
            // noteLabel
            // 
            resources.ApplyResources(this.noteLabel, "noteLabel");
            this.noteLabel.Name = "noteLabel";
            // 
            // generationLbl
            // 
            resources.ApplyResources(this.generationLbl, "generationLbl");
            this.generationLbl.Name = "generationLbl";
            // 
            // topGbx
            // 
            resources.ApplyResources(this.topGbx, "topGbx");
            this.topGbx.Name = "topGbx";
            this.topGbx.TabStop = false;
            // 
            // ouputPathBtn
            // 
            resources.ApplyResources(this.ouputPathBtn, "ouputPathBtn");
            this.ouputPathBtn.Name = "ouputPathBtn";
            this.ouputPathBtn.UseVisualStyleBackColor = true;
            this.ouputPathBtn.Click += new System.EventHandler(this.ouputPathBtn_Click);
            // 
            // templatePathBtn
            // 
            resources.ApplyResources(this.templatePathBtn, "templatePathBtn");
            this.templatePathBtn.Name = "templatePathBtn";
            this.templatePathBtn.UseVisualStyleBackColor = true;
            this.templatePathBtn.Click += new System.EventHandler(this.templatePathBtn_Click);
            // 
            // templatePathTxtbox
            // 
            resources.ApplyResources(this.templatePathTxtbox, "templatePathTxtbox");
            this.templatePathTxtbox.Name = "templatePathTxtbox";
            // 
            // templatePathLbl
            // 
            resources.ApplyResources(this.templatePathLbl, "templatePathLbl");
            this.templatePathLbl.Name = "templatePathLbl";
            // 
            // CodeGeneralOptionsPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.templatePathBtn);
            this.Controls.Add(this.templatePathTxtbox);
            this.Controls.Add(this.templatePathLbl);
            this.Controls.Add(this.ouputPathBtn);
            this.Controls.Add(this.ouputPathTxtbox);
            this.Controls.Add(this.ouputPathLbl);
            this.Controls.Add(this.noteTextLabel);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.generationLbl);
            this.Controls.Add(this.topGbx);
            this.Name = "CodeGeneralOptionsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ouputPathTxtbox;
        private System.Windows.Forms.Label ouputPathLbl;
        private System.Windows.Forms.Label noteTextLabel;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Label generationLbl;
        private System.Windows.Forms.GroupBox topGbx;
        private System.Windows.Forms.Button ouputPathBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button templatePathBtn;
        private System.Windows.Forms.TextBox templatePathTxtbox;
        private System.Windows.Forms.Label templatePathLbl;
    }
}
