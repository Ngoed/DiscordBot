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
			await ReplyAsync("Hello");
			await ReplyAsync("Hi " + Context.User.Mention);
		}


		[Command("join")]
		public async Task JoinVoice()
		{
			var voicestate = Context.User as IVoiceState;
			if( voicestate?.VoiceChannel == null)
			{
				await ReplyAsync("Connect to a voice channel!");
			}			
		}


		[Command("age")]
		public async Task GetAge()
		{
			await ReplyAsync("Account created on " + Context.User.CreatedAt);
		}


		[Command("channel")]
		public async Task GetChannelName()
		{
			await ReplyAsync("You are in " + Context.Channel.Name);
		}



	}
}
