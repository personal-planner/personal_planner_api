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

        public void ChangeCategory(CategoryModel model)
        {
            context.Categories.Update(model);
            context.SaveChanges();
        }
    }
}
