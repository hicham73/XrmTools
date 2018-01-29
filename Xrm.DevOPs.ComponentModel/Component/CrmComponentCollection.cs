using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.ComponentModel
{
    public class CrmComponentCollection<T>
    {
        public List<KeyValuePair<string, string>> Properties { get; }

        public CrmComponentCollection(List<KeyValuePair<string, string>> properties)
        {
            Properties = properties;
        }

        public CrmComponentCollection()
        {
        }

        public List<T> Components = new List<T>();
    }
}
