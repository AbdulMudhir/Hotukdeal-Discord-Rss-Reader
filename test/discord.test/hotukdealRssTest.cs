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
            
                  Hotukdeals hotukdeals = hotUKDealRss.Hotukdeal();


            int totalDeal =  hotukdeals.Total;

            Assert.Equal(20, totalDeal);

            Deal deal = new DealBuilder()
            .Name("UnitTest")
            .Build();

            hotukdeals.addDeal(deal);

            totalDeal = hotukdeals.Total;
            
            Assert.Equal(21, totalDeal);

        }


     

        [Fact]
        public void RssFeedItem()
        {
            Hotukdeals hotukdeals = hotUKDealRss.Hotukdeal();
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
