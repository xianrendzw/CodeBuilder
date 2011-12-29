using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public sealed class DataSourceElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public String Name
        {
            get { return base["name"].ToString(); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("connectionString", IsRequired = true)]
        public String ConnectionString
        {
            get { return base["connectionString"].ToString(); }
            set { base["connectionString"] = value; }
        }

        [ConfigurationProperty("exporter", IsRequired = true)]
        public String Exporter
        {
            get { return base["exporter"].ToString(); }
            set { base["exporter"] = value; }
        }
    }
}
