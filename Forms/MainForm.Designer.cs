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
            this.removeDeadAndCompletedButton = new System.Windows.Forms.Button();
            this.stopAndRemoveSelectedButton = new System.Windows.Forms.Button();
            this.stopSelectedButton = new System.Windows.Forms.Button();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.openFolderButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.applyToAllButton = new System.Windows.Forms.Button();
            this.applyToSelectedButton = new System.Windows.Forms.Button();
            this.verifyImageHashesCheckBox = new System.Windows.Forms.CheckBox();
            this.checkIntervalCheckBox = new System.Windows.Forms.CheckBox();
            this.checkIntervalComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.downloadVideosCheckBox = new System.Windows.Forms.CheckBox();
            this.downloadImagesCheckBox = new System.Windows.Forms.CheckBox();
            this.downloadThreadPageCheckBox = new System.Windows.Forms.CheckBox();
            this.downloadThumbnailsCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.threadUrlTextBox = new System.Windows.Forms.TextBox();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.pasteFromClipboardButton = new System.Windows.Forms.Button();
            this.addThreadButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Site = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Board = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Thread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ImgTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ImgDownloaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // removeDeadAndCompletedButton
            // 
            this.removeDeadAndCompletedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeDeadAndCompletedButton.Location = new System.Drawing.Point(755, 9);
            this.removeDeadAndCompletedButton.Margin = new System.Windows.Forms.Padding(3, 9, 9, 9);
            this.removeDeadAndCompletedButton.Name = "removeDeadAndCompletedButton";
            this.removeDeadAndCompletedButton.Size = new System.Drawing.Size(157, 23);
            this.removeDeadAndCompletedButton.TabIndex = 6;
            this.removeDeadAndCompletedButton.Text = "Remove Dead && Completed";
            this.removeDeadAndCompletedButton.UseVisualStyleBackColor = true;
            // 
            // stopAndRemoveSelectedButton
            // 
            this.stopAndRemoveSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopAndRemoveSelectedButton.Location = new System.Drawing.Point(608, 9);
            this.stopAndRemoveSelectedButton.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.stopAndRemoveSelectedButton.Name = "stopAndRemoveSelectedButton";
            this.stopAndRemoveSelectedButton.Size = new System.Drawing.Size(141, 23);
            this.stopAndRemoveSelectedButton.TabIndex = 5;
            this.stopAndRemoveSelectedButton.Text = "Stop && Remove Selected";
            this.stopAndRemoveSelectedButton.UseVisualStyleBackColor = true;
            // 
            // stopSelectedButton
            // 
            this.stopSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopSelectedButton.Location = new System.Drawing.Point(510, 9);
            this.stopSelectedButton.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.stopSelectedButton.Name = "stopSelectedButton";
            this.stopSelectedButton.Size = new System.Drawing.Size(92, 23);
            this.stopSelectedButton.TabIndex = 4;
            this.stopSelectedButton.Text = "Stop Selected";
            this.stopSelectedButton.UseVisualStyleBackColor = true;
            // 
            // selectAllButton
            // 
            this.selectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllButton.Location = new System.Drawing.Point(414, 9);
            this.selectAllButton.Margin = new System.Windows.Forms.Padding(3, 9, 18, 9);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(75, 23);
            this.selectAllButton.TabIndex = 3;
            this.selectAllButton.Text = "Select All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // openFolderButton
            // 
            this.openFolderButton.Location = new System.Drawing.Point(9, 9);
            this.openFolderButton.Margin = new System.Windows.Forms.Padding(9);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(96, 23);
            this.openFolderButton.TabIndex = 2;
            this.openFolderButton.Text = "Open Folder...";
            this.openFolderButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.applyToAllButton);
            this.panel2.Controls.Add(this.applyToSelectedButton);
            this.panel2.Controls.Add(this.verifyImageHashesCheckBox);
            this.panel2.Controls.Add(this.checkIntervalCheckBox);
            this.panel2.Controls.Add(this.checkIntervalComboBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.downloadVideosCheckBox);
            this.panel2.Controls.Add(this.downloadImagesCheckBox);
            this.panel2.Controls.Add(this.downloadThreadPageCheckBox);
            this.panel2.Controls.Add(this.downloadThumbnailsCheckBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 247);
            this.panel2.MinimumSize = new System.Drawing.Size(2, 200);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(929, 208);
            this.panel2.TabIndex = 3;
            // 
            // applyToAllButton
            // 
            this.applyToAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyToAllButton.Location = new System.Drawing.Point(843, 174);
            this.applyToAllButton.Margin = new System.Windows.Forms.Padding(9);
            this.applyToAllButton.Name = "applyToAllButton";
            this.applyToAllButton.Size = new System.Drawing.Size(75, 23);
            this.applyToAllButton.TabIndex = 11;
            this.applyToAllButton.Text = "Apply to All";
            this.applyToAllButton.UseVisualStyleBackColor = true;
            // 
            // applyToSelectedButton
            // 
            this.applyToSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyToSelectedButton.Location = new System.Drawing.Point(723, 174);
            this.applyToSelectedButton.Margin = new System.Windows.Forms.Padding(9);
            this.applyToSelectedButton.Name = "applyToSelectedButton";
            this.applyToSelectedButton.Size = new System.Drawing.Size(108, 23);
            this.applyToSelectedButton.TabIndex = 10;
            this.applyToSelectedButton.Text = "Apply to Selected";
            this.applyToSelectedButton.UseVisualStyleBackColor = true;
            // 
            // verifyImageHashesCheckBox
            // 
            this.verifyImageHashesCheckBox.AutoSize = true;
            this.verifyImageHashesCheckBox.Location = new System.Drawing.Point(12, 169);
            this.verifyImageHashesCheckBox.Name = "verifyImageHashesCheckBox";
            this.verifyImageHashesCheckBox.Size = new System.Drawing.Size(162, 17);
            this.verifyImageHashesCheckBox.TabIndex = 8;
            this.verifyImageHashesCheckBox.Text = "Verify Image Hashes (4chan)";
            this.verifyImageHashesCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkIntervalCheckBox
            // 
            this.checkIntervalCheckBox.AutoSize = true;
            this.checkIntervalCheckBox.Location = new System.Drawing.Point(12, 136);
            this.checkIntervalCheckBox.Name = "checkIntervalCheckBox";
            this.checkIntervalCheckBox.Size = new System.Drawing.Size(127, 17);
            this.checkIntervalCheckBox.TabIndex = 7;
            this.checkIntervalCheckBox.Text = "Check threads every:";
            this.checkIntervalCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkIntervalComboBox
            // 
            this.checkIntervalComboBox.FormattingEnabled = true;
            this.checkIntervalComboBox.Items.AddRange(new object[] {
            "30s",
            "1min",
            "2min",
            "5min",
            "10min",
            "15min",
            "30min",
            "1h"});
            this.checkIntervalComboBox.Location = new System.Drawing.Point(146, 134);
            this.checkIntervalComboBox.Name = "checkIntervalComboBox";
            this.checkIntervalComboBox.Size = new System.Drawing.Size(79, 21);
            this.checkIntervalComboBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(440, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Will be applied to all new threads.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Download:";
            // 
            // downloadVideosCheckBox
            // 
            this.downloadVideosCheckBox.AutoSize = true;
            this.downloadVideosCheckBox.Location = new System.Drawing.Point(12, 103);
            this.downloadVideosCheckBox.Name = "downloadVideosCheckBox";
            this.downloadVideosCheckBox.Size = new System.Drawing.Size(99, 17);
            this.downloadVideosCheckBox.TabIndex = 3;
            this.downloadVideosCheckBox.Text = "Videos (WebM)";
            this.downloadVideosCheckBox.UseVisualStyleBackColor = true;
            // 
            // downloadImagesCheckBox
            // 
            this.downloadImagesCheckBox.AutoSize = true;
            this.downloadImagesCheckBox.Location = new System.Drawing.Point(12, 57);
            this.downloadImagesCheckBox.Name = "downloadImagesCheckBox";
            this.downloadImagesCheckBox.Size = new System.Drawing.Size(60, 17);
            this.downloadImagesCheckBox.TabIndex = 2;
            this.downloadImagesCheckBox.Text = "Images";
            this.downloadImagesCheckBox.UseVisualStyleBackColor = true;
            // 
            // downloadThreadPageCheckBox
            // 
            this.downloadThreadPageCheckBox.AutoSize = true;
            this.downloadThreadPageCheckBox.Location = new System.Drawing.Point(12, 34);
            this.downloadThreadPageCheckBox.Name = "downloadThreadPageCheckBox";
            this.downloadThreadPageCheckBox.Size = new System.Drawing.Size(120, 17);
            this.downloadThreadPageCheckBox.TabIndex = 1;
            this.downloadThreadPageCheckBox.Text = "Thread HTML page";
            this.downloadThreadPageCheckBox.UseVisualStyleBackColor = true;
            // 
            // downloadThumbnailsCheckBox
            // 
            this.downloadThumbnailsCheckBox.AutoSize = true;
            this.downloadThumbnailsCheckBox.Location = new System.Drawing.Point(12, 80);
            this.downloadThumbnailsCheckBox.Name = "downloadThumbnailsCheckBox";
            this.downloadThumbnailsCheckBox.Size = new System.Drawing.Size(112, 17);
            this.downloadThumbnailsCheckBox.TabIndex = 0;
            this.downloadThumbnailsCheckBox.Text = "Image Thumbnails";
            this.downloadThumbnailsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Add thread:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(935, 538);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.threadUrlTextBox);
            this.panel3.Controls.Add(this.statisticsButton);
            this.panel3.Controls.Add(this.aboutButton);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pasteFromClipboardButton);
            this.panel3.Controls.Add(this.addThreadButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 461);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(929, 74);
            this.panel3.TabIndex = 5;
            // 
            // threadUrlTextBox
            // 
            this.threadUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.threadUrlTextBox.Location = new System.Drawing.Point(78, 10);
            this.threadUrlTextBox.Name = "threadUrlTextBox";
            this.threadUrlTextBox.Size = new System.Drawing.Size(753, 20);
            this.threadUrlTextBox.TabIndex = 10;
            // 
            // statisticsButton
            // 
            this.statisticsButton.Location = new System.Drawing.Point(9, 42);
            this.statisticsButton.Margin = new System.Windows.Forms.Padding(9);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(75, 23);
            this.statisticsButton.TabIndex = 3;
            this.statisticsButton.Text = "Statistics";
            this.statisticsButton.UseVisualStyleBackColor = true;
            this.statisticsButton.Click += new System.EventHandler(this.statisticsButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(102, 42);
            this.aboutButton.Margin = new System.Windows.Forms.Padding(9);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 2;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // pasteFromClipboardButton
            // 
            this.pasteFromClipboardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pasteFromClipboardButton.Location = new System.Drawing.Point(787, 40);
            this.pasteFromClipboardButton.Margin = new System.Windows.Forms.Padding(9);
            this.pasteFromClipboardButton.Name = "pasteFromClipboardButton";
            this.pasteFromClipboardButton.Size = new System.Drawing.Size(131, 23);
            this.pasteFromClipboardButton.TabIndex = 1;
            this.pasteFromClipboardButton.Text = "Paste from Clipboard";
            this.pasteFromClipboardButton.UseVisualStyleBackColor = true;
            this.pasteFromClipboardButton.Click += new System.EventHandler(this.pasteFromClipboardButton_Click);
            // 
            // addThreadButton
            // 
            this.addThreadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addThreadButton.Location = new System.Drawing.Point(843, 10);
            this.addThreadButton.Margin = new System.Windows.Forms.Padding(9);
            this.addThreadButton.Name = "addThreadButton";
            this.addThreadButton.Size = new System.Drawing.Size(75, 23);
            this.addThreadButton.TabIndex = 0;
            this.addThreadButton.Text = "Add Thread";
            this.addThreadButton.UseVisualStyleBackColor = true;
            this.addThreadButton.Click += new System.EventHandler(this.addThreadButton_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.tableLayoutPanel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(929, 238);
            this.panel4.TabIndex = 14;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(927, 236);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.removeDeadAndCompletedButton);
            this.panel1.Controls.Add(this.stopAndRemoveSelectedButton);
            this.panel1.Controls.Add(this.openFolderButton);
            this.panel1.Controls.Add(this.stopSelectedButton);
            this.panel1.Controls.Add(this.selectAllButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 41);
            this.panel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID,
            this.col_Subject,
            this.col_Site,
            this.col_Board,
            this.col_Thread,
            this.col_ImgTotal,
            this.col_ImgDownloaded,
            this.col_Status});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(921, 183);
            this.dataGridView1.TabIndex = 5;
            // 
            // col_ID
            // 
            this.col_ID.HeaderText = "ID";
            this.col_ID.Name = "col_ID";
            // 
            // col_Subject
            // 
            this.col_Subject.HeaderText = "Subject";
            this.col_Subject.Name = "col_Subject";
            // 
            // col_Site
            // 
            this.col_Site.HeaderText = "Site";
            this.col_Site.Name = "col_Site";
            // 
            // col_Board
            // 
            this.col_Board.HeaderText = "Board";
            this.col_Board.Name = "col_Board";
            // 
            // col_Thread
            // 
            this.col_Thread.HeaderText = "Thread";
            this.col_Thread.Name = "col_Thread";
            // 
            // col_ImgTotal
            // 
            this.col_ImgTotal.HeaderText = "Img: Count";
            this.col_ImgTotal.Name = "col_ImgTotal";
            // 
            // col_ImgDownloaded
            // 
            this.col_ImgDownloaded.HeaderText = "Img: Downloaded";
            this.col_ImgDownloaded.Name = "col_ImgDownloaded";
            // 
            // col_Status
            // 
            this.col_Status.HeaderText = "Status";
            this.col_Status.Name = "col_Status";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 538);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(16, 461);
            this.Name = "MainForm";
            this.Text = "BoardHoard v0.0.1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button removeDeadAndCompletedButton;
        private System.Windows.Forms.Button stopAndRemoveSelectedButton;
        private System.Windows.Forms.Button stopSelectedButton;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button applyToAllButton;
        private System.Windows.Forms.Button applyToSelectedButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox verifyImageHashesCheckBox;
        private System.Windows.Forms.CheckBox checkIntervalCheckBox;
        private System.Windows.Forms.ComboBox checkIntervalComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox downloadVideosCheckBox;
        private System.Windows.Forms.CheckBox downloadImagesCheckBox;
        private System.Windows.Forms.CheckBox downloadThreadPageCheckBox;
        private System.Windows.Forms.CheckBox downloadThumbnailsCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox threadUrlTextBox;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button pasteFromClipboardButton;
        private System.Windows.Forms.Button addThreadButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Site;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Board;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Thread;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ImgTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ImgDownloaded;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Status;


    }
}

