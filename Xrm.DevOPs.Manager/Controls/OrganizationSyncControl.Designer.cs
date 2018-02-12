namespace Xrm.DevOPs.Manager.Controls
{
    partial class OrganizationSyncControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrganizationSyncControl));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.tvTFS = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.BtnReload = new System.Windows.Forms.ToolStripButton();
            this.masterOrgControl = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.integrationOrgControl = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.orgControlDev6 = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.orgControlDev5 = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.orgControlDev1 = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.orgControlDev2 = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.orgControlDev4 = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.orgControlDev3 = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.rtSyncLog = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            this.splitContainer2.Panel1.Controls.Add(this.splitter1);
            this.splitContainer2.Panel1.Margin = new System.Windows.Forms.Padding(100, 0, 0, 0);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1047, 612);
            this.splitContainer2.SplitterDistance = 233;
            this.splitContainer2.TabIndex = 10;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.tvTFS);
            this.splitContainer4.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.masterOrgControl);
            this.splitContainer4.Size = new System.Drawing.Size(230, 612);
            this.splitContainer4.SplitterDistance = 277;
            this.splitContainer4.TabIndex = 1;
            // 
            // tvTFS
            // 
            this.tvTFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTFS.Location = new System.Drawing.Point(0, 25);
            this.tvTFS.Name = "tvTFS";
            this.tvTFS.Size = new System.Drawing.Size(230, 252);
            this.tvTFS.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.BtnReload});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(230, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel1.Text = "TFS - Projects";
            // 
            // BtnReload
            // 
            this.BtnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnReload.Image = ((System.Drawing.Image)(resources.GetObject("BtnReload.Image")));
            this.BtnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnReload.Name = "BtnReload";
            this.BtnReload.Size = new System.Drawing.Size(23, 22);
            this.BtnReload.Text = "Reload";
            this.BtnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // masterOrgControl
            // 
            this.masterOrgControl.BackColor = System.Drawing.SystemColors.Control;
            this.masterOrgControl.CrmMasterOrg = null;
            this.masterOrgControl.CrmOrg = null;
            this.masterOrgControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterOrgControl.HeaderBackColor = System.Drawing.Color.SteelBlue;
            this.masterOrgControl.Location = new System.Drawing.Point(0, 0);
            this.masterOrgControl.Log = null;
            this.masterOrgControl.Name = "masterOrgControl";
            this.masterOrgControl.OrgName = "";
            this.masterOrgControl.Size = new System.Drawing.Size(230, 331);
            this.masterOrgControl.TabIndex = 6;
            this.masterOrgControl.TvMasterConfig = null;
            this.masterOrgControl.TvTfs = null;
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 612);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.integrationOrgControl);
            this.splitContainer1.Size = new System.Drawing.Size(810, 612);
            this.splitContainer1.SplitterDistance = 582;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.rtSyncLog);
            this.splitContainer3.Size = new System.Drawing.Size(582, 612);
            this.splitContainer3.SplitterDistance = 474;
            this.splitContainer3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.orgControlDev6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.orgControlDev5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.orgControlDev1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.orgControlDev2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.orgControlDev4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.orgControlDev3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(582, 474);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // integrationOrgControl
            // 
            this.integrationOrgControl.CrmMasterOrg = null;
            this.integrationOrgControl.CrmOrg = null;
            this.integrationOrgControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.integrationOrgControl.HeaderBackColor = System.Drawing.Color.SteelBlue;
            this.integrationOrgControl.Location = new System.Drawing.Point(0, 0);
            this.integrationOrgControl.Log = null;
            this.integrationOrgControl.Name = "integrationOrgControl";
            this.integrationOrgControl.OrgName = "";
            this.integrationOrgControl.Size = new System.Drawing.Size(224, 612);
            this.integrationOrgControl.TabIndex = 4;
            this.integrationOrgControl.TvMasterConfig = null;
            this.integrationOrgControl.TvTfs = null;
            // 
            // orgControlDev6
            // 
            this.orgControlDev6.CrmMasterOrg = null;
            this.orgControlDev6.CrmOrg = null;
            this.orgControlDev6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgControlDev6.HeaderBackColor = System.Drawing.Color.DarkSlateGray;
            this.orgControlDev6.Location = new System.Drawing.Point(391, 240);
            this.orgControlDev6.Log = null;
            this.orgControlDev6.Name = "orgControlDev6";
            this.orgControlDev6.OrgName = "";
            this.orgControlDev6.Size = new System.Drawing.Size(188, 231);
            this.orgControlDev6.TabIndex = 5;
            this.orgControlDev6.TvMasterConfig = null;
            this.orgControlDev6.TvTfs = null;
            // 
            // orgControlDev5
            // 
            this.orgControlDev5.CrmMasterOrg = null;
            this.orgControlDev5.CrmOrg = null;
            this.orgControlDev5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgControlDev5.HeaderBackColor = System.Drawing.Color.DarkSlateGray;
            this.orgControlDev5.Location = new System.Drawing.Point(197, 240);
            this.orgControlDev5.Log = null;
            this.orgControlDev5.Name = "orgControlDev5";
            this.orgControlDev5.OrgName = "";
            this.orgControlDev5.Size = new System.Drawing.Size(188, 231);
            this.orgControlDev5.TabIndex = 4;
            this.orgControlDev5.TvMasterConfig = null;
            this.orgControlDev5.TvTfs = null;
            // 
            // orgControlDev1
            // 
            this.orgControlDev1.CrmMasterOrg = null;
            this.orgControlDev1.CrmOrg = null;
            this.orgControlDev1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgControlDev1.HeaderBackColor = System.Drawing.Color.DarkSlateGray;
            this.orgControlDev1.Location = new System.Drawing.Point(3, 3);
            this.orgControlDev1.Log = null;
            this.orgControlDev1.Name = "orgControlDev1";
            this.orgControlDev1.OrgName = "";
            this.orgControlDev1.Size = new System.Drawing.Size(188, 231);
            this.orgControlDev1.TabIndex = 0;
            this.orgControlDev1.TvMasterConfig = null;
            this.orgControlDev1.TvTfs = null;
            // 
            // orgControlDev2
            // 
            this.orgControlDev2.CrmMasterOrg = null;
            this.orgControlDev2.CrmOrg = null;
            this.orgControlDev2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgControlDev2.HeaderBackColor = System.Drawing.Color.DarkSlateGray;
            this.orgControlDev2.Location = new System.Drawing.Point(197, 3);
            this.orgControlDev2.Log = null;
            this.orgControlDev2.Name = "orgControlDev2";
            this.orgControlDev2.OrgName = "";
            this.orgControlDev2.Size = new System.Drawing.Size(188, 231);
            this.orgControlDev2.TabIndex = 1;
            this.orgControlDev2.TvMasterConfig = null;
            this.orgControlDev2.TvTfs = null;
            // 
            // orgControlDev4
            // 
            this.orgControlDev4.CrmMasterOrg = null;
            this.orgControlDev4.CrmOrg = null;
            this.orgControlDev4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgControlDev4.HeaderBackColor = System.Drawing.Color.DarkSlateGray;
            this.orgControlDev4.Location = new System.Drawing.Point(3, 240);
            this.orgControlDev4.Log = null;
            this.orgControlDev4.Name = "orgControlDev4";
            this.orgControlDev4.OrgName = "";
            this.orgControlDev4.Size = new System.Drawing.Size(188, 231);
            this.orgControlDev4.TabIndex = 3;
            this.orgControlDev4.TvMasterConfig = null;
            this.orgControlDev4.TvTfs = null;
            // 
            // orgControlDev3
            // 
            this.orgControlDev3.CrmMasterOrg = null;
            this.orgControlDev3.CrmOrg = null;
            this.orgControlDev3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgControlDev3.HeaderBackColor = System.Drawing.Color.DarkSlateGray;
            this.orgControlDev3.Location = new System.Drawing.Point(391, 3);
            this.orgControlDev3.Log = null;
            this.orgControlDev3.Name = "orgControlDev3";
            this.orgControlDev3.OrgName = "";
            this.orgControlDev3.Size = new System.Drawing.Size(188, 231);
            this.orgControlDev3.TabIndex = 2;
            this.orgControlDev3.TvMasterConfig = null;
            this.orgControlDev3.TvTfs = null;
            // 
            // rtSyncLog
            // 
            this.rtSyncLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtSyncLog.Location = new System.Drawing.Point(0, 0);
            this.rtSyncLog.Name = "rtSyncLog";
            this.rtSyncLog.Size = new System.Drawing.Size(582, 134);
            this.rtSyncLog.TabIndex = 0;
            this.rtSyncLog.Text = "";
            // 
            // OrganizationSyncControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "OrganizationSyncControl";
            this.Size = new System.Drawing.Size(1047, 612);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TreeView tvTFS;
        private OrganizationControl masterOrgControl;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OrganizationControl orgControlDev1;
        private OrganizationControl orgControlDev2;
        private OrganizationControl orgControlDev3;
        private OrganizationControl orgControlDev4;
        private System.Windows.Forms.RichTextBox rtSyncLog;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton BtnReload;
        private OrganizationControl orgControlDev6;
        private OrganizationControl orgControlDev5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private OrganizationControl integrationOrgControl;
    }
}
