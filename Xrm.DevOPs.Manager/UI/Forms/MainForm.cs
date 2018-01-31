using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using Xrm.DevOPs.Manager.Diff;
using Xrm.DevOPs.Manager.Helpers;
using Xrm.DevOPs.Manager.UI;
using Xrm.DevOPs.Manager.Util;
using Xrm.DevOPs.Manager.Wrappers;
using System.Linq;
using Xrm.DevOPs.ComponentModel;
using Xrm.DevOPs.Manager.ComponentModel;

namespace Xrm.DevOPs.Manager.UI.Forms
{
    // TODO: Add workflows to the diff
    // TODO: Add an option to diff (select all) the custom entities
    public partial class MainForm : Form
    {
        static List<KeyValuePair<String, IOrganizationService>> _orgServices = new List<KeyValuePair<string, IOrganizationService>>();
        static List<CrmOrganization> CrmOrganizations = new List<CrmOrganization>();
        static bool isOrganizationsLoaded = false;
        private DiffGenerator _diffGenerator = new DiffGenerator();
        static System.Drawing.Color LeftColor = System.Drawing.Color.LightBlue;
        static System.Drawing.Color RightColor = System.Drawing.Color.LightGray;

        public MainForm()
        {
            InitializeComponent();

            Setting.DiffComponentsFilter = clbDiffOptions;
            Setting.DiffEntityFilter = lvEntities;

        }

        private static Boolean isValidConnectionString(String connectionString)
        {
            // At a minimum, a connection string must contain one of these arguments.
            if (connectionString.Contains("Url=") ||
                connectionString.Contains("Server=") ||
                connectionString.Contains("ServiceUri="))
                return true;

            return false;
        }


        #region UI Actions
        private void TVOrgs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = tvOrgs.SelectedNode;

            if (node.Tag?.ToString() == "Solution")
            {
                var solNode = (CrmTreeNode<CrmSolution>)node;
                var crmSol = (CrmSolution)solNode.Component;
                var org = crmSol.Organization;
                var service = org.Service;

                crmSol.LoadMeta(service);

                var path = solNode.Text;

                if (solNode.Parent != null)
                {
                    path = $"{solNode.Parent.Text}::{path}";
                    if (solNode.Parent.Parent != null)
                        path = $"{solNode.Parent.Parent.Text}::{path}";
                }

                crmSol.Path = path;

                var solExplorer = new SolutionExplorer(crmSol.Path, imageList1);
                var controls = tabControlMain.Controls.Find(crmSol.UniqueName, false);
                if (controls.Length == 0)
                {
                    solExplorer.Display(crmSol);
                    tabControlMain.Controls.Add(solExplorer.Container);
                }
                tabControlMain.SelectTab(crmSol.UniqueName);
            }

        }

 
        private void MIOptions_Click(object sender, EventArgs e)
        {
            clbDiffOptions.Visible = !clbDiffOptions.Visible;
        }

        private void MIDiff_Click(object sender, EventArgs e)
        {

            List<string> options = new List<string>();

            options.Clear();

            foreach (var comp in clbDiffOptions.CheckedItems)
            {
                options.Add(comp.ToString());
            }
            
            _diffGenerator.Compare(options);
            DisplayDiffResult();
        }

        private void MILoadEntities_Click(object sender, EventArgs e)
        {
            LoadEntities();
        }

