using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.DataSource.Exporter
{
    using PhysicalDataModel;

    public abstract class BaseExporter : IExporter
    {
        public abstract Model Export(ExportConfig config);

        public List<Model> Export(params ExportConfig[] configs)
        {
            if (configs == null ||
                configs.Length == 0)
            {
                return null;
            }

            List<Model> models = new List<Model>(configs.Length);
            foreach (ExportConfig config in configs)
            {
                models.Add(this.Export(config));
            }

            return models;
        }
    }
}
