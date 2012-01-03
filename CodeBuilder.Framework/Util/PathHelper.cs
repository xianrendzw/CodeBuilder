using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeBuilder.Util
{
    public class PathHelper
    {
        public static void CreateCodeFileNamePath(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        public static string GetCodeFileNamePath(string outputPath, string languageAlias, string packageName, string templateName)
        {
            return Path.Combine(outputPath, templateName, languageAlias, packageName);
        }

        public static string GetCodeFileName(string outputPath, string languageAlias,
            string packageName, string templateName, string fileName)
        {
            return Path.Combine(GetCodeFileNamePath(outputPath, languageAlias, packageName, templateName), fileName);
        }
    }
}
