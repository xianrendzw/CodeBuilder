using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.DataSource.Exporter
{
    using PhysicalDataModel;

    public abstract class BaseExporter : IExporter
    {
        /// <summary>
        /// 从指定的源(如:PowerDesigner模型文档,数据库等)导出数据模型方法
        /// </summary>
        /// <param name="config">导出模型对象相关配置参数对象</param>
        /// <returns>数据模型</returns>
        public abstract Model Export(ExportConfig config);

        /// <summary>
        /// 从指定的源(如:PowerDesigner模型文档,数据库等)导出数据模型方法
        /// </summary>
        /// <param name="configs">导出模型对象相关配置参数对象集合</param>
        /// <returns>数据模型对象集合</returns>
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
