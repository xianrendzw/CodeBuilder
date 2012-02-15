using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CodeBuilder.WinForm
{
    using Configuration;
    using Properties;
    using UI;
    using Util;

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
                InitializeTraceLevel();

                AppContainer container = new AppContainer();
                MainForm form = new MainForm();
                container.Add(form);

                logger.Info(Resources.StartingCodeBuilder);
                Application.Run(form);
                logger.Info(Resources.CodeBuilderExit); 
            }
            catch (Exception ex)
            {
                logger.Error(Resources.Startup, ex);
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
