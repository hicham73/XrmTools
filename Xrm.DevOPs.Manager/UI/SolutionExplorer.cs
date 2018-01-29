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
            tree.TabIndex = 0;
            tree.AfterSelect += new TreeViewEventHandler(this.TVSolDetail_AfterSelect);

            pageContainer = new TabControl();
            pageContainer.Dock = DockStyle.Fill;
            pageContainer.Location = new System.Drawing.Point(0, 0);
            pageContainer.SelectedIndex = 0;
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
                    case "Workflows":
                        ShowCollection<WorkflowComponent>(node, "Workflows", "Workflows");
                        break;
                    case "PluginAssemblies":
                        ShowCollection<PluginAssemblyComponent>(node, "PluginAssemblies", "Plugin Assemblies");
                        break;
                    case "SecurityRoles":
                        ShowCollection<SecurityRoleComponent>(node, "SecurityRoles", "Security Roles");
                        break;
                    case "RoutingRuleSets":
                        ShowCollection<RoutingRuleComponent>(node, "RoutingRuleSets", "Routing Rule Sets");
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

        public void ShowCollection<T>(TreeNode node, string name, string text) where T: CrmComponent
        {
            var componentNode = (CrmTreeNode<T>)node;
            var controls = pageContainer.Controls.Find(name, false);

            if (controls.Length == 0)
            {
                var compCollectViewer = new ComponentCollectionViewer();
                compCollectViewer.Display(componentNode.Collection);
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

        public void AddRootNode<T>(CrmSolution crmSol, string itemName, string collectionName, string displayName, CrmComponentCollection<T> collection, int imgIdx) where T:CrmComponent
        {

            var rootNode = new CrmTreeNode<T>()
            {
                Component = new CrmComponent() { Text = displayName },
                Tag = collectionName,
                ImageIndex = imgIdx,
                Collection = collection
            };
            tree.Nodes.Add(rootNode);
            foreach (var c in collection.Components)
            {
                var d = (CrmComponent)c;
                var n = new CrmTreeNode<T>()
                {
                    Component = c,
                    Tag = itemName,
                    ImageIndex = imgIdx,
                    Name = c.Name
                };
                rootNode.Nodes.Add(n);
            }
        }

        public void Display(CrmSolution crmSol)
        {
            container.Name = crmSol.UniqueName;

            AddRootNode(crmSol, "Entity", "Entities", "Entities", crmSol.EntityComponents, 144);
            AddRootNode(crmSol, "OptionSet", "OptionSets", "Option Sets", crmSol.OptionSetComponents, 144);
            AddRootNode(crmSol, "WebResource", "WebResources", "Web Resources", crmSol.WebResourceComponents, 123);
            AddRootNode(crmSol, "PluginAssemblie", "PluginAssemblies", "Plugin Assemblies", crmSol.PluginAssemblyComponents, 113);
            AddRootNode(crmSol, "Workflow", "Workflows", "Workflows", crmSol.WorkflowComponents, 116);
            AddRootNode(crmSol, "SecurityRole", "SecurityRoles", "Security Roles", crmSol.SecurityRoleComponents, 46);
            AddRootNode(crmSol, "RoutingRuleSet", "RoutingRuleSets", "Routing Rule Sets", crmSol.RoutingRuleComponents, 120);
            AddRootNode(crmSol, "KbArticleTemplate", "KbArticleTemplates", "Kb Article Templates", crmSol.KbArticleTemplateComponents, 34);
            AddRootNode(crmSol, "ContractTemplate", "ContractTemplates", "Contract Templates", crmSol.ContractTemplateComponents, 78);
            AddRootNode(crmSol, "EmailTemplate", "EmailTemplates", "Email Templates", crmSol.EmailTemplateComponents, 77);
            AddRootNode(crmSol, "MailMergeTemplate", "MailMergeTemplates", "MailMerge Templates", crmSol.MailMergeTemplateComponents, 125);

        }



    }
}
