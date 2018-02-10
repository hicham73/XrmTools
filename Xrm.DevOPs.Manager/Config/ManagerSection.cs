using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Xrm.DevOPs.Manager.Config
{
    public class ManagerConfig : ConfigurationSection
    {
        [ConfigurationProperty("projects")]
        public ProjectElementCollection Projects
        {
            get { return (ProjectElementCollection)this["projects"]; }
        }
        [ConfigurationProperty("tfs")]
        public TFSElement TFS
        {
            get { return (TFSElement)this["tfs"];  }
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

    public class TFSElement : ConfigurationElement
    {
        [ConfigurationProperty("url", IsKey = true, IsRequired = true)]
        public string Url
        {
            get { return (string)this["url"]; }
        }

        [ConfigurationProperty("username", IsKey = false, IsRequired = false)]
        public string Username
        {
            get { return (string)this["username"]; }
        }

        [ConfigurationProperty("password", IsKey = false, IsRequired = false)]
        public string Password
        {
            get { return (string)this["password"]; }
        }

    }


}
