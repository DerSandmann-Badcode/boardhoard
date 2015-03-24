using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using System.Windows.Input;
using System.Diagnostics;

namespace BoardHoard
{
    public partial class MainForm : Form
    {
        BoardContainer RunningBoards = new BoardContainer();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit); 
            
            Thread CTestingThread = new Thread(new ThreadStart(Setup));
            CTestingThread.IsBackground = true;
            CTestingThread.Start();
            
        }

        public void Setup()
        {
            RunningBoards.LoadConfig();
            RunningBoards = BoardContainer.Load();

            // Update our UI to reflect the Config
            UI_Execute(() => this.txtFolderPath.Text = RunningBoards.FolderLocation);

            UI_Execute(() => this.chkImages.Checked = RunningBoards.DownloadImages);
            UI_Execute(() => this.chkThumbnails.Checked = RunningBoards.DownloadThumbnails);
            UI_Execute(() => this.chkWebm.Checked = RunningBoards.DownloadWebMs);
            UI_Execute(() => this.chkHTML.Checked = RunningBoards.DownloadHTML);
            UI_Execute(() => this.chkVerifyHashes.Checked = RunningBoards.VerifyHashes);
            UI_Execute(() => this.chkSeperateFolder.Checked = RunningBoards.AnimatedFolder);
            UI_Execute(() => this.chkClearDead.Checked = RunningBoards.ClearDead);
            UI_Execute(() => this.chkDeathAlert.Checked = RunningBoards.AlertDeath);
            UI_Execute(() => this.chkConstantCheck.Checked = RunningBoards.ConstantRefresh);

            switch (RunningBoards.Refresh_Delay)
            {
                case 30000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[0]);
                    break;
                case 60000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[1]);
                    break;
                case 120000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[2]);
                    break;
                case 300000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[3]);
                    break;
                case 1800000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[4]);
                    break;
                case 3600000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[5]);
                    break;
                case 43200000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[6]);
                    break;
                case 86400000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[7]);
                    break;
            }

            if (System.IO.File.Exists("SiteConfig.xml") == false)
            {
                SiteConfig.WriteDefaultConfig();
            }

            Thread ATestingThread = new Thread(new ThreadStart(DatagridLoop));
            ATestingThread.IsBackground = true;
            ATestingThread.Start();

            foreach (Board SavedBoard in RunningBoards.Boards)
            {
                if (SavedBoard.ConstantRefresh == true)
                {
                    SavedBoard.Download_Single();
                    SavedBoard.StartRefresh();
                }
            }
            
        }

        // We want to save our boards once the program exits
        private void OnProcessExit (object sender, EventArgs e)
        {
            RunningBoards.Save();
        }

        // This function checks if the control needs an invoke
        // if it does, it calls invoke
        public void UI_Execute(Action a)
        {
            if (InvokeRequired)
                BeginInvoke(a);
            else
                a();
        }

        public void RemoveBoard(Board Board)
        {
            RunningBoards.Boards.Remove(Board);
        }


        #region FormChangedEvents
        private void imagesChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.DownloadImages = this.chkImages.Checked;
        }

        private void htmlChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.DownloadHTML = this.chkHTML.Checked;
        }

        private void webmChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.DownloadWebMs = this.chkWebm.Checked;
        }

        private void thumbnailChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.DownloadThumbnails = this.chkThumbnails.Checked;
        }

        private void separatefolderChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.AnimatedFolder = this.chkSeperateFolder.Checked;
        }

        private void deadclearChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.ClearDead = this.chkClearDead.Checked;
        }

        private void deathalertChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.AlertDeath = this.chkDeathAlert.Checked;
        }

        private void continuousChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.ConstantRefresh = this.chkConstantCheck.Checked;
        }

        private void hashesChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.VerifyHashes = this.chkVerifyHashes.Checked;
        }

        private void folderTxt_TextChanged(object sender, EventArgs e)
        {
            RunningBoards.FolderLocation = txtFolderPath.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbThreadRefresh.SelectedItem.ToString())
            {
                case "30 Seconds":
                    RunningBoards.Refresh_Delay = 30000;
                    break;
                case "1 Minute":
                    RunningBoards.Refresh_Delay = 60000;
                    break;
                case "2 Minutes":
                    RunningBoards.Refresh_Delay = 120000;
                    break;
                case "5 Minutes":
                    RunningBoards.Refresh_Delay = 300000;
                    break;
                case "30 Minutes":
                    RunningBoards.Refresh_Delay = 1800000;
                    break;
                case "1 Hour":
                    RunningBoards.Refresh_Delay = 3600000;
                    break;
                case "12 Hours":
                    RunningBoards.Refresh_Delay = 43200000;
                    break;
                case "Daily":
                    RunningBoards.Refresh_Delay = 86400000;
                    break;
            }


        }
        #endregion

        #region Form Buttons

        private void selectBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = FolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFolderPath.Text = FolderDialog.SelectedPath + @"\";

            }

        }

        private void statisticsBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void removedeadBtn_Click(object sender, EventArgs e)
        {

        }

        private void selectallBtn_Click(object sender, EventArgs e)
        {
            dgvBoards.SelectAll();
        }

        private void clipboardpasteBtn_Click(object sender, EventArgs e)
        {
            txtThread.Text = Clipboard.GetText();
            if (txtThread.Text != string.Empty)
            {
                // Create a new board with the UI settings
                // and add it to the BoardContainer
                RunningBoards.Add(txtThread.Text);

                txtThread.Clear();
            }
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            BoardHoard.Forms.frmAbout AboutDialog = new BoardHoard.Forms.frmAbout();
            AboutDialog.ShowDialog();
        }

        private void openfolderBtm_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                RunningBoards.Open_Folder(Row.Cells[1].Value.ToString(), Row.Cells[2].Value.ToString(), Row.Cells[3].Value.ToString());
            }
        }

        private void addthreadBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtThread.Text != string.Empty)
                {
                    // Create a new board with the UI settings
                    // and add it to the BoardContainer
                    RunningBoards.Add(txtThread.Text);

                    txtThread.Clear();
                }
                else
                {
                    MessageBox.Show("Board string is empty!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
#endregion

        #region Datagrid Update Functions

        public void DatagridLoop()
        {
            int AutoSave = 0;
            do
            {
                Datagrid_Refresh();

                AutoSave += 1;
                if (AutoSave == 300) // AutoSave every 30 seconds
                {
                    RunningBoards.Save();
                    AutoSave = 0;
                }
                Thread.Sleep(100);
            } while (true);

        }

        public void Datagrid_Refresh()
        {

            lock (RunningBoards)
            {

                foreach (Board Board in RunningBoards.GetBoards(RunningBoards.Boards))
                {
                    string DownloadStatusText = string.Empty;
                    string StatusText = string.Empty;
                    TimeSpan NextDownload = TimeSpan.FromMilliseconds(Board.Refresh_Delay);
                    NextDownload = NextDownload - DateTime.Now.Subtract(Board.LastDownload);


                    if (Board.ConstantRefresh == true)
                    {

                        DownloadStatusText = NextDownload.Minutes.ToString() + "m " + NextDownload.Seconds.ToString() + "s";
                    }

                    switch (Board.Status)
                    {
                        case 0:
                            StatusText = "Active";
                            break;
                        case 1:
                            DownloadStatusText = "DOWNLOADING";
                            StatusText = "Active";
                            break;
                        case 2:
                            StatusText = "Active";
                            break;
                        case 3:
                            StatusText = "404";
                            break;
                    }

                    Boolean Found = false;
                    foreach (DataGridViewRow Row in dgvBoards.Rows)
                    {
                        if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                        {
                            Found = true;
                            string[] UpdateRow = new string[8] { Board.ID.ToString(),
                                                            Board.Site, 
                                                            Board.Name, 
                                                            Board.Thread_ID.ToString(), 
                                                            Board.Subject, 
                                                            Board.DownloadedCount.ToString(), 
                                                            StatusText, 
                                                            DownloadStatusText };

                            // There is a chance where the form is closing
                            // and this will try to run, we want to catch the
                            // exception that this object does not exist
                            try
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    DGV_Update(UpdateRow); // runs on UI thread
                                });
                            }
                            catch (ObjectDisposedException ex)
                            {
                                Debug.WriteLine(ex.Message);
                            }

                        } // End check if we found the board earlier

                    } // End for each datagridviewrow

                    if (Found == false)
                    {
                        string[] NewRow = new string[8] { Board.ID.ToString(),
                                                            Board.Site, 
                                                            Board.Name, 
                                                            Board.Thread_ID.ToString(), 
                                                            Board.Subject, 
                                                            Board.DownloadedCount.ToString(), 
                                                            StatusText, 
                                                            DownloadStatusText };

                        // There is a chance where the form is closing
                        // and this will try to run, we want to catch the
                        // exception that this object does not exist
                        try
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                dgvBoards.Rows.Add(NewRow); // runs on UI thread
                            });
                        }
                        catch (ObjectDisposedException ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }


                    }

                } // End for each board

            }

        }

        public void DGV_Add(string[] Data)
        {
            dgvBoards.Rows.Add(Data);
        }

        public void DGV_Update(string[] Data)
        {

            foreach (DataGridViewRow row in dgvBoards.Rows)
            {
                if ((string)row.Cells[0].Value == Data[0])
                {
                    row.Cells[0].Value = Data[0];
                    row.Cells[1].Value = Data[1];
                    row.Cells[2].Value = Data[2];
                    row.Cells[3].Value = Data[3];
                    row.Cells[4].Value = Data[4];
                    row.Cells[5].Value = Data[5];
                    row.Cells[6].Value = Data[6];
                    row.Cells[7].Value = Data[7];
                }
            }
        }

        public void Datagrid_Delete(DataGridViewRow DeletedRow)
        {
            dgvBoards.Rows.Remove(DeletedRow);
        }

        private void boardDataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }
                DataGridViewRow ClickedRow = dgvBoards.Rows[e.RowIndex];
                DataGridViewSelectedRowCollection SelectedRows = dgvBoards.SelectedRows;
                if (SelectedRows.Contains(ClickedRow))
                {
                    ContextBoardDataGrid.Show(Cursor.Position);
                }
                else
                {
                    dgvBoards.ClearSelection();
                    ClickedRow.Selected = true;
                    ContextBoardDataGrid.Show(Cursor.Position);
                }

            }

        }

        private void dgvBoards_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            RunningBoards.Open_Folder(dgvBoards.Rows[e.RowIndex].Cells[1].Value.ToString(),
                dgvBoards.Rows[e.RowIndex].Cells[2].Value.ToString(),
                dgvBoards.Rows[e.RowIndex].Cells[3].Value.ToString());

        }

        #endregion

        #region Context Menu

        private void ContextOpenbtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                RunningBoards.Open_Folder(Row.Cells[1].Value.ToString(), Row.Cells[2].Value.ToString(), Row.Cells[3].Value.ToString());
            }
        }

        private void ContextStopbtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.ConstantRefresh = false;
                    }
                }
            }
        }

        private void ContextStartbtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.ConstantRefresh = true;
                        Board.StartRefresh();
                    }
                }
            }
            
        }

        private void ContextClearbtn_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> DeletedRows = new List<DataGridViewRow>();
            List<Board> DeletedBoards = new List<Board>();

            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                

                List<Board> DisplayedBoards = RunningBoards.Boards;

                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        //Board.Remove(Row);
                        //dgvBoards.Rows.Remove(Row);
                        DeletedBoards.Add(Board);
                        DeletedRows.Add(Row);
                    }
                }
            }

            foreach (Board DeletedBoard in DeletedBoards)
            {
                DeletedBoard.Stop();
                RunningBoards.Boards.Remove(DeletedBoard);
            }

            foreach (DataGridViewRow DeletedRow in DeletedRows)
            {
                dgvBoards.Rows.Remove(DeletedRow);
            }

        }

        private void ContextClearDeletebtn_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> DeletedRows = new List<DataGridViewRow>();
            List<Board> DeletedBoards = new List<Board>();

            lock (dgvBoards)
            {

                foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
                {
                    List<Board> DisplayedBoards = RunningBoards.Boards;

                    foreach (Board Board in DisplayedBoards)
                    {
                        if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                        {
                            DeletedBoards.Add(Board);
                            DeletedRows.Add(Row);
                        }
                    }
                }

                foreach (Board DeletedBoard in DeletedBoards)
                {
                    DeletedBoard.Stop_Delete();
                    RunningBoards.Boards.Remove(DeletedBoard);
                }

                foreach (DataGridViewRow DeletedRow in DeletedRows)
                {
                    dgvBoards.Rows.Remove(DeletedRow);
                }
            }

        }

        private void Context30Secbtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.Refresh_Delay = 30000;
                    }
                }
            }
        }

        private void Context1Minbtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.Refresh_Delay = 60000;
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.Refresh_Delay = 120000;
                    }
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.Refresh_Delay = 300000;
                    }
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.Refresh_Delay = 1800000;
                    }
                }
            }
        }

        private void Context1Hourbtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.Refresh_Delay = 3600000;
                    }
                }
            }
        }

        private void Context12Hrs_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.Refresh_Delay = 43200000;
                    }
                }
            }
        }

        private void ContextDaily_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.Refresh_Delay = 86400000;
                    }
                }
            }
        }

        private void ContextCheckbtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.Download_Single();
                    }
                }
            }
        }

        private void ContexrStop_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.Stop();
                    }
                }
            }
        }

        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                txtThread.Text = Clipboard.GetText();
                if (txtThread.Text != string.Empty)
                {
                    // Create a new board with the UI settings
                    // and add it to the BoardContainer
                    RunningBoards.Add(txtThread.Text);

                    txtThread.Clear();
                }
        

            }
        }


    }

}
