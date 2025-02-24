using Microsoft.AspNetCore.Identity;
using SmartMonitoringApp.Services;
using v1.DbContexts.AuthModels;
using v1.Repository.IRepository.IAuthRepository;
using v1.Services.IService.IAuthService;

namespace v1.Services.AuthService
{
    public class AuthService : IAuthServiceInterface
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IApplicationUserInterface _userRepository;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TokenService tokenService , IApplicationUserInterface applicationUserInterface )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userRepository = applicationUserInterface;
        }

        // registration service 
        public async Task<bool> RegisterAsync(string email, string password, string name)
        {
            // Check if user already exists
            if (email != null)
            {
                var existingUser = await _userRepository.GetUserByEmailAsync(email);
                if (existingUser != null) return false;
            }
            
            // Create a new user
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                Name = name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = 1
            };

            // Save user in the database
            return await _userRepository.CreateUserAsync(user, password);
            
        }


        // login service
        public async Task<(bool Success, string Token, string ErrorMessage)> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return (false, string.Empty, "User not found.");

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (!result.Succeeded) return (false, string.Empty, "Invalid credentials.");

            var token = await _tokenService.GenerateJwtTokenAsync(user);
            return (true, token, "User Log in Success ...");
        }
    }
}
