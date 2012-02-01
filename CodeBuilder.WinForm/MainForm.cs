using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder.WinForm
{
    using Configuration;
    using Properties;
    using UI;
    using Util;

    public partial class MainForm : Form
    {
        private static Logger logger = InternalTrace.GetLogger(typeof(MainForm));
        private string currentGenerationSettingsFile;

        public MainForm()
        {
            InitializeComponent();
            this.InitializeUIData();
        }

        private void InitializeUIData()
        {
            this.SetComboBoxItems();
            this.SetStatusItems();
        }

        #region Menu Handlers

        #region File
        private void fileOpenMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Title = Resources.OpenGenerationSettingsFile;
            this.openFileDialog.Filter = Resources.GenerationSettingsFileExt;
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string xmlFileName = this.openFileDialog.FileName;
                try
                {
                    this.SetGenerationSettings(xmlFileName);
                }
                catch (Exception ex)
                {
                    logger.Error(Resources.OpenGenerationSettingsFile, ex);
                    MessageBoxHelper.DisplayFailure(Resources.InvalidGenerationSettingsFile);
                    return;
                }

                string menuItemText = string.Format(Resources.SaveFormat, Path.GetFileName(xmlFileName));
                this.fileSaveMenuItem.Text = menuItemText;
                this.saveGenSettingCtxMenuItem.Text = menuItemText;
                this.currentGenerationSettingsFile = xmlFileName;
                this.statusBarReady.Text = string.Format(Resources.OpenFormat, xmlFileName);
            }
        }

        private void fileSaveMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.CheckParameters()) return;

            GenerationSettings settings = GetGenerationSettings();
            string xmlFileName = this.currentGenerationSettingsFile;
            string cmdText = Resources.Modified;
            if (string.IsNullOrEmpty(xmlFileName))
            {
                cmdText = Resources.Saved;
                this.saveFileDialog.Filter = Resources.GenerationSettingsFileExt;
                this.saveFileDialog.DefaultExt = ".xml";
                this.saveFileDialog.FileName = "New_GenerationSettings.xml";
                if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
                    xmlFileName = this.saveFileDialog.FileName;
                else return;
            }

            try
            {
                SerializeHelper.XmlSerialize(settings,xmlFileName);
            }
            catch (Exception ex)
            {
                logger.Error(Resources.SaveGenerationSettingsFile, ex);
                MessageBoxHelper.DisplayFailure(ex.Message);
                return;
            }

            this.statusBarReady.Text = string.Format("{0} {1}", cmdText, xmlFileName);
            this.currentGenerationSettingsFile = xmlFileName;
        }

        private void fileExportPdmMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Title = Resources.OpenPowerDesignerPDMFile;
            this.openFileDialog.Filter = Resources.PhysicalDataModelFileExt;
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdmFileName = this.openFileDialog.FileName;

                try
                {
                    TreeNode rootNode = ExportModelHelper.ExportPDM(pdmFileName, this.treeView);
                    rootNode.ExpandAll();
                    this.treeView.SelectedNode = rootNode;
                }
                catch (Exception ex)
                {
                    if (this.treeView.Nodes.Count > 0) 
                        this.treeView.Nodes[this.treeView.Nodes.Count - 1].Remove();

                    logger.Error(Resources.ExportPDMFileFailure, ex);
                    MessageBoxHelper.Display(ex.Message);
                    return;
                }

                this.clearCtxMenuItem.Enabled = true;
                this.statusBarReady.Text = string.Format(Resources.ExportFormat, pdmFileName);
            }
        }

        private void fileExportDataSourceMenuItem_MouseHover(object sender, EventArgs e)
        {
            this.AddDataSourceMenuItems(this.fileExportDataSourceMenuItem);
        }

        private void fileExportDataSourceMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            try
            {
                TreeNode rootNode = ExportModelHelper.Export(menuItem.Text, this.treeView);
                rootNode.ExpandAll();
                this.treeView.SelectedNode = rootNode;
            }
            catch (Exception ex)
            {
                if (this.treeView.Nodes.Count > 0)
                    this.treeView.Nodes[this.treeView.Nodes.Count - 1].Remove();

                logger.Error(Resources.ExportDataSourceFailure, ex);
                MessageBoxHelper.Display(ex.Message);
                return;
            }

            this.clearCtxMenuItem.Enabled = true;
            this.statusBarReady.Text = string.Format(Resources.ExportDataSourceFormat, menuItem.Text);
        }

        private void fileExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Tools

        private void toolsOptionsMenuItem_Click(object sender, EventArgs e)
        {
            OptionsDialog.Display(this);
        }

        private void toolsDSConfigMenuItem_Click(object sender, EventArgs e)
        {
            OptionsDialog.Display(this,Resources.DataSourceManagerDataSources);
        }

        private void toolsTemplatesMenuItem_Click(object sender, EventArgs e)
        {
            OptionsDialog.Display(this, Resources.TemplateManagerTemplates);
        }
        #endregion

        #region Help

        private void helpF1MenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ConfigManager.HelpUrl);
        }

        private void helpFeedbackMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ConfigManager.HelpUrl);
        }

        private void helpAboutMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox aboutBox = new AboutBox())
            {
                aboutBox.ShowDialog();
            }
        }

        #endregion

        #endregion

        #region Context Menu Handlers

        #region TreeView
        private void exportPDMCtxMenuItem_Click(object sender, EventArgs e)
        {
            this.fileExportPdmMenuItem_Click(sender, e);
        }

        private void exportDataSourceCtxMenuItem_MouseHover(object sender, EventArgs e)
        {
            this.AddDataSourceMenuItems(this.exportDataSourceCtxMenuItem);
        }

        private void clearCtxMenuItem_Click(object sender, EventArgs e)
        {
            ModelManager.Clear();
            this.treeView.Nodes.Clear();
            this.clearCtxMenuItem.Enabled = false;
            this.statusBarDatabase.Text = string.Empty;
            this.statusBarReady.Text = Resources.Ready;
        }
        #endregion

        #region Generation SettingsSection
        private void openGenSettingsCtxMenuItem_Click(object sender, EventArgs e)
        {
            this.fileOpenMenuItem_Click(sender, e);
        }

        private void saveGenSettingCtxMenuItem_Click(object sender, EventArgs e)
        {
            this.fileSaveMenuItem_Click(sender, e);
        }

        private void generateCtxMenuItem_Click(object sender, EventArgs e)
        {
            this.generateBtn_Click(sender, e);
        }
   
        #endregion

        #endregion

        #region TreeView Handlers

        private void treeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
        }

        private void treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ExportModelHelper.CheckedTreeNode(e.Node);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null && e.Node != null)
            {
                this.databaseNameLbl.Text = e.Node.Tag.ToString();
                this.statusBarDatabase.Text = this.databaseNameLbl.Text;
            }
        }
        #endregion

        #region Generation Settings Handlers

        private void saveSettingsBtn_Click(object sender, EventArgs e)
        {
            this.fileSaveMenuItem_Click(sender, e);
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {   
            if (!this.CheckParameters()) return;
            var generationObjects = GenerationHelper.GetGenerationObjects(this.treeView);
            int genObjectCount = generationObjects.Sum(x => x.Value.Count);
            if (genObjectCount == 0)
            {
                MessageBoxHelper.DisplayInfo(Resources.ShouldCheckedTreeNode);
                return;
            }

            int fileCount = genObjectCount * this.templateListBox.SelectedItems.Count;
            this.generateBtn.Enabled = false;
            this.completedLbl.Visible = false;
            this.totalFileCountLbl.Text = fileCount.ToString();
            this.genProgressBar.Maximum = fileCount;

            GenerationParameter parameter = new GenerationParameter(
                ModelManager.Clone(),
                GenerationHelper.GetGenerationObjects(this.treeView),
                this.GetGenerationSettings());

            try
            {
                this.codeGeneration.GenerateAsync(parameter, Guid.NewGuid().ToString());
            }
            catch (Exception ex)
            {
                logger.Error(Resources.GenerateFailure, ex);
            }
        }

        private void codeGeneration_Completed(object sender, GenerationCompletedEventArgs args)
        {
            this.generateBtn.Enabled = true;
            this.completedLbl.Visible = true;
            this.statusBarReady.Text = this.completedLbl.Text;
            this.SetGenFileNameLabel();
        }

        private void codeGeneration_ProgressChanged(GenerationProgressChangedEventArgs args)
        {
            this.genProgressBar.Value = args.ProgressPercentage;
            this.genFileCountLbl.Text = args.GeneratedCount.ToString();
            this.errorFileCountLbl.Text = args.ErrorCount.ToString();
            this.currentGenFileNameLbl.Text = args.CurrentFileName;
            this.statusBarReady.Text = args.CurrentFileName;
        }

        private void languageCombx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.statusBarLanguage.Text = this.languageCombx.Text;
            this.ChangeTemplateListBox(this.languageCombx.Text, this.templateEngineCombox.Text);
        }

        private void codeFileEncodingCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.statusBarEncoding.Text = this.codeFileEncodingCombox.Text;
        }

        private void templateEngineCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ChangeTemplateListBox(this.languageCombx.Text, this.templateEngineCombox.Text);
        }

        private void currentGenFileNameLbl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.currentGenFileNameLbl.Text)) return;

            try
            {
                string folder = Path.GetDirectoryName(this.currentGenFileNameLbl.Text);
                System.Diagnostics.Process.Start("explorer.exe", folder);
            }
            catch (Exception ex)
            {
                logger.Error(Resources.OpenCodeGenerationFolderFailure, ex);
                MessageBoxHelper.DisplayInfo(Resources.OpenCodeGenerationFolderFailure);
            }
        }

        #endregion

        #region Helper methods for modifying the UI display

        private void SetComboBoxItems()
        {
            this.languageCombx.Items.Clear();
            this.templateEngineCombox.Items.Clear();
            this.codeFileEncodingCombox.Items.Clear();

            foreach (LanguageElement language in ConfigManager.SettingsSection.Languages)
            {
                this.languageCombx.Items.Add(language.Name);
            }

            foreach (TemplateEngineElement templateEngine in ConfigManager.SettingsSection.TemplateEngines)
            {
                this.templateEngineCombox.Items.Add(templateEngine.Name);
            }

            foreach (var encodingInfo in Encoding.GetEncodings())
            {
                this.codeFileEncodingCombox.Items.Add(encodingInfo.Name.ToUpper());
            }

            this.languageCombx.Text = this.languageCombx.Items[0].ToString();
            this.templateEngineCombox.Text = this.templateEngineCombox.Items[0].ToString();
            this.codeFileEncodingCombox.Text = "UTF-8";
        }

        private void SetStatusItems()
        {
            this.statusBarDatabase.Text = this.databaseNameLbl.Text;
            this.statusBarEncoding.Text = this.codeFileEncodingCombox.Text;
            this.statusBarLanguage.Text = this.languageCombx.Text;
        }

        private void SetGenFileNameLabel()
        {
            if (!string.IsNullOrEmpty(this.currentGenFileNameLbl.Text))
            {
                this.currentGenFileNameLbl.Cursor = System.Windows.Forms.Cursors.Hand;
                this.toolTip.SetToolTip(this.currentGenFileNameLbl, Resources.OpenCodeGenerationFolder);
            }
        }

        private void AddDataSourceMenuItems(ToolStripMenuItem parent)
        {
            parent.DropDownItems.Clear();
            foreach (DataSourceElement dataSource in ConfigManager.DataSourceSection.DataSources)
            {
                ToolStripMenuItem ds = new ToolStripMenuItem(dataSource.Name);
                ds.Click += new EventHandler(fileExportDataSourceMenuItem_Click);
                parent.DropDownItems.Add(ds);
            }
        }

        private void ChangeTemplateListBox(string language, string engine)
        {
            this.templateListBox.Items.Clear();
            foreach (TemplateElement template in ConfigManager.TemplateSection.Templates)
            {
                if (template.Language.Equals(language, StringComparison.CurrentCultureIgnoreCase) &&
                    template.Engine.Equals(engine, StringComparison.CurrentCultureIgnoreCase))
                {

                    this.templateListBox.Items.Add(new TemplateListBoxItem(template.Name, template.DisplayName));
                    this.templateListBox.DisplayMember = "DisplayName";
                }
            }
        }

        private void SetGenerationSettings(string xmlFileName)
        {
            GenerationSettings settings = SerializeHelper.XmlDeserialize<GenerationSettings>(xmlFileName);
            this.languageCombx.Text = settings.Language;
            this.templateEngineCombox.Text = settings.TemplateEngine;
            this.packageTxtBox.Text = settings.Package;
            this.tablePrefixTxtBox.Text = settings.TablePrefix;
            this.authorTxtBox.Text = settings.Author;
            this.versionTxtBox.Text = settings.Version;
            this.codeFileEncodingCombox.Text = settings.Encoding;
            this.isOmitTablePrefixChkbox.Checked = settings.IsOmitTablePrefix;
            this.isStandardizeNameChkbox.Checked = settings.IsStandardizeName;

            this.templateListBox.Items.Clear();
            foreach (string templateName in settings.TemplatesNames)
            {
                TemplateElement template = ConfigManager.TemplateSection.Templates[templateName];
                TemplateListBoxItem item = new TemplateListBoxItem(template.Name, template.DisplayName);
                this.templateListBox.Items.Add(item);
                this.templateListBox.SelectedItems.Add(item);
                this.templateListBox.DisplayMember = "DisplayName";
            }
        }

        private GenerationSettings GetGenerationSettings()
        {
            GenerationSettings settings = new GenerationSettings(this.languageCombx.Text,
                this.templateEngineCombox.Text, this.packageTxtBox.Text, this.tablePrefixTxtBox.Text,
                this.authorTxtBox.Text, this.versionTxtBox.Text,
                this.templateListBox.SelectedItems.Cast<TemplateListBoxItem>().Select(x=>x.Name).ToArray(),
                this.codeFileEncodingCombox.Text, this.isOmitTablePrefixChkbox.Checked, this.isStandardizeNameChkbox.Checked);
            return settings;
        }

        public bool CheckParameters()
        {
            if (!GenerationHelper.IsValidPackageName(this.packageTxtBox.Text))
            {
                MessageBoxHelper.DisplayInfo(Resources.PackageNameInvalid);
                this.packageTxtBox.Focus();
                return false;
            }

            if (this.templateListBox.SelectedItems == null ||
                this.templateListBox.SelectedItems.Count == 0)
            {
                MessageBoxHelper.DisplayInfo(Resources.ShouldSelectOneTemplate);
                this.templateListBox.Focus();
                return false;
            }

            return true;
        }

        #endregion	

        #region TemplateListBox Item Inner Class

        private class TemplateListBoxItem
        {
            public TemplateListBoxItem(string name,string displayName)
            {
                this.Name = name;
                this.DisplayName = displayName;
            }

            public string Name { get; set; }
            public string DisplayName { get; set; }
        }

        #endregion
    }
}
