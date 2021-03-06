﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace BoardHoard
{
    [XmlRootAttribute("SiteConfig", Namespace = "BoardHoard")]
    public class SiteConfig
    {
        public List<Site> Sites = new List<Site>();

        public static void WriteDefaultConfig()
        {
            SiteConfig DefaultConfig = new SiteConfig();

            Site fourchan = new Site();
            fourchan.name = @"boards.4chan.org";
            fourchan.subject = @"//span[@class = 'subject']";
            fourchan.thread = @"//div[@class = 'thread']";
            fourchan.thread_tag = @"id";
            fourchan.board = @"";
            fourchan.board_tag = @"";
            fourchan.hash_tag = @"data-md5";
            fourchan.image = @"//a[@class='fileThumb']";
            fourchan.image_tag = @"href";
            fourchan.thumb = @"//a[@class = 'fileThumb']//img";
            fourchan.thumb_tag = @"src";
            DefaultConfig.Sites.Add(fourchan);

            Site archivemoe = new Site();
            archivemoe.name = @"archive.moe";
            archivemoe.subject = @"//h2[@class = 'post_title']";
            archivemoe.thread = @"//article[contains(@class, 'clearfix thread')]";
            archivemoe.thread_tag = @"id";
            archivemoe.board = @"";
            archivemoe.board_tag = @"";
            archivemoe.hash_tag = @"";
            archivemoe.image = @"//div[@class='thread_image_box']//a";
            archivemoe.image_tag = @"href";
            archivemoe.thumb = @"//div[@class='thread_image_box']//img";
            archivemoe.thumb_tag = @"src";
            DefaultConfig.Sites.Add(archivemoe);


            Site eightchan = new Site();
            eightchan.name = @"8ch.net";
            eightchan.subject = @"//span[@class = 'subject']";
            eightchan.thread = @"//input[@name = 'thread']";
            eightchan.thread_tag = @"value";
            eightchan.board = @"//input[@name = 'board']";
            eightchan.board_tag = @"value";
            eightchan.hash_tag = @"alt-data-md5";
            eightchan.image = @"//div[@class='file']//a | //div[@class='file multifile']//a";
            eightchan.image_tag = @"href";
            eightchan.thumb = @"//div[@class='file']//img | //div[@class='file multifile']//img";
            eightchan.thumb_tag = @"src";
            DefaultConfig.Sites.Add(eightchan);

            Site eightarchive = new Site();
            eightarchive.name = @"8archive.moe";
            eightarchive.subject = @"//h2[@class = 'post_title']";
            eightarchive.thread = @"//article[contains(@class, 'clearfix thread')]";
            eightarchive.thread_tag = @"id";
            eightarchive.board = @"";
            eightarchive.board_tag = @"";
            eightarchive.hash_tag = @"";
            eightarchive.image = @"//div[@class='thread_image_box']//a";
            eightarchive.image_tag = @"href";
            eightarchive.thumb = @"//div[@class='thread_image_box']//img";
            eightarchive.thumb_tag = @"src";
            DefaultConfig.Sites.Add(eightarchive);

            Site sevenchan = new Site();
            sevenchan.name = @"7chan.org";
            sevenchan.subject = @"//span[@class = 'subject']";
            sevenchan.thread = @"//div[contains(@id, 'thread_')]";
            sevenchan.thread_tag = @"id";
            sevenchan.board = @"//input[@name = 'board']";
            sevenchan.board_tag = @"value";
            sevenchan.hash_tag = @"";
            sevenchan.image = @"//span[contains(@class, 'multithumb')]//a | //div[@class = 'post_thumb']//a";
            sevenchan.image_tag = @"href";
            sevenchan.thumb = @"//img[contains(@class, 'multithumb')]//img | //div[@class = 'post_thumb']//img";
            sevenchan.thumb_tag = @"src";
            DefaultConfig.Sites.Add(sevenchan);

            Site krautchan = new Site();
            krautchan.name = @"krautchan.net";
            krautchan.subject = @"//span[@class = 'postsubject']";
            krautchan.thread = @"//input[@name = 'redirect']";
            krautchan.thread_tag = @"value";
            krautchan.board = @"";
            krautchan.board_tag = @"";
            krautchan.hash_tag = @"";
            krautchan.image = @"//div[@class = 'file_thread']//a[@target= '_blank'] | //div[@class = 'file_reply']//a[@target= '_blank']";
            krautchan.image_tag = @"href";
            krautchan.thumb = @"//div[@class = 'file_thread']//img[contains(@id, 'thumb')] | //div[@class = 'file_reply']//img[contains(@id, 'thumb')]";
            krautchan.thumb_tag = @"src";
            DefaultConfig.Sites.Add(krautchan);

            Site anonib = new Site();
            anonib.name = @"anon-ib.ch";
            anonib.subject = @"//span[@class = 'subject']";
            anonib.thread = @"//a[@class = 'post_anchor']";
            anonib.thread_tag = @"id";
            anonib.board = @"//input[@name = 'board']";
            anonib.board_tag = @"value";
            anonib.hash_tag = @"";
            anonib.image = @"//div[contains(@class, 'file')]//a";
            anonib.image_tag = @"href";
            anonib.thumb = @"//div[contains(@class, 'file')]//img";
            anonib.thumb_tag = @"src";
            DefaultConfig.Sites.Add(anonib);

            Site uncleb = new Site();
            uncleb.name = @"uncleb.net";
            uncleb.subject = @"//span[@class = 'subject']";
            uncleb.thread = @"//a[@class = 'post_anchor']";
            uncleb.thread_tag = @"id";
            uncleb.board = @"//input[@name = 'board']";
            uncleb.board_tag = @"value";
            uncleb.hash_tag = @"";
            uncleb.image = @"//div[@class = 'file']//a";
            uncleb.image_tag = @"href";
            uncleb.thumb = @"//div[@class = 'file']//img";
            uncleb.thumb_tag = @"src";
            DefaultConfig.Sites.Add(uncleb);

            Site gurochan = new Site();
            gurochan.name = @"gurochan.ch";
            gurochan.subject = @"//a[@class = 'thread_subject']";
            gurochan.thread = @"//div[@class = 'thr-cont']";
            gurochan.thread_tag = @"data-tid";
            gurochan.board = @"//input[@name = 'board']";
            gurochan.board_tag = @"value";
            gurochan.hash_tag = @"";
            gurochan.image = @"//td[@class = 'post_image']//a";
            gurochan.image_tag = @"href";
            gurochan.thumb = @"//td[@class = 'post_image']//img";
            gurochan.thumb_tag = @"src";
            DefaultConfig.Sites.Add(gurochan);

            Site fgts = new Site();
            fgts.name = @"fgts.jp";
            fgts.subject = @"//h2[@class = 'post_title']";
            fgts.thread = @"//article[contains(@class, 'clearfix thread')]";
            fgts.thread_tag = @"id";
            fgts.board = @"";
            fgts.board_tag = @"";
            fgts.hash_tag = @"";
            fgts.image = @"//div[@class='thread_image_box']//a";
            fgts.image_tag = @"href";
            fgts.thumb = @"//div[@class='thread_image_box']//img";
            fgts.thumb_tag = @"src";
            DefaultConfig.Sites.Add(fgts);


            XmlSerializer serializer = new XmlSerializer(typeof(SiteConfig));
            using (TextWriter SaveWriter = new StreamWriter("SiteConfig.xml"))
            {
                serializer.Serialize(SaveWriter, DefaultConfig);
            }
        }

        public static SiteConfig Load()
        {
            SiteConfig LoadedSites = new SiteConfig();

            if (File.Exists("SiteConfig.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SiteConfig));

                using (FileStream fs = new FileStream("SiteConfig.xml", FileMode.Open))
                {
                    LoadedSites = (SiteConfig)serializer.Deserialize(fs);
                }
            }

            return LoadedSites;
        }
    }
}
