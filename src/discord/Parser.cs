using System.Text.RegularExpressions;
using System.Xml;
using Hotukdeal;
using System;

namespace Parse
{

    public static class Parser
    {


        
        public static string getDealForumThreadNumber(string url)
        {
            return Regex.Match(url, "\\d+$").Value;

        }
        
        
        public static string removeHTMLElementFromRSS(string description)
        {   
           
            // shortened version
            int limitDescription = 100;
        
            string result = Regex.Replace(description, @"<[^>]*>", " ");


            if(result.Length > limitDescription)
            {
                result =  result.Substring(0, limitDescription);

            }



            return result.Trim();
        }
        

        
        public static string getDirectLink(string url)
        {
             string baseDirectLink = "https://www.hotukdeals.com/visit/thread/";
            

            return "str";
        }


        
        public static Deal parseRssItem(XmlNode item)
        {   
           
            
                string title = item.SelectSingleNode("title").InnerText;
                string description = Parser.removeHTMLElementFromRSS(item.SelectSingleNode("description").InnerText);
                string link = item.SelectSingleNode("link").InnerText;
                string category = item.SelectSingleNode("category").InnerText;

                string merchantName;
                string price;
                // need to fix this as not all return nulls
                try{

                    var merchantInfo = item["pepper:merchant"].Attributes;


                    merchantName = merchantInfo["name"].Value;

                    price = merchantInfo["price"].Value;



                }
                catch(NullReferenceException e)
                {
                    merchantName = "";
                    price = "";

                    Console.WriteLine($"{nameof(e)} Does not exist ");
                }
            

                string imageLink = item["media:content"].Attributes["url"].Value;
        
                                       
                 Deal deal = new Deal(title, price, category, link, description, imageLink, merchantName, "");


            return deal;
            
        }




    }


}