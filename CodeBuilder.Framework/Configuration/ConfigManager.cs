using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    using Util;
    using Exceptions;

    public class ConfigManager
    {
        private static SettingsSection settingsSection;
        private static TypeMappingSection typeMappingSection;
        private static DataSourceSection dataSourceSection;
        private static TemplateSection templateSection;
        private static OptionSection optionSection;

        #region Class Constructor

        static ConfigManager()
        {
            LoadAll();
        }

        #endregion

        #region Public Properties

        public static SettingsSection SettingsSection
        {
            get { return settingsSection; }
        }

        public static TypeMappingSection TypeMappingSection
        {
            get { return typeMappingSection; }
        }

        public static DataSourceSection DataSourceSection
        {
            get { return dataSourceSection; }
        }

        public static TemplateSection TemplateSection
        {
            get { return templateSection; }
        }

        public static OptionSection OptionSection
        {
            get { return optionSection; }
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

        public static string ConfigFileDirectory
        {
            get { return Path.Combine(Environment.CurrentDirectory, "Config"); }
        }

        public static string OptionSettingsFileName
        {
            get { return Path.Combine(ConfigFileDirectory, "Options.xml"); }
        }

        public static string DataSourceSettingsFileName
        {
            get { return Path.Combine(ConfigFileDirectory, "DataSources.xml"); }
        }

        public static string TemplateSettingsFileName
        {
            get { return Path.Combine(ConfigFileDirectory, "Templates.xml"); }
        }

        public static string HelpUrl
        {
            get
            {
                string helpUrl = SettingsSection.AppSettings["helpUrl"].Value;
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
                string feedbackUrl = SettingsSection.AppSettings["feedbackUrl"].Value;
                if (feedbackUrl != null)
                {
                    return feedbackUrl;
                }
                return feedbackUrl = "http://www.dengzhiwei.com/category/codebuilder-feedback";
            }
        }
        #endregion

        #region Public Methods

        public static void RefreshAll()
        {
            LoadAll();
        }

        public static void RefreshSettings()
        {
            try
            {
                settingsSection = (SettingsSection)GetConfigSection("codebuilder/settingsSection");
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Load 'settings' configSection failure", ex);
            }
        }

        public static void RefreshTypeMapping()
        {
            try
            {
                typeMappingSection = (TypeMappingSection)GetConfigSection("codebuilder/typeMappingSection");
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Load 'typeMapping' configSection failure", ex);
            }
        }

        public static void RefreshDataSources()
        {
            try
            {
                dataSourceSection = (DataSourceSection)GetConfigSection("codebuilder/dataSourceSection");
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Load 'dataSources' configSection failure", ex);
            }
        }

        public static void RefreshTemplates()
        {
            try
            {
                templateSection = (TemplateSection)GetConfigSection("codebuilder/templateSection");
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Load 'templates' configSection failure", ex);
            }
        }

        public static void RefreshOptions()
        {
            try
            {
                optionSection = (OptionSection)GetConfigSection("codebuilder/options");
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Load 'typeMapping' configSection failure", ex);
            }
        }

        #endregion

        #region Private Methods

        private static void LoadAll()
        {
            try
            {
                settingsSection = (SettingsSection)GetConfigSection("codebuilder/settingsSection");
                typeMappingSection = (TypeMappingSection)GetConfigSection("codebuilder/typeMappingSection");
                dataSourceSection = (DataSourceSection)GetConfigSection("codebuilder/dataSourceSection");
                templateSection = (TemplateSection)GetConfigSection("codebuilder/templateSection");
                optionSection = (OptionSection)GetConfigSection("codebuilder/optionSection");
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Load configuration failure", ex);
            }
        }

        private static object GetConfigSection(string name)
        {
            ConfigurationManager.RefreshSection(name);
            return ConfigurationManager.GetSection(name);
        }

        #endregion

        public static void Save()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            SettingsSection section = (SettingsSection)config.GetSection("codebuilder.settings");
            if (section == null) return;
            if (!section.ElementInformation.IsLocked) 
                config.Save(ConfigurationSaveMode.Modified);
            else
                throw new ConfigSectionLockedException();
        }

    }
}
