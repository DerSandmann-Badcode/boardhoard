using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Board.Config NewConfig = new Board.Config();
            NewConfig.Download_HTML = downloadThreadPageCheckBox.Checked = true;
            NewConfig.Download_Images = downloadImagesCheckBox.Checked = true;
            NewConfig.Download_Thumnails = downloadThumbnailsCheckBox.Checked = true;
            NewConfig.URL = threadUrlTextBox.Text;

            BoardContainer.Add(NewConfig);
            threadUrlTextBox.Clear();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Set up a new board container to contain our boards
            BoardContainer.Boards = new List<Board>();


        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        private void pasteFromClipboardButton_Click(object sender, EventArgs e)
        {
            BoardContainer.DownloadThread();
        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            BoardContainer.Load();
        }

        #region UI Callbacks for Program
        // This is where I plan to include classes that require UI objects to function
       

        #endregion

    }

}
