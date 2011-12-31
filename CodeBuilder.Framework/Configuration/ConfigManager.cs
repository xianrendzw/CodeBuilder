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
        private static readonly string settingsSectionName = "codebuilder/settingsSection";
        private static readonly string typeMappingSectionName = "codebuilder/typeMappingSection";
        private static readonly string dataSourceSectionName = "codebuilder/dataSourceSection";
        private static readonly string templateSectionName = "codebuilder/templateSection";
        private static readonly string optionSectionName = "codebuilder/optionSection";

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
                    if (Path.GetFileName(binDirectory).ToLower() == "Lib")
                        binDirectory = Path.GetDirectoryName(binDirectory);
                }
                return binDirectory;
            }
        }

        public static string TemplatePath
        {
            get
            {
                string templatePath = optionSection.Options["CodeGeneration.General.TemplatePath"].Value;
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
                string templatePath = optionSection.Options["CodeGeneration.General.OutputPath"].Value;
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

        public static string OnlineTemplateUrl
        {
            get
            {
                string onlineTemplateUrl = SettingsSection.AppSettings["onlineTemplateUrl"].Value;
                if (onlineTemplateUrl != null)
                {
                    return onlineTemplateUrl;
                }
                return onlineTemplateUrl = "http://www.dengzhiwei.com/category/codebuilder-templates";
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
            ConfigurationManager.RefreshSection(settingsSectionName);
            settingsSection = GetConfigSection<SettingsSection>(settingsSectionName);
        }

        public static void RefreshTypeMapping()
        {
            ConfigurationManager.RefreshSection(typeMappingSectionName);
            typeMappingSection = GetConfigSection<TypeMappingSection>(typeMappingSectionName);
        }

        public static void RefreshDataSources()
        {
            ConfigurationManager.RefreshSection(dataSourceSectionName);
            dataSourceSection = GetConfigSection<DataSourceSection>(dataSourceSectionName);
        }

        public static void RefreshTemplates()
        {
            ConfigurationManager.RefreshSection(templateSectionName);
            templateSection = GetConfigSection<TemplateSection>(templateSectionName);
        }

        public static void RefreshOptions()
        {
            ConfigurationManager.RefreshSection(optionSectionName);
            optionSection = GetConfigSection<OptionSection>(optionSectionName);
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
                throw new ConfigurationErrorsException("Save configuration failure", ex);
            }
        }

        #endregion

        #region Private Methods

        private static void LoadAll()
        {
            try
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                typeMappingSection = GetConfigSection<TypeMappingSection>(typeMappingSectionName);
                settingsSection = GetConfigSection<SettingsSection>(settingsSectionName);
                optionSection = GetConfigSection<OptionSection>(optionSectionName);
                dataSourceSection = GetConfigSection<DataSourceSection>(dataSourceSectionName);
                templateSection = GetConfigSection<TemplateSection>(templateSectionName);
                optionSection = GetConfigSection<OptionSection>(optionSectionName);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Load configuration failure", ex);
            }
        }

        private static T GetConfigSection<T>(string name) where T:ConfigurationSection
        {
            return (T)config.GetSection(name);
        }

        #endregion
    }
}
