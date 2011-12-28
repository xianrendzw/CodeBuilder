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

        public override Model Export(ExportConfig config)
        {
            return null;
        }

        #endregion
    }
}
