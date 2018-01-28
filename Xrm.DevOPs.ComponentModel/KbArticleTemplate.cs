using Microsoft.Xrm.Sdk;


namespace Xrm.DevOPs.ComponentModel
{
    public class KbArticleTemplateComponent : CrmComponent
    {
        Entity e;

        public KbArticleTemplateComponent(CrmComponent c, Entity e)
        {
            this.e = e;
            ComponentType = c.ComponentType;

        }

        new public string Name
        {
            get { return e.GetAttributeValue<string>("title"); }
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
