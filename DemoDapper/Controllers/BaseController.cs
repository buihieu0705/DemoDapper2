using DemoDapper.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase, IBaseController<T>
    {
        protected readonly IBaseRepository<T> repository;

        public BaseController(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var entities = await repository.GetAll();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await repository.GetById(id);
                if (entity == null) return NotFound();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<IActionResult> Create(T entity)
        {
            try
            {
                var createdEntity = await repository.Create(entity);
                return Ok(createdEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<IActionResult> Update(int id, T entity)
        {
            try
            {
                await repository.Update(id, entity);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await repository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
