using EventData.Repository;
using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusiness.Services
{
    public class EventService
    { 
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public bool AddEvent(EventModel eventData)
        {
            bool status = _eventRepository.AddEvent(eventData);
            return status;
        }
        public IList<EventModel> GetAll()
        {
            return _eventRepository.GetEvents();
        }
    }
}
