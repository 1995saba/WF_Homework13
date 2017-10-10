using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Explorer
{
    public partial class ExplorerForm : Form
    {
        public ExplorerForm()
        {
            InitializeComponent();

            ShowTreeNode();
        }

        private void ShowTreeNode()
        {
            DirectoryInfo info = new DirectoryInfo(@"C:\Program Files");
            TreeNode node = new TreeNode(info.Name);
            node.Tag = info;
            GetDirectories(info.GetDirectories(), node);
            treeView.Nodes.Add(node);
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode node;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                node = new TreeNode(subDir.Name, 0, 0);
                node.Tag = subDir;
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, node);
                }
                nodeToAddTo.Nodes.Add(node);
            }
        }
    }
}
