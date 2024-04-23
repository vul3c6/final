using final.Contracts;
using final.Dtos;
using final.Models;
using Microsoft.AspNetCore.Mvc;

namespace final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ILogger<CalendarController> _logger;
        private readonly ICalendar _calendar;
        public CalendarController(ILogger<CalendarController> logger, ICalendar calendar)
        {
            _logger = logger;
            _calendar = calendar;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCalendars()
        {
            try
            {
                var calendar = await _calendar.GetAllCalendars();
                return Ok(new { Success = true, Message = "All Calendar Returned.", calendar });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalendarById(int id)
        {
            try
            {
                var calendar = await _calendar.GetCalendarById(id);
                return Ok(new { Success = true, Message = "Calendar Returned.", calendar });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
            [HttpPost] 
        public async Task<IActionResult> CreateCalendar(CalendarForCreationDto calendar)
        {
            try
            {
                var newCalendar = await _calendar.CreateCalendar(calendar);
                return Ok(new { Success = true, Message = "Calendar Created.", newCalendar });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateCalendar(int id, CalendarForUpdateDto calendar)
        {
            try
            {
                await _calendar.UpdateCalendar(id, calendar);
                return Ok(new { Success = true, Message = "Calendar Updated." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendar(int id)
        {
            try
            {
                await _calendar.DeleteCalendar(id);
                return Ok(new { Success = true, Message = "Calendar Deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
