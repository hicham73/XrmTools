using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using Xrm.DevOPs.Manager.TFS;

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
        internal void LoadSolutions()
        {
            int i = 0;
            foreach (var org in Context.CrmOrganizations)
            {
                if (org.Name == "MasterConfig")
                {
                    masterOrgControl.LoadSolutions(org);
                    masterOrgControl.LblOrgName.Text = org.Name;
                    masterOrgControl.Log = rtSyncLog;
                }
                else if (org.Name == "Integration")
                {
                    integrationOrgControl.LoadSolutions(org);
                    integrationOrgControl.LblOrgName.Text = org.Name;
                    integrationOrgControl.Log = rtSyncLog;
                }
                else
                {
                    OrgControls[i].LoadSolutions(org);
                    OrgControls[i].LblOrgName.Text = org.Name;
                    OrgControls[i].Log = rtSyncLog;
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

        private void ReloadTFSFiles()
        {
            var tfsConfig = GlobalContext.Config.TFS;

            SourceControl sc = new SourceControl(tfsConfig.Url, tfsConfig.Username, tfsConfig.Password);
            var items = sc.GetFolderItems("$/CRMDevOPs/Solutions");
            char pathSeperator = '/';

            TreeNode lastNode = null;
            string subPathAgg;
            for(int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                subPathAgg = string.Empty;
                //var p = item.path.Replace(rootPath, "");
                foreach (string subPath in item.ServerItem.Split(pathSeperator))
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

        #endregion

        private void BtnReload_Click(object sender, EventArgs e)
        {
            ReloadTFSFiles();
        }
    }

 
}
