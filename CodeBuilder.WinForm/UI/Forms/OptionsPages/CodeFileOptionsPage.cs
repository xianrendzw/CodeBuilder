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

    public partial class CodeFileOptionsPage : BaseOptionsPage
    {
        public CodeFileOptionsPage()
        {
            InitializeComponent();
        }

        public CodeFileOptionsPage(string key)
            : base(key)
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
        }

        public override void ApplySettings()
        {
        }

        private void openFolderDialogBtn_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.ouputPathTextBox.Text = this.folderBrowserDialog.SelectedPath;
            }
        }
    }
}
