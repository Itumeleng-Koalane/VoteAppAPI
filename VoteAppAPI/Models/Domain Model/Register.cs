using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Domain_Model
{
    public class Register : IdentityUser
    {
        [Required]
        public string? IdentificationNumber { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
