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
            this.orgControlConfig = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.orgControlDev1 = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.orgControlDev2 = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.orgControlDev3 = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.orgControlDev4 = new Xrm.DevOPs.Manager.Controls.OrganizationControl();
            this.rtSyncLog = new System.Windows.Forms.RichTextBox();
            this.BtnReload = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Panel2.Controls.Add(this.rtSyncLog);
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
            this.splitContainer4.Panel2.Controls.Add(this.orgControlConfig);
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
            this.toolStrip1.BackColor = System.Drawing.Color.Teal;
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
            // orgControlConfig
            // 
            this.orgControlConfig.BackColor = System.Drawing.SystemColors.Control;
            this.orgControlConfig.CrmOrg = null;
            this.orgControlConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgControlConfig.Location = new System.Drawing.Point(0, 0);
            this.orgControlConfig.Name = "orgControlConfig";
            this.orgControlConfig.Size = new System.Drawing.Size(230, 331);
            this.orgControlConfig.TabIndex = 6;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.22968F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.77032F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204F));
            this.tableLayoutPanel1.Controls.Add(this.orgControlDev1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.orgControlDev2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.orgControlDev3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.orgControlDev4, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(810, 329);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // orgControlDev1
            // 
            this.orgControlDev1.CrmOrg = null;
            this.orgControlDev1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgControlDev1.Location = new System.Drawing.Point(3, 3);
            this.orgControlDev1.Name = "orgControlDev1";
            this.orgControlDev1.Size = new System.Drawing.Size(156, 323);
            this.orgControlDev1.TabIndex = 0;
            // 
            // orgControlDev2
            // 
            this.orgControlDev2.CrmOrg = null;
            this.orgControlDev2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgControlDev2.Location = new System.Drawing.Point(165, 3);
            this.orgControlDev2.Name = "orgControlDev2";
            this.orgControlDev2.Size = new System.Drawing.Size(191, 323);
            this.orgControlDev2.TabIndex = 1;
            // 
            // orgControlDev3
            // 
            this.orgControlDev3.CrmOrg = null;
            this.orgControlDev3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgControlDev3.Location = new System.Drawing.Point(362, 3);
            this.orgControlDev3.Name = "orgControlDev3";
            this.orgControlDev3.Size = new System.Drawing.Size(240, 323);
            this.orgControlDev3.TabIndex = 2;
            // 
            // orgControlDev4
            // 
            this.orgControlDev4.CrmOrg = null;
            this.orgControlDev4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgControlDev4.Location = new System.Drawing.Point(608, 3);
            this.orgControlDev4.Name = "orgControlDev4";
            this.orgControlDev4.Size = new System.Drawing.Size(199, 323);
            this.orgControlDev4.TabIndex = 3;
            // 
            // rtSyncLog
            // 
            this.rtSyncLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtSyncLog.Location = new System.Drawing.Point(0, 329);
            this.rtSyncLog.Name = "rtSyncLog";
            this.rtSyncLog.Size = new System.Drawing.Size(810, 283);
            this.rtSyncLog.TabIndex = 0;
            this.rtSyncLog.Text = "";
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TreeView tvTFS;
        private OrganizationControl orgControlConfig;
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
    }
}
