using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using VoteAppAPI.DBContext;
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

        public NationalsController(INationalRepository nationalRepository, VoteAppDBContext voteAppDBContext)
        {
            this.nationalRepository = nationalRepository;
            this.voteAppDBContext = voteAppDBContext;
        }

        public INationalRepository NationalRepository { get; }

        [HttpGet]
        public async Task<IActionResult> getAllNationals()
        {
            var nationalVotes = voteAppDBContext.Nationals.ToList();
            return Ok(nationalVotes);
        }

        //[HttpGet("id")]
        //public async Task<IActionResult> getNational(int id)
        //{

        //}

        [HttpPost]
        public async Task<IActionResult> createNational(CreateNationalRequestDto requestDto)
        {
            var national = new National()
            {
                Name = requestDto.Name,
                Surname = requestDto.Surname,
                Idnumber = requestDto.Idnumber,
                PartyNameNational = requestDto.PartyNameNational
            };

            await nationalRepository.CreateNationalAsync(national);

            var response = new National()
            {
                Name = national.Name,
                Surname = national.Surname,
                Idnumber = national.Idnumber,
                PartyNameNational = national.PartyNameNational
            };

            return Ok(response);
        }
    }
}
