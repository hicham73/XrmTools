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
                orgControlDev4
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
                    orgControlConfig.LoadSolutions(org);
                    orgControlConfig.LblOrgName.Text = org.Name;
                }
                else
                {
                    OrgControls[i].LoadSolutions(org);
                    OrgControls[i].LblOrgName.Text = org.Name;
                    i++;
                }

            }

            for (i = 0; i < OrgControls.Count; i++)
            {
                OrgControls[i].CrmMasterOrg = orgControlConfig.CrmOrg;
                OrgControls[i].TvTfs = tvTFS;
            }

            ReloadSolutions();
        }

        private void ReloadSolutions()
        {
            tvTFS.Nodes.Clear();

            var folderContent = GetFolderItems("$/CRMDevOPs/Solutions");
            List<Value> paths = folderContent.Result.value;
            string rootPath = "$/CRMDevOPs/";
            char pathSeparator = '/';
            
            TreeNode lastNode = null;
            string subPathAgg;
            foreach (var item in paths)
            {
                subPathAgg = string.Empty;
                var p = item.path.Replace(rootPath, "");
                foreach (string subPath in p.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = tvTFS.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                    {
                        var n = new TreeNode();
                        n.Tag = item;
                        n.Name = subPathAgg;
                        n.Text = subPath;
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
        }

        private async Task<FolderContent> GetFolderItems(string folderPath)
        {
            string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", "f55jctcmowqpla3rmjic64wxpho4d6pxw66kvuh2y35xuu6uisyq")));

            //use the httpclient
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://hwahbi.visualstudio.com/DefaultCollection/");  //url of our account
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                var qs = $"_apis/tfvc/items?scopePath={folderPath}&api-version=1.0&recursionLevel=Full";
                HttpResponseMessage response = client.GetAsync(qs).Result;

                //check to see if we have a succesfull respond
                if (response.IsSuccessStatusCode)
                {
                    //set the viewmodel from the content in the response
                    var content = response.Content;

                    var c = await content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<FolderContent>(c);

                }
            }

            return null;
        }

        private async void DownloadFile(Value item)
        {
            string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", "f55jctcmowqpla3rmjic64wxpho4d6pxw66kvuh2y35xuu6uisyq")));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://hwahbi.visualstudio.com/DefaultCollection/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                var qs = $"_apis/tfvc/items/{item.path}";
                HttpResponseMessage response = client.GetAsync(qs).Result;

                using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    var fileName = Path.GetFileName(item.path);
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

        #region UI
        private void TVTFS_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var n = ((TreeView)sender).SelectedNode;
            var item = (Value)n.Tag;
            DownloadFile(item);
        }

        #endregion

        private void BtnReload_Click(object sender, EventArgs e)
        {
            ReloadSolutions();
        }
    }

    public class Value
    {
        public int version { get; set; }
        public DateTime changeDate { get; set; }
        public string path { get; set; }
        public bool isFolder { get; set; }
        public string url { get; set; }
        public string hashValue { get; set; }
    }

    public class FolderContent
    {
        public List<Value> value { get; set; }
        public int count { get; set; }
    }

}
