using System.Windows.Forms;
using Xrm.DevOPs.Manager.Wrappers;

using Xrm.DevOPs.Manager.UI.Forms;
using Xrm.DevOPs.ComponentModel;

namespace Xrm.DevOPs.Manager.UI
{
    class SolutionExplorer
    {

        TabPage container;
        TreeView tree;
        SplitContainer split;
        TabControl pageContainer;
        ImageList imageList;

        PropertiesForm propertiesForm;

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

        public TabControl PageContainer { get { return pageContainer; }  }

        private void TVSolDetail_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tv = (TreeView)sender;
            var node = tv.SelectedNode;
            if (node.Tag?.ToString() == "Entity")
            {
                var entityNode = (CrmTreeNode)node;

                var controls = pageContainer.Controls.Find(entityNode.Name, false);

                if (controls.Length == 0)
                {
                    var entityViewer = new EntityViewer(entityNode.Name, entityNode.Text);
                    pageContainer.Controls.Add(entityViewer.Page);
                    entityViewer.ShowAssets(entityNode);
                }
                pageContainer.SelectTab(entityNode.Name);
            }
            else if (node.Tag?.ToString() == "OptionSet")
            {
                if(propertiesForm == null)
                    propertiesForm = new PropertiesForm();
                var optionSetNode = (CrmTreeNode)node;

                var optionSetComponent = (OptionSetComponent)optionSetNode.Component;


                //propertiesForm.SetPropertGrid(optionSetComponent);
                //propertiesForm.Show();
            }
        }

        public void Display(CrmSolution crmSol)
        {
            #region Entities
            var root = new CrmTreeNode()
                {
                    Component = new CrmComponent() { Text = "Entities" },
                    Tag = "Entities",
                    ImageIndex = 144
                };
                tree.Nodes.Add(root);
                foreach (var entityComp in crmSol.EntityComponents)
                {
                    var entityNode = new CrmTreeNode()
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

            root = new CrmTreeNode()
            {
                Component = new CrmComponent() { Text = "Option Sets" },
                Tag = "Option Sets",
                ImageIndex = 144
            };
            tree.Nodes.Add(root);
            foreach (var c in crmSol.OptionSetComponents)
            {
                var n = new CrmTreeNode()
                {
                    Component = c,
                    Tag = "OptionSet",
                    ImageIndex = 144,
                    Name = c.Name
                };
                root.Nodes.Add(n);
            }

            #endregion

            #region Web Resources

            root = new CrmTreeNode()
            {
                Component = new CrmComponent() { Text = "Web Resources" },
                Tag = "Web Resources",
                ImageIndex = 123
            };
            tree.Nodes.Add(root);
            foreach (var c in crmSol.WebResourceComponents)
            {
                var n = new CrmTreeNode()
                {
                    Component = c,
                    Tag = "WebResource",
                    ImageIndex = 123,
                    Name = c.Name
                };
                root.Nodes.Add(n);
            }

            #endregion

            #region Plugin Assemblies

            root = new CrmTreeNode()
                {
                    Component = new CrmComponent() { Text = "Plugin Assemblies" },
                    Tag = "Plugin Assemblies",
                    ImageIndex = 113,
                    
                };
                tree.Nodes.Add(root);
                foreach (var pa in crmSol.PluginAssemblyComponents)
                {
                    var paNode = new CrmTreeNode()
                    {
                        Component = pa,
                        ImageIndex = 113,
                        Name = pa.Name
                    };
                    root.Nodes.Add(paNode);
                    foreach (var p in pa.PluginTypeComponents)
                    {
                        var ptNode = new CrmTreeNode() { Component = p };
                        if (!paNode.Nodes.Contains(ptNode))
                            paNode.Nodes.Add(ptNode);
                    }
                }

            #endregion

            #region Workflows

            root = new CrmTreeNode()
                {
                    Component = new CrmComponent() { Text = "Workflows" },
                    Tag = "Workflows",
                    ImageIndex = 116
                };
                tree.Nodes.Add(root);
                foreach (var c in crmSol.WorkflowComponents)
                {
                    var n = new CrmTreeNode()
                    {
                        Component = c,
                        Tag = "Workflow",
                        ImageIndex = 116,
                        Name = c.Name
                    };
                    root.Nodes.Add(n);
                }

            #endregion

            #region Security Roles

            root = new CrmTreeNode()
            {
                Component = new CrmComponent() { Text = "Security Roles" },
                Tag = "Security Roles",
                ImageIndex = 43
            };
            tree.Nodes.Add(root);
            foreach (var c in crmSol.Roles)
            {
                var n = new CrmTreeNode()
                {
                    Component = c,
                    Tag = "Security Roles",
                    ImageIndex = 43,
                    Name = c.Name
                };
                root.Nodes.Add(n);
            }

            #endregion

            #region Routing Rule Sets

            root = new CrmTreeNode()
            {
                Component = new CrmComponent() { Text = "Routing Rule Sets" },
                Tag = "Routing Rule Sets",
                ImageIndex = 120
            };
            tree.Nodes.Add(root);
            foreach (var c in crmSol.RoutingRuleComponents)
            {
                var n = new CrmTreeNode()
                {
                    Component = c,
                    Tag = "RoutingRuleSet",
                    ImageIndex = 120,
                    Name = c.Name
                };
                root.Nodes.Add(n);
            }

            #endregion

            #region Article Templates

            root = new CrmTreeNode()
            {
                Component = new CrmComponent() { Text = "Article Templates" },
                Tag = "ArticleTemplates",
                ImageIndex = 34
            };
            tree.Nodes.Add(root);
            foreach (var c in crmSol.KbArticleTemplateComponents)
            {
                var n = new CrmTreeNode()
                {
                    Component = c,
                    Tag = "ArticleTemplate",
                    ImageIndex = 34,
                    Name = c.Name
                };
                root.Nodes.Add(n);
            }

            #endregion

            #region Contract Templates

            root = new CrmTreeNode()
            {
                Component = new CrmComponent() { Text = "Contract Templates" },
                Tag = "Contract Templates",
                ImageIndex = 78
            };
            tree.Nodes.Add(root);
            foreach (var c in crmSol.ContractTemplateComponents)
            {
                var n = new CrmTreeNode()
                {
                    Component = c,
                    Tag = "ContractTemplate",
                    ImageIndex = 78,
                    Name = c.Name
                };
                root.Nodes.Add(n);
            }

            #endregion

            #region Email Templates

            root = new CrmTreeNode()
            {
                Component = new CrmComponent() { Text = "Email Templates" },
                Tag = "EmailTemplates",
                ImageIndex = 77
            };
            tree.Nodes.Add(root);
            foreach (var c in crmSol.EmailTemplateComponents)
            {
                var n = new CrmTreeNode()
                {
                    Component = c,
                    Tag = "EmailTemplate",
                    ImageIndex = 77,
                    Name = c.Name
                };
                root.Nodes.Add(n);
            }

            #endregion

            #region Mail Merge Templates

            root = new CrmTreeNode()
            {
                Component = new CrmComponent() { Text = "Mail Merge Templates" },
                Tag = "MailMergeTemplate",
                ImageIndex = 125
            };
            tree.Nodes.Add(root);
            foreach (var c in crmSol.MailMergeTemplateComponents)
            {
                var n = new CrmTreeNode()
                {
                    Component = c,
                    Tag = "MailMergeTemplate",
                    ImageIndex = 125,
                    Name = c.Name
                };
                root.Nodes.Add(n);
            }

            #endregion


            container.Name = crmSol.UniqueName;

        }



    }
}
