using System;
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
        }

        #region Menu Handlers

        #region File Menu
        private void fileOpenMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "Generation Settings (*.xml)|*.xml";
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string xmlFileName = this.openFileDialog.FileName;
                this.clearCtxMenuItem.Enabled = true;
            }
        }

        private void fileImportPdmMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "Physical Data Model (*.pdm)|*.pdm";
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdmFileName = this.openFileDialog.FileName;
                try
                {
                    ImportModelHelper.Import(pdmFileName, this.treeView);
                    this.treeView.ExpandAll();
                    this.clearCtxMenuItem.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.Display(ex.Message);
                }
            }
        }

        private void fileImportMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ImportModelHelper.CheckedTreeNode(e.Node);
        }

        #endregion

        #region Tools Menu

        private void toolsSettngsMenuItem_Click(object sender, EventArgs e)
        {
            SettingsOptionDialog.Display(this);
        }

        #endregion

        #region Help Menu

        private void helpF1MenuItem_Click(object sender, EventArgs e)
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

        private void generateBtn_Click(object sender, EventArgs e)
        {
            List<string> l = ImportModelHelper.GetCheckedTags(this.treeView.Nodes);
            int n = l.Count;
        }

        #endregion

        private void openCtxMenuItem_Click(object sender, EventArgs e)
        {
            this.fileOpenMenuItem_Click(sender, e);
        }

        private void importPDMCtxMenuItem_Click(object sender, EventArgs e)
        {
            this.fileImportPdmMenuItem_Click(sender, e);
        }

        private void importDataSourceCtxMenuItem_Click(object sender, EventArgs e)
        {
            this.fileImportMenuItem_Click(sender, e);
        }

        private void clearCtxMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView.Nodes.Clear();
            this.clearCtxMenuItem.Enabled = false;
        }

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
    }
}
