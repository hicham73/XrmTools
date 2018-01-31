using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xrm.DevOPs.Manager.Diff;
using Xrm.DevOPs.Manager.Wrappers;

namespace Xrm.DevOPs.Manager
{
    public class GlobalContext
    {
        public static List<KeyValuePair<String, IOrganizationService>> _orgServices = new List<KeyValuePair<string, IOrganizationService>>();
        public static List<CrmOrganization> CrmOrganizations = new List<CrmOrganization>();
        public static bool isOrganizationsLoaded = false;
        public static DiffGenerator _diffGenerator = new DiffGenerator();
        public static System.Drawing.Color LeftColor = System.Drawing.Color.LightBlue;
        public static System.Drawing.Color RightColor = System.Drawing.Color.LightGray;
    }
}
