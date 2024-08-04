using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteAppAPI.DBContext;
using VoteAppAPI.Domain_Model;
using VoteAppAPI.Models.DTOs;
using VoteAppAPI.Repositories.Implementations;
using VoteAppAPI.Repositories.Interfaces;

namespace VoteAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistoriesController : ControllerBase
    {
        private readonly RegisterAuthDBContext registerAuthDBContext;
        private readonly IRegistrationRepository registrationRepository;

        public RegistoriesController(RegisterAuthDBContext registerAuthDBContext, IRegistrationRepository registrationRepository)
        {
            this.registerAuthDBContext = registerAuthDBContext;
            this.registrationRepository = registrationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> createRegistration(CreateRegistrationRequestDto requestDto)
        {
            var register = new Register()
            {
                Name = requestDto.Name,
                Surname = requestDto.Surname,
                Idnumber = requestDto.Idnumber,
                Email = requestDto.Email,
            };

            await registrationRepository.CreateRegistrationAsync(register);

            var response = new Register()
            {
                Name = register.Name,
                Surname = register.Surname,
                Idnumber = register.Idnumber,
                Email = register.Email,
            };

            return Ok(response);
        }
    }
}
