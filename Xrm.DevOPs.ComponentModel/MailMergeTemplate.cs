using Microsoft.Xrm.Sdk;


namespace Xrm.DevOPs.ComponentModel
{
    public class MailMergeTemplateComponent : CrmComponent
    {
        Entity e;

        public MailMergeTemplateComponent(CrmComponent c, Entity e)
        {
            ComponentType = c.ComponentType;
            this.e = e;
        }

        new public string Name
        {
            get { return e.GetAttributeValue<string>("name"); }
        }
        public string Description
        {
            get { return e.GetAttributeValue<string>("descrkiption"); }
        }
        override public string Text
        {
            get { return Name; }
        }
    }
}
