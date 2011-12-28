using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.DataSource.Exporter
{
    public class ExportConfig
    {
        protected string _connectionString;
        protected string _database;
        protected string _langauge;

        public ExportConfig()
        {
        }

        public ExportConfig(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public ExportConfig(string connectionString,string database,string language)
        {
            this._database = database;
            this._langauge = language;
            this._connectionString = connectionString;
        }

        public string Database
        {
            get { return this._database; }
            set { this._database = value; }
        }

        public string Language
        {
            get { return this._langauge; }
            set { this._langauge = value; }
        }

        public string ConnectionString
        {
            get { return this._connectionString; }
            set { this._connectionString = value; }
        }
    }
}
