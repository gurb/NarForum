using Application.Contracts.Identity;
using Application.Models;
using Application.Models.Identity.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {

        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Creates chat request between the creator and the recevier.
        /// </summary>
        /// <param name="request">The request containing title, message, the creator's and the receiver's information</param>
        /// <returns>The creating chat request result</returns>
        [HttpPost("CreateChat")]
        public async Task<ApiResponse> CreateChat(CreateChatRequest request)
        {
            return await _messageService.CreateChat(request);
        }

        /// <summary>
        /// Change chat request status by the receiver.
        /// </summary>
        /// <param name="request">The request containing chatId and the value of chat request status.</param>
        /// <returns>The change status of the chat result</returns>
        [HttpPost("ChangeChatStatus")]
        public async Task<ApiResponse> ChangeChatStatus(ChangeChatStatusRequest request)
        {
            return await _messageService.ChangeChatStatus(request);
        }

        /// <summary>
        /// Adds message to selected chat by the owner of message.
        /// </summary>
        /// <param name="request">The request containing chatId and the message text.</param>
        /// <returns>The adding message to the chat result</returns>
        [HttpPost("AddMessage")]
        public async Task<ApiResponse> AddMessage(AddMessageRequest request)
        {
            return await _messageService.AddMessage(request);
        }

        /// <summary>
        /// Gets all messages related chatId
        /// </summary>
        /// <param name="chatId">Chat Id as string</param>
        /// <returns>The list of MessageDTO as result</returns>
        [HttpPost("GetMessages")]
        public async Task<GetMessageResponse> GetMessages(string chatId)
        {
            return await _messageService.GetMessages(chatId);
        }

        /// <summary>
        /// Get all messages related multiple chatIds
        /// </summary>
        /// <param name="chatIds">Chat Ids as string array</param>
        /// <returns>The list of MessageDTO as result</returns>
        [HttpPost("GetMessagesByChatIds")]
        public async Task<GetMessageResponse> GetMessagesByChatIds(string[] chatIds)
        {
            return await _messageService.GetMessages(chatIds);
        }

        /// <summary>
        /// Get all chats related the specific user
        /// </summary>
        /// <param name="userId">User Id as string</param>
        /// <returns>The list of ChatDTO as result</returns>
        [HttpPost("GetChats")]
        public async Task<GetChatResponse> GetChats(string userId)
        {
            return await _messageService.GetChats(userId);
        }
    }
}
