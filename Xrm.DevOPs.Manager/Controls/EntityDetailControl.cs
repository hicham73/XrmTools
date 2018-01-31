using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xrm.DevOPs.Controls
{
    public partial class EntityDetailControl : UserControl
    {
        public EntityDetailControl()
        {
            InitializeComponent();
        }

        public ListView Lv1NRelationships { get { return lv1NRelationships;  } }
        public ListView LvAttributes { get { return lvAttributes;  } }
        public ListView LvN1Relationships { get { return lvN1Relationships;  } }
        public ListView LvNNRelationships { get { return lvNNRelationships;  } }

        public void ShowProperties(Object comp)
        {
            pgCompDetail.SelectedObject = comp;
        }

        private void TV_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lv = (ListView)sender;
            if (lv.SelectedItems.Count > 0)
            {
                var obj = lv.SelectedItems[0];
                pgCompDetail.SelectedObject = obj.Tag;
            }
        }
    }
    
}
