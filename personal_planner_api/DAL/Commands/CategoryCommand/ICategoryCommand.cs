using DTO;

namespace DAL
{
    public interface ICategoryCommand
    {
        public void CreateCategory(CategoryModel catData);
    }
}
