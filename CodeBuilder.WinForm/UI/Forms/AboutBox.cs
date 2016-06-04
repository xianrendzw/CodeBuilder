using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace CodeBuilder.WinForm.UI
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            this.SetAboutInfo();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void infoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.infoLinkLabel.Text);
            infoLinkLabel.LinkVisited = true;
        }

        private void SetAboutInfo()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string versionText = executingAssembly.GetName().Version.ToString();
            this.versionLabel.Text = versionText;

            dotNetVersionLabel.Text = string.Format(".Net Framework {0}", Environment.Version);
        }
    }
}
