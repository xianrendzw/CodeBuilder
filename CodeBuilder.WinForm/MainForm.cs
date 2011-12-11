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

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Menu Handlers

        #region File Menu
        private void fileImportPdmMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openPDMFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdmFileName = this.openPDMFileDialog.FileName;
            }
        }

        private void fileImportMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Tools Menu


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

        #endregion

    }
}
