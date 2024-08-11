namespace VoteAppAPI.Models.DTOs
{
    public class CreateRegistrationRequestDto
    {
        public string Idnumber { get; set; }
        public string? Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
