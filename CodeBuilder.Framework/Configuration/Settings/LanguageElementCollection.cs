using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    [ConfigurationCollection(typeof(LanguageElement), AddItemName = "language")]
    public sealed class LanguageElementCollection : ConfigurationElementCollection
    {
        public new LanguageElement this[string name]
        {
            get { return (LanguageElement)base.BaseGet(name); }
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

        public LanguageElement this[int index]
        {
            get { return (LanguageElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public void Add(LanguageElement element)
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
            return new LanguageElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LanguageElement)element).Name;
        }
    }
}
