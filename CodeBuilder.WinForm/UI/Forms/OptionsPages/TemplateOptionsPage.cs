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
    using Properties;
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
                this.listBoxItems.Clear();
                ConfigManager.RefreshTemplates();
                ConfigManager.Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Resources.SaveTemplateItemsFailure, ex);
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
                this.fileNameTextbox.Text = this.openFileDialog.FileName;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (this.fileNameTextbox.Text.Trim().Length == 0) return;

            try
            {
                System.Diagnostics.Process.Start("Notepad.exe", this.fileNameTextbox.Text);
            }
            catch (Exception ex)
            {
                logger.Error(Resources.EditTemplateFileFailure, ex);
                MessageBoxHelper.DisplayFailure(Resources.EditTemplateFileFailure);
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
                logger.Error(Resources.RemoveTemplateItemFailure, ex);
                MessageBoxHelper.DisplayFailure(Resources.RemoveTemplateItemFailure);
            }
        }

        private void newsaveBtn_Click(object sender, EventArgs e)
        {
            string language = this.languageCombox.Text.Trim();
            string engine = this.engineCombox.Text.Trim();
            string fileName = this.fileNameTextbox.Text.Trim();
            string displayName = this.displayNameTxtbox.Text.Trim();
            string prefix = this.prefixTxtBox.Text.Trim();
            string suffix = this.suffixTxtBox.Text.Trim();

            if (displayName.Length == 0 || fileName.Length == 0)
            {
                MessageBoxHelper.Display(Resources.DisplayNameOrFileNameCanntSetEmpty); return;
            }

            if (!File.Exists(fileName))
            {
                MessageBoxHelper.Display(Resources.TemplateFileNotFound); return;
            }

            try
            {
                string name = this.GetTemplateUniqueName(language, engine, displayName);
                if (this.listBoxItems.ContainsKey(name))
                {
                    this.listBoxItems[name].Name = name;
                    this.listBoxItems[name].Language = language;
                    this.listBoxItems[name].Engine = engine;
                    this.listBoxItems[name].FileName = fileName;
                    this.listBoxItems[name].DisplayName = displayName;
                    this.listBoxItems[name].Prefix = prefix;
                    this.listBoxItems[name].Suffix = suffix;
                    if (this.listBoxItems[name].Status != TemplateItemStatus.New)
                        this.listBoxItems[name].Status = TemplateItemStatus.Edit;

                    return;
                }

                this.listBoxItems.Add(name, new TemplateItem(name, language,
                    engine, fileName, displayName, prefix, suffix, TemplateItemStatus.New));
                this.templateListbox.Items.Add(name);
            }
            catch (Exception ex)
            {
                logger.Error(Resources.SaveOrNewTemplateFileFailure, ex);
                MessageBoxHelper.DisplayFailure(Resources.SaveOrNewTemplateFileFailure);
            }
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
                string name = template.Name.Trim();
                string fileName = Path.Combine(ConfigManager.TemplatePath, template.FileName);
                if (!listBoxItems.ContainsKey(name))
                {
                    this.templateListbox.Items.Add(name);
                    listBoxItems.Add(name, new TemplateItem(template.Name, template.Language,
                        template.Engine, fileName, template.DisplayName, template.Prefix, template.Suffix));
                }
            }
        }

        private void SelectedListBoxItem(string selectedItem)
        {
            if (selectedItem == null) return;

            string name = selectedItem.ToString();
            if (!listBoxItems.ContainsKey(name)) return;

            this.languageCombox.Text = listBoxItems[name].Language;
            this.engineCombox.Text = listBoxItems[name].Engine;
            this.displayNameTxtbox.Text = listBoxItems[name].DisplayName;
            this.fileNameTextbox.Text = listBoxItems[name].FileName;
            this.prefixTxtBox.Text = listBoxItems[name].Prefix;
            this.suffixTxtBox.Text = listBoxItems[name].Suffix;
        }

        private void SaveChanged()
        {
            foreach (var item in this.listBoxItems)
            {
                if (item.Value.Status == TemplateItemStatus.None) continue;
                if (item.Value.Status == TemplateItemStatus.Deleted)
                {
                    ConfigManager.TemplateSection.Templates.Remove(item.Value.Name);
                    continue;
                }

                item.Value.FileName = this.GetTemplateReleatedFileName(item.Value);
                if (string.IsNullOrEmpty(item.Value.FileName)) continue;

                if (item.Value.Status == TemplateItemStatus.New)
                {
                    this.AddTemplate(item.Value);
                    continue;
                }

                if (item.Value.Status == TemplateItemStatus.Edit)
                {
                    this.EditTemplate(item.Value);
                    continue;
                }
            }
        }

        private void AddTemplate(TemplateItem item)
        {
            TemplateElement element = new TemplateElement();
            element.Name = item.Name;
            element.Language = item.Language;
            element.Engine = item.Engine;
            element.FileName = item.FileName;
            element.DisplayName = item.DisplayName;
            element.Prefix = item.Prefix;
            element.Suffix = item.Suffix;
            element.Url = item.Url;
            element.Description = item.Description;
            ConfigManager.TemplateSection.Templates.Add(element);
        }

        private void EditTemplate(TemplateItem item)
        {
            ConfigManager.TemplateSection.Templates[item.Name].Name = item.Name;
            ConfigManager.TemplateSection.Templates[item.Name].Language = item.Language;
            ConfigManager.TemplateSection.Templates[item.Name].Engine = item.Engine;
            ConfigManager.TemplateSection.Templates[item.Name].FileName = item.FileName;
            ConfigManager.TemplateSection.Templates[item.Name].DisplayName = item.DisplayName;
            ConfigManager.TemplateSection.Templates[item.Name].Prefix = item.Prefix;
            ConfigManager.TemplateSection.Templates[item.Name].Suffix = item.Suffix;
            ConfigManager.TemplateSection.Templates[item.Name].Url = item.Url;
            ConfigManager.TemplateSection.Templates[item.Name].Description = item.Description;
        }

        private string GetTemplateReleatedFileName(TemplateItem item)
        {
            string languageAlais = ConfigManager.SettingsSection.Languages[item.Language].Alias;
            string fileName = this.CopyTemplateFile(item.DisplayName.ToLower(), languageAlais, item.Engine, item.FileName);
            return fileName.Replace(ConfigManager.TemplatePath, "").TrimStart('\\', '/');
        }

        private string CopyTemplateFile(string displayName, string language, string engine, string srcFileName)
        {
            string destFileName = string.Empty;

            try
            {
                if (File.Exists(srcFileName))
                {
                    string path = Path.Combine(ConfigManager.TemplatePath, language, engine);
                    string enginext = ConfigManager.SettingsSection.TemplateEngines[engine].Extension;
                    destFileName = Path.Combine(path, displayName + enginext);

                    if (destFileName.Equals(srcFileName,
                        StringComparison.CurrentCultureIgnoreCase)) return srcFileName;

                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    File.Copy(srcFileName, destFileName, true);
                }
            }
            catch (Exception ex)
            {
                destFileName = string.Empty;
                logger.Error(string.Format(Resources.SaveTemplateFileFailure, srcFileName), ex);
            }

            return destFileName;
        }

        private string GetTemplateUniqueName(string language, string engineName, string displayName)
        {
            string langext = ConfigManager.SettingsSection.Languages[language].Extension;
            string enginext = ConfigManager.SettingsSection.TemplateEngines[engineName].Extension;
            return string.Format("{0}{1}{2}", displayName, langext, enginext).ToLower();
        }


        #endregion	

        private class TemplateItem
        {
            public TemplateItem() { }

            public TemplateItem(string name,string language, string engine, 
                string fileName,string displayName,string prefix,string suffix)
                : this(name, language, engine, fileName, displayName,prefix,suffix,TemplateItemStatus.None)
            {
            }

            public TemplateItem(string name, string language, string engine,
                string fileName, string displayName, string prefix, string suffix, TemplateItemStatus status)
                : this(name, language, engine, fileName, displayName, prefix, suffix, "", "", status)
            {
            }

            public TemplateItem(string name, string language, string engine,
                string fileName, string displayName, string prefix, string suffix, string url, string desc, TemplateItemStatus status)
            {
                this.Name = name;
                this.Language = language;
                this.Engine = engine;
                this.FileName = fileName;
                this.DisplayName = displayName;
                this.Prefix = prefix;
                this.Suffix = suffix;
                this.Url = url;
                this.Description = desc;
                this.Status = status;
            }

            public string Name { get; set; }
            public string Language { get; set; }
            public string Engine { get; set; }
            public string FileName { get; set; }
            public string DisplayName { get; set; }
            public string Prefix { get; set; }
            public string Suffix { get; set; }
            public string Url { get; set; }
            public string Description { get; set; }
            public TemplateItemStatus Status { get; set; }
        }

        private enum TemplateItemStatus
        {
            None,
            Edit,
            New,
            Deleted
        }
    }
}
