﻿using Xrm.DevOPs.Controls;

namespace Xrm.DevOPs.Manager.UI.Forms
{
    partial class MainForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MIFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MILoadOrganizations = new System.Windows.Forms.ToolStripMenuItem();
            this.MIExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MIDeployment = new System.Windows.Forms.ToolStripMenuItem();
            this.MIDeploymentManager = new System.Windows.Forms.ToolStripMenuItem();
            this.organizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MIOrgCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.solutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MISolCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.MISolTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.MIView = new System.Windows.Forms.ToolStripMenuItem();
            this.MICloseActiveWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.MICloseAllWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvOrgs = new System.Windows.Forms.TreeView();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabCtrlMain = new System.Windows.Forms.TabControl();
            this.tabDeploymentExplorer = new System.Windows.Forms.TabPage();
            this.tabOrgDiff = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lvEntities = new System.Windows.Forms.ListView();
            this.entityDiffControl1 = new Xrm.DevOPs.Controls.EntityDiffControl();
            this.clbDiffOptions = new System.Windows.Forms.CheckedListBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.cbLeftOrg = new System.Windows.Forms.ToolStripComboBox();
            this.cbRightOrg = new System.Windows.Forms.ToolStripComboBox();
            this.MIOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.miLoadEntities = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDiff = new System.Windows.Forms.ToolStripMenuItem();
            this.tabSolCompare = new System.Windows.Forms.TabPage();
            this.ctrlSolutionCompare = new Xrm.DevOPs.Controls.SolutionCompareControl();
            this.tabSyncTool = new System.Windows.Forms.TabPage();
            this.orgSyncControl = new Xrm.DevOPs.Manager.Controls.OrganizationSyncControl();
            this.BtnSyncOrgs = new System.Windows.Forms.Button();
            this.BtnTransfer = new System.Windows.Forms.Button();
            this.pbHome = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabDeploymentExplorer.SuspendLayout();
            this.tabOrgDiff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.tabSolCompare.SuspendLayout();
            this.tabSyncTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIFile,
            this.MIDeployment,
            this.organizationToolStripMenuItem,
            this.solutionToolStripMenuItem,
            this.MIView});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MIFile
            // 
            this.MIFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MILoadOrganizations,
            this.MIExit});
            this.MIFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.MIFile.Name = "MIFile";
            this.MIFile.Size = new System.Drawing.Size(38, 20);
            this.MIFile.Text = "File";
            // 
            // MILoadOrganizations
            // 
            this.MILoadOrganizations.Name = "MILoadOrganizations";
            this.MILoadOrganizations.Size = new System.Drawing.Size(179, 22);
            this.MILoadOrganizations.Text = "Load Organizations";
            this.MILoadOrganizations.Click += new System.EventHandler(this.MILoadOrganizations_Click);
            // 
            // MIExit
            // 
            this.MIExit.Name = "MIExit";
            this.MIExit.Size = new System.Drawing.Size(179, 22);
            this.MIExit.Text = "Exit";
            this.MIExit.Click += new System.EventHandler(this.MIExit_Click);
            // 
            // MIDeployment
            // 
            this.MIDeployment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIDeploymentManager});
            this.MIDeployment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.MIDeployment.Name = "MIDeployment";
            this.MIDeployment.Size = new System.Drawing.Size(88, 20);
            this.MIDeployment.Text = "Deployment";
            // 
            // MIDeploymentManager
            // 
            this.MIDeploymentManager.Enabled = false;
            this.MIDeploymentManager.Name = "MIDeploymentManager";
            this.MIDeploymentManager.Size = new System.Drawing.Size(152, 22);
            this.MIDeploymentManager.Text = "Manager";
            this.MIDeploymentManager.Click += new System.EventHandler(this.MIDeploymentManager_Click);
            // 
            // organizationToolStripMenuItem
            // 
            this.organizationToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.organizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIOrgCompare});
            this.organizationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.organizationToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.organizationToolStripMenuItem.Name = "organizationToolStripMenuItem";
            this.organizationToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.organizationToolStripMenuItem.Text = "Organization";
            // 
            // MIOrgCompare
            // 
            this.MIOrgCompare.Enabled = false;
            this.MIOrgCompare.Name = "MIOrgCompare";
            this.MIOrgCompare.Size = new System.Drawing.Size(152, 22);
            this.MIOrgCompare.Text = "Compare";
            this.MIOrgCompare.Click += new System.EventHandler(this.MIOrgDiff_Click);
            // 
            // solutionToolStripMenuItem
            // 
            this.solutionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MISolCompare,
            this.MISolTransfer});
            this.solutionToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.solutionToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.solutionToolStripMenuItem.Name = "solutionToolStripMenuItem";
            this.solutionToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.solutionToolStripMenuItem.Text = "Solution";
            // 
            // MISolCompare
            // 
            this.MISolCompare.Enabled = false;
            this.MISolCompare.Name = "MISolCompare";
            this.MISolCompare.Size = new System.Drawing.Size(152, 22);
            this.MISolCompare.Text = "Compare";
            this.MISolCompare.Click += new System.EventHandler(this.MISolCompare_Click);
            // 
            // MISolTransfer
            // 
            this.MISolTransfer.Enabled = false;
            this.MISolTransfer.Name = "MISolTransfer";
            this.MISolTransfer.Size = new System.Drawing.Size(152, 22);
            this.MISolTransfer.Text = "Transfer";
            this.MISolTransfer.Click += new System.EventHandler(this.MISolTransfer_Click);
            // 
            // MIView
            // 
            this.MIView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MICloseActiveWindow,
            this.MICloseAllWindows});
            this.MIView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.MIView.Name = "MIView";
            this.MIView.Size = new System.Drawing.Size(47, 20);
            this.MIView.Text = "View";
            // 
            // MICloseActiveWindow
            // 
            this.MICloseActiveWindow.Name = "MICloseActiveWindow";
            this.MICloseActiveWindow.Size = new System.Drawing.Size(152, 22);
            this.MICloseActiveWindow.Text = "Close Active";
            this.MICloseActiveWindow.Click += new System.EventHandler(this.MICloseActiveWindow_Click);
            // 
            // MICloseAllWindows
            // 
            this.MICloseAllWindows.Name = "MICloseAllWindows";
            this.MICloseAllWindows.Size = new System.Drawing.Size(152, 22);
            this.MICloseAllWindows.Text = "Close All";
            this.MICloseAllWindows.Click += new System.EventHandler(this.MICloseAllWindows_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvOrgs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlMain);
            this.splitContainer1.Size = new System.Drawing.Size(1170, 848);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvOrgs
            // 
            this.tvOrgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOrgs.Location = new System.Drawing.Point(0, 0);
            this.tvOrgs.Name = "tvOrgs";
            this.tvOrgs.Size = new System.Drawing.Size(222, 848);
            this.tvOrgs.TabIndex = 0;
            this.tvOrgs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TVOrgs_AfterSelect);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.ImageList = this.imageList1;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(944, 848);
            this.tabControlMain.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "16_help.gif");
            this.imageList1.Images.SetKeyName(1, "16_L_check.gif");
            this.imageList1.Images.SetKeyName(2, "16_save.gif");
            this.imageList1.Images.SetKeyName(3, "16_saveclose.gif");
            this.imageList1.Images.SetKeyName(4, "addNew.gif");
            this.imageList1.Images.SetKeyName(5, "alternatekey_16.png");
            this.imageList1.Images.SetKeyName(6, "blank_11.gif");
            this.imageList1.Images.SetKeyName(7, "businessrule_16.png");
            this.imageList1.Images.SetKeyName(8, "ClientExtension_16.png");
            this.imageList1.Images.SetKeyName(9, "component.png");
            this.imageList1.Images.SetKeyName(10, "exportsolution.png");
            this.imageList1.Images.SetKeyName(11, "Filter_16.png");
            this.imageList1.Images.SetKeyName(12, "hierarchysettings.png");
            this.imageList1.Images.SetKeyName(13, "ico_16_1.gif");
            this.imageList1.Images.SetKeyName(14, "ico_16_2.gif");
            this.imageList1.Images.SetKeyName(15, "ico_16_3.gif");
            this.imageList1.Images.SetKeyName(16, "ico_16_4.gif");
            this.imageList1.Images.SetKeyName(17, "ico_16_5.png");
            this.imageList1.Images.SetKeyName(18, "ico_16_8.gif");
            this.imageList1.Images.SetKeyName(19, "ico_16_9.gif");
            this.imageList1.Images.SetKeyName(20, "ico_16_10.gif");
            this.imageList1.Images.SetKeyName(21, "ico_16_50.gif");
            this.imageList1.Images.SetKeyName(22, "ico_16_78.gif");
            this.imageList1.Images.SetKeyName(23, "ico_16_85.gif");
            this.imageList1.Images.SetKeyName(24, "ico_16_92.gif");
            this.imageList1.Images.SetKeyName(25, "ico_16_99.gif");
            this.imageList1.Images.SetKeyName(26, "ico_16_112.gif");
            this.imageList1.Images.SetKeyName(27, "ico_16_123.gif");
            this.imageList1.Images.SetKeyName(28, "ico_16_127.gif");
            this.imageList1.Images.SetKeyName(29, "ico_16_129.gif");
            this.imageList1.Images.SetKeyName(30, "ico_16_1001.png");
            this.imageList1.Images.SetKeyName(31, "ico_16_1010.gif");
            this.imageList1.Images.SetKeyName(32, "ico_16_1011.gif");
            this.imageList1.Images.SetKeyName(33, "ico_16_1013.gif");
            this.imageList1.Images.SetKeyName(34, "ico_16_1016.gif");
            this.imageList1.Images.SetKeyName(35, "ico_16_1022.gif");
            this.imageList1.Images.SetKeyName(36, "ico_16_1024.gif");
            this.imageList1.Images.SetKeyName(37, "ico_16_1025.gif");
            this.imageList1.Images.SetKeyName(38, "ico_16_1026.gif");
            this.imageList1.Images.SetKeyName(39, "ico_16_1028.gif");
            this.imageList1.Images.SetKeyName(40, "ico_16_1030.gif");
            this.imageList1.Images.SetKeyName(41, "ico_16_1030_8.gif");
            this.imageList1.Images.SetKeyName(42, "ico_16_1032.gif");
            this.imageList1.Images.SetKeyName(43, "ico_16_1036.gif");
            this.imageList1.Images.SetKeyName(44, "ico_16_1038.gif");
            this.imageList1.Images.SetKeyName(45, "ico_16_1039.gif");
            this.imageList1.Images.SetKeyName(46, "ico_16_1048.gif");
            this.imageList1.Images.SetKeyName(47, "ico_16_1049.gif");
            this.imageList1.Images.SetKeyName(48, "ico_16_1055.gif");
            this.imageList1.Images.SetKeyName(49, "ico_16_1056.gif");
            this.imageList1.Images.SetKeyName(50, "ico_16_1071.gif");
            this.imageList1.Images.SetKeyName(51, "ico_16_1080.gif");
            this.imageList1.Images.SetKeyName(52, "ico_16_1083.gif");
            this.imageList1.Images.SetKeyName(53, "ico_16_1084.gif");
            this.imageList1.Images.SetKeyName(54, "ico_16_1085.gif");
            this.imageList1.Images.SetKeyName(55, "ico_16_1088.gif");
            this.imageList1.Images.SetKeyName(56, "ico_16_1089.gif");
            this.imageList1.Images.SetKeyName(57, "ico_16_1090.gif");
            this.imageList1.Images.SetKeyName(58, "ico_16_1091.gif");
            this.imageList1.Images.SetKeyName(59, "ico_16_1111.png");
            this.imageList1.Images.SetKeyName(60, "ico_16_1112.png");
            this.imageList1.Images.SetKeyName(61, "ico_16_1141.gif");
            this.imageList1.Images.SetKeyName(62, "ico_16_1142.gif");
            this.imageList1.Images.SetKeyName(63, "ico_16_1144.gif");
            this.imageList1.Images.SetKeyName(64, "ico_16_1145.gif");
            this.imageList1.Images.SetKeyName(65, "ico_16_1146.gif");
            this.imageList1.Images.SetKeyName(66, "ico_16_1147.gif");
            this.imageList1.Images.SetKeyName(67, "ico_16_1148.gif");
            this.imageList1.Images.SetKeyName(68, "ico_16_1149.gif");
            this.imageList1.Images.SetKeyName(69, "ico_16_1150.gif");
            this.imageList1.Images.SetKeyName(70, "ico_16_1151.gif");
            this.imageList1.Images.SetKeyName(71, "ico_16_1152.gif");
            this.imageList1.Images.SetKeyName(72, "ico_16_1200.png");
            this.imageList1.Images.SetKeyName(73, "ico_16_1234.png");
            this.imageList1.Images.SetKeyName(74, "ico_16_1235.gif");
            this.imageList1.Images.SetKeyName(75, "ico_16_1236.png");
            this.imageList1.Images.SetKeyName(76, "ico_16_1333.gif");
            this.imageList1.Images.SetKeyName(77, "ico_16_2010.gif");
            this.imageList1.Images.SetKeyName(78, "ico_16_2011.gif");
            this.imageList1.Images.SetKeyName(79, "ico_16_2013.gif");
            this.imageList1.Images.SetKeyName(80, "ico_16_2020.gif");
            this.imageList1.Images.SetKeyName(81, "ico_16_2029.gif");
            this.imageList1.Images.SetKeyName(82, "ico_16_3231.png");
            this.imageList1.Images.SetKeyName(83, "ico_16_3234.gif");
            this.imageList1.Images.SetKeyName(84, "ico_16_4000.gif");
            this.imageList1.Images.SetKeyName(85, "ico_16_4001.gif");
            this.imageList1.Images.SetKeyName(86, "ico_16_4002.gif");
            this.imageList1.Images.SetKeyName(87, "ico_16_4007.gif");
            this.imageList1.Images.SetKeyName(88, "ico_16_4009.gif");
            this.imageList1.Images.SetKeyName(89, "ico_16_4200.gif");
            this.imageList1.Images.SetKeyName(90, "ico_16_4201.gif");
            this.imageList1.Images.SetKeyName(91, "ico_16_4202.gif");
            this.imageList1.Images.SetKeyName(92, "ico_16_4204.gif");
            this.imageList1.Images.SetKeyName(93, "ico_16_4206.gif");
            this.imageList1.Images.SetKeyName(94, "ico_16_4207.gif");
            this.imageList1.Images.SetKeyName(95, "ico_16_4208.gif");
            this.imageList1.Images.SetKeyName(96, "ico_16_4209.gif");
            this.imageList1.Images.SetKeyName(97, "ico_16_4210.gif");
            this.imageList1.Images.SetKeyName(98, "ico_16_4211.gif");
            this.imageList1.Images.SetKeyName(99, "ico_16_4212.gif");
            this.imageList1.Images.SetKeyName(100, "ico_16_4214.gif");
            this.imageList1.Images.SetKeyName(101, "ico_16_4216.gif");
            this.imageList1.Images.SetKeyName(102, "ico_16_4230.gif");
            this.imageList1.Images.SetKeyName(103, "ico_16_4251.gif");
            this.imageList1.Images.SetKeyName(104, "ico_16_4300.gif");
            this.imageList1.Images.SetKeyName(105, "ico_16_4400.gif");
            this.imageList1.Images.SetKeyName(106, "ico_16_4401.gif");
            this.imageList1.Images.SetKeyName(107, "ico_16_4402.gif");
            this.imageList1.Images.SetKeyName(108, "ico_16_4406.png");
            this.imageList1.Images.SetKeyName(109, "ico_16_4411.gif");
            this.imageList1.Images.SetKeyName(110, "ico_16_4414.gif");
            this.imageList1.Images.SetKeyName(111, "ico_16_4502.gif");
            this.imageList1.Images.SetKeyName(112, "ico_16_4503.gif");
            this.imageList1.Images.SetKeyName(113, "ico_16_4605.png");
            this.imageList1.Images.SetKeyName(114, "ico_16_4608.png");
            this.imageList1.Images.SetKeyName(115, "ico_16_4618.png");
            this.imageList1.Images.SetKeyName(116, "ico_16_4703.png");
            this.imageList1.Images.SetKeyName(117, "ico_16_4710.png");
            this.imageList1.Images.SetKeyName(118, "ico_16_7100.gif");
            this.imageList1.Images.SetKeyName(119, "ico_16_7101.png");
            this.imageList1.Images.SetKeyName(120, "ico_16_8181.gif");
            this.imageList1.Images.SetKeyName(121, "ico_16_8199.gif");
            this.imageList1.Images.SetKeyName(122, "ico_16_9006.png");
            this.imageList1.Images.SetKeyName(123, "ico_16_9100.gif");
            this.imageList1.Images.SetKeyName(124, "ico_16_9105.gif");
            this.imageList1.Images.SetKeyName(125, "ico_16_9106.gif");
            this.imageList1.Images.SetKeyName(126, "ico_16_9300.png");
            this.imageList1.Images.SetKeyName(127, "ico_16_9301.png");
            this.imageList1.Images.SetKeyName(128, "ico_16_9333.gif");
            this.imageList1.Images.SetKeyName(129, "ico_16_9502.png");
            this.imageList1.Images.SetKeyName(130, "ico_16_9507.png");
            this.imageList1.Images.SetKeyName(131, "ico_16_9508.png");
            this.imageList1.Images.SetKeyName(132, "ico_16_9600.png");
            this.imageList1.Images.SetKeyName(133, "ico_16_9602.png");
            this.imageList1.Images.SetKeyName(134, "ico_16_9603.png");
            this.imageList1.Images.SetKeyName(135, "ico_16_9605.gif");
            this.imageList1.Images.SetKeyName(136, "ico_16_9606.gif");
            this.imageList1.Images.SetKeyName(137, "ico_16_9700.gif");
            this.imageList1.Images.SetKeyName(138, "ico_16_9701.gif");
            this.imageList1.Images.SetKeyName(139, "ico_16_9702.gif");
            this.imageList1.Images.SetKeyName(140, "ico_16_9703.gif");
            this.imageList1.Images.SetKeyName(141, "ico_16_9750.gif");
            this.imageList1.Images.SetKeyName(142, "ico_16_9752.gif");
            this.imageList1.Images.SetKeyName(143, "ico_16_9753.png");
            this.imageList1.Images.SetKeyName(144, "ico_16_9801.gif");
            this.imageList1.Images.SetKeyName(145, "ico_16_9804.png");
            this.imageList1.Images.SetKeyName(146, "ico_16_9869.gif");
            this.imageList1.Images.SetKeyName(147, "ico_16_9930.png");
            this.imageList1.Images.SetKeyName(148, "ico_16_9953.png");
            this.imageList1.Images.SetKeyName(149, "ico_16_9954.png");
            this.imageList1.Images.SetKeyName(150, "ico_16_9955.png");
            this.imageList1.Images.SetKeyName(151, "ico_16_9958.gif");
            this.imageList1.Images.SetKeyName(152, "ico_16_9959.png");
            this.imageList1.Images.SetKeyName(153, "ico_16_9997.gif");
            this.imageList1.Images.SetKeyName(154, "ico_16_forms.png");
            this.imageList1.Images.SetKeyName(155, "ico_16_insertCheck.gif");
            this.imageList1.Images.SetKeyName(156, "ico_16_relationshipsn2n.gif");
            this.imageList1.Images.SetKeyName(157, "ico_16_relationshipsn21.gif");
            this.imageList1.Images.SetKeyName(158, "ico_16_systemEntity.gif");
            this.imageList1.Images.SetKeyName(159, "ico_16_views.png");
            this.imageList1.Images.SetKeyName(160, "ico_16_visualizations.gif");
            this.imageList1.Images.SetKeyName(161, "ico_18_7100.gif");
            this.imageList1.Images.SetKeyName(162, "ico_18_attributes.gif");
            this.imageList1.Images.SetKeyName(163, "ico_18_entityinfo.gif");
            this.imageList1.Images.SetKeyName(164, "ico_18_messages.gif");
            this.imageList1.Images.SetKeyName(165, "ico_18_relationships.gif");
            this.imageList1.Images.SetKeyName(166, "ico_fhe_7100.png");
            this.imageList1.Images.SetKeyName(167, "icon (1).gif");
            this.imageList1.Images.SetKeyName(168, "icon (2).gif");
            this.imageList1.Images.SetKeyName(169, "icon (3).gif");
            this.imageList1.Images.SetKeyName(170, "icon (4).gif");
            this.imageList1.Images.SetKeyName(171, "icon (5).gif");
            this.imageList1.Images.SetKeyName(172, "icon (6).gif");
            this.imageList1.Images.SetKeyName(173, "icon (7).gif");
            this.imageList1.Images.SetKeyName(174, "icon (8).gif");
            this.imageList1.Images.SetKeyName(175, "icon.gif");
            this.imageList1.Images.SetKeyName(176, "mnu_actions.gif");
            this.imageList1.Images.SetKeyName(177, "navcollapsedarrow16_silver.png");
            this.imageList1.Images.SetKeyName(178, "poperties_16.png");
            this.imageList1.Images.SetKeyName(179, "PostConfig_16px.png");
            this.imageList1.Images.SetKeyName(180, "PostConfigRules_16px.png");
            this.imageList1.Images.SetKeyName(181, "publish.png");
            this.imageList1.Images.SetKeyName(182, "publishall.gif");
            this.imageList1.Images.SetKeyName(183, "tab_line.gif");
            this.imageList1.Images.SetKeyName(184, "translations.gif");
            this.imageList1.Images.SetKeyName(185, "transparent_spacer.gif");
            // 
            // tabCtrlMain
            // 
            this.tabCtrlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlMain.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlMain.Name = "tabCtrlMain";
            this.tabCtrlMain.SelectedIndex = 0;
            this.tabCtrlMain.Size = new System.Drawing.Size(1184, 880);
            this.tabCtrlMain.TabIndex = 2;
            // 
            // tabDeploymentExplorer
            // 
            this.tabDeploymentExplorer.BackColor = System.Drawing.Color.SlateGray;
            this.tabDeploymentExplorer.Controls.Add(this.splitContainer1);
            this.tabDeploymentExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDeploymentExplorer.Location = new System.Drawing.Point(4, 22);
            this.tabDeploymentExplorer.Name = "tabDeploymentExplorer";
            this.tabDeploymentExplorer.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeploymentExplorer.Size = new System.Drawing.Size(1176, 854);
            this.tabDeploymentExplorer.TabIndex = 0;
            this.tabDeploymentExplorer.Text = "Deployment Explorer";
            // 
            // tabOrgDiff
            // 
            this.tabOrgDiff.BackColor = System.Drawing.Color.White;
            this.tabOrgDiff.Controls.Add(this.splitContainer3);
            this.tabOrgDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOrgDiff.Location = new System.Drawing.Point(4, 22);
            this.tabOrgDiff.Name = "tabOrgDiff";
            this.tabOrgDiff.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrgDiff.Size = new System.Drawing.Size(1176, 830);
            this.tabOrgDiff.TabIndex = 1;
            this.tabOrgDiff.Text = "Organization Diff.";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lvEntities);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.entityDiffControl1);
            this.splitContainer3.Panel2.Controls.Add(this.clbDiffOptions);
            this.splitContainer3.Panel2.Controls.Add(this.menuStrip2);
            this.splitContainer3.Size = new System.Drawing.Size(1170, 824);
            this.splitContainer3.SplitterDistance = 120;
            this.splitContainer3.TabIndex = 0;
            // 
            // lvEntities
            // 
            this.lvEntities.CheckBoxes = true;
            this.lvEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEntities.Location = new System.Drawing.Point(0, 0);
            this.lvEntities.Name = "lvEntities";
            this.lvEntities.Size = new System.Drawing.Size(120, 824);
            this.lvEntities.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvEntities.TabIndex = 0;
            this.lvEntities.UseCompatibleStateImageBehavior = false;
            this.lvEntities.View = System.Windows.Forms.View.SmallIcon;
            // 
            // entityDiffControl1
            // 
            this.entityDiffControl1.AutoScroll = true;
            this.entityDiffControl1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.entityDiffControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityDiffControl1.ForeColor = System.Drawing.Color.LightSlateGray;
            this.entityDiffControl1.Location = new System.Drawing.Point(0, 76);
            this.entityDiffControl1.Name = "entityDiffControl1";
            this.entityDiffControl1.Size = new System.Drawing.Size(1046, 748);
            this.entityDiffControl1.TabIndex = 2;
            // 
            // clbDiffOptions
            // 
            this.clbDiffOptions.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clbDiffOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.clbDiffOptions.FormattingEnabled = true;
            this.clbDiffOptions.Items.AddRange(new object[] {
            "Entities",
            "Attributes",
            "Forms",
            "Views",
            "Relationships",
            "Option Sets",
            "Web Resources",
            "Processes",
            "Plugins",
            "Plugin Steps",
            "Article Templates",
            "Contract Templates",
            "Email Templates",
            "Mail Merge Templates",
            "Security Roles",
            "Field Security Profiles",
            "Reports",
            "Dashboards",
            "SLAs"});
            this.clbDiffOptions.Location = new System.Drawing.Point(0, 27);
            this.clbDiffOptions.MultiColumn = true;
            this.clbDiffOptions.Name = "clbDiffOptions";
            this.clbDiffOptions.Size = new System.Drawing.Size(1046, 49);
            this.clbDiffOptions.TabIndex = 1;
            this.clbDiffOptions.Visible = false;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbLeftOrg,
            this.cbRightOrg,
            this.MIOptions,
            this.miLoadEntities,
            this.menuItemDiff});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1046, 27);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // cbLeftOrg
            // 
            this.cbLeftOrg.Name = "cbLeftOrg";
            this.cbLeftOrg.Size = new System.Drawing.Size(250, 23);
            this.cbLeftOrg.SelectedIndexChanged += new System.EventHandler(this.CBLeftOrg_SelectedIndexChanged);
            // 
            // cbRightOrg
            // 
            this.cbRightOrg.Name = "cbRightOrg";
            this.cbRightOrg.Size = new System.Drawing.Size(250, 23);
            this.cbRightOrg.SelectedIndexChanged += new System.EventHandler(this.CBRightOrg_SelectedIndexChanged);
            // 
            // MIOptions
            // 
            this.MIOptions.Image = global::Xrm.DevOPs.Manager.Properties.Resources.ico_16_9300;
            this.MIOptions.Name = "MIOptions";
            this.MIOptions.Size = new System.Drawing.Size(77, 23);
            this.MIOptions.Text = "Options";
            this.MIOptions.Click += new System.EventHandler(this.MIOptions_Click);
            // 
            // miLoadEntities
            // 
            this.miLoadEntities.Image = global::Xrm.DevOPs.Manager.Properties.Resources.ico_16_9801;
            this.miLoadEntities.Name = "miLoadEntities";
            this.miLoadEntities.Size = new System.Drawing.Size(102, 23);
            this.miLoadEntities.Text = "Load Entities";
            this.miLoadEntities.Click += new System.EventHandler(this.MILoadEntities_Click);
            // 
            // menuItemDiff
            // 
            this.menuItemDiff.Image = global::Xrm.DevOPs.Manager.Properties.Resources.ico_16_1048;
            this.menuItemDiff.Name = "menuItemDiff";
            this.menuItemDiff.Size = new System.Drawing.Size(84, 23);
            this.menuItemDiff.Text = "Compare";
            this.menuItemDiff.Click += new System.EventHandler(this.MIDiff_Click);
            // 
            // tabSolCompare
            // 
            this.tabSolCompare.BackColor = System.Drawing.Color.White;
            this.tabSolCompare.Controls.Add(this.ctrlSolutionCompare);
            this.tabSolCompare.Location = new System.Drawing.Point(4, 22);
            this.tabSolCompare.Name = "tabSolCompare";
            this.tabSolCompare.Size = new System.Drawing.Size(1176, 830);
            this.tabSolCompare.TabIndex = 2;
            this.tabSolCompare.Text = "Solution Compare";
            // 
            // ctrlSolutionCompare
            // 
            this.ctrlSolutionCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSolutionCompare.Location = new System.Drawing.Point(0, 0);
            this.ctrlSolutionCompare.Name = "ctrlSolutionCompare";
            this.ctrlSolutionCompare.OrganizationTree = null;
            this.ctrlSolutionCompare.Size = new System.Drawing.Size(1176, 830);
            this.ctrlSolutionCompare.TabIndex = 0;
            // 
            // tabSyncTool
            // 
            this.tabSyncTool.BackColor = System.Drawing.Color.White;
            this.tabSyncTool.Controls.Add(this.orgSyncControl);
            this.tabSyncTool.Controls.Add(this.BtnSyncOrgs);
            this.tabSyncTool.Controls.Add(this.BtnTransfer);
            this.tabSyncTool.Location = new System.Drawing.Point(4, 22);
            this.tabSyncTool.Name = "tabSyncTool";
            this.tabSyncTool.Size = new System.Drawing.Size(1176, 830);
            this.tabSyncTool.TabIndex = 3;
            this.tabSyncTool.Text = "Deployment Manager";
            // 
            // orgSyncControl
            // 
            this.orgSyncControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orgSyncControl.Location = new System.Drawing.Point(0, 0);
            this.orgSyncControl.Name = "orgSyncControl";
            this.orgSyncControl.Size = new System.Drawing.Size(1176, 830);
            this.orgSyncControl.TabIndex = 9;
            // 
            // BtnSyncOrgs
            // 
            this.BtnSyncOrgs.Location = new System.Drawing.Point(552, 640);
            this.BtnSyncOrgs.Name = "BtnSyncOrgs";
            this.BtnSyncOrgs.Size = new System.Drawing.Size(157, 23);
            this.BtnSyncOrgs.TabIndex = 8;
            this.BtnSyncOrgs.Text = "Sync. Organizations";
            this.BtnSyncOrgs.UseVisualStyleBackColor = true;
            // 
            // BtnTransfer
            // 
            this.BtnTransfer.Location = new System.Drawing.Point(445, 640);
            this.BtnTransfer.Name = "BtnTransfer";
            this.BtnTransfer.Size = new System.Drawing.Size(101, 23);
            this.BtnTransfer.TabIndex = 7;
            this.BtnTransfer.Text = "Transfer";
            this.BtnTransfer.UseVisualStyleBackColor = true;
            // 
            // pbHome
            // 
            this.pbHome.BackColor = System.Drawing.Color.LightGray;
            this.pbHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbHome.BackgroundImage")));
            this.pbHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbHome.InitialImage = null;
            this.pbHome.Location = new System.Drawing.Point(788, 27);
            this.pbHome.Name = "pbHome";
            this.pbHome.Size = new System.Drawing.Size(352, 297);
            this.pbHome.TabIndex = 3;
            this.pbHome.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(988, 821);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMessage,
            this.statusProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 858);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusMessage
            // 
            this.statusMessage.Name = "statusMessage";
            this.statusMessage.Size = new System.Drawing.Size(50, 17);
            this.statusMessage.Text = "Loading";
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(1100, 16);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 880);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabCtrlMain);
            this.Controls.Add(this.pbHome);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "CRM DevOPs Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabDeploymentExplorer.ResumeLayout(false);
            this.tabOrgDiff.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tabSolCompare.ResumeLayout(false);
            this.tabSyncTool.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvOrgs;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabControl tabCtrlMain;
        private System.Windows.Forms.TabPage tabDeploymentExplorer;
        private System.Windows.Forms.TabPage tabOrgDiff;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView lvEntities;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem menuItemDiff;
        private EntityDiffControl entityDiffControl1;
        private System.Windows.Forms.ToolStripMenuItem miLoadEntities;
        private System.Windows.Forms.CheckedListBox clbDiffOptions;
        private System.Windows.Forms.ToolStripComboBox cbLeftOrg;
        private System.Windows.Forms.ToolStripComboBox cbRightOrg;
        private System.Windows.Forms.ToolStripMenuItem MIOptions;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabSolCompare;
        private SolutionCompareControl ctrlSolutionCompare;
        private System.Windows.Forms.ToolStripMenuItem organizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MIOrgCompare;
        private System.Windows.Forms.ToolStripMenuItem solutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MISolCompare;
        private System.Windows.Forms.ToolStripMenuItem MISolTransfer;
        private System.Windows.Forms.TabPage tabSyncTool;
        private System.Windows.Forms.Button BtnTransfer;
        private System.Windows.Forms.Button BtnSyncOrgs;
        private Controls.OrganizationSyncControl orgSyncControl;
        private System.Windows.Forms.PictureBox pbHome;
        private System.Windows.Forms.ToolStripMenuItem MIFile;
        private System.Windows.Forms.ToolStripMenuItem MILoadOrganizations;
        private System.Windows.Forms.ToolStripMenuItem MIExit;
        private System.Windows.Forms.ToolStripMenuItem MIView;
        private System.Windows.Forms.ToolStripMenuItem MICloseActiveWindow;
        private System.Windows.Forms.ToolStripMenuItem MICloseAllWindows;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusMessage;
        private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        private System.Windows.Forms.ToolStripMenuItem MIDeployment;
        private System.Windows.Forms.ToolStripMenuItem MIDeploymentManager;
    }
}

