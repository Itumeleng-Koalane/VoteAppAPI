using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Models.DTOs
{
    public class CreateNationalRequestDto
    {
        public string PartyNameNational { get; set; }
        public int? Idnumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
