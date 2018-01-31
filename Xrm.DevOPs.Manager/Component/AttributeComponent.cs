using Microsoft.Xrm.Sdk.Metadata;
using System.ComponentModel;

namespace Xrm.DevOPs.ComponentModel
{
    public class AttributeComponent : CrmComponent
    {
        private readonly AttributeMetadata amd;
        public static string[] Properties { get; } = new string[] { "Name"};

        public AttributeComponent(AttributeMetadata amd)
        {
            this.amd = amd;
            Id = amd.MetadataId;
            Name = amd.LogicalName;
            DisplayName = amd.DisplayName?.UserLocalizedLabel?.Label;
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        AttributeMetadata Meta { get { return amd; } }

        public string AttributeOf
        {
            get { return amd.AttributeOf; }
        }

        public AttributeTypeCode AttributeType
        {
            get { return amd.AttributeType.Value; }
        }

        public string AttributeTypeName
        {
            get { return amd.AttributeTypeName != null ? amd.AttributeTypeName.Value : ""; }
        }

        public bool CanBeSecuredForCreate
        {
            get { return amd.CanBeSecuredForCreate.HasValue && amd.CanBeSecuredForCreate.Value; }
        }

        public bool CanBeSecuredForRead
        {
            get { return amd.CanBeSecuredForRead.HasValue && amd.CanBeSecuredForRead.Value; }
        }

        public bool CanBeSecuredForUpdate
        {
            get { return amd.CanBeSecuredForUpdate.HasValue && amd.CanBeSecuredForUpdate.Value; }
        }

        public int ColumnNumber
        {
            get { return amd.ColumnNumber.Value; }
        }

        public string DeprecatedVersion
        {
            get { return amd.DeprecatedVersion; }
        }

        public string Description
        {
            get { return amd.Description?.UserLocalizedLabel?.Label; }
        }

        public string EntityLogicalName
        {
            get { return amd.EntityLogicalName; }
        }

        public string ExtensionData
        {
            get { return amd.ExtensionData.ToString(); }
        }

        public bool HasChanged
        {
            get { return amd.HasChanged.HasValue && amd.HasChanged.Value; }
        }

        public string InheritsFrom
        {
            get { return amd.InheritsFrom; }
        }

        public string IntroducedVersion
        {
            get { return amd.IntroducedVersion; }
        }

        public bool IsCustomAttribute
        {
            get { return amd.IsCustomAttribute.HasValue && amd.IsCustomAttribute.Value; }
        }

        public bool IsFilterable
        {
            get { return amd.IsFilterable.HasValue && amd.IsFilterable.Value; }
        }

        public bool IsLogical
        {
            get { return amd.IsLogical.HasValue && amd.IsLogical.Value; }
        }

        public bool IsManaged
        {
            get { return amd.IsManaged.HasValue && amd.IsManaged.Value; }
        }

        public bool IsPrimaryId
        {
            get { return amd.IsPrimaryId.HasValue && amd.IsPrimaryId.Value; }
        }

        public bool IsPrimaryName
        {
            get { return amd.IsPrimaryName.HasValue && amd.IsPrimaryName.Value; }
        }

        public bool IsRetrievable
        {
            get { return amd.IsRetrievable.HasValue && amd.IsRetrievable.Value; }
        }

        public bool IsSearchable
        {
            get { return amd.IsSearchable.HasValue && amd.IsSearchable.Value; }
        }

        public bool IsSecured
        {
            get { return amd.IsSecured.HasValue && amd.IsSecured.Value; }
        }


        public bool IsValidForCreate
        {
            get { return amd.IsValidForCreate.HasValue && amd.IsValidForCreate.Value; }
        }

        public bool IsValidForRead
        {
            get { return amd.IsValidForRead.HasValue && amd.IsValidForRead.Value; }
        }

        public bool IsValidForUpdate
        {
            get { return amd.IsValidForUpdate.HasValue && amd.IsValidForUpdate.Value; }
        }

        public string LinkedAttributeId
        {
            get { return amd.LinkedAttributeId.HasValue ? amd.LinkedAttributeId.Value.ToString("B") : ""; }
        }

        public string LogicalName
        {
            get { return amd.LogicalName; }
        }

        public string MetadataId
        {
            get { return amd.MetadataId.HasValue ? amd.MetadataId.Value.ToString("B") : ""; }
        }


        public string SchemaName
        {
            get { return amd.SchemaName; }
        }

        public int SourceType
        {
            get { return amd.SourceType.HasValue ? amd.SourceType.Value : -1; }
        }

        public override string ToString()
        {
            return amd.AttributeType.Value.ToString();
        }
    }
}