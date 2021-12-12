//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Discord;
//using Discord.Audio;
//using Discord.Commands;
//using Victoria;
//using Victoria.Enums;

//namespace Bot.Modules
//{
//    public sealed class AudioModule : ModuleBase<SocketCommandContext>
//    {
//        private readonly LavaNode _lavaNode;
//        private readonly AudioInStream _audioService;

//        public AudioModule(LavaNode lavaNode, AudioInStream audioService)
//        {
//            _lavaNode = lavaNode;
//            _audioService = audioService;
//        }

//        [Command("Join")]
//        public async Task JoinAsync()
//        {
//            if (_lavaNode.HasPlayer(Context.Guild))
//            {
//                await ReplyAsync("I'm already connected to a voice channel!");
//                return;
//            }

//            var voiceState = Context.User as IVoiceState;
//            if (voiceState?.VoiceChannel == null)
//            {
//                await ReplyAsync("You must be connected to a voice channel!");
//                return;
//            }

//            try
//            {
//                await _lavaNode.JoinAsync(voiceState.VoiceChannel, Context.Channel as ITextChannel);
//                await ReplyAsync($"Joined {voiceState.VoiceChannel.Name}!");
//            }
//            catch (Exception exception)
//            {
//                await ReplyAsync(exception.Message);
//            }
//        }
//    }
//}