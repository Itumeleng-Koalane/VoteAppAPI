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

        public ProvincialController(IProvincialRepository provincialRepository, VoteAppDBContext voteAppDBContext)
        {
            this.provincialRepository = provincialRepository;
            this.voteAppDBContext = voteAppDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> getAllProvinces()
        {
            var provincialVotes = voteAppDBContext.Provinces.ToList();
            return Ok(provincialVotes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Provincial>> GetProvince(long id)
        {
            var province = await voteAppDBContext.Provinces.FindAsync(id);

            if (province == null)
            {
                return NotFound();
            }
            return province;
        }

        [HttpPost]
        public async Task<IActionResult> createProvincial(CreateProvincialRequestDto requestDto)
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

            return Ok(response);
        }
    }
}
