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

    public partial class RecentFilesOptionsPage : BaseOptionsPage
    {
        public RecentFilesOptionsPage()
        {
            InitializeComponent();
        }

        public RecentFilesOptionsPage(string key)
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
    }
}
