using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xrm.DevOPs.Manager.Diff;
using Xrm.DevOPs.Manager.Wrappers;

namespace Xrm.DevOPs.Manager
{
    public class GlobalContext
    {
        public static List<KeyValuePair<String, IOrganizationService>> Services = new List<KeyValuePair<string, IOrganizationService>>();
        public static List<CrmOrganization> CrmOrganizations = new List<CrmOrganization>();
        public static bool IsOrganizationLoaded = false;
        public static DiffGenerator DiffGenerator = new DiffGenerator();
        public static Color LeftColor = Color.LightBlue;
        public static Color RightColor = Color.LightGray;
        public static TreeView OrganizationTree;
    }
}
