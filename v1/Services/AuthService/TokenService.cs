using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using v1.AuthHandler.Claims;
using v1.DbContexts.AuthModels;
using v1.Services.IService.IAuthInterface;

namespace SmartMonitoringApp.Services
{
    public class TokenService : ITokenServiceInterface
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public TokenService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> GenerateJwtTokenAsync(ApplicationUser user)
        {

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(CustomClaims.Name, user.Name ?? string.Empty),
                new Claim(CustomClaims.Region, user.Region ?? string.Empty)
            };

            // Add Role if available
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Any())
            {
                claims.Add(new Claim(CustomClaims.Role, roles.First()));
            }

            //var roles = await _userManager.GetRolesAsync(user);
            //claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds,
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
