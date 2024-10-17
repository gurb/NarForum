using Application.Contracts.Hubs;
using Application.Contracts.Identity;
using Application.Models.Identity.Message;
using Identity.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace Identity.Services.Hubs
{
    public class ChatBackgroundService : BackgroundService
    {
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(60);
        private readonly IHubContext<ChatHub, IChatHub> _context;
        private readonly IGarnetCacheService _cache;
        private readonly IServiceProvider _serviceProvider;

        public ChatBackgroundService(IHubContext<ChatHub, IChatHub> context, IGarnetCacheService cache, IServiceProvider serviceProvider)
        {
            _context = context;
            _cache = cache;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(Timeout);

            while (!stoppingToken.IsCancellationRequested &&
                await timer.WaitForNextTickAsync(stoppingToken))
            {
                await SaveMessagesToDatabase();
            }
        }

        private async Task SaveMessagesToDatabase()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _messageService = scope.ServiceProvider.GetRequiredService<IMessageService>();

                // store chat
                Dictionary<string, string>? chatHistory = await _cache.GetAllHashSet("chat-requests");
                Dictionary<string, string>? chatRequestsDb = await _cache.GetAllHashSet("chat-requests-db");

                List<ChatDTO> updateChats = new List<ChatDTO>();
                List<ChatDTO> chats = new List<ChatDTO>();

                if (chatHistory is not null)
                {
                    foreach (var chatElem in chatHistory)
                    {
                        ChatDTO? chatDto = JsonSerializer.Deserialize<ChatDTO>(chatElem.Value);

                        if (chatDto != null)
                        {
                            chatDto.Creator = null;
                            chatDto.Receiver = null;

                            if(chatRequestsDb is not null && chatRequestsDb.Count > 0 && chatRequestsDb.ContainsKey(chatDto.Id))
                            {
                                updateChats.Add(chatDto);
                                continue;
                            }

                            bool isExist = chats.Any(x => x.Id == chatDto.Id);
                            if (!isExist)
                            {
                                chats.Add(chatDto);
                            }
                        }
                    }

                    if (chats.Count > 0)
                    {
                        var response = await _messageService.AddChatList(chats);

                        if (response.IsSuccess)
                        {
                            await _cache.Clear("chat-requests");
                        }
                    }

                    if (updateChats.Count > 0)
                    {
                        var response = await _messageService.UpdateChatList(updateChats);

                        if (response.IsSuccess)
                        {
                            await _cache.Clear("chat-requests-db");
                            await _cache.Clear("chat-requests");
                        }
                    }
                }


                // store message
                Dictionary<string, string>? messageHistory = await _cache.GetAllHashSet("messages");

                List<MessageDTO> messages = new List<MessageDTO>();

                if (messageHistory is not null)
                {
                    foreach (var messageElem in messageHistory)
                    {
                        MessageDTO? messageDto = JsonSerializer.Deserialize<MessageDTO>(messageElem.Value);
                        if (messageDto != null)
                        {
                            messageDto.Owner = null;

                            bool isExist = messages.Any(x => x.Id == messageDto.Id);
                            if (!isExist)
                            {
                                messages.Add(messageDto);
                            }
                        }
                    }

                    if (messages.Count > 0)
                    {
                        var response = await _messageService.AddMessageList(messages);

                        if (response.IsSuccess)
                        {
                            await _cache.Clear("messages");
                        }
                    }
                }
            }
        }

    }
}
