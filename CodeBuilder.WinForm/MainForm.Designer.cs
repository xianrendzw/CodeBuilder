namespace CodeBuilder.WinForm
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileImportPdmMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileImportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSeparator1MenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsSettngsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsSeparator1MenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.toolsDSConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpF1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpSeparator1MenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.helpAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.openPDMFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.gbxResult = new System.Windows.Forms.GroupBox();
            this.gbxGenItems = new System.Windows.Forms.GroupBox();
            this.statusBarReady = new System.Windows.Forms.ToolStripStatusLabel();
            this.templatesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.toolsMenu,
            this.helpMenu});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(744, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileImportPdmMenuItem,
            this.fileImportMenuItem,
            this.fileSeparator1MenuItem,
            this.fileExitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "&File";
            // 
            // fileImportPdmMenuItem
            // 
            this.fileImportPdmMenuItem.Name = "fileImportPdmMenuItem";
            this.fileImportPdmMenuItem.Size = new System.Drawing.Size(282, 22);
            this.fileImportPdmMenuItem.Text = "Import From &PowerDesigner PDM File...";
            // 
            // fileImportMenuItem
            // 
            this.fileImportMenuItem.Name = "fileImportMenuItem";
            this.fileImportMenuItem.Size = new System.Drawing.Size(282, 22);
            this.fileImportMenuItem.Text = "&Import...";
            // 
            // fileSeparator1MenuItem
            // 
            this.fileSeparator1MenuItem.Name = "fileSeparator1MenuItem";
            this.fileSeparator1MenuItem.Size = new System.Drawing.Size(279, 6);
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            this.fileExitMenuItem.Size = new System.Drawing.Size(282, 22);
            this.fileExitMenuItem.Text = "&Exit";
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsSettngsMenuItem,
            this.toolsSeparator1MenuItem,
            this.toolsDSConfigMenuItem,
            this.templatesMenuItem});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(48, 20);
            this.toolsMenu.Text = "&Tools";
            // 
            // toolsSettngsMenuItem
            // 
            this.toolsSettngsMenuItem.Name = "toolsSettngsMenuItem";
            this.toolsSettngsMenuItem.Size = new System.Drawing.Size(220, 22);
            this.toolsSettngsMenuItem.Text = "&Settings...";
            // 
            // toolsSeparator1MenuItem
            // 
            this.toolsSeparator1MenuItem.Name = "toolsSeparator1MenuItem";
            this.toolsSeparator1MenuItem.Size = new System.Drawing.Size(217, 6);
            // 
            // toolsDSConfigMenuItem
            // 
            this.toolsDSConfigMenuItem.Name = "toolsDSConfigMenuItem";
            this.toolsDSConfigMenuItem.Size = new System.Drawing.Size(220, 22);
            this.toolsDSConfigMenuItem.Text = "&DataSource Configuration...";
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpF1MenuItem,
            this.helpSeparator1MenuItem,
            this.helpAboutMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "&Help";
            this.helpMenu.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // helpF1MenuItem
            // 
            this.helpF1MenuItem.Name = "helpF1MenuItem";
            this.helpF1MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpF1MenuItem.Size = new System.Drawing.Size(195, 22);
            this.helpF1MenuItem.Text = "CodeBuilder Help...";
            // 
            // helpSeparator1MenuItem
            // 
            this.helpSeparator1MenuItem.Name = "helpSeparator1MenuItem";
            this.helpSeparator1MenuItem.Size = new System.Drawing.Size(192, 6);
            // 
            // helpAboutMenuItem
            // 
            this.helpAboutMenuItem.Name = "helpAboutMenuItem";
            this.helpAboutMenuItem.Size = new System.Drawing.Size(195, 22);
            this.helpAboutMenuItem.Text = "About CodeBuilder...";
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarReady,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 430);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(744, 22);
            this.mainStatusStrip.TabIndex = 1;
            // 
            // openPDMFileDialog
            // 
            this.openPDMFileDialog.Filter = "Physical Data Model (*.pdm)|*.pdm";
            this.openPDMFileDialog.Title = "Open PowerDesigner PDM File";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gbxResult);
            this.splitContainer.Panel2.Controls.Add(this.gbxGenItems);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.splitContainer.Size = new System.Drawing.Size(744, 406);
            this.splitContainer.SplitterDistance = 206;
            this.splitContainer.TabIndex = 2;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(3, 3);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(200, 400);
            this.treeView.TabIndex = 0;
            // 
            // gbxResult
            // 
            this.gbxResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxResult.Location = new System.Drawing.Point(1, 268);
            this.gbxResult.Name = "gbxResult";
            this.gbxResult.Size = new System.Drawing.Size(532, 137);
            this.gbxResult.TabIndex = 0;
            this.gbxResult.TabStop = false;
            this.gbxResult.Text = "Results";
            // 
            // gbxGenItems
            // 
            this.gbxGenItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxGenItems.Location = new System.Drawing.Point(1, 3);
            this.gbxGenItems.Name = "gbxGenItems";
            this.gbxGenItems.Size = new System.Drawing.Size(531, 259);
            this.gbxGenItems.TabIndex = 0;
            this.gbxGenItems.TabStop = false;
            this.gbxGenItems.Text = "Generation Settings";
            // 
            // statusBarReady
            // 
            this.statusBarReady.Name = "statusBarReady";
            this.statusBarReady.Size = new System.Drawing.Size(257, 17);
            this.statusBarReady.Spring = true;
            this.statusBarReady.Text = "Ready";
            this.statusBarReady.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // templatesMenuItem
            // 
            this.templatesMenuItem.Name = "templatesMenuItem";
            this.templatesMenuItem.Size = new System.Drawing.Size(220, 22);
            this.templatesMenuItem.Text = "&Templates...";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 452);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(160, 38);
            this.Name = "MainForm";
            this.Text = "CodeBuilder";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsSettngsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem helpF1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpAboutMenuItem;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripSeparator helpSeparator1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileImportPdmMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileImportMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileSeparator1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolsSeparator1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsDSConfigMenuItem;
        private System.Windows.Forms.OpenFileDialog openPDMFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.GroupBox gbxGenItems;
        private System.Windows.Forms.GroupBox gbxResult;
        private System.Windows.Forms.ToolStripMenuItem templatesMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusBarReady;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    }
}

