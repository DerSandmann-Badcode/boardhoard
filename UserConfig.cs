using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace BoardHoard
{
    class UserConfig
    {
        public static int Refresh_Delay = 120000;

        public static string FolderLocation = Directory.GetCurrentDirectory() + "//Downloaded_Boards//";

        public static void Save()
        {
            // Set indents on for easy reading
            XmlWriterSettings ConfigSettings = new XmlWriterSettings();
            ConfigSettings.Indent = true;

            // Set path for the XML Board file
            XmlWriter ConfigWriter = XmlWriter.Create("config.xml", ConfigSettings);

            // Write the start of the XML document
            ConfigWriter.WriteStartDocument();

            // Leave a comment so we know what the file is
            ConfigWriter.WriteComment("UserConfig");

            ConfigWriter.WriteStartElement("config");

            //Start the boards XML section
            ConfigWriter.WriteStartElement("download_location");
            ConfigWriter.WriteString(FolderLocation);
            ConfigWriter.WriteEndElement();

            ConfigWriter.WriteStartElement("refresh_delay");
            ConfigWriter.WriteString(Convert.ToString(Refresh_Delay));
            ConfigWriter.WriteEndElement();

            ConfigWriter.WriteEndElement();
            ConfigWriter.WriteEndDocument();
            ConfigWriter.Close();
        }

        public static void Load()
        {
            if (System.IO.File.Exists("config.xml") == false)
            {
                //MessageBox.Show("Config not found!");
                return;
            }


            XmlDocument Doc = new XmlDocument();
            Doc.Load("config.xml");
            
            XmlNodeList Configs = Doc.GetElementsByTagName("config");

            foreach (XmlElement Config in Configs)
            {
                FolderLocation = Config["download_location"].InnerText;
                Refresh_Delay = Convert.ToInt32(Config["refresh_delay"].InnerText);
            }

        }


    }
}
