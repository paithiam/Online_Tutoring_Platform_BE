using BbCenter.Dto.Schedule;
using BbCenter.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BbCenter.Controllers
{
    [Route("api/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost]
        public IActionResult CreateSchedule([FromBody] CreateScheduleDto createScheduleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _scheduleService.CreateSchedule(createScheduleDto);
                return Ok(new { message = "Schedule created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSchedule(Guid id, [FromBody] UpdateScheduleDto updateScheduleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _scheduleService.UpdateSchedule(updateScheduleDto, id);
                return Ok(new { message = "Schedule updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchedule(Guid id)
        {
            try
            {
                _scheduleService.DeleteSchedule(id);
                return Ok(new { message = "Schedule deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetScheduleById(Guid id)
        {
            try
            {
                var schedule = _scheduleService.GetScheduleById(id);
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllSchedules()
        {
            try
            {
                var schedules = _scheduleService.GetAllSchedules();
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("byDate")]
        public IActionResult GetSchedulesByDate([FromQuery] DateTime scheduleDate)
        {
            try
            {
                var schedules = _scheduleService.GetSchedulesByDate(scheduleDate);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("bySubjectOrParticipant")]
        public IActionResult GetSchedulesBySubjectIdOrParticipantId([FromBody] QueryDto queryDto)
        {
            try
            {
                var schedules = _scheduleService.GetSchedulesBySubjectIdOrParticipantId(queryDto);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }

}
