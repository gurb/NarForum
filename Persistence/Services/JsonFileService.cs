using Application.Contracts.Persistence;
using Application.Models;
using Azure.Core;

namespace Persistence.Services
{
    public class JsonFileService : IJsonFileService
    {
        public JsonFileService()
        {
            
        }

        public async Task<ApiResponse> ChangeJsonFile(string dir, string fileName, string jsonContent)
        {
            ApiResponse response = new();

            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                var filePath = Path.Combine(dir, fileName);

                var extensionFile = Path.GetExtension(filePath).ToLower();

                await File.WriteAllTextAsync(filePath, jsonContent);

                response.IsSuccess = true;
                response.Message = "Language file is updated";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }
    }
}
