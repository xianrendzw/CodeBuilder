using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    [ConfigurationCollection(typeof(TypeMappingElement), AddItemName = "typemapping")]
    public sealed class TypeMappingElementCollection : ConfigurationElementCollection
    {
        public new TypeMappingElement this[string name]
        {
            get { return (TypeMappingElement)base.BaseGet(name); }
        }

        public TypeMappingElement this[int index]
        {
            get { return (TypeMappingElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new TypeMappingElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TypeMappingElement)element).Name;
        }
    }
}
