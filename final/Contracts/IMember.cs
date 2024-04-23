using final.Models;
using final.Dtos;
namespace final.Contracts
{
    public interface IMember
    {
        // 查詢所有Member資料的介面
        public Task<IEnumerable<Member>> GetAllMembers();
        // 查詢單一Member資料（依指定id）
        public Task<Member> GetMemberById(Guid id);
        // 新增Member 資料
        public Task<MemberForCreationDto> CreateMember(MemberForCreationDto member);
        // 更新Member 資料（依指定id）
        public Task UpdateMember(Guid id, MemberForUpdateDto member);
        // 刪除Member 資料（依指定id）
        public Task DeleteMember(Guid id);
    }
}
