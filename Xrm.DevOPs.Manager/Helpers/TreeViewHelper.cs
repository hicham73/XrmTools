using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xrm.DevOPs.Manager.Util;

namespace Xrm.DevOPs.Manager.Helpers
{
    public class TreeViewHelper
    {
        public static TreeNode SearchTree(TreeNodeCollection nodes, string name, EnumTypes.RecursionType recursionType, EnumTypes.SearchPaternType searchType)
        {
            var match = false;
            foreach (TreeNode n in nodes)
            {
                switch (searchType)
                {
                    case EnumTypes.SearchPaternType.Contains:
                        match = n.Name.Contains(name);
                        break;
                    case EnumTypes.SearchPaternType.EndsWith:
                        match = n.Name.EndsWith(name);
                        break;
                    case EnumTypes.SearchPaternType.Exact:
                        match = n.Name == name;
                        break;
                    case EnumTypes.SearchPaternType.StartsWith:
                        match = n.Name.StartsWith(name);
                        break;
                }
                if (match)
                    return n;
                else if (recursionType == EnumTypes.RecursionType.Full)
                {
                    var cn = SearchTree(n.Nodes, name, recursionType, searchType);
                    if (cn != null)
                        return cn;
                }
                    

            }

            return null;

        }
    }
}
