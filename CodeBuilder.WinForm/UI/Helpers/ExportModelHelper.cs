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

    public class ExportModelHelper
    {
        public static TreeNode Export(string connectionString, TreeView treeView)
        {
            ExportConfig exportConfig = new ExportConfig(connectionString,"mysql50","csharp");
            return Export(exportConfig, treeView);
        }

        public static TreeNode Export(ExportConfig exportConfig, TreeView treeView)
        {
            TreeNode rootNode = new TreeNode(exportConfig.ConnectionString, 1, 1);
            treeView.Nodes.Add(rootNode);
            Export(exportConfig, rootNode);
            return rootNode;
        }

        public static void Export(ExportConfig exportConfig, TreeNode rootNode)
        {
            IExporter exporter = new PowerDesigner12Exporter();
            Model model = exporter.Export(exportConfig);
            Export(model, rootNode);
        }

        public static void Export(Model model, TreeNode parentNode)
        {
            ExportTables(model.Tables, parentNode);
            ExportViews(model.Views, parentNode);
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

        private static void ExportTables(Tables tables, TreeNode parentNode)
        {
            if (tables == null ||
                tables.Count == 0) return;

            TreeNode childNode = new TreeNode("Tables", 1, 1);
            foreach (Table table in tables.Values)
            {
                TreeNode newNode = new TreeNode();
                newNode.Tag = table.Id;
                newNode.Text = table.Name;
                newNode.ToolTipText = table.Name;
                newNode.ImageIndex = 2;
                newNode.SelectedImageIndex = 2;
                childNode.Nodes.Add(newNode);
            }

            parentNode.Nodes.Add(childNode);
        }

        private static void ExportViews(Views views, TreeNode parentNode)
        {
            if (views == null ||
                views.Count == 0) return;

            TreeNode childNode = new TreeNode("Views", 1, 1);
            foreach (View view in views.Values)
            {
                TreeNode newNode = new TreeNode();
                newNode.Tag = view.Id;
                newNode.Text = view.Name;
                newNode.ToolTipText = view.Name;
                newNode.ImageIndex = 2;
                newNode.SelectedImageIndex = 2;
                childNode.Nodes.Add(newNode);
            }

            parentNode.Nodes.Add(childNode);
        }
    }
}
