using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public sealed class OptionElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public String Name
        {
            get { return base["name"].ToString(); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public String Value
        {
            get { return base["value"].ToString(); }
            set { base["value"] = value; }
        }
    }
}
