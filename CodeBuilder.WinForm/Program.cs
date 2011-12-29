using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CodeBuilder.WinForm
{
    using UI;
    using Util;
    using Configuration;

    static class Program
    {
        static Logger logger = InternalTrace.GetLogger(typeof(Program));

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                AppContainer c = new AppContainer();
                MainForm form = new MainForm();
                c.Add(form);

                Application.Run(form);
            }
            catch (Exception ex)
            {
                logger.Error("", ex);
                MessageBoxHelper.DisplayFailure(ex.Message);
                return;
            }

            InternalTrace.Close();
        }

        static void LoadSettings()
        {
            //string traceLevel = Enum.Parse(InternalTraceLevel.Default.GetType(), result.ToString(), true);
            //InternalTrace.Initialize("CodeBuilder_%p.log",
            //    (InternalTraceLevel)ConfigManager.OptionSection.Options["Options.InternalTraceLevel"].Value);
        }
    }
}
