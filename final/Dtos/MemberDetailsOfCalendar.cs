using final.Models;
using System.ComponentModel.DataAnnotations;

namespace final.Dtos
{
    public class MemberDetailsOfCalendar
    {
        [Required] public int Cid { get; set; }
        [Required] public string Cname { get; set; }
        // 參與此Calendar 的成員
        public List<Member> Members { get; set; } = new List<Member>();
    }
}
