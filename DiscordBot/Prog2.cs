//using System;
//using Discord;
//using Discord.WebSocket;
//using Discord.Commands;
//using System.Threading.Tasks;
//using Microsoft.Extensions.DependencyInjection;
//using System.Reflection;

//namespace DiscordBot
//{
//	class Program
//	{
//		public static void Main(string[] args) =>
//			new Program().MainAsync().GetAwaiter().GetResult();

//		private DiscordSocketClient _client;


//		public async Task MainAsync()
//		{
//			_client = new DiscordSocketClient();
//			_client.MessageReceived += CommandHandler;

//			_client.Log += Log;


//			var token = "OTA1MjY1MzY1NDU2NjU4NDQz.YYHkEg.MshFWVIq6TaFq_IBpjPGczYW8Pg";

//			await _client.LoginAsync(TokenType.Bot, token);
//			await _client.StartAsync();


//			await Task.Delay(-1);
//		}

//		private Task Log(LogMessage msg)
//		{
//			Console.WriteLine(msg.ToString());
//			return Task.CompletedTask;
//		}
//		private Task CommandHandler(SocketMessage message)
//		{

//			string command = "";
//			int lengthOfCommand = -1;

//			if (!message.Content.StartsWith('!'))
//				return Task.CompletedTask;

//			if (message.Content.Contains(' '))
//				lengthOfCommand = message.Content.IndexOf(' ');

//			else
//				lengthOfCommand = message.Content.Length;

//			command = message.Content.Substring(1, lengthOfCommand - 1);


//			if (command.Equals("hello"))
//			{
//				message.Channel.SendMessageAsync("Hello " + message.Author.Mention);
//			}
//			if (command.Equals("join"))
//			{
//				message.Channel.GetMessageAsync(1);

//			}


//			return Task.CompletedTask;
//		}


//	}
//}
