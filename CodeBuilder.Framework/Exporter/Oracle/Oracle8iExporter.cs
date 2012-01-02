using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.DataSource.Exporter
{
    using PhysicalDataModel;

    public class Oracle8iExporter : BaseExporter, IExporter
    {
        #region IExporter Members

        public override Model Export(string connectionString)
        {
            Model model = new Model();
            model.Database = "Oracle8i";

            return model;
        }

        #endregion
    }
}
