using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public sealed class TypeMappingElement : ConfigurationElement
    {
        private static ConfigurationProperty _property;
        private static ConfigurationPropertyCollection _properties;

        public TypeMappingElement()
        {
            EnsureStaticPropertyBag();
        }

        [ConfigurationProperty("name", IsRequired = true,IsKey=true)]
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

        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public TypeElementCollection Types
        {
            get { return (TypeElementCollection)base[_property]; }
        }

        protected override void PostDeserialize()
        {
            base.PostDeserialize();
        }

        private static ConfigurationPropertyCollection EnsureStaticPropertyBag()
        {
            if (_properties == null)
            {
                _property = new ConfigurationProperty(null, typeof(TypeElementCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
                _properties = new ConfigurationPropertyCollection();
                _properties.Add(_property);
            }
            return _properties;
        }
    }
}
