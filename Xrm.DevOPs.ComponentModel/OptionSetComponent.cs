using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System.ComponentModel;

namespace Xrm.DevOPs.ComponentModel
{
    public class OptionSetComponent : CrmComponent
    {
        OptionSetMetadataBase osmdb;

        [Browsable(false)]
        public OptionSetComponent(OptionSetMetadataBase osmdb)
        {
            this.osmdb = osmdb;
        }

        [Browsable(false)]
        public MetadataBase Metadata { get { return osmdb;  } }

        new public string Name
        {
            get { return osmdb.Name; }
        }

        public string Description
        {
            get { return osmdb.Description?.UserLocalizedLabel?.Label;  }
        }
        override public string Text
        {
            get { return Name; }
        }
    }
}
