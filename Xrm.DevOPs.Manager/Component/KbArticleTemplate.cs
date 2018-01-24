using Microsoft.Xrm.Sdk;


namespace Xrm.DevOPs.Manager.Component
{
    public class KbArticleTemplateComponent : CrmComponent
    {
        Entity e;

        public KbArticleTemplateComponent(Entity e)
        {
            this.e = e;
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
