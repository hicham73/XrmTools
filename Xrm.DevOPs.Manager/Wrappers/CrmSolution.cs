using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Xrm.DevOPs.ComponentModel;
using Xrm.DevOPs.Manager.Helpers;
using Xrm.DevOPs.Manager.Util;
using static Xrm.DevOPs.ComponentModel.EnumTypes;

namespace Xrm.DevOPs.Manager.Wrappers
{
    public class CrmSolution : CrmComponent
    {

        #region Properties

        public List<CrmComponent> Components { get; set; }
        public CrmComponentCollection<CrmSolution> ChildSolutions { get; set; } = new CrmComponentCollection<CrmSolution>(new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("Name","Name")
        });
        public CrmComponentCollection<EntityComponent> EntityComponents { get; set; } = new CrmComponentCollection<EntityComponent>(new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("DisplayName","Display Name"),
            new KeyValuePair<string, string>("Name","Name"),
            new KeyValuePair<string, string>("IsManaged","State"),
            new KeyValuePair<string, string>("IsCustomizable","Customizable"),

        });
        public CrmComponentCollection<OptionSetComponent> OptionSetComponents { get; set; } = new CrmComponentCollection<OptionSetComponent>(new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("DisplayName","Display Name"),
            new KeyValuePair<string, string>("Name","Name"),
            new KeyValuePair<string, string>("Description","Description"),
            new KeyValuePair<string, string>("IsManaged","State"),
            new KeyValuePair<string, string>("IsCustomizable","Customizable"),
        });
        public CrmComponentCollection<PluginAssemblyComponent> PluginAssemblyComponents { get; set; } = new CrmComponentCollection<PluginAssemblyComponent>(new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("DisplayName","Display Name"),
            new KeyValuePair<string, string>("Name","Name"),
            new KeyValuePair<string, string>("IsManaged","State"),
            new KeyValuePair<string, string>("IsCustomizable","Customizable"),
        });
        public CrmComponentCollection<WorkflowComponent> WorkflowComponents { get; set; } = new CrmComponentCollection<WorkflowComponent>(new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("Name","Name"),
            new KeyValuePair<string, string>("Uniquename","Unique Name"),
            new KeyValuePair<string, string>("CategoryValue","Category"),
            new KeyValuePair<string, string>("Description","Description"),
            new KeyValuePair<string, string>("InputParameters","Input Parameters"),
            new KeyValuePair<string, string>("AsyncAutoDelete","Async Auto Delete"),
            new KeyValuePair<string, string>("SubProcess","Sub Process"),
            new KeyValuePair<string, string>("BusinessProcessTypeValue","Business Process Type"),
        });
        public CrmComponentCollection<WebResourceComponent> WebResourceComponents { get; set; } = new CrmComponentCollection<WebResourceComponent>(new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("DisplayName","Display Name"),
            new KeyValuePair<string, string>("Name","Name"),
            new KeyValuePair<string, string>("IsManaged","State"),
            new KeyValuePair<string, string>("IsCustomizable","Customizable"),
        });
        public CrmComponentCollection<SecurityRoleComponent> SecurityRoleComponents { get; set; } = new CrmComponentCollection<SecurityRoleComponent>(new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("DisplayName","Display Name"),
            new KeyValuePair<string, string>("Name","Name"),
            new KeyValuePair<string, string>("IsManaged","State"),
            new KeyValuePair<string, string>("IsCustomizable","Customizable"),
        });
        public CrmComponentCollection<RoutingRuleComponent> RoutingRuleComponents { get; set; } = new CrmComponentCollection<RoutingRuleComponent>(new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("DisplayName","Display Name"),
            new KeyValuePair<string, string>("Name","Name"),
            new KeyValuePair<string, string>("IsManaged","State"),
            new KeyValuePair<string, string>("IsCustomizable","Customizable"),
        });
        public CrmComponentCollection<EmailTemplateComponent> EmailTemplateComponents { get; set; } = new CrmComponentCollection<EmailTemplateComponent>(new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("DisplayName","Display Name"),
            new KeyValuePair<string, string>("Name","Name"),
            new KeyValuePair<string, string>("IsManaged","State"),
            new KeyValuePair<string, string>("IsCustomizable","Customizable"),
        });
        public CrmComponentCollection<KbArticleTemplateComponent> KbArticleTemplateComponents { get; set; } = new CrmComponentCollection<KbArticleTemplateComponent>(new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("DisplayName","Display Name"),
            new KeyValuePair<string, string>("Name","Name"),
            new KeyValuePair<string, string>("Description","Description"),
            new KeyValuePair<string, string>("IsManaged","State"),
            new KeyValuePair<string, string>("IsCustomizable","Customizable"),
        });
        public CrmComponentCollection<MailMergeTemplateComponent> MailMergeTemplateComponents { get; set; } = new CrmComponentCollection<MailMergeTemplateComponent>(new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("DisplayName","Display Name"),
            new KeyValuePair<string, string>("Name","Name"),
            new KeyValuePair<string, string>("Description","Description"),
            new KeyValuePair<string, string>("IsManaged","State"),
            new KeyValuePair<string, string>("IsCustomizable","Customizable"),
        });
        public CrmComponentCollection<ContractTemplateComponent> ContractTemplateComponents { get; set; } = new CrmComponentCollection<ContractTemplateComponent>(new List<KeyValuePair<string, string>>() {
            new KeyValuePair<string, string>("DisplayName","Display Name"),
            new KeyValuePair<string, string>("Name","Name"),
            new KeyValuePair<string, string>("IsManaged","State"),
            new KeyValuePair<string, string>("IsCustomizable","Customizable"),
            new KeyValuePair<string, string>("Description","Description"),
        });



        public string UniqueName { get; set; }
        public string FriendlyName { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string NameVersion
        {
            get { return $"{this.FriendlyName} - {this.Version}"; }
        }
        public string Path { get; set; }
        public bool IsParent { get; set; }

        public EntityReference ParentSolutionId { get; set; }

        public CrmOrganization Organization { get; set; }

        public TreeNodeType Type { get; set; }

        public bool IsLoaded { get; internal set; } = false;
        public TreeView Tree { get; internal set; }

        #endregion

        #region Methods
        internal void LoadMeta(IOrganizationService service)
        {

            if (!IsLoaded)
            {
                Components = SolutionHelper.RetrieveComponentsFromSolution(this, service);
                LoadFromComponents(Components, service);
            }
            IsLoaded = true;
        }
        internal void AddEntity(EntityComponent entityComp)
        {
            EntityComponents.Components.Add(entityComp);
        }

        public void AddAttribute(CrmComponent component, CrmComponent rootComponent)
        {
            if (rootComponent != null)
            {
                var entityComp = EntityComponents.Components.Where(x => x.MetadataId.Contains(rootComponent.ObjectId.ToString())).FirstOrDefault<EntityComponent>();
                if (entityComp != null)
                {
                    var amd = entityComp.Meta.Attributes.Where(x => x.MetadataId == component.ObjectId).FirstOrDefault<AttributeMetadata>();

                    entityComp.Attributes.Add(new AttributeComponent(amd));

                }
            }


        }

        internal void AddManyToOneRelationship(CrmComponent component, CrmComponent rootComponent)
        {
            if (rootComponent != null)
            {
                var entityComp = EntityComponents.Components.Where(x => x.MetadataId.Contains(rootComponent.ObjectId.ToString())).FirstOrDefault<EntityComponent>();

                if (entityComp != null)
                {
                    var otmr = entityComp.Meta.ManyToOneRelationships.Where(x => x.MetadataId == component.ObjectId).FirstOrDefault<OneToManyRelationshipMetadata>();

                    if (otmr != null)
                    {
                        entityComp.ManyToOneRelashionships.Add(new OneToManyRelationshipComponent(otmr));

                        var primaryEntity = EntityComponents.Components.Where(x => x.LogicalName == otmr.ReferencedEntity).FirstOrDefault<EntityComponent>();

                        if (primaryEntity != null)
                            primaryEntity.OneToManyRelashionships.Add(new OneToManyRelationshipComponent(otmr));
                    }

                }
            }
        }

        internal void AddManyToManyRelationship(CrmComponent component, CrmComponent rootComponent)
        {
            if (rootComponent != null)
            {
                var entityComp = EntityComponents.Components.Where(x => x.MetadataId.Contains(rootComponent.ObjectId.ToString())).FirstOrDefault<EntityComponent>();

                if (entityComp != null)
                {
                    var mtmr = entityComp.Meta.ManyToManyRelationships.Where(x => x.MetadataId == component.ObjectId).FirstOrDefault<ManyToManyRelationshipMetadata>();

                    if (mtmr != null)
                        entityComp.ManyToManyRelationships.Add(new ManyToManyRelationshipComponent(mtmr));

                }
            }
        }

        public void LoadFromComponents(List<CrmComponent> components, IOrganizationService service)
        {
            foreach (var component in components)
            {
                if (component.ComponentType == ComponentType.Entity)
                {
                    RetrieveEntityRequest request = new RetrieveEntityRequest
                    {
                        EntityFilters = EntityFilters.All,
                        MetadataId = component.ObjectId
                    };

                    RetrieveEntityResponse response = (RetrieveEntityResponse)service.Execute(request);
                    AddEntity(new EntityComponent(component, response.EntityMetadata));
                }
                else if (component.ComponentType == ComponentType.PluginAssembly)
                {
                    var e = service.Retrieve("pluginassembly", component.ObjectId, new ColumnSet(true));

                    var name = e.GetAttributeValue<string>("name");

                    var paComp = new PluginAssemblyComponent(component, e);

                    var qe = new QueryByAttribute("plugintype");
                    qe.ColumnSet = new ColumnSet(true);
                    qe.AddAttributeValue("pluginassemblyid", e.Id);

                    var pts = service.RetrieveMultiple(qe).Entities;

                    var ns = $"{name}.";
                    foreach (var pt in pts)
                    {
                        var typeName = pt.GetAttributeValue<string>("typename")?.Replace(ns, "");

                        paComp.PluginTypeComponents.Add(new PluginTypeComponent(component, pt));
                    }

                    AddAssembly(paComp);

                }
                else if (component.ComponentType == ComponentType.SDKMessageProcessingStep)
                {
                    var e = service.Retrieve("sdkmessageprocessingstep", component.ObjectId, new ColumnSet(true));
                    var name = e.GetAttributeValue<string>("name");
                }
                else if (component.ComponentType == ComponentType.Workflow)
                {
                    var e = service.Retrieve("workflow", component.ObjectId, new ColumnSet("asyncautodelete", "uniquename", "subprocess", "description", "inputparameters", "name", "businessprocesstype", "category"));
                    var name = e.GetAttributeValue<string>("name");
                    WorkflowComponents.Components.Add(new WorkflowComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.WebResource)
                {
                    var e = service.Retrieve("webresource", component.ObjectId, new ColumnSet(true));
                    var name = e.GetAttributeValue<string>("name");
                    WebResourceComponents.Components.Add(new WebResourceComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.Role)
                {
                    var e = service.Retrieve("role", component.ObjectId, new ColumnSet(true));
                    var name = e.GetAttributeValue<string>("name");
                    SecurityRoleComponents.Components.Add(new SecurityRoleComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.RoutingRule)
                {
                    var e = service.Retrieve("routingrule", component.ObjectId, new ColumnSet(true));
                    RoutingRuleComponents.Components.Add(new RoutingRuleComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.EmailTemplate)
                {
                    var e = service.Retrieve("template", component.ObjectId, new ColumnSet("title","description", "iscustomizable", "componentstate", "modifiedby", "createdby", "ismanaged", "modifiedon"));
                    EmailTemplateComponents.Components.Add(new EmailTemplateComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.MailMergeTemplate)
                {
                    var e = service.Retrieve("mailmergetemplate", component.ObjectId, new ColumnSet("name", "description", "iscustomizable", "componentstate", "modifiedby", "createdby", "ismanaged", "modifiedon"));
                    MailMergeTemplateComponents.Components.Add(new MailMergeTemplateComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.KBArticleTemplate)
                {
                    var e = service.Retrieve("kbarticletemplate", component.ObjectId, new ColumnSet("title", "description", "iscustomizable", "componentstate", "modifiedby", "createdby", "ismanaged", "modifiedon"));
                    KbArticleTemplateComponents.Components.Add(new KbArticleTemplateComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.ContractTemplate)
                {
                    var e = service.Retrieve("contracttemplate", component.ObjectId, new ColumnSet("name", "description", "iscustomizable", "componentstate", "modifiedby", "createdby", "ismanaged", "modifiedon"));
                    ContractTemplateComponents.Components.Add(new ContractTemplateComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.OptionSet)
                {

                    var optionSetMetabase = Organization.OptionSets.Where(x => x.MetadataId == component.ObjectId).FirstOrDefault<OptionSetMetadataBase>();

                    if(optionSetMetabase != null)
                        OptionSetComponents.Components.Add(new OptionSetComponent(component, optionSetMetabase));
                }
            }

            foreach (var component in components)
            {

                if (component.ComponentType == ComponentType.Attribute)
                {
                    var rootComponent = components.Where(x => x.Id == component.RootSolutionComponentId).FirstOrDefault<CrmComponent>();
                    AddAttribute(component, rootComponent);

                }
                else if (component.ComponentType == ComponentType.EntityRelationship)
                {
                    var rootComponent = components.Where(x => x.Id == component.RootSolutionComponentId).FirstOrDefault<CrmComponent>();
                    AddManyToOneRelationship(component, rootComponent);
                    AddManyToManyRelationship(component, rootComponent);

                }

            }

        }

        private void AddAssembly(PluginAssemblyComponent comp)
        {
            PluginAssemblyComponents.Components.Add(comp);
        }

        #endregion
    }
}
