using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Domain_Model
{
    public class National
    {
        public string PartyNameNational { get; set; }
        [Key]
        public int? Idnumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
