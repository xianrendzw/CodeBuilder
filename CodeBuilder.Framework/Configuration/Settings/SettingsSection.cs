using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    using Exceptions;

    public class SettingsSection : ConfigurationSection
    {
        public void Save()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            SettingsSection section = (SettingsSection)config.GetSection("codebuilder.settings");
            if (section == null) return;
            if (!section.ElementInformation.IsLocked) config.Save();
            else throw new ConfigSectionLockedException();
        }

        protected override void PostDeserialize()
        {
            base.PostDeserialize();
        }
    }
}
