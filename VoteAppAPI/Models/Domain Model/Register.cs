using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoteAppAPI.Domain_Model
{
    public class Register : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(13)")]
        public string? IdentificationNumber { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(150)")]
        public string Surname { get; set; }
        [PersonalData]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
