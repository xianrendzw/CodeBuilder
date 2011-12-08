using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public class TypeMappingSection : ConfigurationSection
    {
        [ConfigurationProperty("typemappings", IsRequired = true)]
        public TypeMappingElementCollection TypeMappings
        {
            get { return (TypeMappingElementCollection)base["typemappings"]; }
        }

        protected override void PostDeserialize()
        {
            base.PostDeserialize();
        }
    }
}
