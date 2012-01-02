using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.DataSource.Exporter
{
    using PhysicalDataModel;

    public class SqlServer2000Exporter : BaseExporter, IExporter
    {
        #region IExporter Members

        public override Model Export(string connectionString)
        {
            Model model = new Model();
            model.Database = "SqlServer2000";

            return model;
        }

        #endregion
    }
}
