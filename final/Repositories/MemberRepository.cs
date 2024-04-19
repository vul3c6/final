using Calendars2.Contracts;
using Calendars2.Models;
using Calendars2.Utilities;
using Calendars2.Dtos;
using Dapper;
using System.Data;
namespace Calendars2.Repositories
{
    public class MemberRepository : IMember
    {
        private readonly DbContext _dbContext;
        // 在建構子中初始化DbContext 服務
        public MemberRepository(DbContext dbContext)
        {
            // 注入DbContext 服務
            _dbContext = dbContext;
        }
        // 查詢所有Member資料的實作
        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            // 設定查詢用的SQL 語法
            string sqlQuery = "SELECT * FROM Member";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var members = await connection.QueryAsync<Member>(sqlQuery);
                return members.ToList();
            }
        }
        // 查詢單一Member資料（依指定Id）
        public async Task<Member> GetMemberById(Guid id)
        {
            string sqlQuery = "SELECT * FROM Member WHERE Mid = @Id";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var member = await connection.QueryFirstOrDefaultAsync<Member>(sqlQuery, new { Id = id });
                return member;
            }
        }
        // 新增Member 資料
        public async Task<MemberForCreationDto> CreateMember(MemberForCreationDto member)
        {
            string sqlQuery = "INSERT INTO Member (Mname, Mage) VALUES (@Mname, @Mage)";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, member);
                return member;
            }
        }
        public async Task UpdateMember(Guid id, MemberForUpdateDto member)
        {
            string sqlQuery = "UPDATE Member SET Mname = @Mname, Mage = @Mage, Maddress = @Maddress, Mphone = @Mphone WHERE Mid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            parameters.Add("Mname", member.Mname, DbType.String);
            parameters.Add("Mage", member.Mage, DbType.Int32);
            parameters.Add("Maddress", member.Maddress, DbType.String);
            parameters.Add("Mphone", member.Mphone, DbType.String);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行更新
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
        public async Task DeleteMember(Guid id)
        {
            string sqlQuery = "DELETE FROM Member WHERE Mid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行刪除
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
    }
}
