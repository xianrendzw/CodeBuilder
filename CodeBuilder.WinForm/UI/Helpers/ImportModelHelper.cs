using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder.WinForm.UI
{
    using PhysicalDataModel;
    using DataSource.Exporter;
    using DataSource.Exporter.PowerDesigner;

    public class ImportModelHelper
    {
        public static void Import(string connectionString, TreeView treeView)
        {
            ExportConfig exportConfig = new ExportConfig(connectionString);
            Import(exportConfig, treeView);
        }

        public static void Import(ExportConfig exportConfig, TreeView treeView)
        {
            TreeNode rootNode = new TreeNode(exportConfig.ConnectionString);
            treeView.Nodes.Add(rootNode);
            Import(exportConfig, rootNode);
            treeView.ExpandAll();
        }

        public static void Import(ExportConfig exportConfig, TreeNode rootNode)
        {
            IExporter exporter = new PowerDesigner12Exporter();
            Model model = exporter.Export(exportConfig);
            Import(model, rootNode);
        }

        public static void Import(Model model, TreeNode parentNode)
        {
            ImportTables(model.Tables, parentNode);
            ImportViews(model.Views, parentNode);
        }

        public static void CheckedTreeNode(TreeNode tn)
        {
            foreach (TreeNode childNode in tn.Nodes)
            {
                if (childNode.Checked != tn.Checked)
                    childNode.Checked = tn.Checked;
                CheckedTreeNode(childNode);
            }
        }

        public static List<String> GetCheckedTags(TreeNodeCollection nodes)
        {
            List<string> tags = new List<string>();
            foreach (TreeNode node in nodes)
            {
                if (node.Checked && node.Tag != null)
                {
                    tags.Add(node.Tag.ToString());
                }
                GetCheckedTags(node.Nodes, tags);
            }
            return tags;
        }

        private static void GetCheckedTags(TreeNodeCollection nodes, List<String> tags)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked && node.Tag != null)
                {
                    tags.Add(node.Tag.ToString());
                }
                GetCheckedTags(node.Nodes, tags);
            }
        }

        private static void ImportTables(Tables tables, TreeNode parentNode)
        {
            if (tables == null ||
                tables.Count == 0) return;

            TreeNode childNode = new TreeNode("Tables");
            foreach (Table table in tables.Values)
            {
                TreeNode newNode = new TreeNode();
                newNode.Tag = table.Id;
                newNode.Text = table.Name;
                newNode.ToolTipText = table.Name;
                childNode.Nodes.Add(newNode);
            }

            parentNode.Nodes.Add(childNode);
        }

        private static void ImportViews(Views views, TreeNode parentNode)
        {
            if (views == null ||
                views.Count == 0) return;

            TreeNode childNode = new TreeNode("Views");
            foreach (View view in views.Values)
            {
                TreeNode newNode = new TreeNode();
                newNode.Tag = view.Id;
                newNode.Text = view.Name;
                newNode.ToolTipText = view.Name;
                childNode.Nodes.Add(newNode);
            }

            parentNode.Nodes.Add(childNode);
        }

    }
}
