using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CodeBuilder.DataSource.Exporter
{
    using Configuration;
    using Exceptions;
    using PhysicalDataModel;
    using Util;

    public class MySql5Exporter : BaseExporter, IExporter
    {
        #region IExporter Members

        public override Model Export(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString", "Argument is null");

            MySqlConnectionStringBuilder connBuilder = new MySqlConnectionStringBuilder(connectionString);
            string originalDatabase = connBuilder.Database;
            connBuilder.Database = "information_schema";

            Model model = new Model();
            model.Database = "MySQL5";

            try
            {
                model.Tables = this.GetTables(originalDatabase,connBuilder.ConnectionString);
                model.Views = this.GetViews(originalDatabase,connBuilder.ConnectionString);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private Members

        private Tables GetTables(string originalDatabase,string connectionString)
        {
            Tables tables = new Tables(10);

            string sqlCmd = string.Format("SELECT TABLE_NAME, TABLE_COMMENT FROM TABLES WHERE TABLE_SCHEMA = '{0}'", originalDatabase);
            MySqlDataReader dr = MySqlHelper.ExecuteReader(connectionString, sqlCmd);
            while (dr.Read())
            {
                string id = dr.GetString(0);
                string name = dr.GetString(0);
                string code = dr.GetString(0);
                string comment = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);

                Table table = new Table(id, name, code, comment);
                table.OriginalName = code;
                table.Columns = this.GetColumns(name, originalDatabase, connectionString);
                table.PrimaryKeys = this.GetPrimaryKeys(name, originalDatabase, connectionString);
                tables.Add(id, table);
            }
            dr.Close();

            return tables;
        }

        private Views GetViews(string originalDatabase, string connectionString)
        {
            Views views = new Views(10);

            string sqlCmd = string.Format("SELECT TABLE_NAME FROM VIEWS WHERE TABLE_SCHEMA = '{0}'", originalDatabase);
            MySqlDataReader dr = MySqlHelper.ExecuteReader(connectionString, sqlCmd);
            while (dr.Read())
            {
                string id = dr.GetString(0);
                string name = dr.GetString(0);
                string code = dr.GetString(0);
                string comment = string.Empty;

                View view = new View(id, name, code, comment);
                view.OriginalName = code;
                view.Columns = this.GetColumns(name, originalDatabase, connectionString);
                views.Add(id, view);
            }
            dr.Close();

            return views;
        }

        private Columns GetColumns(string tableOrViewName, string originalDatabase, string connectionString)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,DATA_TYPE,COLUMN_KEY,COLUMN_DEFAULT, ");
            sqlBuilder.Append("IS_NULLABLE,CHARACTER_MAXIMUM_LENGTH,EXTRA,COLUMN_COMMENT ");
            sqlBuilder.Append("FROM COLUMNS ");
            sqlBuilder.AppendFormat("WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME ='{1}' ", originalDatabase, tableOrViewName);

            return this.GetColumns(connectionString, sqlBuilder.ToString());
        }

        private Columns GetKeys(string tableName, string originalDatabase, string connectionString)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,DATA_TYPE,COLUMN_KEY,COLUMN_DEFAULT, ");
            sqlBuilder.Append("IS_NULLABLE,CHARACTER_MAXIMUM_LENGTH,EXTRA,COLUMN_COMMENT ");
            sqlBuilder.Append("FROM COLUMNS ");
            sqlBuilder.AppendFormat("WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME ='{1}' AND CHARACTER_LENGTH(COLUMN_KEY)>0 ", originalDatabase, tableName);

            return GetColumns(connectionString, sqlBuilder.ToString());
        }

        private Columns GetPrimaryKeys(string tableName, string originalDatabase, string connectionString)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,DATA_TYPE,COLUMN_KEY,COLUMN_DEFAULT, ");
            sqlBuilder.Append("IS_NULLABLE,CHARACTER_MAXIMUM_LENGTH,EXTRA,COLUMN_COMMENT ");
            sqlBuilder.Append("FROM COLUMNS ");
            sqlBuilder.AppendFormat("WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME ='{1}' AND COLUMN_KEY='PRI'", originalDatabase, tableName);

            return this.GetColumns(connectionString, sqlBuilder.ToString());
        }

        private Columns GetColumns(string connectionString, string sqlCmd)
        {
            Columns columns = new Columns(50);
            MySqlDataReader dr = MySqlHelper.ExecuteReader(connectionString, sqlCmd.ToString());
            while (dr.Read())
            {
                string id = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                string name = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                string code = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                string dataType = dr.IsDBNull(3) ? string.Empty : dr.GetString(3);
                string key = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
                string defaultValue = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                string isNullable = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);
                string length = dr.IsDBNull(7) ? string.Empty : dr.GetString(7);
                string identity = dr.IsDBNull(8) ? string.Empty : dr.GetString(8);
                string comment = dr.IsDBNull(9) ? string.Empty : dr.GetString(9);

                Column column = new Column(id, name, code, dataType, comment);
                column.Length = ConvertHelper.GetInt32(length);
                column.IsAutoIncremented = identity.Equals("auto_increment");
                column.IsNullable = isNullable.Equals("YES");
                column.DefaultValue = defaultValue.ToEmpty();
                column.DataType = dataType;
                column.OriginalName = code;
                columns.Add(id, column);
            }
            dr.Close();

            return columns;
        }

        #endregion
    }
}
