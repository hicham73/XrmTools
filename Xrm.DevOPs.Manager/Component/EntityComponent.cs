using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xrm.DevOPs.Manager.Wrappers;

namespace Xrm.DevOPs.Manager.Component
{
    public class EntityComponent : CrmComponent
    {
        private EntityMetadata emd;
        public EntityMetadata Meta { get { return emd; } set { emd = value; } }
        public List<OneToManyRelationshipComponent> ManyToOneRelashionships { get; set; } = new List<OneToManyRelationshipComponent>();
        public List<OneToManyRelationshipComponent> OneToManyRelashionships { get; set; } = new List<OneToManyRelationshipComponent>();
        public List<ManyToManyRelationshipComponent> ManyToManyRelationships { get; set; } = new List<ManyToManyRelationshipComponent>();
        public List<AttributeComponent> Attributes { get; set; } = new List<AttributeComponent>();

        override public string Text
        {
            get { return DisplayName; }
        }
        public EntityComponent(CrmComponent component, EntityMetadata emd)
        {
            this.emd = emd;
            RootComponentBehavior = component.RootComponentBehavior;
            RootSolutionComponentId = component.RootSolutionComponentId;
            ComponentType = component.ComponentType;
            Name = emd.LogicalName;
           
            if (RootComponentBehavior == 0)
            {
                foreach (var amd in emd.Attributes)
                {
                    Attributes.Add(new AttributeComponent(amd));
                }
                foreach (var rel in emd.OneToManyRelationships)
                {
                    OneToManyRelashionships.Add(new OneToManyRelationshipComponent(rel));
                }
                foreach (var rel in emd.ManyToManyRelationships)
                {
                    ManyToManyRelationships.Add(new ManyToManyRelationshipComponent(rel));
                }
            }
        }


        public string Description
        {
            get { return emd.Description?.UserLocalizedLabel?.Label; }
        }

        public string DisplayName
        {
            get { return emd.DisplayName?.UserLocalizedLabel?.Label; }
        }

        public string LogicalName
        {
            get { return emd.LogicalName; }
        }

        public string ExtensionData
        {
            get { return emd.ExtensionData.ToString(); }
        }

        public bool HasChanged
        {
            get { return emd.HasChanged.HasValue && emd.HasChanged.Value; }
        }

        public string IntroducedVersion
        {
            get { return emd.IntroducedVersion; }
        }

        public bool IsCustomEntity
        {
            get { return emd.IsCustomEntity.HasValue && emd.IsCustomEntity.Value; }
        }

        public bool IsActivity
        {
            get { return emd.IsActivity.HasValue && emd.IsActivity.Value; }
        }

        public bool IsManaged
        {
            get { return emd.IsManaged.HasValue && emd.IsManaged.Value; }
        }

        public string MetadataId
        {
            get { return emd.MetadataId.HasValue ? emd.MetadataId.Value.ToString("B") : ""; }
        }

        public string SchemaName
        {
            get { return emd.SchemaName; }
        }


        public override string ToString()
        {
            return DisplayName;
        }
    }
}
