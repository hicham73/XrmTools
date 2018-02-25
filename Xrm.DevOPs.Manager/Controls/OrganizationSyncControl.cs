using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Xrm.DevOPs.Manager.Controls
{
    public partial class OrganizationSyncControl : UserControl
    {

        #region Contructors
        public OrganizationSyncControl()
        {
            InitializeComponent();
            OrgControls = new List<OrganizationControl>()
            {
                orgControlDev1,
                orgControlDev2,
                orgControlDev3,
                orgControlDev4,
                orgControlDev5,
                orgControlDev6,
            };
        }

        #endregion

        #region Properties
        List<OrganizationControl> OrgControls;
        public GlobalContext Context { get; internal set; }

        #endregion

        #region Methods
        public void LoadSolutions()
        {
            int i = 0;
            foreach (var org in Context.CrmOrganizations)
            {
                if (org.Name == "MasterConfig")
                {
                    masterOrgControl.LoadSolutions(org);
                    masterOrgControl.LblOrgName.Text = org.Name;
                    masterOrgControl.OrgName = org.Name;
                    masterOrgControl.ParentControl = this;
                    masterOrgControl.SolutionImportControl = solutionImportControl;
                }
                else if (org.Name == "Integration")
                {
                    integrationOrgControl.LoadSolutions(org);
                    integrationOrgControl.LblOrgName.Text = org.Name;
                    integrationOrgControl.OrgName = org.Name;
                    integrationOrgControl.ParentControl = this;
                    integrationOrgControl.SolutionImportControl = solutionImportControl;
                }
                else
                {
                    OrgControls[i].LoadSolutions(org);
                    OrgControls[i].LblOrgName.Text = org.Name;
                    OrgControls[i].OrgName = org.Name;
                    OrgControls[i].ParentControl = this;
                    OrgControls[i].SolutionImportControl = solutionImportControl;
                    i++;
                }

            }

            for (i = 0; i < OrgControls.Count; i++)
            {
                OrgControls[i].CrmMasterOrg = masterOrgControl.CrmOrg;
                OrgControls[i].TvTfs = tvTFS;
                OrgControls[i].TvMasterConfig = masterOrgControl.Tree;
            }

            ReloadTFSFiles();
        }

        public void ReloadTFSFiles()
        {
            var tfsConfig = GlobalContext.Config.TFS;
            var sc = GlobalContext.SourceControl;

            var items = sc.GetFolderItems(tfsConfig.SolsFolder);
            char pathSeperator = '/';

            TreeNode lastNode = null;
            string subPathAgg;
            for(int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                subPathAgg = string.Empty;
                var p = item.ServerItem;
                foreach (string subPath in p.Split(pathSeperator))
                {
                    subPathAgg += subPath + pathSeperator;
                    TreeNode[] nodes = tvTFS.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                    {
                        var n = new TreeNode() { Tag = item, Name = subPathAgg, Text = subPath };

                        if (lastNode == null)
                            tvTFS.Nodes.Add(n);
                        else
                            lastNode.Nodes.Add(n);

                        lastNode = n;
                    }
                    else
                        lastNode = nodes[0];
                }
            }

            tvTFS.ExpandAll();
        }

        #endregion

        #region UI
        private void BtnReload_Click(object sender, EventArgs e)
        {
            ReloadTFSFiles();
        }

        #endregion


    }

 
}
