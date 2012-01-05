namespace CodeBuilder.WinForm.UI.OptionsPages
{
    partial class DataSourceOptionsPage
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
            this.datasourceLbl = new System.Windows.Forms.Label();
            this.topGbx = new System.Windows.Forms.GroupBox();
            this.noteTextLbl = new System.Windows.Forms.Label();
            this.noteLbl = new System.Windows.Forms.Label();
            this.connstrLbl = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.exporterLbl = new System.Windows.Forms.Label();
            this.nameTxtbox = new System.Windows.Forms.TextBox();
            this.connstrTxtbox = new System.Windows.Forms.TextBox();
            this.newsaveBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.exporterCombox = new System.Windows.Forms.ComboBox();
            this.datasourceListbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // datasourceLbl
            // 
            this.datasourceLbl.Location = new System.Drawing.Point(9, 5);
            this.datasourceLbl.Name = "datasourceLbl";
            this.datasourceLbl.Size = new System.Drawing.Size(80, 16);
            this.datasourceLbl.TabIndex = 39;
            this.datasourceLbl.Text = "DataSources";
            // 
            // topGbx
            // 
            this.topGbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topGbx.Location = new System.Drawing.Point(90, 5);
            this.topGbx.Name = "topGbx";
            this.topGbx.Size = new System.Drawing.Size(360, 8);
            this.topGbx.TabIndex = 38;
            this.topGbx.TabStop = false;
            // 
            // noteTextLbl
            // 
            this.noteTextLbl.Location = new System.Drawing.Point(246, 191);
            this.noteTextLbl.Name = "noteTextLbl";
            this.noteTextLbl.Size = new System.Drawing.Size(207, 142);
            this.noteTextLbl.TabIndex = 11;
            // 
            // noteLbl
            // 
            this.noteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(190, 191);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(50, 18);
            this.noteLbl.TabIndex = 10;
            this.noteLbl.Text = "Note:";
            // 
            // connstrLbl
            // 
            this.connstrLbl.Location = new System.Drawing.Point(190, 65);
            this.connstrLbl.Name = "connstrLbl";
            this.connstrLbl.Size = new System.Drawing.Size(80, 13);
            this.connstrLbl.TabIndex = 4;
            this.connstrLbl.Text = "ConnectString:";
            // 
            // nameLbl
            // 
            this.nameLbl.Location = new System.Drawing.Point(190, 30);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(60, 13);
            this.nameLbl.TabIndex = 2;
            this.nameLbl.Text = "Name:";
            // 
            // exporterLbl
            // 
            this.exporterLbl.Location = new System.Drawing.Point(190, 100);
            this.exporterLbl.Name = "exporterLbl";
            this.exporterLbl.Size = new System.Drawing.Size(60, 13);
            this.exporterLbl.TabIndex = 6;
            this.exporterLbl.Text = "Exporter:";
            // 
            // nameTxtbox
            // 
            this.nameTxtbox.Location = new System.Drawing.Point(274, 30);
            this.nameTxtbox.MaxLength = 200;
            this.nameTxtbox.Name = "nameTxtbox";
            this.nameTxtbox.Size = new System.Drawing.Size(179, 20);
            this.nameTxtbox.TabIndex = 3;
            // 
            // connstrTxtbox
            // 
            this.connstrTxtbox.Location = new System.Drawing.Point(274, 65);
            this.connstrTxtbox.MaxLength = 500;
            this.connstrTxtbox.Name = "connstrTxtbox";
            this.connstrTxtbox.Size = new System.Drawing.Size(179, 20);
            this.connstrTxtbox.TabIndex = 5;
            // 
            // newsaveBtn
            // 
            this.newsaveBtn.Location = new System.Drawing.Point(349, 141);
            this.newsaveBtn.Name = "newsaveBtn";
            this.newsaveBtn.Size = new System.Drawing.Size(104, 23);
            this.newsaveBtn.TabIndex = 9;
            this.newsaveBtn.Text = "New/Save";
            this.newsaveBtn.UseVisualStyleBackColor = true;
            this.newsaveBtn.Click += new System.EventHandler(this.newsaveBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(279, 141);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(64, 23);
            this.removeBtn.TabIndex = 8;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // exporterCombox
            // 
            this.exporterCombox.FormattingEnabled = true;
            this.exporterCombox.Location = new System.Drawing.Point(274, 100);
            this.exporterCombox.Name = "exporterCombox";
            this.exporterCombox.Size = new System.Drawing.Size(121, 21);
            this.exporterCombox.TabIndex = 7;
            // 
            // datasourceListbox
            // 
            this.datasourceListbox.FormattingEnabled = true;
            this.datasourceListbox.Location = new System.Drawing.Point(10, 30);
            this.datasourceListbox.Name = "datasourceListbox";
            this.datasourceListbox.Size = new System.Drawing.Size(160, 303);
            this.datasourceListbox.TabIndex = 1;
            this.datasourceListbox.SelectedIndexChanged += new System.EventHandler(this.datasourceListbox_SelectedIndexChanged);
            // 
            // DataSourceOptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.noteTextLbl);
            this.Controls.Add(this.noteLbl);
            this.Controls.Add(this.connstrLbl);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.exporterLbl);
            this.Controls.Add(this.nameTxtbox);
            this.Controls.Add(this.connstrTxtbox);
            this.Controls.Add(this.newsaveBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.exporterCombox);
            this.Controls.Add(this.datasourceListbox);
            this.Controls.Add(this.datasourceLbl);
            this.Controls.Add(this.topGbx);
            this.Name = "DataSourceOptionsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label datasourceLbl;
        private System.Windows.Forms.GroupBox topGbx;
        private System.Windows.Forms.Label noteTextLbl;
        private System.Windows.Forms.Label noteLbl;
        private System.Windows.Forms.Label connstrLbl;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label exporterLbl;
        private System.Windows.Forms.TextBox nameTxtbox;
        private System.Windows.Forms.TextBox connstrTxtbox;
        private System.Windows.Forms.Button newsaveBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.ComboBox exporterCombox;
        private System.Windows.Forms.ListBox datasourceListbox;
    }
}
