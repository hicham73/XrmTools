namespace Xrm.DevOPs.Manager.Wrappers
{
    using Entities;
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    public enum CrmAssemblyIsolationMode
    {
        None = 1,
        Sandbox = 2
    }

    public enum CrmAssemblySourceType
    {
        Database = 0,
        Disk = 1,
        GAC = 2
    }

    [Serializable]
    public sealed class CrmPluginAssembly
    {
        #region Public Fields

        public const string RelationshipAssemblyToType = "pluginassembly_plugintype";

        #endregion Public Fields

        #region Private Fields

        private static CrmEntityColumn[] m_entityColumns = null;
        private Guid m_assemblyId = Guid.Empty;
        private string m_Name = null;
        private List<CrmPlugin> m_pluginList = new List<CrmPlugin>();

        #endregion Private Fields

        #region Public Constructors

        public CrmPluginAssembly(string name)
        {
            Name = name;
        }


        #endregion Public Constructors

        #region Public Properties

        public static CrmEntityColumn[] Columns
        {
            get
            {
                if (m_entityColumns == null)
                {
                    m_entityColumns = new CrmEntityColumn[] {
                        new CrmEntityColumn("Name", "Name", typeof(string)),
                        new CrmEntityColumn("Description", "Description", typeof(string)),
                        new CrmEntityColumn("ModifiedOn", "Modified On", typeof(string)),
                        new CrmEntityColumn("SourceType", "Source", typeof(string)),
                        new CrmEntityColumn("Version", "Version", typeof(string)),
                        new CrmEntityColumn("Path", "Path", typeof(string)),
                        new CrmEntityColumn("PublicKeyToken", "Public Key Token", typeof(string)),
                        new CrmEntityColumn("Culture", "Culture", typeof(string)),
                        new CrmEntityColumn("IsolationMode", "Isolation Mode", typeof(string)),
                        new CrmEntityColumn("Enabled", "Enabled", typeof(bool)),
                        new CrmEntityColumn("Id", "AssemblyId", typeof(Guid)),
                        };
                }

                return m_entityColumns;
            }
        }

        public Guid AssemblyId
        {
            get
            {
                return m_assemblyId;
            }
            set
            {
                if (value == m_assemblyId)
                {
                    return;
                }

                m_assemblyId = value;

                if (m_pluginList != null)
                {
                    foreach (CrmPlugin plugin in m_pluginList)
                    {
                        plugin.AssemblyId = value;
                    }
                }
            }
        }

        public DateTime? CreatedOn { get; private set; }

        public string Culture { get; set; }
       
        public string Description { get; set; }

        public bool Enabled { get; set; }

        public Guid EntityId
        {
            get
            {
                return AssemblyId;
            }
        }

        public string EntityType
        {
            get
            {
                return PluginAssembly.EntityLogicalName;
            }
        }

        public CrmAssemblyIsolationMode IsolationMode { get; set; }

        public bool IsProfilerAssembly { get; set; }

        public DateTime? ModifiedOn { get; private set; }

        public string Name { get { } } 

        public string PublicKeyToken { get; set; }

        public List<CrmPlugin> Plugins
        {
            get
            {
                return m_pluginList;
            }
        }
        public Version SdkVersion { get; set; }

        public string ServerFileName { get; set; }

        public CrmAssemblySourceType SourceType { get; set; }

        public Dictionary<string, object> Values
        {
            get
            {
                Dictionary<string, object> valueList = new Dictionary<string, object>();
                valueList.Add("Id", AssemblyId);
                valueList.Add("Description", String.IsNullOrEmpty(Description) ? string.Empty : Description);
                valueList.Add("Name", Name);
                valueList.Add("ModifiedOn", (ModifiedOn.HasValue ? ModifiedOn.ToString() : ""));
                valueList.Add("SourceType", SourceType.ToString());
                valueList.Add("Version", ConvertNullStringToEmpty(Version));
                valueList.Add("Path", ConvertNullStringToEmpty(ServerFileName));
                valueList.Add("PublicKeyToken", ConvertNullStringToEmpty(PublicKeyToken));
                valueList.Add("Culture", ConvertNullStringToEmpty(Culture));

                if (CrmAssemblyIsolationMode.Sandbox == IsolationMode)
                {
                    valueList.Add("IsolationMode", "Sandbox");
                }
                else
                {
                    valueList.Add("IsolationMode", "None");
                }

                valueList.Add("Enabled", Enabled);

                return valueList;
            }
        }

        internal void AddPlugin(CrmPlugin crmPlugin)
        {
            m_pluginList.Add(crmPlugin);
        }

        public string Version { get; set; }

        public string Content { get; set; }

        #endregion Public Properties



        #region Private Methods

        private string ConvertNullStringToEmpty(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return string.Empty;
            }
            else
            {
                return val;
            }
        }

        #endregion Private Methods
    }
}