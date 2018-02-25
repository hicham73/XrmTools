using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xrm.DevOPs.Manager.Wrappers;
using Xrm.DevOPs.Manager.Model;

namespace Xrm.DevOPs.Manager.Helpers
{
    class ImportJob
    {

        public CrmSolution Solution { get; set; }
        public CrmOrganization Org { get; set; }
        double Progress { get; set; }  = 0.0;
        Entity m_ije;
        public Guid ImportJobId { get; set; }
        string JobLog { get; set; } = string.Empty;

        ColumnSet m_columnSet = new ColumnSet("solutionname", "startedon", "completedon", "progress");


        public void GetJobStatus()
        {
            m_ije = Org.Service.Retrieve("importjob", ImportJobId, m_columnSet);
        }
        public List<JobLogItem> GetImporJobtLog()
        {
            GetJobStatus();
            var formattedImportJobResultsRequest = new RetrieveFormattedImportJobResultsRequest
            {
                ImportJobId = m_ije.Id
            };
            var formattedImportJobResultsResponse = (RetrieveFormattedImportJobResultsResponse)Org.Service.Execute(formattedImportJobResultsRequest);
            JobLog = formattedImportJobResultsResponse.FormattedResults;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(JobLog);

            var ws = (XmlElement)doc.DocumentElement.GetElementsByTagName("Worksheet")[1];
            var rows = ws.GetElementsByTagName("Row");

            var jobLogItems = new List<JobLogItem>();

            foreach (var row in rows)
            {

                var r = (XmlElement)row;

                var data = r.GetElementsByTagName("Data");


                jobLogItems.Add(new JobLogItem() {
                    DateTime = data[0].InnerText,
                    ItemType = data[1].InnerText,
                    Id = data[2].InnerText,
                    Name = data[3].InnerText,
                    LocalizedName = data[4].InnerText,
                    OriginalName = data[5].InnerText,
                    Description = data[6].InnerText,
                    Status = data[7].InnerText,
                    ErrorCode = data[8].InnerText,
                    ErrorText = data[9].InnerText,
                });

            }

            return jobLogItems;
        }
    }
}
