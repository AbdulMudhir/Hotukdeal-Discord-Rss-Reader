using System;
using Xunit;
using System.Xml;
using System.Collections.Generic;

namespace discord.Test
{
    public class HotUKDealRssTest
    {
        const string HOTUKDEALRSSURL = "https://www.hotukdeals.com/rss/all";

        [Fact]
        public void RssFeedCount()
        {
            
        
            // HotUKDeal hotUKDeal = new HotUKDeal();

            // Assert.Equal(20,hotUKDeal.rssNodes.Count);

            
        }

         [Fact]
        public void RssFeedFirstChild()
        {
            
        
           RssReader rssReader = new RssReader(HOTUKDEALRSSURL);

            Dictionary<string, Dictionary<string, string>> content = rssReader.parseRss();



            // check first child title

           
            

        }
    }
}
