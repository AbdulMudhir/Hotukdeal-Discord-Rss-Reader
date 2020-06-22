
using Hotukdeal;
using Xunit;

namespace discord.Test
{



    public class HotukdealScraperTest
    {   
        HotukdealScraper scraper = new HotukdealScraper("https://www.hotukdeals.com/tag/gaming");

        [Fact]
        public void TotalDealScraped()
        {
        //Given

        Hotukdeals hotukdeals = scraper.Hotukdeal();
        
        //When

        //Then

        Assert.Equal(20, hotukdeals.Total);
        }






    }





}