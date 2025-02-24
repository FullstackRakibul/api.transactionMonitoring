using SmartMonitoringApp.Services;
using v1.DbContexts.AuthModels;
using v1.DbContexts;
using v1.Repository;
using v1.Repository.IRepository;
using v1.Services;
using Microsoft.AspNetCore.Identity;
using v1.Services.AuthService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using v1.AuthHandler.Configuration;
using v1.Repository.IRepository.IAuthRepository;
using v1.Repository.AuthRepository;
using v1.Services.IService.IAuthService;
using v1.Services.AuthService;
using v1.Services.IService.IAuthInterface;

namespace v1.DependencyInversion
{
    public class DependencyInversion
    {

        internal static void RegisterServices(IServiceCollection services)
        {
            // repositories ...
            services.AddTransient <IPublicInterface ,PublicRepository>();
            services.AddTransient<IApplicationUserInterface, ApplicationUserRepository>();


            //services ...
            services.AddScoped<IAuthServiceInterface, AuthService>();
            services.AddScoped<ITokenServiceInterface, TokenService>();


            // Register Identity
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<MonitoringAppDbContext>()
                .AddDefaultTokenProviders();


            // Register custom services
            services.AddScoped<TokenService>();
            services.AddScoped<AuthService>();




            // Register JWT Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var serviceProvider = services.BuildServiceProvider();
                    var jwtSettings = serviceProvider.GetRequiredService<IConfiguration>().GetSection("JwtSettings").Get<JwtSettings>();

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                    };
                });

            // Register Role-based Authorization Policies (Dynamic)
            services.AddAuthorization(options =>
            {
                var roleNames = new[] { "Admin", "Merchant", "Banker" }; // Can be fetched from DB if needed
                foreach (var roleName in roleNames)
                {
                    options.AddPolicy($"{roleName}Policy", policy => policy.RequireRole(roleName));
                }
            });
        }
    }
}
