using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.ComponentModel;

namespace Xrm.DevOPs.ComponentModel
{
    public class OneToManyRelationshipComponent : CrmComponent
    {
        private readonly OneToManyRelationshipMetadata otmmd;

        public OneToManyRelationshipComponent(OneToManyRelationshipMetadata otmmd)
        {
            this.otmmd = otmmd;
            Id = otmmd.MetadataId;
            ComponentType = EnumTypes.ComponentType.Relationship;
            Name = otmmd.SchemaName;
            DisplayName = Name;
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public OneToManyRelationshipMetadata Meta { get { return otmmd; } }

        public string ExtensionData
        {
            get { return otmmd.ExtensionData != null ? otmmd.ExtensionData.ToString() : ""; }
        }

        public bool HasChanged
        {
            get { return otmmd.HasChanged.HasValue && otmmd.HasChanged.Value; }
        }



        public bool IsCustomRelationship
        {
            get { return otmmd.IsCustomRelationship.HasValue && otmmd.IsCustomRelationship.Value; }
        }

        public bool IsManaged
        {
            get { return otmmd.IsManaged.HasValue && otmmd.IsManaged.Value; }
        }

        public bool IsValidForAdvancedFind
        {
            get { return otmmd.IsValidForAdvancedFind.HasValue && otmmd.IsValidForAdvancedFind.Value; }
        }

        public Guid MetadataId
        {
            get { return otmmd.MetadataId.Value; }
        }

        public string ReferencedAttribute
        {
            get { return otmmd.ReferencedAttribute; }
        }

        public string ReferencedEntity
        {
            get { return otmmd.ReferencedEntity; }
        }

        public string ReferencingAttribute
        {
            get { return otmmd.ReferencingAttribute; }
        }

        public string ReferencingEntity
        {
            get { return otmmd.ReferencingEntity; }
        }

        public RelationshipType RelationshipType
        {
            get { return otmmd.RelationshipType; }
        }

        public string SchemaName
        {
            get { return otmmd.SchemaName; }
        }

        public SecurityTypes SecurityTypes
        {
            get { return otmmd.SecurityTypes.Value; }
        }

        public override string ToString()
        {
            return otmmd.SchemaName;
        }

        public bool? IsCustomizable
        {
            get { return otmmd.IsCustomizable?.Value; }
        }
    }
}