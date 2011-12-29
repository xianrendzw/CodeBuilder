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
        private static System.Configuration.Configuration config;

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
                    libDirectory = AssemblyHelper.GetDirectoryName(Assembly.GetExecutingAssembly());
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
                settingsSection = GetConfigSection<SettingsSection>("codebuilder/settingsSection");
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
                typeMappingSection = GetConfigSection<TypeMappingSection>("codebuilder/typeMappingSection");
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
                dataSourceSection = GetConfigSection<DataSourceSection>("codebuilder/dataSourceSection");
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
                templateSection = GetConfigSection<TemplateSection>("codebuilder/templateSection");
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
                optionSection = GetConfigSection<OptionSection>("codebuilder/optionSection");
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
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                settingsSection = GetConfigSection<SettingsSection>("codebuilder/settingsSection");
                typeMappingSection = GetConfigSection<TypeMappingSection>("codebuilder/typeMappingSection");
                dataSourceSection = GetConfigSection<DataSourceSection>("codebuilder/dataSourceSection");
                templateSection = GetConfigSection<TemplateSection>("codebuilder/templateSection");
                optionSection = GetConfigSection<OptionSection>("codebuilder/optionSection");
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Load configuration failure", ex);
            }
        }

        private static T GetConfigSection<T>(string name) where T:ConfigurationSection
        {
            ConfigurationManager.RefreshSection(name);
            return (T)config.GetSection(name);
        }

        #endregion

        public static void Save()
        {
            try
            {
                config.Save(ConfigurationSaveMode.Modified, true);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Save configuration failure", ex);
            }
        }
    }
}
