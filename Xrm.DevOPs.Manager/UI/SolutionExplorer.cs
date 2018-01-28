using System.Windows.Forms;
using Xrm.DevOPs.Manager.Wrappers;
using Xrm.DevOPs.Manager.UI.Forms;
using Xrm.DevOPs.ComponentModel;
using Xrm.DevOPs.Controls;
using Xrm.DevOPs.Manager.ComponentModel;

namespace Xrm.DevOPs.Manager.UI
{
    class SolutionExplorer
    {

        TabPage container;
        TreeView tree;
        SplitContainer split;
        TabControl pageContainer;
        ImageList imageList;

        public SolutionExplorer(string name, ImageList imageList)
        {
            this.imageList = imageList;
            container = new TabPage();
            container.Location = new System.Drawing.Point(4, 22);
            container.Padding = new System.Windows.Forms.Padding(3);
            container.Size = new System.Drawing.Size(988, 669);
            container.TabIndex = 1;
            container.Text = name;
            container.UseVisualStyleBackColor = true;

            split = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(split)).BeginInit();
            split.Dock = DockStyle.Fill;
            //split.Panel1.SuspendLayout();
            //split.Panel2.SuspendLayout();            

            tree = new TreeView();
            tree.Dock = DockStyle.Fill;
            tree.ImageIndex = 177;
            tree.ImageList = imageList;
            tree.Location = new System.Drawing.Point(0, 0);
            tree.SelectedImageIndex = 0;
            tree.Size = new System.Drawing.Size(225, 663);
            tree.TabIndex = 0;
            tree.AfterSelect += new TreeViewEventHandler(this.TVSolDetail_AfterSelect);

            pageContainer = new TabControl();
            pageContainer.Dock = DockStyle.Fill;
            pageContainer.Location = new System.Drawing.Point(0, 0);
            pageContainer.SelectedIndex = 0;
            pageContainer.Size = new System.Drawing.Size(753, 663);
            pageContainer.TabIndex = 1;
            pageContainer.ImageList = imageList;


            split.Panel1.Controls.Add(tree);
            split.Panel2.Controls.Add(pageContainer);
            container.Controls.Add(split);


        }
        public TabPage Container { get { return container; } }
        public TreeView Tree { get { return tree; } }
        public SplitContainer Split { get { return split; } }

        public TabControl PageContainer { get { return pageContainer; } }

