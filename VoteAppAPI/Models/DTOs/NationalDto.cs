using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Models.DTOs
{
    public class NationalDto
    {
        public string PartyNameNational { get; set; }
        [Key]
        public long Idnumber { get; set; }
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
