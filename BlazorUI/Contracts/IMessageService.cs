using BlazorUI.Models;
using BlazorUI.Models.Message;

namespace BlazorUI.Contracts
{
    public interface IMessageService
    {
        Task<ApiResponseVM> CreateChat(CreateChatRequestVM request);
        Task<ApiResponseVM> ChangeChatStatus(ChangeChatStatusRequestVM request);
        Task<ApiResponseVM> AddMessage(AddMessageRequestVM request);
        Task<GetMessageResponseVM> GetMessages(string chatId);
        Task<GetChatResponseVM> GetChats(string userId);
    }
}
