using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    [ConfigurationCollection(typeof(DatabaseElement), AddItemName = "database")]
    public sealed class DatabaseElementCollection : ConfigurationElementCollection
    {
        public new DatabaseElement this[string name]
        {
            get { return (DatabaseElement)base.BaseGet(name); }
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

        public void Add(DatabaseElement element)
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
            return new DatabaseElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DatabaseElement)element).Name;
        }
    }
}
