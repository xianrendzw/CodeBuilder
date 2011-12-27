using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Configuration
{
    public class OptionSettings:ISettings
    {
        public event SettingsEventHandler Changed;

        public object Get(string name)
        {
            throw new NotImplementedException();
        }

        public object Get(string name, object defaultValue)
        {
            throw new NotImplementedException();
        }

        public int Get(string name, int defaultValue)
        {
            throw new NotImplementedException();
        }

        public float Get(string name, float defaultValue)
        {
            throw new NotImplementedException();
        }

        public bool Get(string name, bool defaultValue)
        {
            throw new NotImplementedException();
        }

        public string Get(string name, string defaultValue)
        {
            throw new NotImplementedException();
        }

        public Enum Get(string name, Enum defaultValue)
        {
            throw new NotImplementedException();
        }

        public void Remove(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public void Save(string name, object value)
        {
            throw new NotImplementedException();
        }
    }
}
