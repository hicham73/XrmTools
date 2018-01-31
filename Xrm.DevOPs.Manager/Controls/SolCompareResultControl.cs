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
    public partial class SolCompareResultControl : UserControl
    {
        public SolCompareResultControl()
        {
            InitializeComponent();
        }

        public string Header
        {
            get { return lblHeader.Text;  }
            set { lblHeader.Text = value;  }
        }
    }
}
