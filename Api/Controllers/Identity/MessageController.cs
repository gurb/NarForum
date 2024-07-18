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

        [HttpPost("CreateChat")]
        public async Task<ApiResponse> CreateChat(CreateChatRequest request)
        {
            return await _messageService.CreateChat(request);
        }

        [HttpPost("ChangeChatStatus")]
        public async Task<ApiResponse> ChangeChatStatus(ChangeChatStatusRequest request)
        {
            return await _messageService.ChangeChatStatus(request);
        }

        [HttpPost("AddMessage")]
        public async Task<ApiResponse> AddMessage(AddMessageRequest request)
        {
            return await _messageService.AddMessage(request);
        }

        [HttpPost("GetMessages")]
        public async Task<GetMessageResponse> GetMessages(string chatId)
        {
            return await _messageService.GetMessages(chatId);
        }

        [HttpPost("GetChats")]
        public async Task<GetChatResponse> GetChats(string userId)
        {
            return await _messageService.GetChats(userId);
        }
    }
}
