﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public MainForm()
        {
            InitializeComponent();

            this.InitializeUIData();
        }

        private void InitializeUIData()
        {
            this.SetComboBoxItems();
            this.AddDataSourceMenuItems(this.fileExportDataSourceMenuItem);
            this.AddDataSourceMenuItems(this.exportDataSourceCtxMenuItem);
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
                this.clearCtxMenuItem.Enabled = true;
            }
        }

        private void fileSaveMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.Filter = "Generation Settings (*.xml)|*.xml";
            this.saveFileDialog.DefaultExt = ".xml";
            this.saveFileDialog.FileName = "New_GenerationSettings.xml";
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string xmlFileName = this.saveFileDialog.FileName;

            }
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
                    ExportModelHelper.Export(pdmFileName, this.treeView);
                    this.treeView.ExpandAll();
                    this.clearCtxMenuItem.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.Display(ex.Message);
                }
            }
        }

        private void fileExportDataSourceMenuItem_Click(object sender, EventArgs e)
        {
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
            using (DataSourceConfigBox dialog = new DataSourceConfigBox())
            {
                dialog.ShowDialog();
            }
        }

        private void toolsTemplatesMenuItem_Click(object sender, EventArgs e)
        {
            using (TemplateConfigBox dialog = new TemplateConfigBox())
            {
                dialog.ShowDialog();
            }
        }
        #endregion

        #region Help

        private void helpF1MenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(CodeBuilderConfiguration.HelpUrl);
        }

        private void helpFeedbackMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(CodeBuilderConfiguration.HelpUrl);
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

        private void exportDataSourceCtxMenuItem_Click(object sender, EventArgs e)
        {
            this.fileExportDataSourceMenuItem_Click(sender, e);
        }

        private void clearCtxMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView.Nodes.Clear();
            this.clearCtxMenuItem.Enabled = false;
        }
        #endregion

        #region Generation Settings
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
            List<string> l = ExportModelHelper.GetCheckedTags(this.treeView.Nodes);
            int n = l.Count;
            MessageBoxHelper.Display(n.ToString());
        }
        #endregion

        #region Helper methods for modifying the UI display

        private void SetComboBoxItems()
        {
            this.languageCombx.Items.Clear();
            this.templateEngineCombox.Items.Clear();
            this.codeFileEncodingCombox.Items.Clear();

            foreach (LanguageElement language in CodeBuilderConfiguration.Settings.Languages)
            {
                this.languageCombx.Items.Add(language.Name);
            }

            foreach (TemplateEngineElement templateEngine in CodeBuilderConfiguration.Settings.TemplateEngines)
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

        private void AddDataSourceMenuItems(ToolStripMenuItem parent)
        {
            parent.DropDownItems.Clear();
            for (int i = 0; i < 10; i++)
            {
                ToolStripMenuItem ds = new ToolStripMenuItem("DataSource1");
                ds.Click += new EventHandler(generateBtn_Click);
                parent.DropDownItems.Add(ds);
            }
        }
        #endregion	


    }
}
