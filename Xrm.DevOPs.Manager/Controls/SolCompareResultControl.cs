using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xrm.DevOPs.Controls
{
    public partial class SolCompareResultControl : UserControl
    {
        public SolCompareResultControl()
        {
            InitializeComponent();
        }

        public string Header
        {
            get { return lblHeader.Text;  }
            set { lblHeader.Text = value;  }
        }

        public TreeView Tree
        {
            get { return tvResult;  }
        }

        internal void DisplaySolution(TreeView tree)
        {
            if (tree != null)
            {
                foreach (TreeNode r in tree.Nodes)
                {
                    var root = (TreeNode)r.Clone();
                    tvResult.Nodes.Add(root);
                    foreach (TreeNode n in r.Nodes)
                        AddNode(root, n);
                }
            }
            else
            {
                MessageBox.Show("Solution is not loaded yet");
            }

        }

        

        private void AddNode(TreeNode root, TreeNode node)
        {
            TreeNode n = (TreeNode)node.Clone();
            root.Nodes.Add(n);
            foreach (TreeNode cn in node.Nodes)
            {
                AddNode(n, cn);
            }

        }
    }
}
