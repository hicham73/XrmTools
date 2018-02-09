using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xrm.DevOPs.Manager.UI.Forms;
using Xrm.DevOPs.Manager.Util;

namespace Xrm.DevOPs.Manager.Diff
{
    public class DiffGenerator
    {
        private MainForm mainForm;
        private List<string> _compared = new List<string>();
        private DiffResult _diffResult = new DiffResult(); 
        public IOrganizationService LeftService { get; set; }
        public IOrganizationService RightService { get; set; }
        public List<EntityInfo> Entities { get; set; } = new List<EntityInfo>();
        public DiffResult DiffResult { get { return _diffResult; } }
        public DiffResult Compare(List<string> options)
        {
            mainForm = ((MainForm)Application.OpenForms[0]);
            

            if (LeftService == null || RightService == null)
            {
                MessageBox.Show("You need to connect to and select 2 organizations");
                return null;
            }

            DiffEntities();
            DiffForms();
            DiffViews();
            DiffWorkflows();
            DiffPlugins();
            DiffSdkMessageProcessingSteps();
            DiffTemapltes("template", _diffResult.Templates, new string[] { "title", "description" }, "title");
            DiffTemapltes("mailmergetemplate", _diffResult.Templates, new string[] { "name", "description" }, "name");
            DiffTemapltes("kbarticletemplate", _diffResult.Templates, new string[] { "title", "description" }, "title");
            DiffTemapltes("contracttemplate", _diffResult.Templates, new string[] { "name", "description" }, "name");
            DiffRoles();


            return _diffResult;

        }

        public void DiffEntities()
        {
            Dictionary<string, string> attributesData = new Dictionary<string, string>();
            RetrieveAllEntitiesRequest metaDataRequest = new RetrieveAllEntitiesRequest();
            metaDataRequest.EntityFilters = EntityFilters.All;
            
            // Execute the request.

            var entities1 = ((RetrieveAllEntitiesResponse)LeftService.Execute(metaDataRequest)).EntityMetadata;
            var entities2 = ((RetrieveAllEntitiesResponse)RightService.Execute(metaDataRequest)).EntityMetadata;

            mainForm.ProgressStart("Entities", 1, entities1.Length);

            foreach (var emd1 in entities1)
            {

                var emd2 = entities2.Where(x => x.LogicalName == emd1.LogicalName).FirstOrDefault();

                if(emd2 != null && emd1.IsCustomizable.Value)
                    DiffEntity(emd1, emd2);


                mainForm.ProgressPerformStep();
            }

        }

