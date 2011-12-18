using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeBuilder.WinForm.UiKit
{
    public partial class TreeSettingsDialog : BaseSettingsDialog
    {
        private SettingsPage current;

        public TreeSettingsDialog()
        {
            InitializeComponent();
        }

        #region TreeView Event Handlers

        private void optionTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            string key = e.Node.FullPath;
            SettingsPage page = SettingsPages[key];
            //Services.UserSettings.SaveSetting("Gui.Settings.InitialPage", key);

            if (page != null && page != current)
            {
                pagePanel.Controls.Clear();
                pagePanel.Controls.Add(page);
                page.Dock = DockStyle.Fill;
                current = page;
                return;
            }
        }

        private void optionTreeView_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            e.Node.ImageIndex = e.Node.SelectedImageIndex = 1;
        }

        private void optionTreeView_AfterCollapse(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            e.Node.ImageIndex = e.Node.SelectedImageIndex = 0;
        }

        #endregion

        public static void Display(Form owner, params SettingsPage[] pages)
        {
            using (TreeSettingsDialog dialog = new TreeSettingsDialog())
            {
                owner.Site.Container.Add(dialog);
                dialog.Font = owner.Font;
                dialog.SettingsPages.AddRange(pages);
                dialog.ShowDialog();
            }
        }

        private void TreeSettingsDialog_Load(object sender, System.EventArgs e)
        {
            foreach (SettingsPage page in SettingsPages)
                AddBranchToTree(optionTreeView.Nodes, page.Key);

            if (optionTreeView.VisibleCount >= optionTreeView.GetNodeCount(true))
                optionTreeView.ExpandAll();

            SelectInitialPage();
            optionTreeView.Select();
        }

        private void SelectInitialPage()
        {
            string initialPage = null;//Services.UserSettings.GetSetting("Gui.Settings.InitialPage") as string;

            if (initialPage != null)
                SelectPage(initialPage);
            else if (optionTreeView.Nodes.Count > 0)
                SelectFirstPage(optionTreeView.Nodes);
        }

        private void SelectPage(string initialPage)
        {
            TreeNode node = FindNode(optionTreeView.Nodes, initialPage);
            if (node != null)
                optionTreeView.SelectedNode = node;
            else
                SelectFirstPage(optionTreeView.Nodes);
        }

        private TreeNode FindNode(TreeNodeCollection nodes, string key)
        {
            int dot = key.IndexOf('.');
            string tail = null;

            if (dot >= 0)
            {
                tail = key.Substring(dot + 1);
                key = key.Substring(0, dot);
            }

            foreach (TreeNode node in nodes)
                if (node.Text == key)
                    return tail == null
                        ? node
                        : FindNode(node.Nodes, tail);

            return null;
        }

        private void SelectFirstPage(TreeNodeCollection nodes)
        {
            if (nodes[0].Nodes.Count == 0)
                optionTreeView.SelectedNode = nodes[0];
            else
            {
                nodes[0].Expand();
                SelectFirstPage(nodes[0].Nodes);
            }
        }

        private void AddBranchToTree(TreeNodeCollection nodes, string key)
        {
            int dot = key.IndexOf('.');
            if (dot < 0)
            {
                nodes.Add(new TreeNode(key, 2, 2));
                return;
            }

            string name = key.Substring(0, dot);
            key = key.Substring(dot + 1);

            TreeNode node = FindOrAddNode(nodes, name);

            if (key != null)
                AddBranchToTree(node.Nodes, key);
        }

        private TreeNode FindOrAddNode(TreeNodeCollection nodes, string name)
        {
            foreach (TreeNode node in nodes)
                if (node.Text == name)
                    return node;

            TreeNode newNode = new TreeNode(name, 0, 0);
            nodes.Add(newNode);
            return newNode;
        }
    }
}
