using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Models.DTOs
{
    public class CreateRegistrationRequestDto
    {
        [MaxLength(13)]
        public string Idnumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
