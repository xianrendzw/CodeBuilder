using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder.WinForm.UI.OptionsPages
{
    using Configuration;
    using Util;

    public partial class TemplateOptionsPage : BaseOptionsPage
    {
        private static Logger logger = InternalTrace.GetLogger(typeof(TemplateOptionsPage));
        private Dictionary<string, TemplateItem> listBoxItems = new Dictionary<string, TemplateItem>(20);

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
            this.isLoaded = true;
            this.SetComboBoxItems();
            this.ListTemplateItems();
        }

        public override void ApplySettings()
        {
            try
            {
                this.SaveChanged();
                ConfigManager.Save();
                ConfigManager.RefreshTemplates();
            }
            catch (Exception ex)
            {
                logger.Error("Save Template Items", ex);
            }
        }

        #region Event Handlers

        private void templateListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.templateListbox.SelectedItem == null) return;
            this.SelectedListBoxItem(this.templateListbox.SelectedItem.ToString());
        }

        private void openFileDialogBtn_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.filePathTextbox.Text = this.openFileDialog.FileName;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (this.filePathTextbox.Text.Trim().Length == 0) return;

            try
            {
                System.Diagnostics.Process.Start("Notepad.exe", this.filePathTextbox.Text);
            }
            catch (Exception ex)
            {
                logger.Error("Edit Template File", ex);
                MessageBoxHelper.DisplayFailure("Edit template file failure!");
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {

            object selectedItem = this.templateListbox.SelectedItem;
            if (selectedItem == null) return;

            string name = selectedItem.ToString().Trim().ToLower();
            this.listBoxItems[name].Status = TemplateItemStatus.Deleted;

            try
            {
                this.templateListbox.Items.RemoveAt(this.templateListbox.SelectedIndex);
            }
            catch (Exception ex)
            {
                logger.Error("Remove template item failure!", ex);
                MessageBoxHelper.DisplayFailure("Remove template item failure!");
            }
        }

        private void newsaveBtn_Click(object sender, EventArgs e)
        {
            string language = this.languageCombox.Text.Trim();
            string engine = this.engineCombox.Text.Trim();
            string name = this.nameTxtbox.Text.Trim();
            string path = this.filePathTextbox.Text.Trim();

            if (name.Trim().Length == 0 ||
                path.Trim().Length == 0)
            {
                MessageBoxHelper.Display("name or connectionstring cann't set empty");
                return;
            }

            if (this.listBoxItems.ContainsKey(name.ToLower()))
            {
                this.listBoxItems[name.ToLower()].Name = name;
                this.listBoxItems[name.ToLower()].Language = language;
                this.listBoxItems[name.ToLower()].Engine = engine;
                this.listBoxItems[name.ToLower()].Path = path;
                this.listBoxItems[name.ToLower()].Status = TemplateItemStatus.Edit;
                return;
            }

            this.listBoxItems.Add(name.ToLower(), new TemplateItem(name, language, engine, TemplateItemStatus.New));
            this.templateListbox.Items.Add(name);
        }

        private void getItFromOnlineBtn_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Helper methods for modifying the UI display

        private void SetComboBoxItems()
        {
            this.languageCombox.Items.Clear();
            this.engineCombox.Items.Clear();

            foreach (LanguageElement language in ConfigManager.SettingsSection.Languages)
            {
                this.languageCombox.Items.Add(language.Name);
            }

            foreach (TemplateEngineElement templateEngine in ConfigManager.SettingsSection.TemplateEngines)
            {
                this.engineCombox.Items.Add(templateEngine.Name);
            }

            this.languageCombox.Text = this.languageCombox.Items[0].ToString();
            this.engineCombox.Text = this.engineCombox.Items[0].ToString();
        }

        private void ListTemplateItems()
        {
            this.templateListbox.Items.Clear();
            this.listBoxItems.Clear();

            foreach (TemplateElement template in ConfigManager.TemplateSection.Templates)
            {
                this.templateListbox.Items.Add(template.Name);
                string name = template.Name.Trim().ToLower();
                if (!listBoxItems.ContainsKey(name))
                    listBoxItems.Add(name, new TemplateItem(template.Name, template.Language, template.Engine));
            }
        }

        private void SelectedListBoxItem(string selectedItem)
        {
            string name = selectedItem.Trim().ToLower();
            if (!listBoxItems.ContainsKey(name)) return;

            this.languageCombox.Text = listBoxItems[name].Language;
            this.engineCombox.Text = listBoxItems[name].Engine;
            this.nameTxtbox.Text = listBoxItems[name].Name;
            this.filePathTextbox.Text = listBoxItems[name].Path;
        }

        private void SaveChanged()
        {
            foreach (var item in this.listBoxItems)
            {
                if (item.Value.Status == TemplateItemStatus.None) continue;
                if (item.Value.Status == TemplateItemStatus.Deleted)
                    ConfigManager.TemplateSection.Templates.Remove(item.Value.Name);

                string templateFileName = this.CopyTemplateFile(item.Value.Name, item.Value.Language, item.Value.Engine, item.Value.Path);
                if (string.IsNullOrEmpty(templateFileName)) continue;

                if (item.Value.Status == TemplateItemStatus.New)
                {
                    TemplateElement element = new TemplateElement();
                    element.Name = item.Value.Name;
                    element.Language = item.Value.Language;
                    element.Engine = item.Value.Engine;
                    element.Path = item.Value.Path;
                    element.Url = item.Value.Url;
                    element.Description = item.Value.Description;
                    ConfigManager.TemplateSection.Templates.Add(element);
                    continue;
                }
                if (item.Value.Status == TemplateItemStatus.Edit)
                {
                    ConfigManager.TemplateSection.Templates[item.Value.Name].Name = item.Value.Name;
                    ConfigManager.TemplateSection.Templates[item.Value.Name].Language = item.Value.Language;
                    ConfigManager.TemplateSection.Templates[item.Value.Name].Engine = item.Value.Engine;
                    ConfigManager.TemplateSection.Templates[item.Value.Name].Path = item.Value.Path;
                    ConfigManager.TemplateSection.Templates[item.Value.Name].Url = item.Value.Url;
                    ConfigManager.TemplateSection.Templates[item.Value.Name].Description = item.Value.Description;
                    continue;
                }
            }
        }

        private string CopyTemplateFile(string templateName,string language,string engine, string srcFileName)
        {
            string destFileName = string.Empty;

            try
            {
                destFileName = Path.Combine(ConfigManager.TemplatePath, language, engine, templateName.Trim().ToLower());
                File.Copy(srcFileName, destFileName, true);
            }
            catch (Exception ex)
            {
                destFileName = string.Empty;
                logger.Error(string.Format("Saved template file: {0} failure!", srcFileName), ex);
            }

            return destFileName;
        }

        #endregion	

        private class TemplateItem
        {
            public TemplateItem() { }

            public TemplateItem(string name, string language, string engine)
                : this(name, language, engine,TemplateItemStatus.None)
            {
            }

            public TemplateItem(string name, string language, string engine, 
                TemplateItemStatus status)
                : this(name, language, engine, string.Empty, string.Empty, string.Empty, status)
            {
            }

            public TemplateItem(string name, string language, string engine,
                string path,string url,string desc,TemplateItemStatus status)
            {
                this.Name = name;
                this.Language = language;
                this.Engine = engine;
                this.Path = path;
                this.Url = url;
                this.Description = desc;
                this.Status = status;
            }

            public string Name { get; set; }
            public string Language { get; set; }
            public string Engine { get; set; }
            public string Path { get; set; }
            public string Url { get; set; }
            public string Description { get; set; }
            public TemplateItemStatus Status { get; set; }
        }

        private enum TemplateItemStatus
        {
            None,
            Edit,
            New,
            Deleted,
        }
    }
}
