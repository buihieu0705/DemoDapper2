using DemoDapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoDapper.Controllers
{
    public interface ICategoryController
    {
        Task<IActionResult> GetCategories();
        Task<IActionResult> GetCategoryById(int id);
        Task<IActionResult> CreateCategory(CategoryRequest cat);
        Task<IActionResult> GetCategoryWithProduct(int id);
        Task<IActionResult> DeleteCategory(int id);
        Task<IActionResult> UpdateCategory(int id, CategoryRequest cat);
    }
}
