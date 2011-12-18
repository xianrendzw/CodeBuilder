using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder.WinForm
{
    using UI;
    using UI.SettingsPages;

    public class SettingsOptionDialog
    {
        public static void Display(Form owner)
        {
            TreeSettingsDialog.Display(owner,
                new TraceSettingsPage("Advanced Settings.Internal Trace"));
        }
    }
}
