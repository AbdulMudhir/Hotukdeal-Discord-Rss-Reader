using System;
using Xunit;
using System.Xml;
using Hotukdeal;
using System.Collections.Generic;

namespace discord.Test
{
    public class HotUKDealRssTest
    {

        [Fact]
        public void RssFeedCount()
        {
            
            
            HotUkDealRssReader hotUKDealRss = new HotUkDealRssReader();

            Hotukdeals hotukdeals = hotUKDealRss.hotukdeals();

            int totalDeal =  hotukdeals.Total;

            // should recieve 20 feed from RSS
            Assert.Equal(20, totalDeal);


            
        }


    }
}
