using System.ComponentModel.DataAnnotations.Schema;

namespace EventEntity
{
    public class Schedule
    {
        public int Id { get; set; }
        public string date { get; set; }

        [ForeignKey("eventModel")]
        public int? EventId { get; set; }
        public virtual EventModel? eventModel { get; set; }
    }
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
