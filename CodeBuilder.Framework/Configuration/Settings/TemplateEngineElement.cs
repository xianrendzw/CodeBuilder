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

        [ConfigurationProperty("ext", IsRequired = false, DefaultValue = "tpl")]
        public String Extension
        {
            get { return base["ext"].ToString(); }
            set { base["ext"] = value; }
        }

        [ConfigurationProperty("adapter", IsRequired = true)]
        public String Adapter
        {
            get { return base["adapter"].ToString(); }
            set { base["adapter"] = value; }
        }
    }
}
