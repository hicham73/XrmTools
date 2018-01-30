using Microsoft.Xrm.Sdk;
using System;
using System.ComponentModel;

namespace Xrm.DevOPs.ComponentModel
{
    public class PluginTypeComponent : CrmComponent
    {

        Entity e;
        Entity PluginType { get { return e; } set { e = value; } }

        public PluginTypeComponent(CrmComponent c, Entity e)
        {
            this.e = e;
            Id = e.Id;
            Name = e.GetAttributeValue<string>("name");
            DisplayName = e.GetAttributeValue<string>("friendlyname");
            ComponentType = c.ComponentType;
        }
        #region Public Properties

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Entity Entity { get { return e; } }

        public string AssemblyName
        {
            get
            {
                return e.GetAttributeValue<string>("assemblyname");
            }
        }


        public OptionSetValue ComponentState
        {
            get
            {
                return e.GetAttributeValue<OptionSetValue>("componentstate");
            }
        }


        [TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityReference CreatedBy
        {
            get
            {
                return e.GetAttributeValue<EntityReference>("createdby");
            }
        }

        public DateTime? CreatedOn
        {
            get
            {
                return e.GetAttributeValue<DateTime?>("createdon");
            }
        }


        [TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityReference CreatedOnBehalfBy
        {
            get
            {
                return e.GetAttributeValue<EntityReference>("createdonbehalfby");
            }
        }


        public string Culture
        {
            get
            {
                return e.GetAttributeValue<string>("culture");
            }
        }


        public int? CustomizationLevel
        {
            get
            {
                return e.GetAttributeValue<int?>("customizationlevel");
            }
        }


        public string Description
        {
            get
            {
                return e.GetAttributeValue<string>("description");
            }
            set
            {

                SetAttributeValue("description", value);
            }
        }


        public string FriendlyName
        {
            get
            {
                return e.GetAttributeValue<string>("friendlyname");
            }
            set
            {
                SetAttributeValue("friendlyname", value);
            }
        }


        public bool? IsManaged
        {
            get
            {
                return e.GetAttributeValue<bool?>("ismanaged");
            }
        }

        public bool? IsWorkflowActivity
        {
            get
            {
                return e.GetAttributeValue<bool?>("isworkflowactivity");
            }
        }


        public int? Major
        {
            get
            {
                return e.GetAttributeValue<int?>("major");
            }
        }


        public int? Minor
        {
            get
            {
                return e.GetAttributeValue<int?>("minor");
            }
        }


        [TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityReference ModifiedBy
        {
            get
            {
                return e.GetAttributeValue<EntityReference>("modifiedby");
            }
        }


        public DateTime? ModifiedOn
        {
            get
            {
                return e.GetAttributeValue<DateTime?>("modifiedon");
            }
        }


        [TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityReference ModifiedOnBehalfBy
        {
            get
            {
                return e.GetAttributeValue<EntityReference>("modifiedonbehalfby");
            }
        }


        override public string Text
        {
            get
            {
                return e.GetAttributeValue<string>("typename").Replace($"{ AssemblyName}.","");
            }
            set
            {
                e["name"] = value;
            }
        }


        [TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityReference OrganizationId
        {
            get
            {
                return e.GetAttributeValue<EntityReference>("organizationid");
            }
        }

        public DateTime? OverwriteTime
        {
            get
            {
                return e.GetAttributeValue<DateTime?>("overwritetime");
            }
        }


        [TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityReference PluginAssemblyId
        {
            get
            {
                return e.GetAttributeValue<EntityReference>("pluginassemblyid");
            }
            set
            {

                SetAttributeValue("pluginassemblyid", value);
            }
        }

        public Guid? PluginTypeId
        {
            get
            {
                return e.GetAttributeValue<Guid?>("plugintypeid");
            }
            set
            {
                SetAttributeValue("plugintypeid", value);
                if (value.HasValue)
                {
                    base.Id = value.Value;
                }
                else
                {
                    base.Id = Guid.Empty;
                }
            }
        }

        public Guid? PluginTypeIdUnique
        {
            get
            {
                return e.GetAttributeValue<Guid?>("plugintypeidunique");
            }
        }


        public string PublicKeyToken
        {
            get
            {
                return e.GetAttributeValue<string>("publickeytoken");
            }
        }


        public string TypeName
        {
            get
            {
                return e.GetAttributeValue<string>("typename");
            }
            set
            {
                SetAttributeValue("typename", value);
            }
        }

        public string Version
        {
            get
            {
                return e.GetAttributeValue<string>("version");
            }
        }

        public long? VersionNumber
        {
            get
            {
                return e.GetAttributeValue<long?>("versionnumber");
            }
        }

        public string WorkflowActivityGroupName
        {
            get
            {
                return e.GetAttributeValue<string>("workflowactivitygroupname");
            }
            set
            {
                SetAttributeValue("workflowactivitygroupname", value);
            }
        }

        private void SetAttributeValue(string name, Object value)
        {
            e[name] = value;
        }


        public bool? IsCustomizable
        {
            get { return e.GetAttributeValue<ManagedProperty<bool>>("iscustomizable")?.Value; }
        }

        #endregion Public Properties

    }
}
