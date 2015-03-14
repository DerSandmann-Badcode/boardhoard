using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Xml.Linq;
using System.Xml;

namespace BoardHoard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    class UI_Functions
    {
        public static void Datagrid_Refresh()
        {
            foreach (Board b in BoardContainer.Boards)
            {
                bool BoardRowExists = false;

            }
        }
    }

    class BoardContainer
    {

        public static List<Board> Boards { get; set; }

        public static void Load()
        {

        }

        public static void Save()
        {
            XmlWriterSettings BoardSettings = new XmlWriterSettings();
            BoardSettings.Indent = true;

            XmlWriter SaveWriter = XmlWriter.Create("C:\\DEV\\Newboard.xml", BoardSettings);


            SaveWriter.WriteStartDocument();

            SaveWriter.WriteComment("Saved Boards");

            SaveWriter.WriteStartElement("boards");

            foreach (Board savedBoard in BoardContainer.Boards)
            {
                SaveWriter.WriteStartElement("board");

                SaveWriter.WriteComment("Status: 0 = Idle, 2 = Stopped, 3 = Dead");
                SaveWriter.WriteStartElement("status");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Status));
                SaveWriter.WriteEndElement();

                SaveWriter.WriteStartElement("url");
                SaveWriter.WriteString(savedBoard.URL);
                SaveWriter.WriteEndElement();

                SaveWriter.WriteComment("Thread config");
                    
                SaveWriter.WriteStartElement("download_html");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Download_HTML));
                SaveWriter.WriteEndElement();

                SaveWriter.WriteStartElement("download_thumbs");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Download_Thumnails));
                SaveWriter.WriteEndElement();

                SaveWriter.WriteStartElement("download_images");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Download_Images));
                SaveWriter.WriteEndElement();

                SaveWriter.WriteStartElement("download_webms");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Download_WebMs));
                SaveWriter.WriteEndElement();

                SaveWriter.WriteStartElement("animated_separate");
                SaveWriter.WriteString(Convert.ToString(savedBoard.AnimatedFolder));
                SaveWriter.WriteEndElement();

                SaveWriter.WriteStartElement("thread_death_notify");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Alerts_Death));
                SaveWriter.WriteEndElement();

                SaveWriter.WriteStartElement("thread_download_notify");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Alerts_Download));
                SaveWriter.WriteEndElement();

                //SaveWriter.WriteStartElement("date_last_download");
                //SaveWriter.WriteString(savedBoard.LastDownload);
                //SaveWriter.WriteEndElement();

                SaveWriter.WriteEndElement(); 
            }

            SaveWriter.WriteEndElement();
            SaveWriter.WriteEndDocument();
            SaveWriter.Close();

        }

        public static void Add(string URL)
        {
            if (URL == "")
            {
                MessageBox.Show("Thread string is empty!");
                return;
            }

            foreach (Board b in BoardContainer.Boards)
            {
                if (URL == b.URL)
                {
                    MessageBox.Show("Thread already exists!");
                    return;
                }
            }

            Board New_Board = new Board();
            New_Board.ID = BoardContainer.Boards.Count + 1;
            New_Board.URL = URL;

            Uri Board_Uri = new Uri(New_Board.URL);
            XElement Doc = XElement.Load("C:\\DEV\\MyXML.xml");

            //XElement BoardConfig = Doc.Element("sites")
            //               .Elements("site")
            //               .Where(x => x.Element("name").Value == Board_Uri.Host)
            //               .SingleOrDefault();

            string t = Board_Uri.Host;
            var Configs = from ConfigXML in Doc.Elements("site")
                    where (string)ConfigXML.Element("name") == Board_Uri.Host
                    select ConfigXML;

            foreach (XElement BoardConfig in Configs)
            {
                New_Board.XPath_Subject = BoardConfig.Element("subject").Value;

                New_Board.XPath_Thread = BoardConfig.Element("thread").Value;
                New_Board.Tag_Thread = BoardConfig.Element("thread_tag").Value;

                New_Board.XPath_Board = BoardConfig.Element("board").Value;
                New_Board.Tag_Board = BoardConfig.Element("board_tag").Value;

                New_Board.XPath_Image = BoardConfig.Element("image").Value;
                New_Board.Tag_Image = BoardConfig.Element("image_tag").Value;

                New_Board.XPath_Thumbnail = BoardConfig.Element("thumb").Value;
                New_Board.Tag_Thumbnail = BoardConfig.Element("thumb_tag").Value;
            }

            
            BoardContainer.Boards.Add(New_Board);

        }

        public static void Remove(int id)
        {

        }

        public static void Download(Board b)
        {

        }

    }

    class Board
    {
        public int ID { get; set; }
        public int Thread { get; set; }
        public int ImgCount { get; set; }
        public int ImgDownloaded { get; set; }
        public int Status { get; set; }

        public string Subject { get; set; }
        public string Site { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }

        public Boolean Download_HTML { get; set; }
        public Boolean Download_Images { get; set; }
        public Boolean Download_Thumnails { get; set; }
        public Boolean Download_WebMs { get; set; }
        public Boolean AnimatedFolder { get; set; }
        public Boolean Alerts_Death { get; set; }
        public Boolean Alerts_Download { get; set; }

        // The following are used to drive HTMLAgilityPack parsing

        // XPath and HTML tag for the subject data
        public string XPath_Subject { get; set; }
        public string Tag_Subject { get; set; }

        // XPath and HTML tag for the board name
        public string XPath_Board { get; set; }
        public string Tag_Board { get; set; }

        // XPath and HTML tag for the thread ID
        public string XPath_Thread { get; set; }
        public string Tag_Thread { get; set; }

        // XPath and HTML tag for the thread images
        public string XPath_Image { get; set; }
        public string Tag_Image { get; set; }

        // XPath and HTML tag for the thread thumbnails
        public string XPath_Thumbnail { get; set; }
        public string Tag_Thumbnail { get; set; }


    }

  

}
