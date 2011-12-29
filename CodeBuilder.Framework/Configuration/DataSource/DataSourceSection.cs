using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeBuilder.Configuration
{
    public class DataSourceSection : ConfigurationSection
    {
        [ConfigurationProperty("dataSources", IsRequired = true)]
        public DataSourceElementCollection DataSources
        {
            get { return (DataSourceElementCollection)base["dataSources"]; }
        }

        protected override void PostDeserialize()
        {
            base.PostDeserialize();
        }
    }
}
