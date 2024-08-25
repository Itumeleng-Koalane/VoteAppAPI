using VoteAppAPI.Data.DBContext;
using VoteAppAPI.Domain_Model;
using VoteAppAPI.Repositories.Interfaces;

namespace VoteAppAPI.Repositories.Implementations
{
    public class RegisterRepository : IRegistrationRepository
    {
        private readonly RegisterAuthDBContext registerAuthDBContext;

        public RegisterRepository(RegisterAuthDBContext registerAuthDBContext)
        {
            this.registerAuthDBContext = registerAuthDBContext;
        }
        public async Task<Register> CreateRegistrationAsync(Register register)
        {
            await registerAuthDBContext.Registers.AddAsync(register);
            await registerAuthDBContext.SaveChangesAsync();

            return register;
        }
    }
}
