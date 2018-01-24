using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xrm.DevOPs.Manager
{
    public class Setting
    {

        public static CheckedListBox DiffComponentsFilter { get; set; }

        public static ListView DiffEntityFilter { get; set; }


        public static List<string> GetIncludedComponents()
        {
            var list = new List<string>();
            foreach (var c in DiffComponentsFilter.CheckedItems)
            {
                list.Add(c.ToString());

            }

            return list;
        }
        public static List<string> GetIncludedEntties()
        {
            var list = new List<string>();
            foreach (var c in DiffComponentsFilter.CheckedItems)
            {
                list.Add(c.ToString());

            }

            return list;
        }
    }
}
