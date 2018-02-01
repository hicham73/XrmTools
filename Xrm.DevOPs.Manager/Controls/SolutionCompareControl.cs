using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xrm.DevOPs.Manager.Wrappers;
using Xrm.DevOPs.Manager.ComponentModel;

namespace Xrm.DevOPs.Controls
{
    public partial class SolutionCompareControl : UserControl
    {
        TreeView _orgTree;
        CrmSolution leftSelectedSol;
        CrmSolution rightSelectedSol;

        public TreeView OrganizationTree {
            get { return _orgTree; }
            set
            {
                _orgTree = value;
                ctrlLeftSolSelecter.OrganizationTree = value;
                ctrlRightSolSelecter.OrganizationTree = value;
            }
        }
        public SolutionCompareControl()
        {
            InitializeComponent();

            ctrlLeftSolSelecter.TVSolutions.AfterSelect += HandleLeftSolutionSelected;
            ctrlRightSolSelecter.TVSolutions.AfterSelect += HandleRightSolutionSelected;
        }

        private void HandleLeftSolutionSelected(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag?.ToString() == "Solution")
            {
                leftSelectedSol = GetSelectedSolution(e.Node, ctrlLeftSolSelecter, ctrlLeftCompareResult);
                ctrlLeftCompareResult.Header = $"Only in {leftSelectedSol.NameVersion}";
            }

        }
        private void HandleRightSolutionSelected(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag?.ToString() == "Solution")
            {
                rightSelectedSol = GetSelectedSolution(e.Node, ctrlRightSolSelecter, ctrlRightCompareResult);
                ctrlRightCompareResult.Header = $"Only in {rightSelectedSol.NameVersion}";
            }
        }

        public CrmSolution GetSelectedSolution(TreeNode node, SolutionSelecterControl ctrSolSelecter, SolCompareResultControl ctrSolCompareResult)
        {
            var selectedOrg = (CrmOrganization)ctrSolSelecter.CBOrgs.SelectedItem;
            TreeNode foundOrgNode = null;
            foreach (TreeNode orgNode in OrganizationTree.Nodes)
            {
                if (orgNode.Text == selectedOrg.ToString())
                {
                    foundOrgNode = orgNode;
                    break;
                }
            }

            CrmTreeNode<CrmSolution> foundSolNode = null;
            if (foundOrgNode != null)
            {
                foreach (CrmTreeNode<CrmSolution> solNode in foundOrgNode.Nodes)
                {
                    if (solNode.Text == node.Text)
                    {
                        foundSolNode = solNode;
                        break;
                    }
                    foreach (CrmTreeNode<CrmSolution> childSolNode in solNode.Nodes)
                    {
                        if (childSolNode.Text == node.Text)
                        {
                            foundSolNode = solNode;
                            break;
                        }
                    }
                }
                if (foundSolNode != null)
                    return (CrmSolution)foundSolNode.Component;

            }
            return null;
        }


        public void LoadOrgs(List<CrmOrganization> orgs)
        {
            ctrlLeftSolSelecter.CBOrgs.Items.Clear();
            ctrlRightSolSelecter.CBOrgs.Items.Clear();
            foreach (var crmOrg in orgs)
            {
                ctrlLeftSolSelecter.CBOrgs.Items.Add(crmOrg);
                ctrlRightSolSelecter.CBOrgs.Items.Add(crmOrg);
            }
        }

        private TreeNode SearchTree(TreeView tree, string name)
        {

            TreeNode found;
            foreach (TreeNode node in tree.Nodes)
            {
                found = SearchNode(node, name);
                if (found != null)
                    return found;
            }

            return null;

        }

        private TreeNode SearchNode(TreeNode searchNode, string name)
        {
            TreeNode node = null;
            while (searchNode != null)
            {
                if (searchNode.Tag?.ToString() == "Solution")
                {
                    var solNode = (CrmTreeNode<CrmSolution>)searchNode;
                    if (((CrmSolution)solNode.Component).UniqueName == name)
                    {
                        node = searchNode;
                        break;
                    }
                };
                if (searchNode.Nodes.Count != 0)
                {
                    node = SearchNode(searchNode.Nodes[0], name);
                    if (node != null)
                        break;
                };
                searchNode = searchNode.NextNode;
            };
            return node;
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {

            ctrlLeftCompareResult.Tree.Nodes.Clear();
            ctrlRightCompareResult.Tree.Nodes.Clear();
            ctrlInterCompareResult.Tree.Nodes.Clear();

            var leftNode = ctrlLeftSolSelecter.OrganizationTree?.SelectedNode;
            var rightNode = ctrlRightSolSelecter.OrganizationTree?.SelectedNode;

            if (this.leftSelectedSol == null || this.rightSelectedSol == null)
            {
                MessageBox.Show("Please select 2 solutions to compare");
                return;
            }
            if (leftSelectedSol.Tree == null)
            {
                MessageBox.Show($"Please load the {leftSelectedSol.NameVersion} solution first");
                return;
            }
            if (rightSelectedSol.Tree == null)
            {
                MessageBox.Show($"Please load the {rightSelectedSol.NameVersion} solution first");
                return;
            }


            foreach (TreeNode leftRootNode in leftSelectedSol.Tree.Nodes)
            {
                TreeNode lrn = null;
                TreeNode irn = null;

                TreeNode rightRootNode = null;
                foreach (TreeNode n in rightSelectedSol.Tree.Nodes)
                {
                    if (leftRootNode.Text == n.Text)
                    {
                        rightRootNode = n;
                        break;
                    }

                }
                lrn = new CrmTreeNode<string>() { Text = leftRootNode.Text };
                ctrlLeftCompareResult.Tree.Nodes.Add(lrn);
                if (rightRootNode != null)
                {
                    irn = new CrmTreeNode<string>() { Text = leftRootNode.Text };
                    ctrlInterCompareResult.Tree.Nodes.Add(irn);
                    foreach (TreeNode ln in leftRootNode.Nodes)
                    {
                        TreeNode rn = null;
                        foreach (TreeNode n in rightRootNode.Nodes)
                        {
                            if (ln.Text == n.Text)
                            {
                                rn = n;
                                break;
                            }

                        }
                        if (rn == null)
                            lrn.Nodes.Add(new CrmTreeNode<string>() { Text = ln.Text });
                        else
                            irn.Nodes.Add(new CrmTreeNode<string>() { Text = ln.Text });

                    }
                }

            }
            foreach (TreeNode rightRootNode in rightSelectedSol.Tree.Nodes)
            {
                TreeNode rrn = null;

                TreeNode leftRootNode = null;
                foreach (TreeNode n in leftSelectedSol.Tree.Nodes)
                {
                    if (rightRootNode.Text == n.Text)
                    {
                        leftRootNode = n;
                        break;
                    }

                }
                rrn = new CrmTreeNode<string>() { Text = rightRootNode.Text };
                ctrlRightCompareResult.Tree.Nodes.Add(rrn);
                if (leftRootNode != null)
                {
                    foreach (TreeNode rn in rightRootNode.Nodes)
                    {
                        TreeNode ln = null;
                        foreach (TreeNode n in leftRootNode.Nodes)
                        {
                            if (rn.Text == n.Text)
                            {
                                ln = n;
                                break;
                            }

                        }
                        if (ln == null)
                            rrn.Nodes.Add(new CrmTreeNode<string>() { Text = rn.Text });

                    }
                }

            }

        }
    }
}
