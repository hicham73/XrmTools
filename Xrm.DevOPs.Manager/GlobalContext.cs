using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xrm.DevOPs.Manager.Config;
using Xrm.DevOPs.Manager.Diff;
using Xrm.DevOPs.Manager.Wrappers;

namespace Xrm.DevOPs.Manager
{
    public class GlobalContext
    {

        private static ManagerConfig m_config;
        public List<KeyValuePair<String, IOrganizationService>> Services = new List<KeyValuePair<string, IOrganizationService>>();
        public List<CrmOrganization> CrmOrganizations = new List<CrmOrganization>();
        public bool IsOrganizationLoaded = false;
        public DiffGenerator DiffGenerator = new DiffGenerator();
        public Color LeftColor = Color.LightBlue;
        public Color RightColor = Color.LightGray;
        public TreeView OrganizationTree;

        public static ManagerConfig Config
        {
            get
            {
                if (m_config == null)
                    m_config = (ManagerConfig)ConfigurationManager.GetSection("Manager"); ;
                return m_config;
            }
        }
    }
}
