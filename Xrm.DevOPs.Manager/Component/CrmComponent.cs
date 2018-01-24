using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Xrm.DevOPs.Manager.Util.EnumTypes;

namespace Xrm.DevOPs.Manager.Component
{
    public class CrmComponent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ComponentType ComponentType { get; set; }

        public Guid ObjectId { get; set; }

        public Int32? RootComponentBehavior { get; set; }

        public Guid SolutionId { get; set; }

        public Guid RootSolutionComponentId { get; set; }

        public virtual string Text { get; set; }
    }
}
