namespace Xrm.DevOPs.Manager.UI.Forms
{
    partial class SolutionTransferDlg
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cbFromOrg = new System.Windows.Forms.ToolStripComboBox();
            this.cbToOrg = new System.Windows.Forms.ToolStripComboBox();
            this.tvLeftOrg = new System.Windows.Forms.TreeView();
            this.tvRightOrg = new System.Windows.Forms.TreeView();
            this.BtnTransfer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbFromOrg,
            this.cbToOrg});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(614, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cbFromOrg
            // 
            this.cbFromOrg.Name = "cbFromOrg";
            this.cbFromOrg.Size = new System.Drawing.Size(300, 23);
            this.cbFromOrg.Text = "Source Organization";
            this.cbFromOrg.SelectedIndexChanged += new System.EventHandler(this.CBSourceOrg_SelectedIndexChanged);
            // 
            // cbToOrg
            // 
            this.cbToOrg.Name = "cbToOrg";
            this.cbToOrg.Size = new System.Drawing.Size(300, 23);
            this.cbToOrg.Text = "Target Organization";
            this.cbToOrg.SelectedIndexChanged += new System.EventHandler(this.CBTargetOrg_SelectedIndexChanged);
            // 
            // tvLeftOrg
            // 
            this.tvLeftOrg.Location = new System.Drawing.Point(0, 30);
            this.tvLeftOrg.Name = "tvLeftOrg";
            this.tvLeftOrg.Size = new System.Drawing.Size(302, 341);
            this.tvLeftOrg.TabIndex = 1;
            // 
            // tvRightOrg
            // 
            this.tvRightOrg.Location = new System.Drawing.Point(308, 30);
            this.tvRightOrg.Name = "tvRightOrg";
            this.tvRightOrg.Size = new System.Drawing.Size(306, 341);
            this.tvRightOrg.TabIndex = 2;
            // 
            // BtnTransfer
            // 
            this.BtnTransfer.Location = new System.Drawing.Point(159, 377);
            this.BtnTransfer.Name = "BtnTransfer";
            this.BtnTransfer.Size = new System.Drawing.Size(101, 23);
            this.BtnTransfer.TabIndex = 3;
            this.BtnTransfer.Text = "Transfer";
            this.BtnTransfer.UseVisualStyleBackColor = true;
            this.BtnTransfer.Click += new System.EventHandler(this.BtnTransfer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(323, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SolutionTransferDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 407);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.BtnTransfer);
            this.Controls.Add(this.tvRightOrg);
            this.Controls.Add(this.tvLeftOrg);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SolutionTransferDlg";
            this.Text = "SolutionTransferDlg";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox cbFromOrg;
        private System.Windows.Forms.ToolStripComboBox cbToOrg;
        private System.Windows.Forms.TreeView tvLeftOrg;
        private System.Windows.Forms.TreeView tvRightOrg;
        private System.Windows.Forms.Button BtnTransfer;
        private System.Windows.Forms.Button btnCancel;
    }
}