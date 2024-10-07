using Microsoft.JSInterop;

namespace NarForumUser.Client.Services.Common
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
            // Eğer JavaScript interop çağrısının yapılamayacağı bir ortamdaysanız null döndür
            if (_jSRuntime is not IJSInProcessRuntime)
            {
                return;
            }

            await _jSRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        public async Task<string> GetItem(string key)
        {
            // Eğer JavaScript interop çağrısının yapılamayacağı bir ortamdaysanız null döndür
            if (_jSRuntime is not IJSInProcessRuntime)
            {
                return null;
            }


            return await _jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
        }

        public async Task<bool> ContainsKey(string key)
        {
            // Eğer JavaScript interop çağrısının yapılamayacağı bir ortamdaysanız null döndür
            if (_jSRuntime is not IJSInProcessRuntime)
            {
                return false;
            }

            if (await _jSRuntime.InvokeAsync<string>("localStorage.getItem", key) == null)
            {
                return false;
            }
            return true;
        }

        public async Task RemoveItem(string key)
        {
            if (_jSRuntime is not IJSInProcessRuntime)
            {
                return;
            }

            await _jSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
