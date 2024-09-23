using Microsoft.EntityFrameworkCore;
using VoteAppAPI.Data.DBContext;

namespace VoteAppAPI.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using RegisterAuthDBContext context = scope.ServiceProvider.GetRequiredService<RegisterAuthDBContext>();

            context.Database.Migrate();
        }
    }
}
