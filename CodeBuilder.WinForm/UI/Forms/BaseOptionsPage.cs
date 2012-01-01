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
    using Util;
    using Configuration;

    public partial class BaseOptionsPage : UserControl
    {
        private string key;
        private string title;
        protected bool isLoaded;

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
            if (!DesignMode) this.LoadSettings();
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
            get { return this.isLoaded; }
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
