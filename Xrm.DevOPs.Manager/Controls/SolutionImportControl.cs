using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xrm.DevOPs.Manager.Wrappers;
using Xrm.DevOPs.Manager.Helpers;
using Xrm.DevOPs.Manager.Model;

namespace Xrm.DevOPs.Manager.Controls
{
    public partial class SolutionImportControl : UserControl
    {

        List<CrmSolution> Solutions = new List<CrmSolution>();
        public CrmOrganization SourceOrg { get; set; }
        public CrmOrganization TargetOrg { get; set; }


        public SolutionImportControl()
        {
            InitializeComponent();
        }

        public void AddSolution(CrmSolution sol)
        {
            Solutions.Add(sol);

            var item = new ListViewItem(new string[] { sol.NameVersion, sol.Version, SourceOrg.Name, TargetOrg.Name });
            item.Tag = sol;
            item.Checked = true;
            lvSolutions.Items.Add(item);
        }

        private void BtnStart_Click(object sender, EventArgs ea)
        {
            var worker = new Worker();

            worker.WorkAsync(new WorkAsyncInfo("Loading solution history..", (e) =>
            {
                foreach (ListViewItem item in lvSolutions.CheckedItems)
                {
                    var sol = (CrmSolution)item.Tag;
                    ImportJob importJob = null;
                    Guid importJobId = Guid.NewGuid();
                    try
                    {
                        SolutionHelper.TransferSolution(SourceOrg, TargetOrg, sol.UniqueName, importJobId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Solution import failed, Message: {ex.Message}, {ex.InnerException?.Message}");
                    }

                    importJob = new ImportJob()
                    {
                        Solution = sol,
                        Org = TargetOrg,
                        ImportJobId = importJobId
                    };

                    if (importJob != null)
                    {
                        var jobLogItems = importJob.GetImporJobtLog();
                        if (lvImportLog.Columns.Count == 0)
                        {
                            lvImportLog.Columns.Add(new ColumnHeader() { Text = "Date", Width = 100 });
                            lvImportLog.Columns.Add(new ColumnHeader() { Text = "Name", Width = 100 });
                            lvImportLog.Columns.Add(new ColumnHeader() { Text = "Id", Width = 100 });
                            lvImportLog.Columns.Add(new ColumnHeader() { Text = "Description", Width = 150 });
                            lvImportLog.Columns.Add(new ColumnHeader() { Text = "Status", Width = 80 });
                            lvImportLog.Columns.Add(new ColumnHeader() { Text = "Error Code", Width = 80 });
                            lvImportLog.Columns.Add(new ColumnHeader() { Text = "Error Message", Width = 300 });
                        }
                        foreach (var it in jobLogItems)
                        {
                            if (!string.IsNullOrEmpty(it.DateTime))
                            {
                                lvImportLog.Items.Add(new ListViewItem(new string[] {
                                it.DateTime,
                                it.Name,
                                it.Id,
                                it.Description,
                                it.Status,
                                it.ErrorCode,
                                it.ErrorText,
                            }));
                            }
                        }
                    }
                }
            })
            {
                PostWorkCallBack = (completedargs) =>
                {
                }
            });

           


        }

        internal void Reset()
        {
            Solutions.Clear();
            lvSolutions.Items.Clear();
            lvImportLog.Items.Clear();

        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
