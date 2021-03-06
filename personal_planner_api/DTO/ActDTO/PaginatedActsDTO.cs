using System;
using System.Collections.Generic;

namespace DTO
{
    public class PaginatedActsResponceDTO
    {
        public int Total { get; set; }
        public bool HasNext { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<ActResponseDTO> Acts { get; set; }
    }

    public class PaginatedActsDTO
    { 
        public string UserName { get; set; }
        public IEnumerable<string> CategoriesId { get; set; }
        public int PageSize { get; set; } = 50;
        public int CurrentPage { get; set; } = 1;
        public string Filter { get; set; } = null;

    }
}
