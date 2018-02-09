using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.ComponentModel
{
    public class CrmComponentCollection<T>
    {
        public string Name { get; set; }
        public List<KeyValuePair<string, string>> Properties { get; }

        public CrmComponentCollection()
        {
        }
        public CrmComponentCollection(string name, List<KeyValuePair<string, string>> properties)
        {
            Properties = properties;
            Name = name;
        }

        public List<T> Components = new List<T>();
    }
}
