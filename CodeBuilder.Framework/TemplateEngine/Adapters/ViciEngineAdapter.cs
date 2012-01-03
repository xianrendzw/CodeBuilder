using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.TemplateEngine
{
    public class ViciEngineAdapter : ITemplateEngine
    {
        public ViciEngineAdapter() { }

        public bool Run(TemplateData templateData)
        {
            return true;
        }
    }
}
