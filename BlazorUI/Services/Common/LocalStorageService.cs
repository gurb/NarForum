using Microsoft.JSInterop;

namespace BlazorUI.Services.Common
{
    public class LocalStorageService
    {
        private IJSRuntime _jSRuntime;

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jSRuntime = jsRuntime; 
        }

        public async Task AddItem(string key, string value)
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        public async Task<string> GetItem(string key)
        {
            return await _jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
        }

        public async Task<bool> ContainsKey(string key)
        {
            if(await _jSRuntime.InvokeAsync<string>("localStorage.getItem", key) == null)
            {
                return false;
            }
            return true;
        }

        public async Task RemoveItem(string key)
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
