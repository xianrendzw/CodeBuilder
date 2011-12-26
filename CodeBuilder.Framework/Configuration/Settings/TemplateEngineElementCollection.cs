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
