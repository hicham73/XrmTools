using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xrm.DevOPs.Manager.ComponentModel;
using Xrm.DevOPs.Manager.Wrappers;
using Xrm.DevOPs.Manager.Helpers;

namespace Xrm.DevOPs.Controls
{
    public partial class SolutionSelecterControl : UserControl
    {

        public TreeView OrganizationTree { get; set; }

        public SolutionCompareControl ParentControl { get; set; }
        public SolutionSelecterControl()
        {
            InitializeComponent();
        }

        public ComboBox CBOrgs
        {
            get { return cbOrgs; }
        }
        public TreeView TVSolutions
        {
            get { return tvSolutions; }
        }

        private void CBOrgs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sourceOrg = (CrmOrganization)((ComboBox)sender).SelectedItem;

            var crmOrgNode = new CrmTreeNode<CrmOrganization>()
            {
                Component = sourceOrg,
                Text = sourceOrg.Name,
                Tag = "Organization"

            };

            tvSolutions.Nodes.Add(crmOrgNode);

            LoadOrganizationNode(sourceOrg.Name, sourceOrg, crmOrgNode);

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


    }
}
