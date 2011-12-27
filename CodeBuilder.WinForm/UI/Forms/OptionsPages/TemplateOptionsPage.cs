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
            this.SetComboBoxItems();
        }

        public override void ApplySettings()
        {
        }

        #region Event Handlers

        private void templateListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        #endregion

        #region Helper methods for modifying the UI display

        private void SetComboBoxItems()
        {
            this.languageCombox.Items.Clear();
            this.engineCombox.Items.Clear();

            foreach (LanguageElement language in CodeBuilderConfiguration.Settings.Languages)
            {
                this.languageCombox.Items.Add(language.Name);
            }

            foreach (TemplateEngineElement templateEngine in CodeBuilderConfiguration.Settings.TemplateEngines)
            {
                this.engineCombox.Items.Add(templateEngine.Name);
            }

            this.languageCombox.Text = this.languageCombox.Items[0].ToString();
            this.engineCombox.Text = this.engineCombox.Items[0].ToString();
        }

        #endregion	
    }
}
