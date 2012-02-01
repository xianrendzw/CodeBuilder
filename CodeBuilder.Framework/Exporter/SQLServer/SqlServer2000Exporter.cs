using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CodeBuilder.DataSource.Exporter
{
    using PhysicalDataModel;

    public class SqlServer2000Exporter : BaseExporter, IExporter
    {
        #region IExporter Members

        public override Model Export(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            Model model = new Model();
            model.Database = "SqlServer2000";

            return model;
        }

        #endregion

        #region Private Members

        private Tables GetTables()
        {
            return null;
        }

        private Views GetViews()
        {
            return null;
        }

        private Columns GetColumns()
        {
            return null;
        }

        private Columns GetKeys()
        {
            return null;
        }

        private Columns GetPrimaryKeys()
        {
            return null;
        }

        #endregion
    }
}
