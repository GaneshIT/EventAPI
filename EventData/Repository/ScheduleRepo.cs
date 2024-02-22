using EventData.DataContext;
using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventData.Repository
{
    public class ScheduleRepo : IScheduleRepo
    {
        private EventDbContext _db;
        public ScheduleRepo(EventDbContext eventDbContext)
        {
            _db = eventDbContext;
        }
        public void AddSchedule(Schedule schedule)
        {
            _db.schedule.Add(schedule);
            _db.SaveChanges();
        }
    }
}
