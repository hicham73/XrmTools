using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.ComponentModel;

namespace Xrm.DevOPs.ComponentModel
{
    public class ManyToManyRelationshipComponent : CrmComponent
    {
        private readonly ManyToManyRelationshipMetadata mtmmd;

        public ManyToManyRelationshipComponent(ManyToManyRelationshipMetadata mtmmd)
        {
            this.mtmmd = mtmmd;
            Id = mtmmd.MetadataId;
            ComponentType = EnumTypes.ComponentType.Relationship;
            Name = mtmmd.SchemaName;
            DisplayName = Name;
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ManyToManyRelationshipMetadata Meta { get { return mtmmd; } }

        public string Entity1IntersectAttribute => mtmmd.Entity1IntersectAttribute;

        public string Entity1LogicalName => mtmmd.Entity1LogicalName;

        
        public string Entity2IntersectAttribute => mtmmd.Entity2IntersectAttribute;

        public string Entity2LogicalName => mtmmd.Entity2LogicalName;

        public string ExtensionData => mtmmd.ExtensionData?.ToString() ?? "";

        public bool HasChanged => mtmmd.IsValidForAdvancedFind.HasValue && mtmmd.IsValidForAdvancedFind.Value;

        public string IntersectEntityName => mtmmd.IntersectEntityName;

        public bool IsCustomRelationship => mtmmd.IsCustomRelationship.HasValue && mtmmd.IsCustomRelationship.Value;

        public bool IsManaged => mtmmd.IsManaged.HasValue && mtmmd.IsManaged.Value;

        public bool IsValidForAdvancedFind => mtmmd.IsValidForAdvancedFind.HasValue && mtmmd.IsValidForAdvancedFind.Value;

        public Guid MetadataId => mtmmd.MetadataId ?? Guid.Empty;

        public RelationshipType RelationshipType => mtmmd.RelationshipType;

        public string SchemaName => mtmmd.SchemaName;

        public SecurityTypes SecurityTypes => mtmmd.SecurityTypes.Value;

        public override string ToString()
        {
            return mtmmd.SchemaName;
        }

        override public string Text
        {
            get { return Name; }
        }

        public bool? IsCustomizable
        {
            get { return mtmmd.IsCustomizable?.Value; }
        }

    }
}