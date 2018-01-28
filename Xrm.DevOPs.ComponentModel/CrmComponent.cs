using System;
using System.ComponentModel;
using static Xrm.DevOPs.ComponentModel.EnumTypes;

namespace Xrm.DevOPs.ComponentModel
{
    public class CrmComponent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Browsable(false)]
        public ComponentType ComponentType { get; set; }

        [Browsable(false)]
        public Guid ObjectId { get; set; }

        [Browsable(false)]
        public Int32? RootComponentBehavior { get; set; }

        [Browsable(false)]
        public Guid SolutionId { get; set; }

        [Browsable(false)]
        public Guid RootSolutionComponentId { get; set; }

        public virtual string Text { get; set; }
    }
}
