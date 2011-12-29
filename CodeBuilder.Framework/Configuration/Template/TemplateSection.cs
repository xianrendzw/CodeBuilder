using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public class TemplateSection : ConfigurationSection
    {
        [ConfigurationProperty("templates", IsRequired = true)]
        public TemplateElementCollection Templates
        {
            get { return (TemplateElementCollection)base["templates"]; }
        }

        protected override void PostDeserialize()
        {
            base.PostDeserialize();
        }
    }
}
