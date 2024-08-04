using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoteAppAPI.Domain_Model;

namespace VoteAppAPI.DBContext
{
    public class RegisterAuthDBContext : IdentityDbContext<IdentityUser>
    {
        public RegisterAuthDBContext(DbContextOptions<RegisterAuthDBContext> options) : base(options)
        {

        }
        public DbSet<Register> Registers { get; set; }
    }
}
