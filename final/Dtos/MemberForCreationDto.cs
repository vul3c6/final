using System.ComponentModel.DataAnnotations;
namespace Calendars2.Dtos
{
    public class MemberForCreationDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string Mname { get; set; }
        [Required]
        public int Mage { get; set; }
    }
}