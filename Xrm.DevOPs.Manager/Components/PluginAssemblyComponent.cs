﻿using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Xrm.DevOPs.Manager.Component
{
    public class PluginAssemblyComponent : CrmComponent
    {
        Entity e;
        public Entity PluginAssembly { get { return e;  } set { e = value;  } }

        public List<PluginTypeComponent> PluginTypeComponents = new List<PluginTypeComponent>();


        public PluginAssemblyComponent(CrmComponent c, Entity e)
        {
            this.e = e;
            Id = e.Id;
            ComponentType = c.ComponentType;
            Name = e.GetAttributeValue<string>("name");
            DisplayName = e.GetAttributeValue<string>("friendlyname");
        }

        #region Public Properties
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Entity Entity { get { return e; } }


        public Guid AssemblyId
        {
            get { return e.GetAttributeValue<Guid>("assemblyid"); }
        }

        public DateTime? CreatedOn
        {
            get { return e.GetAttributeValue<DateTime?>("assemblyid"); }
        }

        public string Culture
        {
            get { return e.GetAttributeValue<string>("culture"); }
        }

        public int CustomizationLevel
        {
            get { return e.GetAttributeValue<int>("customizationlevel"); }
        }

        public string Description { get { return e.GetAttributeValue<string>("description"); } }

        public bool Enabled { get { return e.GetAttributeValue<bool>("enabled"); } }

        public Guid EntityId
        {
            get { return e.GetAttributeValue<Guid>("entityid"); }
        }

        public string EntityType
        {
            get { return e.GetAttributeValue<string>("entitytype"); }
        }

        public int? IsolationMode { get { return e.GetAttributeValue<OptionSetValue>("isolationmode")?.Value; } }

        public bool IsProfilerAssembly { get { return e.GetAttributeValue<bool>("isprofilerassembly"); } }

        public bool IsSystemCrmEntity
        {
            get { return e.GetAttributeValue<bool>("issystementity"); }
        }

        public DateTime ModifiedOn { get { return e.GetAttributeValue<DateTime>("modifiedon"); } }

        override public string Text
        {
            get { return e.GetAttributeValue<string>("name"); }
        }
        public string PublicKeyToken { get { return e.GetAttributeValue<string>("publickeytoken"); } }

        public Version SdkVersion { get { return e.GetAttributeValue<Version>("sdkversion"); } }

        public string ServerFileName { get { return e.GetAttributeValue<string>("serverfilename"); } }

        public string SourceType { get; set; }

        public string Version { get; set; }

        public string Content { get; set; }

        public bool? IsCustomizable
        {
            get { return e.GetAttributeValue<ManagedProperty<bool>>("iscustomizable")?.Value; }
        }
        public bool IsManaged
        {
            get { return e.GetAttributeValue<bool>("ismanaged"); }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityReference CreatedBy
        {
            get { return e.GetAttributeValue<EntityReference>("createdby"); }
        }
       

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityReference ModifiedBy
        {
            get { return e.GetAttributeValue<EntityReference>("modifiedby"); }
        }

        #endregion Public Properties

    }
}
