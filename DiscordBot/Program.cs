using System;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Discord.Audio;


namespace DiscordBot
{
	class Program
	{
		public static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();
	

		private DiscordSocketClient _socketClient;
		private CommandService _commandService;
		private IServiceProvider _serviceProvider;


		public async Task RunBotAsync()
		{
			_socketClient = new DiscordSocketClient();
			_commandService = new CommandService();


			//Dependency Injection
			_serviceProvider = new ServiceCollection()
				.AddSingleton(_socketClient)
				.AddSingleton(_commandService)
				.BuildServiceProvider();
			
			


			string token = "OTA1MjY1MzY1NDU2NjU4NDQz.YYHkEg.MshFWVIq6TaFq_IBpjPGczYW8Pg";

			_socketClient.Log += _socketClient_Log;
			

			await RegisterCommandsAsync();

			await _socketClient.LoginAsync(TokenType.Bot, token);

			await _socketClient.StartAsync();

			await Task.Delay(-1);
		}

		private Task _socketClient_Log(LogMessage arg)
		{
			Console.WriteLine(arg);
			return Task.CompletedTask;
		}

		public async Task RegisterCommandsAsync()
		{
			_socketClient.MessageReceived += HandleCommandAsync;
			await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(), _serviceProvider);
		}
		




		private async Task HandleCommandAsync(SocketMessage arg)
		{
			var message = arg as SocketUserMessage;
			var context = new SocketCommandContext(_socketClient, message);
			if (message.Author.IsBot) 
				return;

			int argPos = 0;
			if (message.HasStringPrefix("!",ref argPos ))
			{
				var result = await _commandService.ExecuteAsync(context, argPos, _serviceProvider);
				if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
			}
		}
	}
}
