using System;
using Xunit;
using System.Xml;
using Hotukdeal;
using System.Collections.Generic;
using Parse;

namespace discord.Test
{
    public class HotUKDealRssTest
    {

         HotUkDealRssReader hotUKDealRss = new HotUkDealRssReader();

      
        [Fact]
        public void RssFeedCount()
        {
            
                  Hotukdeals hotukdeals = hotUKDealRss.hotukdeals();


            int totalDeal =  hotukdeals.Total;

            // should recieve 20 feed from RSS
            //Assert.Equal(20, totalDeal);


            
        }


        [Fact]
        public void getThreadNumber()
        {

            string normalUrl = "https://www.hotukdeals.com/deals/playmobil-70317-back-to-the-futurec-delorean-toy-3490437";
           
            string threadNumber = Parser.getDealForumThreadNumber(normalUrl);

            Assert.Equal("3490437", threadNumber);


        }
        [Fact]
        public void removeHTMLElementfromRSS()
        {
            // should return max 100 character length without h tml tags
            string description = hotUKDealRss.removeHTMLElementFromRSS("<strong>£2,851.38 - Amazon</strong><br />");
            Assert.Equal("£2,851.38 - Amazon",description);
        }

        [Fact]
        public void RssFeedItem()
        {
            Hotukdeals hotukdeals = hotUKDealRss.hotukdeals();
            Deal deal = hotukdeals.deals[0];

            String firstItemName = deal.Name;

            string link = deal.Link;
            // check if the first deal is similar to one to rss
            // Assert.Equal("1,000 free audiobooks @ Open Culture",firstItemName);
            // Assert.Equal("https://www.hotukdeals.com/deals/1000-free-audiobooks-3490202", link);

            // Assert.Equal("£100.64", deal.Price);
            // Assert.Equal("Amazon", deal.MerchantName);
            // Assert.Equal("https://images.hotukdeals.com/threads/thread_list_big/default/3490255_1.jpg", deal.ImageLink);

        }


    }
}
