using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CodeBuilder.WinForm.UI
{
    public class GenerationHelper
    {
        public static bool IsValidPackageName(string packageName)
        {
            if (string.IsNullOrEmpty(packageName) ||
                packageName.Trim().Length == 0) return false;

            return Regex.IsMatch(packageName, "[a-zA-Z]+");
        }

        public static Dictionary<string, List<string>> GetGenerationObjects(TreeView treeView)
        {
            Dictionary<string, List<string>> generationObjects = new Dictionary<string, List<string>>();
            foreach (TreeNode parentNode in treeView.Nodes)
            {
                generationObjects.Add(parentNode.Index.ToString(), GetCheckedTags(parentNode.Nodes));
            }

            return generationObjects;
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
    }
}
