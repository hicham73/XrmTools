using Microsoft.Xrm.Sdk.Metadata;
using Xrm.DevOPs.Manager.Meta.LabelMd;
using System.ComponentModel;
using System.Windows.Forms;
using Xrm.DevOPs.Manager.Meta.AttributeMd;
using System.Collections.Generic;
using MsCrmTools.MetadataBrowser.AppCode.OneToManyRelationship;
using MsCrmTools.MetadataBrowser.AppCode.ManyToManyRelationship;

namespace Xrm.DevOPs.Manager.Meta.EntityMd
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class EntityMetadataInfo : TreeNode
    {
        private readonly EntityMetadata emd;

        public EntityMetadataInfo(EntityMetadata emd)
        {
            this.emd = emd;
            Text = emd.LogicalName;
            Tag = "Entity";
        }

        public EntityMetadata EntityMetadata { get { return emd;  } }

        public List<AttributeMetadataInfo> Attributes { get; set; } = new List<AttributeMetadataInfo>();

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public LabelInfo Description
        {
            get { return new LabelInfo(emd.Description); }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public LabelInfo DisplayName
        {
            get { return new LabelInfo(emd.DisplayName); }
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

        public List<OneToManyRelationshipMetadataInfo> ManyToOneRelashionships { get; set; } = new List<OneToManyRelationshipMetadataInfo>();
        public List<OneToManyRelationshipMetadataInfo> OneToManyRelashionships { get; set; } = new List<OneToManyRelationshipMetadataInfo>();
        public List<ManyToManyRelationshipMetadataInfo> ManyToManyRelationships { get; set; } = new List<ManyToManyRelationshipMetadataInfo>();

        public override string ToString()
        {
            return DisplayName.ToString();
        }
    }
}