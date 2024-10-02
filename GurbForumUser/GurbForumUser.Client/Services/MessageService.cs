using AutoMapper;
using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Models;
using GurbForumUser.Client.Models.Message;
using GurbForumUser.Client.Services.Base;
using GurbForumUser.Client.Services.Common;

namespace GurbForumUser.Client.Services
{
    public class MessageService : BaseHttpService, IMessageService
    {
        private readonly IMapper _mapper;

        public MessageService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> AddMessage(AddMessageRequestVM request)
        {
            var req = _mapper.Map<AddMessageRequest>(request);
            var response = await _client.AddMessageAsync(req);

            var responseVM = _mapper.Map<ApiResponseVM>(response);

            return responseVM;
        }

        public async Task<ApiResponseVM> ChangeChatStatus(ChangeChatStatusRequestVM request)
        {
            var req = _mapper.Map<ChangeChatStatusRequest>(request);
            var response = await _client.ChangeChatStatusAsync(req);

            var responseVM = _mapper.Map<ApiResponseVM>(response);

            return responseVM;
        }

        public async Task<ApiResponseVM> CreateChat(CreateChatRequestVM request)
        {
            var req = _mapper.Map<CreateChatRequest>(request);
            var response = await _client.CreateChatAsync(req);

            var responseVM = _mapper.Map<ApiResponseVM>(response);

            return responseVM;
        }

        public async Task<GetChatResponseVM> GetChats(string userId)
        {
            var chats = await _client.GetChatsAsync(userId);
            var data = _mapper.Map<GetChatResponseVM>(chats);

            return data;
        }

        public async Task<GetMessageResponseVM> GetMessages(string chatId)
        {

            var messages = await _client.GetMessagesAsync(chatId);
            var data = _mapper.Map<GetMessageResponseVM>(messages);

            return data;
        }

        public async Task<GetMessageResponseVM> GetMessages(string[] chatIds)
        {
            var messages = await _client.GetMessagesByChatIdsAsync(chatIds);
            var data = _mapper.Map<GetMessageResponseVM>(messages);

            return data;
        }
    }
}
