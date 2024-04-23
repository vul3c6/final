using final.Contracts;
using final.Utilities;
using final.Models;
using final.Dtos;
using Dapper;
using System.Data;

namespace final.Repositories
{
    public class CalendarRepository:ICalendar
    {
        private readonly DbContext _dbContext;
        // 在建構子中初始化DbContext 服務
        public CalendarRepository(DbContext dbContext)
        {
            // 注入DbContext 服務
            _dbContext = dbContext;
        }
        // 查詢所有Calendars資料的實作
        public async Task<IEnumerable<Calendar>> GetAllCalendars()
        { // 設定查詢用的SQL 語法
            string sqlQuery = "SELECT * FROM Calendar";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var calendar = await connection.QueryAsync<Calendar>(sqlQuery);
                return calendar.ToList();
            }
        }
            // 查詢指定id 的Calendar 資料
            public async Task<Calendar> GetCalendarById(int id)
            // 新增Calendar資料
        {
            string sqlQuery = "SELECT * FROM Calendar WHERE Cid = @Id";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var calendar = await connection.QueryFirstOrDefaultAsync<Calendar>(sqlQuery, new { Id = id });
                return calendar;
            }
        }
            public async Task<CalendarForCreationDto> CreateCalendar(CalendarForCreationDto calendar)
        {
            string sqlQuery = "INSERT INTO Calendar (Cname,Cpriority) VALUES (@Cname,@Cpriority)";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, calendar);
                return calendar;
            }
        }
            // 更新Calendar資料（依指定id）
            public async Task UpdateCalendar(int id, CalendarForUpdateDto calendar)
        {
            string sqlQuery = "UPDATE Calendar SET Cname = @Cname, Cpriority = @Cpriority, Cfinish = @Cfinish WHERE Cid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Cname", calendar.Cname, DbType.String);
            parameters.Add("Cpriority", calendar.Cpriority, DbType.Int32);
            parameters.Add("Cfinish", calendar.Cfinish, DbType.Boolean);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行更新
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }// 刪除Calendar資料（依指定id）
        public async Task DeleteCalendar(int id)
        {
            string sqlQuery = "DELETE FROM Calendar WHERE Cid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Int32);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行刪除
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
    }
}
