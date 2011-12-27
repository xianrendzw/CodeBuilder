using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder.WinForm.UI
{
    using Configuration;

    public partial class BaseOptionsPage : UserControl
    {
        protected ISettings settings;
        private string key;
        private string title;

        public BaseOptionsPage()
        {
            InitializeComponent();
        }

        public BaseOptionsPage(string key)
            : this()
        {
            this.key = key;
            this.title = key;
            int dot = key.LastIndexOf('.');
            if (dot >= 0) title = key.Substring(dot + 1);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode)
            {
                //this.settings = Services.UserSettings;
                this.LoadSettings();
            }
        }

        #region Properties

        public string Key
        {
            get { return key; }
        }

        public string Title
        {
            get { return title; }
        }

        public bool IsLoaded
        {
            get { return settings != null; }
        }

        public virtual bool HasChangesRequiringReload
        {
            get { return false; }
        }

        #endregion

        #region Public Methods

        public virtual void LoadSettings()
        {
        }

        public virtual void ApplySettings()
        {
        }

        #endregion
    }
}
