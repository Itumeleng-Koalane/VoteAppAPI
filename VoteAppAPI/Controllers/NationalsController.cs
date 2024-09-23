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
        public async Task<ActionResult<National>> GetNational(Guid id)
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
        public async Task<IActionResult> CreateNational(CreateNationalRequestDto requestDto)
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
    }
}
