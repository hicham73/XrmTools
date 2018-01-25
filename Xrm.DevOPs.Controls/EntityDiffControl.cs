using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Xrm.DevOPs.Controls
{
    public partial class EntityDiffControl: UserControl
    {
        List<ResultView> resultViews;

        public EntityDiffControl()
        {
            InitializeComponent();
            resultViews = new List<ResultView>() {
                new ResultView(gbAttributes, lvAttributes),
                new ResultView(gbManyToMany, lvManyToManyRelationships),
                new ResultView(gbOneToMany, lvOneToManyRelationships),
                new ResultView(gbManyToOne, lvManyToOneRelationships),
                new ResultView(gbViews, lvViews),
                new ResultView(gbForms, lvForms),
                new ResultView(gbWorkflows, lvWorkflows),
                new ResultView(gbPlugins, lvPlugins),
                new ResultView(gbPluginSteps, lvPluginSteps),
                new ResultView(gbTemplates, lvTemplates),

            };
        }

        public ListView LVAttributes
        {
            get { return lvAttributes; }
        }
        public ListView LVOneToManyRelationships
        {
            get { return lvOneToManyRelationships; }
        }
        public ListView LVManyToManyRelationships
        {
            get { return lvManyToManyRelationships; }
        }
        public ListView LVManyToOneRelationships
        {
            get { return lvManyToOneRelationships; }
        }
        public ListView LVForms
        {
            get { return lvForms; }
        }
        public ListView LVViews
        {
            get { return lvViews; }
        }
        public ListView LVWorkflows
        {
            get { return lvWorkflows; }
        }
        public ListView LVPlugins
        {
            get { return lvPlugins; }
        }
        public ListView LVPluginSteps
        {
            get { return lvPluginSteps; }
        }
        public ListView LVTemplates
        {
            get { return lvTemplates; }
        }

        public void OptimizeDisplay()
        {
            foreach (var rv in resultViews)
            {
                rv.GroupBox.Visible = rv.ListView.Items.Count != 0;
                rv.GroupBox.Height = 150;
            }
        }

        public void Clear()
        {
            foreach (var rv in resultViews)
            {
                rv.ListView.Items.Clear();
            }

        }

    }

    public class ResultView
    {
        public ResultView(GroupBox gb, ListView lv)
        {
            GroupBox = gb;
            ListView = lv;
        }
        public GroupBox GroupBox { get; set; }
        public ListView ListView { get; set; }
    }
}
