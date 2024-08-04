using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Domain_Model
{
    public class Register
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(13)]
        public string Idnumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
