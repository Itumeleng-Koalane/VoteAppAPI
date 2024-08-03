using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Domain_Model
{
    public class Provincial
    {
        public string PartyNameProvincial { get; set; }
        [Key]
        public int Idnumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
