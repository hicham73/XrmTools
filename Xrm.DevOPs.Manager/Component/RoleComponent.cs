using Microsoft.Xrm.Sdk;


namespace Xrm.DevOPs.Manager.Component
{
    public class RoleComponent : CrmComponent
    {
        Entity e;

        public RoleComponent(Entity e)
        {
            this.e = e;
        }

        new public string Name
        {
            get { return e.GetAttributeValue<string>("name"); }
        }
        override public string Text
        {
            get { return Name; }
        }
    }
}
