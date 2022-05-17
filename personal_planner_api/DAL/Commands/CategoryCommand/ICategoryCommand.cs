using DTO;

namespace DAL
{
    public interface ICategoryCommand
    {
        public void CreateCategory(CategoryModel catData);
        public void ChangeCategory(CategoryModel catData);
    }
}
