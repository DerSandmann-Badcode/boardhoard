namespace BoardHoard
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnClearInactive = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkClearDead = new System.Windows.Forms.CheckBox();
            this.chkVerifyHashes = new System.Windows.Forms.CheckBox();
            this.cmbThreadRefresh = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkConstantCheck = new System.Windows.Forms.CheckBox();
            this.chkDeathAlert = new System.Windows.Forms.CheckBox();
            this.chkSeperateFolder = new System.Windows.Forms.CheckBox();
            this.chkThumbnails = new System.Windows.Forms.CheckBox();
            this.chkHTML = new System.Windows.Forms.CheckBox();
            this.chkWebm = new System.Windows.Forms.CheckBox();
            this.chkImages = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtThread = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.ContextBoardDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextOpenbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextCheckbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextStopbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextStartbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.contextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextClearbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextClearDeletebtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextSelectWaitbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.Context30Secbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.Context1Minbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Context1Hourbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.Context12Hrs = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.chkInstantSubmit = new System.Windows.Forms.CheckBox();
            this.dgvBoards = new BoardHoard.BufferedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.ContextBoardDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoards)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(12, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(936, 2);
            this.label4.TabIndex = 32;
            this.label4.Text = "label4";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFolder.Location = new System.Drawing.Point(12, 216);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(100, 25);
            this.btnOpenFolder.TabIndex = 33;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.openfolderBtm_Click);
            // 
            // btnClearInactive
            // 
            this.btnClearInactive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearInactive.Location = new System.Drawing.Point(806, 216);
            this.btnClearInactive.Name = "btnClearInactive";
            this.btnClearInactive.Size = new System.Drawing.Size(142, 25);
            this.btnClearInactive.TabIndex = 34;
            this.btnClearInactive.Text = "Clear Inactive Entries";
            this.btnClearInactive.UseVisualStyleBackColor = true;
            this.btnClearInactive.Click += new System.EventHandler(this.removedeadBtn_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(681, 216);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(119, 25);
            this.btnSelectAll.TabIndex = 37;
            this.btnSelectAll.Text = "Select all";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.selectallBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.chkClearDead);
            this.panel1.Controls.Add(this.chkVerifyHashes);
            this.panel1.Controls.Add(this.cmbThreadRefresh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkConstantCheck);
            this.panel1.Controls.Add(this.chkDeathAlert);
            this.panel1.Controls.Add(this.chkSeperateFolder);
            this.panel1.Controls.Add(this.chkThumbnails);
            this.panel1.Controls.Add(this.chkHTML);
            this.panel1.Controls.Add(this.chkWebm);
            this.panel1.Controls.Add(this.chkImages);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 285);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 225);
            this.panel1.TabIndex = 38;
            // 
            // chkClearDead
            // 
            this.chkClearDead.AutoSize = true;
            this.chkClearDead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClearDead.Location = new System.Drawing.Point(15, 102);
            this.chkClearDead.Name = "chkClearDead";
            this.chkClearDead.Size = new System.Drawing.Size(219, 17);
            this.chkClearDead.TabIndex = 59;
            this.chkClearDead.Text = "Clear out dead thread entries immediately";
            this.chkClearDead.UseVisualStyleBackColor = true;
            this.chkClearDead.CheckedChanged += new System.EventHandler(this.deadclearChk_CheckedChanged);
            // 
            // chkVerifyHashes
            // 
            this.chkVerifyHashes.AutoSize = true;
            this.chkVerifyHashes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVerifyHashes.Location = new System.Drawing.Point(15, 194);
            this.chkVerifyHashes.Name = "chkVerifyHashes";
            this.chkVerifyHashes.Size = new System.Drawing.Size(123, 17);
            this.chkVerifyHashes.TabIndex = 57;
            this.chkVerifyHashes.Text = "Verify Image Hashes";
            this.chkVerifyHashes.UseVisualStyleBackColor = true;
            this.chkVerifyHashes.CheckedChanged += new System.EventHandler(this.hashesChk_CheckedChanged);
            // 
            // cmbThreadRefresh
            // 
            this.cmbThreadRefresh.AutoCompleteCustomSource.AddRange(new string[] {
            "30 Seconds",
            "1 Minute",
            "2 Minutes",
            "5 Minutes",
            "1 Hour"});
            this.cmbThreadRefresh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThreadRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThreadRefresh.FormattingEnabled = true;
            this.cmbThreadRefresh.Items.AddRange(new object[] {
            "30 Seconds",
            "1 Minute",
            "2 Minutes",
            "5 Minutes",
            "15 Minutes",
            "30 Minutes",
            "1 Hour",
            "12 Hours",
            "Daily"});
            this.cmbThreadRefresh.Location = new System.Drawing.Point(168, 169);
            this.cmbThreadRefresh.Name = "cmbThreadRefresh";
            this.cmbThreadRefresh.Size = new System.Drawing.Size(132, 21);
            this.cmbThreadRefresh.TabIndex = 56;
            this.cmbThreadRefresh.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Check threads every: ";
            // 
            // chkConstantCheck
            // 
            this.chkConstantCheck.AutoSize = true;
            this.chkConstantCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConstantCheck.Location = new System.Drawing.Point(15, 148);
            this.chkConstantCheck.Name = "chkConstantCheck";
            this.chkConstantCheck.Size = new System.Drawing.Size(127, 17);
            this.chkConstantCheck.TabIndex = 54;
            this.chkConstantCheck.Text = "Continuous Checking";
            this.chkConstantCheck.UseVisualStyleBackColor = true;
            this.chkConstantCheck.CheckedChanged += new System.EventHandler(this.continuousChk_CheckedChanged);
            // 
            // chkDeathAlert
            // 
            this.chkDeathAlert.AutoSize = true;
            this.chkDeathAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeathAlert.Location = new System.Drawing.Point(15, 125);
            this.chkDeathAlert.Name = "chkDeathAlert";
            this.chkDeathAlert.Size = new System.Drawing.Size(125, 17);
            this.chkDeathAlert.TabIndex = 53;
            this.chkDeathAlert.Text = "Alert on thread death";
            this.chkDeathAlert.UseVisualStyleBackColor = true;
            this.chkDeathAlert.CheckedChanged += new System.EventHandler(this.deathalertChk_CheckedChanged);
            // 
            // chkSeperateFolder
            // 
            this.chkSeperateFolder.AutoSize = true;
            this.chkSeperateFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSeperateFolder.Location = new System.Drawing.Point(36, 79);
            this.chkSeperateFolder.Name = "chkSeperateFolder";
            this.chkSeperateFolder.Size = new System.Drawing.Size(332, 17);
            this.chkSeperateFolder.TabIndex = 50;
            this.chkSeperateFolder.Text = "Place GIFs, WebMs and SWFs in /Site/Board/Thread/Animated";
            this.chkSeperateFolder.UseVisualStyleBackColor = true;
            this.chkSeperateFolder.CheckedChanged += new System.EventHandler(this.separatefolderChk_CheckedChanged);
            // 
            // chkThumbnails
            // 
            this.chkThumbnails.AutoSize = true;
            this.chkThumbnails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkThumbnails.Location = new System.Drawing.Point(256, 56);
            this.chkThumbnails.Name = "chkThumbnails";
            this.chkThumbnails.Size = new System.Drawing.Size(80, 17);
            this.chkThumbnails.TabIndex = 49;
            this.chkThumbnails.Text = "Thumbnails";
            this.chkThumbnails.UseVisualStyleBackColor = true;
            this.chkThumbnails.CheckedChanged += new System.EventHandler(this.thumbnailChk_CheckedChanged);
            // 
            // chkHTML
            // 
            this.chkHTML.AutoSize = true;
            this.chkHTML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHTML.Location = new System.Drawing.Point(232, 33);
            this.chkHTML.Name = "chkHTML";
            this.chkHTML.Size = new System.Drawing.Size(93, 17);
            this.chkHTML.TabIndex = 48;
            this.chkHTML.Text = "Thread HTML";
            this.chkHTML.UseVisualStyleBackColor = true;
            this.chkHTML.CheckedChanged += new System.EventHandler(this.htmlChk_CheckedChanged);
            // 
            // chkWebm
            // 
            this.chkWebm.AutoSize = true;
            this.chkWebm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWebm.Location = new System.Drawing.Point(15, 56);
            this.chkWebm.Name = "chkWebm";
            this.chkWebm.Size = new System.Drawing.Size(123, 17);
            this.chkWebm.TabIndex = 38;
            this.chkWebm.Text = "WebM Videos\\Flash";
            this.chkWebm.UseVisualStyleBackColor = true;
            this.chkWebm.CheckedChanged += new System.EventHandler(this.webmChk_CheckedChanged);
            // 
            // chkImages
            // 
            this.chkImages.AutoSize = true;
            this.chkImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImages.Location = new System.Drawing.Point(15, 33);
            this.chkImages.Name = "chkImages";
            this.chkImages.Size = new System.Drawing.Size(60, 17);
            this.chkImages.TabIndex = 37;
            this.chkImages.Text = "Images";
            this.chkImages.UseVisualStyleBackColor = true;
            this.chkImages.CheckedChanged += new System.EventHandler(this.imagesChk_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Download options (Will be applied to all new threads)";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Download Folder:";
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolderPath.Location = new System.Drawing.Point(121, 257);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.ReadOnly = true;
            this.txtFolderPath.Size = new System.Drawing.Size(791, 20);
            this.txtFolderPath.TabIndex = 40;
            this.txtFolderPath.TextChanged += new System.EventHandler(this.folderTxt_TextChanged);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFolder.Location = new System.Drawing.Point(918, 255);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(30, 23);
            this.btnSelectFolder.TabIndex = 41;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaste.Location = new System.Drawing.Point(792, 546);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(156, 23);
            this.btnPaste.TabIndex = 42;
            this.btnPaste.Text = "Clipboard (CTRL + V)";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.clipboardpasteBtn_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(792, 517);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(156, 23);
            this.btnSubmit.TabIndex = 43;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.addthreadBtn_Click);
            // 
            // txtThread
            // 
            this.txtThread.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThread.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThread.Location = new System.Drawing.Point(121, 518);
            this.txtThread.Name = "txtThread";
            this.txtThread.Size = new System.Drawing.Size(665, 20);
            this.txtThread.TabIndex = 44;
            this.txtThread.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtThread_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 521);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Add thread:";
            // 
            // btnStatistics
            // 
            this.btnStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.Location = new System.Drawing.Point(12, 546);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(103, 23);
            this.btnStatistics.TabIndex = 46;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.statisticsBtn_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.Location = new System.Drawing.Point(121, 546);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(79, 23);
            this.btnAbout.TabIndex = 47;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // ContextBoardDataGrid
            // 
            this.ContextBoardDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextOpenbtn,
            this.toolStripSeparator1,
            this.ContextCheckbtn,
            this.ContextStopbtn,
            this.ContextStartbtn,
            this.contextCopy,
            this.toolStripSeparator2,
            this.ContextClearbtn,
            this.ContextClearDeletebtn,
            this.toolStripSeparator3,
            this.ContextSelectWaitbtn});
            this.ContextBoardDataGrid.Name = "ContextBoardDataGrid";
            this.ContextBoardDataGrid.Size = new System.Drawing.Size(192, 198);
            // 
            // ContextOpenbtn
            // 
            this.ContextOpenbtn.Name = "ContextOpenbtn";
            this.ContextOpenbtn.Size = new System.Drawing.Size(191, 22);
            this.ContextOpenbtn.Text = "Open Folder";
            this.ContextOpenbtn.Click += new System.EventHandler(this.ContextOpenbtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // ContextCheckbtn
            // 
            this.ContextCheckbtn.Name = "ContextCheckbtn";
            this.ContextCheckbtn.Size = new System.Drawing.Size(191, 22);
            this.ContextCheckbtn.Text = "Check Now";
            this.ContextCheckbtn.Click += new System.EventHandler(this.ContextCheckbtn_Click);
            // 
            // ContextStopbtn
            // 
            this.ContextStopbtn.Name = "ContextStopbtn";
            this.ContextStopbtn.Size = new System.Drawing.Size(191, 22);
            this.ContextStopbtn.Text = "Stop Watching";
            this.ContextStopbtn.Click += new System.EventHandler(this.ContextStopbtn_Click);
            // 
            // ContextStartbtn
            // 
            this.ContextStartbtn.Name = "ContextStartbtn";
            this.ContextStartbtn.Size = new System.Drawing.Size(191, 22);
            this.ContextStartbtn.Text = "Start Watching";
            this.ContextStartbtn.Click += new System.EventHandler(this.ContextStartbtn_Click);
            // 
            // contextCopy
            // 
            this.contextCopy.Name = "contextCopy";
            this.contextCopy.Size = new System.Drawing.Size(191, 22);
            this.contextCopy.Text = "Copy thread URL";
            this.contextCopy.Click += new System.EventHandler(this.contextCopy_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // ContextClearbtn
            // 
            this.ContextClearbtn.Name = "ContextClearbtn";
            this.ContextClearbtn.Size = new System.Drawing.Size(191, 22);
            this.ContextClearbtn.Text = "Clear Entry";
            this.ContextClearbtn.Click += new System.EventHandler(this.ContextClearbtn_Click);
            // 
            // ContextClearDeletebtn
            // 
            this.ContextClearDeletebtn.Name = "ContextClearDeletebtn";
            this.ContextClearDeletebtn.Size = new System.Drawing.Size(191, 22);
            this.ContextClearDeletebtn.Text = "Clear && Delete Folder";
            this.ContextClearDeletebtn.Click += new System.EventHandler(this.ContextClearDeletebtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // ContextSelectWaitbtn
            // 
            this.ContextSelectWaitbtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Context30Secbtn,
            this.Context1Minbtn,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.Context1Hourbtn,
            this.Context12Hrs,
            this.ContextDaily});
            this.ContextSelectWaitbtn.Name = "ContextSelectWaitbtn";
            this.ContextSelectWaitbtn.Size = new System.Drawing.Size(191, 22);
            this.ContextSelectWaitbtn.Text = "Select Waiting Interval";
            // 
            // Context30Secbtn
            // 
            this.Context30Secbtn.Name = "Context30Secbtn";
            this.Context30Secbtn.Size = new System.Drawing.Size(133, 22);
            this.Context30Secbtn.Text = "30 Seconds";
            this.Context30Secbtn.Click += new System.EventHandler(this.Context30Secbtn_Click);
            // 
            // Context1Minbtn
            // 
            this.Context1Minbtn.Name = "Context1Minbtn";
            this.Context1Minbtn.Size = new System.Drawing.Size(133, 22);
            this.Context1Minbtn.Text = "1 Minute";
            this.Context1Minbtn.Click += new System.EventHandler(this.Context1Minbtn_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem1.Text = "2 Minutes";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem2.Text = "5 Minutes";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem3.Text = "30 Minutes";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // Context1Hourbtn
            // 
            this.Context1Hourbtn.Name = "Context1Hourbtn";
            this.Context1Hourbtn.Size = new System.Drawing.Size(133, 22);
            this.Context1Hourbtn.Text = "1 Hour";
            this.Context1Hourbtn.Click += new System.EventHandler(this.Context1Hourbtn_Click);
            // 
            // Context12Hrs
            // 
            this.Context12Hrs.Name = "Context12Hrs";
            this.Context12Hrs.Size = new System.Drawing.Size(133, 22);
            this.Context12Hrs.Text = "12 Hours";
            this.Context12Hrs.Click += new System.EventHandler(this.Context12Hrs_Click);
            // 
            // ContextDaily
            // 
            this.ContextDaily.Name = "ContextDaily";
            this.ContextDaily.Size = new System.Drawing.Size(133, 22);
            this.ContextDaily.Text = "Daily";
            this.ContextDaily.Click += new System.EventHandler(this.ContextDaily_Click);
            // 
            // chkInstantSubmit
            // 
            this.chkInstantSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInstantSubmit.AutoSize = true;
            this.chkInstantSubmit.Location = new System.Drawing.Point(638, 550);
            this.chkInstantSubmit.Name = "chkInstantSubmit";
            this.chkInstantSubmit.Size = new System.Drawing.Size(138, 17);
            this.chkInstantSubmit.TabIndex = 49;
            this.chkInstantSubmit.Text = "Instant Submit on Paste";
            this.chkInstantSubmit.UseVisualStyleBackColor = true;
            this.chkInstantSubmit.CheckedChanged += new System.EventHandler(this.chkInstantSubmit_CheckedChanged);
            // 
            // dgvBoards
            // 
            this.dgvBoards.AllowUserToAddRows = false;
            this.dgvBoards.AllowUserToDeleteRows = false;
            this.dgvBoards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBoards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBoards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column2,
            this.Column7,
            this.Column8,
            this.Column6});
            this.dgvBoards.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBoards.Location = new System.Drawing.Point(12, 12);
            this.dgvBoards.Name = "dgvBoards";
            this.dgvBoards.ReadOnly = true;
            this.dgvBoards.RowHeadersWidth = 20;
            this.dgvBoards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBoards.Size = new System.Drawing.Size(936, 198);
            this.dgvBoards.TabIndex = 48;
            this.dgvBoards.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBoards_CellMouseDoubleClick);
            this.dgvBoards.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.boardDataGrid_CellMouseDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Index";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Date added";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Site";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Board";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Subject";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Files Downloaded";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Status";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Next DL in";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 576);
            this.Controls.Add(this.chkInstantSubmit);
            this.Controls.Add(this.dgvBoards);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtThread);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClearInactive);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.label4);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(16, 461);
            this.Name = "MainForm";
            this.Text = "BoardHoard";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ContextBoardDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnClearInactive;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkVerifyHashes;
        private System.Windows.Forms.ComboBox cmbThreadRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkConstantCheck;
        private System.Windows.Forms.CheckBox chkDeathAlert;
        private System.Windows.Forms.CheckBox chkSeperateFolder;
        private System.Windows.Forms.CheckBox chkThumbnails;
        private System.Windows.Forms.CheckBox chkHTML;
        private System.Windows.Forms.CheckBox chkWebm;
        private System.Windows.Forms.CheckBox chkImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtThread;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.CheckBox chkClearDead;
        public BufferedDataGridView dgvBoards;
        private System.Windows.Forms.ContextMenuStrip ContextBoardDataGrid;
        private System.Windows.Forms.ToolStripMenuItem ContextCheckbtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ContextOpenbtn;
        private System.Windows.Forms.ToolStripMenuItem ContextStopbtn;
        private System.Windows.Forms.ToolStripMenuItem ContextStartbtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ContextClearbtn;
        private System.Windows.Forms.ToolStripMenuItem ContextClearDeletebtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextSelectWaitbtn;
        private System.Windows.Forms.ToolStripMenuItem Context30Secbtn;
        private System.Windows.Forms.ToolStripMenuItem Context1Minbtn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem Context1Hourbtn;
        private System.Windows.Forms.ToolStripMenuItem Context12Hrs;
        private System.Windows.Forms.ToolStripMenuItem ContextDaily;
        private System.Windows.Forms.CheckBox chkInstantSubmit;
        private System.Windows.Forms.ToolStripMenuItem contextCopy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;




    }
}

