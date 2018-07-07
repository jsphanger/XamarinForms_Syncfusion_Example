using System;
namespace SynchFusionExample
{
    public class ScheduleItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public ScheduleItem()
        {
            Title = string.Empty;
            StartDateTime = DateTime.UtcNow;
            EndDateTime = DateTime.UtcNow;
        }
    }
}
