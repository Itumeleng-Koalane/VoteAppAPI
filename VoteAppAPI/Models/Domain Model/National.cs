using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Domain_Model
{
    public class National
    {
        public string PartyNameNational { get; set; }
        [Key]
        public Guid Id { get; set; }
        [MaxLength(13)]
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
