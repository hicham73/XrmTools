using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xrm.DevOPs.Manager.Component;


namespace Xrm.DevOPs.Manager.ComponentModel
{
     public class CrmTreeNode<T> : TreeNode
    {
        CrmComponent component;
        public CrmComponent Component {
            get { return component; }
            set
            {
                component = value;
                Text = component.Text;
                Name = component.Name;
            }
        }
        public CrmComponentCollection<T> Collection { get; set; }
    }

    public class ComponentCollection<T>
    {
        public string Type { get; set; }
        public List<T> Collection { get; set; }
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
