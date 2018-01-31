using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.ComponentModel;
using Xrm.DevOPs.Manager.ComponentModel.Property;

namespace Xrm.DevOPs.ComponentModel
{
    public class OptionSetComponent : CrmComponent
    {
        OptionSetMetadataBase osmdb;

        public static string[] Properties { get; } = new string[] { "Name", "Description" }; 

        [Browsable(false)]
        public OptionSetComponent(CrmComponent c, OptionSetMetadataBase osmdb)
        {
            this.osmdb = osmdb;
            Id = osmdb.MetadataId;
            ComponentType = c.ComponentType;
            Name = osmdb.Name;
            DisplayName = osmdb.DisplayName?.UserLocalizedLabel?.Label;
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public OptionSetMetadataInfo Metadata { get { return new OptionSetMetadataInfo(osmdb);  } }

        public string Description
        {
            get { return osmdb.Description?.UserLocalizedLabel?.Label;  }
        }
        [Browsable(false)]
        override public string Text
        {
            get { return Name; }
        }

        public bool? IsCustomizable
        {
            get { return osmdb.IsCustomizable?.Value; }
        }
        public bool? IsManaged
        {
            get { return osmdb.IsManaged; }
        }


    }
}
