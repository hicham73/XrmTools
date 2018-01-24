using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xrm.DevOPs.Manager.UI.Forms
{
    public partial class PropertiesForm : Form
    {
        public PropertiesForm()
        {
            InitializeComponent();
        }


        public void SetPropertGrid(Object obj)
        {
            propertyGrid1.SelectedObject = obj;
        }


    }
}
