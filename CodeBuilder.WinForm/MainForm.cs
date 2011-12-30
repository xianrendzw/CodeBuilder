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
            this.openFileDialog.Title = "Open Generation Settings File";
            this.openFileDialog.Filter = "Generation Settings (*.xml)|*.xml";
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string xmlFileName = this.openFileDialog.FileName;
                try
                {
                    this.SetGenerationSettings(xmlFileName);
                }
                catch (Exception ex)
                {
                    logger.Error("Open Generation Settings File", ex);
                    MessageBoxHelper.DisplayFailure("Invalid Generation Settings File");
                    return;
                }

                string menuItemText = string.Format("Save {0}...", Path.GetFileName(xmlFileName));
                this.fileSaveMenuItem.Text = menuItemText;
                this.saveGenSettingCtxMenuItem.Text = menuItemText;
                this.currentGenerationSettingsFile = xmlFileName;
                this.statusBarReady.Text = string.Format("Open {0}", xmlFileName);
            }
        }

        private void fileSaveMenuItem_Click(object sender, EventArgs e)
        {
            GenerationSettings settings = GetGenerationSettings();

            string xmlFileName = this.currentGenerationSettingsFile;
            string cmdText = "Modified";
            if (string.IsNullOrEmpty(xmlFileName))
            {
                cmdText = "Saved";
                this.saveFileDialog.Filter = "Generation Settings (*.xml)|*.xml";
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
                logger.Error("Save Generation Settings File", ex);
                MessageBoxHelper.DisplayFailure(ex.Message);
                return;
            }

            this.statusBarReady.Text = string.Format("{0} {1}", cmdText, xmlFileName);
            this.currentGenerationSettingsFile = xmlFileName;
        }

        private void fileExportPdmMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Title = "Open PowerDesigner PDM File";
            this.openFileDialog.Filter = "Physical Data Model (*.pdm)|*.pdm";
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdmFileName = this.openFileDialog.FileName;

                try
                {
                    TreeNode rootNode = ExportModelHelper.ExportPDM(pdmFileName, this.treeView);
                    rootNode.ExpandAll();
                }
                catch (Exception ex)
                {
                    if (this.treeView.Nodes.Count > 0) 
                        this.treeView.Nodes[this.treeView.Nodes.Count - 1].Remove();

                    logger.Error("Export PDM File", ex);
                    MessageBoxHelper.Display(ex.Message);
                    return;
                }

                this.clearCtxMenuItem.Enabled = true;
                this.statusBarReady.Text = string.Format("Export {0}", pdmFileName);
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
            }
            catch (Exception ex)
            {
                if (this.treeView.Nodes.Count > 0)
                    this.treeView.Nodes[this.treeView.Nodes.Count - 1].Remove();

                logger.Error("Export DataSource", ex);
                MessageBoxHelper.Display(ex.Message);
                return;
            }

            this.clearCtxMenuItem.Enabled = true;
            this.statusBarReady.Text = string.Format("Export DataSource {0}", menuItem.Text);
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
            OptionsDialog.Display(this,"DataSource Manager.DataSources");
        }

        private void toolsTemplatesMenuItem_Click(object sender, EventArgs e)
        {
            OptionsDialog.Display(this, "Template Manager.Templates");
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
            this.treeView.Nodes.Clear();
            this.clearCtxMenuItem.Enabled = false;
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
        #endregion

        #region Generation Settings Handlers

        private void saveSettingsBtn_Click(object sender, EventArgs e)
        {
            this.fileSaveMenuItem_Click(sender, e);
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            this.generateBtn.Enabled = false;
            this.completedLbl.Visible = false;

            try
            {
                for(int i =1;i<11;i++){
                    this.genProgressBar.Value = i * 10;
                    this.currentGenFileNameLbl.Text = i.ToString();
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Generate", ex);
            }

            this.generateBtn.Enabled = true;
            this.completedLbl.Visible = true;
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

        private void AddDataSourceMenuItems(ToolStripMenuItem parent)
        {
            parent.DropDownItems.Clear();
            foreach (DataSourceElement dataSource in ConfigManager.DataSourceSection.DataSources)
            {
                ToolStripMenuItem ds = new ToolStripMenuItem(dataSource.Name);
                //ds.ToolTipText = dataSource.ConnectionString;
                ds.Click += new EventHandler(fileExportDataSourceMenuItem_Click);
                parent.DropDownItems.Add(ds);
            }
        }

        private void ChangeTemplateListBox(string language, string engine)
        {
            this.templateListBox.Items.Clear();
            language = ConfigManager.SettingsSection.Languages[language].Alias;
            foreach (TemplateElement template in ConfigManager.TemplateSection.Templates)
            {
                if(template.Language.Equals(language,StringComparison.CurrentCultureIgnoreCase) &&
                    template.Engine.Equals(engine, StringComparison.CurrentCultureIgnoreCase))
                this.templateListBox.Items.Add(template.Name);
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
            this.templateListBox.SelectedItem = settings.Template;
            this.codeFileEncodingCombox.Text = settings.Encoding;
            this.isOmitTablePrefixChkbox.Checked = settings.IsOmitTablePrefix;
            this.isStandardizeNameChkbox.Checked = settings.IsStandardizeName;
        }

        private GenerationSettings GetGenerationSettings()
        {
            GenerationSettings settings = new GenerationSettings(this.languageCombx.Text,
                this.templateEngineCombox.Text, this.packageTxtBox.Text, this.tablePrefixTxtBox.Text,
                this.authorTxtBox.Text, this.versionTxtBox.Text,
                this.templateListBox.SelectedItem == null ? string.Empty : this.templateListBox.SelectedItem.ToString(),
                this.codeFileEncodingCombox.Text, this.isOmitTablePrefixChkbox.Checked, this.isStandardizeNameChkbox.Checked);
            return settings;
        }

        #endregion	

        
    }
}
