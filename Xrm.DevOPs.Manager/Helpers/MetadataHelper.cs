using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.Manager.Helpers
{
    class MetadataHelper
    {
        public static List<OptionSetMetadataBase> GetOptionSetMetadata(IOrganizationService service)
        {
            RetrieveAllOptionSetsRequest req = new RetrieveAllOptionSetsRequest();
            RetrieveAllOptionSetsResponse res = (RetrieveAllOptionSetsResponse)service.Execute(req);
            return res.OptionSetMetadata.ToList();
        }

        
    }
}
