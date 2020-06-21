
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

                    var description = deal.SelectSingleNode(".//div[@class='cept-description-container overflow--wrap-break width--all-12  size--all-s size--fromW3-m']").InnerText;
                    description = description.Replace("Read more", "");

                    
                    var hotMeters = hotMeter(deal);

                    var merchantName = deal.SelectSingleNode(".//span[@class='cept-merchant-name text--b text--color-brandPrimary link']").InnerText;

                    System.Console.WriteLine(merchantName);

                    var directLink = Parser.getDirectLink(link);

                    var commentCounts = commentCount(deal, link);

                    var madeHotDate = deal.SelectSingleNode(".//span[@class ='hide--toW3']").InnerText;

                   


                    }


                }


            }




        }

        
        private string commentCount(HtmlNode deal, string url)
        {   // get the parent comment node then get the inner childs and retreive their value
            var commentNode = deal.SelectSingleNode($".//a[@class  = 'cept-comment-link btn space--h-3 btn--mode-boxSec cept-comment-link-id-{Parser.forumNumber(url)} ']");

            return commentNode.ChildNodes[1].InnerText;;
        }

        private string hotMeter(HtmlNode deal)
        
        {      
            string meter;

            try{
                    meter = deal.SelectSingleNode(".//span[@class='cept-vote-temp vote-temp vote-temp--hot']").InnerText;
                }
                catch(NullReferenceException)
                { 
                    meter = deal.SelectSingleNode(".//span[@class='cept-vote-temp vote-temp vote-temp--burn']").InnerText;

                }

            return meter.Trim();
        }

        private Boolean validDeal(HtmlNode deal)
        {
            return deal.SelectSingleNode(".//a[@class ='cept-tt thread-link linkPlain thread-title--list' ]") != null;
        }

        private Boolean expiredDeal(HtmlNode deal)
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