using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CodeBuilder.Configuration
{
    [XmlRoot("Options")]
    public class OptionSettingsList : List<OptionSettings>
    {
        public OptionSettingsList()
        {
        }

        public OptionSettingsList(int capacity)
            : base(capacity)
        {
        }
    }
}
