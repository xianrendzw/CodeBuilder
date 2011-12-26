using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CodeBuilder.Configuration
{
    [XmlRoot(ElementName = "DataSources")]
    public class DataSourceSettingsList : List<DataSourceSettings>
    {
        public DataSourceSettingsList()
        {
        }

        public DataSourceSettingsList(int capacity)
            : base(capacity)
        {
        }
    }
}
