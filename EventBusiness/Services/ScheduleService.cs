using EventData.Repository;
using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusiness.Services
{
    public class ScheduleService
    {
        IScheduleRepo _schedule;
        public ScheduleService(IScheduleRepo schedule)
        {
            _schedule = schedule;
        }
        public void Add(Schedule schedule)
        {
            _schedule.AddSchedule(schedule);
        }
    }
}
