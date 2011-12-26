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
        static Logger log = InternalTrace.GetLogger(typeof(Program));

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppContainer c = new AppContainer();
            MainForm form = new MainForm();
            c.Add(form);

            Application.Run(form);

            InternalTrace.Close();
        }
    }
}
