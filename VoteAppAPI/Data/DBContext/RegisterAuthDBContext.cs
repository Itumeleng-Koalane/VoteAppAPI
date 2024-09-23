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
        public DbSet<Register> Registers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
