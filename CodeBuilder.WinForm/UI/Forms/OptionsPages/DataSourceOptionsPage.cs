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
        private static Logger logger = InternalTrace.GetLogger(typeof(DataSourceOptionsPage));

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
            this.isLoaded = true;
            this.SetComboBoxItems();
        }

        public override void ApplySettings()
        {
        }

        #region Event Handlers

        private void datasourceListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void removeBtn_Click(object sender, EventArgs e)
        {

        }

        private void newsaveBtn_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Helper methods for modifying the UI display

        private void SetComboBoxItems()
        {
            this.exporterCombox.Items.Clear();
            foreach (ExporterElement exporter in ConfigManager.SettingsSection.Exporters)
            {
                this.exporterCombox.Items.Add(exporter.Name);
            }

            this.exporterCombox.Text = this.exporterCombox.Items[0].ToString();
        }

        #endregion	
    }
}
