using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.ComponentModel
{
    public class WorkflowComponent : CrmComponent
    {
        Entity e;

        public WorkflowComponent(Entity e)
        {
            this.e = e;
        }

        public string Name
        {
            get { return e.GetAttributeValue<string>("name"); }
        }
        override public string Text
        {
            get { return Name; }
        }
    }
}
