namespace Xrm.DevOPs.Controls
{
    partial class SolutionSelecterControl
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
            this.cbOrgs = new System.Windows.Forms.ComboBox();
            this.tvSolutions = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // cbOrgs
            // 
            this.cbOrgs.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbOrgs.FormattingEnabled = true;
            this.cbOrgs.Location = new System.Drawing.Point(0, 0);
            this.cbOrgs.Name = "cbOrgs";
            this.cbOrgs.Size = new System.Drawing.Size(308, 21);
            this.cbOrgs.TabIndex = 0;
            // 
            // tvSolutions
            // 
            this.tvSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSolutions.Location = new System.Drawing.Point(0, 21);
            this.tvSolutions.Name = "tvSolutions";
            this.tvSolutions.Size = new System.Drawing.Size(308, 328);
            this.tvSolutions.TabIndex = 1;
            // 
            // SolutionSelecterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvSolutions);
            this.Controls.Add(this.cbOrgs);
            this.Name = "SolutionSelecterControl";
            this.Size = new System.Drawing.Size(308, 349);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbOrgs;
        private System.Windows.Forms.TreeView tvSolutions;
    }
}
