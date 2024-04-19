using Calendars2.Dtos;
namespace Calendars2.Contracts
{
    public interface ICross
    {
        // 查詢Member 和他/她參與的所有Calendars 資料（依指定id）
        public Task<CalendarsOfMember> GetCalendarsByMemberId(Guid id);
        // 查詢Calendar 和參與其中的所有Members 資料（依指定id）
        public Task<MembersOfCalendar> GetMembersByCalendarId(int id);
    }
}
