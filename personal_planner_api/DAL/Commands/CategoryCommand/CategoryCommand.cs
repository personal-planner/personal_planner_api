using DTO;

namespace DAL
{
    public class CategoryCommand : ICategoryCommand
    {
        private PlannerDbContext context { get; }

        public CategoryCommand(PlannerDbContext context)
        {
            this.context = context;
        }

        public void CreateCategory(CategoryModel model)
        {
            context.Categories.Add(model);
            context.SaveChanges();
        }
    }
}
