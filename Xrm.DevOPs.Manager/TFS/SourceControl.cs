using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.Manager.TFS
{
    public class SourceControl
    {

        TfsTeamProjectCollection m_tpc;
        string m_username;
        string m_password;
        string m_url;

        TfsTeamProjectCollection TFSProject { get { return m_tpc; } }

        public SourceControl(string url, string username, string password)
        {
            m_url = url;
            m_username = username; //"hicham_wahbi@hotmail.com"
            m_password = password; // Juliku11

            Connect();
        }

        public void Connect()
        {
            NetworkCredential netCred = new NetworkCredential(m_username, m_password);
            BasicAuthCredential basicCred = new BasicAuthCredential(netCred);
            TfsClientCredentials tfsCred = new TfsClientCredentials(basicCred);
            m_tpc = new TfsTeamProjectCollection(new Uri(m_url), tfsCred);
        }
        public Item[] GetFolderItems(string folderPath)
        {
                VersionControlServer version = m_tpc.GetService(typeof(VersionControlServer)) as VersionControlServer;
                ItemSet items = version.GetItems(folderPath, RecursionType.Full);

            return items.Items;
        }

    }
}
