namespace DemoDapper.Repository
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T entity);
        Task Delete(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Update(int id, T entity);
    }
}