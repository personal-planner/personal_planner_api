using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public interface ICategoryQuery
    {
        public IQueryable<CategoryModel> GetCategories(string userId);
    }
}
