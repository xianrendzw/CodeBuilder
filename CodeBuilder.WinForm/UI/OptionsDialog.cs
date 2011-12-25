using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder.WinForm
{
    using UI;
    using UI.OptionsPages;

    public class OptionsDialog
    {
        public static void Display(Form owner)
        {
            TreeOptionsDialog.Display(owner,
                new GenerationOptionsPage("Generation.Code Generation"),
                new TraceOptionsPage("Tracing.Internal Trace"));
        }
    }
}
