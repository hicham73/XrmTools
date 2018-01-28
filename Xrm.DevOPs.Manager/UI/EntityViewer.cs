using System.Windows.Forms;
using Xrm.DevOPs.ComponentModel;
using Xrm.DevOPs.Controls;
using Xrm.DevOPs.Manager.ComponentModel;

namespace Xrm.DevOPs.Manager.UI
{
    public class EntityViewer
    {
        TabPage _page;
        EntityDetailControl _entityDetail;

        public EntityViewer(string name, string text)
        {
            _page = new TabPage();

            _entityDetail = new EntityDetailControl();
            _entityDetail.Dock = DockStyle.Fill;

            _page.SuspendLayout();
            _entityDetail.SuspendLayout();

            _page.Controls.Add(_entityDetail);
            _page.Location = new System.Drawing.Point(4, 22);
            _page.Padding = new Padding(3);
            _page.Dock = DockStyle.Fill;
            _page.Size = new System.Drawing.Size(745, 637);
            _page.TabIndex = 0;
            _page.Name = name;
            _page.Text = text;
            _page.UseVisualStyleBackColor = true;
            _page.ImageIndex = 100;

            _page.ResumeLayout();
            _entityDetail.ResumeLayout();

        }

        public TabPage Page { get { return _page; } }
        public EntityDetailControl EntityDetail { get { return _entityDetail; } }
        public void ShowAssets<T>(CrmTreeNode<T> entityNode)
        {
            var entityComponent = (EntityComponent)entityNode.Component;

            var lvAttributes = _entityDetail.LvAttributes;
            var lv1NRelationships = _entityDetail.Lv1NRelationships;
            var lvN1Relationships = _entityDetail.LvN1Relationships;
            var lvNNRelationships = _entityDetail.LvNNRelationships;

            lvAttributes.Columns.Clear();
            lvAttributes.Items.Clear();

            lvAttributes.View = View.Details;
            lvAttributes.Columns.Add("Name", 150);
            lvAttributes.Columns.Add("DisplayName", 150);
            lvAttributes.Columns.Add("Version", 100);
            lvAttributes.Columns.Add("Type", 150);
            lvAttributes.Columns.Add("Description", 250);
            foreach (var attr in entityComponent.Attributes)
            {
                var item = new ListViewItem(new string[] {
                    attr.SchemaName.ToString(),
                    attr.DisplayName?.ToString(),
                    attr.IntroducedVersion.ToString(),
                    attr.AttributeTypeName.ToString(),
                    attr.Description?.ToString(),
                });

                item.Tag = attr;
                lvAttributes.Items.Add(item);

            }

            lvN1Relationships.Columns.Clear();
            lvN1Relationships.Items.Clear();
            lvN1Relationships.Columns.Add("Name", 150);
            lvN1Relationships.Columns.Add("Parent", 150);
            lvN1Relationships.Columns.Add("Child", 150);
            lvN1Relationships.Columns.Add("Attribute", 150);
            lvN1Relationships.Columns.Add("Type", 150);
            foreach (var rel in entityComponent.ManyToOneRelashionships)
            {
                var item = new ListViewItem(new string[] {
                    rel.SchemaName.ToString(),
                    rel.ReferencingEntity,
                    rel.ReferencedEntity,
                    rel.ReferencingAttribute,
                    rel.RelationshipType.ToString(),
                });

                item.Tag = rel;
                lvN1Relationships.Items.Add(item);
            }

            lv1NRelationships.Columns.Clear();
            lv1NRelationships.Items.Clear();
            lv1NRelationships.Columns.Add("Name", 150);
            lv1NRelationships.Columns.Add("Parent", 150);
            lv1NRelationships.Columns.Add("Child", 150);
            lv1NRelationships.Columns.Add("Attribute", 150);
            lv1NRelationships.Columns.Add("Type", 150);
            foreach (var rel in entityComponent.OneToManyRelashionships)
            {
                var item = new ListViewItem(new string[] {
                    rel.SchemaName.ToString(),
                    rel.ReferencingEntity,
                    rel.ReferencedEntity,
                    rel.ReferencingAttribute,
                    rel.RelationshipType.ToString(),
                });
                item.Tag = rel;
                lv1NRelationships.Items.Add(item);
            }

            lvNNRelationships.Columns.Clear();
            lvNNRelationships.Items.Clear();
            lvNNRelationships.Columns.Add("Name", 150);
            lvNNRelationships.Columns.Add("E1 - Logical Name", 150);
            lvNNRelationships.Columns.Add("E1 - Attribute", 150);
            lvNNRelationships.Columns.Add("E2 - Logical Name", 150);
            lvNNRelationships.Columns.Add("E2 - Attribute", 150);
            lvNNRelationships.Columns.Add("Type", 150);
            foreach (var rel in entityComponent.ManyToManyRelationships)
            {
                var item = new ListViewItem(new string[] {
                    rel.SchemaName.ToString(),
                    rel.Entity1LogicalName,
                    rel.Entity1IntersectAttribute,
                    rel.Entity2LogicalName,
                    rel.Entity2IntersectAttribute,
                    rel.RelationshipType.ToString(),
                });
                item.Tag = rel;
                lvNNRelationships.Items.Add(item);

            }

        }

    }

}
