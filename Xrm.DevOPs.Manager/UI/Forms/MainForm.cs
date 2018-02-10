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
using Xrm.DevOPs.Manager.Wrappers;
using Xrm.DevOPs.Manager.Component;
using Xrm.DevOPs.Manager.ComponentModel;


namespace Xrm.DevOPs.Manager.UI.Forms
{
    public partial class MainForm : Form
    {

        public GlobalContext Context;
        public MainForm()
        {
            InitializeComponent();

            Setting.DiffComponentsFilter = clbDiffOptions;
            Setting.DiffEntityFilter = lvEntities;

            Context = new GlobalContext();

            Context.OrganizationTree = tvOrgs;
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

                crmSol.Path = solNode.Text;
                if (solNode.Parent != null)
                {
                    crmSol.Path = $"{solNode.Parent.Text}::{crmSol.Path}";
                    if (solNode.Parent.Parent != null)
                    {
                        crmSol.Path = $"{solNode.Parent.Parent.Text}::{crmSol.Path}";
                        if (solNode.Parent.Parent.Parent != null)
                            crmSol.Path = $"{solNode.Parent.Parent.Parent.Text}::{crmSol.Path}";
                    }
                }
                var solExplorer = new SolutionExplorer(crmSol.Path, imageList1);
                crmSol.Tree = solExplorer.Tree;
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

            Context.DiffGenerator.Compare(options);
            DisplayDiffResult();
        }

        private void MILoadEntities_Click(object sender, EventArgs e)
        {
            LoadEntities();
        }

        private void CBLeftOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            var crmOrg = (CrmOrganization)((ToolStripComboBox)sender).SelectedItem;
            Context.DiffGenerator.LeftService = crmOrg.Service;
        }

