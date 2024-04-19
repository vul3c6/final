using System.ComponentModel.DataAnnotations;
namespace Calendars2.Dtos
{
    public class MemberForUpdateDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string Mname { get; set; }
        [Required]
        public int Mage { get; set; }
        [StringLength(100, ErrorMessage = "Maximum 100 characters")]
        public string? Maddress { get; set; }
        public string? Mphone { get; set; }
    }
}