using final.Contracts;
using final.Utilities;
using final.Dtos;
using Dapper;
namespace final.Repositories
{
    public class CrossRepository : ICross
    {
        private readonly DbContext _dbContext;
        public CrossRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // 查詢Member 和他/她參與的所有Calendars 資料（依指定id）
        public async Task<CalendarsOfMember> GetCalendarsByMemberId(Guid id)
        {
            string sqlQuery = "SELECT Mid, Mname, Mphone FROM Member WHERE Mid = @Id;" + "SELECT C.Cname FROM Calendar C, CalendarJoin J " + "WHERE J.Mid = @Id AND C.Cid = J.Cid;";
            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
                var member = await multi.ReadSingleOrDefaultAsync<CalendarsOfMember>();
                if (member != null) member.Calendars = (await multi.ReadAsync<String>()).ToList();
                return member;
            }
        }
        // 查詢Calendar 和參與的所有Member 資料（依指定id）
        public async Task<MembersOfCalendar> GetMembersByCalendarId(int id)
        {
            string sqlQuery = "SELECT Cid, Cname FROM Calendar WHERE Cid = @Id;" + "SELECT M.Mname FROM Member M, CalendarJoin J " + "WHERE J.Cid = @Id AND M.Mid = J.Mid;";

            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
                var calendar = await multi.ReadSingleOrDefaultAsync<MembersOfCalendar>();
                if (calendar != null) calendar.Members = (await multi.ReadAsync<String>()).ToList();
                return calendar;
            }
        }
    }
}
