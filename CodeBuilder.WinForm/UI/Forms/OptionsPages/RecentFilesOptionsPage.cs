using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder.WinForm.UI.OptionsPages
{
    using Configuration;
    using Properties;
    using Util;

    public partial class RecentFilesOptionsPage : BaseOptionsPage
    {
        private static Logger logger = InternalTrace.GetLogger(typeof(RecentFilesOptionsPage));

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
            this.recentFilesCountTextBox.Text = ConfigManager.OptionSection.Options["Environment.RecentFiles.MaxFiles"].Value;
            string value = ConfigManager.OptionSection.Options["Environment.RecentFiles.IsCheckFileExist"].Value;
            this.checkFilesExistCheckBox.Checked = ConvertHelper.GetBoolean(value);
        }

        public override void ApplySettings()
        {
            try
            {
                ConfigManager.OptionSection.Options["Environment.RecentFiles.MaxFiles"].Value = this.recentFilesCountTextBox.Text;
                ConfigManager.OptionSection.Options["Environment.RecentFiles.IsCheckFileExist"].Value = this.checkFilesExistCheckBox.Checked.ToString();
                ConfigManager.RefreshOptions();
                ConfigManager.Save(); 
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Resources.SaveEnvironmentRecentFilesFailure, ex);
            }
        }
    }
}
