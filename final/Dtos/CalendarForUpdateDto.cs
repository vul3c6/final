using System.ComponentModel.DataAnnotations;

namespace final.Dtos
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
