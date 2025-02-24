using Microsoft.AspNetCore.Identity;
using v1.DbContexts.AuthModels;

namespace v1.AuthHandler.MinimalApis
{
    public static class IdentityApi
    {
        public static void RegisterIdentityApi(this IEndpointRouteBuilder app)
        {
            app.MapGet("/identity/user/{id}", async (string id, UserManager<ApplicationUser> userManager) =>
            {
                var user = await userManager.FindByIdAsync(id);
                return user != null ? Results.Ok(new { user.Id, user.Email, user.Name }) : Results.NotFound("User not found");
            })
            .RequireAuthorization("AdminPolicy");

            app.MapGet("/identity/roles/{id}", async (string id, UserManager<ApplicationUser> userManager) =>
            {
                var user = await userManager.FindByIdAsync(id);
                if (user == null) return Results.NotFound("User not found");

                var roles = await userManager.GetRolesAsync(user);
                return Results.Ok(roles);
            })
            .RequireAuthorization();
        }
    }
}
