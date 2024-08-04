using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Models.DTOs
{
    public class CreateNationalRequestDto
    {
        public string PartyNameNational { get; set; }
        [Key]
        public long Idnumber { get; set; }
        [MaxLength(13)]
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
