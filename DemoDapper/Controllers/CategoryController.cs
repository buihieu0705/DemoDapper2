using DemoDapper.Models;
using DemoDapper.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<Category>, ICategoryController
    {
        //private readonly ICategoryRepository categoryRepo;

        //public CategoryController(ICategoryRepository categoryRepo)
        //{
        //    this.categoryRepo = categoryRepo;
        //}

        public CategoryController(IBaseRepository<Category> repository) : base(repository)
        {
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await ((ICategoryRepository)repository).GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var cat = await ((ICategoryRepository)repository).GetById(id);
                if (cat == null) return NotFound();
                return Ok(cat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryRequest cat)
        {
            try
            {
                var category = await ((ICategoryRepository)repository).Create(cat);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}/MultipleResult")]
        public async Task<IActionResult> GetCategoryWithProduct(int id)
        {
            try
            {
                var category = await ((ICategoryRepository)repository).GetCategoryWithProducts(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var cat = await ((ICategoryRepository)repository).GetById(id);
                if (cat == null) return NotFound();
                await ((ICategoryRepository)repository).Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryRequest cat)
        {
            try
            {
                var category = await ((ICategoryRepository)repository).GetById(id);
                if (category == null) return NotFound();
                await ((ICategoryRepository)repository).Update(id, cat);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
