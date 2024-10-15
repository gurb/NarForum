using Application.Contracts.Identity;
using Application.Models;
using Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Identity
{
    /// <summary>
    /// User Auth Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;

        public AuthController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="request">The authentication request containing the user's login credentials.</param>
        /// <returns>The authentication result and associated user information.</returns>
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        /// <summary>
        /// Registers the user
        /// </summary>
        /// <param name="request">The register request containing the user's unique informations.</param>
        /// <returns>The register result</returns>
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }
    }
}
