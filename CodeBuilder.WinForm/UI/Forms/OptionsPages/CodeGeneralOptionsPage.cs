using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder.WinForm.UI.OptionsPages
{
    using Util;
    using Configuration;

    public partial class CodeGeneralOptionsPage : BaseOptionsPage
    {
        public CodeGeneralOptionsPage()
        {
            InitializeComponent();
        }

        public CodeGeneralOptionsPage(string key)
            : base(key)
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
            this.isLoaded = true;
        }

        public override void ApplySettings()
        {
        }

        private void ouputPathBtn_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.ouputPathTxtbox.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        private void templatePathBtn_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.templatePathTxtbox.Text = this.folderBrowserDialog.SelectedPath;
            }
        }
    }
}
