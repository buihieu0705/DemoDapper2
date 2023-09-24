using DemoDapper.Models;

namespace DemoDapper.Repository
{
    public interface ICategoryRepository:IGenericRepository<Category, CategoryRequest, int>
    {
        Task<Category> GetCategoryWithProducts(int id);
    }
}
