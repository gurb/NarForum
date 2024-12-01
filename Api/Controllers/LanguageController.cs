using Application.Contracts.Persistence;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IJsonFileService _jsonFileService;

        public LanguageController(IWebHostEnvironment webHostEnvironment, IJsonFileService jsonFileService)
        {
            _webHostEnvironment = webHostEnvironment;
            _jsonFileService = jsonFileService;
        }

        [AllowAnonymous]
        [HttpGet("language/{lang}")]
        public IActionResult GetLang(string lang)
        {
            var dir = Path.Combine(_webHostEnvironment.ContentRootPath, $"Uploads/Langs");
            if (!Directory.Exists(dir))
            {
                return NotFound("Language directory not found.");
            }

            var fileName = Path.GetFileName(lang);
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return BadRequest("Invalid file name.");
            }

            var filePath = Path.Combine(dir, fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            try
            {
                var content = System.IO.File.OpenRead(filePath);
                return File(content, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while reading the file.");
            }
        }

        [HttpPost("ChangeLanguage")]
        public async Task<ApiResponse> ChangeLanguage(string lang, string jsonStr)
        {
            var dir = Path.Combine(_webHostEnvironment.ContentRootPath, $"Uploads/Langs");
            ApiResponse response = await _jsonFileService.ChangeJsonFile(dir, lang + ".json", jsonStr);
            return response;
        }
    }
}
