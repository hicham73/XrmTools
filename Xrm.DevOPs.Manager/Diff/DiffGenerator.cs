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
using Xrm.DevOPs.Manager.Util;

namespace Xrm.DevOPs.Manager.Diff
{
    internal class DiffGenerator
    {
        private List<string> _compared = new List<string>();
        private DiffResult _diffResult = new DiffResult(); 
        public IOrganizationService LeftService { get; set; }
        public IOrganizationService RightService { get; set; }
        public List<EntityInfo> Entities { get; set; } = new List<EntityInfo>();
        public DiffResult DiffResult { get { return _diffResult; } }
        public DiffResult Compare(List<string> options)
        {
            if (LeftService == null || RightService == null)
            {
                MessageBox.Show("You need to connect to and select 2 organizations");
                return null;
            }
            var includeEntities = false;
            var includeWorkflows = false;
            var includePlugins = false;
            var includePluginSteps = false;

            foreach (var comp in options)
            {
                switch (comp.ToString())
                {
                    case "Entities":
                    case "Attributes":
                    case "Forms":
                    case "Views":
                    case "Relationships":
                        includeEntities = true;
                        break;
                    case "Processes":
                        includeWorkflows = true;
                        break;
                    case "Plugins":
                        includePlugins = true;
                        break;
                    case "Plugins Steps":
                        includePluginSteps = true;
                        break;
                }
            }

            if (includeEntities)
                DiffEntities();

            if (includeWorkflows && !IsCompared("workflows"))
                DiffWorkflows();

            if (includePlugins && !IsCompared("plugins"))
                DiffPlugins();

            if(includePluginSteps && !IsCompared("pluginsteps"))
                DiffSdkMessageProcessingSteps();


            return _diffResult;

        }
        public void DiffEntities()
        {
            EntityDiffResult entityDiffRes = null;
            foreach (var item in Setting.DiffEntityFilter.CheckedItems)
            {
                var ei = (EntityInfo)((ListViewItem)item).Tag;
                if (entityDiffRes == null || !entityDiffRes.IsEmpty())
                    entityDiffRes = new EntityDiffResult(ei);

                DiffEntity(entityDiffRes);

                if (!entityDiffRes.IsEmpty())
                    _diffResult.Entities.Add(entityDiffRes);
                
            }
        }
        public void DiffEntity(EntityDiffResult edr)
        {
            if (IsCompared(edr.EntityInfo.LogicalName))
                return;

            var req = new RetrieveEntityRequest()
            {
                EntityFilters = EntityFilters.All,
                LogicalName = edr.EntityInfo.LogicalName,
                
            };

            var response1 = (RetrieveEntityResponse)LeftService.Execute(req);
            var response2 = (RetrieveEntityResponse)RightService.Execute(req);

            var emd1 = response1.EntityMetadata;
            var emd2 = response2.EntityMetadata;

            #region Attributes 

            
            foreach (var attr1 in emd1.Attributes)
            {
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

            #region Forms

            var qe = new QueryExpression("systemform");
            qe.Criteria.AddCondition(new ConditionExpression("objecttypecode", ConditionOperator.Equal, edr.EntityInfo.ObjectTypeCode));
            qe.ColumnSet = new ColumnSet("name", "publishedon", "type", "objecttypecode");

            var forms1 = LeftService.RetrieveMultiple(qe).Entities;
            var forms2 = RightService.RetrieveMultiple(qe).Entities;

            List<ComponentDiff<Entity>> formsDif = new List<ComponentDiff<Entity>>();
            foreach (var f1 in forms1)
            {
                var f2 = forms2.Where(x => x.Id == f1.Id).FirstOrDefault();
                if (f2 == null)
                {
                    formsDif.Add(new ComponentDiff<Entity>()
                    {
                        Name = f1.GetAttributeValue<string>("name"),
                        Left = f1,
                    });
                }
            }
            foreach (var f2 in forms2)
            {
                var f1 = forms1.Where(x => x.Id == f2.Id).FirstOrDefault();
                if (f1 == null)
                {
                    formsDif.Add(new ComponentDiff<Entity>()
                    {
                        Name = f2.GetAttributeValue<string>("name"),
                        Right = f2,
                    });
                }
            }



            #endregion

            #region Views

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
            }
            
        }
        public void DiffPlugins()
        {
            // Instantiate QueryExpression QEplugintype
            var qe = new QueryExpression("plugintype");
            qe.ColumnSet.AddColumns("friendlyname", "name", "assemblyname", "isworkflowactivity", "plugintypeid", "typename", "plugintypeidunique", "pluginassemblyid");

            var pls1 = LeftService.RetrieveMultiple(qe).Entities;
            var pls2 = RightService.RetrieveMultiple(qe).Entities;

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
