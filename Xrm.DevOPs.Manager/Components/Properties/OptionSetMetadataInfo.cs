using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.ComponentModel;

namespace Xrm.DevOPs.Manager.ComponentModel.Property
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OptionSetMetadataInfo
    {
        private readonly OptionSetMetadataBase amd;

        public OptionSetMetadataInfo(OptionSetMetadataBase amd)
        {
            this.amd = amd;
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public LabelInfo Description => new LabelInfo(amd.Description);

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public LabelInfo DisplayName => new LabelInfo(amd.DisplayName);

        public string ExtensionData => amd.ExtensionData?.ToString() ?? "";

        public string IntroducedVersion => amd.IntroducedVersion;

        //[TypeConverter(typeof(ExpandableObjectConverter))]
        //public BooleanManagedPropertyInfo IsCustomizable => new BooleanManagedPropertyInfo(amd.IsCustomizable);

        public bool IsCustomOptionSet => amd.IsCustomOptionSet.HasValue && amd.IsCustomOptionSet.Value;

        public bool IsGlobal => amd.IsGlobal.HasValue && amd.IsGlobal.Value;

        public bool IsManaged => amd.IsManaged.HasValue && amd.IsManaged.Value;

        public Guid MetadataId => amd.MetadataId.Value;

        public string Name => amd.Name;

        //[Editor(typeof(CustomCollectionEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(OptionMetadataCollectionConverter))]
        public OptionMetadataCollection Options
        {
            get
            {
                var collec = new OptionMetadataCollection();
                if (amd.OptionSetType != null)
                    {
                        if ((OptionSetType)amd.OptionSetType == OptionSetType.Picklist)
                        {
                            OptionSetMetadata omd = (OptionSetMetadata)amd;
                            
                            foreach (OptionMetadata option in omd.Options)
                            {
                            collec.Add(new OptionMetadataInfo(option));
                        }
                        
                    }
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