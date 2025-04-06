using Microsoft.AspNetCore.Identity;
using v1.DbContexts.AuthModels;

namespace v1.Services.IService.IAuthInterface
{
    public interface ITokenServiceInterface
    {
        Task<string> GenerateJwtTokenAsync(ApplicationUser user);
    }
}
