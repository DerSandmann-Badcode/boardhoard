using System;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.IO;


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

        public DateTime LastDownload;

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

        public void StartRefresh()
        {
            this.LastDownload = DateTime.Now;
            Thread BTestingThread = new Thread(new ThreadStart(DownloadLoop));
            BTestingThread.IsBackground = true;
            BTestingThread.Start();
        }

        public void Download_Single()
        {
            Thread BTestingThread = new Thread(new ThreadStart(Download));
            BTestingThread.IsBackground = true;
            BTestingThread.Start();
        }

        public void DeleteDirectory()
        {
            // Delete while downloading
            String DeletedFolder = this.DownloadPath + this.Site + @"\" + this.Name + @"\" + this.Thread_ID;
            Directory.Delete(DeletedFolder, true);
        }

        public void Download()
        {
            // If thread is running, I don't 
            // want to start it again
            if (this.Status == 1)
            {
                return;
            }

            // Set status to 1
            // Prevents the same board from running
            // on multiple threads, sort of like a
            // session lock, also we want to update
            // the last runtime on this thread

            this.Status = 1;
            this.LastDownload = DateTime.Now;
            Uri BoardUri = new Uri(this.URL);

            // Set up a new HtmlDocument
            HtmlAgilityPack.HtmlDocument Document = new HtmlAgilityPack.HtmlDocument();

            // Webrequest allows setting of proxy settings and Useragents
            // I could add a form to allow users to set proxy
            // settings per board

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
                        if (this.Alerts_Death == true)
                        {
                            System.Media.SystemSounds.Exclamation.Play();
                        }
                        return;
                    }
                }
            } // End Catch for Request.GetResponse()

            // LINQ To get rid of all scripts
            // this speeds the opening of the HTML
            // by ~500%
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

            // Try to rea the thread ID - We will use REGEX to convert it
            // to an int regardless of what is in the string.
            DocNodes = Document.DocumentNode.SelectNodes(this.XPath_Thread);
            if (DocNodes != null)
            {
                this.Thread_ID = Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(DocNodes[0].GetAttributeValue(this.Tag_Thread, ""), "\\D", ""));

            }

            // Set up directories for our program to download into
            String DownloadFolder = this.DownloadPath + this.Site + @"\" + this.Name + @"\" + this.Thread_ID + @"\";
            Directory.CreateDirectory(DownloadFolder);

            // Download CSS files to go with our HTML
            var sources = Document.DocumentNode.Descendants("link");
            foreach (HtmlAgilityPack.HtmlNode CSS_File in sources)
            {
                // Get all of the href elements that contain .css
                if (CSS_File.Attributes["href"].Value.Contains(".css"))
                {
                    // Temporary code until I can think of a way to
                    // fix local or file links

                    Uri NewURI = ValidateURI(BoardUri.ToString(), CSS_File.Attributes["href"].Value);

                    string newfile = DownloadFolder + @"Site_Data\" + GetCleanFileName(NewURI.ToString());

                    if (this.Download_HTML == true)
                    {
                        // Create a folder and download the CSS
                        Directory.CreateDirectory(DownloadFolder + @"Site_Data\");
                        UrlDownload(NewURI.ToString(), newfile);
                    }
                    // Rename the CSS file paths if we download the HTML
                    CSS_File.Attributes["href"].Value = newfile;
                }
            } // CSS File End Each

            // Get list of nodes containing thumbnails
            DocNodes = Document.DocumentNode.SelectNodes(this.XPath_Thumbnail);
            if (DocNodes != null)
            {
                foreach (HtmlAgilityPack.HtmlNode Node in DocNodes)
                {

                    if (this.Stopping == true)
                    {
                        this.Status = 4;
                        return;
                    }

                    string Thumbnail = Node.GetAttributeValue(this.Tag_Thumbnail, "");
                    if (Thumbnail == string.Empty)
                    {
                        continue;
                    }
                    // Save the location for the thumbnails,
                    // regardless of if we download them 
                    string newfile = DownloadFolder + @"Thumbnails\" + Path.GetFileName(Thumbnail);
                    if (this.Download_Thumnails == true)
                    {
                        if (File.Exists(newfile) == false)
                        {
                            // Try to clean up boards using file URI
                            // Needs work, some sites send relative
                            // URIs

                            Uri Thumbnail_URI = ValidateURI(BoardUri.ToString(), Thumbnail);

                            // Create /Thumbnails directory to store the
                            // thumbnails we download
                            Directory.CreateDirectory(DownloadFolder + @"Thumbnails\");
                            UrlDownload(Thumbnail_URI.ToString(), DownloadFolder + @"Thumbnails\" + Path.GetFileName(Thumbnail));
                        }
                    }
                    // Rename thumbnail file paths
                    Node.Attributes[this.Tag_Thumbnail].Value = newfile;
                } // Thumbnails End Each
            }
            


            // Get list of elements containing Images
            DocNodes = Document.DocumentNode.SelectNodes(this.XPath_Image);

            if (DocNodes != null)
            {
                this.FileCount = DocNodes.Count;
                foreach (HtmlAgilityPack.HtmlNode Node in DocNodes)
                {

                    if (this.Stopping == true)
                    {
                        this.Status = 4;
                        return;
                    }

                    // If the XPath matches and the Tag
                    // matches, we want to download this
                    // image
                    string Image = Node.GetAttributeValue(this.Tag_Image, "");
                    if (Image == string.Empty)
                    {
                        continue;
                    }

                    string newfile = DownloadFolder + Path.GetFileName(Image);
                    // Couldn't think of a better way of doing this
                    // We're going to use a boolean to determine what
                    // type of file we are looking at
                    bool Download = false;
                    bool IsAnimated = false;
                    switch (System.IO.Path.GetExtension(Image))
                    {

                        case ".jpg":
                        case ".png":
                        case ".bmp":
                            if (this.Download_Images == true)
                            {
                                Download = true;
                            }
                            break;
                        case ".gif":
                        case ".webm":
                        case ".swf":
                            if (this.Download_WebMs == true)
                            {
                                IsAnimated = true;
                                Download = true;
                            }
                            break;
                    }


                    // Try to clean up boards using file URI
                    // Needs work, some sites send relative
                    // URIs
                    Uri Image_URI = ValidateURI(BoardUri.ToString(), Image);

                    // If file was in our types of file to download
                    if (Download == true)
                    {
                        if (IsAnimated == true)
                        {
                            if (this.AnimatedFolder == true)
                            {
                                // Newfile is what we are using to change the HTML elements
                                newfile = DownloadFolder + @"Animated\" + Path.GetFileName(Image_URI.ToString());

                                if (File.Exists(newfile) == false)
                                {
                                    // If the user requested we create a folder for
                                    // WebMs and Flash, do that now
                                    Directory.CreateDirectory(DownloadFolder + @"Animated\");
                                    UrlDownload(Image_URI.ToString(), DownloadFolder + @"Animated\" + Path.GetFileName(Image_URI.ToString()));
                                    this.DownloadedCount += 1;
                                }
                            }
                            else
                            {
                                if (File.Exists(newfile) == false)
                                {
                                    // Download Board Object, could be an image, webm, flash
                                    UrlDownload(Image_URI.ToString(), DownloadFolder + Path.GetFileName(Image_URI.ToString()));
                                    this.DownloadedCount += 1;
                                }

                            }

                        }
                        else
                        {
                            if (File.Exists(newfile) == false)
                            {
                                // Download Board Object, could be an image, webm, flash
                                UrlDownload(Image_URI.ToString(), DownloadFolder + Path.GetFileName(Image_URI.ToString()));
                                this.DownloadedCount += 1;
                            }
                        }


                    }                        

                    Node.Attributes[this.Tag_Image].Value = newfile;

                } //end Image foreach loop
            }
            

            if (this.Download_HTML == true)
            {
                // If the user wants to download the HTML for the thread
                // we have already changed all of the links to be local
                // links
                Document.Save(DownloadFolder + this.Thread_ID + ".html");
            }

            // Thread is complete. Return to idle
            this.Status = 0;

        }

        public Uri ValidateURI(string PageURL, string ElementURI)
        {
            Uri baseUri = new Uri(URL, UriKind.Absolute);
            Uri page = new Uri(baseUri, ElementURI);
            return page;
        }

        public void UrlDownload(string address, string filename)
        {
            
            using (WebClient Client = new WebClient())
            {
                try
                {
                    
                    Client.DownloadFile(address, filename);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
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
            return Path.GetInvalidFileNameChars().Aggregate(Path.GetFileName(filepath), (current, c) => current.Replace(c.ToString(), string.Empty));
        
        }


        private void ThreadStop()
        {
            this.Stopping = true;

        }

        public void Stop()
        {
            this.Stopping = true;

            do
            {
                Thread.Sleep(100);
            } while (this.Status != 4);

            this.Status = 2;

        }

        private void ThreadStopDelete()
        {
            this.Stopping = true;

            do
            {
                Thread.Sleep(100);
            } while ((this.Status != 4) && (this.Status != 0));

            this.DeleteDirectory();

        }


        public void Stop_Delete()
        {
            Thread ATestingThread = new Thread(new ThreadStart(ThreadStopDelete));
            ATestingThread.IsBackground = true;
            ATestingThread.Start();

        }

    }
}
