using System;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace BoardHoard
{

    public class Board
    {
        public int ID;
        public int Thread_ID;
        public int FileCount;
        public int DownloadedCount;
        public int Status; // 0 = Idle, 1 = Running, 2 = Stopped, 3 = Dead, 4 = Stopping(Paused)
        public int Refresh_Delay = 120000;

        public string Subject;
        public string Site;
        public string URL;
        public string Name;
        public string DownloadPath;

        public bool Download_HTML = false;
        public bool Download_Images = false;
        public bool Download_Thumnails = false;
        public bool Download_WebMs = false;
        public bool AnimatedFolder = false;
        public bool Alerts_Death = false;
        public bool Alerts_Download = false;
        public bool ConstantRefresh = true;
        public bool Stopping = false;
        public bool VerifyHashes = false;

        public DateTime LastDownload;
        public DateTime DateAdded;

        // The following are used to drive HTMLAgilityPack parsing

        // XPath and HTML tag for the subject data
        public string XPath_Subject;
        //public string Tag_Subject;

        // XPath and HTML tag for the board name
        public string XPath_Board;
        public string Tag_Board;

        // XPath for pukkubg website hashes
        public string XPath_Hash;

        // XPath and HTML tag for the thread ID
        public string XPath_Thread;
        public string Tag_Thread;

        // XPath and HTML tag for the thread images
        public string XPath_Image;
        public string Tag_Image;

        // XPath and HTML tag for the thread thumbnails
        public string XPath_Thumbnail;
        public string Tag_Thumbnail;

        public void DownloadLoop()
        {
            do
            {
                // We're going to sleep in sections
                // if user cancels the thread checking,
                // we want to be able to end this thread
                int SleptTime = 0;
                do
                {
                    SleptTime += 1000;
                    Thread.Sleep(1000);
                    if (this.ConstantRefresh == false)
                    {
                        // If user wanted to stop watching this thread
                        // while thread was resting, we will exit
                        break;
                    }
                    if (this.Status == 4)
                    {
                        return;
                    }

                } while (SleptTime < Refresh_Delay);

                if (this.ConstantRefresh == true)
                {
                    this.Download();
                }
                
            } while (this.Status == 0);

        }

        public void _ThreadRefresh()
        {
            /*
             * This starts the automatic downloading on
             * the specified board. The board will 
             * automatically redownload upon reaching
             * the timer interval.
             */
            this.LastDownload = DateTime.Now;
            Thread RefreshLoopThread = new Thread(new ThreadStart(DownloadLoop));
            RefreshLoopThread.IsBackground = true;
            RefreshLoopThread.Start();
        }

        public void _ThreadDownload()
        {
            Thread DownloadThread = new Thread(new ThreadStart(Download));
            DownloadThread.IsBackground = true;
            DownloadThread.Start();
        }

        public void DeleteDirectory()
        {
            // Delete while downloading
            String DeletedFolder = this.DownloadPath + this.Site + @"\" + this.Name + @"\" + this.Thread_ID;
            if (Directory.Exists(DeletedFolder))
            {
                Directory.Delete(DeletedFolder, true);
            }
        }

        public void Download()
        {

            /*
             * If thread is running, I don't 
             * want to start it again
             */

            if (this.Status == 1)
            {
                return;
            }

            /*
             * Set status to 1
             * Prevents the same board from running
             * on multiple threads. We want to update
             * the last runtime on this thread
             */
            List<BoardObject> DownloadItems = new List<BoardObject>();
            this.Status = 1;
            this.LastDownload = DateTime.Now;
            Uri BoardUri = new Uri(this.URL);

            // Set up a new HtmlDocument
            HtmlAgilityPack.HtmlDocument Document = new HtmlAgilityPack.HtmlDocument();

            /*
             * Webrequest allows setting of proxy settings and Useragents
             * I could add a form to allow users to set proxy
             * settings per board
             */

            HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(this.URL);
            Request.AllowReadStreamBuffering = false;
            Request.UserAgent = "BoardHoard";

            WebResponse Response;
            try
            {
                // Try to get html data
                Response = Request.GetResponse();
                // Fill HTML document with the webpage
                Document.Load(Response.GetResponseStream());
            }
            catch (WebException ex)
            {
                // Check if Board is 404
                if (ex.Status == WebExceptionStatus.ProtocolError & ex.Response != null)
                {
                    // Page not found, thread has 404'd
                    HttpWebResponse Resp = (HttpWebResponse)ex.Response;
                    if (Resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        this.Status = 3;
                        this.ConstantRefresh = false;
                        if (this.Alerts_Death == true)
                        {
                            System.Media.SystemSounds.Exclamation.Play();
                        }
                        return;
                    }
                }
            } // End Catch for Request.GetResponse()

            /*
             * LINQ To get rid of all scripts
             * this speeds the opening of the HTM
             * by ~500%
             */

            Document.DocumentNode.Descendants()
                .Where(n => n.Name == "script")
                .ToList()
                .ForEach(n => n.Remove());

            // Set up html nodes to read the html into
            HtmlAgilityPack.HtmlNodeCollection DocNodes;

            // Set the board site
            this.Site = BoardUri.Host;

            // Try to read elements for the board name, if all else fails,
            // we are going to grab it from the board URI
            if (this.XPath_Board == null || this.XPath_Board == "")
            {
                this.Name = BoardUri.LocalPath.Split(Convert.ToChar("/"))[1];

            }
            else
            {
                // Read board XPaths
                DocNodes = Document.DocumentNode.SelectNodes(this.XPath_Board);
                if (DocNodes != null)
                {
                    foreach (HtmlAgilityPack.HtmlNode Node in DocNodes)
                    {
                        this.Name = Node.GetAttributeValue(this.Tag_Board, "");
                    }
                }

            }

            // Try to read the subject - This can be blank, but it's nice to have
            DocNodes = Document.DocumentNode.SelectNodes(this.XPath_Subject);
            if (DocNodes != null)
            {
                this.Subject = DocNodes[0].InnerText;
            }

            // Try to read the thread ID - We will use REGEX to convert it
            // to an int regardless of what is in the string.
            DocNodes = Document.DocumentNode.SelectNodes(this.XPath_Thread);
            if (DocNodes != null)
            {
                this.Thread_ID = Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(DocNodes[0].GetAttributeValue(this.Tag_Thread, ""), "\\D", ""));

            }

            // Set up directories for our program to download into
            String DownloadFolder = this.DownloadPath + this.Site + @"\" + this.Name + @"\" + this.Thread_ID + @"\";
            Directory.CreateDirectory(DownloadFolder);

            // Set up folder for HTML
            if (this.Download_HTML == true)
            {
                Directory.CreateDirectory(DownloadFolder + @"Site_Data\");
            }

            // Set up folder for thumbnails
            if (this.Download_Thumnails == true)
            {
                Directory.CreateDirectory(DownloadFolder + @"Thumbnails\");
            }

            // Set up folder for animated downloads
            if (this.AnimatedFolder == true)
            {
                Directory.CreateDirectory(DownloadFolder + @"Animated\");
            }

            // Download CSS files to go with our HTML
            var sources = Document.DocumentNode.Descendants("link");
            foreach (HtmlAgilityPack.HtmlNode CSS_File in sources)
            {
                // Get all of the href elements that contain .css
                if (CSS_File.Attributes["href"].Value.Contains(".css"))
                {

                    BoardObject BoardItem = new BoardObject();
                    BoardItem.AddCount = false;
                    BoardItem.Directory = DownloadFolder + @"Site_Data\";
                    BoardItem.URI = ValidateURI(BoardUri.ToString(), CSS_File.Attributes["href"].Value).ToString();
                    BoardItem.Filename = Path.GetFileName(BoardItem.URI.ToString());

                    if (this.Download_HTML == true)
                    {
                        DownloadItems.Add(BoardItem);
                    }
                    // Rename the CSS file paths if we download the HTML
                    CSS_File.Attributes["href"].Value = BoardItem.Directory + BoardItem.Filename;
                }
            } // CSS File End Each

            // Get list of nodes containing thumbnails
            DocNodes = Document.DocumentNode.SelectNodes(this.XPath_Thumbnail);
            if (DocNodes != null)
            {
                foreach (HtmlAgilityPack.HtmlNode Node in DocNodes)
                {

                    string Thumbnail = Node.GetAttributeValue(this.Tag_Thumbnail, "");
                    if (Thumbnail == string.Empty)
                    {
                        continue;
                    }

                    BoardObject BoardItem = new BoardObject();
                    BoardItem.AddCount = false;
                    BoardItem.Directory = DownloadFolder + @"Thumbnails\";
                    BoardItem.URI = ValidateURI(BoardUri.ToString(), Thumbnail).ToString();
                    BoardItem.Filename = Path.GetFileName(BoardItem.URI.ToString());

                    if (this.Download_Thumnails == true)
                    {
                        DownloadItems.Add(BoardItem);
                    }

                    // Save the location for the thumbnails,
                    // regardless of if we download them 
                    // Rename thumbnail file paths
                    Node.Attributes[this.Tag_Thumbnail].Value = BoardItem.Directory + BoardItem.Filename;
                } // Thumbnails End Each
            }

            // Get list of elements containing Images
            DocNodes = Document.DocumentNode.SelectNodes(this.XPath_Image);

            if (DocNodes != null)
            {
                this.FileCount = DocNodes.Count;
                foreach (HtmlAgilityPack.HtmlNode Node in DocNodes)
                {
                    // If the XPath matches and the Tag
                    // matches, we want to download this
                    // image
                    string Image = Node.GetAttributeValue(this.Tag_Image, "");
                    if (Image == string.Empty)
                    {
                        continue;
                    }

                    BoardObject BoardItem = new BoardObject();
                    BoardItem.Directory = DownloadFolder;
                    BoardItem.URI = ValidateURI(BoardUri.ToString(), Image).ToString();
                    BoardItem.Filename = Path.GetFileName(BoardItem.URI.ToString());

                    // Couldn't think of a better way of doing this
                    // We're going to use a boolean to determine what
                    // type of file we are looking at
                    switch (System.IO.Path.GetExtension(Image))
                    {

                        case ".jpg":
                        case ".png":
                        case ".bmp":
                            if (this.Download_Images == true)
                            {
                                DownloadItems.Add(BoardItem);
                            }
                            break;
                        case ".gif":
                        case ".webm":
                        case ".swf":
                            if (this.AnimatedFolder == true)
                            {
                                BoardItem.Directory = DownloadFolder + @"Animated\";
                            }
                            if (this.Download_WebMs == true)
                            {
                                DownloadItems.Add(BoardItem);
                            }
                            break;
                    }

                    // If file was in our types of file to download
                    // rename images for the HTML
                    Node.Attributes[this.Tag_Image].Value = BoardItem.Directory + BoardItem.Filename;

                } //end Image foreach loop
            }


            if (this.Download_HTML == true)
            {
                // If the user wants to download the HTML for the thread
                // we have already changed all of the links to be local
                // links
                Document.Save(DownloadFolder + this.Thread_ID + ".html");
            }

            foreach (BoardObject DownloadItem in DownloadItems)
            {
                if (this.Stopping == true)
                {
                    this.Status = 4;
                    return;
                }

                if (File.Exists(DownloadItem.Directory + DownloadItem.Filename) == false)
                {
                    UrlDownload(DownloadItem.URI, DownloadItem.Directory + DownloadItem.Filename);
                    if (DownloadItem.AddCount == true)
                    {
                        this.DownloadedCount += 1;
                    }
                }
            }

            // Thread is complete. Return to idle
            this.Status = 0;

        }

        public Uri ValidateURI(string PageURL, string ElementURI)
        {
            /*
             * can convert file:// and relative URLs to their usable
             * counterparts 
             */
            Uri baseUri = new Uri(URL, UriKind.Absolute);
            Uri page = new Uri(baseUri, ElementURI);
            return page;
        }

        public void UrlDownload(string address, string filename)
        {
            /*
             * Just a wrapper for the webclient that includes
             * some error checking
             */
            using (WebClient Client = new WebClient())
            {
                try
                {
                    
                    Client.DownloadFile(address, filename);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + " " + address + " " + filename);
                }
            }
        }

        public bool StreamDownload(string url, string filename)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
            /*&&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase)*/
            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.   
            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect))
            {
                
                // if the remote file was found, download it
                using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(filename))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }
                return true;
            }
            else
                return false;
        }

        public string GetCleanFileName(string filepath)
        {
            /*
             * This removes all of the Linux\Unix characters from our
             * Windows filenames
             */
            return Path.GetInvalidFileNameChars().Aggregate(Path.GetFileName(filepath), (current, c) => current.Replace(c.ToString(), string.Empty));
        
        }

        private void _ThreadStop()
        {
            this.Stopping = true;

            do
            {
                Thread.Sleep(100);
            } while (this.Status == 1);

            this.Status = 2;
        }

        private void _ThreadDelete()
        {
            this.Stopping = true;

            do
            {
                Thread.Sleep(100);
            } while (this.Status == 2);

            this.DeleteDirectory();

        }

        public static Boolean VerifyHash(string hash, string filepath)
        {
            // Returns true if the hashes match
            using (var md5 = MD5.Create())
            {
                string filehash = Convert.ToBase64String(md5.ComputeHash(File.ReadAllBytes(filepath)));
                if (filehash == hash)
                {
                    Debug.WriteLine("Hash is true [" + filepath + "]");
                    return true;
                    
                }
                Debug.WriteLine("Hash is false [" + filepath + "]");
                return false;
            }
        }

        public void Stop()
        {
            Thread StopThread = new Thread(new ThreadStart(_ThreadStop));
            StopThread.IsBackground = true;
            StopThread.Start();
        }

        public void Stop_Delete()
        {
            Thread DeleteThread = new Thread(new ThreadStart(_ThreadDelete));
            DeleteThread.IsBackground = true;
            DeleteThread.Start();

        }

    }

    public class BoardObject
    {
        public string Directory;
        public string Filename;
        public string URI;
        public bool AddCount = true;
    }
}
