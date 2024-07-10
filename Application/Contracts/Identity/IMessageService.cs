using Application.Models;
using Application.Models.Identity.Message;

namespace Application.Contracts.Identity
{
    public interface IMessageService
    {
        Task<ApiResponse> AddMessage(AddMessageRequest request);
        Task<GetMessageResponse> GetMessages(string userId);
    }
}
