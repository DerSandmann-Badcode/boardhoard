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
            this.label4 = new System.Windows.Forms.Label();
            this.openfolderBtm = new System.Windows.Forms.Button();
            this.removedeadBtn = new System.Windows.Forms.Button();
            this.selectallBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.deadclearChk = new System.Windows.Forms.CheckBox();
            this.defaultBtn = new System.Windows.Forms.Button();
            this.hashesChk = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.continuousChk = new System.Windows.Forms.CheckBox();
            this.deathalertChk = new System.Windows.Forms.CheckBox();
            this.separatefolderChk = new System.Windows.Forms.CheckBox();
            this.thumbnailChk = new System.Windows.Forms.CheckBox();
            this.htmlChk = new System.Windows.Forms.CheckBox();
            this.webmChk = new System.Windows.Forms.CheckBox();
            this.imagesChk = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.folderTxt = new System.Windows.Forms.TextBox();
            this.selectBtn = new System.Windows.Forms.Button();
            this.clipboardpasteBtn = new System.Windows.Forms.Button();
            this.addthreadBtn = new System.Windows.Forms.Button();
            this.threadTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statisticsBtn = new System.Windows.Forms.Button();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.boardDataGrid = new BoardHoard.BufferedDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(12, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(911, 2);
            this.label4.TabIndex = 32;
            this.label4.Text = "label4";
            // 
            // openfolderBtm
            // 
            this.openfolderBtm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.openfolderBtm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openfolderBtm.Location = new System.Drawing.Point(12, 212);
            this.openfolderBtm.Name = "openfolderBtm";
            this.openfolderBtm.Size = new System.Drawing.Size(100, 25);
            this.openfolderBtm.TabIndex = 33;
            this.openfolderBtm.Text = "Open Folder";
            this.openfolderBtm.UseVisualStyleBackColor = true;
            this.openfolderBtm.Click += new System.EventHandler(this.openfolderBtm_Click);
            // 
            // removedeadBtn
            // 
            this.removedeadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removedeadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removedeadBtn.Location = new System.Drawing.Point(722, 212);
            this.removedeadBtn.Name = "removedeadBtn";
            this.removedeadBtn.Size = new System.Drawing.Size(201, 25);
            this.removedeadBtn.TabIndex = 34;
            this.removedeadBtn.Text = "Remove Dead && Completed";
            this.removedeadBtn.UseVisualStyleBackColor = true;
            this.removedeadBtn.Click += new System.EventHandler(this.removedeadBtn_Click);
            // 
            // selectallBtn
            // 
            this.selectallBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectallBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectallBtn.Location = new System.Drawing.Point(597, 212);
            this.selectallBtn.Name = "selectallBtn";
            this.selectallBtn.Size = new System.Drawing.Size(119, 25);
            this.selectallBtn.TabIndex = 37;
            this.selectallBtn.Text = "Select all";
            this.selectallBtn.UseVisualStyleBackColor = true;
            this.selectallBtn.Click += new System.EventHandler(this.selectallBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.deadclearChk);
            this.panel1.Controls.Add(this.defaultBtn);
            this.panel1.Controls.Add(this.hashesChk);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.continuousChk);
            this.panel1.Controls.Add(this.deathalertChk);
            this.panel1.Controls.Add(this.separatefolderChk);
            this.panel1.Controls.Add(this.thumbnailChk);
            this.panel1.Controls.Add(this.htmlChk);
            this.panel1.Controls.Add(this.webmChk);
            this.panel1.Controls.Add(this.imagesChk);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 225);
            this.panel1.TabIndex = 38;
            // 
            // deadclearChk
            // 
            this.deadclearChk.AutoSize = true;
            this.deadclearChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deadclearChk.Location = new System.Drawing.Point(15, 102);
            this.deadclearChk.Name = "deadclearChk";
            this.deadclearChk.Size = new System.Drawing.Size(219, 17);
            this.deadclearChk.TabIndex = 59;
            this.deadclearChk.Text = "Clear out dead thread entries immediately";
            this.deadclearChk.UseVisualStyleBackColor = true;
            // 
            // defaultBtn
            // 
            this.defaultBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultBtn.Location = new System.Drawing.Point(755, 194);
            this.defaultBtn.Name = "defaultBtn";
            this.defaultBtn.Size = new System.Drawing.Size(148, 23);
            this.defaultBtn.TabIndex = 58;
            this.defaultBtn.Text = "Set as Default";
            this.defaultBtn.UseVisualStyleBackColor = true;
            // 
            // hashesChk
            // 
            this.hashesChk.AutoSize = true;
            this.hashesChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hashesChk.Location = new System.Drawing.Point(15, 194);
            this.hashesChk.Name = "hashesChk";
            this.hashesChk.Size = new System.Drawing.Size(123, 17);
            this.hashesChk.TabIndex = 57;
            this.hashesChk.Text = "Verify Image Hashes";
            this.hashesChk.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "30 Seconds",
            "1 Minute",
            "2 Minutes",
            "5 Minutes",
            "1 Hour"});
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(168, 169);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 21);
            this.comboBox1.TabIndex = 56;
            this.comboBox1.Text = "1 Minute";
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
            // continuousChk
            // 
            this.continuousChk.AutoSize = true;
            this.continuousChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continuousChk.Location = new System.Drawing.Point(15, 148);
            this.continuousChk.Name = "continuousChk";
            this.continuousChk.Size = new System.Drawing.Size(127, 17);
            this.continuousChk.TabIndex = 54;
            this.continuousChk.Text = "Continuous Checking";
            this.continuousChk.UseVisualStyleBackColor = true;
            // 
            // deathalertChk
            // 
            this.deathalertChk.AutoSize = true;
            this.deathalertChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deathalertChk.Location = new System.Drawing.Point(15, 125);
            this.deathalertChk.Name = "deathalertChk";
            this.deathalertChk.Size = new System.Drawing.Size(125, 17);
            this.deathalertChk.TabIndex = 53;
            this.deathalertChk.Text = "Alert on thread death";
            this.deathalertChk.UseVisualStyleBackColor = true;
            // 
            // separatefolderChk
            // 
            this.separatefolderChk.AutoSize = true;
            this.separatefolderChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.separatefolderChk.Location = new System.Drawing.Point(36, 79);
            this.separatefolderChk.Name = "separatefolderChk";
            this.separatefolderChk.Size = new System.Drawing.Size(303, 17);
            this.separatefolderChk.TabIndex = 50;
            this.separatefolderChk.Text = "Place .GIFs and .WebMs in /Site/Board/Thread/Animated";
            this.separatefolderChk.UseVisualStyleBackColor = true;
            // 
            // thumbnailChk
            // 
            this.thumbnailChk.AutoSize = true;
            this.thumbnailChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thumbnailChk.Location = new System.Drawing.Point(256, 56);
            this.thumbnailChk.Name = "thumbnailChk";
            this.thumbnailChk.Size = new System.Drawing.Size(80, 17);
            this.thumbnailChk.TabIndex = 49;
            this.thumbnailChk.Text = "Thumbnails";
            this.thumbnailChk.UseVisualStyleBackColor = true;
            // 
            // htmlChk
            // 
            this.htmlChk.AutoSize = true;
            this.htmlChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.htmlChk.Location = new System.Drawing.Point(232, 33);
            this.htmlChk.Name = "htmlChk";
            this.htmlChk.Size = new System.Drawing.Size(93, 17);
            this.htmlChk.TabIndex = 48;
            this.htmlChk.Text = "Thread HTML";
            this.htmlChk.UseVisualStyleBackColor = true;
            // 
            // webmChk
            // 
            this.webmChk.AutoSize = true;
            this.webmChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webmChk.Location = new System.Drawing.Point(15, 56);
            this.webmChk.Name = "webmChk";
            this.webmChk.Size = new System.Drawing.Size(93, 17);
            this.webmChk.TabIndex = 38;
            this.webmChk.Text = "WebM Videos";
            this.webmChk.UseVisualStyleBackColor = true;
            // 
            // imagesChk
            // 
            this.imagesChk.AutoSize = true;
            this.imagesChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imagesChk.Location = new System.Drawing.Point(15, 33);
            this.imagesChk.Name = "imagesChk";
            this.imagesChk.Size = new System.Drawing.Size(60, 17);
            this.imagesChk.TabIndex = 37;
            this.imagesChk.Text = "Images";
            this.imagesChk.UseVisualStyleBackColor = true;
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
            this.label5.Location = new System.Drawing.Point(9, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Download Folder:";
            // 
            // folderTxt
            // 
            this.folderTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderTxt.Location = new System.Drawing.Point(110, 253);
            this.folderTxt.Name = "folderTxt";
            this.folderTxt.Size = new System.Drawing.Size(777, 20);
            this.folderTxt.TabIndex = 40;
            // 
            // selectBtn
            // 
            this.selectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectBtn.Location = new System.Drawing.Point(893, 251);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(30, 23);
            this.selectBtn.TabIndex = 41;
            this.selectBtn.Text = "...";
            this.selectBtn.UseVisualStyleBackColor = true;
            // 
            // clipboardpasteBtn
            // 
            this.clipboardpasteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clipboardpasteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clipboardpasteBtn.Location = new System.Drawing.Point(767, 542);
            this.clipboardpasteBtn.Name = "clipboardpasteBtn";
            this.clipboardpasteBtn.Size = new System.Drawing.Size(156, 23);
            this.clipboardpasteBtn.TabIndex = 42;
            this.clipboardpasteBtn.Text = "Paste from Clipboard";
            this.clipboardpasteBtn.UseVisualStyleBackColor = true;
            // 
            // addthreadBtn
            // 
            this.addthreadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addthreadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addthreadBtn.Location = new System.Drawing.Point(767, 513);
            this.addthreadBtn.Name = "addthreadBtn";
            this.addthreadBtn.Size = new System.Drawing.Size(156, 23);
            this.addthreadBtn.TabIndex = 43;
            this.addthreadBtn.Text = "Submit";
            this.addthreadBtn.UseVisualStyleBackColor = true;
            this.addthreadBtn.Click += new System.EventHandler(this.addthreadBtn_Click);
            // 
            // threadTxt
            // 
            this.threadTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.threadTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threadTxt.Location = new System.Drawing.Point(110, 514);
            this.threadTxt.Name = "threadTxt";
            this.threadTxt.Size = new System.Drawing.Size(651, 20);
            this.threadTxt.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 516);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Add thread:";
            // 
            // statisticsBtn
            // 
            this.statisticsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statisticsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsBtn.Location = new System.Drawing.Point(12, 542);
            this.statisticsBtn.Name = "statisticsBtn";
            this.statisticsBtn.Size = new System.Drawing.Size(103, 23);
            this.statisticsBtn.TabIndex = 46;
            this.statisticsBtn.Text = "Statistics";
            this.statisticsBtn.UseVisualStyleBackColor = true;
            // 
            // aboutBtn
            // 
            this.aboutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.aboutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutBtn.Location = new System.Drawing.Point(121, 542);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(79, 23);
            this.aboutBtn.TabIndex = 47;
            this.aboutBtn.Text = "About";
            this.aboutBtn.UseVisualStyleBackColor = true;
            // 
            // boardDataGrid
            // 
            this.boardDataGrid.AllowUserToAddRows = false;
            this.boardDataGrid.AllowUserToDeleteRows = false;
            this.boardDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boardDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.boardDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.boardDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.boardDataGrid.Location = new System.Drawing.Point(12, 12);
            this.boardDataGrid.Name = "boardDataGrid";
            this.boardDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.boardDataGrid.Size = new System.Drawing.Size(911, 194);
            this.boardDataGrid.TabIndex = 48;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Subject";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Site";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Board";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Thread";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Img: Count";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Img: Downloaded";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Status";
            this.Column8.Name = "Column8";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 572);
            this.Controls.Add(this.boardDataGrid);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.statisticsBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.threadTxt);
            this.Controls.Add(this.addthreadBtn);
            this.Controls.Add(this.clipboardpasteBtn);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.folderTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.selectallBtn);
            this.Controls.Add(this.removedeadBtn);
            this.Controls.Add(this.openfolderBtm);
            this.Controls.Add(this.label4);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(16, 461);
            this.Name = "MainForm";
            this.Text = "BoardHoard v0.0.1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button openfolderBtm;
        private System.Windows.Forms.Button removedeadBtn;
        private System.Windows.Forms.Button selectallBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox hashesChk;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox continuousChk;
        private System.Windows.Forms.CheckBox deathalertChk;
        private System.Windows.Forms.CheckBox separatefolderChk;
        private System.Windows.Forms.CheckBox thumbnailChk;
        private System.Windows.Forms.CheckBox htmlChk;
        private System.Windows.Forms.CheckBox webmChk;
        private System.Windows.Forms.CheckBox imagesChk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox folderTxt;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button clipboardpasteBtn;
        private System.Windows.Forms.Button addthreadBtn;
        private System.Windows.Forms.TextBox threadTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button statisticsBtn;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Button defaultBtn;
        private System.Windows.Forms.CheckBox deadclearChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        public BufferedDataGridView boardDataGrid;




    }
}

