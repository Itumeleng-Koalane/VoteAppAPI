using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VoteAppAPI.Data.DBContext;
using VoteAppAPI.Domain_Model;

namespace VoteAppAPI.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityHandlersAndStores(this IServiceCollection services)
        {
            services.AddIdentityApiEndpoints<Register>()
                    .AddEntityFrameworkStores<RegisterAuthDBContext>()
                    .AddDefaultTokenProviders()
                    .AddApiEndpoints();

            return services;
        }

        public static IServiceCollection ConfigureIdentityOptions(this IServiceCollection services)
        {
            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.User.RequireUniqueEmail = true;
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireUppercase = true;
            //});

            return services;
        }

        public static IServiceCollection AddIdentityAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme =
                x.DefaultChallengeScheme =
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(i =>
            {
                i.SaveToken = false;
                i.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:JWTSecret"]!))
                };
            });
            return services;
        }

        public static WebApplication AddIdentityMiddlewares(this WebApplication app)
        {
            app.UseAuthentication();

            app.UseAuthorization();

            return app;
        }
    }
}
