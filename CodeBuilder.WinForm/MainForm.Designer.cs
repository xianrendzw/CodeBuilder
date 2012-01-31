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
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.codeGeneration = new CodeBuilder.WinForm.UI.CodeGeneration(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.treeViewContextMenu.SuspendLayout();
            this.resultGbx.SuspendLayout();
            this.genItemsGbx.SuspendLayout();
            this.genSettingsCtxMenuStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.resultGbx);
            this.splitContainer.Panel2.Controls.Add(this.genItemsGbx);
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            // 
            // treeView
            // 
            this.treeView.CheckBoxes = true;
            this.treeView.ContextMenuStrip = this.treeViewContextMenu;
            resources.ApplyResources(this.treeView, "treeView");
            this.treeView.ImageList = this.treeNodeImageList;
            this.treeView.Name = "treeView";
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
            resources.ApplyResources(this.treeViewContextMenu, "treeViewContextMenu");
            // 
            // exportPDMCtxMenuItem
            // 
            this.exportPDMCtxMenuItem.Name = "exportPDMCtxMenuItem";
            resources.ApplyResources(this.exportPDMCtxMenuItem, "exportPDMCtxMenuItem");
            this.exportPDMCtxMenuItem.Click += new System.EventHandler(this.exportPDMCtxMenuItem_Click);
            // 
            // exportDataSourceCtxMenuItem
            // 
            this.exportDataSourceCtxMenuItem.Name = "exportDataSourceCtxMenuItem";
            resources.ApplyResources(this.exportDataSourceCtxMenuItem, "exportDataSourceCtxMenuItem");
            this.exportDataSourceCtxMenuItem.MouseHover += new System.EventHandler(this.exportDataSourceCtxMenuItem_MouseHover);
            // 
            // ctxSeparator2
            // 
            this.ctxSeparator2.Name = "ctxSeparator2";
            resources.ApplyResources(this.ctxSeparator2, "ctxSeparator2");
            // 
            // clearCtxMenuItem
            // 
            resources.ApplyResources(this.clearCtxMenuItem, "clearCtxMenuItem");
            this.clearCtxMenuItem.Name = "clearCtxMenuItem";
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
            resources.ApplyResources(this.resultGbx, "resultGbx");
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
            this.resultGbx.Name = "resultGbx";
            this.resultGbx.TabStop = false;
            // 
            // errorFileCountLbl
            // 
            resources.ApplyResources(this.errorFileCountLbl, "errorFileCountLbl");
            this.errorFileCountLbl.Name = "errorFileCountLbl";
            // 
            // errorFilesLbl
            // 
            resources.ApplyResources(this.errorFilesLbl, "errorFilesLbl");
            this.errorFilesLbl.Name = "errorFilesLbl";
            // 
            // genFileCountLbl
            // 
            resources.ApplyResources(this.genFileCountLbl, "genFileCountLbl");
            this.genFileCountLbl.Name = "genFileCountLbl";
            // 
            // genFilesLbl
            // 
            resources.ApplyResources(this.genFilesLbl, "genFilesLbl");
            this.genFilesLbl.Name = "genFilesLbl";
            // 
            // completedLbl
            // 
            resources.ApplyResources(this.completedLbl, "completedLbl");
            this.completedLbl.Name = "completedLbl";
            // 
            // totalFileCountLbl
            // 
            resources.ApplyResources(this.totalFileCountLbl, "totalFileCountLbl");
            this.totalFileCountLbl.Name = "totalFileCountLbl";
            // 
            // totalFilesLbl
            // 
            resources.ApplyResources(this.totalFilesLbl, "totalFilesLbl");
            this.totalFilesLbl.Name = "totalFilesLbl";
            // 
            // currentGenFileNameLbl
            // 
            resources.ApplyResources(this.currentGenFileNameLbl, "currentGenFileNameLbl");
            this.currentGenFileNameLbl.Cursor = System.Windows.Forms.Cursors.Default;
            this.currentGenFileNameLbl.Name = "currentGenFileNameLbl";
            this.currentGenFileNameLbl.Click += new System.EventHandler(this.currentGenFileNameLbl_Click);
            // 
            // currentGenFileLbl
            // 
            resources.ApplyResources(this.currentGenFileLbl, "currentGenFileLbl");
            this.currentGenFileLbl.Name = "currentGenFileLbl";
            // 
            // genProgressBar
            // 
            resources.ApplyResources(this.genProgressBar, "genProgressBar");
            this.genProgressBar.Name = "genProgressBar";
            // 
            // genItemsGbx
            // 
            resources.ApplyResources(this.genItemsGbx, "genItemsGbx");
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
            this.genItemsGbx.Name = "genItemsGbx";
            this.genItemsGbx.TabStop = false;
            // 
            // genSettingsCtxMenuStrip
            // 
            this.genSettingsCtxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGenSettingsCtxMenuItem,
            this.saveGenSettingCtxMenuItem,
            this.genSettingsCtxSeparator1,
            this.generateCtxMenuItem});
            this.genSettingsCtxMenuStrip.Name = "genSettingsCtxMenuStrip";
            resources.ApplyResources(this.genSettingsCtxMenuStrip, "genSettingsCtxMenuStrip");
            // 
            // openGenSettingsCtxMenuItem
            // 
            this.openGenSettingsCtxMenuItem.Name = "openGenSettingsCtxMenuItem";
            resources.ApplyResources(this.openGenSettingsCtxMenuItem, "openGenSettingsCtxMenuItem");
            this.openGenSettingsCtxMenuItem.Click += new System.EventHandler(this.openGenSettingsCtxMenuItem_Click);
            // 
            // saveGenSettingCtxMenuItem
            // 
            this.saveGenSettingCtxMenuItem.Name = "saveGenSettingCtxMenuItem";
            resources.ApplyResources(this.saveGenSettingCtxMenuItem, "saveGenSettingCtxMenuItem");
            this.saveGenSettingCtxMenuItem.Click += new System.EventHandler(this.saveGenSettingCtxMenuItem_Click);
            // 
            // genSettingsCtxSeparator1
            // 
            this.genSettingsCtxSeparator1.Name = "genSettingsCtxSeparator1";
            resources.ApplyResources(this.genSettingsCtxSeparator1, "genSettingsCtxSeparator1");
            // 
            // generateCtxMenuItem
            // 
            this.generateCtxMenuItem.Name = "generateCtxMenuItem";
            resources.ApplyResources(this.generateCtxMenuItem, "generateCtxMenuItem");
            this.generateCtxMenuItem.Click += new System.EventHandler(this.generateCtxMenuItem_Click);
            // 
            // templateListBox
            // 
            resources.ApplyResources(this.templateListBox, "templateListBox");
            this.templateListBox.FormattingEnabled = true;
            this.templateListBox.Name = "templateListBox";
            this.templateListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            // 
            // databaseNameLbl
            // 
            resources.ApplyResources(this.databaseNameLbl, "databaseNameLbl");
            this.databaseNameLbl.Name = "databaseNameLbl";
            // 
            // databaseLbl
            // 
            resources.ApplyResources(this.databaseLbl, "databaseLbl");
            this.databaseLbl.Name = "databaseLbl";
            // 
            // templateEngineCombox
            // 
            this.templateEngineCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateEngineCombox.FormattingEnabled = true;
            resources.ApplyResources(this.templateEngineCombox, "templateEngineCombox");
            this.templateEngineCombox.Name = "templateEngineCombox";
            this.templateEngineCombox.SelectedIndexChanged += new System.EventHandler(this.templateEngineCombox_SelectedIndexChanged);
            // 
            // templateEngineLbl
            // 
            resources.ApplyResources(this.templateEngineLbl, "templateEngineLbl");
            this.templateEngineLbl.Name = "templateEngineLbl";
            // 
            // isStandardizeNameChkbox
            // 
            resources.ApplyResources(this.isStandardizeNameChkbox, "isStandardizeNameChkbox");
            this.isStandardizeNameChkbox.Name = "isStandardizeNameChkbox";
            this.isStandardizeNameChkbox.UseVisualStyleBackColor = true;
            // 
            // isOmitTablePrefixChkbox
            // 
            resources.ApplyResources(this.isOmitTablePrefixChkbox, "isOmitTablePrefixChkbox");
            this.isOmitTablePrefixChkbox.Name = "isOmitTablePrefixChkbox";
            this.isOmitTablePrefixChkbox.UseVisualStyleBackColor = true;
            // 
            // codeFileEncodingCombox
            // 
            this.codeFileEncodingCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codeFileEncodingCombox.FormattingEnabled = true;
            resources.ApplyResources(this.codeFileEncodingCombox, "codeFileEncodingCombox");
            this.codeFileEncodingCombox.Name = "codeFileEncodingCombox";
            this.codeFileEncodingCombox.SelectedIndexChanged += new System.EventHandler(this.codeFileEncodingCombox_SelectedIndexChanged);
            // 
            // codeFileEncodingLbl
            // 
            resources.ApplyResources(this.codeFileEncodingLbl, "codeFileEncodingLbl");
            this.codeFileEncodingLbl.Name = "codeFileEncodingLbl";
            // 
            // languageCombx
            // 
            resources.ApplyResources(this.languageCombx, "languageCombx");
            this.languageCombx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageCombx.FormattingEnabled = true;
            this.languageCombx.Name = "languageCombx";
            this.languageCombx.SelectedIndexChanged += new System.EventHandler(this.languageCombx_SelectedIndexChanged);
            // 
            // languageLbl
            // 
            resources.ApplyResources(this.languageLbl, "languageLbl");
            this.languageLbl.Name = "languageLbl";
            // 
            // templateLbl
            // 
            resources.ApplyResources(this.templateLbl, "templateLbl");
            this.templateLbl.Name = "templateLbl";
            // 
            // versionTxtBox
            // 
            resources.ApplyResources(this.versionTxtBox, "versionTxtBox");
            this.versionTxtBox.Name = "versionTxtBox";
            // 
            // versionLbl
            // 
            resources.ApplyResources(this.versionLbl, "versionLbl");
            this.versionLbl.Name = "versionLbl";
            // 
            // authorTxtBox
            // 
            resources.ApplyResources(this.authorTxtBox, "authorTxtBox");
            this.authorTxtBox.Name = "authorTxtBox";
            // 
            // authorLbl
            // 
            resources.ApplyResources(this.authorLbl, "authorLbl");
            this.authorLbl.Name = "authorLbl";
            // 
            // tablePrefixTxtBox
            // 
            resources.ApplyResources(this.tablePrefixTxtBox, "tablePrefixTxtBox");
            this.tablePrefixTxtBox.Name = "tablePrefixTxtBox";
            // 
            // tablePrefixLbl
            // 
            resources.ApplyResources(this.tablePrefixLbl, "tablePrefixLbl");
            this.tablePrefixLbl.Name = "tablePrefixLbl";
            // 
            // packageTxtBox
            // 
            resources.ApplyResources(this.packageTxtBox, "packageTxtBox");
            this.packageTxtBox.Name = "packageTxtBox";
            // 
            // packageLabel
            // 
            resources.ApplyResources(this.packageLabel, "packageLabel");
            this.packageLabel.Name = "packageLabel";
            // 
            // saveSettingsBtn
            // 
            resources.ApplyResources(this.saveSettingsBtn, "saveSettingsBtn");
            this.saveSettingsBtn.Name = "saveSettingsBtn";
            this.saveSettingsBtn.UseVisualStyleBackColor = true;
            this.saveSettingsBtn.Click += new System.EventHandler(this.saveSettingsBtn_Click);
            // 
            // generateBtn
            // 
            resources.ApplyResources(this.generateBtn, "generateBtn");
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.toolsMenu,
            this.helpMenu});
            resources.ApplyResources(this.mainMenuStrip, "mainMenuStrip");
            this.mainMenuStrip.Name = "mainMenuStrip";
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
            resources.ApplyResources(this.fileMenu, "fileMenu");
            // 
            // fileExportPdmMenuItem
            // 
            this.fileExportPdmMenuItem.Name = "fileExportPdmMenuItem";
            resources.ApplyResources(this.fileExportPdmMenuItem, "fileExportPdmMenuItem");
            this.fileExportPdmMenuItem.Click += new System.EventHandler(this.fileExportPdmMenuItem_Click);
            // 
            // fileExportDataSourceMenuItem
            // 
            this.fileExportDataSourceMenuItem.Name = "fileExportDataSourceMenuItem";
            resources.ApplyResources(this.fileExportDataSourceMenuItem, "fileExportDataSourceMenuItem");
            this.fileExportDataSourceMenuItem.MouseHover += new System.EventHandler(this.fileExportDataSourceMenuItem_MouseHover);
            // 
            // fileSeparator2MenuItem
            // 
            this.fileSeparator2MenuItem.Name = "fileSeparator2MenuItem";
            resources.ApplyResources(this.fileSeparator2MenuItem, "fileSeparator2MenuItem");
            // 
            // fileOpenMenuItem
            // 
            this.fileOpenMenuItem.Name = "fileOpenMenuItem";
            resources.ApplyResources(this.fileOpenMenuItem, "fileOpenMenuItem");
            this.fileOpenMenuItem.Click += new System.EventHandler(this.fileOpenMenuItem_Click);
            // 
            // fileSaveMenuItem
            // 
            this.fileSaveMenuItem.Name = "fileSaveMenuItem";
            resources.ApplyResources(this.fileSaveMenuItem, "fileSaveMenuItem");
            this.fileSaveMenuItem.Click += new System.EventHandler(this.fileSaveMenuItem_Click);
            // 
            // fileSeparator1MenuItem
            // 
            this.fileSeparator1MenuItem.Name = "fileSeparator1MenuItem";
            resources.ApplyResources(this.fileSeparator1MenuItem, "fileSeparator1MenuItem");
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            resources.ApplyResources(this.fileExitMenuItem, "fileExitMenuItem");
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
            resources.ApplyResources(this.toolsMenu, "toolsMenu");
            // 
            // toolsDSConfigMenuItem
            // 
            this.toolsDSConfigMenuItem.Name = "toolsDSConfigMenuItem";
            resources.ApplyResources(this.toolsDSConfigMenuItem, "toolsDSConfigMenuItem");
            this.toolsDSConfigMenuItem.Click += new System.EventHandler(this.toolsDSConfigMenuItem_Click);
            // 
            // toolsTemplatesMenuItem
            // 
            this.toolsTemplatesMenuItem.Name = "toolsTemplatesMenuItem";
            resources.ApplyResources(this.toolsTemplatesMenuItem, "toolsTemplatesMenuItem");
            this.toolsTemplatesMenuItem.Click += new System.EventHandler(this.toolsTemplatesMenuItem_Click);
            // 
            // toolsSeparator1MenuItem
            // 
            this.toolsSeparator1MenuItem.Name = "toolsSeparator1MenuItem";
            resources.ApplyResources(this.toolsSeparator1MenuItem, "toolsSeparator1MenuItem");
            // 
            // toolsOptionsMenuItem
            // 
            this.toolsOptionsMenuItem.Name = "toolsOptionsMenuItem";
            resources.ApplyResources(this.toolsOptionsMenuItem, "toolsOptionsMenuItem");
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
            resources.ApplyResources(this.helpMenu, "helpMenu");
            this.helpMenu.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // helpF1MenuItem
            // 
            this.helpF1MenuItem.Name = "helpF1MenuItem";
            resources.ApplyResources(this.helpF1MenuItem, "helpF1MenuItem");
            this.helpF1MenuItem.Click += new System.EventHandler(this.helpF1MenuItem_Click);
            // 
            // helpFeedbackMenuItem
            // 
            this.helpFeedbackMenuItem.Name = "helpFeedbackMenuItem";
            resources.ApplyResources(this.helpFeedbackMenuItem, "helpFeedbackMenuItem");
            this.helpFeedbackMenuItem.Click += new System.EventHandler(this.helpFeedbackMenuItem_Click);
            // 
            // helpSeparator1MenuItem
            // 
            this.helpSeparator1MenuItem.Name = "helpSeparator1MenuItem";
            resources.ApplyResources(this.helpSeparator1MenuItem, "helpSeparator1MenuItem");
            // 
            // helpAboutMenuItem
            // 
            this.helpAboutMenuItem.Name = "helpAboutMenuItem";
            resources.ApplyResources(this.helpAboutMenuItem, "helpAboutMenuItem");
            this.helpAboutMenuItem.Click += new System.EventHandler(this.helpAboutMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarReady,
            this.statusBarDatabase,
            this.statusBarLanguage,
            this.statusBarEncoding});
            resources.ApplyResources(this.mainStatusStrip, "mainStatusStrip");
            this.mainStatusStrip.Name = "mainStatusStrip";
            // 
            // statusBarReady
            // 
            resources.ApplyResources(this.statusBarReady, "statusBarReady");
            this.statusBarReady.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusBarReady.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.statusBarReady.Name = "statusBarReady";
            this.statusBarReady.Spring = true;
            // 
            // statusBarDatabase
            // 
            resources.ApplyResources(this.statusBarDatabase, "statusBarDatabase");
            this.statusBarDatabase.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusBarDatabase.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.statusBarDatabase.Name = "statusBarDatabase";
            // 
            // statusBarLanguage
            // 
            resources.ApplyResources(this.statusBarLanguage, "statusBarLanguage");
            this.statusBarLanguage.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusBarLanguage.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.statusBarLanguage.Name = "statusBarLanguage";
            // 
            // statusBarEncoding
            // 
            resources.ApplyResources(this.statusBarEncoding, "statusBarEncoding");
            this.statusBarEncoding.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusBarEncoding.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarEncoding.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.statusBarEncoding.Name = "statusBarEncoding";
            // 
            // codeGeneration
            // 
            this.codeGeneration.ProgressChanged += new CodeBuilder.WinForm.UI.GenerationProgressChangedEventHandler(this.codeGeneration_ProgressChanged);
            this.codeGeneration.Completed += new CodeBuilder.WinForm.UI.GenerationCompletedEventHandler(this.codeGeneration_Completed);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.treeViewContextMenu.ResumeLayout(false);
            this.resultGbx.ResumeLayout(false);
            this.genItemsGbx.ResumeLayout(false);
            this.genItemsGbx.PerformLayout();
            this.genSettingsCtxMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
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

