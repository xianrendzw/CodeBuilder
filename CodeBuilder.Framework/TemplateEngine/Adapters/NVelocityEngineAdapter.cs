using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NVelocity;
using NVelocity.App;
using NVelocity.Context;
using NVelocity.Runtime; 

namespace CodeBuilder.TemplateEngine
{
    using Util;

    public class NVelocityAdapter : ITemplateEngine
    {
        private static Logger logger = InternalTrace.GetLogger(typeof(NVelocityAdapter));
        private VelocityEngine velocityEngine;

        public NVelocityAdapter() {
            velocityEngine = new VelocityEngine();
        }

        public bool Run(TemplateData templateData)
        {
            VelocityContext context = new VelocityContext();
            context.Put("tdo", templateData);

            try
            {
                string loaderPath = Path.GetDirectoryName(templateData.TemplateFileName);
                string templateFile = Path.GetFileName(templateData.TemplateFileName);
                velocityEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, loaderPath);
                velocityEngine.Init();

                Template template = velocityEngine.GetTemplate(templateFile);
                StreamWriter writer = new StreamWriter(templateData.CodeFileName, false, Encoding.GetEncoding(templateData.Encoding));
                template.Merge(context, writer);
                writer.Close();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(String.Format("NVelocityAdapter:{0}", templateData.CodeFileName), ex);
                return false;
            }
        }
    }
}
