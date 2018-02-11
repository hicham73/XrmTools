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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void AddProjectPatch(string projectName, string patchPath, string patchVer, RichTextBox log)
        {
            var server = m_tpc.GetService<VersionControlServer>();
            var workspace = server.GetWorkspace(GlobalContext.Config.TFS.WorkspacePath);
            var projSolDir = Path.Combine("solutions", projectName);
            String fullPath = string.Empty;

            try
            {
                var rootDir = workspace.Folders[0].LocalItem;
                var fileName = Path.GetFileName(patchPath);

                var projDir = Directory.GetDirectories(rootDir, projSolDir, SearchOption.AllDirectories);
                if (projDir.Length == 0)
                    throw new Exception($"Project directory {projSolDir} not found, please make sure the workspace exists and the path is correct");

                var baseVer = patchVer;
                var vnums = patchVer.Split('.');
                if (vnums.Length == 4)
                    baseVer = $"{vnums[0]}.{vnums[1]}";

                fullPath = Path.Combine(projDir[0], baseVer);

                if(!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);

                String patchWsPath = Path.Combine(fullPath, fileName);
                File.Copy(patchPath, patchWsPath);
                workspace.PendAdd(patchWsPath, true);

                WriteLine(log, "--- Show our pending changes.");
                PendingChange[] pendingChanges = workspace.GetPendingChanges();
                WriteLine(log, "  Your current pending changes:");
                foreach (PendingChange pendingChange in pendingChanges)
                {
                    WriteLine(log, "    path: " + pendingChange.LocalItem +
                                      ", change: " + PendingChange.GetLocalizedStringForChangeType(pendingChange.ChangeType));
                }

                WriteLine(log, "--- Checkin the items we added.");
                int changesetNumber = workspace.CheckIn(pendingChanges, "Sample changes");
                WriteLine(log, "  Checked in changeset " + changesetNumber);

                WriteLine(log, "--- Checkout and modify the file.");
                workspace.PendEdit(fileName);
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("revision 2 of basic.cs");
                }

                WriteLine(log, "--- Get the pending change and check in the new revision.");
                pendingChanges = workspace.GetPendingChanges();
                changesetNumber = workspace.CheckIn(pendingChanges, "Modified basic.cs");
                WriteLine(log, "  Checked in changeset " + changesetNumber);
            }
            catch(Exception ex)
            {
                WriteLine(log, $"Exception while adding file to TFS, Message: {ex.Message}");
            }
            
        }


        public void WriteLine(RichTextBox log, string msg)
        {
            log.AppendText($"{msg}{Environment.NewLine}");
        }
    

    }
}
