using System.ComponentModel.DataAnnotations;

namespace VoteAppAPI.Models.DTOs
{
    public class CreateProvincialRequestDto
    {
        public string PartyNameProvincial { get; set; }
        public Guid Id { get; set; }
        [MaxLength(13)]
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
