using Microsoft.EntityFrameworkCore;
using VoteAppAPI.Domain_Model;

namespace VoteAppAPI.Data.DBContext
{
    public class VoteAppDBContext : DbContext
    {
        public VoteAppDBContext(DbContextOptions<VoteAppDBContext> options) : base(options)
        {

        }
        public DbSet<Provincial> Provinces { get; set; }
        public DbSet<National> Nationals { get; set; }
    }
}
