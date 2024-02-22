using EventEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventData.Repository
{
    public interface IScheduleRepo
    {
        void AddSchedule(Schedule schedule);
    }
}
