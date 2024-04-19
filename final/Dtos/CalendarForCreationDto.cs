using System.ComponentModel.DataAnnotations;
namespace Calendars2.Dtos
{
    public class CalendarForCreationDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string Cname { get; set; }
        [Required]
        public int Cpriority {  get; set; }
    }
}
