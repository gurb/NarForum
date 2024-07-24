using Application.Models.Identity.Message;
using AutoMapper;
using Identity.Models;


namespace Identity.MappingProfiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDTO>().ReverseMap();
            CreateMap<ForumUser, UserDTO>().ReverseMap();
            CreateMap<Chat, ChatDTO>().ReverseMap();
        }
    }
}
