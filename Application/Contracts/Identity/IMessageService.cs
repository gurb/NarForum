using Application.Models;
using Application.Models.Identity.Message;

namespace Application.Contracts.Identity
{
    public interface IMessageService
    {
        Task<ApiResponse> CreateChat(CreateChatRequest request);
        Task<ApiResponse> AddChatList(List<ChatDTO> chats);

        Task<ApiResponse> AddMessageList(List<MessageDTO> messages);

        Task<ApiResponse> ChangeChatStatus(ChangeChatStatusRequest request);
        Task<ApiResponse> AddMessage(AddMessageRequest request);

        Task<GetChatResponse> GetChats(string userId);

        Task<GetMessageResponse> GetMessages(string chatId);
    }
}
