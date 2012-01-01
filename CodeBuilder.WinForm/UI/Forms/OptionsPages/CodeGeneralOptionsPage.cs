using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CodeBuilder.WinForm.UI.OptionsPages
{
    using Util;
    using Configuration;

    public partial class CodeGeneralOptionsPage : BaseOptionsPage
    {
        private static Logger logger = InternalTrace.GetLogger(typeof(CodeGeneralOptionsPage));

        public CodeGeneralOptionsPage()
        {
            InitializeComponent();
        }

        public CodeGeneralOptionsPage(string key)
            : base(key)
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
            this.isLoaded = true;
            this.ouputPathTxtbox.Text = ConfigManager.GenerationCodeOuputPath;
            this.templatePathTxtbox.Text = ConfigManager.TemplatePath;
        }

        public override void ApplySettings()
        {
            try
            {
                string templatePath = this.templatePathTxtbox.Text;
                string ouputPath = this.ouputPathTxtbox.Text;

                if(!Directory.Exists(templatePath)) Directory.CreateDirectory(templatePath);
                if(!Directory.Exists(ouputPath)) Directory.CreateDirectory(ouputPath);

                ConfigManager.OptionSection.Options["CodeGeneration.General.TemplatePath"].Value = templatePath;
                ConfigManager.OptionSection.Options["CodeGeneration.General.OutputPath"].Value = ouputPath;
                ConfigManager.RefreshOptions();
                ConfigManager.Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Save Options.CodeGeneration.General Failure", ex);
            }
        }

        private void ouputPathBtn_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.ouputPathTxtbox.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        private void templatePathBtn_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.templatePathTxtbox.Text = this.folderBrowserDialog.SelectedPath;
            }
        }
    }
}
