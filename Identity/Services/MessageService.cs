using Application.Contracts.Identity;
using Application.Models;
using Application.Models.Identity.Message;
using AutoMapper;
using Azure.Core;
using Identity.DatabaseContext;
using Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly ForumIdentityDbContext _forumIdentityDbContext;

        public MessageService(IMapper mapper, ForumIdentityDbContext forumIdentityDbContext)
        {
            _forumIdentityDbContext = forumIdentityDbContext;
            _mapper = mapper;
        }

        public async Task<ApiResponse> AddMessage(AddMessageRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                Message message = new Message
                {
                    Text = request.Text,
                    ReceiverId = request.ReceiverId,
                    OwnerId = request.OwnerId,
                    DateTime = DateTime.UtcNow,
                };


                await _forumIdentityDbContext.Messages.AddAsync(message);
                await _forumIdentityDbContext.SaveChangesAsync();

                response.Message = "Message is added";
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    response.Message = ex.InnerException.Message;
                }
                else
                {
                    response.Message = ex.Message;
                }
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<GetMessageResponse> GetMessages(string userId)
        {
            GetMessageResponse response = new GetMessageResponse();

            var data = await _forumIdentityDbContext.Messages.AsNoTracking()
                .Include(x => x.Receiver)
                .Include(x => x.Owner)
                .Where(x => x.OwnerId == userId || x.ReceiverId == userId).ToListAsync();

            response.Messages = _mapper.Map<List<MessageDTO>>(data);

            return response;
        }
    }
}
