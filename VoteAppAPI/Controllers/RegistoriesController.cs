using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ILogger<Register> logger;

        public RegistoriesController(RegisterAuthDBContext registerAuthDBContext, IRegistrationRepository registrationRepository, ILogger<Register> logger)
        {
            this.registerAuthDBContext = registerAuthDBContext;
            this.registrationRepository = registrationRepository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistryList()
        {
            var registryList = registerAuthDBContext.Registers.ToList();
            return Ok(registryList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Register>> GetSingleUser(Guid id)
        {
            var singleUser = await registerAuthDBContext.Registers.FindAsync(id);

            try
            {
                if (singleUser == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning($"Could not get the user {singleUser} based on an excpetion: " + ex.StackTrace);
            }
            return singleUser;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Register>> RemoveUser(Guid id)
        {
            var singleUser = await registerAuthDBContext.Registers.FindAsync(id);
            try
            {
                if (singleUser == null)
                {
                    return NotFound();
                }

                registerAuthDBContext.Registers.Remove(singleUser);
                await registerAuthDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Could not remove the user {singleUser} based on: " + ex.StackTrace);
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] Register updatedUser)
        {
            var user = await registerAuthDBContext.Registers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            // Update the properties of the found entity with the values from the input model
            user.Name = updatedUser.Name;
            user.Idnumber = updatedUser.Idnumber;
            user.Surname = updatedUser.Surname;
            user.Email = updatedUser.Email;
            // Update other properties here

            registerAuthDBContext.Entry(user).State = EntityState.Modified;

            try
            {
                await registerAuthDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!registerAuthDBContext.Registers.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    logger.LogError($"Failed to create registration for user {user}:");
                    logger.LogInformation($"{user.Idnumber}");
                }
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistration([FromBody]CreateRegistrationRequestDto requestDto)
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

            logger.LogError($"Failed to create registration for user {response}:");
            logger.LogTrace($"{response.Idnumber}");

            return Ok(response);
        }
    }
}
