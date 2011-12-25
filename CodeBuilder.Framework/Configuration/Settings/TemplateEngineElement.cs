using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public sealed class TemplateEngineElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public String Name
        {
            get { return base["name"].ToString(); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("adapter", IsRequired = true, DefaultValue = "String")]
        public String Adapter
        {
            get { return base["adapter"].ToString(); }
            set { base["adapter"] = value; }
        }
    }
}
