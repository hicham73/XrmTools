using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Xrm.DevOPs.Manager.Config
{
    public class ManagerSection : ConfigurationSection
    {
        [ConfigurationProperty("projects")]
        public ProjectElementCollection Projects
        {
            get { return (ProjectElementCollection)this["projects"]; }
        }
    }
    public class ProjectElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ProjectElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProjectElement)element).Name;
        }
    }

    public class ProjectElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
        }
    }

    
}
