using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    [ConfigurationCollection(typeof(ExporterElement), AddItemName = "exporter")]
    public sealed class ExporterElementCollection : ConfigurationElementCollection
    {
        public new ExporterElement this[string name]
        {
            get { return (ExporterElement)base.BaseGet(name); }
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

        public ExporterElement this[int index]
        {
            get { return (ExporterElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public void Add(ExporterElement element)
        {
            base.BaseAdd(element);
        }

        public void Remove(string key)
        {
            base.BaseRemove(key);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ExporterElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ExporterElement)element).Name;
        }
    }
}
