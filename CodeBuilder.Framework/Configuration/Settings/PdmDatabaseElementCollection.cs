using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    [ConfigurationCollection(typeof(PdmDatabaseElement), AddItemName = "pdmDatabase")]
    public sealed class PdmDatabaseElementCollection : ConfigurationElementCollection
    {
        public new PdmDatabaseElement this[string name]
        {
            get { return (PdmDatabaseElement)base.BaseGet(name); }
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

        public PdmDatabaseElement this[int index]
        {
            get { return (PdmDatabaseElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public void Add(PdmDatabaseElement element)
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
            return new PdmDatabaseElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PdmDatabaseElement)element).Name;
        }
    }
}
