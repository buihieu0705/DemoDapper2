using Microsoft.AspNetCore.Mvc;

namespace DemoDapper.Controllers
{
    public interface IBaseController<T>
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(T entity);
        Task<IActionResult> Update(int id, T entity);
        Task<IActionResult> Delete(int id);
    }
}
