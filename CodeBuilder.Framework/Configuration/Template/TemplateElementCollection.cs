using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    [ConfigurationCollection(typeof(TemplateElement), AddItemName = "template")]
    public sealed class TemplateElementCollection : ConfigurationElementCollection
    {
        public new TemplateElement this[string name]
        {
            get { return (TemplateElement)base.BaseGet(name); }
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

        public TemplateElement this[int index]
        {
            get { return (TemplateElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public void Add(TemplateElement element)
        {
            this[element.Name] = element;
        }

        public void Remove(string key)
        {
            if(base.BaseGet(key) != null)
                base.BaseRemove(key);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new TemplateElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TemplateElement)element).Name;
        }
    }
}
