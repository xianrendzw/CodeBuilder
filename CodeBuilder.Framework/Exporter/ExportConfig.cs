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

        /// <summary>
        /// 构造函数。
        /// </summary>
        public ExportConfig()
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="connectionString">数据源连接字符串(如:数据模型文件路径,数据库连接字符串等)。</param>
        public ExportConfig(string connectionString)
        {
            this._connectionString = connectionString;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="connectionString">数据源连接字符串(如:数据模型文件路径,数据库连接字符串等)。</param>
        /// <param name="database">数据库系统</param>
        /// <param name="language">程序设计语言</param>
        public ExportConfig(string connectionString,string database,string language)
        {
            this._database = database;
            this._langauge = language;
            this._connectionString = connectionString;
        }

        /// <summary>
        /// 获取或设置数据库系统类型。
        /// </summary>
        public string Database
        {
            get { return this._database; }
            set { this._database = value; }
        }

        /// <summary>
        /// 获取或设置生成代码的程序设计语言。
        /// </summary>
        public string Language
        {
            get { return this._langauge; }
            set { this._langauge = value; }
        }

        /// <summary>
        /// 获取或设置数据源连接字符串(如:数据模型文件路径,数据库连接字符串等)。
        /// </summary>
        public string ConnectionString
        {
            get { return this._connectionString; }
            set { this._connectionString = value; }
        }
    }
}
