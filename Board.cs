using System;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;


namespace BoardHoard
{
    public class Board
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

        
        public static void Stop(int Board_ID)
        {
            /*
            foreach (Board b in BoardContainer.Boards)
            {
                if (b.ID == Board_ID)
                {
                    b.Status = 2;
                }
            }*/
        }


    }
}
