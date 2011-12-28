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
            this.ouputPathTxtbox = new System.Windows.Forms.TextBox();
            this.ouputPathLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.generationLbl = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ouputPathBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.templatePathBtn = new System.Windows.Forms.Button();
            this.templatePathTxtbox = new System.Windows.Forms.TextBox();
            this.templatePathLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ouputPathTxtbox
            // 
            this.ouputPathTxtbox.Location = new System.Drawing.Point(105, 43);
            this.ouputPathTxtbox.Name = "ouputPathTxtbox";
            this.ouputPathTxtbox.Size = new System.Drawing.Size(311, 20);
            this.ouputPathTxtbox.TabIndex = 42;
            // 
            // ouputPathLbl
            // 
            this.ouputPathLbl.Location = new System.Drawing.Point(19, 46);
            this.ouputPathLbl.Name = "ouputPathLbl";
            this.ouputPathLbl.Size = new System.Drawing.Size(80, 13);
            this.ouputPathLbl.TabIndex = 41;
            this.ouputPathLbl.Text = "Output path:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(102, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 76);
            this.label2.TabIndex = 40;
            this.label2.Text = "Generationed code files will be save to Output Path directory .\r\nCode template fi" +
    "les will be write to/read from Template Path directory.";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 40);
            this.label1.TabIndex = 39;
            this.label1.Text = "Note:";
            // 
            // generationLbl
            // 
            this.generationLbl.Location = new System.Drawing.Point(9, 5);
            this.generationLbl.Name = "generationLbl";
            this.generationLbl.Size = new System.Drawing.Size(60, 16);
            this.generationLbl.TabIndex = 37;
            this.generationLbl.Text = "General";
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
            // ouputPathBtn
            // 
            this.ouputPathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ouputPathBtn.Location = new System.Drawing.Point(422, 40);
            this.ouputPathBtn.Name = "ouputPathBtn";
            this.ouputPathBtn.Size = new System.Drawing.Size(25, 23);
            this.ouputPathBtn.TabIndex = 43;
            this.ouputPathBtn.Text = "...";
            this.ouputPathBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ouputPathBtn.UseVisualStyleBackColor = true;
            this.ouputPathBtn.Click += new System.EventHandler(this.ouputPathBtn_Click);
            // 
            // templatePathBtn
            // 
            this.templatePathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templatePathBtn.Location = new System.Drawing.Point(422, 79);
            this.templatePathBtn.Name = "templatePathBtn";
            this.templatePathBtn.Size = new System.Drawing.Size(25, 23);
            this.templatePathBtn.TabIndex = 46;
            this.templatePathBtn.Text = "...";
            this.templatePathBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.templatePathBtn.UseVisualStyleBackColor = true;
            this.templatePathBtn.Click += new System.EventHandler(this.templatePathBtn_Click);
            // 
            // templatePathTxtbox
            // 
            this.templatePathTxtbox.Location = new System.Drawing.Point(105, 82);
            this.templatePathTxtbox.Name = "templatePathTxtbox";
            this.templatePathTxtbox.Size = new System.Drawing.Size(311, 20);
            this.templatePathTxtbox.TabIndex = 45;
            // 
            // templatePathLbl
            // 
            this.templatePathLbl.Location = new System.Drawing.Point(19, 85);
            this.templatePathLbl.Name = "templatePathLbl";
            this.templatePathLbl.Size = new System.Drawing.Size(80, 13);
            this.templatePathLbl.TabIndex = 44;
            this.templatePathLbl.Text = "Template path:";
            // 
            // CodeGeneralOptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.templatePathBtn);
            this.Controls.Add(this.templatePathTxtbox);
            this.Controls.Add(this.templatePathLbl);
            this.Controls.Add(this.ouputPathBtn);
            this.Controls.Add(this.ouputPathTxtbox);
            this.Controls.Add(this.ouputPathLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generationLbl);
            this.Controls.Add(this.groupBox3);
            this.Name = "CodeGeneralOptionsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ouputPathTxtbox;
        private System.Windows.Forms.Label ouputPathLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label generationLbl;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ouputPathBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button templatePathBtn;
        private System.Windows.Forms.TextBox templatePathTxtbox;
        private System.Windows.Forms.Label templatePathLbl;
    }
}
