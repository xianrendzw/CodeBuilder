using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.DataSource.Exporter.Oracle
{
    using PhysicalDataModel;

    public class Oracle8iExporter : BaseExporter, IExporter
    {
        #region IExporter Members

        public override Model Export(ExportConfig config)
        {
            return null;
        }

        #endregion
    }
}
