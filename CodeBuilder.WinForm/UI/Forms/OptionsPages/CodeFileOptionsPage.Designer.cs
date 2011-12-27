namespace CodeBuilder.WinForm.UI.OptionsPages
{
    partial class CodeFileOptionsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ouputPathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.generationLbl = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.openFolderDialogBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // ouputPathTextBox
            // 
            this.ouputPathTextBox.Location = new System.Drawing.Point(105, 43);
            this.ouputPathTextBox.Name = "ouputPathTextBox";
            this.ouputPathTextBox.Size = new System.Drawing.Size(311, 20);
            this.ouputPathTextBox.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Output Path:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(102, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 40);
            this.label2.TabIndex = 40;
            this.label2.Text = "Save generationed code files to this directory .";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 40);
            this.label1.TabIndex = 39;
            this.label1.Text = "Note:";
            // 
            // generationLbl
            // 
            this.generationLbl.Location = new System.Drawing.Point(9, 5);
            this.generationLbl.Name = "generationLbl";
            this.generationLbl.Size = new System.Drawing.Size(60, 16);
            this.generationLbl.TabIndex = 37;
            this.generationLbl.Text = "Code File";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Location = new System.Drawing.Point(80, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 8);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            // 
            // openFolderDialogBtn
            // 
            this.openFolderDialogBtn.Location = new System.Drawing.Point(422, 40);
            this.openFolderDialogBtn.Name = "openFolderDialogBtn";
            this.openFolderDialogBtn.Size = new System.Drawing.Size(25, 23);
            this.openFolderDialogBtn.TabIndex = 43;
            this.openFolderDialogBtn.Text = "...";
            this.openFolderDialogBtn.UseVisualStyleBackColor = true;
            this.openFolderDialogBtn.Click += new System.EventHandler(this.openFolderDialogBtn_Click);
            // 
            // CodeFileOptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.openFolderDialogBtn);
            this.Controls.Add(this.ouputPathTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generationLbl);
            this.Controls.Add(this.groupBox3);
            this.Name = "CodeFileOptionsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ouputPathTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label generationLbl;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button openFolderDialogBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}
