﻿namespace HM_1X_Aid_v01
{
    partial class MainDisplay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDisplay));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPortsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbcBottomPane = new System.Windows.Forms.TabControl();
            this.tabPortSettings = new System.Windows.Forms.TabPage();
            this.tloPortSettings = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPortNumberInPortSettingsTab = new System.Windows.Forms.ComboBox();
            this.cmbBaudRatePortSettingsTab = new System.Windows.Forms.ComboBox();
            this.cmbStopBitsPortSettingsTab = new System.Windows.Forms.ComboBox();
            this.cmbParityPortSettingsTab = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDataBitsPortSettingsTab = new System.Windows.Forms.ComboBox();
            this.cmbHandshakingPortSettingsTab = new System.Windows.Forms.ComboBox();
            this.tabDataSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbCharsAfterTx = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDataAs = new System.Windows.Forms.ComboBox();
            this.String = new System.Windows.Forms.Label();
            this.cmbCharAfterRx = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabTSB = new System.Windows.Forms.TabPage();
            this.ltbTSB = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rtbHexFilePath = new System.Windows.Forms.RichTextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnWriteHexFile = new System.Windows.Forms.Button();
            this.btnReadHexFile = new System.Windows.Forms.Button();
            this.cmbChip = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSend = new System.Windows.Forms.Button();
            this.txbSendTextBox = new System.Windows.Forms.TextBox();
            this.btnToggleStringHexSendText = new System.Windows.Forms.Button();
            this.btnClearSendBox = new System.Windows.Forms.Button();
            this.rtbMainDisplay = new System.Windows.Forms.RichTextBox();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.txbSysMsg = new System.Windows.Forms.TextBox();
            this.btmClearMainDisplay = new System.Windows.Forms.Button();
            this.pbSysStatus = new System.Windows.Forms.ProgressBar();
            this.lblTSB = new System.Windows.Forms.Label();
            this.btnConnectToTSB = new System.Windows.Forms.Button();
            this.ofdHexFile = new System.Windows.Forms.OpenFileDialog();
            this.mnuMainMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbcBottomPane.SuspendLayout();
            this.tabPortSettings.SuspendLayout();
            this.tloPortSettings.SuspendLayout();
            this.tabDataSettings.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabTSB.SuspendLayout();
            this.ltbTSB.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.serialPortsToolStripMenuItem});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Size = new System.Drawing.Size(1200, 33);
            this.mnuMainMenu.TabIndex = 1;
            this.mnuMainMenu.Text = "menuStrip1";
            this.mnuMainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(203, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(203, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(199, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(168, 30);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(168, 30);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(168, 30);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(165, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(168, 30);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // serialPortsToolStripMenuItem
            // 
            this.serialPortsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem});
            this.serialPortsToolStripMenuItem.Name = "serialPortsToolStripMenuItem";
            this.serialPortsToolStripMenuItem.Size = new System.Drawing.Size(111, 29);
            this.serialPortsToolStripMenuItem.Text = "Serial Ports";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(140, 30);
            this.defaultToolStripMenuItem.Text = "None";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbcBottomPane, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rtbMainDisplay, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(219, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.24034F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.85788F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.90178F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(969, 668);
            this.tableLayoutPanel1.TabIndex = 4;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // tbcBottomPane
            // 
            this.tbcBottomPane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcBottomPane.Controls.Add(this.tabPortSettings);
            this.tbcBottomPane.Controls.Add(this.tabDataSettings);
            this.tbcBottomPane.Controls.Add(this.tabTSB);
            this.tbcBottomPane.Location = new System.Drawing.Point(3, 464);
            this.tbcBottomPane.Name = "tbcBottomPane";
            this.tbcBottomPane.SelectedIndex = 0;
            this.tbcBottomPane.Size = new System.Drawing.Size(963, 201);
            this.tbcBottomPane.TabIndex = 0;
            // 
            // tabPortSettings
            // 
            this.tabPortSettings.Controls.Add(this.tloPortSettings);
            this.tabPortSettings.Location = new System.Drawing.Point(4, 29);
            this.tabPortSettings.Name = "tabPortSettings";
            this.tabPortSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPortSettings.Size = new System.Drawing.Size(955, 168);
            this.tabPortSettings.TabIndex = 0;
            this.tabPortSettings.Text = "Port Settings";
            this.tabPortSettings.UseVisualStyleBackColor = true;
            // 
            // tloPortSettings
            // 
            this.tloPortSettings.ColumnCount = 3;
            this.tloPortSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.30517F));
            this.tloPortSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.59134F));
            this.tloPortSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.10349F));
            this.tloPortSettings.Controls.Add(this.label1, 0, 0);
            this.tloPortSettings.Controls.Add(this.label2, 0, 1);
            this.tloPortSettings.Controls.Add(this.label4, 0, 4);
            this.tloPortSettings.Controls.Add(this.label3, 0, 3);
            this.tloPortSettings.Controls.Add(this.cmbPortNumberInPortSettingsTab, 1, 0);
            this.tloPortSettings.Controls.Add(this.cmbBaudRatePortSettingsTab, 1, 1);
            this.tloPortSettings.Controls.Add(this.cmbStopBitsPortSettingsTab, 1, 3);
            this.tloPortSettings.Controls.Add(this.cmbParityPortSettingsTab, 1, 4);
            this.tloPortSettings.Controls.Add(this.label5, 0, 2);
            this.tloPortSettings.Controls.Add(this.label6, 0, 5);
            this.tloPortSettings.Controls.Add(this.cmbDataBitsPortSettingsTab, 1, 2);
            this.tloPortSettings.Controls.Add(this.cmbHandshakingPortSettingsTab, 1, 5);
            this.tloPortSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tloPortSettings.Location = new System.Drawing.Point(3, 3);
            this.tloPortSettings.Name = "tloPortSettings";
            this.tloPortSettings.RowCount = 6;
            this.tloPortSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.tloPortSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.tloPortSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66933F));
            this.tloPortSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.tloPortSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.tloPortSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tloPortSettings.Size = new System.Drawing.Size(949, 162);
            this.tloPortSettings.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Parity";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stop Bits";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPortNumberInPortSettingsTab
            // 
            this.cmbPortNumberInPortSettingsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPortNumberInPortSettingsTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortNumberInPortSettingsTab.Enabled = false;
            this.cmbPortNumberInPortSettingsTab.FormattingEnabled = true;
            this.cmbPortNumberInPortSettingsTab.Location = new System.Drawing.Point(129, 3);
            this.cmbPortNumberInPortSettingsTab.Name = "cmbPortNumberInPortSettingsTab";
            this.cmbPortNumberInPortSettingsTab.Size = new System.Drawing.Size(189, 28);
            this.cmbPortNumberInPortSettingsTab.TabIndex = 4;
            this.cmbPortNumberInPortSettingsTab.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cmbBaudRatePortSettingsTab
            // 
            this.cmbBaudRatePortSettingsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBaudRatePortSettingsTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRatePortSettingsTab.Enabled = false;
            this.cmbBaudRatePortSettingsTab.FormattingEnabled = true;
            this.cmbBaudRatePortSettingsTab.Location = new System.Drawing.Point(129, 29);
            this.cmbBaudRatePortSettingsTab.Name = "cmbBaudRatePortSettingsTab";
            this.cmbBaudRatePortSettingsTab.Size = new System.Drawing.Size(189, 28);
            this.cmbBaudRatePortSettingsTab.TabIndex = 5;
            this.cmbBaudRatePortSettingsTab.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // cmbStopBitsPortSettingsTab
            // 
            this.cmbStopBitsPortSettingsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStopBitsPortSettingsTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBitsPortSettingsTab.Enabled = false;
            this.cmbStopBitsPortSettingsTab.FormattingEnabled = true;
            this.cmbStopBitsPortSettingsTab.Location = new System.Drawing.Point(129, 82);
            this.cmbStopBitsPortSettingsTab.Name = "cmbStopBitsPortSettingsTab";
            this.cmbStopBitsPortSettingsTab.Size = new System.Drawing.Size(189, 28);
            this.cmbStopBitsPortSettingsTab.TabIndex = 6;
            this.cmbStopBitsPortSettingsTab.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // cmbParityPortSettingsTab
            // 
            this.cmbParityPortSettingsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbParityPortSettingsTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParityPortSettingsTab.Enabled = false;
            this.cmbParityPortSettingsTab.FormattingEnabled = true;
            this.cmbParityPortSettingsTab.Location = new System.Drawing.Point(129, 108);
            this.cmbParityPortSettingsTab.Name = "cmbParityPortSettingsTab";
            this.cmbParityPortSettingsTab.Size = new System.Drawing.Size(189, 28);
            this.cmbParityPortSettingsTab.TabIndex = 7;
            this.cmbParityPortSettingsTab.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 27);
            this.label5.TabIndex = 8;
            this.label5.Text = "Data Bits";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 31);
            this.label6.TabIndex = 9;
            this.label6.Text = "Handshaking";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDataBitsPortSettingsTab
            // 
            this.cmbDataBitsPortSettingsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDataBitsPortSettingsTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBitsPortSettingsTab.Enabled = false;
            this.cmbDataBitsPortSettingsTab.FormattingEnabled = true;
            this.cmbDataBitsPortSettingsTab.Location = new System.Drawing.Point(129, 55);
            this.cmbDataBitsPortSettingsTab.Name = "cmbDataBitsPortSettingsTab";
            this.cmbDataBitsPortSettingsTab.Size = new System.Drawing.Size(189, 28);
            this.cmbDataBitsPortSettingsTab.TabIndex = 10;
            // 
            // cmbHandshakingPortSettingsTab
            // 
            this.cmbHandshakingPortSettingsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbHandshakingPortSettingsTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHandshakingPortSettingsTab.Enabled = false;
            this.cmbHandshakingPortSettingsTab.FormattingEnabled = true;
            this.cmbHandshakingPortSettingsTab.Location = new System.Drawing.Point(129, 134);
            this.cmbHandshakingPortSettingsTab.Name = "cmbHandshakingPortSettingsTab";
            this.cmbHandshakingPortSettingsTab.Size = new System.Drawing.Size(189, 28);
            this.cmbHandshakingPortSettingsTab.TabIndex = 11;
            // 
            // tabDataSettings
            // 
            this.tabDataSettings.Controls.Add(this.tableLayoutPanel3);
            this.tabDataSettings.Location = new System.Drawing.Point(4, 29);
            this.tabDataSettings.Name = "tabDataSettings";
            this.tabDataSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataSettings.Size = new System.Drawing.Size(955, 168);
            this.tabDataSettings.TabIndex = 1;
            this.tabDataSettings.Text = "Data Settings";
            this.tabDataSettings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.43625F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.65332F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.80506F));
            this.tableLayoutPanel3.Controls.Add(this.cmbCharsAfterTx, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.cmbDataAs, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.String, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmbCharAfterRx, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(949, 162);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // cmbCharsAfterTx
            // 
            this.cmbCharsAfterTx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCharsAfterTx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCharsAfterTx.FormattingEnabled = true;
            this.cmbCharsAfterTx.Location = new System.Drawing.Point(140, 67);
            this.cmbCharsAfterTx.Name = "cmbCharsAfterTx";
            this.cmbCharsAfterTx.Size = new System.Drawing.Size(190, 28);
            this.cmbCharsAfterTx.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 32);
            this.label8.TabIndex = 9;
            this.label8.Text = "Char(s) after TX";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDataAs
            // 
            this.cmbDataAs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDataAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataAs.FormattingEnabled = true;
            this.cmbDataAs.Location = new System.Drawing.Point(140, 3);
            this.cmbDataAs.Name = "cmbDataAs";
            this.cmbDataAs.Size = new System.Drawing.Size(190, 28);
            this.cmbDataAs.TabIndex = 5;
            // 
            // String
            // 
            this.String.AutoSize = true;
            this.String.Dock = System.Windows.Forms.DockStyle.Fill;
            this.String.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.String.Location = new System.Drawing.Point(3, 0);
            this.String.Name = "String";
            this.String.Size = new System.Drawing.Size(131, 32);
            this.String.TabIndex = 0;
            this.String.Text = "Display Data As";
            this.String.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.String.Click += new System.EventHandler(this.String_Click);
            // 
            // cmbCharAfterRx
            // 
            this.cmbCharAfterRx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCharAfterRx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCharAfterRx.FormattingEnabled = true;
            this.cmbCharAfterRx.Location = new System.Drawing.Point(140, 35);
            this.cmbCharAfterRx.Name = "cmbCharAfterRx";
            this.cmbCharAfterRx.Size = new System.Drawing.Size(190, 28);
            this.cmbCharAfterRx.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 32);
            this.label7.TabIndex = 7;
            this.label7.Text = "Char(s) after RX";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabTSB
            // 
            this.tabTSB.Controls.Add(this.ltbTSB);
            this.tabTSB.Location = new System.Drawing.Point(4, 29);
            this.tabTSB.Name = "tabTSB";
            this.tabTSB.Padding = new System.Windows.Forms.Padding(3);
            this.tabTSB.Size = new System.Drawing.Size(955, 168);
            this.tabTSB.TabIndex = 2;
            this.tabTSB.Text = "TSB";
            this.tabTSB.UseVisualStyleBackColor = true;
            // 
            // ltbTSB
            // 
            this.ltbTSB.ColumnCount = 3;
            this.ltbTSB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.61222F));
            this.ltbTSB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.38778F));
            this.ltbTSB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 385F));
            this.ltbTSB.Controls.Add(this.label9, 0, 2);
            this.ltbTSB.Controls.Add(this.label10, 0, 1);
            this.ltbTSB.Controls.Add(this.rtbHexFilePath, 1, 1);
            this.ltbTSB.Controls.Add(this.btnOpenFile, 1, 0);
            this.ltbTSB.Controls.Add(this.btnWriteHexFile, 1, 3);
            this.ltbTSB.Controls.Add(this.btnReadHexFile, 2, 3);
            this.ltbTSB.Controls.Add(this.cmbChip, 1, 2);
            this.ltbTSB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltbTSB.Location = new System.Drawing.Point(3, 3);
            this.ltbTSB.Name = "ltbTSB";
            this.ltbTSB.RowCount = 4;
            this.ltbTSB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ltbTSB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ltbTSB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ltbTSB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.ltbTSB.Size = new System.Drawing.Size(949, 162);
            this.ltbTSB.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 40);
            this.label9.TabIndex = 6;
            this.label9.Text = "Chip:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(172, 40);
            this.label10.TabIndex = 5;
            this.label10.Text = "Hex File Path:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtbHexFilePath
            // 
            this.rtbHexFilePath.DetectUrls = false;
            this.rtbHexFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHexFilePath.ForeColor = System.Drawing.SystemColors.MenuText;
            this.rtbHexFilePath.Location = new System.Drawing.Point(181, 43);
            this.rtbHexFilePath.Multiline = false;
            this.rtbHexFilePath.Name = "rtbHexFilePath";
            this.rtbHexFilePath.ReadOnly = true;
            this.rtbHexFilePath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbHexFilePath.Size = new System.Drawing.Size(379, 34);
            this.rtbHexFilePath.TabIndex = 2;
            this.rtbHexFilePath.Text = "None";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenFile.Location = new System.Drawing.Point(181, 3);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(379, 34);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "Open Hex File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnWriteHexFile
            // 
            this.btnWriteHexFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWriteHexFile.Enabled = false;
            this.btnWriteHexFile.Location = new System.Drawing.Point(181, 123);
            this.btnWriteHexFile.Name = "btnWriteHexFile";
            this.btnWriteHexFile.Size = new System.Drawing.Size(379, 36);
            this.btnWriteHexFile.TabIndex = 1;
            this.btnWriteHexFile.Text = "Write File";
            this.btnWriteHexFile.UseVisualStyleBackColor = true;
            this.btnWriteHexFile.Click += new System.EventHandler(this.btnWriteHexFile_Click);
            // 
            // btnReadHexFile
            // 
            this.btnReadHexFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadHexFile.Location = new System.Drawing.Point(566, 123);
            this.btnReadHexFile.Name = "btnReadHexFile";
            this.btnReadHexFile.Size = new System.Drawing.Size(380, 36);
            this.btnReadHexFile.TabIndex = 4;
            this.btnReadHexFile.Text = "Read File";
            this.btnReadHexFile.UseVisualStyleBackColor = true;
            this.btnReadHexFile.Click += new System.EventHandler(this.btnReadHexFile_Click);
            // 
            // cmbChip
            // 
            this.cmbChip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbChip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChip.FormattingEnabled = true;
            this.cmbChip.Location = new System.Drawing.Point(181, 83);
            this.cmbChip.Name = "cmbChip";
            this.cmbChip.Size = new System.Drawing.Size(379, 28);
            this.cmbChip.TabIndex = 7;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.58125F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.788162F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.099689F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.09554F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.257529F));
            this.tableLayoutPanel4.Controls.Add(this.btnSend, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.txbSendTextBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnToggleStringHexSendText, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnClearSendBox, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 412);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(963, 46);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(769, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(149, 40);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txbSendTextBox
            // 
            this.txbSendTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSendTextBox.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSendTextBox.Location = new System.Drawing.Point(3, 3);
            this.txbSendTextBox.Multiline = true;
            this.txbSendTextBox.Name = "txbSendTextBox";
            this.txbSendTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbSendTextBox.Size = new System.Drawing.Size(607, 40);
            this.txbSendTextBox.TabIndex = 0;
            this.txbSendTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // btnToggleStringHexSendText
            // 
            this.btnToggleStringHexSendText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToggleStringHexSendText.Location = new System.Drawing.Point(616, 3);
            this.btnToggleStringHexSendText.Name = "btnToggleStringHexSendText";
            this.btnToggleStringHexSendText.Size = new System.Drawing.Size(69, 40);
            this.btnToggleStringHexSendText.TabIndex = 1;
            this.btnToggleStringHexSendText.Text = "String";
            this.btnToggleStringHexSendText.UseVisualStyleBackColor = true;
            this.btnToggleStringHexSendText.Click += new System.EventHandler(this.btnToggleStringHexSendText_Click);
            // 
            // btnClearSendBox
            // 
            this.btnClearSendBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearSendBox.Location = new System.Drawing.Point(691, 3);
            this.btnClearSendBox.Name = "btnClearSendBox";
            this.btnClearSendBox.Size = new System.Drawing.Size(72, 40);
            this.btnClearSendBox.TabIndex = 2;
            this.btnClearSendBox.Text = "Clear";
            this.btnClearSendBox.UseVisualStyleBackColor = true;
            this.btnClearSendBox.Click += new System.EventHandler(this.btnClearSendBox_Click);
            // 
            // rtbMainDisplay
            // 
            this.rtbMainDisplay.BackColor = System.Drawing.SystemColors.Desktop;
            this.rtbMainDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMainDisplay.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMainDisplay.ForeColor = System.Drawing.Color.Lime;
            this.rtbMainDisplay.Location = new System.Drawing.Point(3, 3);
            this.rtbMainDisplay.Name = "rtbMainDisplay";
            this.rtbMainDisplay.Size = new System.Drawing.Size(963, 403);
            this.rtbMainDisplay.TabIndex = 4;
            this.rtbMainDisplay.Text = "";
            // 
            // menuPanel
            // 
            this.menuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.menuPanel.AutoScroll = true;
            this.menuPanel.Controls.Add(this.tableLayoutPanel2);
            this.menuPanel.Location = new System.Drawing.Point(12, 49);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Padding = new System.Windows.Forms.Padding(20);
            this.menuPanel.Size = new System.Drawing.Size(200, 671);
            this.menuPanel.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnConnect, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblConnectionStatus, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txbSysMsg, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.btmClearMainDisplay, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.pbSysStatus, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.lblTSB, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnConnectToTSB, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 12;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.72043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.72043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.72043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.72043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.72043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.72043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.72043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.72043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.72043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.72043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.72043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.07527F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(160, 631);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 42);
            this.label12.TabIndex = 8;
            this.label12.Text = "Serial Port";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConnect
            // 
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnect.Location = new System.Drawing.Point(3, 87);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(154, 36);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.BackColor = System.Drawing.Color.Crimson;
            this.lblConnectionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.Location = new System.Drawing.Point(3, 42);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(154, 42);
            this.lblConnectionStatus.TabIndex = 3;
            this.lblConnectionStatus.Text = "Disconnected";
            this.lblConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbSysMsg
            // 
            this.txbSysMsg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txbSysMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbSysMsg.Location = new System.Drawing.Point(3, 465);
            this.txbSysMsg.Multiline = true;
            this.txbSysMsg.Name = "txbSysMsg";
            this.txbSysMsg.ReadOnly = true;
            this.txbSysMsg.Size = new System.Drawing.Size(154, 163);
            this.txbSysMsg.TabIndex = 5;
            // 
            // btmClearMainDisplay
            // 
            this.btmClearMainDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btmClearMainDisplay.Location = new System.Drawing.Point(3, 129);
            this.btmClearMainDisplay.Name = "btmClearMainDisplay";
            this.btmClearMainDisplay.Size = new System.Drawing.Size(154, 36);
            this.btmClearMainDisplay.TabIndex = 6;
            this.btmClearMainDisplay.Text = "Clear";
            this.btmClearMainDisplay.UseVisualStyleBackColor = true;
            this.btmClearMainDisplay.Click += new System.EventHandler(this.btmClearMainDisplay_Click);
            // 
            // pbSysStatus
            // 
            this.pbSysStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSysStatus.Location = new System.Drawing.Point(3, 423);
            this.pbSysStatus.Name = "pbSysStatus";
            this.pbSysStatus.Size = new System.Drawing.Size(154, 36);
            this.pbSysStatus.TabIndex = 11;
            // 
            // lblTSB
            // 
            this.lblTSB.AutoSize = true;
            this.lblTSB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTSB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTSB.Location = new System.Drawing.Point(3, 168);
            this.lblTSB.Name = "lblTSB";
            this.lblTSB.Size = new System.Drawing.Size(154, 42);
            this.lblTSB.TabIndex = 12;
            this.lblTSB.Text = "Tiny Safe Boot";
            this.lblTSB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConnectToTSB
            // 
            this.btnConnectToTSB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectToTSB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectToTSB.Location = new System.Drawing.Point(3, 213);
            this.btnConnectToTSB.Name = "btnConnectToTSB";
            this.btnConnectToTSB.Size = new System.Drawing.Size(154, 36);
            this.btnConnectToTSB.TabIndex = 13;
            this.btnConnectToTSB.Text = "Connect to TSB";
            this.btnConnectToTSB.UseVisualStyleBackColor = true;
            this.btnConnectToTSB.Click += new System.EventHandler(this.btnConnectToTSB_Click);
            // 
            // ofdHexFile
            // 
            this.ofdHexFile.FileName = "openFileDialog1";
            // 
            // MainDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 732);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.mnuMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainDisplay";
            this.Text = "Lumi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDisplay_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tbcBottomPane.ResumeLayout(false);
            this.tabPortSettings.ResumeLayout(false);
            this.tloPortSettings.ResumeLayout(false);
            this.tloPortSettings.PerformLayout();
            this.tabDataSettings.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabTSB.ResumeLayout(false);
            this.ltbTSB.ResumeLayout(false);
            this.ltbTSB.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialPortsToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox txbSendTextBox;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnToggleStringHexSendText;
        private System.Windows.Forms.Button btnClearSendBox;
        private System.Windows.Forms.TextBox txbSysMsg;
        private System.Windows.Forms.Button btmClearMainDisplay;
        private System.Windows.Forms.RichTextBox rtbMainDisplay;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar pbSysStatus;
        private System.Windows.Forms.TabControl tbcBottomPane;
        private System.Windows.Forms.TabPage tabPortSettings;
        private System.Windows.Forms.TableLayoutPanel tloPortSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPortNumberInPortSettingsTab;
        private System.Windows.Forms.ComboBox cmbBaudRatePortSettingsTab;
        private System.Windows.Forms.ComboBox cmbStopBitsPortSettingsTab;
        private System.Windows.Forms.ComboBox cmbParityPortSettingsTab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDataBitsPortSettingsTab;
        private System.Windows.Forms.ComboBox cmbHandshakingPortSettingsTab;
        private System.Windows.Forms.TabPage tabDataSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cmbCharsAfterTx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDataAs;
        private System.Windows.Forms.Label String;
        private System.Windows.Forms.ComboBox cmbCharAfterRx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabTSB;
        private System.Windows.Forms.OpenFileDialog ofdHexFile;
        private System.Windows.Forms.TableLayoutPanel ltbTSB;
        private System.Windows.Forms.Button btnWriteHexFile;
        private System.Windows.Forms.RichTextBox rtbHexFilePath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnReadHexFile;
        private System.Windows.Forms.ComboBox cmbChip;
        private System.Windows.Forms.Label lblTSB;
        private System.Windows.Forms.Button btnConnectToTSB;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    }


}

