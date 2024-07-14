using Application.Models.Identity.Message;
using AutoMapper;
using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
