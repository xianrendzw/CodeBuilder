using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    [ConfigurationCollection(typeof(TemplateEngineElement), AddItemName = "templateEngine")]
    public sealed class TemplateEngineElementCollection : ConfigurationElementCollection
    {
        public new TemplateEngineElement this[string name]
        {
            get { return (TemplateEngineElement)base.BaseGet(name); }
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

        public TemplateEngineElement this[int index]
        {
            get { return (TemplateEngineElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public void Add(TemplateEngineElement element)
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
            return new TemplateEngineElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TemplateEngineElement)element).Name;
        }
    }
}
