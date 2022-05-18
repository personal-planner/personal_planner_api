using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryResponseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public string ColorCode { get; set; }
        public virtual IEnumerable<ActResponseDTO> Acts { get; set; }
    }
}
