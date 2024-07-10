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

        [HttpPost("AddMessage")]
        public async Task<ApiResponse> AddMessage(AddMessageRequest request)
        {
            return await _messageService.AddMessage(request);
        }

        [HttpPost("GetPermissions")]
        public async Task<GetMessageResponse> GetMessages(string userId)
        {
            return await _messageService.GetMessages(userId);
        }
    }
}
