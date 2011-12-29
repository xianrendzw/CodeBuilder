using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    [ConfigurationCollection(typeof(OptionElement), AddItemName = "option")]
    public sealed class OptionElementCollection : ConfigurationElementCollection
    {
        public new OptionElement this[string name]
        {
            get { return (OptionElement)base.BaseGet(name); }
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

        public OptionElement this[int index]
        {
            get { return (OptionElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public void Add(OptionElement element)
        {
            base.BaseAdd(element);
        }

        public void Remove(string key)
        {
            base.BaseRemove(key);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new OptionElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((OptionElement)element).Name;
        }
    }
}
