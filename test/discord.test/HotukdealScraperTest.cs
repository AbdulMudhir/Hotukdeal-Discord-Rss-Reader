
using Hotukdeal;
using Xunit;

namespace discord.Test
{



    public class HotukdealScraperTest
    {   
        HotukdealScraper hotUKDeal = new HotukdealScraper("https://www.hotukdeals.com/tag/gaming");

        [Fact]
        public void TotalDealScraped()
        {
        //Given

        Hotukdeals hotukdeals = hotUKDeal.Scrape();
        
        //When

        //Then

        Assert.Equal(19, hotukdeals.Total);
        }






    }





}