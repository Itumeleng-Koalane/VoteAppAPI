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

        public RegistoriesController(RegisterAuthDBContext registerAuthDBContext, IRegistrationRepository registrationRepository)
        {
            this.registerAuthDBContext = registerAuthDBContext;
            this.registrationRepository = registrationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getRegistryList()
        {
            var registryList = registerAuthDBContext.Registers.ToList();
            return Ok(registryList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Register>> GetSingleUser(long id)
        {
            var singleUser = await registerAuthDBContext.Registers.FindAsync(id);

            if (singleUser == null)
            {
                return NotFound();
            }
            return singleUser;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Register>> removeUser(long id)
        {
            var singleUser = await registerAuthDBContext.Registers.FindAsync(id);

            if (singleUser == null)
            {
                return NotFound();
            }

            registerAuthDBContext.Registers.Remove(singleUser);
            await registerAuthDBContext.SaveChangesAsync();

            return NoContent();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUser(int id, [FromBody] Register updatedUser)
        //{
        //    if (id != updatedUser.Idnumber)
        //    {
        //        return BadRequest();
        //    }

        //    var user = await registerAuthDBContext.Registers.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    // Update the properties of the found entity with the values from the input model
        //    user.Name = updatedUser.Name;
        //    // Update other properties here

        //    registerAuthDBContext.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await registerAuthDBContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!registerAuthDBContext.Registers.Any(e => e.id == id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return NoContent();
        //}

        [HttpPost]
        public async Task<IActionResult> createRegistration([FromBody]CreateRegistrationRequestDto requestDto)
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
