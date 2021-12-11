using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;


namespace DiscordBot.Modules
{
	public class BotCommands : ModuleBase<SocketCommandContext>
	{
		[Command("ping")]
		public async Task Ping()
		{
			await ReplyAsync("hello");
			await ReplyAsync("Hi " + Context.User.Mention);
		}
	}
}
