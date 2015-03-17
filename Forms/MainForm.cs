using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

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
            
        }

        private void addThreadButton_Click(object sender, EventArgs e)
        {
            Board NewBoard = new Board();
            NewBoard.Download_HTML = downloadThreadPageCheckBox.Checked = true;
            NewBoard.Download_Images = downloadImagesCheckBox.Checked = true;
            NewBoard.Download_Thumnails = downloadThumbnailsCheckBox.Checked = true;
            NewBoard.URL = threadUrlTextBox.Text;

            BoardContainer.Add(NewBoard);
            threadUrlTextBox.Clear();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            //Setup_Delgates();
            //Set up a new board container to contain our boards
            BoardContainer.Boards = new List<Board>();

            BoardContainer.Load();

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
            BoardContainer.Load();
            
            MessageBox.Show("i" + BoardContainer.Boards.Count);

        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            
        }

        #endregion


        #region UI Callbacks for Program
        // This is where I plan to include classes that require UI objects to function

        public void Setup_Delgates()
        {
            Del_Add_DGV = new Datagrid_Add(this.DGV_Add);
            Del_Update_DGV = new Datagrid_Update(this.DGV_Update);
        }

        public delegate void Datagrid_Add(string[] Data);
        public delegate void Datagrid_Update(string[] Data);
        public static Datagrid_Add Del_Add_DGV;
        public static Datagrid_Update Del_Update_DGV;
        
        public void DGV_Add(string[] Data)
        {
            BoardDataGrid.Rows.Add(Data);
        }

        public void DGV_Update(string[] Data)
        {
            foreach (DataGridViewRow row in BoardDataGrid.Rows)
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
            foreach (Board Board in BoardContainer.Boards)
            {
                Boolean Found = false;
                foreach (DataGridViewRow Row in BoardDataGrid.Rows)
                {
                    if (Convert.ToUInt32(Row.Cells[0].Value) == Board.ID)
                    {
                        Found = true;
                        string[] UpdateRow = new string[8] { Convert.ToString(Board.ID), 
                                                            Board.Subject, 
                                                            Board.Site, 
                                                            Board.Name, 
                                                            Convert.ToString(Board.Thread), 
                                                            Convert.ToString(Board.ImgDownloaded), 
                                                            Convert.ToString(Board.ImgCount), 
                                                            Convert.ToString(Board.Status) };
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
                                                            Convert.ToString(Board.Status) };
                    try
                    {
                        //string newText = "abc"; // running on worker thread
                        this.Invoke((MethodInvoker)delegate
                        {
                            BoardDataGrid.Rows.Add(NewRow); // runs on UI thread
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

    }

}
