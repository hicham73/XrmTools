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
using System.Configuration;
using Xrm.DevOPs.Manager.Config;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace Xrm.DevOPs.Manager.Controls
{
    public partial class OrganizationControl : UserControl
    {

        public RichTextBox Log { get; set; }
        public CrmOrganization CrmMasterOrg { get; set; }
        public TreeView TvTfs { get; set; }
        public TreeView TvMasterConfig { get; set; }
        public CrmOrganization CrmOrg { get; set; }
        public ToolStrip Toolbar { get { return toolbar; } }

        public TreeView Tree { get { return tvSolutions;  } }

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
                        Tag = "SolutionBase",
                        Name = sol.FriendlyName
                    };

                    tvSolutions.Nodes.Add(crmSolNode);

                    foreach (var childSol in sol.ChildSolutions.Components)
                    {
                        var crmChildSolNode = new CrmTreeNode<CrmSolution>()
                        {
                            Component = childSol,
                            Text = childSol.NameVersion,
                            Tag = "SolutionPatch",
                            Name = childSol.FriendlyName

                        };

                        crmSolNode.Nodes.Add(crmChildSolNode);
                    }
                }

                tvSolutions.ExpandAll();
            }
        }

        #region UI
        private void BtnSyncConfig_Click(object sender, EventArgs e)
        {
            var fromOrg = CrmMasterOrg;
            var toOrg = CrmOrg;

            TreeNode masterNode = null;
            foreach (TreeNode n in TvMasterConfig.Nodes)
            {
                if (n.Text.StartsWith("MasterConfig"))
                {
                    masterNode = n;
                    break;
                }
            }

            if (masterNode != null)
            {
                foreach (CrmTreeNode<CrmSolution> cn in masterNode.Nodes)
                {
                    var patch = (CrmSolution)cn.Component;
                    var qa = new QueryByAttribute("solution");
                    qa.AddAttributeValue("uniquename", patch.UniqueName);
                    qa.AddAttributeValue("version", patch.Version);

                    if (!CrmOrg.Service.RetrieveMultiple(qa).Entities.Any())
                    {
                        SolutionHelper.TransferSolution(CrmMasterOrg, CrmOrg, patch.UniqueName);
                        MessageBox.Show($"solution {patch.UniqueName} transfered");
                    }

                }
            }
        }

        List<TreeNode> DiffFiles = new List<TreeNode>();
        private void BtnSyncProjects_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ProjectElement proj in GlobalContext.Config.Projects)
                {
                    
                    var projectName = proj.Name;
                    var baseNode = FindSolProjectNode(tvSolutions, projectName);
                    if (baseNode != null)
                    {
                        var sol = (CrmSolution)baseNode.Component;
                        var versions = sol.Version.Split('.');
                        var version = $"{versions[0]}.{versions[1]}";
                        var tfsNode = FindTFSProjectNode(TvTfs, projectName, version);

                        if (tfsNode != null)
                        {
                            var fileExists = false;
                            foreach (TreeNode fn in tfsNode.Nodes)
                            {
                                foreach (CrmTreeNode<CrmSolution> pn in baseNode.Nodes)
                                {
                                    var patch = (CrmSolution)pn.Component;
                                    var fileName = $"{patch.Version.Replace('.', '_')}.zip";
                                    if (fn.Name.Contains(projectName) && fn.Name.Contains(fileName))
                                    {
                                        fileExists = true;
                                        break;
                                    }
                                }

                                if (!fileExists)
                                {
                                    DiffFiles.Add(fn);
                                }
                                fileExists = false;
                            }
                        }
                    }
                }

                foreach (TreeNode node in DiffFiles)
                {
                    TransferPatch((Item)node.Tag);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while sycning projects, Message: {ex.Message}, Inner: {ex.InnerException?.Message}");
            }
        }

        private void BtnSyncAll_Click(object sender, EventArgs e)
        {

        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ReLoadSolutions();
        }

        CrmTreeNode<CrmSolution> FindSolProjectNode(TreeView tv, string projectName)
        {
            projectName = $"{projectName}Base";
            foreach (TreeNode n in tv.Nodes)
            {
                if (n.Name == projectName)
                    return (CrmTreeNode<CrmSolution>)n;
            }
            return null;
        }
        TreeNode FindTFSProjectNode(TreeView tv, string projectName, string version)
        {
            if (TvTfs.Nodes.Count > 0)
            {
                var tfsNode = TvTfs.Nodes[0];
                foreach (TreeNode n in tfsNode.Nodes)
                {
                    if (n.Text == projectName)
                    {
                        foreach (TreeNode vn in n.Nodes)
                        {
                            if (vn.Text == version)
                                return vn;
                        }
                    }

                }
            }
            return null;
        }

        private void TransferPatch(Item item)
        {
            var stream = item.DownloadFile();
            var bytes = StreamHelper.ReadToEnd(stream);

            ImportSolutionRequest impSolReq = new ImportSolutionRequest()
            {
                CustomizationFile = bytes
            };

            CrmOrg.Service.Execute(impSolReq);
        }

        #endregion
    }

    enum SearchOption
    {
        Equal,
        StartsWith,
        Contains
    }
}
