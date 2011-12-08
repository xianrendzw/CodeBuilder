using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public class TypeMappingSection : ConfigurationSection
    {
        [ConfigurationProperty("mappings", IsRequired = true)]
        public TypeMappingElementCollection Mappings
        {
            get { return (TypeMappingElementCollection)base["mappings"]; }
        }

        protected override void PostDeserialize()
        {
            base.PostDeserialize();
        }
    }
}
