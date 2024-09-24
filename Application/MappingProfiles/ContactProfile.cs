using Application.Features.Contact.Commands.CreateContact;
using Application.Features.Contact.Queries.GetContact;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactDTO, Contact>().ReverseMap();
            CreateMap<CreateContactCommand, Contact>().ReverseMap();
        }

    }
}
