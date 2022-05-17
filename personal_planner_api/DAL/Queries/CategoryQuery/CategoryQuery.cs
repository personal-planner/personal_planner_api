using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryQuery : ICategoryQuery
    {
        private PlannerDbContext context;

        public CategoryQuery(PlannerDbContext context)
        {
            this.context = context;
        }

        public IQueryable<CategoryModel> GetCategories(Guid userId)
        {
            return context.Categories.Include(c => c.Acts).Where(c => c.UserId == userId);
        }
    }
}
