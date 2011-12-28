using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CodeBuilder.Configuration
{
    [XmlRoot("Templates")]
    public class TemplateSettingsList : List<TemplateSettings>
    {
        public TemplateSettingsList()
        {
        }

        public TemplateSettingsList(int capacity)
            : base(capacity)
        {
        }
    }
}
