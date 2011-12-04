using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBuilder.DataSource.Exporter
{
    using PhysicalDataModel;

    public interface IExporter
    {
        /// <summary>
        /// 从指定的源(如:PowerDesigner模型文档,数据库等)导出数据模型方法
        /// </summary>
        /// <param name="config">导出模型对象相关配置参数对象</param>
        /// <returns>数据模型</returns>
        Model Export(ExportConfig config);
    }
}
