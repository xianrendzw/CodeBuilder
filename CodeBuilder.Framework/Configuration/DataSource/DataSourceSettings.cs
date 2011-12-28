using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CodeBuilder.Configuration
{
    [Serializable, XmlType("DataSource")]
    public class DataSourceSettings
    {
        private string _name;
        private string _connectionString;
        private string _exporter;

        public DataSourceSettings() { }
        public DataSourceSettings(string name, string connectionString, string exporter)
        {
            this._name = name;
            this._connectionString = connectionString;
            this._exporter = exporter;
        }

        [XmlAttribute("name")]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        [XmlAttribute("connectionString")]
        public string ConnectionString
        {
            get { return this._connectionString; }
            set { this._connectionString = value; }
        }

        [XmlAttribute("exporter")]
        public string Exporter
        {
            get { return this._exporter; }
            set { this._exporter = value; }
        }
    }
}
