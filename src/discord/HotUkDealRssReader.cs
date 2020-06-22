using System.Xml;
using System.Collections.Generic;
using System;
using Parse;
using System.Text.RegularExpressions;
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

        

        public  Hotukdeals Hotukdeal()
        
        {   
            reader.Load(URL);
            // skip through rss and only head over to Item node
            XmlNodeList items =  reader.SelectNodes("rss/channel/item");

            Hotukdeals hotukdeal = new Hotukdeals();

            foreach(XmlNode item in items)
            {
                hotukdeal.addDeal(Parser.parseRssItem(item));
            }


            return hotukdeal;


        }

    }


}