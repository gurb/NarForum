using Application.Features.Contact.Commands.CreateContact;
using Application.Features.Contact.Commands.RemoveContact;
using Application.Features.Contact.Queries.GetContact;
using Application.Features.Contact.Queries.GetContacts;
using Application.Features.Contact.Queries.GetContactsWithPagination;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetContacts")]
        public async Task<List<ContactDTO>> GetContacts(GetContactsQuery request)
        {
            var Contacts = await _mediator.Send(request);
            return Contacts;
        }

        [HttpPost("GetContact")]
        public async Task<ContactDTO> GetContact(GetContactQuery request)
        {
            var Contact = await _mediator.Send(request);

            return Contact;
        }

        [HttpPost("GetContactsWithPagination")]
        public async Task<ContactsPaginationDTO> GetContactsWithPagination(GetContactsWithPaginationQuery request)
        {
            var dto = await _mediator.Send(request);

            return dto;
        }

        [HttpPost("CreateContact")]
        [AllowAnonymous]
        public async Task<ApiResponse> CreateContact(CreateContactCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("RemoveContact")]
        public async Task<ApiResponse> RemoveContact(RemoveContactCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
