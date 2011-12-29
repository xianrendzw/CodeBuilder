using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public class OptionSection : ConfigurationSection
    {
        [ConfigurationProperty("options", IsRequired = true)]
        public OptionElementCollection Options
        {
            get { return (OptionElementCollection)base["options"]; }
        }

        protected override void PostDeserialize()
        {
            base.PostDeserialize();
        }
    }
}
