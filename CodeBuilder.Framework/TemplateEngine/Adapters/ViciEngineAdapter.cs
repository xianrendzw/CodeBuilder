using System;
using System.Text;
using System.IO;
using Vici.Core.Parser;
using Vici.Core.Parser.Config;

namespace CodeBuilder.TemplateEngine
{
    using Util;

    public class ViciEngineAdapter : ITemplateEngine
    {
        private static Logger logger = InternalTrace.GetLogger(typeof(ViciEngineAdapter));

        public ViciEngineAdapter() { }

        public bool Run(TemplateData templateData)
        {
            try
            {
                TemplateParser template = new TemplateParser<DoubleCurly>();
                IParserContext data = new CSharpContext();
                data.Set<TemplateData>("tdo", templateData);

                using (var writer = new StreamWriter(templateData.CodeFileName, 
                    false, Encoding.GetEncoding(templateData.Encoding)))
                {
                    writer.Write(template.RenderFile(templateData.TemplateFileName, data));
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(String.Format("ViciEngineAdapter:{0}", templateData.CodeFileName), ex);
                return false;
            }
        }
    }
}
