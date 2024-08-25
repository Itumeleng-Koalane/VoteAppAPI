using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using VoteAppAPI.Data.DBContext;
using VoteAppAPI.Domain_Model;
using VoteAppAPI.Repositories.Interfaces;

namespace VoteAppAPI.Repositories.Implementations
{
    public class ProvincialRepository : IProvincialRepository
    {
        private readonly VoteAppDBContext voteAppDBContext;

        public ProvincialRepository(VoteAppDBContext voteAppDBContext)
        {
            this.voteAppDBContext = voteAppDBContext;
        }
        public async Task<Provincial> CreateProvincialAsync(Provincial provincial)
        {
            await voteAppDBContext.Provinces.AddAsync(provincial);
            await voteAppDBContext.SaveChangesAsync();

            return provincial;
        }
    }
}
