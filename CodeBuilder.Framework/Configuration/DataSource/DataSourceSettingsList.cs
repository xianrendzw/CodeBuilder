using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CodeBuilder.Configuration
{
    [Serializable, XmlRoot("DataSources")]
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
