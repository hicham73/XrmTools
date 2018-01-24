using Microsoft.Xrm.Sdk;


namespace Xrm.DevOPs.ComponentModel
{
    public class ContractTemplateComponent : CrmComponent
    {
        Entity e;

        public ContractTemplateComponent(Entity e)
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
