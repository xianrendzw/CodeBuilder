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
