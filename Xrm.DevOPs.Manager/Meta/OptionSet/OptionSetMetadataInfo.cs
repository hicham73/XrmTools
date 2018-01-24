using Microsoft.Xrm.Sdk.Metadata;
using Xrm.DevOPs.Manager.Meta.LabelMd;
using Xrm.DevOPs.Manager.Meta.OptionMd;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using OptionMetadataCollection = Xrm.DevOPs.Manager.Meta.OptionMd.OptionMetadataCollection;

namespace Xrm.DevOPs.Manager.Meta.OptionSetMd
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OptionSetMetadataInfo
    {
        private readonly OptionSetMetadata amd;

        public OptionSetMetadataInfo(OptionSetMetadata amd)
        {
            this.amd = amd;
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public LabelInfo Description => new LabelInfo(amd.Description);

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public LabelInfo DisplayName => new LabelInfo(amd.DisplayName);

        public string ExtensionData => amd.ExtensionData?.ToString() ?? "";

        public string IntroducedVersion => amd.IntroducedVersion;


        public bool IsCustomOptionSet => amd.IsCustomOptionSet.HasValue && amd.IsCustomOptionSet.Value;

        public bool IsGlobal => amd.IsGlobal.HasValue && amd.IsGlobal.Value;

        public bool IsManaged => amd.IsManaged.HasValue && amd.IsManaged.Value;

        public Guid MetadataId => amd.MetadataId.Value;

        public string Name => amd.Name;

        public OptionMetadataCollection Options
        {
            get
            {
                var collec = new OptionMetadataCollection();
                foreach (OptionMetadata omd in amd.Options)
                {
                    collec.Add(new OptionMetadataInfo(omd));
                }

                return collec;
            }
        }

        public OptionSetType OptionSetType => amd.OptionSetType.Value;

        public override string ToString()
        {
            return amd.Name;
        }
    }
}