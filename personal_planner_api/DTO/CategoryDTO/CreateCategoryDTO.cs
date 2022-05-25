using System;

namespace DTO
{
    public class CreateCategoryDTO
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public string ColorCode { get; set; }
        public string UserName { get; set; }
    }
}
