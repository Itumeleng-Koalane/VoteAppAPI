using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoteAppAPI.Domain_Model;

namespace VoteAppAPI.Data.DBContext
{
    public class RegisterAuthDBContext : IdentityDbContext<Register>
    {
        public RegisterAuthDBContext(DbContextOptions<RegisterAuthDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Register>().Property(u => u.IdentificationNumber).HasMaxLength(13);
            builder.HasDefaultSchema("Register");
        }
    }
}
