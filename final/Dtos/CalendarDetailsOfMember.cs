using final.Models;
using System.ComponentModel.DataAnnotations;

namespace final.Dtos
{
    public class CalendarDetailsOfMember
    {
        [Required] public Guid Mid { get; set; }
        [Required] public string Mname { get; set; }
        [Required] public string Mphone { get; set; }
        // 此Member 所參與的Calendars
        public List<Calendar> Calendars { get; set; } = new List<Calendar>();
    }
}
