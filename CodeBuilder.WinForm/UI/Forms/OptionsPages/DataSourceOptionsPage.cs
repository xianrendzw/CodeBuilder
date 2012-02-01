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
    using Properties;
    using Util;
    using Configuration;

    public partial class DataSourceOptionsPage : BaseOptionsPage
    {
        private static Logger logger = InternalTrace.GetLogger(typeof(DataSourceOptionsPage));
        private Dictionary<string, DataSourceItem> listBoxItems = new Dictionary<string, DataSourceItem>(10);

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
            this.ListExporterItems();
            this.ListDataSourceItems();
        }

        public override void ApplySettings()
        {
            try
            {
                this.SaveChanged();
                this.listBoxItems.Clear();
                ConfigManager.RefreshDataSources();
                ConfigManager.Save();  
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Resources.SaveDataSourceItemsFailure, ex);
            }
        }

        #region Event Handlers

        private void datasourceListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.datasourceListbox.SelectedItem == null) return;
            this.SelectedListBoxItem(this.datasourceListbox.SelectedItem.ToString());
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            object selectedItem = this.datasourceListbox.SelectedItem;
            if (selectedItem == null) return;

            string name = selectedItem.ToString().Trim().ToLower();
            this.listBoxItems[name].Status = DataSourceItemStatus.Deleted;

            try
            {
                this.datasourceListbox.Items.RemoveAt(this.datasourceListbox.SelectedIndex);
            }
            catch (Exception ex)
            {
                logger.Error(Resources.SaveDataSourceItemsFailure, ex);
                MessageBoxHelper.DisplayFailure(Resources.SaveDataSourceItemsFailure);
            }
        }

        private void newsaveBtn_Click(object sender, EventArgs e)
        {
            string name = this.nameTxtbox.Text.Trim();
            string connString = this.connstrTxtbox.Text.Trim();
            string exporter = this.exporterCombox.Text;

            if (name.Trim().Length == 0 ||
                connString.Trim().Length == 0)
            {
                MessageBoxHelper.Display(Resources.NameOrConnectionstringCanntSetEmpty);
                return;
            }

            if (this.listBoxItems.ContainsKey(name.ToLower()))
            {
                this.listBoxItems[name.ToLower()].Name = name;
                this.listBoxItems[name.ToLower()].ConnectionString = connString;
                this.listBoxItems[name.ToLower()].Exporter = exporter;
                if (this.listBoxItems[name.ToLower()].Status != DataSourceItemStatus.New)
                    this.listBoxItems[name.ToLower()].Status = DataSourceItemStatus.Edit;
                return;
            }

            this.listBoxItems.Add(name.ToLower(), new DataSourceItem(name, connString, exporter, DataSourceItemStatus.New));
            this.datasourceListbox.Items.Add(name);
        }

        #endregion

        #region Helper methods for modifying the UI display

        private void ListExporterItems()
        {
            this.exporterCombox.Items.Clear();
            foreach (ExporterElement exporter in ConfigManager.SettingsSection.Exporters)
            {
                this.exporterCombox.Items.Add(exporter.Name);
            }

            this.exporterCombox.Text = this.exporterCombox.Items[0].ToString();
        }

        private void ListDataSourceItems()
        {
            this.datasourceListbox.Items.Clear();
            this.listBoxItems.Clear();

            foreach (DataSourceElement dataSource in ConfigManager.DataSourceSection.DataSources)
            {
                this.datasourceListbox.Items.Add(dataSource.Name);
                string name = dataSource.Name.Trim().ToLower();
                if (!listBoxItems.ContainsKey(name))
                    listBoxItems.Add(name, new DataSourceItem(dataSource.Name, dataSource.ConnectionString, dataSource.Exporter));
            }
        }

        private void SelectedListBoxItem(string selectedItem)
        {
            string name = selectedItem.Trim().ToLower();
            if (!listBoxItems.ContainsKey(name)) return;

            this.nameTxtbox.Text = listBoxItems[name].Name;
            this.connstrTxtbox.Text = listBoxItems[name].ConnectionString;
            this.exporterCombox.Text = listBoxItems[name].Exporter;
        }

        private void SaveChanged()
        {
            foreach (var item in this.listBoxItems)
            {
                if (item.Value.Status == DataSourceItemStatus.None) continue;
                if (item.Value.Status == DataSourceItemStatus.Deleted)
                {
                    ConfigManager.DataSourceSection.DataSources.Remove(item.Value.Name);
                    continue;
                }

                if (item.Value.Status == DataSourceItemStatus.New)
                {
                    DataSourceElement element = new DataSourceElement();
                    element.Name = item.Value.Name;
                    element.ConnectionString = item.Value.ConnectionString;
                    element.Exporter = item.Value.Exporter;
                    ConfigManager.DataSourceSection.DataSources.Add(element);
                    continue;
                }
                if (item.Value.Status == DataSourceItemStatus.Edit)
                {
                    ConfigManager.DataSourceSection.DataSources[item.Value.Name].Name = item.Value.Name;
                    ConfigManager.DataSourceSection.DataSources[item.Value.Name].ConnectionString = item.Value.ConnectionString;
                    ConfigManager.DataSourceSection.DataSources[item.Value.Name].Exporter = item.Value.Exporter;
                    continue;
                }
            }
        }

        #endregion	

        private class DataSourceItem
        {
            public DataSourceItem() { }

            public DataSourceItem(string name, string connectionString,string exporter)
                : this(name, connectionString, exporter,DataSourceItemStatus.None)
            {
            }

            public DataSourceItem(string name, string connectionString, string exporter, DataSourceItemStatus status)
            {
                this.Name = name;
                this.ConnectionString = connectionString;
                this.Status = status;
                this.Exporter = exporter;
            }

            public string Name { get; set; }
            public string ConnectionString { get; set; }
            public string Exporter { get; set; }
            public DataSourceItemStatus Status { get; set; }
        }

        private enum DataSourceItemStatus
        {
            None,
            Edit,
            New,
            Deleted,
        }
    }
}
