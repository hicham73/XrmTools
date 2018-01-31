using Microsoft.Xrm.Sdk;


namespace Xrm.DevOPs.Manager.Component
{
    public class MailMergeTemplateComponent : CrmComponent
    {
        Entity e;

        public MailMergeTemplateComponent(Entity e)
        {
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
