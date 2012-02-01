using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CodeBuilder.DataSource.Exporter
{
    using PhysicalDataModel;
    using Util;

    public class SqlServer2008Exporter : BaseExporter, IExporter
    {
        #region IExporter Members

        public override Model Export(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            Model model = new Model();
            model.Database = "SqlServer2008";

            try
            {
                model.Tables = this.GetTables(connectionString);
                model.Views = this.GetViews(connectionString);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private Members

        private Tables GetTables(string connectionString)
        {
            Tables tables = new Tables(10);

            string sqlCmd = "select [name],[object_id] from sys.tables where type='U'";
            SqlDataReader dr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sqlCmd);
            while (dr.Read())
            {
                string id = dr.GetString(0);
                string displayName = dr.GetString(0);
                string name = dr.GetString(0);
                string comment = string.Empty;
                int objectId = dr.GetInt32(1);

                Table table = new Table(id, displayName, name, comment);
                table.OriginalName = name;
                table.Columns = this.GetColumns(objectId, connectionString);
                table.PrimaryKeys = this.GetPrimaryKeys(objectId, connectionString);
                tables.Add(id, table);
            }
            dr.Close();

            return tables;
        }

        private Views GetViews(string connectionString)
        {
            Views views = new Views(10);

            string sqlCmd = "select [name],[object_id] from sys.views where type='V'";
            SqlDataReader dr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sqlCmd);
            while (dr.Read())
            {
                string id = dr.GetString(0);
                string displayName = dr.GetString(0);
                string name = dr.GetString(0);
                string comment = string.Empty;
                int objectId = dr.GetInt32(1);

                View view = new View(id, displayName, name, comment);
                view.OriginalName = name;
                view.Columns = this.GetColumns(objectId, connectionString);
                views.Add(id, view);
            }
            dr.Close();

            return views;
        }

        private Columns GetColumns(int objectId,string connectionString)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select c.object_id,c.column_id,c.name,c.max_length,c.is_identity,c.is_nullable,c.is_computed,");
            sqlBuilder.Append("t.name as type_name,p.value as description,d.definition as default_value ");
            sqlBuilder.Append("from sys.columns as c ");
            sqlBuilder.Append("inner join sys.types as t on c.user_type_id =  t.user_type_id ");
            sqlBuilder.Append("left join sys.extended_properties as p on p.major_id = c.object_id and p.minor_id = c.column_id ");
            sqlBuilder.Append("left join sys.default_constraints as d on d.parent_object_id = c.object_id and d.parent_column_id = c.column_id ");
            sqlBuilder.AppendFormat("where c.object_id={0}", objectId);

            return this.GetColumns(connectionString, sqlBuilder.ToString());
        }

        private Columns GetKeys(int objectId, string connectionString)
        {
            return null;
        }

        private Columns GetPrimaryKeys(int objectId, string connectionString)
        {
            return null;
        }

        private Columns GetColumns(string connectionString, string sqlCmd)
        {
            Columns columns = new Columns(50);
            SqlDataReader dr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sqlCmd);
            while (dr.Read())
            {
                string id = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                string displayName = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                string name = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                int length = dr.IsDBNull(3) ? 0 : dr.GetInt16(3);
                bool identity = dr.IsDBNull(4) ? false : dr.GetBoolean(4);
                bool isNullable = dr.IsDBNull(5) ? false : dr.GetBoolean(5);
                bool isComputed = dr.IsDBNull(6) ? false : dr.GetBoolean(6);
                string dataType = dr.IsDBNull(7) ? string.Empty : dr.GetString(7);
                string comment = dr.IsDBNull(8) ? string.Empty : dr.GetString(8);
                string defaultValue = dr.IsDBNull(9) ? string.Empty : dr.GetString(9);

                Column column = new Column(id, displayName, name, dataType, comment);
                column.Length = length;
                column.IsAutoIncremented = identity;
                column.IsNullable = isNullable;
                column.DefaultValue = defaultValue;
                column.DataType = dataType;
                column.OriginalName = name;
                column.IsComputed = isComputed;
                columns.Add(id, column);
            }
            dr.Close();

            return columns;
        }

        #endregion
    }
}
