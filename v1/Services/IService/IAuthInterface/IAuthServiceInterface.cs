namespace v1.Services.IService.IAuthService
{
    public interface IAuthServiceInterface
    {
        Task<bool> RegisterAsync(string email, string password, string name);
        Task<(bool Success, string Token, string ErrorMessage)> LoginAsync(string email, string password);
    }
}
