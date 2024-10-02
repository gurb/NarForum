using GurbForumUser.Client.Models;
using GurbForumUser.Client.Models.Contact;

namespace GurbForumUser.Client.Contracts
{
    public interface IContactService
    {
        Task<List<ContactVM>> GetContacts(GetContactsQueryVM request);
        Task<ContactVM> GetContact(GetContactQueryVM request);
        Task<ContactsPaginationVM> GetContactsWithPagination(GetContactsWithPaginationQueryVM request);
        Task<ApiResponseVM> CreateContact(CreateContactCommandVM command);
        Task<ApiResponseVM> RemoveContact(RemoveContactCommandVM command);
    }
}
