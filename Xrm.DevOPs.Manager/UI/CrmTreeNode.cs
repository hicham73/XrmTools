using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xrm.DevOPs.ComponentModel;


namespace Xrm.DevOPs.Manager.UI
{
    public class CrmTreeNode : TreeNode
    {
        CrmComponent component;
        public CrmComponent Component {
            get { return component; }
            set
            {
                component = value;
                Text = component.Text;
            }
        }

    }

    public enum NodeType
    {
        Organization,
        Solution,
        Entity,
        Attribute,
        ManyToManyRelationship,
        OneToManyRelationship,
        PluginAssembly,
        PluginType,
        SdkMessageProcessingStep,
    }
}
