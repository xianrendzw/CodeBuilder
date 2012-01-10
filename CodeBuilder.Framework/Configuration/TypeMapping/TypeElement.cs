using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public sealed class TypeElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public String Name
        {
            get { return base["name"].ToString(); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("langtype", IsRequired = true, DefaultValue = "String")]
        public String LanguageType
        {
            get { return base["langtype"].ToString(); }
            set { base["langtype"] = value; }
        }

        [ConfigurationProperty("default", IsRequired = false, DefaultValue = "")]
        public String DefaultValue
        {
            get { return base["default"].ToString(); }
            set { base["default"] = value; }
        }
    }
}
