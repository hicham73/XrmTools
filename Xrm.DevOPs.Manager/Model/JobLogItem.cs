using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.Manager.Model
{
    public class JobLogItem
    {

        public string DateTime { get; set; }
        public string ItemType { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string LocalizedName { get; set; }
        public string OriginalName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorText { get; set; }
    }
}
