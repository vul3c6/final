using final.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrossController : ControllerBase
    {
        // 記錄和追蹤應用程式的運行時行為及各種訊息，如警告、錯誤等
        private readonly ILogger<CrossController> _logger;
        // 宣告此控制器所要依賴的介面（Interface），而不是其實作
        private readonly ICross _cross;
        public CrossController(ILogger<CrossController> logger, ICross cross)
        {
            // 注入Logger 服務
            _logger = logger;
            // 注入Cross 服務
            _cross = cross;
        }
        [HttpGet("CalendarsForMember/{id}")]
        public async Task<IActionResult> GetCalendarsByMemberId(Guid id)
        {
            try
            {
                // 取得指定id 的會員資料
                var calendars = await _cross.GetCalendarsByMemberId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定id 會員的所有行事曆成功",
                    Data = calendars
                });
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
        [HttpGet("MembersForCalendar/{id}")]
        public async Task<IActionResult> GetMembersByCalendarId(int id)
        {
            try
            {
                // 取得指定id 的會員資料
                var members = await _cross.GetMembersByCalendarId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定id 會員的所有行事曆成功",
                    Data = members
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("CalendarDetailsForMember/{id}")]
        public async Task<IActionResult> GetCalendarDetailsByMemberId(Guid id)
        {
            try
            {
                // 取得指定id 的會員資料
                var calendarDetails = await _cross.GetCalendarDetailsByMemberId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定id 會員的所有行事曆詳細資料成功",
                    Data = calendarDetails
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("MemberDetailsForCalendar/{id}")]
        public async Task<IActionResult> GetMemberDetailsByCalendarId(int id)
        {
            try
            {
                // 取得指定id 的行事曆資料
                var memberDetails = await _cross.GetMemberDetailsByCalendarId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定id 行事曆的所有會員詳細資料成功",
                    Data = memberDetails
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
