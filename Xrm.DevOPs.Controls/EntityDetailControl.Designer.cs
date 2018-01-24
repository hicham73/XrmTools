namespace Xrm.DevOPs.Controls
{
    partial class EntityDetailControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcEntityDetail = new System.Windows.Forms.TabControl();
            this.tabAttributes = new System.Windows.Forms.TabPage();
            this.lvAttributes = new System.Windows.Forms.ListView();
            this.tabKeys = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tab1N = new System.Windows.Forms.TabPage();
            this.lv1NRelationships = new System.Windows.Forms.ListView();
            this.tabN1 = new System.Windows.Forms.TabPage();
            this.lvN1Relationships = new System.Windows.Forms.ListView();
            this.tabNN = new System.Windows.Forms.TabPage();
            this.lvNNRelationships = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pgCompDetail = new System.Windows.Forms.PropertyGrid();
            this.tcEntityDetail.SuspendLayout();
            this.tabAttributes.SuspendLayout();
            this.tabKeys.SuspendLayout();
            this.tab1N.SuspendLayout();
            this.tabN1.SuspendLayout();
            this.tabNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcEntityDetail
            // 
            this.tcEntityDetail.Controls.Add(this.tabAttributes);
            this.tcEntityDetail.Controls.Add(this.tabKeys);
            this.tcEntityDetail.Controls.Add(this.tab1N);
            this.tcEntityDetail.Controls.Add(this.tabN1);
            this.tcEntityDetail.Controls.Add(this.tabNN);
            this.tcEntityDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEntityDetail.Location = new System.Drawing.Point(0, 0);
            this.tcEntityDetail.Name = "tcEntityDetail";
            this.tcEntityDetail.SelectedIndex = 0;
            this.tcEntityDetail.Size = new System.Drawing.Size(755, 624);
            this.tcEntityDetail.TabIndex = 1;
            // 
            // tabAttributes
            // 
            this.tabAttributes.Controls.Add(this.lvAttributes);
            this.tabAttributes.Location = new System.Drawing.Point(4, 22);
            this.tabAttributes.Name = "tabAttributes";
            this.tabAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttributes.Size = new System.Drawing.Size(747, 598);
            this.tabAttributes.TabIndex = 0;
            this.tabAttributes.Text = "Attributes";
            this.tabAttributes.UseVisualStyleBackColor = true;
            // 
            // lvAttributes
            // 
            this.lvAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAttributes.FullRowSelect = true;
            this.lvAttributes.GridLines = true;
            this.lvAttributes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvAttributes.Location = new System.Drawing.Point(3, 3);
            this.lvAttributes.MultiSelect = false;
            this.lvAttributes.Name = "lvAttributes";
            this.lvAttributes.Size = new System.Drawing.Size(741, 592);
            this.lvAttributes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvAttributes.TabIndex = 0;
            this.lvAttributes.UseCompatibleStateImageBehavior = false;
            this.lvAttributes.View = System.Windows.Forms.View.Details;
            this.lvAttributes.SelectedIndexChanged += new System.EventHandler(this.TV_SelectedIndexChanged);
            // 
            // tabKeys
            // 
            this.tabKeys.Controls.Add(this.listView1);
            this.tabKeys.Location = new System.Drawing.Point(4, 22);
            this.tabKeys.Name = "tabKeys";
            this.tabKeys.Padding = new System.Windows.Forms.Padding(3);
            this.tabKeys.Size = new System.Drawing.Size(1093, 598);
            this.tabKeys.TabIndex = 1;
            this.tabKeys.Text = "Keys";
            this.tabKeys.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1087, 592);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // tab1N
            // 
            this.tab1N.Controls.Add(this.lv1NRelationships);
            this.tab1N.Location = new System.Drawing.Point(4, 22);
            this.tab1N.Name = "tab1N";
            this.tab1N.Size = new System.Drawing.Size(1093, 598);
            this.tab1N.TabIndex = 5;
            this.tab1N.Text = "1:N";
            this.tab1N.UseVisualStyleBackColor = true;
            // 
            // lv1NRelationships
            // 
            this.lv1NRelationships.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv1NRelationships.GridLines = true;
            this.lv1NRelationships.Location = new System.Drawing.Point(0, 0);
            this.lv1NRelationships.Name = "lv1NRelationships";
            this.lv1NRelationships.Size = new System.Drawing.Size(1093, 598);
            this.lv1NRelationships.TabIndex = 0;
            this.lv1NRelationships.UseCompatibleStateImageBehavior = false;
            this.lv1NRelationships.View = System.Windows.Forms.View.Details;
            // 
            // tabN1
            // 
            this.tabN1.Controls.Add(this.lvN1Relationships);
            this.tabN1.Location = new System.Drawing.Point(4, 22);
            this.tabN1.Name = "tabN1";
            this.tabN1.Size = new System.Drawing.Size(1093, 598);
            this.tabN1.TabIndex = 3;
            this.tabN1.Text = "N:1";
            this.tabN1.UseVisualStyleBackColor = true;
            // 
            // lvN1Relationships
            // 
            this.lvN1Relationships.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvN1Relationships.GridLines = true;
            this.lvN1Relationships.Location = new System.Drawing.Point(0, 0);
            this.lvN1Relationships.Name = "lvN1Relationships";
            this.lvN1Relationships.Size = new System.Drawing.Size(1093, 598);
            this.lvN1Relationships.TabIndex = 0;
            this.lvN1Relationships.UseCompatibleStateImageBehavior = false;
            this.lvN1Relationships.View = System.Windows.Forms.View.Details;
            // 
            // tabNN
            // 
            this.tabNN.Controls.Add(this.lvNNRelationships);
            this.tabNN.Location = new System.Drawing.Point(4, 22);
            this.tabNN.Name = "tabNN";
            this.tabNN.Size = new System.Drawing.Size(1093, 598);
            this.tabNN.TabIndex = 4;
            this.tabNN.Text = "N:N";
            this.tabNN.UseVisualStyleBackColor = true;
            // 
            // lvNNRelationships
            // 
            this.lvNNRelationships.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNNRelationships.GridLines = true;
            this.lvNNRelationships.Location = new System.Drawing.Point(0, 0);
            this.lvNNRelationships.Name = "lvNNRelationships";
            this.lvNNRelationships.Size = new System.Drawing.Size(1093, 598);
            this.lvNNRelationships.TabIndex = 0;
            this.lvNNRelationships.UseCompatibleStateImageBehavior = false;
            this.lvNNRelationships.View = System.Windows.Forms.View.Details;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tcEntityDetail);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pgCompDetail);
            this.splitContainer1.Size = new System.Drawing.Size(1101, 624);
            this.splitContainer1.SplitterDistance = 755;
            this.splitContainer1.TabIndex = 2;
            // 
            // pgCompDetail
            // 
            this.pgCompDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgCompDetail.Location = new System.Drawing.Point(0, 0);
            this.pgCompDetail.Name = "pgCompDetail";
            this.pgCompDetail.Size = new System.Drawing.Size(342, 624);
            this.pgCompDetail.TabIndex = 0;
            // 
            // EntityDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "EntityDetailControl";
            this.Size = new System.Drawing.Size(1101, 624);
            this.tcEntityDetail.ResumeLayout(false);
            this.tabAttributes.ResumeLayout(false);
            this.tabKeys.ResumeLayout(false);
            this.tab1N.ResumeLayout(false);
            this.tabN1.ResumeLayout(false);
            this.tabNN.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcEntityDetail;
        private System.Windows.Forms.TabPage tabAttributes;
        private System.Windows.Forms.ListView lvAttributes;
        private System.Windows.Forms.TabPage tabKeys;
        private System.Windows.Forms.TabPage tab1N;
        private System.Windows.Forms.ListView lv1NRelationships;
        private System.Windows.Forms.TabPage tabN1;
        private System.Windows.Forms.ListView lvN1Relationships;
        private System.Windows.Forms.TabPage tabNN;
        private System.Windows.Forms.ListView lvNNRelationships;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid pgCompDetail;
    }
}
