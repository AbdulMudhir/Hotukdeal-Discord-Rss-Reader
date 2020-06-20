using System;
using Xunit;
using System.Xml;
using Hotukdeal;
using System.Collections.Generic;

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
            Assert.Equal(20, totalDeal);


            
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

            Assert.Equal("£14.99", deal.Price);

        }


    }
}
