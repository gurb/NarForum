using AutoMapper;
using BlazorUI.Contracts;
using BlazorUI.Models;
using BlazorUI.Models.Message;
using BlazorUI.Services.Base;
using BlazorUI.Services.Common;

namespace BlazorUI.Services
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
    }
}
