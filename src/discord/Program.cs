using System;
using System.Threading.Tasks;
using System.Xml;
using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using Hotukdeal;

namespace discord
{    class Program
    {

        
    private DiscordSocketClient _client;
    private string TOKEN{
        get{return Environment.GetEnvironmentVariable("csharptoken");}
    }


        Hotukdeals hotUKDeal;
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            
            _client = new DiscordSocketClient();

            hotUKDeal = new  Hotukdeals();


           

            _client.Log += Log;
            _client.MessageReceived += MessageReceived;

            await _client.LoginAsync(TokenType.Bot,TOKEN);
            await _client.StartAsync();
            
            // Block this task until the program is closed.
            await Task.Delay(-1);
           
        }


        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage message)
        {

          

            if(!message.Author.IsBot){
                
               
            }

            
        }
    }
}
