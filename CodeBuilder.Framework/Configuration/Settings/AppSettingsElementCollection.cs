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
