using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    [ConfigurationCollection(typeof(DataSourceElement), AddItemName = "dataSource")]
    public sealed class DataSourceElementCollection : ConfigurationElementCollection
    {
        public new DataSourceElement this[string name]
        {
            get { return (DataSourceElement)base.BaseGet(name); }
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

        public DataSourceElement this[int index]
        {
            get { return (DataSourceElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public void Add(DataSourceElement element)
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
            return new DataSourceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DataSourceElement)element).Name;
        }
    }
}
