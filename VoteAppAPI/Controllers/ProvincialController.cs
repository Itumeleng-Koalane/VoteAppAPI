using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoteAppAPI.Data.DBContext;
using VoteAppAPI.Domain_Model;
using VoteAppAPI.Models.DTOs;
using VoteAppAPI.Repositories.Interfaces;

namespace VoteAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincialController : ControllerBase
    {
        private readonly IProvincialRepository provincialRepository;
        private readonly VoteAppDBContext voteAppDBContext;
        private readonly ILogger<Provincial> logger;

        public ProvincialController(IProvincialRepository provincialRepository, VoteAppDBContext voteAppDBContext, ILogger<Provincial> logger)
        {
            this.provincialRepository = provincialRepository;
            this.voteAppDBContext = voteAppDBContext;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProvinces()
        {
            var provincialVotes = voteAppDBContext.Provinces.ToList();

            logger.LogError($"Could not get {provincialVotes.ToList()}");

            return Ok(provincialVotes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Provincial>> GetProvince([FromRoute]Guid id)
        {
            var province = await voteAppDBContext.Provinces.FindAsync(id);

            try
            {
                if (province == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Could not get {province.IdentificationNumber}");
                logger.LogInformation(ex.StackTrace);
            }
            return province;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProvincial([FromBody]CreateProvincialRequestDto requestDto)
        {
            var province = new Provincial()
            {
                Name = requestDto.Name,
                Surname = requestDto.Surname,
                IdentificationNumber = requestDto.IdentificationNumber,
                PartyNameProvincial = requestDto.PartyNameProvincial
            };

            await provincialRepository.CreateProvincialAsync(province);

            var response = new Provincial()
            {
                Name = province.Name,
                Surname = province.Surname,
                IdentificationNumber = province.IdentificationNumber,
                PartyNameProvincial = province.PartyNameProvincial
            };

            logger.LogError($"Could not create {requestDto.Name} based on: {response}");

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Register>> RemoveUser(Guid id)
        {
            var singleUser = await voteAppDBContext.Provinces.FindAsync(id);
            try
            {
                if (singleUser == null)
                {
                    return NotFound();
                }

                voteAppDBContext.Provinces.Remove(singleUser);
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
            var user = await voteAppDBContext.Provinces.FindAsync(id);

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
                if (!voteAppDBContext.Provinces.Any(e => e.Id == id))
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
