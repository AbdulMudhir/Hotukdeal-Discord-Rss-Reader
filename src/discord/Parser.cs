using System.Text.RegularExpressions;
using System.Xml;
using Hotukdeal;
using System;

namespace Parse
{

    public static class Parser
    {


        
        public static string forumNumber(string url)
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

            return $"https://www.hotukdeals.com/visit/thread/{forumNumber(url)}";
        }


        
        public static Deal parseRssItem(XmlNode item)
        {   
           
            
                string title = item.SelectSingleNode("title").InnerText;
                string description = Parser.removeHTMLElementFromRSS(item.SelectSingleNode("description").InnerText);
                string link = item.SelectSingleNode("link").InnerText;
                string category = item.SelectSingleNode("category").InnerText;
                string directLink = getDirectLink(link);
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
                    merchantName = "None";
                    price = "None";

                    Console.WriteLine($"{nameof(e)} Does not exist ");
                }
            

                string imageLink = item["media:content"].Attributes["url"].Value;
        
                                       
                 Deal deal = new DealBuilder()
                 .Name(title)
                 .Price(price)
                 .Category(category)
                 .Link(link)
                 .Description(description)
                 .ImageLink(imageLink)
                 .MerchantName(merchantName)
                 .DirectLink(directLink)
                 .Build();
                 


            return deal;
            
        }




    }


}