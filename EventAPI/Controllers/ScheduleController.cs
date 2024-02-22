using EventBusiness.Services;
using EventEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;
        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [HttpPost]
        public IActionResult Add(Schedule schedule)
        {
            _scheduleService.Add(schedule);
            return Ok();
        }


    }
}
