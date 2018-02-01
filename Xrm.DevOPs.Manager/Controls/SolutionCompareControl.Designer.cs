namespace Xrm.DevOPs.Controls
{
    partial class SolutionCompareControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionCompareControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnCompare = new System.Windows.Forms.ToolStripButton();
            this.ctrlLeftSolSelecter = new Xrm.DevOPs.Controls.SolutionSelecterControl();
            this.ctrlRightSolSelecter = new Xrm.DevOPs.Controls.SolutionSelecterControl();
            this.ctrlLeftCompareResult = new Xrm.DevOPs.Controls.SolCompareResultControl();
            this.ctrlInterCompareResult = new Xrm.DevOPs.Controls.SolCompareResultControl();
            this.ctrlRightCompareResult = new Xrm.DevOPs.Controls.SolCompareResultControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1143, 704);
            this.splitContainer1.SplitterDistance = 310;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ctrlLeftSolSelecter);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ctrlRightSolSelecter);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(310, 704);
            this.splitContainer2.SplitterDistance = 327;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ctrlLeftCompareResult);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(829, 704);
            this.splitContainer3.SplitterDistance = 276;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.ctrlInterCompareResult);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.ctrlRightCompareResult);
            this.splitContainer4.Size = new System.Drawing.Size(549, 704);
            this.splitContainer4.SplitterDistance = 286;
            this.splitContainer4.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnCompare});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(310, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnCompare
            // 
            this.BtnCompare.Image = ((System.Drawing.Image)(resources.GetObject("BtnCompare.Image")));
            this.BtnCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCompare.Name = "BtnCompare";
            this.BtnCompare.Size = new System.Drawing.Size(76, 22);
            this.BtnCompare.Text = "Compare";
            this.BtnCompare.Click += new System.EventHandler(this.BtnCompare_Click);
            // 
            // ctrlLeftSolSelecter
            // 
            this.ctrlLeftSolSelecter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLeftSolSelecter.Location = new System.Drawing.Point(0, 0);
            this.ctrlLeftSolSelecter.Name = "ctrlLeftSolSelecter";
            this.ctrlLeftSolSelecter.OrganizationTree = null;
            this.ctrlLeftSolSelecter.ParentControl = null;
            this.ctrlLeftSolSelecter.Size = new System.Drawing.Size(310, 327);
            this.ctrlLeftSolSelecter.TabIndex = 0;
            // 
            // ctrlRightSolSelecter
            // 
            this.ctrlRightSolSelecter.CausesValidation = false;
            this.ctrlRightSolSelecter.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlRightSolSelecter.Location = new System.Drawing.Point(0, 25);
            this.ctrlRightSolSelecter.Name = "ctrlRightSolSelecter";
            this.ctrlRightSolSelecter.OrganizationTree = null;
            this.ctrlRightSolSelecter.ParentControl = null;
            this.ctrlRightSolSelecter.Size = new System.Drawing.Size(310, 348);
            this.ctrlRightSolSelecter.TabIndex = 0;
            // 
            // ctrlLeftCompareResult
            // 
            this.ctrlLeftCompareResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLeftCompareResult.Header = "Difference";
            this.ctrlLeftCompareResult.Location = new System.Drawing.Point(0, 0);
            this.ctrlLeftCompareResult.Name = "ctrlLeftCompareResult";
            this.ctrlLeftCompareResult.Size = new System.Drawing.Size(276, 704);
            this.ctrlLeftCompareResult.TabIndex = 0;
            // 
            // ctrlInterCompareResult
            // 
            this.ctrlInterCompareResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlInterCompareResult.Header = "Intersection";
            this.ctrlInterCompareResult.Location = new System.Drawing.Point(0, 0);
            this.ctrlInterCompareResult.Name = "ctrlInterCompareResult";
            this.ctrlInterCompareResult.Size = new System.Drawing.Size(286, 704);
            this.ctrlInterCompareResult.TabIndex = 0;
            // 
            // ctrlRightCompareResult
            // 
            this.ctrlRightCompareResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRightCompareResult.Header = "Reverse Difference";
            this.ctrlRightCompareResult.Location = new System.Drawing.Point(0, 0);
            this.ctrlRightCompareResult.Name = "ctrlRightCompareResult";
            this.ctrlRightCompareResult.Size = new System.Drawing.Size(259, 704);
            this.ctrlRightCompareResult.TabIndex = 0;
            // 
            // SolutionCompareControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SolutionCompareControl";
            this.Size = new System.Drawing.Size(1143, 704);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private SolutionSelecterControl ctrlLeftSolSelecter;
        private SolutionSelecterControl ctrlRightSolSelecter;
        private SolCompareResultControl ctrlLeftCompareResult;
        private SolCompareResultControl ctrlInterCompareResult;
        private SolCompareResultControl ctrlRightCompareResult;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnCompare;
    }
}
