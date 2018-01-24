
namespace Xrm.DevOPs.Manager.Wrappers
{
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Xrm.DevOPs.Manager.Entities;

    public enum CrmPluginIsolatable
    {
        Yes,
        No,
        Unknown
    }

    public enum CrmPluginType
    {
        Plugin,
        WorkflowActivity
    }

    public sealed class CrmPlugin
    {
        #region Public Fields

        public const string RelationshipTypeToStep = "plugintype_sdkmessageprocessingstep";

        #endregion Public Fields

        #region Private Fields

        private const string V3CalloutProxyTypeName = "Microsoft.Crm.Extensibility.V3CalloutProxyPlugin";
        private string m_assemblyName = null;
        private DateTime? m_createdOn = null;
        private int m_customizationLevel = 1;
        private string m_friendlyName;
        private bool m_friendlyNameIgnore;
        private CrmPluginIsolatable m_isolatable = CrmPluginIsolatable.Unknown;
        private DateTime? m_modifiedOn = null;
        private string m_name = null;
        private Guid m_pluginAssemblyId = Guid.Empty;
        private Guid m_pluginId = Guid.Empty;
        private CrmPluginType m_plugType = CrmPluginType.Plugin;
        private string m_typeName = null;
        private string m_workflowActivityGroupName = null;

        #endregion Private Fields

        #region Public Constructors

        #endregion Public Constructors

        #region Public Properties

        public Guid AssemblyId
        {
            get
            {
                return m_pluginAssemblyId;
            }
            set
            {
                if (value == m_pluginAssemblyId)
                {
                    return;
                }

                m_pluginAssemblyId = value;

            }
        }

        public string AssemblyName
        {
            get
            {
                return m_assemblyName;
            }

            set
            {
                m_assemblyName = value;
            }
        }

        public DateTime? CreatedOn
        {
            get
            {
                return m_createdOn;
            }
        }

        public int CustomizationLevel
        {
            get
            {
                return m_customizationLevel;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid CustomizationLevel specified");
                }

                m_customizationLevel = value;
            }
        }

        public string Description
        {
            get;
            set;
        }

        public Guid EntityId
        {
            get
            {
                return m_pluginId;
            }
        }

        public string EntityType
        {
            get
            {
                return Entities.PluginType.EntityLogicalName;
            }
        }

        public string FriendlyName
        {
            get
            {
                return m_friendlyName;
            }
            set
            {
                m_friendlyName = GenerateFriendlyName(value, out m_friendlyNameIgnore);
            }
        }

        public CrmPluginIsolatable Isolatable
        {
            get
            {
                return m_isolatable;
            }

            set
            {
                m_isolatable = value;
            }
        }

        public bool IsProfilerPlugin { get; set; }

        public bool IsSystemCrmEntity
        {
            get
            {
                return CustomizationLevel == 0;
            }
        }

        public DateTime? ModifiedOn
        {
            get
            {
                return m_modifiedOn;
            }
        }

        new public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
                Text = value;
            }
        }

        public Guid PluginId
        {
            get
            {
                return m_pluginId;
            }
            set
            {
                if (value == m_pluginId)
                {
                    return;
                }

                m_pluginId = value;

            }
        }

        public CrmPluginType PluginType
        {
            get
            {
                return m_plugType;
            }
            set
            {
                m_plugType = value;
            }
        }

        public string TypeName
        {
            get
            {
                return m_typeName;
            }

            set
            {
                m_typeName = value;
            }
        }

        public Dictionary<string, object> Values
        {
            get
            {
                Dictionary<string, object> valueList = new Dictionary<string, object>();
                valueList.Add("Id", PluginId);
                valueList.Add("Assembly", AssemblyName);
                valueList.Add("ModifiedOn", ModifiedOn);
                valueList.Add("FriendlyName", FriendlyName);
                valueList.Add("Name", Name);
                valueList.Add("TypeName", TypeName);
                valueList.Add("WorkflowActivityGroupName", WorkflowActivityGroupName);
                valueList.Add("Isolatable", Isolatable.ToString());
                valueList.Add("Description", Description);
                return valueList;
            }
        }

        public string WorkflowActivityGroupName
        {
            get
            {
                return m_workflowActivityGroupName;
            }
            set
            {
                m_workflowActivityGroupName = value;
            }
        }

        #endregion Public Properties


        #region Public Methods

        public Dictionary<string, object> GenerateCrmEntities()
        {
            PluginType plugin = new PluginType();
            if (PluginId != Guid.Empty)
            {
                plugin["plugintypeid"] = new Guid?();
                plugin["plugintypeid"] = PluginId;
            }

            if (AssemblyId != Guid.Empty)
            {
                plugin.PluginAssemblyId = new EntityReference();
                plugin.PluginAssemblyId.LogicalName = PluginAssembly.EntityLogicalName;
                plugin.PluginAssemblyId.Id = AssemblyId;
            }
            else
            {
                throw new ArgumentException("PluginAssembly has not been set", "plugin");
            }

            plugin.TypeName = TypeName;
            plugin.FriendlyName = m_friendlyName;

            plugin.Name = Name;
            plugin.Description = Description;
            plugin.WorkflowActivityGroupName = WorkflowActivityGroupName;

            Dictionary<string, object> entityList = new Dictionary<string, object>();
            entityList.Add(Entities.PluginType.EntityLogicalName, plugin);

            return entityList;
        }


        #endregion Public Methods

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

        private string GenerateFriendlyName(string newName, out bool ignoreFriendlyName)
        {
            if (string.IsNullOrEmpty(newName) ||
                string.Equals(m_typeName, newName, StringComparison.InvariantCultureIgnoreCase))
            {
                ignoreFriendlyName = true;
                if (m_friendlyNameIgnore)
                {
                    return m_friendlyName;
                }
                else
                {
                    return Guid.NewGuid().ToString();
                }
            }
            else
            {
                // Checking if name should be ignored
                var guidOutput = Guid.Empty;
                ignoreFriendlyName = Guid.TryParse(newName, out guidOutput);

                return newName;
            }
        }

        #endregion Private Methods
    }
}