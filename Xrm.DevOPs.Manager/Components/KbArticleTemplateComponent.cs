﻿using Microsoft.Xrm.Sdk;
using System;
using System.ComponentModel;

namespace Xrm.DevOPs.Manager.Component
{
    public class KbArticleTemplateComponent : CrmComponent
    {
        Entity e;

        public KbArticleTemplateComponent(CrmComponent c, Entity e)
        {
            this.e = e;
            Id = e.Id;
            ComponentType = c.ComponentType;
            Name = e.GetAttributeValue<string>("title");
            DisplayName = Name;

        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Entity Entity { get { return e; } }


        public string Description
        {
            get { return e.GetAttributeValue<string>("description"); }
        }
        override public string Text
        {
            get { return Name; }
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