        private void TVSolDetail_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tv = (TreeView)sender;
            var node = tv.SelectedNode;
            if (node.Tag?.ToString() == "Entity")
            {
                var entityNode = (CrmTreeNode<EntityComponent>)node;
                var controls = pageContainer.Controls.Find(entityNode.Name, false);

                if (controls.Length == 0)
                {
                    var entityViewer = new EntityViewer(entityNode.Name, entityNode.Text);
                    pageContainer.Controls.Add(entityViewer.Page);
                    entityViewer.ShowAssets(entityNode);
                }
                pageContainer.SelectTab(entityNode.Name);
            }
            else
            {
                switch (node.Tag?.ToString())
                {
                    case "OptionSets":
                        ShowCollection<OptionSetComponent>(node, "OptionSets", "Option Sets");
                        break;
                    case "WebResources":
                        ShowCollection<WebResourceComponent>(node, "WebResources", "Web Resources");
                        break;
                    case "EmailTemplates":
                        ShowCollection<EmailTemplateComponent>(node, "EmailTemplates", "Email Templates");
                        break;
                    case "ContractTemplates":
                        ShowCollection<ContractTemplateComponent>(node, "ContractTemplates", "Contract Templates");
                        break;
                    case "MailMergeTemplates":
                        ShowCollection<MailMergeTemplateComponent>(node, "MailMergeTemplates", "Mail Merge Templates");
                        break;
                    case "KbArticleTemplates":
                        ShowCollection<KbArticleTemplateComponent>(node, "KbArticleTemplates", "Kb Article Templates");
                        break;

                }
            }

        }

        public void ShowCollection<T>(TreeNode node, string name, string text)
        {
            var optionSetsNode = (CrmTreeNode<T>)node;
            var controls = pageContainer.Controls.Find("Option Sets", false);

            if (controls.Length == 0)
            {
                var compCollectViewer = new ComponentCollectionViewer();
                compCollectViewer.Display(optionSetsNode.Collection);
                pageContainer.Controls.Add(GetNewPage(name, text, compCollectViewer));
            }

            pageContainer.SelectTab(name);
        }

        public TabPage GetNewPage(string name, string text, ComponentCollectionViewer compCollectViewer)
        {
            var _page = new TabPage();
            _page.SuspendLayout();
            _page.Controls.Add(compCollectViewer);
            _page.Location = new System.Drawing.Point(4, 22);
            _page.Padding = new Padding(3);
            _page.Dock = DockStyle.Fill;
            _page.Size = new System.Drawing.Size(745, 637);
            _page.TabIndex = 0;
            _page.Name = name;
            _page.Text = text;
            _page.UseVisualStyleBackColor = true;
            _page.ImageIndex = 100;

            _page.ResumeLayout();

            return _page;

        }
        public void Display(CrmSolution crmSol)
        {
            #region Entities
            var root = new CrmTreeNode<EntityComponent>()
            {
                Component = new CrmComponent() { Text = "Entities" },
                Tag = "Entities",
                ImageIndex = 144
            };
            tree.Nodes.Add(root);
            foreach (var entityComp in crmSol.EntityComponents.Components)
            {
                var entityNode = new CrmTreeNode<EntityComponent>()
                {
                    Component = entityComp,
                    Tag = "Entity",
                    ImageIndex = 144,
                    Name = entityComp.Name
                };
                root.Nodes.Add(entityNode);
            }

            #endregion

            #region Option Sets

            var optionSetRoot = new CrmTreeNode<OptionSetComponent>()
            {
                Component = new CrmComponent() { Text = "Option Sets" },
                Tag = "OptionSets",
                ImageIndex = 144,
                Collection = crmSol.OptionSetComponents
            };
            tree.Nodes.Add(optionSetRoot);
            foreach (var c in crmSol.OptionSetComponents.Components)
            {
                var n = new CrmTreeNode<OptionSetComponent>()
                {
                    Component = c,
                    Tag = "OptionSet",
                    ImageIndex = 144,
                    Name = c.Name
                };
                optionSetRoot.Nodes.Add(n);
            }

            #endregion

            #region Web Resources

            var webResourceRoot = new CrmTreeNode<WebResourceComponent>()
            {
                Component = new CrmComponent() { Text = "Web Resources" },
                Tag = "WebResource",
                ImageIndex = 123,
                Collection = crmSol.WebResourceComponents

            };
            tree.Nodes.Add(webResourceRoot);
            foreach (var c in crmSol.WebResourceComponents.Components)
            {
                var n = new CrmTreeNode<WebResourceComponent>()
                {
                    Component = c,
                    Tag = "WebResource",
                    ImageIndex = 123,
                    Name = c.Name
                };
                webResourceRoot.Nodes.Add(n);
            }

            #endregion

            #region Plugin Assemblies

            var pluginAssemblyComponent = new CrmTreeNode<PluginAssemblyComponent>()
            {
                Component = new CrmComponent() { Text = "Plugin Assemblies" },
                Tag = "PluginAssemblies",
                ImageIndex = 113,

            };
            tree.Nodes.Add(pluginAssemblyComponent);
            foreach (var pa in crmSol.PluginAssemblyComponents.Components)
            {
                var paNode = new CrmTreeNode<PluginAssemblyComponent>()
                {
                    Component = pa,
                    ImageIndex = 113,
                    Name = pa.Name,
                    Collection = crmSol.PluginAssemblyComponents

                };
                pluginAssemblyComponent.Nodes.Add(paNode);
                foreach (var p in pa.PluginTypeComponents)
                {
                    var ptNode = new CrmTreeNode<PluginTypeComponent>() { Component = p };
                    if (!paNode.Nodes.Contains(ptNode))
                        paNode.Nodes.Add(ptNode);
                }
            }

            #endregion

            #region Workflows

            var workflowRoot = new CrmTreeNode<WorkflowComponent>()
            {
                Component = new CrmComponent() { Text = "Workflows" },
                Tag = "Workflows",
                ImageIndex = 116,
                Collection = crmSol.WorkflowComponents
            };
            tree.Nodes.Add(workflowRoot);
            foreach (var c in crmSol.WorkflowComponents.Components)
            {
                var n = new CrmTreeNode<WorkflowComponent>()
                {
                    Component = c,
                    Tag = "Workflow",
                    ImageIndex = 116,
                    Name = c.Name
                };
                workflowRoot.Nodes.Add(n);
            }

            #endregion

            #region Security Roles

            var roleRoot = new CrmTreeNode<RoleComponent>()
            {
                Component = new CrmComponent() { Text = "Security Roles" },
                Tag = "SecurityRoles",
                ImageIndex = 43,
                Collection = crmSol.RoleComponents
            };
            tree.Nodes.Add(roleRoot);
            foreach (var c in crmSol.RoleComponents.Components)
            {
                var n = new CrmTreeNode<RoleComponent>()
                {
                    Component = c,
                    Tag = "Security Roles",
                    ImageIndex = 43,
                    Name = c.Name
                };
                roleRoot.Nodes.Add(n);
            }

            #endregion

            #region Routing Rule Sets

            var routingRuleRoot = new CrmTreeNode<RoutingRuleComponent>()
            {
                Component = new CrmComponent() { Text = "Routing Rule Sets" },
                Tag = "RoutingRuleSets",
                ImageIndex = 120,
                Collection = crmSol.RoutingRuleComponents
            };
            tree.Nodes.Add(routingRuleRoot);
            foreach (var c in crmSol.RoutingRuleComponents.Components)
            {
                var n = new CrmTreeNode<RoutingRuleComponent>()
                {
                    Component = c,
                    Tag = "RoutingRuleSet",
                    ImageIndex = 120,
                    Name = c.Name
                };
                routingRuleRoot.Nodes.Add(n);
            }

            #endregion

            #region Article Templates

            var articleTemplateRoot = new CrmTreeNode<KbArticleTemplateComponent>()
            {
                Component = new CrmComponent() { Text = "Kb Article Templates" },
                Tag = "KbArticleTemplates",
                ImageIndex = 34,
                Collection = crmSol.KbArticleTemplateComponents
            };
            tree.Nodes.Add(articleTemplateRoot);
            foreach (var c in crmSol.KbArticleTemplateComponents.Components)
            {
                var n = new CrmTreeNode<KbArticleTemplateComponent>()
                {
                    Component = c,
                    Tag = "KbArticleTemplate",
                    ImageIndex = 34,
                    Name = c.Name
                };
                articleTemplateRoot.Nodes.Add(n);
            }

            #endregion

            #region Contract Templates

            var contractTemplateRoot = new CrmTreeNode<ContractTemplateComponent>()
            {
                Component = new CrmComponent() { Text = "Contract Templates" },
                Tag = "ContractTemplates",
                ImageIndex = 78,
                Collection = crmSol.ContractTemplateComponents
            };
            tree.Nodes.Add(contractTemplateRoot);
            foreach (var c in crmSol.ContractTemplateComponents.Components)
            {
                var n = new CrmTreeNode<ContractTemplateComponent>()
                {
                    Component = c,
                    Tag = "ContractTemplate",
                    ImageIndex = 78,
                    Name = c.Name
                };
                contractTemplateRoot.Nodes.Add(n);
            }

            #endregion

            #region Email Templates

            var emailTemplateRoot = new CrmTreeNode<EmailTemplateComponent>()
            {
                Component = new CrmComponent() { Text = "Email Templates" },
                Tag = "EmailTemplates",
                ImageIndex = 77,
                Collection = crmSol.EmailTemplateComponents
            };
            tree.Nodes.Add(emailTemplateRoot);
            foreach (var c in crmSol.EmailTemplateComponents.Components)
            {
                var n = new CrmTreeNode<EmailTemplateComponent>()
                {
                    Component = c,
                    Tag = "Email Templates",
                    ImageIndex = 77,
                    Name = c.Name
                };
                emailTemplateRoot.Nodes.Add(n);
            }

            #endregion

            #region Mail Merge Templates

            var mailMergeRoot = new CrmTreeNode<MailMergeTemplateComponent>()
            {
                Component = new CrmComponent() { Text = "Mail Merge Templates" },
                Tag = "MailMergeTemplates",
                ImageIndex = 125,
                Collection = crmSol.MailMergeTemplateComponents
            };
            tree.Nodes.Add(mailMergeRoot);
            foreach (var c in crmSol.MailMergeTemplateComponents.Components)
            {
                var n = new CrmTreeNode<MailMergeTemplateComponent>()
                {
                    Component = c,
                    Tag = "MailMergeTemplate",
                    ImageIndex = 125,
                    Name = c.Name
                };
                mailMergeRoot.Nodes.Add(n);
            }

            #endregion

            container.Name = crmSol.UniqueName;
        }



    }
}
