using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;

namespace BoardHoard
{
    public partial class MainForm : Form
    {

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
            UserConfig.Load();
            //Set up a new board container to contain our boards
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit); 
            BoardContainer.Boards = new List<Board>();

            Thread CTestingThread = new Thread(new ThreadStart(BoardContainer.Load));
            CTestingThread.IsBackground = true;
            CTestingThread.Start();

            Thread ATestingThread = new Thread(new ThreadStart(DatagridLoop));
            ATestingThread.IsBackground = true;
            ATestingThread.Start();

            Thread BTestingThread = new Thread(new ThreadStart(BoardContainer.DownloadThread));
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


        static void OnProcessExit (object sender, EventArgs e)
        {
            BoardContainer.Save();
            UserConfig.Save();
        }


        #endregion


        #region UI Callbacks for Program
        // This is where I plan to include classes that require UI objects to function

        private void UI_Execute(Action a)
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
            
            List<Board> DisplayedBoards = BoardContainer.Boards;
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
                Board.Open_Folder(Convert.ToString(Row.Cells[2].Value), Convert.ToString(Row.Cells[3].Value), Convert.ToString(Row.Cells[4].Value));
            }
        }

        private void addthreadBtn_Click(object sender, EventArgs e)
        {
            Board NewBoard = new Board();
            NewBoard.Download_HTML = htmlChk.ThreeState;
            NewBoard.Download_Images = imagesChk.ThreeState;
            NewBoard.Download_Thumnails = thumbnailChk.ThreeState;
            NewBoard.URL = threadTxt.Text;

            BoardContainer.Add_Download(NewBoard);
            threadTxt.Clear();
        }

        private void removedeadBtn_Click(object sender, EventArgs e)
        {

        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in boardDataGrid.SelectedRows)
            {
                foreach (Board b in BoardContainer.Boards)
                {
                    if (b.ID == Convert.ToInt32(Row.Cells[0].Value))
                    {
                        b.Status = 2;
                    }
                }
            }
        }

        private void selectallBtn_Click(object sender, EventArgs e)
        {
            boardDataGrid.SelectAll();
        }

    }

}
