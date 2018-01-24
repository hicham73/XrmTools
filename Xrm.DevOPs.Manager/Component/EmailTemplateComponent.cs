using Microsoft.Xrm.Sdk;


namespace Xrm.DevOPs.Manager.Component
{
    public class EmailTemplateComponent : CrmComponent
    {
        Entity e;

        public EmailTemplateComponent(Entity e)
        {
            this.e = e;
        }

        new public string Name
        {
            get { return e.GetAttributeValue<string>("title"); }
        }
        override public string Text
        {
            get { return Name; }
        }
    }
}
