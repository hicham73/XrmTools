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
using Xrm.DevOPs.Manager.Helpers;
using Xrm.DevOPs.Manager.ComponentModel;

namespace Xrm.DevOPs.Manager.Controls
{
    public partial class OrganizationControl : UserControl
    {
        public CrmOrganization CrmMasterOrg { get; set; }
        public TreeView TvTfs { get; set; }
        public CrmOrganization CrmOrg { get; set; }
        public ToolStrip Toolbar { get { return toolbar; } }

        public ToolStripLabel LblOrgName { get { return lblOrgName; } }

        public OrganizationControl()
        {
            InitializeComponent();

        }

        public void LoadSolutions(CrmOrganization crmOrg)
        {
            
            CrmOrg = crmOrg;

            ReLoadSolutions();
        }

        private void ReLoadSolutions()
        {
            if (CrmOrg != null)
            {
                tvSolutions.Nodes.Clear();

                var solutions = SolutionHelper.GetSolutions(CrmOrg.Service);

                foreach (var sol in solutions)
                {
                    var crmSolNode = new CrmTreeNode<CrmSolution>()
                    {
                        Component = sol,
                        Text = sol.NameVersion,
                        Tag = "Solution"
                    };

                    tvSolutions.Nodes.Add(crmSolNode);

                    foreach (var childSol in sol.ChildSolutions.Components)
                    {
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

        #region UI
        private void BtnSyncConfig_Click(object sender, EventArgs e)
        {

        }

        private void BtnSyncProjects_Click(object sender, EventArgs e)
        {

        }

        private void BtnSyncAll_Click(object sender, EventArgs e)
        {

        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ReLoadSolutions();
        }

        #endregion
    }
}
