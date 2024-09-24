using AutoMapper;
using AdminUI.Contracts;
using AdminUI.Models;
using AdminUI.Models.Contact;
using AdminUI.Services.Base;
using AdminUI.Services.Common;

namespace AdminUI.Services
{
    public class ContactService : BaseHttpService, IContactService
    {
        private readonly IMapper _mapper;

        public ContactService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> CreateContact(CreateContactCommandVM command)
        {
            var createContactCommand = _mapper.Map<CreateContactCommand>(command);
            var data = await _client.CreateContactAsync(createContactCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<ContactVM> GetContact(GetContactQueryVM request)
        {
            var query = _mapper.Map<GetContactQuery>(request);
            var data = await _client.GetContactAsync(query);

            return _mapper.Map<ContactVM>(data);
        }

        public async Task<List<ContactVM>> GetContacts(GetContactsQueryVM request)
        {
            var query = _mapper.Map<GetContactsQuery>(request);
            var data = await _client.GetContactsAsync(query);

            return _mapper.Map<List<ContactVM>>(data);
        }

        public async Task<ContactsPaginationVM> GetContactsWithPagination(GetContactsWithPaginationQueryVM request)
        {
            GetContactsWithPaginationQuery query = _mapper.Map<GetContactsWithPaginationQuery>(request);

            var ContactsPagination = await _client.GetContactsWithPaginationAsync(query);

            var data = _mapper.Map<ContactsPaginationVM>(ContactsPagination);

            return data;
        }

        public async Task<ApiResponseVM> RemoveContact(RemoveContactCommandVM command)
        {
            var removeContactCommand = _mapper.Map<RemoveContactCommand>(command);
            var data = await _client.RemoveContactAsync(removeContactCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }
    }
}
