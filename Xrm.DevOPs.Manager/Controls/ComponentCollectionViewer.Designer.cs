using System.Windows.Forms;

namespace Xrm.DevOPs.Controls
{
    partial class ComponentCollectionViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvComponents = new System.Windows.Forms.ListView();
            this.pgComponent = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvComponents);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pgComponent);
            this.splitContainer1.Size = new System.Drawing.Size(963, 581);
            this.splitContainer1.SplitterDistance = 629;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvComponents
            // 
            this.lvComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvComponents.GridLines = true;
            //this.lvComponents.Location = new System.Drawing.Point(0, 0);
            this.lvComponents.Name = "lvComponents";
            //this.lvComponents.Size = new System.Drawing.Size(629, 581);
            this.lvComponents.TabIndex = 0;
            this.lvComponents.UseCompatibleStateImageBehavior = false;
            this.lvComponents.View = System.Windows.Forms.View.Details;
            // 
            // pgComponent
            // 
            this.pgComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgComponent.Location = new System.Drawing.Point(0, 0);
            this.pgComponent.Name = "pgComponent";
            this.pgComponent.Size = new System.Drawing.Size(330, 581);
            this.pgComponent.TabIndex = 0;
            // 
            // ComponentCollectionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ComponentCollectionViewer";
            this.Size = new System.Drawing.Size(963, 581);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvComponents;
        private System.Windows.Forms.PropertyGrid pgComponent;
    }
}
