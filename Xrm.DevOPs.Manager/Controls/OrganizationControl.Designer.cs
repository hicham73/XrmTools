namespace Xrm.DevOPs.Manager.Controls
{
    partial class OrganizationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrganizationControl));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.lblOrgName = new System.Windows.Forms.ToolStripLabel();
            this.BtnSyncConfig = new System.Windows.Forms.ToolStripButton();
            this.BtnSyncProjects = new System.Windows.Forms.ToolStripButton();
            this.BtnSyncAll = new System.Windows.Forms.ToolStripButton();
            this.BtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tvSolutions = new System.Windows.Forms.TreeView();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.LightSlateGray;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblOrgName,
            this.BtnSyncConfig,
            this.BtnSyncProjects,
            this.BtnSyncAll,
            this.BtnRefresh});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(405, 25);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "toolStrip1";
            // 
            // lblOrgName
            // 
            this.lblOrgName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblOrgName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblOrgName.Name = "lblOrgName";
            this.lblOrgName.Size = new System.Drawing.Size(39, 22);
            this.lblOrgName.Text = "Name";
            // 
            // BtnSyncConfig
            // 
            this.BtnSyncConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSyncConfig.Image = ((System.Drawing.Image)(resources.GetObject("BtnSyncConfig.Image")));
            this.BtnSyncConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSyncConfig.Name = "BtnSyncConfig";
            this.BtnSyncConfig.Size = new System.Drawing.Size(23, 22);
            this.BtnSyncConfig.Text = "Config";
            this.BtnSyncConfig.Click += new System.EventHandler(this.BtnSyncConfig_Click);
            // 
            // BtnSyncProjects
            // 
            this.BtnSyncProjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSyncProjects.Image = ((System.Drawing.Image)(resources.GetObject("BtnSyncProjects.Image")));
            this.BtnSyncProjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSyncProjects.Name = "BtnSyncProjects";
            this.BtnSyncProjects.Size = new System.Drawing.Size(23, 22);
            this.BtnSyncProjects.Text = "Projects";
            this.BtnSyncProjects.Click += new System.EventHandler(this.BtnSyncProjects_Click);
            // 
            // BtnSyncAll
            // 
            this.BtnSyncAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSyncAll.Image = ((System.Drawing.Image)(resources.GetObject("BtnSyncAll.Image")));
            this.BtnSyncAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSyncAll.Name = "BtnSyncAll";
            this.BtnSyncAll.Size = new System.Drawing.Size(23, 22);
            this.BtnSyncAll.Text = "All";
            this.BtnSyncAll.Click += new System.EventHandler(this.BtnSyncAll_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefresh.Image")));
            this.BtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(23, 22);
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // tvSolutions
            // 
            this.tvSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSolutions.Location = new System.Drawing.Point(0, 25);
            this.tvSolutions.Name = "tvSolutions";
            this.tvSolutions.Size = new System.Drawing.Size(405, 383);
            this.tvSolutions.TabIndex = 1;
            // 
            // OrganizationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvSolutions);
            this.Controls.Add(this.toolbar);
            this.Name = "OrganizationControl";
            this.Size = new System.Drawing.Size(405, 408);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton BtnSyncConfig;
        private System.Windows.Forms.ToolStripButton BtnSyncProjects;
        private System.Windows.Forms.ToolStripButton BtnSyncAll;
        private System.Windows.Forms.ToolStripButton BtnRefresh;
        private System.Windows.Forms.TreeView tvSolutions;
        private System.Windows.Forms.ToolStripLabel lblOrgName;
    }
}
