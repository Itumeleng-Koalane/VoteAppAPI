using VoteAppAPI.Models;

namespace VoteAppAPI.Extensions
{
    public static class AppConfigExtensions
    {
        public static WebApplication ConfigureCORS(this WebApplication app, IConfiguration configuration)
        {
            //Add CORS in the Middleware pipeline
            app.UseCors(options =>
            {
                options.AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowAnyOrigin();
            });

            return app;
        }

        public static IServiceCollection AddAppConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            return services;
        }
    }
}
