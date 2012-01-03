using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public sealed class LanguageElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public String Name
        {
            get { return base["name"].ToString(); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("alias", IsRequired = true)]
        public String Alias
        {
            get { return base["alias"].ToString(); }
            set { base["alias"] = value; }
        }

        [ConfigurationProperty("ext", IsRequired = true)]
        public String Extension
        {
            get { return base["ext"].ToString(); }
            set { base["ext"] = value; }
        }

        [ConfigurationProperty("isDynamic", IsRequired = true, DefaultValue = false)]
        public Boolean IsDynamic
        {
            get { return (Boolean)base["isDynamic"]; }
            set { base["isDynamic"] = value; }
        }
    }
}
