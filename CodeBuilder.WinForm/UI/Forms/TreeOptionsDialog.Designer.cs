namespace CodeBuilder.WinForm.UI
{
    partial class TreeOptionsDialog
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

        #region Windows Form Designer generated displayName

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the displayName editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeOptionsDialog));
            this.buttomLineGbx = new System.Windows.Forms.GroupBox();
            this.pagePanel = new System.Windows.Forms.Panel();
            this.optionTreeView = new System.Windows.Forms.TreeView();
            this.treeNodeImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(592, 392);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(504, 392);
            // 
            // buttomLineGbx
            // 
            this.buttomLineGbx.Location = new System.Drawing.Point(208, 360);
            this.buttomLineGbx.Name = "buttomLineGbx";
            this.buttomLineGbx.Size = new System.Drawing.Size(456, 8);
            this.buttomLineGbx.TabIndex = 24;
            this.buttomLineGbx.TabStop = false;
            // 
            // pagePanel
            // 
            this.pagePanel.Location = new System.Drawing.Point(208, 16);
            this.pagePanel.Name = "pagePanel";
            this.pagePanel.Size = new System.Drawing.Size(456, 336);
            this.pagePanel.TabIndex = 23;
            // 
            // optionTreeView
            // 
            this.optionTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionTreeView.HideSelection = false;
            this.optionTreeView.Location = new System.Drawing.Point(16, 16);
            this.optionTreeView.Name = "optionTreeView";
            this.optionTreeView.PathSeparator = ".";
            this.optionTreeView.Size = new System.Drawing.Size(176, 350);
            this.optionTreeView.TabIndex = 22;
            this.optionTreeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.optionTreeView_AfterCollapse);
            this.optionTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.optionTreeView_AfterExpand);
            this.optionTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.optionTreeView_AfterSelect);
            // 
            // treeNodeImageList
            // 
            this.treeNodeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeNodeImageList.ImageStream")));
            this.treeNodeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeNodeImageList.Images.SetKeyName(0, "folderClosed.gif");
            this.treeNodeImageList.Images.SetKeyName(1, "folderOpen.gif");
            this.treeNodeImageList.Images.SetKeyName(2, "leaf.gif");
            // 
            // TreeOptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 426);
            this.Controls.Add(this.buttomLineGbx);
            this.Controls.Add(this.pagePanel);
            this.Controls.Add(this.optionTreeView);
            this.Name = "TreeOptionsDialog";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TreeOptionsDialog_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.optionTreeView, 0);
            this.Controls.SetChildIndex(this.pagePanel, 0);
            this.Controls.SetChildIndex(this.buttomLineGbx, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox buttomLineGbx;
        private System.Windows.Forms.Panel pagePanel;
        private System.Windows.Forms.TreeView optionTreeView;
        private System.Windows.Forms.ImageList treeNodeImageList;
    }
}