using System;
using Xunit;
using System.Xml;
using Hotukdeal;
using System.Collections.Generic;
using Parse;

namespace discord.Test
{
    public class ParserTest
    {


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
            string description = Parser.removeHTMLElementFromRSS("<strong>£2,851.38 - Amazon</strong><br />");
            Assert.Equal("£2,851.38 - Amazon",description);
        }




    }
}
