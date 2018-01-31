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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.ctrlLeftSolSelecter = new Xrm.DevOPs.Controls.SolutionSelecterControl();
            this.ctrlRightSolSelecter = new Xrm.DevOPs.Controls.SolutionSelecterControl();
            this.solCompareResultControl1 = new Xrm.DevOPs.Controls.SolCompareResultControl();
            this.solCompareResultControl2 = new Xrm.DevOPs.Controls.SolCompareResultControl();
            this.solCompareResultControl3 = new Xrm.DevOPs.Controls.SolCompareResultControl();
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
            this.splitContainer3.Panel1.Controls.Add(this.solCompareResultControl1);
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
            this.splitContainer4.Panel1.Controls.Add(this.solCompareResultControl2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.solCompareResultControl3);
            this.splitContainer4.Size = new System.Drawing.Size(549, 704);
            this.splitContainer4.SplitterDistance = 286;
            this.splitContainer4.TabIndex = 0;
            // 
            // ctrlLeftSolSelecter
            // 
            this.ctrlLeftSolSelecter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLeftSolSelecter.Location = new System.Drawing.Point(0, 0);
            this.ctrlLeftSolSelecter.Name = "ctrlLeftSolSelecter";
            this.ctrlLeftSolSelecter.Size = new System.Drawing.Size(310, 327);
            this.ctrlLeftSolSelecter.TabIndex = 0;
            // 
            // ctrlRightSolSelecter
            // 
            this.ctrlRightSolSelecter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRightSolSelecter.Location = new System.Drawing.Point(0, 0);
            this.ctrlRightSolSelecter.Name = "ctrlRightSolSelecter";
            this.ctrlRightSolSelecter.Size = new System.Drawing.Size(310, 373);
            this.ctrlRightSolSelecter.TabIndex = 0;
            // 
            // solCompareResultControl1
            // 
            this.solCompareResultControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solCompareResultControl1.Header = "Difference";
            this.solCompareResultControl1.Location = new System.Drawing.Point(0, 0);
            this.solCompareResultControl1.Name = "solCompareResultControl1";
            this.solCompareResultControl1.Size = new System.Drawing.Size(276, 704);
            this.solCompareResultControl1.TabIndex = 0;
            // 
            // solCompareResultControl2
            // 
            this.solCompareResultControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solCompareResultControl2.Header = "Intersection";
            this.solCompareResultControl2.Location = new System.Drawing.Point(0, 0);
            this.solCompareResultControl2.Name = "solCompareResultControl2";
            this.solCompareResultControl2.Size = new System.Drawing.Size(286, 704);
            this.solCompareResultControl2.TabIndex = 0;
            // 
            // solCompareResultControl3
            // 
            this.solCompareResultControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solCompareResultControl3.Header = "Reverse Difference";
            this.solCompareResultControl3.Location = new System.Drawing.Point(0, 0);
            this.solCompareResultControl3.Name = "solCompareResultControl3";
            this.solCompareResultControl3.Size = new System.Drawing.Size(259, 704);
            this.solCompareResultControl3.TabIndex = 0;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private SolutionSelecterControl ctrlLeftSolSelecter;
        private SolutionSelecterControl ctrlRightSolSelecter;
        private SolCompareResultControl solCompareResultControl1;
        private SolCompareResultControl solCompareResultControl2;
        private SolCompareResultControl solCompareResultControl3;
    }
}
