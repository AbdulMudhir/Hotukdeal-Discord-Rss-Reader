using System.Xml;
using System.Collections.Generic;
using System;
namespace Hotukdeal
{


    public class RssReader
    {

        private XmlDocument reader;

        private const string URL = "https://www.hotukdeals.com/rss/all";

        public RssReader()
        {

            reader = new XmlDocument();
            reader.Load(URL);


        }


        public  Hotukdeals parseRss()
        {   // skip through rss and only head over to Item node
            XmlNodeList items =  reader.SelectNodes("rss/channel/item");


            for(int i= 0; i<items.Count; i++)
            {

                string title = items[i].SelectSingleNode("title").InnerText;
                string description = items[i].SelectSingleNode("description").InnerText;
                string link = items[i].SelectSingleNode("link").InnerText;
                string price = "free";

                // store each deal information to seperate dictonary
                Dictionary<string, string> feedInfo = new Dictionary<string, string>();

                feedInfo.Add("description", description);
                feedInfo.Add("link", link);
                feedInfo.Add("price", price);

                // combine both the deal and the information it came with
                feed.TryAdd(title, feedInfo);
            }
        
        return feed;

        }

    }


}