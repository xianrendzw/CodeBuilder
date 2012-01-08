using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public sealed class DatabaseElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public String Name
        {
            get { return base["name"].ToString(); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("typeMapping", IsRequired = true)]
        public String TypeMapping
        {
            get { return base["typeMapping"].ToString(); }
            set { base["typeMapping"] = value; }
        }
    }
}
