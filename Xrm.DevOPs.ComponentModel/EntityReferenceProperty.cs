using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.ComponentModel
{
    public class EntityReferenceProperty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityReferenceProperty()
        {

        }
    }
}
