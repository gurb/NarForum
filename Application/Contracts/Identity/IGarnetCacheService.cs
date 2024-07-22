using Identity.Models.DTO;

namespace Application.Contracts.Identity
{
    public interface IGarnetCacheService
    {
        Task<string> GetValueAsync(string key);
        Task<bool> SetValueAsync(string key, string value);
        Task<List<string>> GetList(string key);
        Task AppendListAsync(string key, string element);
        Task AddHashSet(string key, string field, string value);
        Task<string> GetHashSet(string key, string field);
        Task RemoveFieldHashSet(string key, string field);
        Task<Dictionary<string, string>?> GetAllHashSet(string key);
        Task<bool> RemoveFromList(string key, string element);
        Task Clear(string key);
        void ClearAll();
        Task Scan(string matchPattern, int count);
        Task<HashScanResult> HashScan(string key, string[] matchPatterns, int count);
    }
}
