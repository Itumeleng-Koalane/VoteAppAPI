using Microsoft.EntityFrameworkCore;
using VoteAppAPI.Domain_Model;

namespace VoteAppAPI.DBContext
{
    public class VoteAppDBContext : DbContext
    {
        public VoteAppDBContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<Provincial> Provinces { get; set; }
        public DbSet<National> Nationals { get; set; }
    }
}
