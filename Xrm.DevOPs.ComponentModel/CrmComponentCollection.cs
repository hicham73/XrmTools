using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.ComponentModel
{
    public class CrmComponentCollection<T>
    {

        public CrmComponentCollection(List<T> components)
        {
            Components = components;
        }

        public CrmComponentCollection()
        {
        }

        public List<T> Components = new List<T>();
    }
}
