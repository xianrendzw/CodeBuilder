using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.DataSource.Exporter
{
    using PhysicalDataModel;

    public interface IExporter
    {
        Model Export(ExportConfig config);

        List<Model> Export(params ExportConfig[] configs);
    }
}
