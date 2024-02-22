using EventData.DataContext;
using EventEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventData.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly EventDbContext _eventDbContext;
        //pass eventdbcontext reference->constructore
        public EventRepository(EventDbContext eventDbContext)
        {
            _eventDbContext = eventDbContext;
        }
        public bool AddEvent(EventModel eventData)
        {
            //insert into EventModel values('','','')
            _eventDbContext.EventModel.Add(eventData);
            //execute sql statement
            _eventDbContext.SaveChanges();
            return true;
        }
        public bool DeleteEvent(int id)
        {
            EventModel eventModel = _eventDbContext.EventModel.Find(id);
            _eventDbContext.EventModel.Remove(eventModel);
            _eventDbContext.SaveChanges();
            return true;
        }
        public EventModel GetEventModel(int id)
        {
            EventModel eventModel = _eventDbContext.EventModel.Find(id);
            return eventModel;
        }
        public IList<EventModel> GetEvents()
        {
            //select * from eventmodel
            IList<EventModel> list = _eventDbContext.EventModel.ToList();
            return list;
        }
        public bool UpdateEvent(EventModel eventData)
        {
            //update eventmodel set name=eventData.Name , type=eventData.Type where id=eventData.id
            _eventDbContext.Entry(eventData).State = EntityState.Modified;
            _eventDbContext.SaveChanges();//commit
            return true;
        }
    }
}
