using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.DataSource.Exporter
{
    using PhysicalDataModel;

    public abstract class BaseExporter : IExporter
    {
        public abstract Model Export(string connectionString);
    }
}
