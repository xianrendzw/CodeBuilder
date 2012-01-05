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
            this.templatesLbl = new System.Windows.Forms.Label();
            this.topGbx = new System.Windows.Forms.GroupBox();
            this.templateListbox = new System.Windows.Forms.ListBox();
            this.engineCombox = new System.Windows.Forms.ComboBox();
            this.languageCombox = new System.Windows.Forms.ComboBox();
            this.removeBtn = new System.Windows.Forms.Button();
            this.newsaveBtn = new System.Windows.Forms.Button();
            this.fileNameTextbox = new System.Windows.Forms.TextBox();
            this.displayNameTxtbox = new System.Windows.Forms.TextBox();
            this.languageLbl = new System.Windows.Forms.Label();
            this.engineLbl = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.fileNameLbl = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.openFileDialogBtn = new System.Windows.Forms.Button();
            this.noteTextLbl = new System.Windows.Forms.Label();
            this.noteLbl = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.getItFromOnlineBtn = new System.Windows.Forms.Button();
            this.prefixTxtBox = new System.Windows.Forms.TextBox();
            this.prefixLbl = new System.Windows.Forms.Label();
            this.suffixLbl = new System.Windows.Forms.Label();
            this.suffixTxtBox = new System.Windows.Forms.TextBox();
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
            this.templateListbox.Location = new System.Drawing.Point(10, 30);
            this.templateListbox.Name = "templateListbox";
            this.templateListbox.Size = new System.Drawing.Size(160, 303);
            this.templateListbox.TabIndex = 1;
            this.templateListbox.SelectedIndexChanged += new System.EventHandler(this.templateListbox_SelectedIndexChanged);
            // 
            // engineCombox
            // 
            this.engineCombox.FormattingEnabled = true;
            this.engineCombox.Location = new System.Drawing.Point(262, 60);
            this.engineCombox.Name = "engineCombox";
            this.engineCombox.Size = new System.Drawing.Size(121, 21);
            this.engineCombox.TabIndex = 5;
            // 
            // languageCombox
            // 
            this.languageCombox.FormattingEnabled = true;
            this.languageCombox.Location = new System.Drawing.Point(262, 30);
            this.languageCombox.Name = "languageCombox";
            this.languageCombox.Size = new System.Drawing.Size(121, 21);
            this.languageCombox.TabIndex = 3;
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(291, 210);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(64, 23);
            this.removeBtn.TabIndex = 16;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // newsaveBtn
            // 
            this.newsaveBtn.Location = new System.Drawing.Point(361, 210);
            this.newsaveBtn.Name = "newsaveBtn";
            this.newsaveBtn.Size = new System.Drawing.Size(93, 23);
            this.newsaveBtn.TabIndex = 17;
            this.newsaveBtn.Text = "New/Save";
            this.newsaveBtn.UseVisualStyleBackColor = true;
            this.newsaveBtn.Click += new System.EventHandler(this.newsaveBtn_Click);
            // 
            // fileNameTextbox
            // 
            this.fileNameTextbox.Location = new System.Drawing.Point(262, 120);
            this.fileNameTextbox.Name = "fileNameTextbox";
            this.fileNameTextbox.Size = new System.Drawing.Size(164, 20);
            this.fileNameTextbox.TabIndex = 9;
            // 
            // displayNameTxtbox
            // 
            this.displayNameTxtbox.Location = new System.Drawing.Point(262, 90);
            this.displayNameTxtbox.MaxLength = 200;
            this.displayNameTxtbox.Name = "displayNameTxtbox";
            this.displayNameTxtbox.Size = new System.Drawing.Size(121, 20);
            this.displayNameTxtbox.TabIndex = 7;
            // 
            // languageLbl
            // 
            this.languageLbl.Location = new System.Drawing.Point(178, 30);
            this.languageLbl.Name = "languageLbl";
            this.languageLbl.Size = new System.Drawing.Size(80, 13);
            this.languageLbl.TabIndex = 2;
            this.languageLbl.Text = "Language:";
            // 
            // engineLbl
            // 
            this.engineLbl.Location = new System.Drawing.Point(178, 60);
            this.engineLbl.Name = "engineLbl";
            this.engineLbl.Size = new System.Drawing.Size(80, 13);
            this.engineLbl.TabIndex = 4;
            this.engineLbl.Text = "Engine:";
            // 
            // nameLbl
            // 
            this.nameLbl.Location = new System.Drawing.Point(178, 90);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(80, 13);
            this.nameLbl.TabIndex = 6;
            this.nameLbl.Text = "DisplayName:";
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.Location = new System.Drawing.Point(178, 120);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(80, 13);
            this.fileNameLbl.TabIndex = 8;
            this.fileNameLbl.Text = "File:";
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(228, 210);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(57, 23);
            this.editBtn.TabIndex = 15;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // openFileDialogBtn
            // 
            this.openFileDialogBtn.Location = new System.Drawing.Point(430, 118);
            this.openFileDialogBtn.Name = "openFileDialogBtn";
            this.openFileDialogBtn.Size = new System.Drawing.Size(24, 23);
            this.openFileDialogBtn.TabIndex = 10;
            this.openFileDialogBtn.Text = "...";
            this.openFileDialogBtn.UseVisualStyleBackColor = true;
            this.openFileDialogBtn.Click += new System.EventHandler(this.openFileDialogBtn_Click);
            // 
            // noteTextLbl
            // 
            this.noteTextLbl.Location = new System.Drawing.Point(246, 276);
            this.noteTextLbl.Name = "noteTextLbl";
            this.noteTextLbl.Size = new System.Drawing.Size(210, 60);
            this.noteTextLbl.TabIndex = 20;
            // 
            // noteLbl
            // 
            this.noteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(190, 275);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(50, 18);
            this.noteLbl.TabIndex = 19;
            this.noteLbl.Text = "Note:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Template Text File (*.txt)|*.txt";
            this.openFileDialog.Title = "Select Template Text File";
            // 
            // getItFromOnlineBtn
            // 
            this.getItFromOnlineBtn.Location = new System.Drawing.Point(228, 244);
            this.getItFromOnlineBtn.Name = "getItFromOnlineBtn";
            this.getItFromOnlineBtn.Size = new System.Drawing.Size(226, 23);
            this.getItFromOnlineBtn.TabIndex = 18;
            this.getItFromOnlineBtn.Text = "Get it from online";
            this.getItFromOnlineBtn.UseVisualStyleBackColor = true;
            this.getItFromOnlineBtn.Click += new System.EventHandler(this.getItFromOnlineBtn_Click);
            // 
            // prefixTxtBox
            // 
            this.prefixTxtBox.Location = new System.Drawing.Point(262, 150);
            this.prefixTxtBox.MaxLength = 200;
            this.prefixTxtBox.Name = "prefixTxtBox";
            this.prefixTxtBox.Size = new System.Drawing.Size(121, 20);
            this.prefixTxtBox.TabIndex = 12;
            // 
            // prefixLbl
            // 
            this.prefixLbl.Location = new System.Drawing.Point(178, 150);
            this.prefixLbl.Name = "prefixLbl";
            this.prefixLbl.Size = new System.Drawing.Size(80, 13);
            this.prefixLbl.TabIndex = 11;
            this.prefixLbl.Text = "Prefix:";
            // 
            // suffixLbl
            // 
            this.suffixLbl.Location = new System.Drawing.Point(178, 180);
            this.suffixLbl.Name = "suffixLbl";
            this.suffixLbl.Size = new System.Drawing.Size(80, 13);
            this.suffixLbl.TabIndex = 13;
            this.suffixLbl.Text = "Suffix:";
            // 
            // suffixTxtBox
            // 
            this.suffixTxtBox.Location = new System.Drawing.Point(262, 180);
            this.suffixTxtBox.MaxLength = 200;
            this.suffixTxtBox.Name = "suffixTxtBox";
            this.suffixTxtBox.Size = new System.Drawing.Size(121, 20);
            this.suffixTxtBox.TabIndex = 14;
            // 
            // TemplateOptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.suffixLbl);
            this.Controls.Add(this.suffixTxtBox);
            this.Controls.Add(this.prefixLbl);
            this.Controls.Add(this.prefixTxtBox);
            this.Controls.Add(this.getItFromOnlineBtn);
            this.Controls.Add(this.noteTextLbl);
            this.Controls.Add(this.noteLbl);
            this.Controls.Add(this.openFileDialogBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.fileNameLbl);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.engineLbl);
            this.Controls.Add(this.languageLbl);
            this.Controls.Add(this.displayNameTxtbox);
            this.Controls.Add(this.fileNameTextbox);
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
        private System.Windows.Forms.TextBox fileNameTextbox;
        private System.Windows.Forms.TextBox displayNameTxtbox;
        private System.Windows.Forms.Label languageLbl;
        private System.Windows.Forms.Label engineLbl;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label fileNameLbl;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button openFileDialogBtn;
        private System.Windows.Forms.Label noteTextLbl;
        private System.Windows.Forms.Label noteLbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button getItFromOnlineBtn;
        private System.Windows.Forms.TextBox prefixTxtBox;
        private System.Windows.Forms.Label prefixLbl;
        private System.Windows.Forms.Label suffixLbl;
        private System.Windows.Forms.TextBox suffixTxtBox;
    }
}