        private void CBRightOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            var crmOrg = (CrmOrganization)((ToolStripComboBox)sender).SelectedItem;
            Context.DiffGenerator.RightService = crmOrg.Service;
        }


        private void MIEntitiesLoad_Click(object sender, EventArgs e)
        {
            lvEntities.Items.Clear();

            foreach (var item in Context.DiffGenerator.Entities)
            {
                if (item.IsCustomEntity)
                    lvEntities.Items.Add(new ListViewItem()
                    {
                        Text = item.DisplayName,
                        Tag = item
                    });

            }
        }

        private void MIOrgLoad_Click(object sender, EventArgs e)
        {
            
        }

        private void MIOrgDiff_Click(object sender, EventArgs e)
        {
            ShowTab(tabOrgDiff);
        }

        private void MISolCompare_Click(object sender, EventArgs e)
        {
            ctrlSolutionCompare.OrganizationTree = Context.OrganizationTree;

            ctrlSolutionCompare.LoadOrgs(Context.CrmOrganizations);

            ShowTab(tabSolCompare);

        }

        private void MISolTransfer_Click(object sender, EventArgs e)
        {
            var frm = new SolutionTransferDlg();

            frm.Context = Context;
            frm.LoadForm();


            frm.Show();
        }

        private void MIOrgSync_Click(object sender, EventArgs e)
        {
            orgSyncControl.Context = Context;
            orgSyncControl.LoadSolutions();

            ShowTab(tabSyncTool);
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
            if (Context.DiffGenerator.LeftService == null || Context.DiffGenerator.RightService == null)
            {
                MessageBox.Show("You need to connect to and select 2 organizations");
                return;
            }
            ShowEntities(Context.DiffGenerator.LeftService);
        }

        public void ShowEntities(IOrganizationService organizationService)
        {
            Dictionary<string, string> attributesData = new Dictionary<string, string>();
            RetrieveAllEntitiesRequest metaDataRequest = new RetrieveAllEntitiesRequest();
            RetrieveAllEntitiesResponse metaDataResponse = new RetrieveAllEntitiesResponse();
            metaDataRequest.EntityFilters = EntityFilters.Entity;

            metaDataResponse = (RetrieveAllEntitiesResponse)organizationService.Execute(metaDataRequest);
            var entities = metaDataResponse.EntityMetadata;

            Context.DiffGenerator.Entities.Clear();
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
                            Context.DiffGenerator.Entities.Add(ei);
                            lvEntities.Items.Add(new ListViewItem()
                            {
                                Text = dn,
                                Tag = ei
                            });

                        }

                        if (!Util.Mapping.ObjectTypeCodeName.ContainsKey(e.LogicalName))
                            Util.Mapping.ObjectTypeCodeName.Add(e.LogicalName, e.ObjectTypeCode.Value);
                    }

                }
            }

        }

        public void DisplayDiffResult()
        {
            entityDiffControl1.Clear();

            foreach (var entityDiff in Context.DiffGenerator.DiffResult.Entities)
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

                    entityDiffControl1.LVManyToManyRelationships.Items.Add(item);

                }


                
            }

            foreach (var fd in Context.DiffGenerator.DiffResult.Forms)
            {
                var left = fd.Left;
                var right = fd.Right;

                var item = new ListViewItem(new string[] {
                        fd.EntityName,
                        fd.Name,
                        left?.GetAttributeValue<string>("name"),
                        left?.GetAttributeValue<OptionSetValue>("type")?.Value.ToString(),
                        right?.GetAttributeValue<string>("name"),
                        right?.GetAttributeValue<OptionSetValue>("type")?.Value.ToString(),
                    });

                entityDiffControl1.LVForms.Items.Add(item);

            }
            foreach (var vd in Context.DiffGenerator.DiffResult.Views)
            {
                var left = vd.Left;
                var right = vd.Right;

                var item = new ListViewItem(new string[] {
                        vd.EntityName,
                        vd.Name,
                        left?.GetAttributeValue<OptionSetValue>("type")?.Value.ToString(),
                        right?.GetAttributeValue<OptionSetValue>("type")?.Value.ToString(),
                    });

                entityDiffControl1.LVViews.Items.Add(item);

            }

            foreach (var wd in Context.DiffGenerator.DiffResult.Workflows)
            {
                var left = wd.Left;
                var right = wd.Right;

                var item = new ListViewItem(new string[] {
                    wd.Name,
                    left?.GetAttributeValue<OptionSetValue>("category").Value.ToString(),
                    right?.GetAttributeValue<OptionSetValue>("category").Value.ToString(),
                });


                entityDiffControl1.LVWorkflows.Items.Add(item);
            }

            foreach (var pd in Context.DiffGenerator.DiffResult.Plugins)
            {
                var left = pd.Left;
                var right = pd.Right;

                var item = new ListViewItem(new string[] {
                    pd.Name,
                    left?.GetAttributeValue<bool>("iswokflowactivity").ToString(),
                    right?.GetAttributeValue<bool>("iswokflowactivity").ToString(),
                });

                entityDiffControl1.LVPlugins.Items.Add(item);
            }


            foreach (var smps in Context.DiffGenerator.DiffResult.SdkMessageProcessingSteps)
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

                entityDiffControl1.LVPlugins.Items.Add(item);
            }

            foreach (var temp in Context.DiffGenerator.DiffResult.Templates)
            {
                var left = temp.Left;
                var right = temp.Right;

                var item = new ListViewItem(new string[] {
                    temp.Name,
                    temp.EntityName,
                    left?.GetAttributeValue<string>("description"),
                    right?.GetAttributeValue<string>("description"),
                });

                entityDiffControl1.LVTemplates.Items.Add(item);
            }
            foreach (var role in Context.DiffGenerator.DiffResult.Roles)
            {
                var left = role.Left;
                var right = role.Right;

                var item = new ListViewItem(new string[] {
                    role.Name,
                    left?.Id.ToString(),
                    right?.Id.ToString(),
                });

                entityDiffControl1.LVRoles.Items.Add(item);
            }

            entityDiffControl1.OptimizeDisplay();

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

        public void ShowTab(TabPage tabPage)
        {
            tabCtrlMain.BringToFront();

            if (!tabCtrlMain.Controls.Contains(tabPage))
                tabCtrlMain.Controls.Add(tabPage);

            tabCtrlMain.SelectTab(tabPage);
        }



        #endregion

        private void MILoadOrganizations_Click(object sender, EventArgs e)
        {
            int count = ConfigurationManager.ConnectionStrings.Count;
            List<KeyValuePair<String, String>> filteredConnectionStrings = new List<KeyValuePair<String, String>>();

            if (!Context.IsOrganizationLoaded)
            {
                for (int a = 0; a < count; a++)
                {
                    var name = ConfigurationManager.ConnectionStrings[a].Name;
                    var connStr = ConfigurationManager.ConnectionStrings[a].ConnectionString;
                    if (isValidConnectionString(connStr))
                    {
                        CrmServiceClient conn = new CrmServiceClient(connStr);
                        var orgService = (IOrganizationService)conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
                        Context.Services.Add(new KeyValuePair<string, IOrganizationService>(name, orgService));

                        var crmOrg = new CrmOrganization()
                        {
                            Name = name,
                            Service = orgService,
                            Type = EnumTypes.TreeNodeType.Organization,
                        };

                        Context.CrmOrganizations.Add(crmOrg);

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

                Context.IsOrganizationLoaded = true;
            }
            else
                RefreshOrganizations();

            tvOrgs.ExpandAll();

            ShowTab(tabDeploymentExplorer);
        }

        private void MIExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MICloseActiveWindow_Click(object sender, EventArgs e)
        {
            tabCtrlMain.Controls.Remove(tabCtrlMain.SelectedTab);
        }

        private void MICloseAllWindows_Click(object sender, EventArgs e)
        {
            tabCtrlMain.Controls.Clear();
        }

        public void ProgressStart(string title, int min, int max)
        {
            statusMessage.Text = title;
            statusProgressBar.Minimum = 1;
            statusProgressBar.Maximum = max == 0 ? 1 : max;
            statusProgressBar.Step = 1;
            statusProgressBar.Value = 1;
        }

        public void ProgressPerformStep()
        {
            statusProgressBar.PerformStep();
        }
    }


}





