using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.DataSource.Exporter
{
    using PhysicalDataModel;

    public class SqlServer2005Exporter : BaseExporter, IExporter
    {
        #region IExporter Members

        public override Model Export(string connectionString)
        {
            Model model = new Model();
            model.Database = "SqlServer2005";

            return model;
        }

        #endregion
    }
}
