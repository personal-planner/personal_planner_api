using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ActModel
    {
        public ActModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ActPriority Priority { get; set; }
        public DateTime ScheduledEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public int ScheduledDuration { get; set; }
        public string? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual CategoryModel Category { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserModel User { get; set; }
    }
}
