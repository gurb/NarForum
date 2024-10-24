using Application.Contracts.Identity;
using Application.Models;
using Application.Models.Identity;
using Application.Models.Identity.User;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ForumUser> _userManager;
    private readonly SignInManager<ForumUser> _signInManager;
    private readonly JwtSettings _jwtSettings;
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public AuthService(
        UserManager<ForumUser> userManager, 
        IOptions<JwtSettings> jwtSettings,
        SignInManager<ForumUser> signInManager,
        IUserService userService,
        IRoleService roleService
        )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
        _userService = userService;
        _roleService = roleService;
     }

    public async Task<AuthResponse> Login(AuthRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);


        if(user == null)
        {
            return new AuthResponse
            {
                Token = string.Empty,
                IsSuccess = false,
                Message = $"User with {request.Email} not found."
            };
        }

        if(user.IsBlocked)
        {
            return new AuthResponse
            {
                Token = string.Empty,
                IsSuccess = false,
                Message = "This account is banned. If you think there is a mistake in this case, please contact us from the contact page."
            };
        }

        if(request.IsAdminPanel)
        {
            GetApiUserRoleRequest userRoleRequest = new GetApiUserRoleRequest
            {
                Id = user.Id,
            };
            var roleResponse = await _roleService.GetRoles();
            var userRole = await _userService.GetUserRole(userRoleRequest);

            if(userRole is not null && roleResponse.UserRoles is not null && roleResponse.UserRoles.Count > 0)
            {
                var role = roleResponse.UserRoles.FirstOrDefault(x => x.Id == userRole.RoleId);

                if(role is not null)
                {
                    if(role.Name is not null && 
                       role.Name.ToLower() == "Administrator".ToLower() ||
                       role.Name.ToLower() == "Moderator".ToLower())
                    {
                        
                    }
                    else
                    {
                        return new AuthResponse
                        {
                            Token = string.Empty,
                            IsSuccess = false,
                            Message = $"User has not authorize for admin panel."
                        };
                    }
                }
            }
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if(result.Succeeded == false)
        {
            return new AuthResponse
            {
                Token = string.Empty,
                IsSuccess = false,
                Message = $"Credentials for '{request.Email} aren't valid'."
            };
        }

        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
       

        var response = new AuthResponse
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email,
            Username = user.UserName
        };

        return response;
    }

    private async Task<JwtSecurityToken> GenerateToken(ForumUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles  = await _userManager.GetRolesAsync(user);

        var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();


        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id),
        }
        .Union(userClaims)
        .Union(roleClaims);

        TimeZoneInfo.ClearCachedData();

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }


    public async Task<ApiResponse> Register(RegistrationRequest request)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var user = new ForumUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = false,
                Role = "Member",
            };


            if(string.IsNullOrEmpty(request.Password))
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = "The password cannot be empty."
                };
            }

            if(request.Password.Length < 6)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = "The password must be at least 6 characters long."
                };
            }

            var result = await _userManager.CreateAsync(user, request.Password);


            if(result.Succeeded)
            {
                response.Message = "User registered successfully";

                await _userManager.AddToRoleAsync(user, "Member");
                
                var sendVerifyMailResponse = await _userService.CreateConfirmRequestWithUserId(user.Id);

                if(!sendVerifyMailResponse.IsSuccess)
                {
                    // failed to send verify mail address message to registered user.
                }

                return response;
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    response.Message += error.Description + "\n"; 
                }

                response.IsSuccess = false;
                return response;
            }
        }
        catch (Exception ex) 
        {
            response.Message = ex.Message;
            response.IsSuccess = false;
        }

        return response;
    }
}