        public void DiffEntity(EntityMetadata emd1, EntityMetadata emd2)
        {
            var edr = new EntityDiffResult(new EntityInfo() {
               LogicalName = emd1.LogicalName,
                ObjectTypeCode = emd1.ObjectTypeCode.Value,
                IsCustom = emd1.IsCustomEntity.Value,
                DisplayName = emd1.DisplayName?.UserLocalizedLabel?.Label

            });

            #region Attributes 

            
            foreach (var attr1 in emd1.Attributes)
            {
                //if (attr1.LogicalName != "new_field11")
                //    continue;

                var attr2 = emd2.Attributes.Where(x => x.LogicalName == attr1.LogicalName).FirstOrDefault<AttributeMetadata>();

                if (attr2 != null)
                {
                    if (attr1.AttributeType != attr2.AttributeType)
                    {
                        edr.Attributes.Add(new ComponentDiff<AttributeMetadata>()
                        {
                            Name = attr2.LogicalName,
                            Left = attr1,
                            LRI = 12
                        });
                    }
                }
                else
                {
                    edr.Attributes.Add(new ComponentDiff<AttributeMetadata>()
                    {
                        Name = attr1.LogicalName,
                        Left = attr1,
                        Right = attr2,
                        LRI = 1
                    });
                }
            }


            foreach (var attr2 in emd2.Attributes)
            {
                var attr1 = emd1.Attributes.Where(x => x.LogicalName == attr2.LogicalName).FirstOrDefault<AttributeMetadata>();

                if (attr1 == null)
                {
                    edr.Attributes.Add(new ComponentDiff<AttributeMetadata>()
                    {
                        Name = attr2.LogicalName,
                        Right = attr2,
                        LRI = 1
                    });
                }
            }

            

            #endregion

            #region 1N Relationships

            List<ComponentDiff<OneToManyRelationshipMetadata>> oneToManyRelashionships = new List<ComponentDiff<OneToManyRelationshipMetadata>>();
            if (emd1.OneToManyRelationships != null)
            {
                foreach (var rel1 in emd1.OneToManyRelationships)
                {
                    var exist = emd2.OneToManyRelationships?.Where(x => x.SchemaName == rel1.SchemaName).Any();

                    if (exist == null || !(bool)exist)
                    {
                        oneToManyRelashionships.Add(new ComponentDiff<OneToManyRelationshipMetadata>()
                        {
                            Name = rel1.SchemaName,
                            Left = rel1,
                            LRI = 1
                        });
                    }
                }
            }
            if (emd2.OneToManyRelationships != null)
            {
                foreach (var rel2 in emd2.OneToManyRelationships)
                {
                    var exist = emd1.OneToManyRelationships?.Where(x => x.SchemaName == rel2.SchemaName).Any();
                    if (exist == null || !(bool)exist)
                    {
                        oneToManyRelashionships.Add(new ComponentDiff<OneToManyRelationshipMetadata>()
                        {
                            Name = rel2.SchemaName,
                            Right = rel2,
                            LRI = 1
                        });
                    }
                }
            }


            

            #endregion

            #region NN Relationships

            List<ComponentDiff<ManyToManyRelationshipMetadata>> manyToManyRelationships = new List<ComponentDiff<ManyToManyRelationshipMetadata>>();
            if (emd1.ManyToManyRelationships != null)
            {
                foreach (var rel1 in emd1.ManyToManyRelationships)
                {
                    var exist = emd2.ManyToManyRelationships?.Where(x => x.SchemaName == rel1.SchemaName).Any();

                    if (exist == null || !(bool)exist)
                    {
                        manyToManyRelationships.Add(new ComponentDiff<ManyToManyRelationshipMetadata>()
                        {
                            Left = rel1,
                            Name = rel1.SchemaName,
                            LRI = 1
                        });
                    }
                }
            }
            if (emd2.ManyToManyRelationships != null)
            {
                foreach (var rel2 in emd2.ManyToManyRelationships)
                {
                    var exist = emd1.ManyToManyRelationships?.Where(x => x.SchemaName == rel2.SchemaName).Any();
                    if (exist == null || !(bool)exist)
                    {
                        manyToManyRelationships.Add(new ComponentDiff<ManyToManyRelationshipMetadata>()
                        {
                            Name = rel2.SchemaName,
                            Right = rel2,
                            LRI = 1
                        });
                    }
                }
            }

            #endregion

            
            if(!edr.IsEmpty())
                _diffResult.Entities.Add(edr);

        }

        public void DiffForms()
        {
            #region Forms

            var qe = new QueryExpression("systemform");
            qe.Criteria.AddCondition(new ConditionExpression("ismanaged", ConditionOperator.Equal, false));
            qe.ColumnSet = new ColumnSet("name", "publishedon", "type", "objecttypecode");

            var forms1 = LeftService.RetrieveMultiple(qe).Entities;
            var forms2 = RightService.RetrieveMultiple(qe).Entities;

            List<ComponentDiff<Entity>> formsDiff = new List<ComponentDiff<Entity>>();

            mainForm.ProgressStart("Forms", 1, forms1.Count + forms2.Count);
            foreach (var f1 in forms1)
            {
                var f2 = forms2.Where(x => x.Id == f1.Id).FirstOrDefault();
                if (f2 == null)
                {
                    _diffResult.Forms.Add(new ComponentDiff<Entity>()
                    {
                        EntityName = f1.GetAttributeValue<string>("objecttypecode"),
                        Name = f1.GetAttributeValue<string>("name"),
                        Left = f1,
                    });
                }
                mainForm.ProgressPerformStep();

            }
            foreach (var f2 in forms2)
            {
                var f1 = forms1.Where(x => x.Id == f2.Id).FirstOrDefault();
                if (f1 == null)
                {
                    _diffResult.Forms.Add(new ComponentDiff<Entity>()
                    {
                        EntityName = f2.GetAttributeValue<string>("objecttypecode"),
                        Name = f2.GetAttributeValue<string>("name"),
                        Right = f2,
                    });
                }
                mainForm.ProgressPerformStep();
            }



            #endregion

        }

