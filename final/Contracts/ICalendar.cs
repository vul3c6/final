using Calendars2.Models;
using Calendars2.Dtos;
namespace Calendars2.Contracts
{
    public interface ICalendar
    {
        // 查詢所有Calendar 資料的介面
        public Task<IEnumerable<Calendar>> GetAllCalendars();
        // 查詢單一Calendar資料（依指定id）
        public Task<Calendar> GetCalendarById(int id);
        // 新增Calendar 資料
        public Task<CalendarForCreationDto> CreateCalendar(CalendarForCreationDto calendar);
        // 更新Calendar 資料（依指定id）
        public Task UpdateCalendar(int id, CalendarForUpdateDto calendar);
        // 刪除Calendar 資料（依指定id）
        public Task DeleteCalendar(int id);
    }
}
