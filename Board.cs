using System;
using System.Net;
using System.Collections.Generic;


namespace BoardHoard
{
    class Board
    {
        public int ID;
        public int Thread;
        public int ImgCount;
        public int ImgDownloaded;
        public int Status;

        public string Subject;
        public string Site;
        public string URL;
        public string Name;

        public Boolean Download_HTML = false;
        public Boolean Download_Images = false;
        public Boolean Download_Thumnails = false;
        public Boolean Download_WebMs = false;
        public Boolean AnimatedFolder = false;
        public Boolean Alerts_Death = false;
        public Boolean Alerts_Download = false;

        // The following are used to drive HTMLAgilityPack parsing

        // XPath and HTML tag for the subject data
        public string XPath_Subject;
        //public string Tag_Subject;

        // XPath and HTML tag for the board name
        public string XPath_Board;
        public string Tag_Board;

        // XPath and HTML tag for the thread ID
        public string XPath_Thread;
        public string Tag_Thread;

        // XPath and HTML tag for the thread images
        public string XPath_Image;
        public string Tag_Image;

        // XPath and HTML tag for the thread thumbnails
        public string XPath_Thumbnail;
        public string Tag_Thumbnail;

        public void Download()
        {
            
            if (Status == 0)
            {
                Status = 1;

                Uri BoardUri = new Uri(URL);
                HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(URL);
                Request.AllowReadStreamBuffering = false;
                Request.UserAgent = "BoardHoard";

                try
                {
                    WebResponse Response = Request.GetResponse();
                    HtmlAgilityPack.HtmlDocument Document = new HtmlAgilityPack.HtmlDocument();

                    Document.Load(Response.GetResponseStream());

                    HtmlAgilityPack.HtmlNodeCollection DocNodes;

                    Site = BoardUri.Host;

                    if (XPath_Board == "")
                    {
                        Name = BoardUri.LocalPath.Split(Convert.ToChar("/"))[1];

                    }
                    else
                    {
                        DocNodes = Document.DocumentNode.SelectNodes(XPath_Board);

                        foreach (HtmlAgilityPack.HtmlNode Node in DocNodes)
                        {
                            Name = Node.GetAttributeValue(Tag_Board, "");
                        }
                    }

                    DocNodes = Document.DocumentNode.SelectNodes(XPath_Subject);
                    if (DocNodes != null)
                    {
                        Subject = DocNodes[0].InnerText;
                    }

                    DocNodes = Document.DocumentNode.SelectNodes(XPath_Thread);
                    if (DocNodes != null)
                    {
                        Thread = Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(DocNodes[0].GetAttributeValue(Tag_Thread, ""), "\\D", ""));

                    }

                    string Folder = UserConfig.FolderLocation;

                    string DownloadPath = Folder + Site + "\\" + Name + "\\" + Thread + "\\";

                    System.IO.Directory.CreateDirectory(Folder + Site);
                    System.IO.Directory.CreateDirectory(Folder + Site + "\\" + Name);
                    System.IO.Directory.CreateDirectory(DownloadPath);

                    if (Download_HTML == true)
                    {
                        var sources = Document.DocumentNode.Descendants("link");
                        System.IO.Directory.CreateDirectory(DownloadPath + "Site_Data\\");

                        foreach (HtmlAgilityPack.HtmlNode CSS_File in sources)
                        {
                            if (CSS_File.Attributes["href"].Value.Contains(".css"))
                            {
                                string testcss = "Http:" + CSS_File.Attributes["href"].Value;
                                string newfile = DownloadPath + "Site_Data\\" + System.IO.Path.GetFileName(testcss);

                                using (WebClient Client = new WebClient())
                                {
                                    Client.DownloadFile(testcss, newfile);
                                }

                                CSS_File.Attributes["href"].Value = newfile;
                            }
                        }
                        Document.Save( DownloadPath + Thread + ".html");
                    }

                    if (Download_Thumnails == true)
                    {
                        System.IO.Directory.CreateDirectory(DownloadPath + "Thumbnails\\");

                        DocNodes = Document.DocumentNode.SelectNodes(XPath_Thumbnail);
                        foreach (HtmlAgilityPack.HtmlNode Node in DocNodes)
                        {
                            string Thumbnail = Node.GetAttributeValue(Tag_Thumbnail, "");
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

                                    Client.DownloadFile(Thumbnail, DownloadPath + "Thumbnails\\" + System.IO.Path.GetFileName(Thumbnail));

                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.Message);
                                }
                            } // stop using webclient

                        } //end foreach loop

                    } // end checking if we want to download thumbnails

                    if (Download_Images == true)
                    {
                        DocNodes = Document.DocumentNode.SelectNodes(XPath_Image);
                        ImgCount = DocNodes.Count;
                        foreach (HtmlAgilityPack.HtmlNode Node in DocNodes)
                        {
                            string Image = Node.GetAttributeValue(Tag_Image, "");
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

                                    Client.DownloadFile(Image, DownloadPath + System.IO.Path.GetFileName(Image));
                                    ImgDownloaded += 1;

                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.Message);
                                }
                            } // stop using webclient

                        } //end foreach loop

                    } // end checking if we want to download images

                }

                catch (WebException ex)
                {

                    if (ex.Status == WebExceptionStatus.ProtocolError & ex.Response != null)
                    {
                        HttpWebResponse Resp = (HttpWebResponse)ex.Response;
                        if (Resp.StatusCode == HttpStatusCode.NotFound)
                        {
                            Status = 3;
                        }
                    }
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }

                Status = 0;
            } // end status check if running
        }

        public static void Stop(int Board_ID)
        {
            foreach (Board b in BoardContainer.Boards)
            {
                if (b.ID == Board_ID)
                {
                    b.Status = 2;
                }
            }
        }


        public static void Open_Folder(string site, string board, string thread)
        {
            System.Diagnostics.Debug.WriteLine(UserConfig.FolderLocation + site + "\\" + board + "\\" + thread + "\\");
            System.Diagnostics.Debug.WriteLine("C:\\TEST\\" + site + "\\" + board + "\\" + thread + "\\");
           
            System.Diagnostics.Process.Start("explorer.exe", UserConfig.FolderLocation + site + "\\" + board + "\\" + thread + "\\");
        }

    }
}