        public void DiffViews()
        {

            #region Views
            // Instantiate QueryExpression QEsavedquery
            var qe = new QueryExpression("savedquery");
            qe.Criteria.AddCondition(new ConditionExpression("iscustom", ConditionOperator.Equal, true));
            qe.Criteria.AddCondition(new ConditionExpression("iscustomizable", ConditionOperator.Equal, true));
            qe.Criteria.AddCondition(new ConditionExpression("ismanaged", ConditionOperator.Equal, false));
            qe.ColumnSet.AddColumns("name", "querytype", "returnedtypecode", "iscustom");

            var views1 = LeftService.RetrieveMultiple(qe).Entities;
            var views2 = RightService.RetrieveMultiple(qe).Entities;

            List<ComponentDiff<Entity>> viewsDiff = new List<ComponentDiff<Entity>>();
            mainForm.ProgressStart("Views", 1, views1.Count + views2.Count);
            foreach (var v1 in views1)
            {
                var v2 = views2.Where(x => x.GetAttributeValue<string>("name") == v1.GetAttributeValue<string>("name")).FirstOrDefault();
                if (v2 == null)
                {
                    _diffResult.Views.Add(new ComponentDiff<Entity>()
                    {
                        EntityName = v1.GetAttributeValue<string>("returnedtypecode"),
                        Name = v1.GetAttributeValue<string>("name"),
                        Left = v1,
                    });
                }
                mainForm.ProgressPerformStep();

            }
            foreach (var v2 in views2)
            {
                var v1 = views1.Where(x => x.GetAttributeValue<string>("name") == v2.GetAttributeValue<string>("name")).FirstOrDefault();
                if (v1 == null)
                {
                    _diffResult.Views.Add(new ComponentDiff<Entity>()
                    {
                        EntityName = v2.GetAttributeValue<string>("returnedtypecode"),
                        Name = v2.GetAttributeValue<string>("name"),
                        Right = v2,
                    });
                }
                mainForm.ProgressPerformStep();

            }

            #endregion
        }

        public void DiffWorkflows()
        {
            var qe = new QueryExpression("workflow");
            qe.ColumnSet.AddColumns(new string[] { "mode", "primaryentity", "name", "statecode", "type", "uniquename", "category" });
            qe.Criteria.AddCondition("statecode", ConditionOperator.Equal, 1);
            qe.Criteria.AddCondition("type", ConditionOperator.Equal, 1);
            //query.Criteria.AddCondition("category", ConditionOperator.In, 0, 3);

            var wfls1 = LeftService.RetrieveMultiple(qe).Entities;
            var wfls2 = RightService.RetrieveMultiple(qe).Entities;
            mainForm.ProgressStart("Workflows", 1, wfls1.Count + wfls2.Count);

            foreach (var w1 in wfls1)
            {
                var w2 = wfls2.Where(x => x.Id == w1.Id).FirstOrDefault();
                if (w2 == null)
                {
                    _diffResult.Workflows.Add(new ComponentDiff<Entity>()
                    {
                        Name = w1.GetAttributeValue<string>("name"),
                        Left = w1,
                    });
                }
                mainForm.ProgressPerformStep();
            }
            foreach (var w2 in wfls2)
            {
                var w1 = wfls1.Where(x => x.Id == w2.Id).FirstOrDefault();
                if (w1 == null)
                {
                    _diffResult.Workflows.Add(new ComponentDiff<Entity>()
                    {
                        Name = w2.GetAttributeValue<string>("name"),
                        Right = w2,
                    });
                }
                mainForm.ProgressPerformStep();
            }
        }
        public void DiffPlugins()
        {
            // Instantiate QueryExpression QEplugintype
            var qe = new QueryExpression("plugintype");
            qe.ColumnSet.AddColumns("friendlyname", "name", "assemblyname", "isworkflowactivity", "plugintypeid", "typename", "plugintypeidunique", "pluginassemblyid");

            var pls1 = LeftService.RetrieveMultiple(qe).Entities;
            var pls2 = RightService.RetrieveMultiple(qe).Entities;

            mainForm.ProgressStart("Plugins", 1, pls1.Count + pls2.Count);
            foreach (var p1 in pls1)
            {
                var p2 = pls2.Where(x => x.GetAttributeValue<string>("name") == p1.GetAttributeValue<string>("name")).FirstOrDefault();
                if (p2 == null)
                {
                    _diffResult.Plugins.Add(new ComponentDiff<Entity>()
                    {
                        Name = p1.GetAttributeValue<string>("name"),
                        Left = p1,
                    });
                }
                mainForm.ProgressPerformStep();
            }
            foreach (var p2 in pls2)
            {
                var p1 = pls1.Where(x => x.GetAttributeValue<string>("name") == p2.GetAttributeValue<string>("name")).FirstOrDefault();
                if (p1 == null)
                {
                    _diffResult.Plugins.Add(new ComponentDiff<Entity>()
                    {
                        Name = p2.GetAttributeValue<string>("name"),
                        Right = p2,
                    });
                }
                mainForm.ProgressPerformStep();
            }

        }
        public void DiffSdkMessageProcessingSteps()
        {

            var qe = new QueryExpression("sdkmessageprocessingstep");
            qe.TopCount = 50;
            qe.ColumnSet.AddColumns("statecode", "name", "sdkmessageid", "ismanaged", "plugintypeid", "sdkmessageprocessingstepid");
            qe.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, false);
            var pluginTypeLink = qe.AddLink("plugintype", "plugintypeid", "plugintypeid");
            pluginTypeLink.EntityAlias = "plugintype";
            pluginTypeLink.Columns.AddColumns("name");


