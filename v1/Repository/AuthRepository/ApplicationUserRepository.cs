

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using v1.DbContexts.AuthModels;
using v1.Repository.IRepository.IAuthRepository;

namespace v1.Repository.AuthRepository
{
    public class ApplicationUserRepository :  IApplicationUserInterface
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserRepository(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        // Create User
        public async Task<bool> CreateUserAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        // Get User By Email
        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
