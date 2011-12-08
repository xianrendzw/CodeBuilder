using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public sealed class TypeMappingElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public String Name
        {
            get { return base["name"].ToString(); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("database", IsRequired = true, DefaultValue = "sqlserver2005")]
        public String Database
        {
            get { return base["database"].ToString(); }
            set { base["database"] = value; }
        }

        [ConfigurationProperty("language", IsRequired = true, DefaultValue = "csharp")]
        public String Language
        {
            get { return base["language"].ToString(); }
            set { base["language"] = value; }
        }

        [ConfigurationProperty("types", IsRequired = true)]
        public TypeElementCollection Types
        {
            get { return (TypeElementCollection)base["types"]; }
        }

        protected override void PostDeserialize()
        {
            base.PostDeserialize();
        }
    }
}
