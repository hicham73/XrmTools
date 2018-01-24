using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.Manager.Helpers
{
    class OrganizationHelper
    {

        public static EntityCollection GetWorkflows(IOrganizationService service)
        {
            QueryExpression query = new QueryExpression("workflow");
            query.ColumnSet.AddColumns(new string[] {"mode", "primaryentity","name","scope","statecode","type",
                                                     "uniquename","solutionid","category"});
            query.Criteria.AddCondition("statecode", ConditionOperator.Equal, 1);
            query.Criteria.AddCondition("type", ConditionOperator.Equal, 1);
            //query.Criteria.AddCondition("category", ConditionOperator.In, 0, 3);

            return service.RetrieveMultiple(query);
        }

    }
}
