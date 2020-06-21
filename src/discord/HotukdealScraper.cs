
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

        var page =  web.Load(hotukdealUrl);


        var deals = page.DocumentNode.SelectNodes("//*[@class='threadGrid']");


        foreach(var deal in deals)
        {      // check if the title is not null otherwise skip it
            if(deal.SelectSingleNode(".//a[@class ='cept-tt thread-link linkPlain thread-title--list' ]") != null){
                var titleNode  =  deal.SelectSingleNode(".//a[@class ='cept-tt thread-link linkPlain thread-title--list' ]");
                var title = HttpUtility.HtmlDecode(titleNode.InnerText);

                var link = titleNode.Attributes["href"].Value;
                
                // by pass the lazy load images
                var imageLink = $"https://images.hotukdeals.com/threads/thread_large/default/{Parser.forumNumber(link)}_1.jpg";

                Console.WriteLine(imageLink);

                
            }
    
        }
        



    }





}




















}