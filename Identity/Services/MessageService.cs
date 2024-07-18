using Application.Contracts.Identity;
using Application.Models;
using Application.Models.Identity.Message;
using AutoMapper;
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

        public async Task<ApiResponse> CreateChat(CreateChatRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                Chat chat = new Chat
                {
                    Subject = request.Subject,
                    Message = request.Text,
                    CreatorId = request.OwnerId,
                    ReceiverId = request.ReceiverId,
                };


                await _forumIdentityDbContext.Chats.AddAsync(chat);
                await _forumIdentityDbContext.SaveChangesAsync();

                response.Message = "Chat is created";
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

        public async Task<ApiResponse> ChangeChatStatus(ChangeChatStatusRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                Chat? chat = await _forumIdentityDbContext.Chats.FirstOrDefaultAsync(x => x.Id == request.ChatId);

                if(chat != null)
                {
                    chat.Status = (Models.Enums.ChatStatus)request.Status;
                    
                    _forumIdentityDbContext.Chats.Update(chat);
                    await _forumIdentityDbContext.SaveChangesAsync();
                    response.Message = "Chat staus is changed";
                }
                else
                {
                    response.Message = "Chat is not found";
                }

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

        public async Task<ApiResponse> AddMessage(AddMessageRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                Message message = new Message
                {
                    Text = request.Text,
                    ChatId = request.ChatId,
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

        public async Task<GetMessageResponse> GetMessages(string chatId)
        {
            GetMessageResponse response = new GetMessageResponse();

            var data = await _forumIdentityDbContext.Messages.AsNoTracking()
                .Where(x => x.ChatId == chatId).ToListAsync();

            response.Messages = _mapper.Map<List<MessageDTO>>(data);

            return response;
        }

        public async Task<GetChatResponse> GetChats(string userId)
        {
            GetChatResponse response = new GetChatResponse();

            var data = await _forumIdentityDbContext.Chats.AsNoTracking()
                .Where(x => x.CreatorId == userId || x.ReceiverId == userId).ToListAsync();

            response.Chats = _mapper.Map<List<ChatDTO>>(data);

            return response;
        }
    }
}
