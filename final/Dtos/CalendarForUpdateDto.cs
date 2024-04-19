using System.ComponentModel.DataAnnotations;

namespace Calendars2.Dtos
{
    public class CalendarForUpdateDto
    {
        [Required]
        public string Cname { get; set; }
        [Required]
        public int Cpriority { get; set; }
        [Required]
        public bool Cfinish { get; set; }
    }
}
