namespace CodeBuilder.WinForm.UI.OptionsPages
{
    partial class TemplateOptionsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.templatesLbl = new System.Windows.Forms.Label();
            this.topGbx = new System.Windows.Forms.GroupBox();
            this.templateListbox = new System.Windows.Forms.ListBox();
            this.engineCombox = new System.Windows.Forms.ComboBox();
            this.languageCombox = new System.Windows.Forms.ComboBox();
            this.removeBtn = new System.Windows.Forms.Button();
            this.newsaveBtn = new System.Windows.Forms.Button();
            this.filePathTextbox = new System.Windows.Forms.TextBox();
            this.nameTxtbox = new System.Windows.Forms.TextBox();
            this.languageLbl = new System.Windows.Forms.Label();
            this.engineLbl = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.filePathLbl = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.openFileDialogBtn = new System.Windows.Forms.Button();
            this.noteTextLbl = new System.Windows.Forms.Label();
            this.noteLbl = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.getItFromOnlineBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // templatesLbl
            // 
            this.templatesLbl.Location = new System.Drawing.Point(9, 5);
            this.templatesLbl.Name = "templatesLbl";
            this.templatesLbl.Size = new System.Drawing.Size(60, 16);
            this.templatesLbl.TabIndex = 31;
            this.templatesLbl.Text = "Templates";
            // 
            // topGbx
            // 
            this.topGbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topGbx.Location = new System.Drawing.Point(80, 5);
            this.topGbx.Name = "topGbx";
            this.topGbx.Size = new System.Drawing.Size(370, 8);
            this.topGbx.TabIndex = 30;
            this.topGbx.TabStop = false;
            // 
            // templateListbox
            // 
            this.templateListbox.FormattingEnabled = true;
            this.templateListbox.Location = new System.Drawing.Point(12, 30);
            this.templateListbox.Name = "templateListbox";
            this.templateListbox.Size = new System.Drawing.Size(160, 303);
            this.templateListbox.TabIndex = 32;
            this.templateListbox.SelectedIndexChanged += new System.EventHandler(this.templateListbox_SelectedIndexChanged);
            // 
            // engineCombox
            // 
            this.engineCombox.FormattingEnabled = true;
            this.engineCombox.Location = new System.Drawing.Point(256, 65);
            this.engineCombox.Name = "engineCombox";
            this.engineCombox.Size = new System.Drawing.Size(121, 21);
            this.engineCombox.TabIndex = 33;
            // 
            // languageCombox
            // 
            this.languageCombox.FormattingEnabled = true;
            this.languageCombox.Location = new System.Drawing.Point(256, 30);
            this.languageCombox.Name = "languageCombox";
            this.languageCombox.Size = new System.Drawing.Size(121, 21);
            this.languageCombox.TabIndex = 34;
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(285, 170);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(64, 23);
            this.removeBtn.TabIndex = 35;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // newsaveBtn
            // 
            this.newsaveBtn.Location = new System.Drawing.Point(355, 170);
            this.newsaveBtn.Name = "newsaveBtn";
            this.newsaveBtn.Size = new System.Drawing.Size(93, 23);
            this.newsaveBtn.TabIndex = 36;
            this.newsaveBtn.Text = "New/Save";
            this.newsaveBtn.UseVisualStyleBackColor = true;
            this.newsaveBtn.Click += new System.EventHandler(this.newsaveBtn_Click);
            // 
            // filePathTextbox
            // 
            this.filePathTextbox.Location = new System.Drawing.Point(256, 135);
            this.filePathTextbox.Name = "filePathTextbox";
            this.filePathTextbox.Size = new System.Drawing.Size(164, 20);
            this.filePathTextbox.TabIndex = 37;
            // 
            // nameTxtbox
            // 
            this.nameTxtbox.Location = new System.Drawing.Point(256, 100);
            this.nameTxtbox.Name = "nameTxtbox";
            this.nameTxtbox.Size = new System.Drawing.Size(121, 20);
            this.nameTxtbox.TabIndex = 38;
            // 
            // languageLbl
            // 
            this.languageLbl.Location = new System.Drawing.Point(190, 30);
            this.languageLbl.Name = "languageLbl";
            this.languageLbl.Size = new System.Drawing.Size(60, 13);
            this.languageLbl.TabIndex = 39;
            this.languageLbl.Text = "Language:";
            // 
            // engineLbl
            // 
            this.engineLbl.Location = new System.Drawing.Point(190, 65);
            this.engineLbl.Name = "engineLbl";
            this.engineLbl.Size = new System.Drawing.Size(60, 13);
            this.engineLbl.TabIndex = 40;
            this.engineLbl.Text = "Engine:";
            // 
            // nameLbl
            // 
            this.nameLbl.Location = new System.Drawing.Point(190, 100);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(60, 13);
            this.nameLbl.TabIndex = 41;
            this.nameLbl.Text = "Name:";
            // 
            // filePathLbl
            // 
            this.filePathLbl.Location = new System.Drawing.Point(190, 135);
            this.filePathLbl.Name = "filePathLbl";
            this.filePathLbl.Size = new System.Drawing.Size(60, 13);
            this.filePathLbl.TabIndex = 42;
            this.filePathLbl.Text = "File Path:";
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(222, 170);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(57, 23);
            this.editBtn.TabIndex = 43;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // openFileDialogBtn
            // 
            this.openFileDialogBtn.Location = new System.Drawing.Point(424, 133);
            this.openFileDialogBtn.Name = "openFileDialogBtn";
            this.openFileDialogBtn.Size = new System.Drawing.Size(24, 23);
            this.openFileDialogBtn.TabIndex = 44;
            this.openFileDialogBtn.Text = "...";
            this.openFileDialogBtn.UseVisualStyleBackColor = true;
            this.openFileDialogBtn.Click += new System.EventHandler(this.openFileDialogBtn_Click);
            // 
            // noteTextLbl
            // 
            this.noteTextLbl.Location = new System.Drawing.Point(246, 242);
            this.noteTextLbl.Name = "noteTextLbl";
            this.noteTextLbl.Size = new System.Drawing.Size(202, 91);
            this.noteTextLbl.TabIndex = 46;
            // 
            // noteLbl
            // 
            this.noteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(190, 241);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(50, 18);
            this.noteLbl.TabIndex = 45;
            this.noteLbl.Text = "Note:";
            // 
            // getItFromOnlineBtn
            // 
            this.getItFromOnlineBtn.Location = new System.Drawing.Point(222, 204);
            this.getItFromOnlineBtn.Name = "getItFromOnlineBtn";
            this.getItFromOnlineBtn.Size = new System.Drawing.Size(226, 23);
            this.getItFromOnlineBtn.TabIndex = 47;
            this.getItFromOnlineBtn.Text = "Get it from online";
            this.getItFromOnlineBtn.UseVisualStyleBackColor = true;
            this.getItFromOnlineBtn.Click += new System.EventHandler(this.getItFromOnlineBtn_Click);
            // 
            // TemplateOptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.getItFromOnlineBtn);
            this.Controls.Add(this.noteTextLbl);
            this.Controls.Add(this.noteLbl);
            this.Controls.Add(this.openFileDialogBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.filePathLbl);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.engineLbl);
            this.Controls.Add(this.languageLbl);
            this.Controls.Add(this.nameTxtbox);
            this.Controls.Add(this.filePathTextbox);
            this.Controls.Add(this.newsaveBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.languageCombox);
            this.Controls.Add(this.engineCombox);
            this.Controls.Add(this.templateListbox);
            this.Controls.Add(this.templatesLbl);
            this.Controls.Add(this.topGbx);
            this.Name = "TemplateOptionsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label templatesLbl;
        private System.Windows.Forms.GroupBox topGbx;
        private System.Windows.Forms.ListBox templateListbox;
        private System.Windows.Forms.ComboBox engineCombox;
        private System.Windows.Forms.ComboBox languageCombox;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button newsaveBtn;
        private System.Windows.Forms.TextBox filePathTextbox;
        private System.Windows.Forms.TextBox nameTxtbox;
        private System.Windows.Forms.Label languageLbl;
        private System.Windows.Forms.Label engineLbl;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label filePathLbl;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button openFileDialogBtn;
        private System.Windows.Forms.Label noteTextLbl;
        private System.Windows.Forms.Label noteLbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button getItFromOnlineBtn;
    }
}
