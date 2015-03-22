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
            XmlSerializer serializer = new XmlSerializer(typeof(BoardContainer));

            using (TextWriter SaveWriter = new StreamWriter("BoardContainer.xml"))
            {
                serializer.Serialize(SaveWriter, this);
            }

        }

        public void LoadConfig()
        {
                this.Websites = SiteConfig.Load();
        }

        public void Add(Board b)
        {
            
            if (b.URL == "")
            {
                MessageBox.Show("Thread string is empty!");
                return;
            }

            List<Board> ExistingBoards = this.Boards;
            foreach (Board board in ExistingBoards)
            {
                if (b.URL == board.URL)
                {
                    //MessageBox.Show("Thread already exists!");
                    return;
                }
            }

            if (Boards.Count < 1)
            {
                b.ID = 1;
            }
            else
            {
                b.ID = Boards.Max(p => p.ID) + 1;
            }

            Uri Board_Uri = new Uri(b.URL);

            SiteConfig Test = new SiteConfig();
            Test = SiteConfig.Load();

            foreach (Site Config in Test.Sites)
            {
                if (Config.name == Board_Uri.Host)
                {
                    b.XPath_Subject = Config.subject;

                    b.XPath_Thread = Config.thread;
                    b.Tag_Thread = Config.thread_tag;

                    b.XPath_Board = Config.board;
                    b.Tag_Board = Config.board_tag;

                    b.XPath_Image = Config.image;
                    b.Tag_Image = Config.image_tag;

                    b.XPath_Thumbnail = Config.thumb;
                    b.Tag_Thumbnail = Config.thumb_tag;
                }
            }

            this.Boards.Add(b);
            this.Save();
        }
       
        public void Open_Folder(string site, string board, string thread)
        {
            Process.Start("explorer.exe", this.FolderLocation + site + @"\" + board + @"\" + thread + @"\");
        }
    }

}
