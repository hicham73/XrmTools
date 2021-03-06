﻿using Microsoft.Xrm.Sdk;
using System;
using System.ComponentModel;

namespace Xrm.DevOPs.Manager.Component
{
    public class MailMergeTemplateComponent : CrmComponent
    {
        Entity e;

        public MailMergeTemplateComponent(CrmComponent c, Entity e)
        {
            this.e = e;
            Id = e.Id;
            ComponentType = c.ComponentType;
            Name = e.GetAttributeValue<string>("name");
            DisplayName = Name;
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Entity Entity { get { return e; } }

        override public string Text
        {
            get { return Name; }
        }
        public string Description
        {
            get { return e.GetAttributeValue<string>("description"); }
        }

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
        public DateTime? CreatedOn
        {
            get { return e.GetAttributeValue<DateTime>("createdon"); }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public EntityReference ModifiedBy
        {
            get { return e.GetAttributeValue<EntityReference>("modifiedby"); }
        }
        public DateTime? ModifiedOn
        {
            get { return e.GetAttributeValue<DateTime>("Modifiedon"); }
        }
    }
}
