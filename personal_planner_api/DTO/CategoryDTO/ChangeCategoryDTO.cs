using System;

namespace DTO
{
    public class ChangeCategoryDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public string ColorCode { get; set; }
    }
}
