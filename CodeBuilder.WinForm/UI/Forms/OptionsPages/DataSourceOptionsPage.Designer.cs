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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataSourceOptionsPage));
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
            resources.ApplyResources(this.datasourceLbl, "datasourceLbl");
            this.datasourceLbl.Name = "datasourceLbl";
            // 
            // topGbx
            // 
            resources.ApplyResources(this.topGbx, "topGbx");
            this.topGbx.Name = "topGbx";
            this.topGbx.TabStop = false;
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
            // connstrLbl
            // 
            resources.ApplyResources(this.connstrLbl, "connstrLbl");
            this.connstrLbl.Name = "connstrLbl";
            // 
            // nameLbl
            // 
            resources.ApplyResources(this.nameLbl, "nameLbl");
            this.nameLbl.Name = "nameLbl";
            // 
            // exporterLbl
            // 
            resources.ApplyResources(this.exporterLbl, "exporterLbl");
            this.exporterLbl.Name = "exporterLbl";
            // 
            // nameTxtbox
            // 
            resources.ApplyResources(this.nameTxtbox, "nameTxtbox");
            this.nameTxtbox.Name = "nameTxtbox";
            // 
            // connstrTxtbox
            // 
            resources.ApplyResources(this.connstrTxtbox, "connstrTxtbox");
            this.connstrTxtbox.Name = "connstrTxtbox";
            // 
            // newsaveBtn
            // 
            resources.ApplyResources(this.newsaveBtn, "newsaveBtn");
            this.newsaveBtn.Name = "newsaveBtn";
            this.newsaveBtn.UseVisualStyleBackColor = true;
            this.newsaveBtn.Click += new System.EventHandler(this.newsaveBtn_Click);
            // 
            // removeBtn
            // 
            resources.ApplyResources(this.removeBtn, "removeBtn");
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // exporterCombox
            // 
            this.exporterCombox.FormattingEnabled = true;
            resources.ApplyResources(this.exporterCombox, "exporterCombox");
            this.exporterCombox.Name = "exporterCombox";
            // 
            // datasourceListbox
            // 
            this.datasourceListbox.FormattingEnabled = true;
            resources.ApplyResources(this.datasourceListbox, "datasourceListbox");
            this.datasourceListbox.Name = "datasourceListbox";
            this.datasourceListbox.SelectedIndexChanged += new System.EventHandler(this.datasourceListbox_SelectedIndexChanged);
            // 
            // DataSourceOptionsPage
            // 
            resources.ApplyResources(this, "$this");
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
