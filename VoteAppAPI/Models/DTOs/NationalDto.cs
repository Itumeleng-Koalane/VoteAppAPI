using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Models.DTOs
{
    public class NationalDto
    {
        public string PartyNameNational { get; set; }
        public int? Idnumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
