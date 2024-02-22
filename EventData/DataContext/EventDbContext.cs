using EventEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventData.DataContext
{
    public class EventDbContext:DbContext
    {
        //Connection Establishment
        //DbSet configure
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
            //Connection Establishment
        }
        public DbSet<EventModel> EventModel { get; set; }
        public DbSet<UserModel> userModels { get; set; }
        public DbSet<EventBooking> eventBookings { get; set; }
        public DbSet<Schedule> schedule { get; set; }
    }
}
