using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public sealed class TypeElementCollection : ConfigurationElementCollection
    {
        public new TypeElement this[string name]
        {
            get { return (TypeElement)base.BaseGet(name); }
        }

        public TypeElement this[int index]
        {
            get { return (TypeElement)base.BaseGet(index); }
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
            return new TypeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TypeElement)element).Name;
        }
    }
}
