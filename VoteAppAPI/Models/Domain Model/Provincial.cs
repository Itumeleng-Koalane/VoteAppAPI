using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Domain_Model
{
    public class Provincial
    {
        public string PartyNameProvincial { get; set; }
        [Key]
        public long Idnumber { get; set; }
        [MaxLength(13)]
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
