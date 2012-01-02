using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NVelocity;

namespace CodeBuilder.TemplateEngine
{
    public class NVelocityAdapter : ITemplateEngine
    {
        public NVelocityAdapter() { }

        public void Run(TemplateData templateData)
        {
            System.Threading.Thread.Sleep(10);
        }
    }
}
