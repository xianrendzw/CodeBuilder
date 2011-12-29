using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public sealed class AppSettingsElementCollection : ConfigurationElementCollection
    {
        public new AppSettingsElement this[string name]
        {
            get { return (AppSettingsElement)base.BaseGet(name); }
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

        public AppSettingsElement this[int index]
        {
            get { return (AppSettingsElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public void Add(AppSettingsElement element)
        {
            this[element.key] = element;
        }

        public void Remove(string key)
        {
            if (base.BaseGet(key) != null)
                base.BaseRemove(key);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new AppSettingsElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AppSettingsElement)element).key;
        }
    }
}
