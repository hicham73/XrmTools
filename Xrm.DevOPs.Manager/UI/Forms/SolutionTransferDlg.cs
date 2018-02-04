using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xrm.DevOPs.Manager.ComponentModel;
using Xrm.DevOPs.Manager.Helpers;
using Xrm.DevOPs.Manager.UI;
using Xrm.DevOPs.Manager.Wrappers;

namespace Xrm.DevOPs.Manager.UI.Forms
{
    public partial class SolutionTransferDlg : Form
    {

        CrmOrganization sourceOrg, targetOrg;
        public GlobalContext Context { get; set; }
        public SolutionTransferDlg()
        {
            InitializeComponent();
        }

        internal void LoadForm()
        {
            foreach (var crmOrg in Context.CrmOrganizations)
            {
                cbFromOrg.Items.Add(crmOrg);
                cbToOrg.Items.Add(crmOrg);
            }
        }

        private void CBSourceOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
             sourceOrg = (CrmOrganization)((ToolStripComboBox)sender).SelectedItem;

            var crmOrgNode = new CrmTreeNode<CrmOrganization>()
            {
                Component = sourceOrg,
                Text = sourceOrg.Name,
                Tag = "Organization"

            };

            tvLeftOrg.Nodes.Add(crmOrgNode);

            LoadOrganizationNode(sourceOrg.Name, sourceOrg, crmOrgNode);

        }



        private void CBTargetOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetOrg = (CrmOrganization)((ToolStripComboBox)sender).SelectedItem;
            var crmOrgNode = new CrmTreeNode<CrmOrganization>()
            {
                Component = targetOrg,
                Text = targetOrg.Name,
                Tag = "Organization"

            };

            tvRightOrg.Nodes.Add(crmOrgNode);

            LoadOrganizationNode(targetOrg.Name, targetOrg, crmOrgNode);
        }

        public void LoadOrganizationNode<T>(string name, CrmOrganization crmOrg, CrmTreeNode<T> crmOrgNode)
        {
            var solutions = SolutionHelper.GetSolutions(crmOrg.Service);

            foreach (var sol in solutions)
            {
                sol.Organization = (CrmOrganization)crmOrgNode.Component;
                var crmSolNode = new CrmTreeNode<CrmSolution>()
                {
                    Component = sol,
                    Text = sol.NameVersion,
                    Tag = "Solution"
                };

                crmOrgNode.Nodes.Add(crmSolNode);

                foreach (var childSol in sol.ChildSolutions.Components)
                {
                    childSol.Organization = (CrmOrganization)crmOrgNode.Component;
                    var crmChildSolNode = new CrmTreeNode<CrmSolution>()
                    {
                        Component = childSol,
                        Text = childSol.NameVersion,
                        Tag = "Solution"
                    };

                    crmSolNode.Nodes.Add(crmChildSolNode);

                }
            }
        }

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            var node = tvLeftOrg.SelectedNode;

            if (node.Tag?.ToString() == "Solution")
            {
                var solNode = (CrmTreeNode<CrmSolution>)node;
                var crmSol = (CrmSolution)solNode.Component;

                SolutionHelper.TransferSolution(sourceOrg, targetOrg, crmSol.UniqueName);
                MessageBox.Show("Transfer complete");

            }
            else
            {
                MessageBox.Show("Please select a solution from the source Org.");
            }
        }
    }
}
