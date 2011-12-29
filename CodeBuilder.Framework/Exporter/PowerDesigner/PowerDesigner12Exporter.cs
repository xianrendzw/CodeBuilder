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

        #region IExporter Members

        public override Model Export(ExportConfig config)
        {
            if (config == null)
                throw new ArgumentNullException("config", "参数不能为null");
            this._config = config;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(config.ConnectionString);
            XmlElement root = xmlDoc.DocumentElement;
            this._config.Database = this.GetDatabase(root);

            XmlNodeList tableNodes = root.GetElementsByTagName("c:Tables");
            XmlNodeList viewNodes = root.GetElementsByTagName("c:Views");

            Tables tables = null;
            Views views = null;

            if (tableNodes != null &&
                tableNodes[0] != null) tables = this.GetTables(tableNodes[0].ChildNodes);
            if (viewNodes != null &&
                viewNodes[0] != null) views = this.GetViews(viewNodes[0].ChildNodes);

            return (tables != null || views != null) ? new Model(tables, views) : null;
        }

        #endregion

        #region Private Members

        private Tables GetTables(XmlNodeList tableNodes)
        {
            if (tableNodes == null || 
                tableNodes.Count == 0) return null;

            Tables tables = new Tables(tableNodes.Count);
            foreach (XmlNode tableNode in tableNodes)
            {
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

        private Views GetViews(XmlNodeList viewNodes)
        {
            if (viewNodes == null || 
                viewNodes.Count == 0) return null;

            Views views = new Views(viewNodes.Count);
            foreach (XmlNode viewNode in viewNodes)
            {
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

        private Columns GetColumns(XmlNode tableOrViewNode)
        {
            XmlNode columnsNode = tableOrViewNode["c:Columns"];
            if (columnsNode == null ||
                columnsNode.ChildNodes.Count == 0) return null;

            XmlNodeList columnNodes = columnsNode.ChildNodes;
            Columns columns = new Columns(columnNodes.Count);
            foreach (XmlNode columnNode in columnNodes)
            {
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

                //string dataTypeName = Regex.Replace(column.DataType, "\\(.*?\\)", "");
                //LanguageType langType = TypeMapperFactory.Creator().GetLanguageType(
                //    this._config.Database,
                //    this._config.Value, dataTypeName);
                //column.LanguageType = langType.TypeName;
                //column.LanguageDefaultValue = langType.DefaultValue;
                columns.Add(id, column);
            }

            return columns;
        }

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
                string id = keyColumnNode.Attributes["Ref"].InnerText;
                if (!tableColumns.ContainsKey(id)) continue;
                keys.Add(id, tableColumns[id]);
            }

            return keys;
        }

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
