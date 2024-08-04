using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Domain_Model
{
    public class Register
    {
        public Guid Id { get; set; }
        [MaxLength(13)]
        public string Idnumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
