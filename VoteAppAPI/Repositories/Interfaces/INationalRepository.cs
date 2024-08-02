using VoteAppAPI.Domain_Model;

namespace VoteAppAPI.Repositories.Interfaces
{
    public interface INationalRepository
    {
        Task<National> CreateNationalAsync(National national); 
    }
}
