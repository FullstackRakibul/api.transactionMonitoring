using v1.DbContexts.AuthModels;

namespace v1.Repository.IRepository.IAuthRepository
{
    public interface IApplicationUserInterface
    {
        Task<bool> CreateUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
    }
}
