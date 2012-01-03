using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.TemplateEngine
{
    public class RazorEngineAdapter : ITemplateEngine
    {
        public RazorEngineAdapter() { }

        public bool Run(TemplateData templateData)
        {
            return true;
        }
    }
}
