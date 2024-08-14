using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteAppAPI.DBContext;
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
        public async Task<ActionResult<Provincial>> GetProvince(long id)
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
                logger.LogError($"Could not get {province.Idnumber}");
                logger.LogInformation(ex.StackTrace);
            }
            return province;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProvincial(CreateProvincialRequestDto requestDto)
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
    }
}
