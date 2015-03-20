using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;

namespace BoardHoard
{
    public partial class MainForm : Form
    {
        static BoardContainer RunningBoards = new BoardContainer();
        #region Prebuilt UI Functions

        public MainForm()
        {
            InitializeComponent();
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            boardDataGrid.SelectAll();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //RunningBoards = BoardContainer.Load();
            //Set up a new board container to contain our boards
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit); 
            //BoardContainer.Boards = new Board[];
            
            Thread CTestingThread = new Thread(new ThreadStart(Setup));
            CTestingThread.IsBackground = true;
            CTestingThread.Start();

            
            Thread ATestingThread = new Thread(new ThreadStart(DatagridLoop));
            ATestingThread.IsBackground = true;
            ATestingThread.Start();

            //RunningBoards.DownloadImages = ;
            

            
        }

        public void Setup()
        {
            RunningBoards.LoadConfig();
            RunningBoards = BoardContainer.Load();
            UI_Execute(() => this.folderTxt.Text = RunningBoards.FolderLocation);

            UI_Execute(() => this.imagesChk.Checked = RunningBoards.DownloadImages);
            UI_Execute(() => this.thumbnailChk.Checked = RunningBoards.DownloadThumbnails);
            UI_Execute(() => this.webmChk.Checked = RunningBoards.DownloadWebMs);
            UI_Execute(() => this.htmlChk.Checked = RunningBoards.DownloadHTML);
            UI_Execute(() => this.hashesChk.Checked = RunningBoards.VerifyHashes);
            UI_Execute(() => this.separatefolderChk.Checked = RunningBoards.AnimatedFolder);
            UI_Execute(() => this.deadclearChk.Checked = RunningBoards.ClearDead);
            UI_Execute(() => this.deathalertChk.Checked = RunningBoards.AlertDeath);
            UI_Execute(() => this.continuousChk.Checked = RunningBoards.ConstantRefresh);

            switch (RunningBoards.Refresh_Delay)
            {
                case 30000:
                    UI_Execute(() => this.comboBox1.SelectedText = "30 Seconds");
                    break;
                case 60000:
                    UI_Execute(() => this.comboBox1.SelectedText = "1 Minute");
                    break;
                case 120000:
                    UI_Execute(() => this.comboBox1.SelectedText = "2 Minutes");
                    break;
                case 300000:
                    UI_Execute(() => this.comboBox1.SelectedText = "5 Minutes");
                    break;
                case 1800000:
                    UI_Execute(() => this.comboBox1.SelectedText = "30 Minutes");
                    break;
                case 3600000:
                    UI_Execute(() => this.comboBox1.SelectedText = "1 Hour");
                    break;
            }

            if (System.IO.File.Exists("SiteConfig.xml") == false)
            {
                SiteConfig.WriteDefaultConfig();
            }

            

            Thread BTestingThread = new Thread(new ThreadStart(RunningBoards.DownloadThread));
            BTestingThread.IsBackground = true;
            BTestingThread.Start();
            
        }


        private void aboutButton_Click(object sender, EventArgs e)
        {
            
            //string[] names = new string[8] { "Matt", "Joanne", "Robert", "Robert", "Robert", "Robert", "Robert", "Robert" };
            //DGV_Add(names);

        }

        private void pasteFromClipboardButton_Click(object sender, EventArgs e)
        {
            //UserConfig.Load();
            //MessageBox.Show(UserConfig.FolderLocation);

        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            
        }


        private void OnProcessExit (object sender, EventArgs e)
        {
            RunningBoards.Save();
        }


        #endregion


        #region UI Callbacks for Program
        // This is where I plan to include classes that require UI objects to function

        public void UI_Execute(Action a)
        {
            if (InvokeRequired)
                BeginInvoke(a);
            else
                a();
        }

        

        public void DGV_Add(string[] Data)
        {
            boardDataGrid.Rows.Add(Data);
        }

