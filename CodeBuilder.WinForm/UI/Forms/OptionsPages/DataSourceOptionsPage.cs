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

    public partial class DataSourceOptionsPage : BaseOptionsPage
    {
        public DataSourceOptionsPage()
        {
            InitializeComponent();
        }

        public DataSourceOptionsPage(string key)
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

        private void datasourceListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void removeBtn_Click(object sender, EventArgs e)
        {

        }

        private void newsaveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
