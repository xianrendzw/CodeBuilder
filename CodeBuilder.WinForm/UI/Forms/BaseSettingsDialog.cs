using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder.WinForm.UI
{
    using Configuration;

    public partial class BaseSettingsDialog : Form
    {
        public BaseSettingsDialog()
        {
            InitializeComponent();
            this.settingsPages = new SettingsPageList(6);
        }

        #region Properties

        private SettingsPageList settingsPages;
        public SettingsPageList SettingsPages
        {
            get { return settingsPages; }
        }

        #endregion

        #region Public Methods

        public void ApplySettings()
        {
            foreach (SettingsPage page in settingsPages)
            {
                if (page.SettingsLoaded) page.ApplySettings();
            }
        }

        #endregion

        #region Event Handlers

        //private bool reloadProjectOnClose;
        private void BaseSettingsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (this.reloadProjectOnClose)
            //    Services.TestLoader.ReloadTest();
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            //if (Services.TestLoader.IsTestLoaded && this.HasChangesRequiringReload)
            //{
            //    DialogResult answer = MessageBoxHelper.Ask(
            //        "Some changes will only take effect when you reload the test project. Do you want to reload now?",
            //        "NUnit Options",
            //        MessageBoxButtons.YesNo);

            //    if (answer == DialogResult.Yes)
            //        this.reloadProjectOnClose = true;
            //}

            ApplySettings();
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region Helper Methods

        private bool HasChangesRequiringReload
        {
            get
            {
                foreach (SettingsPage page in settingsPages)
                {
                    if (page.SettingsLoaded && page.HasChangesRequiringReload)
                        return true;
                }
                return false;
            }
        }
        #endregion

        #region Nested SettingsPageCollection Class

        public class SettingsPageList : List<SettingsPage>
        {
            public SettingsPageList()
                : base() { }

            public SettingsPageList(int capacity)
                : base(capacity)
            {
            }

            public SettingsPage this[string key]
            {
                get
                {
                    return this.FirstOrDefault(x => x.Key == key);
                }
            }
        }
        #endregion
    }
}
