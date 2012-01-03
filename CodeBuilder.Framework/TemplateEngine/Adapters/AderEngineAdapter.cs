using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.TemplateEngine
{
    public class AderEngineAdapter : ITemplateEngine
    {
        public AderEngineAdapter() { }

        public bool Run(TemplateData templateData)
        {
            return true;
        }
    }
}
