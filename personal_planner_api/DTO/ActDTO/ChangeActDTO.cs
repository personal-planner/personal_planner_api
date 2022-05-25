using System;

namespace DTO
{
    public class ChangeActDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ActPriority Priority { get; set; }
        public DateTime ScheduledEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public int ScheduledDuration { get; set; }
    }
}
