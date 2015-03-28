using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using System.Xml;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using System.Net;

namespace BoardHoard
{
    [XmlRootAttribute("BoardContainer", Namespace = "BoardHoard")]

    public class BoardContainer
    {
        private SiteConfig Websites = new SiteConfig();
        public List<Board> Boards = new List<Board>();
        public int Refresh_Delay = 120000;
        public string FolderLocation = Directory.GetCurrentDirectory() + @"\Downloaded_Boards\";
        public bool DownloadImages = false;
        public bool DownloadThumbnails = false;
        public bool DownloadHTML = false;
        public bool DownloadWebMs = false;
        public bool AnimatedFolder = false;
        public bool VerifyHashes = false;
        public bool ClearDead = false;
        public bool AlertDeath = false;
        public bool ConstantRefresh = false;
        public bool InstantSubmit = false;

        public static BoardContainer Load()
        {
            BoardContainer LoadedContainer = new BoardContainer();

            if (File.Exists("BoardContainer.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BoardContainer));

                using (FileStream fs =  new FileStream("BoardContainer.xml", FileMode.Open))
                {
                    LoadedContainer = (BoardContainer)serializer.Deserialize(fs);
                }
            }

            return LoadedContainer;
        }

        public void Save()
        {
            /*
             * Set any currently running boards to
             * idle, then we will serialize our 
             * board container to a file
             */
            foreach (Board Board in this.Boards)
            {
                if (Board.Status == 1)
                {
                    Board.Status = 0;
                }
            }

            XmlSerializer serializer = new XmlSerializer(typeof(BoardContainer));

            using (TextWriter SaveWriter = new StreamWriter("BoardContainer.xml"))
            {
                serializer.Serialize(SaveWriter, this);
            }

        }

        public void LoadConfig()
        {
            // Load in our website config file
            this.Websites = SiteConfig.Load();
        }

        public void Add(string Board_URL)
        {

            /*
             * This takes the information on the current
             * board container and generates a new board
             * with those settings. If board is not found 
             * in board config, we will not do anything with
             * the URL.
             */
            Board NewBoard = new Board();
            NewBoard.Download_HTML = this.DownloadHTML;
            NewBoard.Download_Images = this.DownloadImages;
            NewBoard.Download_Thumnails = this.DownloadThumbnails;
            NewBoard.Download_WebMs = this.DownloadWebMs;
            NewBoard.URL = Board_URL;
            NewBoard.DownloadPath = this.FolderLocation;
            NewBoard.Refresh_Delay = this.Refresh_Delay;
            NewBoard.ConstantRefresh = this.ConstantRefresh;
            NewBoard.AnimatedFolder = this.AnimatedFolder;
            NewBoard.Alerts_Death = this.AlertDeath;

            if (NewBoard.URL == "")
            {
                MessageBox.Show("Thread string is empty!");
                return;
            }

            List<Board> ExistingBoards = this.Boards;
            foreach (Board board in ExistingBoards)
            {
                if (NewBoard.URL == board.URL)
                {

                    /*
                     * Board akready exists, we will give
                     * the user the option of replacing the
                     * one currently in the container with the
                     * current settings
                     */

                    DialogResult dialogResult = MessageBox.Show("Update this thread to the current configuration?", "Thread already exists!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        board.Download_HTML = this.DownloadHTML;
                        board.Download_Images = this.DownloadImages;
                        board.Download_Thumnails = this.DownloadThumbnails;
                        board.Download_WebMs = this.DownloadWebMs;
                        board.DownloadPath = this.FolderLocation;
                        board.Refresh_Delay = this.Refresh_Delay;
                        board.ConstantRefresh = this.ConstantRefresh;
                        board.AnimatedFolder = this.AnimatedFolder;
                        board.Alerts_Death = this.AlertDeath;

                        return;
                        //do something
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                    //MessageBox.Show("Thread already exists!");
                }
            }

            if (Boards.Count < 1)
            {
                NewBoard.ID = 1;
            }
            else
            {
                NewBoard.ID = Boards.Max(p => p.ID) + 1;
            }

            Uri Board_Uri = new Uri(NewBoard.URL);

            SiteConfig Test = new SiteConfig();
            Test = SiteConfig.Load();

            bool ConfigFound = false;
            foreach (Site Config in Test.Sites)
            {
                if (Config.name == Board_Uri.Host)
                {
                    ConfigFound = true;
                    NewBoard.XPath_Subject = Config.subject;

                    NewBoard.XPath_Thread = Config.thread;
                    NewBoard.Tag_Thread = Config.thread_tag;

                    NewBoard.XPath_Board = Config.board;
                    NewBoard.Tag_Board = Config.board_tag;

                    NewBoard.XPath_Image = Config.image;
                    NewBoard.Tag_Image = Config.image_tag;

                    NewBoard.XPath_Thumbnail = Config.thumb;
                    NewBoard.Tag_Thumbnail = Config.thumb_tag;
                }
            }

            if (ConfigFound == false)
            {
                // Tell user that I could not find their board config
                MessageBox.Show("I did not find the config for that site. Please add a configuration for that website.");
                return;
            }

            this.Boards.Add(NewBoard);
            this.Save();

            // Download the thread to get the board ID and stats
            NewBoard.Download_Single();

            if (NewBoard.ConstantRefresh == true)
            {
                NewBoard.StartRefresh();
            }
        }
       
        public void Open_Folder(string site, string board, string thread)
        {
            // Open an explorer window at the board location
            Process.Start("explorer.exe", this.FolderLocation + site + @"\" + board + @"\" + thread + @"\");
        }

        //This deep-copies the boards into a new collection
        public List<Board> GetBoards(List<Board> CopiedBoards)
        {
            List<Board> Result = new List<Board>();

            foreach (Board CopyBoard in CopiedBoards)
            {
                Result.Add(CopyBoard);
            }

            return Result;
        }
    }

}
