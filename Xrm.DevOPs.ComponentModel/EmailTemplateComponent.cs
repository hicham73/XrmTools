using Microsoft.Xrm.Sdk;


namespace Xrm.DevOPs.ComponentModel
{
    public class EmailTemplateComponent : CrmComponent
    {
        Entity e;

        public EmailTemplateComponent(CrmComponent c, Entity e)
        {
            ComponentType = c.ComponentType;

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
