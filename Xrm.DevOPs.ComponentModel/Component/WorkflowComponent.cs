using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.ComponentModel
{
    public class WorkflowComponent : CrmComponent
    {
        Entity e;

        public WorkflowComponent(CrmComponent c, Entity e)
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

        public bool AsyncAutoDelete
        {
            get { return e.GetAttributeValue<bool>("asyncautodelete"); }
            set { }
        }
        public string Uniquename
        {
            get { return e.GetAttributeValue<string>("uniquename"); }
            set { }
        }
        public bool SubProcess
        {
            get { return e.GetAttributeValue<bool>("subprocess"); }
            set { }
        }
        public string Description
        {
            get { return e.GetAttributeValue<string>("description"); }
            set { }
        }
        public string InputParameters
        {
            get { return e.GetAttributeValue<string>("inputparameters"); }
            set { }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public OptionSetValue BusinessProcessType
        {
            get { return e.GetAttributeValue<OptionSetValue>("businessprocesstype"); }
            set { }
        }
        public int? BusinessProcessTypeValue
        {
            get { return e.GetAttributeValue<OptionSetValue>("businessprocesstype")?.Value; }
            set { }
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public OptionSetValue Category
        {
            get { return e.GetAttributeValue<OptionSetValue>("category"); }
            set { }
        }
        public int? CategoryValue
        {
            get { return e.GetAttributeValue<OptionSetValue>("category")?.Value; }
            set { }
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
