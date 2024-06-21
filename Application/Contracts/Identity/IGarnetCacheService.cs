namespace Application.Contracts.Identity
{
    public interface IGarnetCacheService
    {
        Task<string> GetValueAsync(string key);
        Task<bool> SetValueAsync(string key, string value);
        Task AppendListAsync(string key, string element);
        Task AddHashSet(string key, string field, string value);
        Task<Dictionary<string, string>?> GetAllHashSet(string key);
        Task<bool> RemoveFromList(string key, string element);
        Task Clear(string key);
        void ClearAll();
    }
}
