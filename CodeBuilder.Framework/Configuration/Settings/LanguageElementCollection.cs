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
