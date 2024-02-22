using EventBusiness.Services;
using EventEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Xml;

namespace EventAPI.Controllers
{
    /*
     * RESPT API methods
     * HTTPGET,HTTPPOST,HTTPPUT,HTTPDELETE,HTTPPatch
     */
    //localhost:5700/api/event   -- HTTPGET
    [Route("api/[controller]")]//Route->API URL
    [ApiController]//class attribute- supports REST API 
    public class EventController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly EventService _eventService;
        public EventController(EventService eventService)
        {
            _eventService = eventService;
            _logger.Info("Constructor");
    }
    [HttpPost]//attribute
        public IActionResult AddEvent(EventModel eventData)
        {
            _logger.Info("AddEvent Entered...");
            var obj = new { status = "Inserted" };
            bool status = _eventService.AddEvent(eventData);
            _logger.Info("AddEvent service method called...");
            _logger.Info("AddEvent service response:" + status);
            if (status)
            {
                _logger.Info("AddEvent method response: Ok");
                return Ok(obj);//200 status Ok
            }
            else
            {
                _logger.Error("AddEvent method response: BadReq");
                return BadRequest();//400 Error
            }
        }

        [HttpGet("GetEvents")]
        public IActionResult GetEvent()
        {
            var result = _eventService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetEventById")]
        public IActionResult GetEvent(int id)
        {
            var result = _eventService.GetAll();
            return Ok(result);
        }
        [HttpPut("UpdateEvent")]
        public IActionResult UpdateEvent()
        {
            var result = _eventService.GetAll();
            return Ok(result);
        }
        [HttpDelete("DeleteEvent")]
        public IActionResult DeleteEvent(int id)
        {
            var result = _eventService.GetAll();
            return Ok(result);
        }
    }
}
