using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    [ConfigurationCollection(typeof(TypeMappingElement), AddItemName = "typeMapping")]
    public sealed class TypeMappingElementCollection : ConfigurationElementCollection
    {
        public new TypeMappingElement this[string name]
        {
            get { return (TypeMappingElement)base.BaseGet(name); }
            set
            {
                if (base.BaseGet(name) != null)
                {
                    int index = base.BaseIndexOf(base.BaseGet(name));
                    base.BaseRemoveAt(index);
                    base.BaseAdd(index, value);
                    return;
                }
                this.BaseAdd(value);
            }
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

        public void Add(TypeMappingElement element)
        {
            this[element.Name] = element;
        }

        public void Remove(string key)
        {
            if (base.BaseGet(key) != null)
                base.BaseRemove(key);
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
