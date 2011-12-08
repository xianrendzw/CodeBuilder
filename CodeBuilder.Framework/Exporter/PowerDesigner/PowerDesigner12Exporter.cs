using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace CodeBuilder.DataSource.Exporter.PowerDesigner
{
    using PhysicalDataModel;
    using TypeMapping;
    using Exceptions;

    public class PowerDesigner12Exporter : BaseExporter,IExporter
    {
        private ExportConfig _config;

        #region IExporter 成员

        public override Model Export(ExportConfig config)
        {
            if (config == null)
                throw new ArgumentNullException("config", "参数不能为null");
            this._config = config;

            //加载PowerDesigner数据模型文件
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(config.ConnectionString);
            XmlElement root = xmlDoc.DocumentElement;
            this._config.Database = this.GetDatabase(root);

            //获取模型文件中table与view结点集合。
            XmlNodeList tableNodes = root.GetElementsByTagName("c:Tables");
            XmlNodeList viewNodes = root.GetElementsByTagName("c:Views");

            Tables tables = null;
            Views views = null;

            //导出模型中的表对象集合
            if (tableNodes != null &&
                tableNodes[0] != null) tables = this.GetTables(tableNodes[0].ChildNodes);

            //导出模型中的视图对象集合
            if (viewNodes != null &&
                viewNodes[0] != null) views = this.GetViews(viewNodes[0].ChildNodes);

            return (tables != null || views != null) ? new Model(tables, views) : null;
        }

        #endregion

        #region 私有成员

        /// <summary>
        /// 导出模型文件中的表对象集合。
        /// </summary>
        /// <param name="tableNodes">模型文件中table结点集合</param>
        /// <returns>表对象集合</returns>
        private Tables GetTables(XmlNodeList tableNodes)
        {
            if (tableNodes == null || 
                tableNodes.Count == 0) return null;

            Tables tables = new Tables(tableNodes.Count);
            foreach (XmlNode tableNode in tableNodes)
            {
                //获取表对象的相关属性
                string id = tableNode.Attributes["Id"].InnerText;
                string name = tableNode["a:Name"].InnerText;
                string code = tableNode["a:Code"].InnerText;
                string comment = tableNode["a:Comment"] != null ? tableNode["a:Comment"].InnerText : string.Empty;

                Table table = new Table(id, name, code, comment);
                table.Columns = this.GetColumns(tableNode);
                table.PrimaryKeys = this.GetPrimaryKeys(tableNode, table.Columns);
                tables.Add(id, table);
            }

            return tables;
        }

        /// <summary>
        /// 导出模型文件中的视图对象集合。
        /// </summary>
        /// <param name="viewNodes">模型文件中view结点集合</param>
        /// <returns>视图对象集合</returns>
        private Views GetViews(XmlNodeList viewNodes)
        {
            if (viewNodes == null || 
                viewNodes.Count == 0) return null;

            Views views = new Views(viewNodes.Count);
            foreach (XmlNode viewNode in viewNodes)
            {
                //获取视图对象的相关属性
                string id = viewNode.Attributes["Id"].InnerText;
                string name = viewNode["a:Name"].InnerText;
                string code = viewNode["a:Code"].InnerText;
                string comment = viewNode["a:Comment"] != null ? viewNode["a:Comment"].InnerText : string.Empty;

                View view = new View(id, name, code, comment);
                view.Columns = this.GetColumns(viewNode);
                views.Add(id, view);
            }

            return views;
        }

        /// <summary>
        /// 导出模型文件中的表或视图对象的列集合。
        /// </summary>
        /// <param name="columnsNode">模型文件中table或view结点的columns结点</param>
        /// <returns>表或视图对象的列集合</returns>
        private Columns GetColumns(XmlNode tableOrViewNode)
        {
            XmlNode columnsNode = tableOrViewNode["c:Columns"];
            if (columnsNode == null ||
                columnsNode.ChildNodes.Count == 0) return null;

            XmlNodeList columnNodes = columnsNode.ChildNodes;
            Columns columns = new Columns(columnNodes.Count);
            foreach (XmlNode columnNode in columnNodes)
            {
                //获取表或视图的列对象相关属性
                string id = columnNode.Attributes["Id"].InnerText;
                string name = columnNode["a:Name"].InnerText;
                string code = columnNode["a:Code"].InnerText;
                string comment = columnNode["a:Comment"] != null ? columnNode["a:Comment"].InnerText : string.Empty;
                string dataType = columnNode["a:DataType"] != null ? columnNode["a:DataType"].InnerText : string.Empty;
                string length = columnNode["a:Length"] != null ? columnNode["a:Length"].InnerText : "0";
                string identity = columnNode["a:Identity"] != null ? columnNode["a:Identity"].InnerText : string.Empty;
                string mandatory = columnNode["a:Mandatory"] != null ? columnNode["a:Mandatory"].InnerText : string.Empty;
                string defaultValue = columnNode["a:DefaultValue"] != null ? columnNode["a:DefaultValue"].InnerText : string.Empty;

                Column column = new Column(id, name, code, dataType, comment);
                column.Length = Int32.Parse(length);
                column.IsAutoIncremented = identity.Equals("1");
                column.IsNullable = mandatory.Equals("1");
                column.DefaultValue = defaultValue;

                //把列的数据类型转换成对应程序设计语言的数据类型
                string dataTypeName = Regex.Replace(column.DataType, "\\(.*?\\)", "");
                LanguageType langType = TypeMapperFactory.Creator().GetLanguageType(
                    this._config.Database,
                    this._config.Language, dataTypeName);
                column.LanguageType = langType.TypeName;
                column.LanguageDefaultValue = langType.DefaultValue;
                columns.Add(id, column);
            }

            return columns;
        }

        /// <summary>
        /// 导出模型文件中的表象的键集合。
        /// </summary>
        /// <param name="tableNode">模型文件中table结点</param>
        /// <param name="tableColumns">当前表中所有的列对象集合</param>
        /// <returns>表对象的键集合</returns>
        private Columns GetKeys(XmlNode tableNode, Columns tableColumns)
        {
            XmlNode keysNode = tableNode["c:Keys"];
            if (keysNode == null ||
                keysNode.ChildNodes.Count == 0) return null;

            XmlNode keyColumnsNode = keysNode.ChildNodes[0]["c:Key.Columns"];
            if (keyColumnsNode == null || 
                keyColumnsNode.ChildNodes.Count == 0) return null;

            XmlNodeList keyColumnNodes = keyColumnsNode.ChildNodes;
            Columns keys = new Columns(keyColumnNodes.Count);
            foreach (XmlNode keyColumnNode in keyColumnNodes)
            {
                //获取表对象的键标识
                string id = keyColumnNode.Attributes["Ref"].InnerText;
                if (!tableColumns.ContainsKey(id)) continue;
                keys.Add(id, tableColumns[id]);
            }

            return keys;
        }

        /// <summary>
        /// 导出模型文件中的表对象的主键集合。
        /// </summary>
        /// <param name="keysNode">模型文件中table结点</param>
        /// <param name="tableColumns">当前表中所有的列对象集合</param>
        /// <returns>表对象的主键集合</returns>
        private Columns GetPrimaryKeys(XmlNode tableNode, Columns tableColumns)
        {
            XmlNode xmlNode = tableNode["c:PrimaryKey"];
            if (xmlNode == null ||
                xmlNode.ChildNodes.Count == 0) return null;

            XmlNodeList primaryKeyNodes = xmlNode.ChildNodes;
            Columns primaryKeys = new Columns(primaryKeyNodes.Count);
            foreach (XmlNode primaryKeyNode in primaryKeyNodes)
            {
                string id = primaryKeyNode.Attributes["Ref"].InnerText;
                if (!tableColumns.ContainsKey(id)) continue;
                primaryKeys.Add(id,tableColumns[id]);
            }

            return primaryKeys;
        }

        private string GetDatabase(XmlElement root)
        {
            XmlNodeList targetModelNodes = root.GetElementsByTagName("o:TargetModel");
            if (targetModelNodes == null ||
                targetModelNodes.Count == 0)
            {
                throw new NotSetDatabaseException();
            }

            return targetModelNodes[0]["a:Code"].InnerText.Trim();
        }

        #endregion
    }
}
