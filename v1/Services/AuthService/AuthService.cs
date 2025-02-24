using Microsoft.AspNetCore.Identity;
using SmartMonitoringApp.Services;
using v1.DbContexts.AuthModels;

namespace v1.Services.AuthService
{
    public class AuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<(bool Success, string Token, string ErrorMessage)> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return (false, string.Empty, "User not found.");

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (!result.Succeeded) return (false, string.Empty, "Invalid credentials.");

            var token = await _tokenService.GenerateJwtToken(user);
            return (true, token, string.Empty);
        }
    }
}
