using Microsoft.EntityFrameworkCore;
using VoteAppAPI.Data.DBContext;

namespace VoteAppAPI.Extensions
{
    public static class EFCoreExtensions
    {
        public static IServiceCollection InjectDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VoteAppDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("VoteAppConnectionString"));
            });

            services.AddDbContext<RegisterAuthDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("VoteAppConnectionString"));
            });

            return services;
        }
    }
}
