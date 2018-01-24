using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using MsCrmTools.MetadataBrowser.AppCode.ManyToManyRelationship;
using MsCrmTools.MetadataBrowser.AppCode.OneToManyRelationship;
using Xrm.DevOPs.Manager.Meta.AttributeMd;
using Xrm.DevOPs.Manager.Meta.EntityMd;
using Xrm.DevOPs.Manager.Util;
using Xrm.DevOPs.Manager.Wrappers;

namespace Xrm.DevOPs.Manager.Meta
{
    public class SolutionMeta
    {
        public string UniqueName { get; set; }

        public List<EntityMetadataInfo> EntityMetas { get; set; } = new List<EntityMetadataInfo>();
        public List<CrmPluginAssembly> PluginAssemblies { get; set; } = new List<CrmPluginAssembly>();

        public bool IsLoaded { get; internal set; } = false;

        internal void AddEntity(EntityMetadataInfo emdi)
        {
            EntityMetas.Add(emdi);
        }

        public void AddAttribute(CrmComponent component, CrmComponent rootComponent)
        {
            if (rootComponent != null)
            {
                var emdi = EntityMetas.Where(x => x.MetadataId.Contains(rootComponent.ObjectId.ToString())).FirstOrDefault<EntityMetadataInfo>();
                if (emdi != null)
                {
                    var amdi = emdi.EntityMetadata.Attributes.Where(x => x.MetadataId == component.ObjectId).FirstOrDefault<AttributeMetadata>();

                    emdi.Attributes.Add(new AttributeMetadataInfo(amdi));

                }
            }

            
        }

        internal void AddManyToOneRelationship(CrmComponent component, CrmComponent rootComponent)
        {
            if (rootComponent != null)
            {
                var emdi = EntityMetas.Where(x => x.MetadataId.Contains(rootComponent.ObjectId.ToString())).FirstOrDefault<EntityMetadataInfo>();

                if (emdi != null)
                {
                    var otmr = emdi.EntityMetadata.ManyToOneRelationships.Where(x => x.MetadataId == component.ObjectId).FirstOrDefault<OneToManyRelationshipMetadata>();

                    if (otmr != null)
                    {
                        emdi.ManyToOneRelashionships.Add(new OneToManyRelationshipMetadataInfo(otmr));

                        var primaryEntity = EntityMetas.Where(x => x.LogicalName == otmr.ReferencedEntity).FirstOrDefault<EntityMetadataInfo>();

                        if (primaryEntity != null)
                            primaryEntity.OneToManyRelashionships.Add(new OneToManyRelationshipMetadataInfo(otmr));
                    }

                }
            }
        }

        internal void AddManyToManyRelationship(CrmComponent component, CrmComponent rootComponent)
        {
            if (rootComponent != null)
            {
                var emdi = EntityMetas.Where(x => x.MetadataId.Contains(rootComponent.ObjectId.ToString())).FirstOrDefault<EntityMetadataInfo>();

                if (emdi != null)
                {
                    var mtmr = emdi.EntityMetadata.ManyToManyRelationships.Where(x => x.MetadataId == component.ObjectId).FirstOrDefault<ManyToManyRelationshipMetadata>();

                    if (mtmr != null)
                        emdi.ManyToManyRelationships.Add(new ManyToManyRelationshipMetadataInfo(mtmr));

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

                    AddEntity(new EntityMetadataInfo(response.EntityMetadata));
                }
                else if (component.ComponentType == EnumTypes.ComponentType.PluginAssembly)
                {
                    var e = service.Retrieve("pluginassembly", component.ObjectId, new ColumnSet(true));

                    var name = e.GetAttributeValue<string>("name");

                    var crmAssembly = new CrmPluginAssembly(name);

                    var qe = new QueryByAttribute("plugintype");
                    qe.ColumnSet = new ColumnSet(true);
                    qe.AddAttributeValue("pluginassemblyid", e.Id);

                    var pts = service.RetrieveMultiple(qe).Entities;

                    var ns = $"{name}.";
                    foreach (var pt in pts)
                    {
                        var typeName = pt.GetAttributeValue<string>("typename")?.Replace(ns,"");
                        
                        crmAssembly.AddPlugin(new CrmPlugin() { Name = typeName });
                    }

                    AddAssembly(crmAssembly);

                }
                else if (component.ComponentType == EnumTypes.ComponentType.SDKMessageProcessingStep)
                {
                    var e = service.Retrieve("sdkmessageprocessingstep", component.ObjectId, new ColumnSet(true));
                    var name = e.GetAttributeValue<string>("name");
                }

            }

            foreach (var component in components)
            {

                if (component.ComponentType == EnumTypes.ComponentType.Attribute)
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

            IsLoaded = true;

        }

        private void AddPluginType(CrmPlugin crmPlugin)
        {
            throw new NotImplementedException();
        }

        private void AddAssembly(CrmPluginAssembly crmPluginAssembly)
        {
            PluginAssemblies.Add(crmPluginAssembly);
        }
    }

    
}