            var smpss1 = LeftService.RetrieveMultiple(qe).Entities;
            var smpss2 = RightService.RetrieveMultiple(qe).Entities;

            mainForm.ProgressStart("Messages Processing Steps", 1, smpss1.Count + smpss2.Count);
            foreach (var smps1 in smpss1)
            {
                var s2 = smpss2.Where(x => x.GetAttributeValue<string>("name") == smps1.GetAttributeValue<string>("name")).FirstOrDefault();
                if (s2 == null)
                {
                    _diffResult.SdkMessageProcessingSteps.Add(new ComponentDiff<Entity>()
                    {
                        Name = smps1.GetAttributeValue<string>("name"),
                        Left = smps1,
                    });
                }
                mainForm.ProgressPerformStep();
            }
            foreach (var smps2 in smpss2)
            {
                var s1 = smpss1.Where(x => x.GetAttributeValue<string>("name") == smps2.GetAttributeValue<string>("name")).FirstOrDefault();
                if (s1 == null)
                {
                    _diffResult.SdkMessageProcessingSteps.Add(new ComponentDiff<Entity>()
                    {
                        Name = smps2.GetAttributeValue<string>("name"),
                        Right = smps2,
                    });
                }
                mainForm.ProgressPerformStep();
            }
        }
        public void DiffTemapltes(string entityName, List<ComponentDiff<Entity>> diffList, string[] columns, string key)
        {
            var qe = new QueryExpression(entityName);
            qe.ColumnSet.AddColumns(columns);
            qe.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, false);


            var temps1 = LeftService.RetrieveMultiple(qe).Entities;
            var temps2 = RightService.RetrieveMultiple(qe).Entities;

            foreach (var temp1 in temps1)
            {
                var s2 = temps2.Where(x => x.GetAttributeValue<string>(key) == temp1.GetAttributeValue<string>(key)).FirstOrDefault();
                if (s2 == null)
                {
                    diffList.Add(new ComponentDiff<Entity>()
                    {
                        EntityName = entityName,
                        Name = temp1.GetAttributeValue<string>(key),
                        Left = temp1,
                    });
                }
            }
            foreach (var temp2 in temps2)
            {
                var s1 = temps1.Where(x => x.GetAttributeValue<string>(key) == temp2.GetAttributeValue<string>(key)).FirstOrDefault();
                if (s1 == null)
                {
                    diffList.Add(new ComponentDiff<Entity>()
                    {
                        EntityName = entityName,
                        Name = temp2.GetAttributeValue<string>(key),
                        Right = temp2,
                    });
                }
            }
        }
        public void DiffRoles()
        {
            // Instantiate QueryExpression QEplugintype
            var qe = new QueryExpression("role");
            qe.ColumnSet.AddColumns("name");

            var roles1 = LeftService.RetrieveMultiple(qe).Entities;
            var roles2 = RightService.RetrieveMultiple(qe).Entities;

            mainForm.ProgressStart("Security Roles", 1, roles1.Count + roles2.Count);
            foreach (var r1 in roles1)
            {
                var r2 = roles2.Where(x => x.Id == r1.Id).FirstOrDefault();
                if (r2 == null)
                {
                    _diffResult.Roles.Add(new ComponentDiff<Entity>()
                    {
                        Name = r1.GetAttributeValue<string>("name"),
                        Left = r1,
                    });
                }
                mainForm.ProgressPerformStep();
            }
            foreach (var r2 in roles2)
            {
                var r1 = roles1.Where(x => x.Id == r2.Id).FirstOrDefault();
                if (r1 == null)
                {
                    _diffResult.Roles.Add(new ComponentDiff<Entity>()
                    {
                        Name = r2.GetAttributeValue<string>("name"),
                        Right = r2,
                    });
                }
                mainForm.ProgressPerformStep();
            }

        }
        public bool IsCompared(string name)
        {
            if (_compared.Contains(name))
                return true;

            _compared.Add(name);
            return false;
        }
    }

    public class EntityInfo
    {
        public string LogicalName { get; set; }
        public int ObjectTypeCode { get; set; }
        public bool IsCustom { get; set; }
        public bool IsCustomEntity { get; internal set; }
        public string DisplayName { get; internal set; }
    }

}
