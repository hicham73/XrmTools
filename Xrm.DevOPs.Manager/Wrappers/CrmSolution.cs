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
        public List<CrmSolution> ChildSolutions { get; set; } = new List<CrmSolution>();
        public List<EntityComponent> EntityComponents { get; set; } = new List<EntityComponent>();
        public List<PluginAssemblyComponent> PluginAssemblyComponents { get; set; } = new List<PluginAssemblyComponent>();
        public List<WorkflowComponent> WorkflowComponents { get; set; } = new List<WorkflowComponent>();
        public List<WebResourceComponent> WebResourceComponents { get; set; } = new List<WebResourceComponent>();
        public List<RoleComponent> Roles { get; set; } = new List<RoleComponent>();
        public List<RoutingRuleComponent> RoutingRuleComponents { get; set; } = new List<RoutingRuleComponent>();
        public List<EmailTemplateComponent> EmailTemplateComponents { get; set; } = new List<EmailTemplateComponent>();
        public List<KbArticleTemplateComponent> KbArticleTemplateComponents { get; set; } = new List<KbArticleTemplateComponent>();
        public List<MailMergeTemplateComponent> MailMergeTemplateComponents { get; set; } = new List<MailMergeTemplateComponent>();
        public List<ContractTemplateComponent> ContractTemplateComponents { get; set; } = new List<ContractTemplateComponent>();
        public List<OptionSetComponent> OptionSetComponents { get; set; } = new List<OptionSetComponent>();


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
            EntityComponents.Add(entityComp);
        }

        public void AddAttribute(CrmComponent component, CrmComponent rootComponent)
        {
            if (rootComponent != null)
            {
                var entityComp = EntityComponents.Where(x => x.MetadataId.Contains(rootComponent.ObjectId.ToString())).FirstOrDefault<EntityComponent>();
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
                var entityComp = EntityComponents.Where(x => x.MetadataId.Contains(rootComponent.ObjectId.ToString())).FirstOrDefault<EntityComponent>();

                if (entityComp != null)
                {
                    var otmr = entityComp.Meta.ManyToOneRelationships.Where(x => x.MetadataId == component.ObjectId).FirstOrDefault<OneToManyRelationshipMetadata>();

                    if (otmr != null)
                    {
                        entityComp.ManyToOneRelashionships.Add(new OneToManyRelationshipComponent(otmr));

                        var primaryEntity = EntityComponents.Where(x => x.LogicalName == otmr.ReferencedEntity).FirstOrDefault<EntityComponent>();

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
                var entityComp = EntityComponents.Where(x => x.MetadataId.Contains(rootComponent.ObjectId.ToString())).FirstOrDefault<EntityComponent>();

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
                if (component.ComponentType == EnumTypes.ComponentType.Entity)
                {
                    RetrieveEntityRequest request = new RetrieveEntityRequest
                    {
                        EntityFilters = EntityFilters.All,
                        MetadataId = component.ObjectId
                    };

                    RetrieveEntityResponse response = (RetrieveEntityResponse)service.Execute(request);
                    AddEntity(new EntityComponent(component, response.EntityMetadata));
                }
                else if (component.ComponentType == EnumTypes.ComponentType.PluginAssembly)
                {
                    var e = service.Retrieve("pluginassembly", component.ObjectId, new ColumnSet(true));

                    var name = e.GetAttributeValue<string>("name");

                    var paComp = new PluginAssemblyComponent(e);

                    var qe = new QueryByAttribute("plugintype");
                    qe.ColumnSet = new ColumnSet(true);
                    qe.AddAttributeValue("pluginassemblyid", e.Id);

                    var pts = service.RetrieveMultiple(qe).Entities;

                    var ns = $"{name}.";
                    foreach (var pt in pts)
                    {
                        var typeName = pt.GetAttributeValue<string>("typename")?.Replace(ns, "");

                        paComp.PluginTypeComponents.Add(new PluginTypeComponent(pt));
                    }

                    AddAssembly(paComp);

                }
                else if (component.ComponentType == EnumTypes.ComponentType.SDKMessageProcessingStep)
                {
                    var e = service.Retrieve("sdkmessageprocessingstep", component.ObjectId, new ColumnSet(true));
                    var name = e.GetAttributeValue<string>("name");
                }
                else if (component.ComponentType == EnumTypes.ComponentType.Workflow)
                {
                    var e = service.Retrieve("workflow", component.ObjectId, new ColumnSet(true));
                    var name = e.GetAttributeValue<string>("name");
                    WorkflowComponents.Add(new WorkflowComponent(e));
                }
                else if (component.ComponentType == EnumTypes.ComponentType.WebResource)
                {
                    var e = service.Retrieve("webresource", component.ObjectId, new ColumnSet(true));
                    var name = e.GetAttributeValue<string>("name");
                    WebResourceComponents.Add(new WebResourceComponent(e));
                }
                else if (component.ComponentType == EnumTypes.ComponentType.Role)
                {
                    var e = service.Retrieve("role", component.ObjectId, new ColumnSet(true));
                    var name = e.GetAttributeValue<string>("name");
                    Roles.Add(new RoleComponent(e));
                }
                else if (component.ComponentType == EnumTypes.ComponentType.RoutingRule)
                {
                    var e = service.Retrieve("routingrule", component.ObjectId, new ColumnSet(true));
                    RoutingRuleComponents.Add(new RoutingRuleComponent(e));
                }
                else if (component.ComponentType == EnumTypes.ComponentType.EmailTemplate)
                {
                    var e = service.Retrieve("template", component.ObjectId, new ColumnSet("title","description"));
                    EmailTemplateComponents.Add(new EmailTemplateComponent(e));
                }
                else if (component.ComponentType == EnumTypes.ComponentType.MailMergeTemplate)
                {
                    var e = service.Retrieve("mailmergetemplate", component.ObjectId, new ColumnSet("name", "description"));
                    MailMergeTemplateComponents.Add(new MailMergeTemplateComponent(e));
                }
                else if (component.ComponentType == EnumTypes.ComponentType.KBArticleTemplate)
                {
                    var e = service.Retrieve("kbarticletemplate", component.ObjectId, new ColumnSet("title", "description"));
                    KbArticleTemplateComponents.Add(new KbArticleTemplateComponent(e));
                }
                else if (component.ComponentType == EnumTypes.ComponentType.ContractTemplate)
                {
                    var e = service.Retrieve("contracttemplate", component.ObjectId, new ColumnSet("name", "description"));
                    ContractTemplateComponents.Add(new ContractTemplateComponent(e));
                }
                else if (component.ComponentType == EnumTypes.ComponentType.OptionSet)
                {

                    var optionSetMetabase = Organization.OptionSets.Where(x => x.MetadataId == component.ObjectId).FirstOrDefault<OptionSetMetadataBase>();

                    if(optionSetMetabase != null)
                        OptionSetComponents.Add(new OptionSetComponent(optionSetMetabase));
                }
            }

            foreach (var component in components)
            {

                if (component.ComponentType == ComponentModel.EnumTypes.ComponentType.Attribute)
                {
                    var rootComponent = components.Where(x => x.Id == component.RootSolutionComponentId).FirstOrDefault<CrmComponent>();
                    AddAttribute(component, rootComponent);

                }
                else if (component.ComponentType == EnumTypes.ComponentType.EntityRelationship)
                {
                    var rootComponent = components.Where(x => x.Id == component.RootSolutionComponentId).FirstOrDefault<CrmComponent>();
                    AddManyToOneRelationship(component, rootComponent);
                    AddManyToManyRelationship(component, rootComponent);

                }

            }

        }

        private void AddAssembly(PluginAssemblyComponent comp)
        {
            PluginAssemblyComponents.Add(comp);
        }

        #endregion
    }
}
