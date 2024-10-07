using AutoMapper;
using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Models.Contact;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;

namespace NarForumAdmin.Services
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
            
            try
            {
                var createContactCommand = _mapper.Map<CreateContactCommand>(command);
                var data = await _client.CreateContactAsync(createContactCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ContactVM> GetContact(GetContactQueryVM request)
        {
            
            try
            {
                var query = _mapper.Map<GetContactQuery>(request);
                var data = await _client.GetContactAsync(query);

                return _mapper.Map<ContactVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<ContactVM>> GetContacts(GetContactsQueryVM request)
        {
            
            try
            {
                var query = _mapper.Map<GetContactsQuery>(request);
                var data = await _client.GetContactsAsync(query);

                return _mapper.Map<List<ContactVM>>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ContactsPaginationVM> GetContactsWithPagination(GetContactsWithPaginationQueryVM request)
        {
            
            try
            {
                GetContactsWithPaginationQuery query = _mapper.Map<GetContactsWithPaginationQuery>(request);

                var ContactsPagination = await _client.GetContactsWithPaginationAsync(query);

                var data = _mapper.Map<ContactsPaginationVM>(ContactsPagination);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> RemoveContact(RemoveContactCommandVM command)
        {
            try
            {
                var removeContactCommand = _mapper.Map<RemoveContactCommand>(command);
                var data = await _client.RemoveContactAsync(removeContactCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
