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

namespace Xrm.DevOPs.Manager.Controls
{
    public partial class OrganizationControl : UserControl
    {
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


            //var masterConfig = _config.GetOrgConfigByName("MasterConfig");
            //var configPatchPrefix = $"MasterConfigBase_Patch";

            //fromOrg.LoadConfigSolutions(configPatchPrefix);
            //toOrg.LoadConfigSolutions(configPatchPrefix);

            //int count = 0;
            //foreach (var sol in fromOrg.ConfigSolutions)
            //{
            //    var isOld = toOrg.ConfigSolutions.Where(x => x.UniqueName == sol.UniqueName && x.Version == sol.Version).Any<CrmSolution>();

            //    if (!isOld)
            //    {
            //        SolutionHelper.TransferSolution(fromOrg, toOrg, sol.UniqueName);
            //        count++;
            //    }
            //}
        }

        List<TreeNode> DiffFiles = new List<TreeNode>();
        private void BtnSyncProjects_Click(object sender, EventArgs e)
        {
            try
            {
                var config = (ManagerSection)ConfigurationManager.GetSection("Manager");

                foreach (ProjectElement proj in config.Projects)
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
                    TransferPatch(((Value)(node.Tag))?.path);
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

        private async void TransferPatch(string tfsPath)
        {
            string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", "f55jctcmowqpla3rmjic64wxpho4d6pxw66kvuh2y35xuu6uisyq")));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://hwahbi.visualstudio.com/DefaultCollection/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                var qs = $"_apis/tfvc/items/{tfsPath}";
                HttpResponseMessage response = client.GetAsync(qs).Result;
                //using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                //{
                //    var fileName = Path.GetFileName(tfsPath);
                //    string fileToWriteTo = $"c:/temp/{fileName}";
                //    using (Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create))
                //    {
                //        await streamToReadFrom.CopyToAsync(streamToWriteTo);
                //    }

                //    response.Content = null;
                //}
                var bytes = response.Content.ReadAsByteArrayAsync().Result;

                ImportSolutionRequest impSolReq = new ImportSolutionRequest()
                {
                    CustomizationFile = bytes
                };

                CrmOrg.Service.Execute(impSolReq);
            }
        }
        private async void DownloadFile(string tfsPath)
        {
            string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", "f55jctcmowqpla3rmjic64wxpho4d6pxw66kvuh2y35xuu6uisyq")));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://hwahbi.visualstudio.com/DefaultCollection/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                var qs = $"_apis/tfvc/items/{tfsPath}";
                HttpResponseMessage response = client.GetAsync(qs).Result;

                using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    var fileName = Path.GetFileName(tfsPath);
                    string fileToWriteTo = $"c:/temp/{fileName}";
                    using (Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create))
                    {
                        await streamToReadFrom.CopyToAsync(streamToWriteTo);
                    }

                    response.Content = null;
                }
            }
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
