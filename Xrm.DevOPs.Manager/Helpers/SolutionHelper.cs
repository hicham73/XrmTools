﻿using System;
using System.IO;
using Microsoft.Xrm.Sdk.Query;

using Microsoft.Crm.Sdk.Messages;
using System.Collections.Generic;
using Xrm.DevOPs.Manager.Wrappers;
using Microsoft.Xrm.Sdk;
using Xrm.DevOPs.Manager.Util;
using System.Linq;
using Xrm.DevOPs.Manager.Component;
using static Xrm.DevOPs.Manager.Util.EnumTypes;

namespace Xrm.DevOPs.Manager.Helpers
{
    public class SolutionHelper
    {
        #region Class Level Members

        private const int _languageCode = 1033;


        #endregion Class Level Members

        public static List<CrmSolution> GetSolutions(IOrganizationService service)
        {
            var sols = new List<CrmSolution>();
            var qe = new QueryExpression("solution");
            qe.ColumnSet = new ColumnSet(true);
            qe.Criteria = new FilterExpression();
            qe.Criteria.AddCondition(new ConditionExpression("ismanaged", ConditionOperator.Equal, false));
            qe.Criteria.AddCondition(new ConditionExpression("uniquename", ConditionOperator.NotIn, "Active", "Basic"));
            //qe.Criteria.AddCondition(new ConditionExpression("uniquename", ConditionOperator.Like, $"{configPatchPrefix}%"));

            var result = service.RetrieveMultiple(qe);

            foreach (var e in result.Entities)
            {
                var sol = new CrmSolution()
                {
                    UniqueName = e.GetAttributeValue<string>("uniquename"),
                    FriendlyName = e.GetAttributeValue<string>("friendlyname"),
                    Version = e.GetAttributeValue<string>("version"),
                    ParentSolutionId = e.GetAttributeValue<EntityReference>("parentsolutionid"),
                    IsParent = false,
                    Id = e.Id,
                    Type = EnumTypes.TreeNodeType.Solution,

                };

                if (sol.ParentSolutionId == null)
                    sol.IsParent = true;

                sols.Add(sol);
            }


            var sols2 = new List<CrmSolution>();
            foreach (var sol in sols.OrderBy(o => o.Version).ToList())
            {
                if (sol.IsParent)
                    sols2.Add(sol);
                else
                {
                    var parentSol = sols.Where(x => x.Id != null && sol.ParentSolutionId != null && x.Id == sol.ParentSolutionId.Id).FirstOrDefault<CrmSolution>();
                    if (parentSol != null)
                        parentSol.ChildSolutions.Components.Add(sol);
                }
            }

            return sols2;
        }

        public static List<CrmComponent> RetrieveComponentsFromSolution(CrmSolution sol, IOrganizationService service)
        {

            var components = new List<CrmComponent>();

            var qe = new QueryExpression("solutioncomponent")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("solutionid", ConditionOperator.Equal, sol.Id),
                        //new ConditionExpression("componenttype", ConditionOperator.In, componentsTypes.ToArray())
                    }
                }
            };

            foreach (var e in service.RetrieveMultiple(qe).Entities)
            {
                components.Add(new CrmComponent()
                {
                    Id = e.Id,
                    ComponentType = (ComponentType)e.GetAttributeValue<OptionSetValue>("componenttype")?.Value,
                    RootComponentBehavior = e.GetAttributeValue<OptionSetValue>("rootcomponentbehavior")?.Value,
                    ObjectId = e.GetAttributeValue<Guid>("objectid"),
                    RootSolutionComponentId = e.GetAttributeValue<Guid>("rootsolutioncomponentid"),
                    SolutionId = (e.GetAttributeValue<EntityReference>("solutionid")).Id
                });


            }
            return components;
        }

        public static void TransferSolution(CrmOrganization sourceOrg, CrmOrganization targetOrg, string solutionUniqueName, Guid? importJobId = null)
        {
            Log.Text($"Transfering solution {solutionUniqueName}...");

            if (importJobId == null)
                importJobId = Guid.NewGuid();

            ExportSolutionRequest exportSolutionRequest = new ExportSolutionRequest();
            exportSolutionRequest.Managed = false;
            exportSolutionRequest.SolutionName = solutionUniqueName;

            ExportSolutionResponse exportSolutionResponse = (ExportSolutionResponse)sourceOrg.Service.Execute(exportSolutionRequest);

            byte[] exportXml = exportSolutionResponse.ExportSolutionFile;

            ImportSolutionRequest impSolReq = new ImportSolutionRequest()
            {
                CustomizationFile = exportXml,
                ImportJobId = (Guid)importJobId
            };

            targetOrg.Service.Execute(impSolReq);
        }
        public static void TransferSolutionFromFile(string filePath, CrmOrganization targetOrg)
        {
            byte[] exportXml = File.ReadAllBytes(filePath);

            ImportSolutionRequest impSolReq = new ImportSolutionRequest()
            {
                CustomizationFile = exportXml
            };

            targetOrg.Service.Execute(impSolReq);
        }

        public static string[] DownloadSolutionFile(CrmOrganization org, string uniqueName)
        {
            var qa = new QueryByAttribute("solution");
            qa.AddAttributeValue("uniquename", uniqueName);
            qa.ColumnSet = new ColumnSet("version");

            var entities = org.Service.RetrieveMultiple(qa).Entities;
            if (entities.Count != 0)
            {
                var version = entities[0].GetAttributeValue<string>("version");
                ExportSolutionRequest exportSolutionRequest = new ExportSolutionRequest();
                exportSolutionRequest.Managed = false;
                exportSolutionRequest.SolutionName = uniqueName;

                ExportSolutionResponse resp = (ExportSolutionResponse)org.Service.Execute(exportSolutionRequest);

                byte[] exportXml = resp.ExportSolutionFile;
                string filename = $"{uniqueName}_{version.Replace(".","_")}.zip";
                string filePath = Path.Combine("c:/temp", filename);
                File.WriteAllBytes(filePath, exportXml);

                return new string[] { filePath, version };

            }

            return null;

        }

    }
}