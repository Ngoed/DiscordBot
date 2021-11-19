using System;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

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

			_serviceProvider = new ServiceCollection()
				.AddSingleton(_socketClient)
				.AddSingleton(_commandService)
				.BuildServiceProvider();
		}


	}
}
