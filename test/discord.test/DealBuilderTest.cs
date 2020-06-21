using Xunit;
using Hotukdeal;


namespace discord.Test
{



    public class DealBuilderTest
    {
        [Fact]
        public void TestName()
        {
        //Given
        Deal deal = new DealBuilder()
        .Name("TEST")
        .Build();
        
        //When

        Assert.Equal("TEST", deal.Name);
        //Then
        }

    }






}