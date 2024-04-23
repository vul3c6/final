using System.ComponentModel.DataAnnotations;
namespace final.Dtos
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
