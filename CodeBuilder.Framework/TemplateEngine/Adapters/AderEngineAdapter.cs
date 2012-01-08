using System;
using System.Text;
using System.IO;
using Ader.TemplateEngine;

namespace CodeBuilder.TemplateEngine
{
    using Util;

    public class AderEngineAdapter : ITemplateEngine
    {
        private static Logger logger = InternalTrace.GetLogger(typeof(AderEngineAdapter));

        public AderEngineAdapter() { }

        public bool Run(TemplateData templateData)
        {
            try
            {
                TemplateManager mngr = TemplateManager.FromFile(templateData.TemplateFileName);
                mngr.SetValue("tdo", templateData);

                using (StreamWriter StreamWriter = new StreamWriter(templateData.CodeFileName,
                    false, Encoding.GetEncoding(templateData.Encoding)))
                {
                    mngr.Process(StreamWriter);
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(String.Format("AderEngineAdapter:{0}", templateData.CodeFileName), ex);
                return false;
            }
        }
    }
}
