using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CodeBuilder.WinForm
{
    using UiKit;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppContainer c = new AppContainer();
            MainForm form = new MainForm();
            c.Add(form);

            Application.Run(form);
        }
    }
}
