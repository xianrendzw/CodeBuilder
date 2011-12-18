using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.Configuration
{
    public interface ISettings
    {
        event SettingsEventHandler Changed;

        object GetSetting(string settingName);

        object GetSetting(string settingName, object defaultValue);

        int GetSetting(string settingName, int defaultValue);

        float GetSetting(string settingName, float defaultValue);

        bool GetSetting(string settingName, bool defaultValue);

        string GetSetting(string settingName, string defaultValue);

        System.Enum GetSetting(string settingName, System.Enum defaultValue);

        //System.Drawing.Font GetSetting(string settingName, System.Drawing.Font defaultFont);

        void RemoveSetting(string settingName);

        void RemoveGroup(string groupName);

        void SaveSetting(string settingName, object settingValue);
    }

    public delegate void SettingsEventHandler(object sender, SettingsEventArgs args);

    public class SettingsEventArgs : EventArgs
    {
        private string settingName;

        public SettingsEventArgs(string settingName)
        {
            this.settingName = settingName;
        }

        public string SettingName
        {
            get { return settingName; }
        }
    }
}
