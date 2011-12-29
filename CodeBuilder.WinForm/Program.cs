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

            AppContainer container = new AppContainer();
            MainForm form = new MainForm();
            container.Add(form);

            try
            {
                InitializeTraceLevel();

                logger.Info("Starting CodeBuilder");
                Application.Run(form);
                logger.Info("CodeBuilder Exit");
            }
            catch (Exception ex)
            {
                logger.Error("Startup", ex);
                MessageBoxHelper.DisplayFailure(ex.Message);
            }

            InternalTrace.Close();
        }

        static void InitializeTraceLevel()
        {
            string traceLevel = ConfigManager.OptionSection.Options["Options.InternalTraceLevel"].Value;
            InternalTraceLevel level =  (InternalTraceLevel)Enum.Parse(InternalTraceLevel.Default.GetType(), traceLevel, true);
            InternalTrace.Initialize("CodeBuilder_%p.log", level);
        }
    }
}
