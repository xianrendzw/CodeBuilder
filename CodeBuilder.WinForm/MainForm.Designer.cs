﻿namespace CodeBuilder.WinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExportPdmMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExportDataSourceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSeparator2MenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSeparator1MenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsDSConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsTemplatesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsSeparator1MenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.toolsOptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpF1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpFeedbackMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpSeparator1MenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.helpAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusBarReady = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarLanguage = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarEncoding = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.treeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportPDMCtxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataSourceCtxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearCtxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeNodeImageList = new System.Windows.Forms.ImageList(this.components);
            this.resultGbx = new System.Windows.Forms.GroupBox();
            this.errorFileCountLbl = new System.Windows.Forms.Label();
            this.errorFilesLbl = new System.Windows.Forms.Label();
            this.genFileCountLbl = new System.Windows.Forms.Label();
            this.genFilesLbl = new System.Windows.Forms.Label();
            this.completedLbl = new System.Windows.Forms.Label();
            this.totalFileCountLbl = new System.Windows.Forms.Label();
            this.totalFilesLbl = new System.Windows.Forms.Label();
            this.currentGenFileNameLbl = new System.Windows.Forms.Label();
            this.currentGenFileLbl = new System.Windows.Forms.Label();
            this.genProgressBar = new System.Windows.Forms.ProgressBar();
            this.genItemsGbx = new System.Windows.Forms.GroupBox();
            this.genSettingsCtxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openGenSettingsCtxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGenSettingCtxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genSettingsCtxSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generateCtxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateListBox = new System.Windows.Forms.ListBox();
            this.databaseNameLbl = new System.Windows.Forms.Label();
            this.databaseLbl = new System.Windows.Forms.Label();
            this.templateEngineCombox = new System.Windows.Forms.ComboBox();
            this.templateEngineLbl = new System.Windows.Forms.Label();
            this.isStandardizeNameChkbox = new System.Windows.Forms.CheckBox();
            this.isOmitTablePrefixChkbox = new System.Windows.Forms.CheckBox();
            this.codeFileEncodingCombox = new System.Windows.Forms.ComboBox();
            this.codeFileEncodingLbl = new System.Windows.Forms.Label();
            this.languageCombx = new System.Windows.Forms.ComboBox();
            this.languageLbl = new System.Windows.Forms.Label();
            this.templateLbl = new System.Windows.Forms.Label();
            this.versionTxtBox = new System.Windows.Forms.TextBox();
            this.versionLbl = new System.Windows.Forms.Label();
            this.authorTxtBox = new System.Windows.Forms.TextBox();
            this.authorLbl = new System.Windows.Forms.Label();
            this.tablePrefixTxtBox = new System.Windows.Forms.TextBox();
            this.tablePrefixLbl = new System.Windows.Forms.Label();
            this.packageTxtBox = new System.Windows.Forms.TextBox();
            this.packageLabel = new System.Windows.Forms.Label();
            this.saveSettingsBtn = new System.Windows.Forms.Button();
            this.generateBtn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.codeGeneration = new CodeBuilder.WinForm.UI.CodeGeneration(this.components);
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.treeViewContextMenu.SuspendLayout();
            this.resultGbx.SuspendLayout();
            this.genItemsGbx.SuspendLayout();
            this.genSettingsCtxMenuStrip.SuspendLayout();
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
            this.mainMenuStrip.Size = new System.Drawing.Size(752, 25);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileExportPdmMenuItem,
            this.fileExportDataSourceMenuItem,
            this.fileSeparator2MenuItem,
            this.fileOpenMenuItem,
            this.fileSaveMenuItem,
            this.fileSeparator1MenuItem,
            this.fileExitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(39, 21);
            this.fileMenu.Text = "&File";
            // 
            // fileExportPdmMenuItem
            // 
            this.fileExportPdmMenuItem.Name = "fileExportPdmMenuItem";
            this.fileExportPdmMenuItem.Size = new System.Drawing.Size(276, 22);
            this.fileExportPdmMenuItem.Text = "Export &PowerDesigner PDM Files...";
            this.fileExportPdmMenuItem.Click += new System.EventHandler(this.fileExportPdmMenuItem_Click);
            // 
            // fileExportDataSourceMenuItem
            // 
            this.fileExportDataSourceMenuItem.Name = "fileExportDataSourceMenuItem";
            this.fileExportDataSourceMenuItem.Size = new System.Drawing.Size(276, 22);
            this.fileExportDataSourceMenuItem.Text = "&Export From DataSource";
            this.fileExportDataSourceMenuItem.MouseHover += new System.EventHandler(this.fileExportDataSourceMenuItem_MouseHover);
            // 
            // fileSeparator2MenuItem
            // 
            this.fileSeparator2MenuItem.Name = "fileSeparator2MenuItem";
            this.fileSeparator2MenuItem.Size = new System.Drawing.Size(273, 6);
            // 
            // fileOpenMenuItem
            // 
            this.fileOpenMenuItem.Name = "fileOpenMenuItem";
            this.fileOpenMenuItem.Size = new System.Drawing.Size(276, 22);
            this.fileOpenMenuItem.Text = "&Open Generation Settings File";
            this.fileOpenMenuItem.Click += new System.EventHandler(this.fileOpenMenuItem_Click);
            // 
            // fileSaveMenuItem
            // 
            this.fileSaveMenuItem.Name = "fileSaveMenuItem";
            this.fileSaveMenuItem.Size = new System.Drawing.Size(276, 22);
            this.fileSaveMenuItem.Text = "&Save Generation Setting...";
            this.fileSaveMenuItem.Click += new System.EventHandler(this.fileSaveMenuItem_Click);
            // 
            // fileSeparator1MenuItem
            // 
            this.fileSeparator1MenuItem.Name = "fileSeparator1MenuItem";
            this.fileSeparator1MenuItem.Size = new System.Drawing.Size(273, 6);
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            this.fileExitMenuItem.Size = new System.Drawing.Size(276, 22);
            this.fileExitMenuItem.Text = "&Exit";
            this.fileExitMenuItem.Click += new System.EventHandler(this.fileExitMenuItem_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsDSConfigMenuItem,
            this.toolsTemplatesMenuItem,
            this.toolsSeparator1MenuItem,
            this.toolsOptionsMenuItem});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(52, 21);
            this.toolsMenu.Text = "&Tools";
            // 
            // toolsDSConfigMenuItem
            // 
            this.toolsDSConfigMenuItem.Name = "toolsDSConfigMenuItem";
            this.toolsDSConfigMenuItem.Size = new System.Drawing.Size(235, 22);
            this.toolsDSConfigMenuItem.Text = "&DataSource Configuration...";
            this.toolsDSConfigMenuItem.Click += new System.EventHandler(this.toolsDSConfigMenuItem_Click);
            // 
            // toolsTemplatesMenuItem
            // 
            this.toolsTemplatesMenuItem.Name = "toolsTemplatesMenuItem";
            this.toolsTemplatesMenuItem.Size = new System.Drawing.Size(235, 22);
            this.toolsTemplatesMenuItem.Text = "&Templates...";
            this.toolsTemplatesMenuItem.Click += new System.EventHandler(this.toolsTemplatesMenuItem_Click);
            // 
            // toolsSeparator1MenuItem
            // 
            this.toolsSeparator1MenuItem.Name = "toolsSeparator1MenuItem";
            this.toolsSeparator1MenuItem.Size = new System.Drawing.Size(232, 6);
            // 
            // toolsOptionsMenuItem
            // 
            this.toolsOptionsMenuItem.Name = "toolsOptionsMenuItem";
            this.toolsOptionsMenuItem.Size = new System.Drawing.Size(235, 22);
            this.toolsOptionsMenuItem.Text = "&Options...";
            this.toolsOptionsMenuItem.Click += new System.EventHandler(this.toolsOptionsMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpF1MenuItem,
            this.helpFeedbackMenuItem,
            this.helpSeparator1MenuItem,
            this.helpAboutMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(47, 21);
            this.helpMenu.Text = "&Help";
            this.helpMenu.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // helpF1MenuItem
            // 
            this.helpF1MenuItem.Name = "helpF1MenuItem";
            this.helpF1MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpF1MenuItem.Size = new System.Drawing.Size(209, 22);
            this.helpF1MenuItem.Text = "CodeBuilder Help...";
            this.helpF1MenuItem.Click += new System.EventHandler(this.helpF1MenuItem_Click);
            // 
            // helpFeedbackMenuItem
            // 
            this.helpFeedbackMenuItem.Name = "helpFeedbackMenuItem";
            this.helpFeedbackMenuItem.Size = new System.Drawing.Size(209, 22);
            this.helpFeedbackMenuItem.Text = "Customer Feedback...";
            this.helpFeedbackMenuItem.Click += new System.EventHandler(this.helpFeedbackMenuItem_Click);
            // 
            // helpSeparator1MenuItem
            // 
            this.helpSeparator1MenuItem.Name = "helpSeparator1MenuItem";
            this.helpSeparator1MenuItem.Size = new System.Drawing.Size(206, 6);
            // 
            // helpAboutMenuItem
            // 
            this.helpAboutMenuItem.Name = "helpAboutMenuItem";
            this.helpAboutMenuItem.Size = new System.Drawing.Size(209, 22);
            this.helpAboutMenuItem.Text = "About CodeBuilder...";
            this.helpAboutMenuItem.Click += new System.EventHandler(this.helpAboutMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarReady,
            this.statusBarDatabase,
            this.statusBarLanguage,
            this.statusBarEncoding});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 405);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(752, 22);
            this.mainStatusStrip.TabIndex = 1;
            // 
            // statusBarReady
            // 
            this.statusBarReady.AutoSize = false;
            this.statusBarReady.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusBarReady.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.statusBarReady.Name = "statusBarReady";
            this.statusBarReady.Size = new System.Drawing.Size(437, 19);
            this.statusBarReady.Spring = true;
            this.statusBarReady.Text = "Ready";
            this.statusBarReady.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusBarDatabase
            // 
            this.statusBarDatabase.AutoSize = false;
            this.statusBarDatabase.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusBarDatabase.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.statusBarDatabase.Name = "statusBarDatabase";
            this.statusBarDatabase.Size = new System.Drawing.Size(120, 19);
            // 
            // statusBarLanguage
            // 
            this.statusBarLanguage.AutoSize = false;
            this.statusBarLanguage.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusBarLanguage.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.statusBarLanguage.Name = "statusBarLanguage";
            this.statusBarLanguage.Size = new System.Drawing.Size(100, 19);
            // 
            // statusBarEncoding
            // 
            this.statusBarEncoding.AutoSize = false;
            this.statusBarEncoding.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusBarEncoding.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarEncoding.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.statusBarEncoding.Name = "statusBarEncoding";
            this.statusBarEncoding.Size = new System.Drawing.Size(80, 19);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer.Panel1MinSize = 206;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.resultGbx);
            this.splitContainer.Panel2.Controls.Add(this.genItemsGbx);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.splitContainer.Size = new System.Drawing.Size(752, 380);
            this.splitContainer.SplitterDistance = 208;
            this.splitContainer.TabIndex = 2;
            // 
            // treeView
            // 
            this.treeView.CheckBoxes = true;
            this.treeView.ContextMenuStrip = this.treeViewContextMenu;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.treeNodeImageList;
            this.treeView.Location = new System.Drawing.Point(3, 3);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(202, 374);
            this.treeView.TabIndex = 2;
            this.treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCheck);
            this.treeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCollapse);
            this.treeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterExpand);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // treeViewContextMenu
            // 
            this.treeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportPDMCtxMenuItem,
            this.exportDataSourceCtxMenuItem,
            this.ctxSeparator2,
            this.clearCtxMenuItem});
            this.treeViewContextMenu.Name = "treeViewContextMenu";
            this.treeViewContextMenu.Size = new System.Drawing.Size(242, 76);
            // 
            // exportPDMCtxMenuItem
            // 
            this.exportPDMCtxMenuItem.Name = "exportPDMCtxMenuItem";
            this.exportPDMCtxMenuItem.Size = new System.Drawing.Size(241, 22);
            this.exportPDMCtxMenuItem.Text = "Export PowerDesigner PDM Files...";
            this.exportPDMCtxMenuItem.Click += new System.EventHandler(this.exportPDMCtxMenuItem_Click);
            // 
            // exportDataSourceCtxMenuItem
            // 
            this.exportDataSourceCtxMenuItem.Name = "exportDataSourceCtxMenuItem";
            this.exportDataSourceCtxMenuItem.Size = new System.Drawing.Size(241, 22);
            this.exportDataSourceCtxMenuItem.Text = "Export From DataSource";
            this.exportDataSourceCtxMenuItem.MouseHover += new System.EventHandler(this.exportDataSourceCtxMenuItem_MouseHover);
            // 
            // ctxSeparator2
            // 
            this.ctxSeparator2.Name = "ctxSeparator2";
            this.ctxSeparator2.Size = new System.Drawing.Size(238, 6);
            // 
            // clearCtxMenuItem
            // 
            this.clearCtxMenuItem.Enabled = false;
            this.clearCtxMenuItem.Name = "clearCtxMenuItem";
            this.clearCtxMenuItem.Size = new System.Drawing.Size(241, 22);
            this.clearCtxMenuItem.Text = "Clear";
            this.clearCtxMenuItem.Click += new System.EventHandler(this.clearCtxMenuItem_Click);
            // 
            // treeNodeImageList
            // 
            this.treeNodeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeNodeImageList.ImageStream")));
            this.treeNodeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeNodeImageList.Images.SetKeyName(0, "folderClosed.gif");
            this.treeNodeImageList.Images.SetKeyName(1, "folderOpen.gif");
            this.treeNodeImageList.Images.SetKeyName(2, "leaf.gif");
            // 
            // resultGbx
            // 
            this.resultGbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultGbx.Controls.Add(this.errorFileCountLbl);
            this.resultGbx.Controls.Add(this.errorFilesLbl);
            this.resultGbx.Controls.Add(this.genFileCountLbl);
            this.resultGbx.Controls.Add(this.genFilesLbl);
            this.resultGbx.Controls.Add(this.completedLbl);
            this.resultGbx.Controls.Add(this.totalFileCountLbl);
            this.resultGbx.Controls.Add(this.totalFilesLbl);
            this.resultGbx.Controls.Add(this.currentGenFileNameLbl);
            this.resultGbx.Controls.Add(this.currentGenFileLbl);
            this.resultGbx.Controls.Add(this.genProgressBar);
            this.resultGbx.Location = new System.Drawing.Point(1, 254);
            this.resultGbx.Name = "resultGbx";
            this.resultGbx.Size = new System.Drawing.Size(538, 123);
            this.resultGbx.TabIndex = 0;
            this.resultGbx.TabStop = false;
            this.resultGbx.Text = "Results";
            // 
            // errorFileCountLbl
            // 
            this.errorFileCountLbl.Location = new System.Drawing.Point(399, 55);
            this.errorFileCountLbl.Name = "errorFileCountLbl";
            this.errorFileCountLbl.Size = new System.Drawing.Size(50, 12);
            this.errorFileCountLbl.TabIndex = 9;
            // 
            // errorFilesLbl
            // 
            this.errorFilesLbl.Location = new System.Drawing.Point(329, 55);
            this.errorFilesLbl.Name = "errorFilesLbl";
            this.errorFilesLbl.Size = new System.Drawing.Size(60, 12);
            this.errorFilesLbl.TabIndex = 8;
            this.errorFilesLbl.Text = "Error files:";
            // 
            // genFileCountLbl
            // 
            this.genFileCountLbl.Location = new System.Drawing.Point(260, 55);
            this.genFileCountLbl.Name = "genFileCountLbl";
            this.genFileCountLbl.Size = new System.Drawing.Size(50, 12);
            this.genFileCountLbl.TabIndex = 7;
            // 
            // genFilesLbl
            // 
            this.genFilesLbl.Location = new System.Drawing.Point(161, 55);
            this.genFilesLbl.Name = "genFilesLbl";
            this.genFilesLbl.Size = new System.Drawing.Size(90, 12);
            this.genFilesLbl.TabIndex = 6;
            this.genFilesLbl.Text = "Generated files:";
            // 
            // completedLbl
            // 
            this.completedLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.completedLbl.Location = new System.Drawing.Point(469, 55);
            this.completedLbl.Name = "completedLbl";
            this.completedLbl.Size = new System.Drawing.Size(60, 12);
            this.completedLbl.TabIndex = 5;
            this.completedLbl.Text = "Completed!";
            this.completedLbl.Visible = false;
            // 
            // totalFileCountLbl
            // 
            this.totalFileCountLbl.Location = new System.Drawing.Point(98, 55);
            this.totalFileCountLbl.Name = "totalFileCountLbl";
            this.totalFileCountLbl.Size = new System.Drawing.Size(50, 12);
            this.totalFileCountLbl.TabIndex = 4;
            // 
            // totalFilesLbl
            // 
            this.totalFilesLbl.Location = new System.Drawing.Point(10, 55);
            this.totalFilesLbl.Name = "totalFilesLbl";
            this.totalFilesLbl.Size = new System.Drawing.Size(80, 12);
            this.totalFilesLbl.TabIndex = 3;
            this.totalFilesLbl.Text = "Total files:";
            // 
            // currentGenFileNameLbl
            // 
            this.currentGenFileNameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.currentGenFileNameLbl.Cursor = System.Windows.Forms.Cursors.Default;
            this.currentGenFileNameLbl.Location = new System.Drawing.Point(129, 78);
            this.currentGenFileNameLbl.Name = "currentGenFileNameLbl";
            this.currentGenFileNameLbl.Size = new System.Drawing.Size(398, 34);
            this.currentGenFileNameLbl.TabIndex = 2;
            this.currentGenFileNameLbl.Click += new System.EventHandler(this.currentGenFileNameLbl_Click);
            // 
            // currentGenFileLbl
            // 
            this.currentGenFileLbl.Location = new System.Drawing.Point(10, 78);
            this.currentGenFileLbl.Name = "currentGenFileLbl";
            this.currentGenFileLbl.Size = new System.Drawing.Size(113, 12);
            this.currentGenFileLbl.TabIndex = 1;
            this.currentGenFileLbl.Text = "Current generating file:";
            // 
            // genProgressBar
            // 
            this.genProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.genProgressBar.Location = new System.Drawing.Point(10, 24);
            this.genProgressBar.Name = "genProgressBar";
            this.genProgressBar.Size = new System.Drawing.Size(519, 21);
            this.genProgressBar.TabIndex = 0;
            // 
            // genItemsGbx
            // 
            this.genItemsGbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.genItemsGbx.ContextMenuStrip = this.genSettingsCtxMenuStrip;
            this.genItemsGbx.Controls.Add(this.templateListBox);
            this.genItemsGbx.Controls.Add(this.databaseNameLbl);
            this.genItemsGbx.Controls.Add(this.databaseLbl);
            this.genItemsGbx.Controls.Add(this.templateEngineCombox);
            this.genItemsGbx.Controls.Add(this.templateEngineLbl);
            this.genItemsGbx.Controls.Add(this.isStandardizeNameChkbox);
            this.genItemsGbx.Controls.Add(this.isOmitTablePrefixChkbox);
            this.genItemsGbx.Controls.Add(this.codeFileEncodingCombox);
            this.genItemsGbx.Controls.Add(this.codeFileEncodingLbl);
            this.genItemsGbx.Controls.Add(this.languageCombx);
            this.genItemsGbx.Controls.Add(this.languageLbl);
            this.genItemsGbx.Controls.Add(this.templateLbl);
            this.genItemsGbx.Controls.Add(this.versionTxtBox);
            this.genItemsGbx.Controls.Add(this.versionLbl);
            this.genItemsGbx.Controls.Add(this.authorTxtBox);
            this.genItemsGbx.Controls.Add(this.authorLbl);
            this.genItemsGbx.Controls.Add(this.tablePrefixTxtBox);
            this.genItemsGbx.Controls.Add(this.tablePrefixLbl);
            this.genItemsGbx.Controls.Add(this.packageTxtBox);
            this.genItemsGbx.Controls.Add(this.packageLabel);
            this.genItemsGbx.Controls.Add(this.saveSettingsBtn);
            this.genItemsGbx.Controls.Add(this.generateBtn);
            this.genItemsGbx.Location = new System.Drawing.Point(1, 3);
            this.genItemsGbx.Name = "genItemsGbx";
            this.genItemsGbx.Size = new System.Drawing.Size(538, 247);
            this.genItemsGbx.TabIndex = 3;
            this.genItemsGbx.TabStop = false;
            this.genItemsGbx.Text = "Generation Settings";
            // 
            // genSettingsCtxMenuStrip
            // 
            this.genSettingsCtxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGenSettingsCtxMenuItem,
            this.saveGenSettingCtxMenuItem,
            this.genSettingsCtxSeparator1,
            this.generateCtxMenuItem});
            this.genSettingsCtxMenuStrip.Name = "genSettingsCtxMenuStrip";
            this.genSettingsCtxMenuStrip.Size = new System.Drawing.Size(230, 76);
            // 
            // openGenSettingsCtxMenuItem
            // 
            this.openGenSettingsCtxMenuItem.Name = "openGenSettingsCtxMenuItem";
            this.openGenSettingsCtxMenuItem.Size = new System.Drawing.Size(229, 22);
            this.openGenSettingsCtxMenuItem.Text = "Open Generation Settings File...";
            this.openGenSettingsCtxMenuItem.Click += new System.EventHandler(this.openGenSettingsCtxMenuItem_Click);
            // 
            // saveGenSettingCtxMenuItem
            // 
            this.saveGenSettingCtxMenuItem.Name = "saveGenSettingCtxMenuItem";
            this.saveGenSettingCtxMenuItem.Size = new System.Drawing.Size(229, 22);
            this.saveGenSettingCtxMenuItem.Text = "Save Generation Setting...";
            this.saveGenSettingCtxMenuItem.Click += new System.EventHandler(this.saveGenSettingCtxMenuItem_Click);
            // 
            // genSettingsCtxSeparator1
            // 
            this.genSettingsCtxSeparator1.Name = "genSettingsCtxSeparator1";
            this.genSettingsCtxSeparator1.Size = new System.Drawing.Size(226, 6);
            // 
            // generateCtxMenuItem
            // 
            this.generateCtxMenuItem.Name = "generateCtxMenuItem";
            this.generateCtxMenuItem.Size = new System.Drawing.Size(229, 22);
            this.generateCtxMenuItem.Text = "Generate";
            this.generateCtxMenuItem.Click += new System.EventHandler(this.generateCtxMenuItem_Click);
            // 
            // templateListBox
            // 
            this.templateListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.templateListBox.FormattingEnabled = true;
            this.templateListBox.ItemHeight = 12;
            this.templateListBox.Location = new System.Drawing.Point(357, 113);
            this.templateListBox.Name = "templateListBox";
            this.templateListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.templateListBox.Size = new System.Drawing.Size(150, 88);
            this.templateListBox.TabIndex = 19;
            // 
            // databaseNameLbl
            // 
            this.databaseNameLbl.Location = new System.Drawing.Point(86, 24);
            this.databaseNameLbl.Name = "databaseNameLbl";
            this.databaseNameLbl.Size = new System.Drawing.Size(150, 12);
            this.databaseNameLbl.TabIndex = 5;
            // 
            // databaseLbl
            // 
            this.databaseLbl.Location = new System.Drawing.Point(10, 24);
            this.databaseLbl.Name = "databaseLbl";
            this.databaseLbl.Size = new System.Drawing.Size(70, 12);
            this.databaseLbl.TabIndex = 4;
            this.databaseLbl.Text = "Database:";
            // 
            // templateEngineCombox
            // 
            this.templateEngineCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateEngineCombox.FormattingEnabled = true;
            this.templateEngineCombox.Location = new System.Drawing.Point(120, 113);
            this.templateEngineCombox.Name = "templateEngineCombox";
            this.templateEngineCombox.Size = new System.Drawing.Size(116, 20);
            this.templateEngineCombox.TabIndex = 17;
            this.templateEngineCombox.SelectedIndexChanged += new System.EventHandler(this.templateEngineCombox_SelectedIndexChanged);
            // 
            // templateEngineLbl
            // 
            this.templateEngineLbl.Location = new System.Drawing.Point(10, 121);
            this.templateEngineLbl.Name = "templateEngineLbl";
            this.templateEngineLbl.Size = new System.Drawing.Size(104, 12);
            this.templateEngineLbl.TabIndex = 16;
            this.templateEngineLbl.Text = "Template Engine:";
            // 
            // isStandardizeNameChkbox
            // 
            this.isStandardizeNameChkbox.Location = new System.Drawing.Point(10, 216);
            this.isStandardizeNameChkbox.Name = "isStandardizeNameChkbox";
            this.isStandardizeNameChkbox.Size = new System.Drawing.Size(210, 16);
            this.isStandardizeNameChkbox.TabIndex = 23;
            this.isStandardizeNameChkbox.Text = "Is Standardize Table And Field Name";
            this.isStandardizeNameChkbox.UseVisualStyleBackColor = true;
            // 
            // isOmitTablePrefixChkbox
            // 
            this.isOmitTablePrefixChkbox.Location = new System.Drawing.Point(10, 185);
            this.isOmitTablePrefixChkbox.Name = "isOmitTablePrefixChkbox";
            this.isOmitTablePrefixChkbox.Size = new System.Drawing.Size(130, 16);
            this.isOmitTablePrefixChkbox.TabIndex = 22;
            this.isOmitTablePrefixChkbox.Text = "Is Omit Table Prefix";
            this.isOmitTablePrefixChkbox.UseVisualStyleBackColor = true;
            // 
            // codeFileEncodingCombox
            // 
            this.codeFileEncodingCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codeFileEncodingCombox.FormattingEnabled = true;
            this.codeFileEncodingCombox.Location = new System.Drawing.Point(120, 146);
            this.codeFileEncodingCombox.Name = "codeFileEncodingCombox";
            this.codeFileEncodingCombox.Size = new System.Drawing.Size(116, 20);
            this.codeFileEncodingCombox.TabIndex = 21;
            this.codeFileEncodingCombox.SelectedIndexChanged += new System.EventHandler(this.codeFileEncodingCombox_SelectedIndexChanged);
            // 
            // codeFileEncodingLbl
            // 
            this.codeFileEncodingLbl.Location = new System.Drawing.Point(10, 153);
            this.codeFileEncodingLbl.Name = "codeFileEncodingLbl";
            this.codeFileEncodingLbl.Size = new System.Drawing.Size(110, 12);
            this.codeFileEncodingLbl.TabIndex = 20;
            this.codeFileEncodingLbl.Text = "Encoding:";
            // 
            // languageCombx
            // 
            this.languageCombx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.languageCombx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageCombx.FormattingEnabled = true;
            this.languageCombx.Location = new System.Drawing.Point(357, 18);
            this.languageCombx.Name = "languageCombx";
            this.languageCombx.Size = new System.Drawing.Size(150, 20);
            this.languageCombx.TabIndex = 7;
            this.languageCombx.SelectedIndexChanged += new System.EventHandler(this.languageCombx_SelectedIndexChanged);
            // 
            // languageLbl
            // 
            this.languageLbl.Location = new System.Drawing.Point(270, 24);
            this.languageLbl.Name = "languageLbl";
            this.languageLbl.Size = new System.Drawing.Size(70, 12);
            this.languageLbl.TabIndex = 6;
            this.languageLbl.Text = "Language:";
            // 
            // templateLbl
            // 
            this.templateLbl.Location = new System.Drawing.Point(270, 121);
            this.templateLbl.Name = "templateLbl";
            this.templateLbl.Size = new System.Drawing.Size(70, 12);
            this.templateLbl.TabIndex = 18;
            this.templateLbl.Text = "Template:";
            // 
            // versionTxtBox
            // 
            this.versionTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.versionTxtBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.versionTxtBox.Location = new System.Drawing.Point(357, 82);
            this.versionTxtBox.MaxLength = 100;
            this.versionTxtBox.Name = "versionTxtBox";
            this.versionTxtBox.Size = new System.Drawing.Size(150, 21);
            this.versionTxtBox.TabIndex = 15;
            // 
            // versionLbl
            // 
            this.versionLbl.Location = new System.Drawing.Point(270, 89);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(70, 12);
            this.versionLbl.TabIndex = 14;
            this.versionLbl.Text = "Version:";
            // 
            // authorTxtBox
            // 
            this.authorTxtBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.authorTxtBox.Location = new System.Drawing.Point(86, 82);
            this.authorTxtBox.MaxLength = 100;
            this.authorTxtBox.Name = "authorTxtBox";
            this.authorTxtBox.Size = new System.Drawing.Size(150, 21);
            this.authorTxtBox.TabIndex = 13;
            // 
            // authorLbl
            // 
            this.authorLbl.Location = new System.Drawing.Point(10, 89);
            this.authorLbl.Name = "authorLbl";
            this.authorLbl.Size = new System.Drawing.Size(70, 12);
            this.authorLbl.TabIndex = 12;
            this.authorLbl.Text = "Author:";
            // 
            // tablePrefixTxtBox
            // 
            this.tablePrefixTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePrefixTxtBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tablePrefixTxtBox.Location = new System.Drawing.Point(357, 51);
            this.tablePrefixTxtBox.MaxLength = 50;
            this.tablePrefixTxtBox.Name = "tablePrefixTxtBox";
            this.tablePrefixTxtBox.Size = new System.Drawing.Size(150, 21);
            this.tablePrefixTxtBox.TabIndex = 11;
            // 
            // tablePrefixLbl
            // 
            this.tablePrefixLbl.Location = new System.Drawing.Point(270, 57);
            this.tablePrefixLbl.Name = "tablePrefixLbl";
            this.tablePrefixLbl.Size = new System.Drawing.Size(70, 12);
            this.tablePrefixLbl.TabIndex = 10;
            this.tablePrefixLbl.Text = "Table Prefix:";
            // 
            // packageTxtBox
            // 
            this.packageTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.packageTxtBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.packageTxtBox.Location = new System.Drawing.Point(86, 50);
            this.packageTxtBox.MaxLength = 200;
            this.packageTxtBox.Name = "packageTxtBox";
            this.packageTxtBox.Size = new System.Drawing.Size(150, 20);
            this.packageTxtBox.TabIndex = 9;
            // 
            // packageLabel
            // 
            this.packageLabel.Location = new System.Drawing.Point(10, 56);
            this.packageLabel.Name = "packageLabel";
            this.packageLabel.Size = new System.Drawing.Size(70, 12);
            this.packageLabel.TabIndex = 8;
            this.packageLabel.Text = "Package:";
            // 
            // saveSettingsBtn
            // 
            this.saveSettingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSettingsBtn.Location = new System.Drawing.Point(353, 216);
            this.saveSettingsBtn.Name = "saveSettingsBtn";
            this.saveSettingsBtn.Size = new System.Drawing.Size(94, 21);
            this.saveSettingsBtn.TabIndex = 24;
            this.saveSettingsBtn.Text = "Save Settings";
            this.saveSettingsBtn.UseVisualStyleBackColor = true;
            this.saveSettingsBtn.Click += new System.EventHandler(this.saveSettingsBtn_Click);
            // 
            // generateBtn
            // 
            this.generateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generateBtn.Location = new System.Drawing.Point(454, 216);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(75, 21);
            this.generateBtn.TabIndex = 25;
            this.generateBtn.Text = "Generate";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // codeGeneration
            // 
            this.codeGeneration.ProgressChanged += new CodeBuilder.WinForm.UI.GenerationProgressChangedEventHandler(this.codeGeneration_ProgressChanged);
            this.codeGeneration.Completed += new CodeBuilder.WinForm.UI.GenerationCompletedEventHandler(this.codeGeneration_Completed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 427);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(760, 455);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeBuilder";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.treeViewContextMenu.ResumeLayout(false);
            this.resultGbx.ResumeLayout(false);
            this.genItemsGbx.ResumeLayout(false);
            this.genItemsGbx.PerformLayout();
            this.genSettingsCtxMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsOptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem helpF1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpAboutMenuItem;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripSeparator helpSeparator1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileExportPdmMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileExportDataSourceMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileSeparator1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolsSeparator1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsDSConfigMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.GroupBox genItemsGbx;
        private System.Windows.Forms.GroupBox resultGbx;
        private System.Windows.Forms.ToolStripMenuItem toolsTemplatesMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusBarReady;
        private System.Windows.Forms.ToolStripStatusLabel statusBarDatabase;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLanguage;
        private System.Windows.Forms.ToolStripStatusLabel statusBarEncoding;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileSeparator2MenuItem;
        private System.Windows.Forms.ImageList treeNodeImageList;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.ContextMenuStrip treeViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exportPDMCtxMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDataSourceCtxMenuItem;
        private System.Windows.Forms.ToolStripSeparator ctxSeparator2;
        private System.Windows.Forms.ToolStripMenuItem clearCtxMenuItem;
        private System.Windows.Forms.ContextMenuStrip genSettingsCtxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openGenSettingsCtxMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGenSettingCtxMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveSettingsBtn;
        private System.Windows.Forms.ToolStripMenuItem fileSaveMenuItem;
        private System.Windows.Forms.ToolStripSeparator genSettingsCtxSeparator1;
        private System.Windows.Forms.ToolStripMenuItem generateCtxMenuItem;
        private System.Windows.Forms.TextBox packageTxtBox;
        private System.Windows.Forms.Label packageLabel;
        private System.Windows.Forms.TextBox versionTxtBox;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.TextBox authorTxtBox;
        private System.Windows.Forms.Label authorLbl;
        private System.Windows.Forms.TextBox tablePrefixTxtBox;
        private System.Windows.Forms.Label tablePrefixLbl;
        private System.Windows.Forms.Label templateLbl;
        private System.Windows.Forms.ComboBox codeFileEncodingCombox;
        private System.Windows.Forms.Label codeFileEncodingLbl;
        private System.Windows.Forms.ComboBox languageCombx;
        private System.Windows.Forms.Label languageLbl;
        private System.Windows.Forms.CheckBox isStandardizeNameChkbox;
        private System.Windows.Forms.CheckBox isOmitTablePrefixChkbox;
        private System.Windows.Forms.ProgressBar genProgressBar;
        private System.Windows.Forms.Label currentGenFileLbl;
        private System.Windows.Forms.Label completedLbl;
        private System.Windows.Forms.Label totalFileCountLbl;
        private System.Windows.Forms.Label totalFilesLbl;
        private System.Windows.Forms.Label currentGenFileNameLbl;
        private System.Windows.Forms.Label genFileCountLbl;
        private System.Windows.Forms.Label genFilesLbl;
        private System.Windows.Forms.Label errorFileCountLbl;
        private System.Windows.Forms.Label errorFilesLbl;
        private System.Windows.Forms.ComboBox templateEngineCombox;
        private System.Windows.Forms.Label templateEngineLbl;
        private System.Windows.Forms.Label databaseNameLbl;
        private System.Windows.Forms.Label databaseLbl;
        private System.Windows.Forms.ToolStripMenuItem helpFeedbackMenuItem;
        private System.Windows.Forms.ListBox templateListBox;
        private UI.CodeGeneration codeGeneration;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