        public void DGV_Update(string[] Data)
        {
            
            foreach (DataGridViewRow row in boardDataGrid.Rows)
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

        public void Datagrid_Refresh()
        {
            
            List<Board> DisplayedBoards = RunningBoards.Boards;
            foreach (Board Board in DisplayedBoards)
            {
                string StatusText = string.Empty;
                        switch (Board.Status)
                        {
                            case 0:
                                StatusText = "IDLE";
                                break;
                            case 1:
                                StatusText = "RUNNING";
                                break;
                            case 2:
                                StatusText = "STOPPED";
                                break;
                            case 3:
                                StatusText = "DEAD";
                                break;
                        }

                Boolean Found = false;
                foreach (DataGridViewRow Row in boardDataGrid.Rows)
                {
                    if (Convert.ToUInt32(Row.Cells[0].Value) == Board.ID)
                    {
                        Found = true;
                        string[] UpdateRow = new string[8] { Convert.ToString(Board.ID), 
                                                            Board.Subject, 
                                                            Board.Site, 
                                                            Board.Name, 
                                                            Convert.ToString(Board.Thread), 
                                                            Convert.ToString(Board.ImgCount), 
                                                            Convert.ToString(Board.ImgDownloaded), 
                                                            StatusText };
                        try
                        {

                            this.Invoke((MethodInvoker)delegate
                            {
                                DGV_Update(UpdateRow);
                                //BoardDataGrid.Rows.Add(NewRow); // runs on UI thread
                            });
                        }
                        catch (Exception ex)
                        {
                            
                        }

                    } // End check if we found the board earlier

                } // End for each datagridviewrow

                if (Found == false)
                {
                    string[] NewRow = new string[8] { Convert.ToString(Board.ID), 
                                                            Board.Subject, 
                                                            Board.Site, 
                                                            Board.Name, 
                                                            Convert.ToString(Board.Thread), 
                                                            Convert.ToString(Board.ImgDownloaded), 
                                                            Convert.ToString(Board.ImgCount), 
                                                            StatusText };
                    try
                    {
                        //string newText = "abc"; // running on worker thread
                        this.Invoke((MethodInvoker)delegate
                        {
                            boardDataGrid.Rows.Add(NewRow); // runs on UI thread
                        });

                        //Invoke(Del_Add_DGV, new object[] { NewRow });
                    }
                    catch (Exception ex)
                    {

                    }
                }

            } // End for each board
            
        }

        public void DatagridLoop()
        {
            do
            {

                Datagrid_Refresh();
                

                Thread.Sleep(100);
            } while (true);
            
        }

        #endregion

        private void openfolderBtm_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in boardDataGrid.SelectedRows)
            {
                RunningBoards.Open_Folder(Convert.ToString(Row.Cells[2].Value), Convert.ToString(Row.Cells[3].Value), Convert.ToString(Row.Cells[4].Value));
            }
        }

        private void addthreadBtn_Click(object sender, EventArgs e)
        {

            try
            {

            Board NewBoard = new Board();
            NewBoard.Download_HTML = this.htmlChk.Checked;
            NewBoard.Download_Images = this.imagesChk.Checked;
            NewBoard.Download_Thumnails = this.thumbnailChk.Checked;
            NewBoard.URL = threadTxt.Text;

            RunningBoards.Add_Download(NewBoard);
            
            threadTxt.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void removedeadBtn_Click(object sender, EventArgs e)
        {

        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            /*
            foreach (DataGridViewRow Row in boardDataGrid.SelectedRows)
            {
                foreach (Board b in BoardContainer.Boards)
                {
                    if (b.ID == Convert.ToInt32(Row.Cells[0].Value))
                    {
                        b.Status = 2;
                    }
                }
            }*/
        }

        private void selectallBtn_Click(object sender, EventArgs e)
        {
            boardDataGrid.SelectAll();
        }

        private void clipboardpasteBtn_Click(object sender, EventArgs e)
        {
            SiteConfig.WriteDefaultConfig();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void imagesChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.DownloadImages = this.imagesChk.Checked;
        }

        private void htmlChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.DownloadHTML = this.htmlChk.Checked;
        }

        private void webmChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.DownloadWebMs = this.webmChk.Checked;
        }

        private void thumbnailChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.DownloadThumbnails = this.thumbnailChk.Checked;
        }

        private void separatefolderChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.AnimatedFolder = this.separatefolderChk.Checked;
        }

        private void deadclearChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.ClearDead = this.deadclearChk.Checked;
        }

        private void deathalertChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.AlertDeath = this.deathalertChk.Checked;
        }

        private void continuousChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.ConstantRefresh = this.continuousChk.Checked;
        }

        private void hashesChk_CheckedChanged(object sender, EventArgs e)
        {
            RunningBoards.VerifyHashes = this.hashesChk.Checked;
        }

        private void folderTxt_TextChanged(object sender, EventArgs e)
        {
            RunningBoards.FolderLocation = folderTxt.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
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
            }
                

        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = FolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderTxt.Text = FolderDialog.SelectedPath + @"\";

            }

        }




    }

}
