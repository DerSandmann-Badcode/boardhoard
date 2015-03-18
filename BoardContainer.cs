using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using System.Xml;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BoardHoard
{
    class BoardContainer
    {

        public static List<Board> Boards;

        public static void Load()
        {
            if (System.IO.File.Exists("C:\\DEV\\boards.xml") == false)
            {
                MessageBox.Show("Config not found!");
                return;
            }


            XmlDocument Doc = new XmlDocument();
            Doc.Load("C:\\DEV\\NewBoard.xml");

            XmlNodeList Boardlist = Doc.GetElementsByTagName("board");

            foreach (XmlElement XmlBoard in Boardlist)
            {
                Board ImportBoard = new Board();
                ImportBoard.URL = XmlBoard["url"].InnerText;
                ImportBoard.Thread = Convert.ToInt32(XmlBoard["thread"].InnerText);
                ImportBoard.Subject = XmlBoard["subject"].InnerText;
                ImportBoard.Site = XmlBoard["site"].InnerText;
                ImportBoard.Name = XmlBoard["name"].InnerText;
                ImportBoard.ImgDownloaded = Convert.ToInt32(XmlBoard["download_count"].InnerText);
                ImportBoard.ImgCount = Convert.ToInt32(XmlBoard["image_total"].InnerText);
                ImportBoard.Status = Convert.ToInt32(XmlBoard["status"].InnerText);
                ImportBoard.Download_HTML = Convert.ToBoolean(XmlBoard["download_html"].InnerText);
                ImportBoard.Download_Thumnails = Convert.ToBoolean(XmlBoard["download_thumbs"].InnerText);
                ImportBoard.Download_Images = Convert.ToBoolean(XmlBoard["download_images"].InnerText);
                ImportBoard.Download_WebMs = Convert.ToBoolean(XmlBoard["download_webms"].InnerText);
                ImportBoard.AnimatedFolder = Convert.ToBoolean(XmlBoard["animated_separate"].InnerText);
                ImportBoard.Alerts_Death = Convert.ToBoolean(XmlBoard["thread_death_notify"].InnerText);
                ImportBoard.Alerts_Download = Convert.ToBoolean(XmlBoard["thread_download_notify"].InnerText);

                Add(ImportBoard);
            }


        }

        public static void Save()
        {
            // Set indents on for easy reading
            XmlWriterSettings BoardSettings = new XmlWriterSettings();
            BoardSettings.Indent = true;

            // Set path for the XML Board file
            XmlWriter SaveWriter = XmlWriter.Create("C:\\DEV\\Newboard.xml", BoardSettings);

            // Write the start of the XML document
            SaveWriter.WriteStartDocument();

            // Leave a comment so we know what the file is
            SaveWriter.WriteComment("Saved Boards");

            //Start the boards XML section
            SaveWriter.WriteStartElement("boards");

            List<Board> SavedBoards = BoardContainer.Boards;
            foreach (Board savedBoard in SavedBoards)
            {
                // Start each individual board
                SaveWriter.WriteStartElement("board");

                // Write status, include a comment detailing what the status is
                SaveWriter.WriteComment("Status: 0 = Idle, 2 = Stopped, 3 = Dead");
                SaveWriter.WriteStartElement("status");
                if (savedBoard.Status == 1)
                {
                    savedBoard.Status = 0;
                }
                SaveWriter.WriteString(Convert.ToString(savedBoard.Status));
                SaveWriter.WriteEndElement();

                // URL for the board that we saved
                SaveWriter.WriteStartElement("url");
                SaveWriter.WriteString(savedBoard.URL);
                SaveWriter.WriteEndElement();

                // Thread for the board that we saved
                SaveWriter.WriteStartElement("thread");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Thread));
                SaveWriter.WriteEndElement();

                // Subject for the board that we saved
                SaveWriter.WriteStartElement("subject");
                SaveWriter.WriteString(savedBoard.Subject);
                SaveWriter.WriteEndElement();

                // Site for the board that we saved
                SaveWriter.WriteStartElement("site");
                SaveWriter.WriteString(savedBoard.Site);
                SaveWriter.WriteEndElement();

                // Name for the board that we saved
                SaveWriter.WriteStartElement("name");
                SaveWriter.WriteString(savedBoard.Name);
                SaveWriter.WriteEndElement();

                // How many images have we downloaded
                SaveWriter.WriteStartElement("download_count");
                SaveWriter.WriteString(Convert.ToString(savedBoard.ImgDownloaded));
                SaveWriter.WriteEndElement();

                // How many images did the thread have
                SaveWriter.WriteStartElement("image_total");
                SaveWriter.WriteString(Convert.ToString(savedBoard.ImgCount));
                SaveWriter.WriteEndElement();

                // Config for the thread-Mainly booleans
                SaveWriter.WriteComment("Thread config");

                // Boolean to download HTML, True = Download, False = No Download
                SaveWriter.WriteStartElement("download_html");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Download_HTML));
                SaveWriter.WriteEndElement();

                // Boolean to Download Thumbnails, True = Download, False = No Download
                SaveWriter.WriteStartElement("download_thumbs");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Download_Thumnails));
                SaveWriter.WriteEndElement();

                // Boolean to download images, True = Download, False = No Download
                SaveWriter.WriteStartElement("download_images");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Download_Images));
                SaveWriter.WriteEndElement();

                // Boolean to download .webm videos, True = Download, False = No Download
                SaveWriter.WriteStartElement("download_webms");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Download_WebMs));
                SaveWriter.WriteEndElement();

                // Boolean to send .gifs and .Webms to a different folder
                SaveWriter.WriteStartElement("animated_separate");
                SaveWriter.WriteString(Convert.ToString(savedBoard.AnimatedFolder));
                SaveWriter.WriteEndElement();

                // Boolean to notify the user when something gets downloaded
                SaveWriter.WriteStartElement("thread_death_notify");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Alerts_Death));
                SaveWriter.WriteEndElement();

                // Boolean to notify the user when something gets downloaded
                SaveWriter.WriteStartElement("thread_download_notify");
                SaveWriter.WriteString(Convert.ToString(savedBoard.Alerts_Download));
                SaveWriter.WriteEndElement();

                //SaveWriter.WriteStartElement("date_last_download");
                //SaveWriter.WriteString(savedBoard.LastDownload);
                //SaveWriter.WriteEndElement();

                // Write the end of the board segment
                SaveWriter.WriteEndElement();
            }

            SaveWriter.WriteEndElement();
            SaveWriter.WriteEndDocument();
            SaveWriter.Close();

        }

        public static void Add(Board b)
        {
            if (b.URL == "")
            {
                MessageBox.Show("Thread string is empty!");
                return;
            }

            List<Board> ExistingBoards = BoardContainer.Boards;
            foreach (Board board in ExistingBoards)
            {
                if (b.URL == board.URL)
                {
                    //MessageBox.Show("Thread already exists!");
                    return;
                }
            }

            //Board New_Board = new Board();
            if (Boards.Count < 1)
            {
                b.ID = 1;
            }
            else
            {
                b.ID = Boards.Max(p => p.ID) + 1;
            }
            //b.URL = b.URL;
            //b.Download_Images = true;

            Uri Board_Uri = new Uri(b.URL);

            if (System.IO.File.Exists("Board_Config.xml") == false)
            {
                MessageBox.Show("Could not find 'Board_Config.xml'!");
                return;
            }

            XElement Doc = XElement.Load("Board_Config.xml");

            string t = Board_Uri.Host;
            var Configs = from ConfigXML in Doc.Elements("site")
                          where (string)ConfigXML.Element("name") == Board_Uri.Host
                          select ConfigXML;

            foreach (XElement BoardConfig in Configs)
            {
                b.XPath_Subject = BoardConfig.Element("subject").Value;

                b.XPath_Thread = BoardConfig.Element("thread").Value;
                b.Tag_Thread = BoardConfig.Element("thread_tag").Value;

                b.XPath_Board = BoardConfig.Element("board").Value;
                b.Tag_Board = BoardConfig.Element("board_tag").Value;

                b.XPath_Image = BoardConfig.Element("image").Value;
                b.Tag_Image = BoardConfig.Element("image_tag").Value;

                b.XPath_Thumbnail = BoardConfig.Element("thumb").Value;
                b.Tag_Thumbnail = BoardConfig.Element("thumb_tag").Value;
            }


            BoardContainer.Boards.Add(b);


        }

        public static void Add_Download(Board b)
        {
            if (b.URL == "")
            {
                MessageBox.Show("Thread string is empty!");
                return;
            }

            List<Board> ExistingBoards = BoardContainer.Boards;
            foreach (Board board in ExistingBoards)
            {
                if (b.URL == board.URL)
                {
                    //MessageBox.Show("Thread already exists!");
                    return;
                }
            }

            //Board New_Board = new Board();
            if (Boards.Count < 1)
            {
                b.ID = 1;
            }
            else
            {
                b.ID = Boards.Max(p => p.ID) + 1;
            }
            //b.ID = BoardContainer.Boards.Count + 1;
            //b.URL = b.URL;

            Uri Board_Uri = new Uri(b.URL);
            XElement Doc = XElement.Load("C:\\DEV\\MyXML.xml");

            string t = Board_Uri.Host;
            var Configs = from ConfigXML in Doc.Elements("site")
                          where (string)ConfigXML.Element("name") == Board_Uri.Host
                          select ConfigXML;

            foreach (XElement BoardConfig in Configs)
            {
                b.XPath_Subject = BoardConfig.Element("subject").Value;

                b.XPath_Thread = BoardConfig.Element("thread").Value;
                b.Tag_Thread = BoardConfig.Element("thread_tag").Value;

                b.XPath_Board = BoardConfig.Element("board").Value;
                b.Tag_Board = BoardConfig.Element("board_tag").Value;

                b.XPath_Image = BoardConfig.Element("image").Value;
                b.Tag_Image = BoardConfig.Element("image_tag").Value;

                b.XPath_Thumbnail = BoardConfig.Element("thumb").Value;
                b.Tag_Thumbnail = BoardConfig.Element("thumb_tag").Value;
            }


            BoardContainer.Boards.Add(b);
            BoardContainer.Save();
            Download_Single(b);
        }

        public static void Remove(int id)
        {

        }

        static void Download_Single(Board b)
        {
            Thread DownloadThread = new Thread(new ThreadStart(b.Download));
            DownloadThread.IsBackground = true;
            DownloadThread.Start();
        }
        
        static void Download_All()
        {
            List<Board> DownloadingBoards = BoardContainer.Boards;
            foreach (Board b in DownloadingBoards)
            {
                
                Thread DownloadThread = new Thread(new ThreadStart(b.Download));
                DownloadThread.IsBackground = true;
                DownloadThread.Start();

            }
        }

        public static void DownloadThread()
        {
            do
            {
                Download_All();
                Thread.Sleep(UserConfig.Refresh_Delay);
            } while (true);

        }

    }
}