        private void CBLeftOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            var crmOrg = (CrmOrganization)((ToolStripComboBox)sender).SelectedItem;
            _diffGenerator.LeftService = crmOrg.Service;
        }

        private void CBRightOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            var crmOrg = (CrmOrganization)((ToolStripComboBox)sender).SelectedItem;
            _diffGenerator.RightService = crmOrg.Service;
        }


        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvEntities.Items.Clear();

            foreach (var item in _diffGenerator.Entities)
            {
                if (item.IsCustomEntity)
                    lvEntities.Items.Add(new ListViewItem()
                    {
                        Text = item.DisplayName,
                        Tag = item
                    });

            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvEntities.Items.Clear();

            foreach (var item in _diffGenerator.Entities)
            {
                lvEntities.Items.Add(new ListViewItem()
                {
                    Text = item.DisplayName,
                    Tag = item
                });

            }
        }

        private void MIOrgLoad_Click(object sender, EventArgs e)
        {
            int count = ConfigurationManager.ConnectionStrings.Count;
            List<KeyValuePair<String, String>> filteredConnectionStrings = new List<KeyValuePair<String, String>>();

            if (!isOrganizationsLoaded)
            {
                for (int a = 0; a < count; a++)
                {
                    var name = ConfigurationManager.ConnectionStrings[a].Name;
                    var connStr = ConfigurationManager.ConnectionStrings[a].ConnectionString;
                    if (isValidConnectionString(connStr))
                    {
                        CrmServiceClient conn = new CrmServiceClient(connStr);
                        var orgService = (IOrganizationService)conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
                        _orgServices.Add(new KeyValuePair<string, IOrganizationService>(name, orgService));

                        var crmOrg = new CrmOrganization()
                        {
                            Name = name,
                            Service = orgService,
                            Type = EnumTypes.TreeNodeType.Organization,
                        };

                        CrmOrganizations.Add(crmOrg);

                        cbLeftOrg.Items.Add(crmOrg);
                        cbRightOrg.Items.Add(crmOrg);

                        var crmOrgNode = new CrmTreeNode<CrmOrganization>()
                        {
                            Component = crmOrg,
                            Text = name,
                            Tag = "Organization"

                        };

                        tvOrgs.Nodes.Add(crmOrgNode);

                        LoadOrganizationNode<CrmOrganization>(name, crmOrg, crmOrgNode);

                    }
                }

                isOrganizationsLoaded = true;
            }
            else
            {
                RefreshOrganizations();
            }
        }

        private void MIOrgCompare_Click(object sender, EventArgs e)
        {
            tabCtrlMain.SelectTab(1);
        }

        private void MISolCompare_Click(object sender, EventArgs e)
        {
            tabCtrlMain.SelectTab(2);

        }

        private void MISolTransfer_Click(object sender, EventArgs e)
        {
            var frm = new SolutionTransferDlg();

            frm.LoadForm(CrmOrganizations);

            frm.Show();
        }

        
        #endregion

        #region Display

        public void RefreshOrganizations()
        {
            foreach (CrmTreeNode<CrmOrganization> orgNode in tvOrgs.Nodes)
            {
                LoadOrganizationNode(orgNode.Name, (CrmOrganization)orgNode.Component, orgNode);
            }
        }

        public void LoadEntities()
        {
            if (_diffGenerator.LeftService == null || _diffGenerator.RightService == null)
            {
                MessageBox.Show("You need to connect to and select 2 organizations");
                return;
            }
            ShowEntities(_diffGenerator.LeftService);
        }

        public void ShowEntities(IOrganizationService organizationService)
        {
            Dictionary<string, string> attributesData = new Dictionary<string, string>();
            RetrieveAllEntitiesRequest metaDataRequest = new RetrieveAllEntitiesRequest();
            RetrieveAllEntitiesResponse metaDataResponse = new RetrieveAllEntitiesResponse();
            metaDataRequest.EntityFilters = EntityFilters.Entity;

            metaDataResponse = (RetrieveAllEntitiesResponse)organizationService.Execute(metaDataRequest);
            var entities = metaDataResponse.EntityMetadata;

            _diffGenerator.Entities.Clear();
            lvEntities.Items.Clear();

            foreach (var e in entities)
            {
                var displayName = e.DisplayName;

                if (e.IsCustomizable.Value && displayName != null)
                {
                    if (displayName.UserLocalizedLabel != null)
                    {
                        var dn = displayName.UserLocalizedLabel?.Label.ToString();
                        if (e.IsCustomizable.Value)
                        {
                            var ei = new EntityInfo()
                            {
                                LogicalName = e.LogicalName,
                                DisplayName = dn,
                                ObjectTypeCode = e.ObjectTypeCode.Value,
                                IsCustomEntity = e.IsCustomEntity.Value

                            };
                            _diffGenerator.Entities.Add(ei);
                            lvEntities.Items.Add(new ListViewItem()
                            {
                                Text = dn,
                                Tag = ei
                            });

                        }

                        if(!Mapping.ObjectTypeCodeName.ContainsKey(e.LogicalName))
                            Mapping.ObjectTypeCodeName.Add(e.LogicalName, e.ObjectTypeCode.Value);
                    }

                }
            }

        }

        public void DisplayDiffResult()
        {
            entityDiffControl1.Clear();

            foreach (var entityDiff in _diffGenerator.DiffResult.Entities)
            {
                foreach (var attrDiff in entityDiff.Attributes)
                {
                    var left = attrDiff.Left;
                    var right = attrDiff.Right;

                    var item = new ListViewItem(new string[] {
                    entityDiff.EntityInfo.LogicalName,
                    attrDiff.Name,
                    left?.DisplayName?.UserLocalizedLabel?.Label,
                    left?.AttributeTypeName.Value,
                    right?.DisplayName?.UserLocalizedLabel?.Label,
                    right?.AttributeTypeName.Value});

                    ColorColumns(item, 2, 6);

                    entityDiffControl1.LVAttributes.Items.Add(item);
                }
                foreach (var relDiff in entityDiff.OneToManyRelationships)
                {

                    var left = relDiff.Left;
                    var right = relDiff.Right;

                    var item = new ListViewItem(new string[] {
                        entityDiff.EntityInfo.LogicalName,
                        relDiff.Name,
                        left?.ReferencedEntity,
                        left?.ReferencingEntity,
                        left?.ReferencedAttribute,
                        right?.ReferencedEntity,
                        right?.ReferencingEntity,
                        right?.ReferencedAttribute,

                    });
                    ColorColumns(item, 2, 8);

                    entityDiffControl1.LVOneToManyRelationships.Items.Add(item);

                }

                foreach (var relDiff in entityDiff.ManyToManyRelationships)
                {

                    var left = relDiff.Left;
                    var right = relDiff.Right;

                    var item = new ListViewItem(new string[] {
                        entityDiff.EntityInfo.LogicalName,
                        relDiff.Name,
                        left?.Entity1LogicalName,
                        left?.Entity2LogicalName,
                        right?.Entity1LogicalName,
                        right?.Entity2LogicalName,
                    });
                    ColorColumns(item, 2, 6);

                    entityDiffControl1.LVManyToManyRelationships.Items.Add(item);

                }


                foreach (var fd in entityDiff.Forms)
                {
                    var left = fd.Left;
                    var right = fd.Right;

                    var item = new ListViewItem(new string[] {
                        entityDiff.EntityInfo.LogicalName,
                        fd.Name,
                        left?.GetAttributeValue<string>("name"),
                        left?.GetAttributeValue<OptionSetValue>("type")?.Value.ToString(),
                        right?.GetAttributeValue<string>("name"),
                        right?.GetAttributeValue<OptionSetValue>("type")?.Value.ToString(),
                    });

                    ColorColumns(item, 2, 6);
                    entityDiffControl1.LVForms.Items.Add(item);

                }
                foreach (var vd in entityDiff.Views)
                {
                    var left = vd.Left;
                    var right = vd.Right;

                    var item = new ListViewItem(new string[] {
                        entityDiff.EntityInfo.LogicalName,
                        vd.Name,
                        left?.GetAttributeValue<OptionSetValue>("type")?.Value.ToString(),
                        right?.GetAttributeValue<OptionSetValue>("type")?.Value.ToString(),
                    });

                    ColorColumns(item, 2, 4);
                    entityDiffControl1.LVViews.Items.Add(item);

                }
            }

            foreach (var wd in _diffGenerator.DiffResult.Workflows)
            {
                var left = wd.Left;
                var right = wd.Right;

                var item = new ListViewItem(new string[] {
                    wd.Name,
                    left?.GetAttributeValue<OptionSetValue>("category").Value.ToString(),
                    right?.GetAttributeValue<OptionSetValue>("category").Value.ToString(),
                });

                ColorColumns(item, 1, 5);

                entityDiffControl1.LVWorkflows.Items.Add(item);
            }

            foreach (var pd in _diffGenerator.DiffResult.Plugins)
            {
                var left = pd.Left;
                var right = pd.Right;

                var item = new ListViewItem(new string[] {
                    pd.Name,
                    left?.GetAttributeValue<bool>("iswokflowactivity").ToString(),
                    right?.GetAttributeValue<bool>("iswokflowactivity").ToString(),
                });
                ColorColumns(item, 1, 3);

                entityDiffControl1.LVPlugins.Items.Add(item);
            }


            foreach (var smps in _diffGenerator.DiffResult.SdkMessageProcessingSteps)
            {
                var left = smps.Left;
                var right = smps.Right;

                var item = new ListViewItem(new string[] {
                    smps.Name,
                    left?.GetAttributeValue<EntityReference>("eventhandler")?.Name,
                    left?.GetAttributeValue<OptionSetValue>("stage")?.Value.ToString(),
                    left?.GetAttributeValue<OptionSetValue>("statecode")?.Value.ToString(),
                    right?.GetAttributeValue<EntityReference>("eventhandler")?.Name,
                    right?.GetAttributeValue<OptionSetValue>("stage")?.Value.ToString(),
                    right?.GetAttributeValue<OptionSetValue>("statecode")?.Value.ToString(),
                });
                ColorColumns(item, 1, 7);

                entityDiffControl1.LVPlugins.Items.Add(item);
            }

            foreach (var temp in _diffGenerator.DiffResult.Templates)
            {
                var left = temp.Left;
                var right = temp.Right;

                var item = new ListViewItem(new string[] {
                    temp.Name,
                    temp.EntityName,
                    left?.GetAttributeValue<string>("description"),
                    right?.GetAttributeValue<string>("description"),
                });
                ColorColumns(item, 2, 4);

                entityDiffControl1.LVPlugins.Items.Add(item);
            }

            entityDiffControl1.OptimizeDisplay();

        }

        private void ColorColumns(ListViewItem item, int rn, int n)
        {

            int j = (n - rn) / 2;

            for (var i = 0; i < j; i++)
            {
                item.SubItems[i + rn].BackColor = LeftColor;
            }
            for (var i = j; i < n - rn; i++)
            {
                item.SubItems[i + rn].BackColor = RightColor;
            }

            item.UseItemStyleForSubItems = false;

        }

        public void LoadOrganizationNode<T>(string name, CrmOrganization crmOrg, CrmTreeNode<T> crmOrgNode)
        {
            crmOrgNode.Nodes.Clear();
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


        #endregion


    }


}





