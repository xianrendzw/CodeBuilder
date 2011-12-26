using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;

namespace CodeBuilder.Configuration
{
    using Util;

    public class CodeBuilderConfiguration
    {
        private static SettingsSection settings;
        private static TypeMappingSection typeMapping;

        #region Class Constructor

        /// <summary>
        /// Class constructor initializes fields from config file
        /// </summary>
        static CodeBuilderConfiguration()
        {
            try
            {
                settings = (SettingsSection)GetConfigSection("codebuilder/settings");
                typeMapping = (TypeMappingSection)GetConfigSection("codebuilder/typeMapping");
            }
            catch (Exception ex)
            {
                string msg = string.Format("Invalid configuration in {0}",
                    AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                throw new ApplicationException(msg, ex);
            }
        }

        private static object GetConfigSection(string name)
        {
            return System.Configuration.ConfigurationManager.GetSection(name);
        }

        #endregion

        #region Public Properties

        public static SettingsSection Settings
        {
            get { return settings; }
        }

        public static TypeMappingSection TypeMapping
        {
            get { return typeMapping; }
        }

        private static string applicationDataDirectory;
        public static string ApplicationDataDirectory
        {
            get
            {
                if (applicationDataDirectory == null)
                {
                    applicationDataDirectory = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        "CodeBuilder");
                }

                return applicationDataDirectory;
            }
        }

        public static string AppCurrentDirectory
        {
            get { return Environment.CurrentDirectory; }
        }

        private static string libDirectory;
        public static string LibDirectory
        {
            get
            {
                if (libDirectory == null)
                {
                    libDirectory =
                        AssemblyHelper.GetDirectoryName(Assembly.GetExecutingAssembly());
                }

                return libDirectory;
            }
        }

        private static string binDirectory;
        public static string BinDirectory
        {
            get
            {
                if (binDirectory == null)
                {
                    binDirectory = LibDirectory;
                    if (Path.GetFileName(binDirectory).ToLower() == "lib")
                        binDirectory = Path.GetDirectoryName(binDirectory);
                }

                return binDirectory;
            }
        }

        public static string LogDirectory
        {
            get { return Path.Combine(Environment.CurrentDirectory, "logs"); }
        }

        public static string HelpUrl
        {
            get
            {
                string helpUrl = Settings.AppSettings["helpUrl"].Value;
                if (helpUrl != null)
                {
                    return helpUrl;
                }

                helpUrl = "http://www.dengzhiwei.com/category/codebuilder";
                string dir = Path.GetDirectoryName(BinDirectory);
                if (dir == null)
                {
                    return helpUrl;
                }

                dir = Path.GetDirectoryName(dir);
                if (dir == null)
                {
                    return helpUrl;
                }

                string localPath = Path.Combine(dir, @"doc/index.html");
                if (File.Exists(localPath))
                {
                    UriBuilder uri = new UriBuilder();
                    uri.Scheme = "file";
                    uri.Host = "localhost";
                    uri.Path = localPath;
                    helpUrl = uri.ToString();
                }
                return helpUrl;
            }
        }

        public static string FeedbackUrl
        {
            get
            {
                string feedbackUrl = Settings.AppSettings["feedbackUrl"].Value;
                if (feedbackUrl != null)
                {
                    return feedbackUrl;
                }
                return feedbackUrl = "http://www.dengzhiwei.com/category/codebuilder-feedback";
            }
        }
        #endregion
    }
}
