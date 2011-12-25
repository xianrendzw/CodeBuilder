using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public sealed class AppSettingsElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public String key
        {
            get { return base["key"].ToString(); }
            set { base["key"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public String Value
        {
            get { return base["value"].ToString(); }
            set { base["value"] = value; }
        }
    }
}
