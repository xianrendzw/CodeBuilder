using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder.WinForm.UI
{
    using OptionsPages;

    public class OptionsDialog
    {
        public static void Display(Form owner)
        {
            Display(owner, null);
        }

        public static void Display(Form owner, string initialPage)
        {
            TreeOptionsDialog.Display(owner, initialPage,
                new RecentFilesOptionsPage("Environment.Recent Files"),
                new CodeGeneralOptionsPage("Code Generation.General"),
                new DataSourceOptionsPage("DataSource Manager.DataSources"),
                new TemplateOptionsPage("Template Manager.Templates"),
                new TraceOptionsPage("Advanced Settings.Internal Trace"));
        }
    }
}
