using Application.Models;

namespace Application.Contracts.Persistence
{
    public interface IJsonFileService
    {
        Task<ApiResponse> ChangeJsonFile(string dir, string fileName, string jsonContent);
    }
}
