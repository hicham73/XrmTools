using Microsoft.Xrm.Sdk;


namespace Xrm.DevOPs.ComponentModel
{
    public class RoleComponent : CrmComponent
    {
        Entity e;

        public RoleComponent(CrmComponent c, Entity e)
        {
            ComponentType = c.ComponentType;
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
