using System;
using System.Text;
using MySql.Data.MySqlClient;

namespace CodeBuilder.DataSource.Exporter
{
    using PhysicalDataModel;
    using Util;

    public class MySql5Exporter : BaseExporter, IExporter
    {
        #region IExporter Members

        public override Model Export(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            MySqlConnectionStringBuilder connBuilder = new MySqlConnectionStringBuilder(connectionString);
            string originalDbName = connBuilder.Database;
            connBuilder.Database = "information_schema";

            Model model = new Model();
            model.Database = "MySQL5";

            try
            {
                model.Tables = this.GetTables(originalDbName,connBuilder.ConnectionString);
                model.Views = this.GetViews(originalDbName,connBuilder.ConnectionString);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private Members

        private Tables GetTables(string originalDbName,string connectionString)
        {
            Tables tables = new Tables(10);

            string sqlCmd = string.Format("SELECT TABLE_NAME, TABLE_COMMENT FROM TABLES WHERE TABLE_SCHEMA = '{0}'", originalDbName);
            MySqlDataReader dr = MySqlHelper.ExecuteReader(connectionString, sqlCmd);
            while (dr.Read())
            {
                string id = dr.GetString(0);
                string displayName = dr.GetString(0);
                string name = dr.GetString(0);
                string comment = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);

                Table table = new Table(id, displayName, name, comment);
                table.OriginalName = name;
                table.Columns = this.GetColumns(displayName, originalDbName, connectionString);
                table.PrimaryKeys = this.GetPrimaryKeys(displayName, originalDbName, connectionString);
                tables.Add(id, table);
            }
            dr.Close();

            return tables;
        }

        private Views GetViews(string originalDbName, string connectionString)
        {
            Views views = new Views(10);

            string sqlCmd = string.Format("SELECT TABLE_NAME FROM VIEWS WHERE TABLE_SCHEMA = '{0}'", originalDbName);
            MySqlDataReader dr = MySqlHelper.ExecuteReader(connectionString, sqlCmd);
            while (dr.Read())
            {
                string id = dr.GetString(0);
                string displayName = dr.GetString(0);
                string name = dr.GetString(0);
                string comment = string.Empty;

                View view = new View(id, displayName, name, comment);
                view.OriginalName = name;
                view.Columns = this.GetColumns(displayName, originalDbName, connectionString);
                views.Add(id, view);
            }
            dr.Close();

            return views;
        }

        private Columns GetColumns(string tableOrViewName, string originalDbName, string connectionString)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,DATA_TYPE,COLUMN_KEY,COLUMN_DEFAULT, ");
            sqlBuilder.Append("IS_NULLABLE,CHARACTER_MAXIMUM_LENGTH,EXTRA,COLUMN_COMMENT ");
            sqlBuilder.Append("FROM COLUMNS ");
            sqlBuilder.AppendFormat("WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME ='{1}' ", originalDbName, tableOrViewName);

            return this.GetColumns(connectionString, sqlBuilder.ToString());
        }

        private Columns GetKeys(string tableName, string originalDbName, string connectionString)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,DATA_TYPE,COLUMN_KEY,COLUMN_DEFAULT, ");
            sqlBuilder.Append("IS_NULLABLE,CHARACTER_MAXIMUM_LENGTH,EXTRA,COLUMN_COMMENT ");
            sqlBuilder.Append("FROM COLUMNS ");
            sqlBuilder.AppendFormat("WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME ='{1}' AND CHARACTER_LENGTH(COLUMN_KEY)>0 ", originalDbName, tableName);

            return GetColumns(connectionString, sqlBuilder.ToString());
        }

        private Columns GetPrimaryKeys(string tableName, string originalDbName, string connectionString)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,DATA_TYPE,COLUMN_KEY,COLUMN_DEFAULT, ");
            sqlBuilder.Append("IS_NULLABLE,CHARACTER_MAXIMUM_LENGTH,EXTRA,COLUMN_COMMENT ");
            sqlBuilder.Append("FROM COLUMNS ");
            sqlBuilder.AppendFormat("WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME ='{1}' AND COLUMN_KEY='PRI'", originalDbName, tableName);

            return this.GetColumns(connectionString, sqlBuilder.ToString());
        }

        private Columns GetColumns(string connectionString, string sqlCmd)
        {
            Columns columns = new Columns(50);
            MySqlDataReader dr = MySqlHelper.ExecuteReader(connectionString, sqlCmd);
            while (dr.Read())
            {
                string id = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                string displayName = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                string name = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                string dataType = dr.IsDBNull(3) ? string.Empty : dr.GetString(3);
                string key = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
                string defaultValue = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                string isNullable = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);
                string length = dr.IsDBNull(7) ? string.Empty : dr.GetString(7);
                string identity = dr.IsDBNull(8) ? string.Empty : dr.GetString(8);
                string comment = dr.IsDBNull(9) ? string.Empty : dr.GetString(9);

                Column column = new Column(id, displayName, name, dataType, comment);
                column.Length = ConvertHelper.GetInt32(length);
                column.IsAutoIncremented = identity.Equals("auto_increment");
                column.IsNullable = isNullable.Equals("YES");
                column.DefaultValue = defaultValue.ToEmpty();
                column.DataType = dataType;
                column.OriginalName = name;
                columns.Add(id, column);
            }
            dr.Close();

            return columns;
        }

        #endregion
    }
}
