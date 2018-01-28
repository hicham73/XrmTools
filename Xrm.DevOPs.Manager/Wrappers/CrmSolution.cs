using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Linq;
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
        public CrmComponentCollection<CrmSolution> ChildSolutions { get; set; } = new CrmComponentCollection<CrmSolution>();
        public CrmComponentCollection<EntityComponent> EntityComponents { get; set; } = new CrmComponentCollection<EntityComponent>();
        public CrmComponentCollection<PluginAssemblyComponent> PluginAssemblyComponents { get; set; } = new CrmComponentCollection<PluginAssemblyComponent>();
        public CrmComponentCollection<WorkflowComponent> WorkflowComponents { get; set; } = new CrmComponentCollection<WorkflowComponent>();
        public CrmComponentCollection<WebResourceComponent> WebResourceComponents { get; set; } = new CrmComponentCollection<WebResourceComponent>();
        public CrmComponentCollection<RoleComponent> RoleComponents { get; set; } = new CrmComponentCollection<RoleComponent>();
        public CrmComponentCollection<RoutingRuleComponent> RoutingRuleComponents { get; set; } = new CrmComponentCollection<RoutingRuleComponent>();
        public CrmComponentCollection<EmailTemplateComponent> EmailTemplateComponents { get; set; } = new CrmComponentCollection<EmailTemplateComponent>();
        public CrmComponentCollection<KbArticleTemplateComponent> KbArticleTemplateComponents { get; set; } = new CrmComponentCollection<KbArticleTemplateComponent>();
        public CrmComponentCollection<MailMergeTemplateComponent> MailMergeTemplateComponents { get; set; } = new CrmComponentCollection<MailMergeTemplateComponent>();
        public CrmComponentCollection<ContractTemplateComponent> ContractTemplateComponents { get; set; } = new CrmComponentCollection<ContractTemplateComponent>();
        public CrmComponentCollection<OptionSetComponent> OptionSetComponents { get; set; } = new CrmComponentCollection<OptionSetComponent>();


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
                    var e = service.Retrieve("workflow", component.ObjectId, new ColumnSet(true));
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
                    RoleComponents.Components.Add(new RoleComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.RoutingRule)
                {
                    var e = service.Retrieve("routingrule", component.ObjectId, new ColumnSet(true));
                    RoutingRuleComponents.Components.Add(new RoutingRuleComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.EmailTemplate)
                {
                    var e = service.Retrieve("template", component.ObjectId, new ColumnSet("title","description"));
                    EmailTemplateComponents.Components.Add(new EmailTemplateComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.MailMergeTemplate)
                {
                    var e = service.Retrieve("mailmergetemplate", component.ObjectId, new ColumnSet("name", "description"));
                    MailMergeTemplateComponents.Components.Add(new MailMergeTemplateComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.KBArticleTemplate)
                {
                    var e = service.Retrieve("kbarticletemplate", component.ObjectId, new ColumnSet("title", "description"));
                    KbArticleTemplateComponents.Components.Add(new KbArticleTemplateComponent(component, e));
                }
                else if (component.ComponentType == ComponentType.ContractTemplate)
                {
                    var e = service.Retrieve("contracttemplate", component.ObjectId, new ColumnSet("name", "description"));
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
