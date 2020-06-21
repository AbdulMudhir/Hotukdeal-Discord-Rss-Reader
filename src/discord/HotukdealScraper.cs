
using HtmlAgilityPack;
using System.Web;
using System;
using Parse;

namespace Hotukdeal
{


    public class HotukdealScraper
    {



        HtmlWeb web;
        public HotukdealScraper(string hotukdealUrl)
        {

            web = new HtmlWeb();

            var page = web.Load(hotukdealUrl);


            var deals = page.DocumentNode.SelectNodes("//*[@class='threadGrid']");


            foreach (var deal in deals)
            {      // check if the title is not null otherwise skip it
                if (validDeal(deal))
                {

                    if(!expiredDeal(deal))
                    {

                    var titleNode = deal.SelectSingleNode(".//a[@class ='cept-tt thread-link linkPlain thread-title--list' ]");
                    var title = HttpUtility.HtmlDecode(titleNode.InnerText);


                    var link = titleNode.Attributes["href"].Value;

                    // by pass the lazy load images
                    var imageLink = $"https://images.hotukdeals.com/threads/thread_large/default/{Parser.forumNumber(link)}_1.jpg";


                    var price = deal.SelectSingleNode(".//span[@class= 'thread-price text--b vAlign--all-tt cept-tp size--all-l size--fromW3-xl']").InnerText;


                    string description = deal.SelectSingleNode(".//div[@class='cept-description-container overflow--wrap-break width--all-12  size--all-s size--fromW3-m']").InnerText;
                    description = description.Replace("Read more", "");
                    System.Console.WriteLine(description);

                    }


                }


            }




        }


        public Boolean validDeal(HtmlNode deal)
        {
            return deal.SelectSingleNode(".//a[@class ='cept-tt thread-link linkPlain thread-title--list' ]") != null;
        }

        public Boolean expiredDeal(HtmlNode deal)
        {
         

            try
            {
                // if it does not trigger Null reference, it has expired
                   var expiredTag = deal.SelectSingleNode(".//span[@class ='size--all-s text--color-grey space--l-1 space--r-2 cept-show-expired-threads hide--toW3']").InnerText;
                return true;
            }

            catch (NullReferenceException)
            {
                return false;
            }
        }





    }



}