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

    public partial class GenerationOptionsPage : BaseOptionsPage
    {
        public GenerationOptionsPage()
        {
            InitializeComponent();
        }

        public GenerationOptionsPage(string key)
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
    }
}
