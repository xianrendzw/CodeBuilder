using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace CodeBuilder.DataSource.Exporter
{
    using Configuration;
    using Exceptions;
    using PhysicalDataModel;
    using Util;

    public class PowerDesigner12Exporter : BaseExporter,IExporter
    {
        #region IExporter Members

        public override Model Export(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(connectionString);
            XmlElement root = xmlDoc.DocumentElement;

            Model model = new Model();
            model.Database = this.GetDatabase(root);

            XmlNodeList tableNodes = root.GetElementsByTagName("c:Tables");
            XmlNodeList viewNodes = root.GetElementsByTagName("c:Views");

            if (tableNodes != null &&
                tableNodes[0] != null) model.Tables = this.GetTables(tableNodes[0].ChildNodes);
            if (viewNodes != null &&
                viewNodes[0] != null) model.Views = this.GetViews(viewNodes[0].ChildNodes);

            return model;
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
                string displayName = tableNode["a:Name"].InnerText;
                string name = tableNode["a:Code"].InnerText;
                string comment = tableNode["a:Comment"] != null ? tableNode["a:Comment"].InnerText : string.Empty;

                Table table = new Table(id, displayName, name, comment);
                table.OriginalName = name;
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
                string displayName = viewNode["a:Name"].InnerText;
                string name = viewNode["a:Code"].InnerText;
                string comment = viewNode["a:Comment"] != null ? viewNode["a:Comment"].InnerText : string.Empty;

                View view = new View(id, displayName, name, comment);
                view.OriginalName = name;
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
                string displayName = columnNode["a:Name"].InnerText;
                string name = columnNode["a:Code"].InnerText;
                string comment = columnNode["a:Comment"] != null ? columnNode["a:Comment"].InnerText : string.Empty;
                string dataType = columnNode["a:DataType"] != null ? columnNode["a:DataType"].InnerText : string.Empty;
                string length = columnNode["a:Length"] != null ? columnNode["a:Length"].InnerText : "0";
                string identity = columnNode["a:Identity"] != null ? columnNode["a:Identity"].InnerText : string.Empty;
                string mandatory = columnNode["a:Mandatory"] != null ? columnNode["a:Mandatory"].InnerText : string.Empty;
                string defaultValue = columnNode["a:DefaultValue"] != null ? columnNode["a:DefaultValue"].InnerText : string.Empty;

                Column column = new Column(id, displayName, name, dataType, comment);
                column.Length = Int32.Parse(length);
                column.IsAutoIncremented = identity.Equals("1");
                column.IsNullable = mandatory.Equals("1");
                column.DefaultValue = defaultValue.ToEmpty();
                column.DataType = Regex.Replace(column.DataType, "\\(.*?\\)", "");
                column.OriginalName = name;
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
                throw new NotFoundPdmDBMSException();

            string dbmsName = targetModelNodes[0]["a:Code"].InnerText.Trim().ToLower();
            if (ConfigManager.SettingsSection.PdmDatabases[dbmsName] == null)
                throw new NotSupportDatabaseException();

            return ConfigManager.SettingsSection.PdmDatabases[dbmsName].Database;
        }

        #endregion
    }
}
