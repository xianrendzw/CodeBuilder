using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Configuration
{
    public interface ISettings
    {
        event SettingsEventHandler Changed;

        object Get(string name);

        object Get(string name, object defaultValue);

        int Get(string name, int defaultValue);

        float Get(string name, float defaultValue);

        bool Get(string name, bool defaultValue);

        string Get(string name, string defaultValue);

        System.Enum Get(string name, System.Enum defaultValue);

        //System.Drawing.Font Get(string settingName, System.Drawing.Font defaultFont);

        void Remove(string name);

        void RemoveGroup(string groupName);

        void Save(string name, object settingValue);
    }

    public delegate void SettingsEventHandler(object sender, SettingsEventArgs args);

    public class SettingsEventArgs : EventArgs
    {
        private string _name;

        public SettingsEventArgs(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get { return this._name; }
        }
    }
}

