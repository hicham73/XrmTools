using System;
using static Xrm.DevOPs.ComponentModel.EnumTypes;

namespace Xrm.DevOPs.ComponentModel
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
