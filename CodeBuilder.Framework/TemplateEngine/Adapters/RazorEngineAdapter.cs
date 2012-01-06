using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RazorEngine;
using RazorEngine.Templating;

namespace CodeBuilder.TemplateEngine
{
    using Util;

    public class RazorEngineAdapter : ITemplateEngine
    {
        private static Logger logger = InternalTrace.GetLogger(typeof(RazorEngineAdapter));

        public RazorEngineAdapter() { }

        public bool Run(TemplateData templateData)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(templateData.CodeFileName, 
                    false, Encoding.GetEncoding(templateData.Encoding)))
                {
                    writer.Write(Razor.Parse(File.ReadAllText(templateData.TemplateFileName), templateData));
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(String.Format("RazorEngineAdapter:{0}", templateData.CodeFileName), ex);
                return false;
            }
        }
    }
}
