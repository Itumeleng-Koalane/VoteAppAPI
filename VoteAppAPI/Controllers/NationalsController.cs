using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using VoteAppAPI.Data.DBContext;
using VoteAppAPI.Domain_Model;
using VoteAppAPI.Models.DTOs;
using VoteAppAPI.Repositories.Interfaces;

namespace VoteAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalsController : ControllerBase
    {
        private readonly INationalRepository nationalRepository;
        private readonly VoteAppDBContext voteAppDBContext;
        private readonly ILogger<National> logger;

        public NationalsController(INationalRepository nationalRepository, VoteAppDBContext voteAppDBContext, ILogger<National> logger)
        {
            this.nationalRepository = nationalRepository;
            this.voteAppDBContext = voteAppDBContext;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNationals()
        {
            var nationalVotes = voteAppDBContext.Nationals.ToList();

            logger.LogError($"Could not get {nationalVotes.ToList()}");

            return Ok(nationalVotes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<National>> GetNational([FromRoute]Guid id)
        {
            var national = await voteAppDBContext.Nationals.FindAsync(id);

            try
            {
                if (national == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Could not get {national} based on: {ex.Message}");
                logger.LogInformation(ex.StackTrace);
            }
            return national;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNational([FromBody]CreateNationalRequestDto requestDto)
        {
            var national = new National()
            {
                Name = requestDto.Name,
                Surname = requestDto.Surname,
                IdentificationNumber = requestDto.IdentificationNumber,
                PartyNameNational = requestDto.PartyNameNational
            };

            await nationalRepository.CreateNationalAsync(national);

            var response = new National()
            {
                Name = national.Name,
                Surname = national.Surname,
                IdentificationNumber = national.IdentificationNumber,
                PartyNameNational = national.PartyNameNational
            };

            logger.LogError($"Could not create {response.IdentificationNumber}");

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Register>> RemoveUser(Guid id)
        {
            var singleUser = await voteAppDBContext.Nationals.FindAsync(id);
            try
            {
                if (singleUser == null)
                {
                    return NotFound();
                }

                voteAppDBContext.Nationals.Remove(singleUser);
                await voteAppDBContext.SaveChangesAsync();
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
            var user = await voteAppDBContext.Nationals.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            // Update the properties of the found entity with the values from the input model
            user.Name = updatedUser.Name;
            user.IdentificationNumber = updatedUser.IdentificationNumber;
            user.Surname = updatedUser.Surname;

            voteAppDBContext.Entry(user).State = EntityState.Modified;

            try
            {
                await voteAppDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!voteAppDBContext.Nationals.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    logger.LogError($"Failed to create registration for user {user}:");
                    logger.LogInformation($"{user.IdentificationNumber}");
                }
            }
            return NoContent();
        }
    }
}
