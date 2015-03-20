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
        public bool ConstantRefresh = true;

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

        public void Add_Download(Board b)
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

                    break;
                }
            }


            this.Boards.Add(b);
            this.Save();
            Download_Single(b);

        }

        public void Download_Single(Board b)
        {
            Thread DownloadThread = new Thread(() => Download(b, this.FolderLocation));
            DownloadThread.IsBackground = true;
            DownloadThread.Start();
        }
        
        public void Download_All()
        {
           
            List<Board> DownloadingBoards = this.Boards;
            foreach (Board b in DownloadingBoards)
            {
                Thread DownloadThread = new Thread(() => Download(b, this.FolderLocation));
                DownloadThread.IsBackground = true;
                DownloadThread.Start();
            }
        }

        public void DownloadThread()
        {
            do
            {
                this.Download_All();
                Thread.Sleep(this.Refresh_Delay);
            } while (true);

        }

        public void Download(Board b, string location)
        {
            location = this.FolderLocation;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            
            if (b.Status == 0)
            {
                b.Status = 1;

                Uri BoardUri = new Uri(b.URL);
                HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(b.URL);
                Request.AllowReadStreamBuffering = false;
                Request.UserAgent = "BoardHoard";

                //try
               // {
                    WebResponse Response = Request.GetResponse();
                    HtmlAgilityPack.HtmlDocument Document = new HtmlAgilityPack.HtmlDocument();

                    Document.Load(Response.GetResponseStream());

                    HtmlAgilityPack.HtmlNodeCollection DocNodes;

                    b.Site = BoardUri.Host;

                    if (b.XPath_Board == null || b.XPath_Board == "")
                    {
                        b.Name = BoardUri.LocalPath.Split(Convert.ToChar("/"))[1];

                    }
                    else
                    {
                        DocNodes = Document.DocumentNode.SelectNodes(b.XPath_Board);

                        foreach (HtmlAgilityPack.HtmlNode Node in DocNodes)
                        {
                            b.Name = Node.GetAttributeValue(b.Tag_Board, "");
                        }
                    }

                    DocNodes = Document.DocumentNode.SelectNodes(b.XPath_Subject);
                    if (DocNodes != null)
                    {
                        b.Subject = DocNodes[0].InnerText;
                    }

                    DocNodes = Document.DocumentNode.SelectNodes(b.XPath_Thread);
                    if (DocNodes != null)
                    {
                        b.Thread = Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(DocNodes[0].GetAttributeValue(b.Tag_Thread, ""), "\\D", ""));

                    }

                    string Folder = location;

                    string DownloadPath = Folder + b.Site + "\\" + b.Name + "\\" + b.Thread + "\\";

                    System.IO.Directory.CreateDirectory(Folder);
                    System.IO.Directory.CreateDirectory(Folder + b.Site);
                    System.IO.Directory.CreateDirectory(Folder + b.Site + "\\" + b.Name);
                    System.IO.Directory.CreateDirectory(DownloadPath);

                    if (b.Download_HTML == true)
                    {
                        var sources = Document.DocumentNode.Descendants("link");
                        System.IO.Directory.CreateDirectory(DownloadPath + @"Site_Data\");

                        foreach (HtmlAgilityPack.HtmlNode CSS_File in sources)
                        {
                            if (CSS_File.Attributes["href"].Value.Contains(".css"))
                            {
                                string testcss = "Http:" + CSS_File.Attributes["href"].Value;
                                string newfile = DownloadPath + "Site_Data\\" + System.IO.Path.GetFileName(testcss);

                                using (WebClient Client = new WebClient())
                                {
                                    try
                                    {
                                        Client.DownloadFile(testcss, newfile);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                CSS_File.Attributes["href"].Value = newfile;
                            }
                        }
                        
                    }

                    if (b.Download_Thumnails == true)
                    {
                        System.IO.Directory.CreateDirectory(DownloadPath + @"Thumbnails\");

                        DocNodes = Document.DocumentNode.SelectNodes(b.XPath_Thumbnail);
                        foreach (HtmlAgilityPack.HtmlNode Node in DocNodes)
                        {
                            string Thumbnail = Node.GetAttributeValue(b.Tag_Thumbnail, "");
                            if (Thumbnail == string.Empty || System.IO.File.Exists(DownloadPath + System.IO.Path.GetFileName(Thumbnail)) == true)
                            {
                                continue;
                            }

                            using (WebClient Client = new WebClient())
                            {
                                try
                                {
                                    Uri UriThumbnail = new Uri(Thumbnail);
                                    if (UriThumbnail.Scheme == "file")
                                    {
                                        Thumbnail = BoardUri.Scheme + ":" + Thumbnail;
                                    }

                                    Client.DownloadFile(Thumbnail, DownloadPath + @"Thumbnails\" + System.IO.Path.GetFileName(Thumbnail));

                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine(ex.Message);
                                }
                            } // stop using webclient

                        } //end foreach loop

                    } // end checking if we want to download thumbnails

                    
                        DocNodes = Document.DocumentNode.SelectNodes(b.XPath_Image);
                        b.ImgCount = DocNodes.Count;
                        foreach (HtmlAgilityPack.HtmlNode Node in DocNodes)
                        {
                            string Image = Node.GetAttributeValue(b.Tag_Image, "");
                            if (Image == string.Empty || System.IO.File.Exists(DownloadPath + System.IO.Path.GetFileName(Image)) == true)
                            {
                                continue;
                            }

                            using (WebClient Client = new WebClient())
                            {
                                try
                                {
                                    Uri UriThumbnail = new Uri(Image);
                                    if (UriThumbnail.Scheme == "file")
                                    {
                                        Image = BoardUri.Scheme + ":" + Image;
                                    }

                                    if (b.Download_Images == true)
                                    {
                                        Client.DownloadFile(Image, DownloadPath + System.IO.Path.GetFileName(Image));
                                        b.ImgDownloaded += 1;
                                    }
                                    

                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine(ex.Message);
                                    Debug.WriteLine(Image);
                                }
                            } // stop using webclient

                        } //end foreach loop

                    if (b.Download_HTML == true)
                    {
                        Document.Save(DownloadPath + b.Thread + ".html");
                    }

                     // end checking if we want to download images

                //}
                    /*
                catch (WebException ex)
                {

                    if (ex.Status == WebExceptionStatus.ProtocolError & ex.Response != null)
                    {
                        HttpWebResponse Resp = (HttpWebResponse)ex.Response;
                        if (Resp.StatusCode == HttpStatusCode.NotFound)
                        {
                            b.Status = 3;
                        }
                    }
                    Debug.WriteLine(ex.Message);
                }*/

                b.Status = 0;
            } // end status check if running

            
            watch.Stop();
            Debug.Print("Download took " + watch.Elapsed.TotalMilliseconds.ToString());
        }
        
        public void Open_Folder(string site, string board, string thread)
        {
            Process.Start("explorer.exe", this.FolderLocation + site + @"\" + board + @"\" + thread + @"\");
        }
    }

}
