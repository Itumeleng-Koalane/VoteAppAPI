using VoteAppAPI.Domain_Model;

namespace VoteAppAPI.Repositories.Interfaces
{
    public interface IProvincialRepository
    {
        Task<Provincial> CreateProvincialAsync(Provincial provincial);
    }
}
