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

                string token = Environment.GetEnvironmentVariable("csharptoken");

                if (String.IsNullOrEmpty(token))
                {
                    throw new ArgumentNullException("Token Key not found on environment");
                }


                return token;
            }
        }

        HotukdealScraper scraper;
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {

            _client = new DiscordSocketClient();


            scraper = new HotukdealScraper("https://www.hotukdeals.com/tag/gaming");


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

            Timer timer = new Timer(3600000);
            timer.Elapsed += PostDeal;
            timer.Enabled = true;


        }


        private void PostDeal(Object source, ElapsedEventArgs e)
        {
            ulong channelId = 724405572400840794;

            var channel = (SocketTextChannel)_client.GetChannel(channelId);


            var deals = new HotukdealScraper("https://www.hotukdeals.com/tag/broadband-phone-service").Hotukdeal().deals;

            foreach (Deal deal in deals)

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
                embed.AddField("Hot Meter", deal.HotMeter, true);
                embed.AddField("Comments", deal.Comments, true);




                channel.SendMessageAsync(embed: embed.Build());
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
