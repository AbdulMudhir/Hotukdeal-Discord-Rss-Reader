using System.Xml;
using System.Collections.Generic;
using System;
namespace Hotukdeal
{


    public class HotUkDealRssReader
    {

        private XmlDocument reader;

        private const string URL = "https://www.hotukdeals.com/rss/all";
        
        // will be use to retreive an deal object. will be parsing all the deal item ehre
        


        public  HotUkDealRssReader()
        {

            reader = new XmlDocument();
            
        }

        

        private Deal parseRssItem(XmlNode item)
        {   
           
            
                string title = item.SelectSingleNode("title").InnerText;
                string description = item.SelectSingleNode("description").InnerText;
                string link = item.SelectSingleNode("link").InnerText;
                string category = "test";
                string price = "free";
                string imageLink = "test";
                                       
                 Deal deal = new Deal(title, price, category, link, description, imageLink);


            return deal;
            
        }


        public  Hotukdeals hotukdeals()
        
        {   
            reader.Load(URL);
            // skip through rss and only head over to Item node
            XmlNodeList items =  reader.SelectNodes("rss/channel/item");

            Hotukdeals hotukdeal = new Hotukdeals();

            foreach(XmlNode item in items)
            {
                hotukdeal.addDeal(parseRssItem(item));
            }


            return hotukdeal;


        }

    }


}