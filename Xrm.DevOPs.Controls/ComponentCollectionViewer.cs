using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xrm.DevOPs.ComponentModel;
using Xrm.DevOPs.Manager.ComponentModel;

namespace Xrm.DevOPs.Controls
{
    public partial class ComponentCollectionViewer : UserControl
    {
        public ComponentCollectionViewer()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            lvComponents.SelectedIndexChanged += ShowComponentProperties;
        }

        private void ShowComponentProperties(object sender, EventArgs e)
        {
            if (lvComponents.SelectedItems.Count > 0)
            {
                var comp = (CrmComponent)lvComponents.SelectedItems[0].Tag;

                switch (comp.ComponentType)
                {
                    case EnumTypes.ComponentType.OptionSet:
                        pgComponent.SelectedObject = (OptionSetComponent)comp;
                        break;
                    case EnumTypes.ComponentType.PluginAssembly:
                        pgComponent.SelectedObject = (PluginAssemblyComponent)comp;
                        break;
                    case EnumTypes.ComponentType.PluginType:
                        pgComponent.SelectedObject = (PluginTypeComponent)comp;
                        break;
                    case EnumTypes.ComponentType.Workflow:
                        pgComponent.SelectedObject = (WorkflowComponent)comp;
                        break;
                    case EnumTypes.ComponentType.EmailTemplate:
                        pgComponent.SelectedObject = (EmailTemplateComponent)comp;
                        break;
                    case EnumTypes.ComponentType.MailMergeTemplate:
                        pgComponent.SelectedObject = (MailMergeTemplateComponent)comp;
                        break;
                    case EnumTypes.ComponentType.ContractTemplate:
                        pgComponent.SelectedObject = (ContractTemplateComponent)comp;
                        break;
                    case EnumTypes.ComponentType.KBArticleTemplate:
                        pgComponent.SelectedObject = (KbArticleTemplateComponent)comp;
                        break;
                    case EnumTypes.ComponentType.RoutingRule:
                        pgComponent.SelectedObject = (RoutingRuleComponent)comp;
                        break;
                    case EnumTypes.ComponentType.Role:
                        pgComponent.SelectedObject = (RoleComponent)comp;
                        break;
                }
            }
        }

        public void Display<T>(CrmComponentCollection<T> compCollection)
        {
            lvComponents.Columns.Add(new ColumnHeader("Name"));
             
            foreach (var comp in compCollection.Components)
            {
                var item = new ListViewItem(comp.GetPropertyValue("Name").ToString());
                item.Tag = comp;
                lvComponents.Items.Add(item);
            }
        }


    }
}
