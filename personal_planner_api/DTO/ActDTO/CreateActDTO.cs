using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class CreateActDTO
    {
        [JsonIgnore]
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ActPriority Priority { get; set; }
        public DateTime ScheduledEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public int ScheduledDuration { get; set; }
        public string CategoryId { get; set; }
    }
}
