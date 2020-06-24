using System;
using System.Threading.Tasks;
using System.Xml;
using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using Hotukdeal;
using System.Timers;


namespace discord
{   

    class Program
    {

        private DiscordSocketClient _client;
        private string TOKEN
        {
            get
            {

                //string token = Environment.GetEnvironmentVariable("csharptoken");
                string token = Environment.GetEnvironmentVariable("hotukdealToken");
               
                if (String.IsNullOrEmpty(token))
                {
                    throw new ArgumentNullException("Token Key not found on environment");
                }


                return token;
            }
        }
        private const ulong channelID = 724405572400840794;
        private const ulong rssChannelID = 653309444934860840;
        private const ulong steamChannelID = 657687492228546573;

        private HotukdealScraper steamHotukdeal = new HotukdealScraper("https://www.hotukdeals.com/tag/steam-hot");
         private  HotUkDealRssReader hotUkDealRssReader = new HotUkDealRssReader();
            
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {

            _client = new DiscordSocketClient();


            _client.Log += Log;
            _client.MessageReceived += MessageReceived;
            _client.Ready += OnReady;



            await _client.LoginAsync(TokenType.Bot, TOKEN);
            await _client.StartAsync();




            // Block this task until the program is closed.
            await Task.Delay(-1);


        }


        private async Task OnReady()
        {   
           
           
           

           
            Timer  timer =  new Timer(1800000);
           // timer.Elapsed += (sender, e) => initiateHotUkDeal(sender, e, channelID,hotukdeal);
            timer.Elapsed += initiateHotUkDeal;
            //timer.AutoReset = false;
            timer.Start();


        }

        
        private async void initiateHotUkDeal(Object source , ElapsedEventArgs e){

            await processHotUkDeal(steamChannelID, steamHotukdeal.Hotukdeal());
            await processHotUkDeal(rssChannelID, hotUkDealRssReader.Hotukdeal());


        }

        private async Task processHotUkDeal(ulong channelID, Hotukdeals hotukdeal)
        {
            
            System.Console.WriteLine("loop");


            var channel = (SocketTextChannel)_client.GetChannel(channelID);
            var messages = (IReadOnlyCollection<IMessage>)await channel.GetMessagesAsync(100).FlattenAsync();
          // await channel.DeleteMessagesAsync(messages);



            if (messages.Count != 0)
            {

              Hotukdeals dealsNotPosted =  filterExpiredDeal(messages, hotukdeal);
              await PostDeals(dealsNotPosted, channel);
            }

            else
            {
                
               await PostDeals(hotukdeal, channel);

            }




        }



        private Hotukdeals filterExpiredDeal(IReadOnlyCollection<IMessage> messages,Hotukdeals hotukdeals)
        {   
        

            bool dealExist = false;
            // check all messages sent in the channel
            foreach(var message in messages)
            {       // all messages were sent as embeds before, only need to check titles
                foreach(var embed in message.Embeds)
                {
                    var title = embed.Title;
                    // check the altest deals scraped and comapre
                   foreach(var deal in hotukdeals.deals)
                   {

                       //System.Console.WriteLine(title);

                       var name = deal.Name;
                        // if the deal exist, just ignore it and break out loop
                       if(title.Equals(name))
                       {
                           dealExist =  true;
                           hotukdeals.removeDeal(deal);
                           break;

                       }
                       else{
                           dealExist = false;
                       }

                   }
                    // if it no longer exist on the hotukdeal, means the deal expired so free to delete message
                   if(!dealExist)
                   {   
                       // delete the message as it's not needed
                       message.DeleteAsync();
                   }


                }

            }
            // return all the deals that were not posted
            return hotukdeals;


        }




        private async Task PostDeals(Hotukdeals hotukdeals, SocketTextChannel channel)
        {



            foreach (Deal deal in hotukdeals.deals)

            {



                var embed = new EmbedBuilder()
                {
                    Title = deal.Name,
                    Url = deal.DirectLink,
                    Description = $"{deal.Description}...[Read More]({deal.Link})",
                    Color = Color.Green,
                    ThumbnailUrl = deal.ImageLink,
                    Footer = new EmbedFooterBuilder()
                    .WithText($"{deal.MadeHot} - {deal.MerchantName}")
                    .WithIconUrl(deal.CategoryImage),



                };

                embed.AddField("Price", deal.Price, true);


                try{
                embed.AddField("Hot Meter", deal.HotMeter, true);
                embed.AddField("Comments", deal.Comments, true);
    
                }
                catch(ArgumentException secondaryInfo){
                    embed.AddField("Category ", deal.Category, true);
                     embed.AddField("Merchant", deal.MerchantName, true);
                    embed.Footer =  new EmbedFooterBuilder()
                    .WithText($"{deal.PostedDate}");

                   // Console.WriteLine(nameof(secondaryInfo) + " doesnt exist");

                    
                }


                await Task.Delay(2000);


                await channel.SendMessageAsync(embed: embed.Build());

            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage message)
        {



            if (!message.Author.IsBot)
            {








            }


        }
    }
}
