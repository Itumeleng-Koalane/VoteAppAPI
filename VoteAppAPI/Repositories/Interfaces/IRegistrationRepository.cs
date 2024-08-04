using VoteAppAPI.Domain_Model;

namespace VoteAppAPI.Repositories.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<Register> CreateRegistrationAsync(Register register);
    }
}
