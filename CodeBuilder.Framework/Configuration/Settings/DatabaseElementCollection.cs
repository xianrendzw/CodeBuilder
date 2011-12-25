using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    [ConfigurationCollection(typeof(LanguageElement), AddItemName = "database")]
    public sealed class DatabaseElementCollection : ConfigurationElementCollection
    {
        public new DatabaseElement this[string name]
        {
            get { return (DatabaseElement)base.BaseGet(name); }
        }

        public DatabaseElement this[int index]
        {
            get { return (DatabaseElement)base.BaseGet(index); }
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
            return new DatabaseElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DatabaseElement)element).Name;
        }
    }
}
