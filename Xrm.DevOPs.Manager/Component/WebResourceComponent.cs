using Microsoft.Xrm.Sdk;


namespace Xrm.DevOPs.Manager.Component
{
    public class WebResourceComponent : CrmComponent
    {
        Entity e;

        public WebResourceComponent(Entity e)
        {
            this.e = e;
        }

        public string Name
        {
            get { return e.GetAttributeValue<string>("name"); }
        }
        override public string Text
        {
            get { return Name; }
        }
    }
}
