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

    public partial class TemplateOptionsPage : BaseOptionsPage
    {
        public TemplateOptionsPage()
        {
            InitializeComponent();
        }

        public TemplateOptionsPage(string key)
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

        private void templateListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialogBtn_Click(object sender, EventArgs e)
        {

        }

        private void editBtn_Click(object sender, EventArgs e)
        {

        }

        private void removeBtn_Click(object sender, EventArgs e)
        {

        }

        private void newsaveBtn_Click(object sender, EventArgs e)
        {

        }

        private void getItFromOnlineBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
