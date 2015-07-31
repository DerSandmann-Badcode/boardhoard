using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using System.Windows.Input;
using System.Diagnostics;
using System.Reflection;

namespace BoardHoard
{
    public partial class MainForm : Form
    {
        BoardContainer RunningBoards = new BoardContainer();

        public MainForm()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            string[] names = this.GetType().Assembly.GetManifestResourceNames(); // Debug for getting loaded assemblies
            InitializeComponent();
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BoardHoard.HtmlAgilityPack.dll"))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            string[] names = this.GetType().Assembly.GetManifestResourceNames();
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
            UI_Execute(() => this.chkInstantSubmit.Checked = RunningBoards.InstantSubmit);

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
                case 900000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[4]);
                    break;
                case 1800000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[5]);
                    break;
                case 3600000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[6]);
                    break;
                case 43200000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[7]);
                    break;
                case 86400000:
                    UI_Execute(() => this.cmbThreadRefresh.SelectedItem = this.cmbThreadRefresh.Items[8]);
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
                    SavedBoard._ThreadDownload();
                    SavedBoard._ThreadRefresh();
                }
            }
            
        }

        // We want to save our boards once the program exits
        private void OnProcessExit (object sender, EventArgs e)
        {
            foreach (Board Board in RunningBoards.Boards)
            {
                if (Board.Status == 1)
                {
                    Board.Status = 0;
                }
            }
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

        private void chkInstantSubmit_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.InstantSubmit = this.chkInstantSubmit.Checked;
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
                case "15 Minutes":
                    RunningBoards.Refresh_Delay = 900000;
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

            var FolderSelect = new FolderSelect.FolderSelectDialog();
            FolderSelect.Title = "Where do you want to save files?";
            FolderSelect.InitialDirectory = @"c:\";

            if (FolderSelect.ShowDialog(IntPtr.Zero))
            {
                txtFolderPath.Text = FolderSelect.FileName + @"\";
            }

        }

        private void statisticsBtn_Click(object sender, EventArgs e)
        {
            BoardHoard.Forms.Statistics StatisticsPopout = new BoardHoard.Forms.Statistics();
            StatisticsPopout.ShowDialog();
        }



        private void removedeadBtn_Click(object sender, EventArgs e)
        {
            List<Board> DeletedBoards = new List<Board>();
            List<Board> DisplayedBoards = RunningBoards.Boards;

            foreach (Board Board in DisplayedBoards)
            {
                if (Board.Status == 3)
                {
                    DeletedBoards.Add(Board);
                }
            }

            foreach (Board DeletedBoard in DeletedBoards)
            {
                DeletedBoard.Stop();
                RunningBoards.Boards.Remove(DeletedBoard);
            }
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
                if (RunningBoards.InstantSubmit == true)
                {
                    RunningBoards.Add(txtThread.Text);
                    txtThread.Clear();
                }

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
                RunningBoards.Open_Folder(Row.Cells[2].Value.ToString(), Row.Cells[3].Value.ToString(), Row.Cells[4].Value.ToString());
            }
        }

        private void addthreadBtn_Click(object sender, EventArgs e)
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

            foreach (Board Board in RunningBoards.GetBoards(RunningBoards.Boards))
            {
                string DownloadStatusText = string.Empty;
                string StatusText = string.Empty;
                TimeSpan NextDownload = TimeSpan.FromMilliseconds(Board.Refresh_Delay);
                NextDownload = NextDownload - DateTime.Now.Subtract(Board.LastDownload);

                if (NextDownload.Milliseconds < 0)
                {
                    NextDownload = TimeSpan.FromMilliseconds(0);
                }

                // Check if board is still running, if so, update the download timer
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
                        // Row already exists, we find the indexand update it
                        Found = true;
                        string[] UpdateRow = new string[9] { Board.ID.ToString(),
                                                            Board.DateAdded.ToString(),
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
                    // Couldn't find the board, we will add it as a new entry
                    string[] NewRow = new string[9] { Board.ID.ToString(),
                                                    Board.DateAdded.ToString(),
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
                            dgvBoards.FirstDisplayedScrollingRowIndex = dgvBoards.Rows.Count - 1;
                            dgvBoards.ClearSelection();
                            dgvBoards.Rows[dgvBoards.Rows.Count - 1].Selected = true;
                        });
                    }
                    catch (ObjectDisposedException ex)
                    {
                        // We closed the form when this tried to update
                        Debug.WriteLine(ex.Message);
                    }


                }

            } // End for each board
            Datagrid_Remove();

        }

        public void Datagrid_Remove()
        {
            List<DataGridViewRow> DeleteRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow Row in dgvBoards.Rows)
            {
                bool Exists = false;
                foreach (Board ExistingBoard in RunningBoards.GetBoards(RunningBoards.Boards))
                {
                    if (ExistingBoard.ID.ToString() == Row.Cells[0].Value.ToString())
                    {
                        Exists = true;
                        break;
                    }
                }

                if (Exists == false)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        dgvBoards.Rows.Remove(Row);
                    });
                    break;
                }
            }
        }

        public void DGV_Add(string[] Data)
        {
            // Adds a row using an array
            dgvBoards.Rows.Add(Data);
        }

        public void DGV_Update(string[] Data)
        {
            // Updates a row from an array
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
                    row.Cells[8].Value = Data[8];
                }
            }
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
                    /*
                     * Show specific items if the user only has a single
                     * thread selected. Could update this to change the
                     * thread settings
                     */

                    if (SelectedRows.Count > 1)
                    {
                        contextCopy.Visible = false;
                    }
                    else
                    {
                        contextCopy.Visible = true;
                    }
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

        private void dgvBoards_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            RunningBoards.Open_Folder(dgvBoards.Rows[e.RowIndex].Cells[2].Value.ToString(),
                dgvBoards.Rows[e.RowIndex].Cells[3].Value.ToString(),
                dgvBoards.Rows[e.RowIndex].Cells[4].Value.ToString());
        }

        #endregion

        #region Context Menu

        private void ContextOpenbtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                RunningBoards.Open_Folder(Row.Cells[2].Value.ToString(), Row.Cells[3].Value.ToString(), Row.Cells[4].Value.ToString());
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
                        Board._ThreadRefresh();
                    }
                }
            }
            
        }

        private void ContextClearbtn_Click(object sender, EventArgs e)
        {
            List<Board> DeletedBoards = new List<Board>();

            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {

                List<Board> DisplayedBoards = RunningBoards.Boards;

                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        DeletedBoards.Add(Board);
                    }
                }
            }

            foreach (Board DeletedBoard in DeletedBoards)
            {
                DeletedBoard.Stop();
                RunningBoards.Boards.Remove(DeletedBoard);
            }

        }

        private void ContextClearDeletebtn_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("This option will clear out the entry from " +
                                                        "BoardHoard AND delete the folder from your " +
                                                        "hard disk!" + Environment.NewLine + Environment.NewLine +
                                                        "Are you sure?", "Delete Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
            List<DataGridViewRow> DeletedRows = new List<DataGridViewRow>();
            List<Board> DeletedBoards = new List<Board>();

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

        private void toolstip15mins_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Board.Refresh_Delay = 900000;
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
                        Board._ThreadDownload();
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

        private void contextCopy_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dgvBoards.SelectedRows)
            {
                List<Board> DisplayedBoards = RunningBoards.Boards;
                foreach (Board Board in DisplayedBoards)
                {
                    if (Row.Cells[0].Value.ToString() == Board.ID.ToString())
                    {
                        Clipboard.SetText(Board.URL);
                    }
                }
            }
        }

        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                txtThread.Clear();
                txtThread.Text = Clipboard.GetText();
                if (txtThread.Text != string.Empty)
                {
                    // Create a new board with the UI settings
                    // and add it to the BoardContainer
                    if (RunningBoards.InstantSubmit == true)
                    {
                        RunningBoards.Add(txtThread.Text);
                        txtThread.Clear();
                    }
                }
            }
        }

        private void txtThread_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                // Throw away the default Ctrl+C function.
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            // Check if our object is text. We only want reply links
            // if it is, show an icon to the user
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            // put text into the text box, then optionally submit
            txtThread.Text = e.Data.GetData(DataFormats.Text).ToString();
            if (txtThread.Text != string.Empty)
            {
                // Create a new board with the UI settings
                // and add it to the BoardContainer
                if (RunningBoards.InstantSubmit == true)
                {
                    RunningBoards.Add(txtThread.Text);
                    txtThread.Clear();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BoardHoard.Forms.Search SearchWindow = new BoardHoard.Forms.Search();
            SearchWindow.ShowDialog();
        }









    }

}
