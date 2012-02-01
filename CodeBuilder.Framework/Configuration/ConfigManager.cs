using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace CodeBuilder.Configuration
{
    using Exceptions;
    using Framework.Properties;
    using Util;

    public class ConfigManager
    {
        private static System.Configuration.Configuration config;
        private static readonly string settingsSectionName = "codebuilder/settingsSection";
        private static readonly string typeMappingSectionName = "codebuilder/typeMappingSection";
        private static readonly string dataSourceSectionName = "codebuilder/dataSourceSection";
        private static readonly string templateSectionName = "codebuilder/templateSection";
        private static readonly string optionSectionName = "codebuilder/optionSection";

        #region Class Constructor

        static ConfigManager()
        {
            LoadConfiguration();
        }

        #endregion

        #region Public Properties

        public static SettingsSection SettingsSection
        {
            get { return GetConfigSection<SettingsSection>(settingsSectionName); }
        }

        public static TypeMappingSection TypeMappingSection
        {
            get { return GetConfigSection<TypeMappingSection>(typeMappingSectionName); }
        }

        public static DataSourceSection DataSourceSection
        {
            get { return GetConfigSection<DataSourceSection>(dataSourceSectionName); }
        }

        public static TemplateSection TemplateSection
        {
            get { return GetConfigSection<TemplateSection>(templateSectionName); ; }
        }

        public static OptionSection OptionSection
        {
            get { return GetConfigSection<OptionSection>(optionSectionName); ; }
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

        public static string TemplatePath
        {
            get
            {
                string templatePath = OptionSection.Options["CodeGeneration.General.TemplatePath"].Value;
                if (string.IsNullOrEmpty(templatePath) ||
                    templatePath.Trim().Length == 0)
                {
                    templatePath = Path.Combine(AppCurrentDirectory, "Templates");
                }

                if (!Directory.Exists(templatePath)) Directory.CreateDirectory(templatePath);
                return templatePath;
            }
        }

        public static string GenerationCodeOuputPath
        {
            get
            {
                string templatePath = OptionSection.Options["CodeGeneration.General.OutputPath"].Value;
                if (string.IsNullOrEmpty(templatePath) ||
                    templatePath.Trim().Length == 0)
                {
                    templatePath = Path.Combine(AppCurrentDirectory, "Codes");
                }

                if (!Directory.Exists(templatePath)) Directory.CreateDirectory(templatePath);
                return templatePath;
            }
        }

        public static string LogDirectory
        {
            get { return Path.Combine(Environment.CurrentDirectory, "Logs"); }
        }

        public static string HelpUrl
        {
            get
            {
                string helpUrl = SettingsSection.AppSettings["helpUrl"].Value;
                if (helpUrl != null) return helpUrl;

                helpUrl = "http://www.dengzhiwei.com/category/codebuilder";
                string localPath = Path.Combine(AppCurrentDirectory, @"doc/index.html");
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
                if (feedbackUrl != null) return feedbackUrl;

                return feedbackUrl = "http://www.dengzhiwei.com/category/codebuilder-feedback";
            }
        }

        public static string OnlineTemplateUrl
        {
            get
            {
                string onlineTemplateUrl = SettingsSection.AppSettings["onlineTemplateUrl"].Value;
                if (onlineTemplateUrl != null) return onlineTemplateUrl;

                return onlineTemplateUrl = "http://www.dengzhiwei.com/category/codebuilder-templates";
            }
        }
        #endregion

        #region Public Methods

        public static void RefreshSettings()
        {
            ConfigurationManager.RefreshSection(settingsSectionName);
        }

        public static void RefreshTypeMapping()
        {
            ConfigurationManager.RefreshSection(typeMappingSectionName);
        }

        public static void RefreshDataSources()
        {
            ConfigurationManager.RefreshSection(dataSourceSectionName);
        }

        public static void RefreshTemplates()
        {
            ConfigurationManager.RefreshSection(templateSectionName);
        }

        public static void RefreshOptions()
        {
            ConfigurationManager.RefreshSection(optionSectionName);
        }

        public static void Save()
        {
            try
            {
                config.Save(ConfigurationSaveMode.Modified);
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException(Resource.SaveConfigurationFailure, ex);
            }
        }

        #endregion

        #region Private Methods

        private static void LoadConfiguration()
        {
            try
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException(Resource.LoadConfigurationFailure, ex);
            }
        }

        private static T GetConfigSection<T>(string name) where T:ConfigurationSection
        {
            try
            {
                return (T)config.GetSection(name);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException(string.Format(Resource.ConfigurationSectionLoadFailure, name), ex);
            }
        }

        #endregion
    }
}
