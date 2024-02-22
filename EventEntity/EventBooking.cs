using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEntity
{
    public class EventBooking
    {
//create table t1(id int,eventid int references eventmode(id)
        public int Id { get; set; }//pk

        [ForeignKey("eventModel")]
        public int EventId { get; set; }//fk
        public EventModel? eventModel { get; set; }//ref table

        [ForeignKey("userModel")]
        public int UserId { get; set; }//fk
        public UserModel? userModel { get; set; }
        public string EventDate { get; set; }
        public string status { get; set; }
    }
}
