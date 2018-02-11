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
using Xrm.DevOPs.Manager.TFS;
using Xrm.DevOPs.Manager.Wrappers;

namespace Xrm.DevOPs.Manager
{
    public class GlobalContext
    {

        private static ManagerConfig m_config;
        private static SourceControl m_sourceControl;
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
        public static SourceControl SourceControl
        {
            get
            {
                if (m_sourceControl == null)
                    m_sourceControl = new SourceControl(Config.TFS.Url, Config.TFS.Username, Config.TFS.Password);

                return m_sourceControl;
            }
        }
    }
}
