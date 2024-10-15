using Application.Features.Contact.Commands.CreateContact;
using Application.Features.Contact.Commands.RemoveContact;
using Application.Features.Contact.Queries.GetContact;
using Application.Features.Contact.Queries.GetContacts;
using Application.Features.Contact.Queries.GetContactsWithPagination;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Gets all contacts
        /// </summary>
        /// <param name="request">The request containing no fields currently.</param>
        /// <returns>The getting contacts result as the list of ContactDTO</returns>
        [HttpPost("GetContacts")]
        public async Task<List<ContactDTO>> GetContacts(GetContactsQuery request)
        {
            var Contacts = await _mediator.Send(request);
            return Contacts;
        }

        /// <summary>
        /// Gets the selected contact. 
        /// </summary>
        /// <param name="request">The request containing Id(Guid) field.</param>
        /// <returns>The getting the selected contact result as ContactDTO.</returns>
        [HttpPost("GetContact")]
        public async Task<ContactDTO> GetContact(GetContactQuery request)
        {
            var Contact = await _mediator.Send(request);

            return Contact;
        }

        /// <summary>
        /// Gets contacts with server-side pagination.
        /// </summary>
        /// <param name="request">The request containing NameSurname(string), Email(string), Type(ContactType as enum), 
        /// Subject(string), PageIndex(int) and PageSize(int) fields.</param>
        /// <returns>The getting the part of the list of contacts and total size of the contacts as ContactsPaginationDTO.</returns>
        [HttpPost("GetContactsWithPagination")]
        public async Task<ContactsPaginationDTO> GetContactsWithPagination(GetContactsWithPaginationQuery request)
        {
            var dto = await _mediator.Send(request);

            return dto;
        }

        /// <summary>
        /// Creates a new contact.
        /// </summary>
        /// <param name="command">The command containing NameSurname(string), Email(string), WebSite(string), 
        /// Type(ContactType as enum), Subject(string), Message(string) fields</param>
        /// <returns>The creating a new contact result as ApiResponse</returns>
        [HttpPost("CreateContact")]
        [AllowAnonymous]
        public async Task<ApiResponse> CreateContact(CreateContactCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Removes the selected contact
        /// </summary>
        /// <param name="command">The command containing Id(Guid) field.</param>
        /// <returns>The removing the selected contact result as ApiResponse</returns>
        [HttpPost("RemoveContact")]
        public async Task<ApiResponse> RemoveContact(RemoveContactCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
