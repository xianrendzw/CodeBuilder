using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public class SettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("databases", IsRequired = true)]
        public DatabaseElementCollection Databases
        {
            get { return (DatabaseElementCollection)base["databases"]; }
        }

        [ConfigurationProperty("pdmDatabases", IsRequired = true)]
        public PdmDatabaseElementCollection PdmDatabases
        {
            get { return (PdmDatabaseElementCollection)base["pdmDatabases"]; }
        }

        [ConfigurationProperty("exporters", IsRequired = true)]
        public ExporterElementCollection Exporters
        {
            get { return (ExporterElementCollection)base["exporters"]; }
        }

        [ConfigurationProperty("languages", IsRequired = true)]
        public LanguageElementCollection Languages
        {
            get { return (LanguageElementCollection)base["languages"]; }
        }

        [ConfigurationProperty("templateEngines", IsRequired = true)]
        public TemplateEngineElementCollection TemplateEngines
        {
            get { return (TemplateEngineElementCollection)base["templateEngines"]; }
        }

        [ConfigurationProperty("appSettings", IsRequired = true)]
        public AppSettingsElementCollection AppSettings
        {
            get { return (AppSettingsElementCollection)base["appSettings"]; }
        }

        protected override void PostDeserialize()
        {
            base.PostDeserialize();
        }
    }
}
