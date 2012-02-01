using System.Windows.Forms;

namespace CodeBuilder.WinForm.UI
{
    using Properties;
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
                new RecentFilesOptionsPage(Resources.EnvironmentRecentFiles),
                new CodeGeneralOptionsPage(Resources.CodeGenerationGeneral),
                new DataSourceOptionsPage(Resources.DataSourceManagerDataSources),
                new TemplateOptionsPage(Resources.TemplateManagerTemplates),
                new TraceOptionsPage(Resources.AdvancedSettingsInternalTrace));
        }
    }
}
