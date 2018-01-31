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

namespace Xrm.DevOPs.Controls
{
    public partial class SolutionCompareControl : UserControl
    {
        public SolutionCompareControl()
        {
            InitializeComponent();
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
    }
}
